using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SubPointSolutions.Docs.Code.Data;

namespace SubPointSolutions.Docs.Services.Base
{
    public abstract class SamplesServiceBase
    {
        public string FileExtension { get; set; }

        public List<DocSample> LoadSamples(string srcFolderPath)
        {
            return LoadSamples(srcFolderPath, true);
        }

        public virtual List<DocSample> LoadSamples(string srcFolderPath, bool recursive)
        {
            var result = new List<DocSample>();

            var files = GetFiles(srcFolderPath, recursive);

            foreach (var file in files)
                result.AddRange(CreateSamplesFromSourceFile(file));

            foreach (var r in result)
            {
                if (r.Language == "js")
                {

                }

                r.MethodBody = NormilizeBody(r.MethodBody);
            }

            return result;
        }

        protected virtual IEnumerable<string> GetFiles(string srcFolderPath, bool recursive)
        {
            if (string.IsNullOrEmpty(FileExtension))
                throw new ArgumentException("FileExtension");

            var search = SearchOption.TopDirectoryOnly;
            if (recursive)
                search = SearchOption.AllDirectories;

            return Directory.GetFiles(srcFolderPath, FileExtension, search);
        }

        public abstract IEnumerable<DocSample> CreateSamplesFromSourceFile(string filePath);

        protected string NormilizeBody(string body)
        {
            return NormilizeBody(body, string.Empty);
        }

        protected virtual string NormilizeBody(string body, string startString)
        {
            var lines = body.Split(new string[] { Environment.NewLine, "\n", "\r\n" }, StringSplitOptions.None);

            string firstLine = null;

            if (!string.IsNullOrEmpty(startString))
                firstLine = lines.FirstOrDefault(l => l.Contains(startString));


            //var firstLineStarts = new List<string>();

            //// C#?
            //firstLineStarts.Add("public");
            //firstLineStarts.Add("using");
            //firstLineStarts.Add("var");
            //firstLineStarts.Add(@"//");

            //// XML?
            //firstLineStarts.Add(@"<");

            //// JS?
            //firstLineStarts.Add(@"function");
            //firstLineStarts.Add(@"SOD");
            //firstLineStarts.Add(@"SP.");
            //firstLineStarts.Add(@"window");

            //foreach (var startLine in firstLineStarts)
            //{
            //    if (firstLine == null)
            //    {
            //        firstLine = lines.FirstOrDefault(l => l.Contains(startLine));

            //        if (firstLine != null)
            //        {
            //            startString = startLine;
            //            break;
            //        }
            //    }
            //}


            var startIndex = 0;

            foreach (var line in lines)
            {

                startIndex =0;
                foreach (var letter in line)
                {
                    if (char.IsLetterOrDigit(letter) && !string.IsNullOrEmpty(letter + ""))
                    {
                        firstLine = line;
                        break;
                    }

                    startIndex++;
                }

                //startString = startLine;
            }

            if (firstLine != null)
            {
                var charsToRemove = startIndex;

                for (int i = 0; i < lines.Length; i++)
                {
                    var currentLine = lines[i];

                    //if (currentLine.StartsWith(" ") && currentLine.Length > charsToRemove)
                    if (currentLine.Length > charsToRemove)
                    {
                        currentLine = currentLine.Substring(charsToRemove, currentLine.Length - charsToRemove);
                        lines[i] = currentLine;
                    }
                }
            }

            //lines
            var result = string.Empty;

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(result) &&
                    (string.IsNullOrEmpty(line) || string.IsNullOrEmpty(line.Replace(" ", string.Empty))))
                    continue;

                result += line.TrimEnd() + Environment.NewLine;
            }

            //var result = string.Join(Environment.NewLine, lines);

            //result = result.Trim();

            return result;
        }

    }
}
