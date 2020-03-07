using jsreport.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;

namespace jsreport.Binary.Linux
{
    public class JsReportBinary
    {
        /// <summary>
        /// Get jsreport executable from the assembly manifest stream
        /// </summary>        
        public static IReportingBinary GetBinary()
        {
            var assembly = typeof(JsReportBinary).GetTypeInfo().Assembly;

            return new ReportingBinary("default-linux-" + assembly.GetName().Version.ToString(),
                () => assembly.GetManifestResourceStream("jsreport.Binary.Linux.jsreport.zip"), true);
        }
    }
}
