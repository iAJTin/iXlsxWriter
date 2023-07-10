
What is iXlsxWriter?
====================

iXlsxWriter is a lightweight implementation that allows creates a xlsx document totally or partially


Changes in this version v1.0.2
==============================

· Added
  -----
    
    - Add support for netstandard2.1
 
        - Add SplitEnumerator ref struct.
   
        - Add support for the use of the ~ character in the iTin.Core.IO library

        - ByteReader class rewritten to work with Span in net core projects.

· Changed
  -------

    - Library versions for this version

    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | Library                               Version     Description                                                                        |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Charting.Models                  1.0.0.1     Base library containing various extensions, helpers, common constants for charting |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core                             2.0.0.7     Base library containing various extensions, helpers, common constants              |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.Drawing                     1.0.0.3     Drawing objects, extension, helpers, common constants                              |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.IO                          1.0.0.2     Common I/O calls                                                                   |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.IO.Compression              1.0.0.1     Compression library                                                                |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.Models                      1.0.0.3     Data models base                                                                   |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.Models.Design.Charting      1.0.0.3     Base charting models                                                               |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.Models.Design.Styling       1.0.0.3     Base styling models                                                                |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Logging                          1.0.0.3     Logging library                                                                    |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Registry.Windows                 1.0.0.3     Common classes for model definitions                                               |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Utilities.Xlsx.Design            1.0.0.2     Xlsx Design Elements                                                               |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Utilities.Xlsx.Writer            1.0.0.2     Xlsx Writer                                                                        |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•

v1.0.1
======

· Fixed
  -----

  - Upgrade Newtonsoft.Json nuget package to version 13.0.1 (without critical errors)
  - Upgrade nuget packages not critical

· Added
  -----

    - Library documentation.

    - tools folder in solution root. Contains a script for update help md files.

· Changed
  -------

    - Changed IResultGeneric interface. Changed Value property name by Result (for code clarify).

      · This change may have implications in your final code, it is resolved by changing Value to Result

    - Update result classes for support more scenaries.

    - Library versions for this version

    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | Library                               Version     Description                                                                        |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Charting.Models                  1.0.0.1     Base library containing various extensions, helpers, common constants for charting |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core                             2.0.0.3     Base library containing various extensions, helpers, common constants              |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.Drawing                     1.0.0.1     Drawing objects, extension, helpers, common constants                              |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.IO                          1.0.0.0     Common I/O calls                                                                   |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.IO.Compression              1.0.0.1     Compression library                                                                |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.Models                      1.0.0.1     Data models base                                                                   |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.Models.Design.Charting      1.0.0.1     Base charting models                                                               |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.Models.Design.Styling       1.0.0.1     Base styling models                                                                |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Logging                          1.0.0.1     Logging library                                                                    |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Registry.Windows                 1.0.0.1     Common classes for model definitions                                               |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Utilities.Xlsx.Design            1.0.0.1     Xlsx Design Elements                                                               |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Utilities.Xlsx.Writer            1.0.0.1     Xlsx Writer                                                                        |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•


v1.0.0
======

· Added
  -----

    - Library versions for this version

    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | Library                               Version     Description                                                                        |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Charting.Models                  1.0.0.0     Base library containing various extensions, helpers, common constants for charting |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core                             2.0.0.0     Base library containing various extensions, helpers, common constants              |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.Drawing                     1.0.0.0     Drawing objects, extension, helpers, common constants                              |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.IO                          1.0.0.0     Common I/O calls                                                                   |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.IO.Compression              1.0.0.0     Compression library                                                                |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.Models                      1.0.0.0     Data models base                                                                   |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.Models.Design.Charting      1.0.0.0     Base charting models                                                               |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.Models.Design.Styling       1.0.0.0     Base styling models                                                                |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Logging                          1.0.0.0     Logging library                                                                    |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Registry.Windows                 1.0.0.0     Common classes for model definitions                                               |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Utilities.Xlsx.Design            1.0.0.0     Xlsx Design Elements                                                               |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Utilities.Xlsx.Writer            1.0.0.0     Xlsx Writer                                                                        |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•


Install via NuGet
=================

PM> Install-Package iXlsxWriter

For more information, please see https://www.nuget.org/packages/iXlsxWriter/


Documentation
=============

 - For Writer code documentation, please see next link https://github.com/iAJTin/iXlsxWriter/blob/master/documentation/iTin.Utilities.Xlsx.Writer.md


Usage
=====

Examples
--------

Coming soon!!!
