using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Advent_Of_Code
{
    class FileController
    {

        public static string GetFileContents(string path)
        {
            string result = "";
            try
            {
                result = File.ReadAllText(path);
            } catch(FileNotFoundException fnfe)
            {
                ConsoleHelper.WriteError("Couldn't read file: " + path);
            }

            return result;
        }

    }
}
