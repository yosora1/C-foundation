using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCompress
{
    class Program
    {
        //创建读取文本的流
        static void Main(string[] args)
        {
            String s="萌";
            using (FileStream fsRead = File.OpenRead(@"E:\C#_project\FileCompress\FileCompress\1.txt"))
            {
                //创建写入文本文件的流
                using (FileStream fsWrite = File.OpenWrite(@"E:\C#_project\FileCompress\FileCompress\compress.txt"))
                {
                    //创建压缩流
                    using (GZipStream zipStream = new GZipStream(fsWrite, CompressionMode.Compress))
                    {
                        //每次读取1024byte
                        byte[] byts = new byte[1024];
                        int len = 0;
                        while ((len = fsRead.Read(byts, 0, byts.Length)) > 0)
                        {
                            //通过压缩流写入文件
                            zipStream.Write(byts, 0, len);
                        }
                    }
                }
            }
            Console.WriteLine("ok");
            Console.ReadKey();

            ////////////////解压////////////////
            using (FileStream fsRead = File.OpenRead(@"E:\C#_project\FileCompress\FileCompress\compress.txt"))
            {
                using (GZipStream gzipStream = new GZipStream(fsRead, CompressionMode.Decompress))
                {
                    using (FileStream fsWrite = File.OpenWrite(@"E:\C#_project\FileCompress\FileCompress\uncompress.txt"))
                    {
                        byte[] byts = new byte[1024];
                        int len = 0;
                        while ((len = gzipStream.Read(byts, 0, byts.Length)) > 0)
                        {
                            fsWrite.Write(byts, 0, len);
                        }
                    }
                }
            }
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
