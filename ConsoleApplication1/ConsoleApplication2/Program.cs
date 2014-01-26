using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication2
{

    class Program
    {
        private const string FILE_PATH="C:\\Temp\\Test.txt";
        private const Int32 MAX_CHARS_PER_LINE = 64;
        private const Int32 MAX_LINES = 64;

        static void Main(string[] args)
        {

            Console.WriteLine(File.Exists(FILE_PATH) ? "File exists." : "File does not exist.");
            if (!File.Exists(FILE_PATH))
            {
                makeFile(FILE_PATH);
            }

            Console.ReadKey();
        }

        static void makeFile(string strPath)
        {
            FileStream objFile = File.OpenWrite(strPath);
            Random objRandom = new Random();
            byte[] bytFileData=new byte[(MAX_CHARS_PER_LINE+2)*MAX_LINES];
            objRandom.NextBytes(bytFileData);

            for (int intLineEnd = MAX_CHARS_PER_LINE + 1; intLineEnd <= (MAX_CHARS_PER_LINE + 2) * MAX_LINES; intLineEnd += MAX_CHARS_PER_LINE)
            {
                bytFileData[intLineEnd]=13;
                bytFileData[intLineEnd+1]=10;
            }

            objFile.Write(bytFileData, 0, (MAX_CHARS_PER_LINE + 2) * MAX_LINES);
            //int intCharCount = Convert.ToInt32(objRandom.NextDouble() * MAX_CHARS_PER_LINE);
            //int intLineCount = Convert.ToInt32(objRandom.NextDouble() * MAX_LINES);
            //int intCurrentLine = 0;
            //byte[] bytFileData = new byte[intCharCount];
            //while (intCurrentLine < intLineCount)
            //{
            //    
            //    int
            //    //objRandom.NextBytes(bytFileData);
            //    //objFile.Write(bytFileData, 0, intCharCount);
            //    intLineCount += 1;
            //}
            objFile.Dispose();
        }
    }
}
