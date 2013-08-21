This README file contains instructions for installing, customizing and using JsonToXml Parser.

Insatalation:
1.Copy the JsonToXmlParser Class
2.Add using System.Xml
3.Download and install JSON framework for .NET from Nuget Packages
4.Add using Newtonsoft.Json

Usage:

1.To get json string you need use JsonToXml method with path to xml file

2.To get xml document you need to use XmlToJson method with parameter this json string, after conversation you can make xml file with doc.Save("filename") or use XmlWriter - http://msdn.microsoft.com/en-us/library/system.xml.xmlwriter.aspx