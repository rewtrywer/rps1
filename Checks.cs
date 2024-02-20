using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rps1
{
    internal class Checks
    {
        public static double checkDouble()
        {
            Double number = 0;
            bool errFlag = false;
            do
            {
                string? input = Console.ReadLine();
                errFlag = !Double.TryParse(input, out number);
                if (errFlag)
                {
                    Console.WriteLine("Ошибка ввода! Попробуйте снова.");
                }
            } while (errFlag);

            return number;
        }

        public static string rightChoice()
        {
            string? input = Console.ReadLine();
            if (input != "y" && input != "n")
            {
                while (input != "y" && input != "n")
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите 'y' или 'n':");
                    input = Console.ReadLine();
                }
                return input;
            }
            else
            {
                return input;
            }
        }

        public static bool IsValidFileForAddingArray(string filePath)
        {
            bool errFlag = true;

            if (!System.IO.File.Exists(filePath))
            {
                Console.WriteLine("Файл не существует.");
                errFlag = false;
                return errFlag;
            }

            using (StreamReader formatReader = new StreamReader(filePath))
            {
                while (!formatReader.EndOfStream)
                {
                    bool result = int.TryParse(formatReader.ReadLine(), out var temp);
                    if (result == false)
                    {
                        Console.WriteLine("Ошибка. В файле некорректные данные");
                        errFlag = false;
                        return errFlag;
                    }
                }
            }

            using (StreamReader sizeReader = new StreamReader(filePath))
            {
                if (!sizeReader.EndOfStream)
                {
                    int size = int.Parse(sizeReader.ReadLine());

                    int sizeCehcker = 0;

                    while (!sizeReader.EndOfStream)
                    {
                        var tempVal = sizeReader.ReadLine();
                        sizeCehcker++;
                    }
                    if (sizeCehcker != size)
                    {
                        Console.WriteLine("Ошибка. Количество данных не совпадает с размером массива");
                        errFlag = false;
                        return errFlag;
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("Ошибка чтения файла: файл пуст.");
                    return false;
                }
            }
        }
    }
}
