# XLIFexctract

## Intro

This program reads an XLIFF created containing opentm2 files and then creates 2 files:

* An XLSX file with the state/word count/source/target of each one of the files.
* An Excel file with the main info of the XLIFF

NOTE: ONLY xliff files with opentm2 folders are intendend for this program.

This program has been developed and compiled in a Microsoft Visual Studio Community
2019 with Net Core 3.1 framework environment.

## Example

* Source file ```u:\tmp\FOLDER_LAN_SHIP.xlf```

![XLIF source file](docimages/01_xlif_file.gif?raw=true "XLIF")

* Run the program

```

C:\tmp>XLIFextract.exe u:\tmp\FOLDER_LAN_SHIP.xlf
XLIFextract (c) 2021 miguel canals MIT License
File   -> u:\tmp\FOLDER_LAN_SHIP.xlf
File u:\tmp\FOLDER_LAN_SHIP.xlf is valid
EOP.
```

There will be 2 target files:

* ```FOLDER_LAN_SHIP.xlsx```. This file will contain all segments with its status
and also the unit ```id='information'```

![XLSX target file](docimages/02_xlsx_result.file.gif?raw=true "XLSX")

* ```FOLDER_LAN_SHIP_xbench.xliff```. This file can be loaded as a xliff file in Apsic XBench
(free version)


(c) miguel canals 2021 MIT License (www.mknals.com) 