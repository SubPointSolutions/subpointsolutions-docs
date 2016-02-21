﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;

namespace SubPointSolutions.Docs.Code.Services
{
    public class S3Service
    {
        #region constructors

        public S3Service()
        {
            AccessKeyId = Environment.GetEnvironmentVariable("S3-AccessKeyId", EnvironmentVariableTarget.Machine);
            SecretAccessKey = Environment.GetEnvironmentVariable("S3-SecretAccessKey", EnvironmentVariableTarget.Machine);
        }

        #endregion

        public string AccessKeyId { get; set; }
        public string SecretAccessKey { get; set; }

        #region methods

        public void WithS3Client(Action<AmazonS3Client> action)
        {
            var amazonS3Config = new AmazonS3Config
            {
                ServiceURL = "http://s3.amazonaws.com",
            };

            using (var client = new AmazonS3Client(AccessKeyId, SecretAccessKey, amazonS3Config))
            {
                action(client);
            }
        }

        public void UploadFilesToBucket(string bucketName, string folderPath, bool isResursive = false)
        {
            if (!Directory.Exists(folderPath))
                return;

            WithS3Client(client =>
            {
                var op = SearchOption.AllDirectories;

                if (!isResursive)
                    op = SearchOption.TopDirectoryOnly;

                var files = Directory.GetFiles(folderPath, "*.*", op)
                                     .ToList();

                Parallel.ForEach(files, filePath =>
                {
                    GetObjectResponse existing = null;

                    var hash = CalculateMD5Hash(File.ReadAllBytes(filePath));
                    using (var inoutStream = File.Open(filePath, FileMode.Open))
                    {
                        var fileName = filePath.Replace(folderPath, string.Empty);

                        fileName = fileName.Substring(1, fileName.Length - 1);

                        fileName = fileName.Replace(@"\", @"/");
                        fileName = fileName.ToLower();

                        // ensure folder
                        EnsureFolder(client, bucketName, fileName.ToLower());

                        var index = files.IndexOf(filePath) + 1;

                        Trace.WriteLine(string.Format("adding [{0}/{1}] - {2}", index, files.Count, fileName));

                        try
                        {
                            existing = client.GetObject(bucketName, fileName);

                            var shouldUpdate = existing.Metadata["x-amz-meta-ci-md5"] != hash;

                            if (shouldUpdate)
                            {
                                var request = new PutObjectRequest
                                {

                                    Key = fileName,
                                    BucketName = bucketName,
                                    InputStream = inoutStream,
                                    CannedACL = S3CannedACL.PublicRead
                                };


                                request.Metadata.Add("x-amz-meta-ci-md5", hash);

                                client.PutObject(request);
                            }

                        }
                        catch (Exception eee)
                        {
                            Trace.WriteLine(eee.ToString());

                            if (eee is AmazonS3Exception)
                            {
                                existing = null;
                            }
                            else
                            {
                                throw;
                            }
                        }

                        if (existing == null)
                        {

                            var request = new PutObjectRequest
                            {
                                Key = fileName,
                                BucketName = bucketName,
                                InputStream = inoutStream,
                                CannedACL = S3CannedACL.PublicRead
                            };

                            request.Metadata.Add("x-amz-meta-ci-md5", hash);

                            client.PutObject(request);
                        }
                        else
                        {
                            existing.Dispose();
                            existing = null;
                        }

                    }
                });
            });
        }

        private void EnsureFolder(AmazonS3Client client, string bucketName, string fileName)
        {
            fileName = fileName.ToLower();

            var folder = Path.GetDirectoryName(fileName);

            if (!string.IsNullOrEmpty(folder))
            {
                var folders = folder.Split(new string[] { @"/", @"\" }, StringSplitOptions.RemoveEmptyEntries);

                var currentFolder = string.Empty;

                foreach (var folderName in folders)
                {
                    if (string.IsNullOrEmpty(currentFolder))
                        currentFolder = folderName;
                    else
                        currentFolder += "/" + folderName;

                    var aswFolder = currentFolder + "/";

                    var folderRequest = new PutObjectRequest
                    {
                        Key = aswFolder,
                        ContentBody = aswFolder,

                        BucketName = bucketName,
                        CannedACL = S3CannedACL.PublicRead
                    };
                    try
                    {
                        client.PutObject(folderRequest);
                    }
                    catch (Exception eee)
                    {
                        Trace.WriteLine(eee.ToString());

                        if (eee is AmazonS3Exception)
                        {

                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
        }

        public string CalculateMD5Hash(string input)
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            return CalculateMD5Hash(inputBytes);
        }

        public string CalculateMD5Hash(byte[] inputBytes)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        #endregion
    }
}