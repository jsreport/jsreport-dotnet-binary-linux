using jsreport.Binary.Linux;
using NUnit.Framework;
using Shouldly;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace jsreport.Binary.Test
{    
    [TestFixture]
    public class JsReportBinaryTest
    {
        [Test]
        public void ExtractAndRunJsReportBinary()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.Ignore("Test only for linux");
            }        

            var tmpFile = Path.GetTempFileName();

            using (var fs = File.Create(tmpFile))
            {
                JsReportBinary.GetBinary().ReadContent().CopyTo(fs);
            }

            var p = Process.Start(tmpFile, "--version");

            p.WaitForExit();

            p.ExitCode.ShouldBe(0);
        }
    }
}
