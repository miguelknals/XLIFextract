using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// code

namespace XLIFextract
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("XLIFextract (c) 2021 miguel canals MIT License");
            bool commandlineerrors = false;
            string inpfileORI = "none";
            string segtype = "";
            if (args.Length == 1)
            {
                inpfileORI = args[0].Trim();
                if (!File.Exists(inpfileORI))
                {
                    Console.WriteLine("");
                    Console.WriteLine("ERROR -> Looks like XLIF file '{0}' does not exist", inpfileORI);
                    commandlineerrors = true;
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("ERROR -> Specify only the xlif file");
                commandlineerrors = true;
            }
            // continue

            if (commandlineerrors)
            {
                Console.WriteLine(" ");
                Console.WriteLine("This program reads and xlif that follow opentm2 export format and exports to an xlsx file. The correct format is: ");
                Console.WriteLine("");
                Console.WriteLine("XLIFextract.exe path\\file.xlf");
                Console.WriteLine("");
                return;
            }

            Console.WriteLine("File   -> {0}", inpfileORI);

            XmlSerializer ser = new XmlSerializer(typeof(xliff));
            xliff myxliff;
            using (Stream stream = new FileStream(inpfileORI, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                myxliff = (xliff)ser.Deserialize(stream);
            }

            if (myxliff!=null)
            {
                Console.WriteLine("File {0} is valid", inpfileORI);
            } else
            {
                Console.WriteLine("ERROR -> File {0} is NOT valid.", inpfileORI);
                Console.WriteLine("");
                Console.WriteLine("Fatal error. ");
                Console.WriteLine("File should follow the xliff standard for opentm2 folders. ");
                return;

            } 
            if (Path.GetFileNameWithoutExtension(inpfileORI).Length>30)
            {
                Console.WriteLine("File {0} is valid.", inpfileORI);
                Console.WriteLine("ERROR -> Max lenght filename cannot exceed 30 chars.");
                Console.WriteLine("");
                Console.WriteLine("Fatal error. ");
                return; 

            }

            Console.WriteLine("INFO -> Extracting info from {0} is valid.", inpfileORI);
            var totalsegments = new List<xliffFileUnitSegment>();
            var totalids = new List<string>();
            XLIFextract.xliffFile[] files = myxliff.file;
            foreach (var file in files)
            {
                xliffFileUnit[] units = file.unit;
                foreach (var unit in units)
                {
                    string unitid = unit.id;
                    xliffFileUnitSegment[] segments = unit.segment;
                    foreach (var segment in segments)
                    {
                        /* Console.WriteLine(segment.state);
                        Console.WriteLine(segment.wordcount);
                        Console.WriteLine(segment.source);
                        Console.WriteLine(segment.target); */
                        totalsegments.Add(segment);
                        totalids.Add(unitid);
                    }
                        
                }

            }


            // got all segments in total
            int RC = 0;
            Console.WriteLine("INFO -> Calling Excel creating");
            RC = CreateExcel(totalsegments,totalids, inpfileORI);
            Console.WriteLine("INFO -> Calling Xbench xliff");
            RC = CreateFinalTabFile(totalsegments, totalids, inpfileORI);



            Console.WriteLine("EOP.");

            int CreateExcel(List<xliffFileUnitSegment> segmentlist, List<string> segids, string xlffile)
            {
                string exten = Path.GetExtension(xlffile);
                string sheetname = Path.GetFileNameWithoutExtension(xlffile);
                string xlsxfile = xlffile.Replace(exten, ".xlsx");

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(sheetname);
                    int filenum = 1;
                    worksheet.Cell("A1").Value = "state";
                    worksheet.Cell("B1").Value = "wct";
                    worksheet.Cell("C1").Value = "source";
                    worksheet.Cell("D1").Value = "target";
                    worksheet.Column("C").Width = 100;
                    worksheet.Column("C").Style.Alignment.WrapText=true;
                    worksheet.Column("D").Width = 100;
                    worksheet.Column("D").Style.Alignment.WrapText = true;
                    foreach (var seg in segmentlist)
                    {
                        filenum += 1;
                        worksheet.Cell(string.Format("A{0}", filenum)).Value = seg.state;
                        worksheet.Cell(string.Format("B{0}", filenum)).Value = seg.wordcount;                        
                        worksheet.Cell(string.Format("C{0}", filenum)).Value = seg.source;
                        worksheet.Cell(string.Format("D{0}", filenum)).Value = seg.target;
                    }

                    filenum = 1;
                    worksheet.Cell("E1").Value = "infoid";
                    worksheet.Column("E").Width = 100;
                    foreach (var segid  in segids)
                    {
                        filenum += 1;
                        worksheet.Cell(string.Format("E{0}", filenum)).Value = segid;                        
                    }

                    // worksheet.Cell("A1").Value = "Hello World!";
                    //# worksheet.Cell("A2").FormulaA1 = "=MID(A1, 7, 5)";
                    workbook.SaveAs(xlsxfile );
                }

                return 0;


            }


            int CreateFinalTabFile(List<xliffFileUnitSegment> segmentlist, List<string> segids, string xlffile)
            {

                string exten = Path.GetExtension(xlffile);
                string aux = Path.GetFileNameWithoutExtension(xlffile);
                string tabfile = xlffile.Replace(exten, "_xbench.xliff");

                string cr = "\r\n";
                using (StreamWriter writetext = new StreamWriter(tabfile))
                {
                    int seg_counter = -1;
                    string cabecera= @"<?xml version=""1.0""?>" ;
                    cabecera += @"<xliff version=""1.2"">";
                    cabecera += @"<file source-language=""EN"" datatype=""plaintext"" original=""{0}"">" ;
                    cabecera = string.Format(cabecera, exten );
                    cabecera += @"<body>" ;
                    string filler_trans_unit = @"<trans-unit id=""{0}"">";
                    //string filler_source = @"<source><![CDATA[{0}]]></source>";
                    //string filler_target = @"<target state=""{0}""><![CDATA[{1}]]></target>";
                    string filler_source = @"<source>{0}</source>";
                    string filler_target = @"<target state=""{0}"">{1}</target>";
                    string filler_end_trans_unit = @"</trans-unit>" ;
                    string footer_tabfile = @"</body>" + cr + @"</file>" + cr + @"</xliff>";

                    writetext.WriteLine(cabecera);

                    foreach (var seg in segmentlist)
                    {
                        seg_counter += 1;
                        writetext.WriteLine(string.Format(filler_trans_unit, seg_counter.ToString() ));
                        writetext.WriteLine(string.Format(filler_source, EscapeXml(seg.source )));
                        writetext.WriteLine(string.Format(filler_target, seg.state, EscapeXml(seg.target )));
                        writetext.WriteLine(string.Format(filler_end_trans_unit));
                        if (seg_counter == 3e10)
                        {
                            break;
                        }
                     
                    }

                    writetext.WriteLine(footer_tabfile);
                }

                return 0;


            }

            //https://stackoverflow.com/questions/22906722/how-to-encode-special-characters-in-xml
            string EscapeXml(string s)
            {
                string toxml = s;
                if (!string.IsNullOrEmpty(toxml))
                {
                    // replace literal values with entities
                    toxml = toxml.Replace("&", "&amp;");
                    toxml = toxml.Replace("'", "&apos;");
                    toxml = toxml.Replace("\"", "&quot;");
                    toxml = toxml.Replace(">", "&gt;");
                    toxml = toxml.Replace("<", "&lt;");
                }
                return toxml;
            }

            string UnescapeXml(string s)
            {
                string unxml = s;
                if (!string.IsNullOrEmpty(unxml))
                {
                    // replace entities with literal values
                    unxml = unxml.Replace("&apos;", "'");
                    unxml = unxml.Replace("&quot;", "\"");
                    unxml = unxml.Replace("&gt;", ">");
                    unxml = unxml.Replace("&lt;", "<");
                    unxml = unxml.Replace("&amp;", "&");
                }
                return unxml;
            }

        }

    }
}
