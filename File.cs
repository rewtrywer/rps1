using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rps1
{
    internal class File
    {
        public static string GetFilePath()
        {
            Console.WriteLine("Введите имя файла:");
            string filePath = @"C:\Users\Арина\Desktop\сем 4\rps1\" + Console.ReadLine();
            do
            {
                if (!System.IO.File.Exists(filePath))
                {
                    Console.WriteLine("Файл по указанному пути не найден. Пожалуйста, введите другой путь:");
                    filePath = @"C:\Users\Арина\Desktop\сем 4\rps1\" + Console.ReadLine();
                }
            } while (!System.IO.File.Exists(filePath));

            return filePath;
        }

        public static void SaveResultToFile(double[] array, double x)
        {
            string filePath = GetFilePath();

            double a = array[0];
            double b = array[1];
            double c = array[2];
            double d = array[3];

            if (System.IO.File.Exists(filePath))
            {
                Console.WriteLine("Файл по указанному пути уже существует. Хотите перезаписать его? (y/n)");
                string answer = Checks.rightChoice();

                if (answer.ToLower() == "y")
                {
                    using (StreamWriter writer = new StreamWriter(filePath, false))
                    {
                        writer.WriteLine(a);
                        writer.WriteLine(b);
                        writer.WriteLine(c);
                        writer.WriteLine(d);
                        writer.WriteLine(x);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Файл перезаписан.");
                }
                else

                    Console.WriteLine("Операция отменена.");

            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine(a);
                    writer.WriteLine(b);
                    writer.WriteLine(c);
                    writer.WriteLine(d);
                    writer.WriteLine(x);
                }
            }
        }

        public static void SaveInputData(double[] array, double[] conditions)
        {
            string filePath = GetFilePath();

            double a = array[0];
            double b = array[1];
            double c = array[2];
            double d = array[3];
            double x0 = conditions[0];
            double x1 = conditions[1];
            double e = conditions[2];

            if (System.IO.File.Exists(filePath))
            {
                Console.WriteLine("Файл по указанному пути уже существует. Хотите перезаписать его? (y/n)");
                string answer = Checks.rightChoice();

                if (answer.ToLower() == "y")
                {

                    using (StreamWriter writer = new StreamWriter(filePath, false))
                    {
                        writer.WriteLine(a);
                        writer.WriteLine(b);
                        writer.WriteLine(c);
                        writer.WriteLine(d);
                        writer.WriteLine(x0);
                        writer.WriteLine(x1);
                        writer.WriteLine(e);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Файл перезаписан.");
                }
                else

                    Console.WriteLine("Операция отменена.");

            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine(a);
                    writer.WriteLine(b);
                    writer.WriteLine(c);
                    writer.WriteLine(d);
                    writer.WriteLine(x0);
                    writer.WriteLine(x1);
                    writer.WriteLine(e);
                }
            }
        }

        public static (double[] array, bool errFlag) AddArrayFromFile(double[] array, double[] conditions, string filePath, bool f)
        {
            if (f)
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        array = array.Concat(new double[] { double.Parse(reader.ReadLine()) }).ToArray();
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        conditions = conditions.Concat(new double[] { double.Parse(reader.ReadLine()) }).ToArray();
                    }

                }
                return (array, f);
            }
            else
            {
                Console.WriteLine("Добавлен пустой массив");
                return (array, f);
            }
        }
    }
}
