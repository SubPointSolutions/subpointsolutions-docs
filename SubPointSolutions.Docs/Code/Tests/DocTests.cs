using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using SubPointSolutions.Docs.Code.Services;
using System;

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

            WyamFolderFullPath = Path.Combine(WorkingDirectory, WyamRelativeFolder);
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
        [TestCategory("CI.Core")]
        public void Publish_Docs()
        {
            var netlifyContentFolder = ContentDirectory;
            var branch = GetGlobalEnvironmentVariable("APPVEYOR_REPO_BRANCH");

            var netlifyDevSiteId = GetGlobalEnvironmentVariable("Netlify-SiteId-SPSDocs-Dev");
            var netlifyProdSiteId = GetGlobalEnvironmentVariable("Netlify-SiteId-SPSDocs-Prod");

            var netlifyApiKey = GetGlobalEnvironmentVariable("Netlify-ApiKey");
            var netlifySiteId = netlifyDevSiteId;

            if (!string.IsNullOrEmpty(branch) && "master".Equals(branch, StringComparison.OrdinalIgnoreCase))
            {
                netlifySiteId = netlifyProdSiteId;
            }

            if (string.IsNullOrEmpty(netlifySiteId))
                throw new Exception("netlifySiteId");

            if (string.IsNullOrEmpty(netlifyApiKey))
                throw new Exception("netlifyApiKey");

            Console.WriteLine("Building from branch:" + branch);
            Trace.WriteLine("Building from branch:" + branch);

            RunWyam();

            // any index file after Wyam?
            var hasIndexFile = Directory.GetFiles(netlifyContentFolder, "*.html", SearchOption.TopDirectoryOnly)
                                        .Count() > 0;

            Assert.AreEqual(true, hasIndexFile,
                string.Format("Cannot find *.html file in directory:[{0}]",
                netlifyContentFolder));

            RunCmd("npm", "install netlify-cli -g");
            RunCmd("netlify", string.Format("deploy -s {0} -t {1} -p {2}", netlifySiteId, netlifyApiKey, netlifyContentFolder));
        }

        private string GetGlobalEnvironmentVariable(string name)
        {
            var result = System.Environment.GetEnvironmentVariable(name, System.EnvironmentVariableTarget.Process);

            if (String.IsNullOrEmpty(result))
                result = System.Environment.GetEnvironmentVariable(name, System.EnvironmentVariableTarget.User);

            if (String.IsNullOrEmpty(result))
                result = System.Environment.GetEnvironmentVariable(name, System.EnvironmentVariableTarget.Machine);

            return result;
        }

        private void RunS3(string bucketName)
        {
            var service = new S3Service();
            service.UploadFilesToBucket(bucketName, ContentDirectory, true);
        }

        #endregion

        #region utils

        private void RunCmd(string fileName, string arguments)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments
                }
            };

            process.Start();
            process.WaitForExit(5 * 60 * 1000);

            Assert.IsTrue(process.ExitCode == 0);
        }

        private void RunWyam()
        {
            var process = new Process();

            process.StartInfo.WorkingDirectory = WyamFolderFullPath;
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

        public string WyamFolderFullPath { get; set; }
    }
}
