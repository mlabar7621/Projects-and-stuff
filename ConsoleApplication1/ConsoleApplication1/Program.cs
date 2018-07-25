using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static string containsFileFolder;
        static string referenceFolder;
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter container folder");
            containsFileFolder = (@"C:\Users\Vladimir_2\Desktop\Stuff"); //Console.ReadLine()
            Console.WriteLine("Please enter folder to write to");
            referenceFolder = (@"C:\Users\Vladimir_2\Desktop\References"); //Console.ReadLine()
            string[] fileNames = Directory.GetFiles(String.Format("{0}", containsFileFolder));
            for (int o = 0; o < fileNames.Length; o++)
            {
                string interpolated = String.Format(@"{0}", fileNames[o]);
                string FileText = File.ReadAllText(interpolated);
                string[] arr = CheckFile(FileText);
                CreateReferences(arr, fileNames[o], referenceFolder);
            }
        }

        public static string[] CheckFile(string FileText)
        {
            string[] arr = new string[1000];
            int startFileName;
            int arrIndex = 0;
            for (int i = 0; i < FileText.Length; i++)
            {
                if (FileText[i] == 'D')
                {
                    if (FileText[i + 1] == 'S')
                    {
                        if (FileText[i + 2] == 'N')
                        {
                            if (FileText[i + 3] == '=')
                            {
                                startFileName = i+4;
                                while (true)
                                {
                                    if (FileText[startFileName] == ',' || FileText[startFileName] == ' ')
                                    {
                                        break;
                                    }
                                    arr[arrIndex] += FileText[startFileName];
                                    startFileName++;
                                }
                                arrIndex++;
                            }
                        }
                    }
                }
            }
            arr = CleanArray(arr);
            return arr;
        }

        public static string[] CleanArray(string[] arr)
        {
            int i = 0;
            int arrLength = 0;
            while (true)
            {
                if (arr[i] != null)
                {
                    arrLength++;
                }
                else
                {
                    break;
                }
                i++;
            }
            string[] arrFinal = new string[arrLength];
            for (int j = 0; j < arrLength; j++)
            {
                arrFinal[j] = arr[j];
            }
            Array.Resize(ref arr, 0);
            for (int j = 0; j < arrLength; j++)
            {
                if (arr.Contains(arrFinal[j]))
                {
                }
                else
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length - 1] = arrFinal[j];
                }
            }
            return arr;
        }

        public static void CreateReferences(string[] arr, string oldFilePath, string newFilePath)
        {
            string fileName = "";
            for (int j = 0; j < oldFilePath.Length; j++)
            {
                if (oldFilePath.ToCharArray()[j] == 'P')
                {
                    if (oldFilePath.ToCharArray()[j + 1] == 'H')
                    {
                        if (oldFilePath.ToCharArray()[j + 2] == 'R')
                        {
                            int i = j;
                            while (true)
                            {
                                fileName += oldFilePath.ToCharArray()[i];
                                if (oldFilePath.ToCharArray()[i+1] == '.')
                                {
                                    break;
                                }
                                i++;
                            }
                            break;
                        }
                    }
                }
            }
            if(fileName == "")
            {
                for (int j = 0; j < oldFilePath.Length; j++)
                {
                    if (oldFilePath.ToCharArray()[j] == 'U')
                    {
                        if (oldFilePath.ToCharArray()[j + 1] == 'S')
                        {
                            if (oldFilePath.ToCharArray()[j + 2] == 'M')
                            {
                                int i = j;
                                while (true)
                                {
                                    fileName += oldFilePath.ToCharArray()[i];
                                    if (oldFilePath.ToCharArray()[i + 1] == '.')
                                    {
                                        break;
                                    }
                                    i++;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            if (fileName == "")
            {
                for (int j = 0; j < oldFilePath.Length; j++)
                {
                    if (oldFilePath.ToCharArray()[j] == 'P')
                    {
                        if (oldFilePath.ToCharArray()[j + 1] == 'A')
                        {
                            if (oldFilePath.ToCharArray()[j + 2] == 'Y')
                            {
                                int i = j;
                                while (true)
                                {
                                    fileName += oldFilePath.ToCharArray()[i];
                                    if (oldFilePath.ToCharArray()[i + 1] == '.')
                                    {
                                        break;
                                    }
                                    i++;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            newFilePath += "\\" + fileName + "_reference.cob";
            using (StreamWriter sw = File.CreateText(newFilePath))
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    sw.WriteLine(arr[j]);
                }
            }
        }
    }
}
