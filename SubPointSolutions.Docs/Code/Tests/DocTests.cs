using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using SubPointSolutions.Docs.Code.Services;

namespace SubPointSolutions.Docs.Code.Tests
{
    [TestClass]
    public class DocTests
    {
        #region constructors

        public DocTests()
        {
            WyamRelativeFolder = "Wyam 0.11.1-beta";
            WorkingDirectory = Path.GetFullPath("../../").TrimEnd('\\');

            WyamExeFullPath = Path.Combine(WorkingDirectory, WyamRelativeFolder + "/wyam.exe");
            WyamExeArgs = string.Format("--input \"{0}\\Views\" --output \"{0}\\Views-Output\" --config  \"{0}\\_site.wyam\" --verbose \"{0}\"", WorkingDirectory);

            ContentDirectory = Path.Combine(WorkingDirectory, "Views-Output");
        }

        #endregion

        #region properties

        public string WorkingDirectory { get; set; }
        public string ContentDirectory { get; set; }
        public string WyamRelativeFolder { get; set; }

        public string WyamExeFullPath { get; set; }

        public string WyamExeArgs { get; set; }

        #endregion

        #region tests

        [TestMethod]
        [TestCategory("Dev")]
        public void Publish_Dev()
        {
            RunWyam();
            RunS3("docs-dev.subpointsolutions.com");
        }

        private void RunS3(string bucketName)
        {
            var service = new S3Service();
            service.UploadFilesToBucket(bucketName, ContentDirectory, true);
        }

        #endregion

        #region utils

        private void RunWyam()
        {
            var process = new Process();

            process.StartInfo.FileName = WyamExeFullPath;
            process.StartInfo.Arguments = WyamExeArgs;

            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            process.OutputDataReceived += (s, e) => Trace.WriteLine(e.Data);
            process.ErrorDataReceived += (s, e) => Trace.WriteLine(e.Data);

            process.Start();

            process.BeginOutputReadLine();
            process.WaitForExit();

            Assert.AreEqual(0, process.ExitCode);
        }

        #endregion
    }
}
