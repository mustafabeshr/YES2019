using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace YES.appcode
{
    /// <summary>
    /// Contains all general functions for example check regular expression matching.
    /// </summary>
    class Utility
    {
        public static bool ValidRegEx(string value, string role)
        {
            Regex rg = new Regex(role);
            return rg.IsMatch(value);
        }
        public static bool IsValidDate(string DateValue)
        {
            try
            {
                DateTime.Parse(DateValue);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool OnlyNumber(char c, bool AllowDecimal, object sender)
        {
            bool res = false;
            if (!AllowDecimal)

                if (!char.IsControl(c) && !char.IsDigit(c))
                    res = true;
                else
                    res = false;

            else
            {
                if (!char.IsControl(c) && !char.IsDigit(c) && (c != '.'))
                    res = true;
                else
                    res = false;


                // only allow one decimal point
                int s = (sender as TextBox).Text.IndexOf('.');
                if ((c == '.') && (s == -1))
                    res = false;

            }
            return res;
        }

        public static bool ObjectIsNull(ref object obj_Data)
        {
            bool isNotNull = true;
            try
            {
                if (obj_Data.Equals(null))
                {
                    isNotNull = false; 
                }
                else
                {
                    isNotNull = true;
                }
            }
            catch (NullReferenceException)
            {
                isNotNull = false;
            }
            return !isNotNull;
        }
        public static string GetLocalIPAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
        }
        public static string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }
        public static string GetMachineName()
        {
            //string name = Environment.MachineName;
            string name = System.Net.Dns.GetHostName();
            //string name = System.Windows.Forms.SystemInformation.ComputerName;
            //string name = System.Environment.GetEnvironmentVariable(“COMPUTERNAME”);
            return name;
        }
        public static bool IsBoolean(string value)
        {
            bool result = false;
            if (!Boolean.TryParse(value,out result))
            {
                result = false;
            }
           return result;
        }

        public static string GetKeyValueFromConfigFile(string p_name)
        {
            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file
            string key = (string)settingsReader.GetValue(p_name, typeof(String));
            return key;
        }
    }



    public class Printable : IDisposable
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        private string _PrinterName = string.Empty;
        private bool _OnlyOnePage = false;
        public string PrinterName
        {
            get
            {
                return _PrinterName;
            }

            set
            {
                _PrinterName = value;
            }
        }

        public bool OnlyOnePage
        {
            get
            {
                return _OnlyOnePage;
            }

            set
            {
                _OnlyOnePage = value;
            }
        }

        private DataTable LoadSalesData()
        {
            // Create a new DataSet and read sales data file 
            //    data.xml into the first DataTable.
            System.Data.DataSet dataSet = new DataSet();
            dataSet.ReadXml(@"..\..\data.xml");
            return dataSet.Tables[0];
        }
        // Routine to provide to the report renderer, in order to
        //    save an image for each page of the report.
        private Stream CreateStream(string name,
          string fileNameExtension, Encoding encoding,
          string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0.0in</MarginTop>
                <MarginLeft>0.0in</MarginLeft>
                <MarginRight>0.0in</MarginRight>
                <MarginBottom>0.0in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            if (_OnlyOnePage)
            {
                ev.HasMorePages = false;
            }
            else
            {
                ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
            }
        }
        [DllImport("winspool.Drv", EntryPoint = "GetDefaultPrinter")]
        public static extern bool GetDefaultPrinter(
         StringBuilder pszBuffer,   // printer name buffer
         ref int pcchBuffer  // size of name buffer
         );
        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                //if (string.IsNullOrEmpty(_PrinterName))
                //{
                //    StringBuilder name = new StringBuilder();
                //    int length = 100;
                //    GetDefaultPrinter(name, ref length);
                //    _PrinterName = name.ToString();
                //}
                //PrinterSettings ps = new PrinterSettings();
                //IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();
                //PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A4); // setting paper size to A4 size
                //printDoc.DefaultPageSettings.PaperSize = sizeA4;
                //printDoc.PrinterSettings.PrinterName = _PrinterName;
                //printDoc.PrinterSettings.PrinterName = "PDFCreator";
                //printDoc.PrinterSettings.PrinterName = Db.GetPrinterName(Utility.GetMACAddress());
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage); 
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

       
        // Create a local report for Report.rdlc, load the data,
        //    export the report to an .emf file, and print it.
        public void Run(string ReportName,string DatasetName,DataTable dt)
        {
            LocalReport report = new LocalReport();
            report.ReportPath = ReportName;
            report.DataSources.Add(
               new ReportDataSource(DatasetName, dt));
            Export(report);
            Print();
        }

        public void Run(string ReportName, string DatasetName, DataTable dt, ReportParameter[] parameters)
        {
            LocalReport report = new LocalReport();
            report.ReportPath = ReportName;
            report.DataSources.Add(
               new ReportDataSource(DatasetName, dt));
            report.SetParameters(parameters);
            Export(report);
            Print();
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }

        //public static void Main(string[] args)
        //{
        //    using (Demo demo = new Demo())
        //    {
        //        demo.Run();
        //    }
        //}
    }
}
