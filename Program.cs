using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;



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

            int RC = CreateExcel(totalsegments,totalids, inpfileORI);

            

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


        }

    }
}
