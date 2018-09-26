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
            AddExecutePermissions(tmpFile);  

            var p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = tmpFile,
                    Arguments = "--version",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            p.Start();
            while (!p.StandardError.EndOfStream)
            {
                Console.WriteLine(p.StandardError.ReadLine());                
            }

            while (!p.StandardOutput.EndOfStream)
            {
                Console.WriteLine(p.StandardOutput.ReadLine());
            }
         
            p.WaitForExit();
            p.ExitCode.ShouldBe(0);
        }

        [DllImport("libc", SetLastError = true)]
        private static extern int chmod(string pathname, int mode);

        private void AddExecutePermissions(string path)
        {
            const int S_IRUSR = 0x100;
            const int S_IWUSR = 0x80;
            const int S_IXUSR = 0x40;

            // group permission
            const int S_IRGRP = 0x20;
            const int S_IWGRP = 0x10;
            const int S_IXGRP = 0x8;

            // other permissions
            const int S_IROTH = 0x4;
            const int S_IWOTH = 0x2;
            const int S_IXOTH = 0x1;

            const int _0755 =
                S_IRUSR | S_IXUSR | S_IWUSR
                | S_IRGRP | S_IXGRP
                | S_IROTH | S_IXOTH;
            chmod(path, (int)_0755);
        }
    }
}
