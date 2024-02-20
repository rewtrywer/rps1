using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rps1
{
    internal class Interface
    {
        public static void GiveWelcomeMessage()
        {
            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine("Вариант №3 работы №1 был выполнен студенткой группы 423 Барановой Ариной.");
            Console.WriteLine("Задание: Отсортировать массив так, чтобы все чётные элементы были слева, а нечётные справа.");
        }

        enum item1
        {
            manual = 1,
            file,
            exit
        }

        enum item2
        {
            save = 1,
            conditions,
            main
        }

        public static void GiveMainMenu()
        {
            Console.WriteLine("Выберите метод ввода данных:");
            Console.WriteLine("1. Ручной ввод");
            Console.WriteLine("2. Ввод из файла");
            Console.WriteLine("3. Выход");
        }

        public static void GiveSaveMenu()
        {
            Console.WriteLine("1. Сохранить результат");
            Console.WriteLine("2. Сохранить входные условия");
            Console.WriteLine("3. Главное меню");
        }

        public static void InstructionEquation()
        {
            Console.WriteLine("Введите последоватьельно коэффициенты для кубического уравнения:");
        }

        public static void InstructionConditions()
        {
            Console.WriteLine("Введите последоватьельно первое приближение, второе приближение, погрешность:");
        }

        public static double[] AddArray(int size, double[] array)
        {
            /*Ввод с клавиатуры.*/
            for (int i = 0; i < size; i++)
            {
               // Console.WriteLine("Элемент {0}", i);
                //array[i] = Convert.ToInt32(Console.ReadLine());
                array[i] = Checks.checkDouble();
            }
            return array;
        }

        public static void SaveMenu(double[] array, double[] conditions, double x)
        {
            while (true)
            {
                GiveSaveMenu();
                if (int.TryParse(Console.ReadLine(), out int choice) && choice <= 3 && choice >= 1)
                {
                    item2 solution = (item2)choice;
                    switch (solution)
                    {
                        case item2.save:

                            File.SaveResultToFile(array, x);
                          
                            break;

                        case item2.conditions:

                            File.SaveInputData(array, conditions);

                        break;

                        case item2.main:

                            GiveMainMenu();

                        break;
                    }
                }
                else
                    Console.WriteLine("Такого пункта нет в меню.");
            }
        }

        public static double methodChord()
        {
            while (true)
            {
                GiveMainMenu();
                if (int.TryParse(Console.ReadLine(), out int choice) && choice <= 3 && choice >= 1)
                {
                    item1 solution = (item1) choice;
                    double[] array = new double[4];
                    double[] conditions = new double[3];
                    double x = 0;
                    
                    switch (solution){
                        case item1.manual:

                            InstructionEquation();
                            array = AddArray(4, array);

                            InstructionConditions();
                            conditions = AddArray(3, conditions);
                            
                            x = Calc.MethodChord(array, conditions);
                            Console.WriteLine("Ответ: " + x);

                            
                            SaveMenu(array, conditions, x);

                        break;

                        case item1.file:
                            string path = File.GetFilePath();
                            File.AddArrayFromFile(array, conditions, path, Checks.IsValidFileForAddingArray(path));
                            x = Calc.MethodChord(array, conditions);
                            Console.WriteLine("Ответ: " + x);


                            SaveMenu(array, conditions, x);

                            //(array, bool errFlag) = File.AddArrayFromFile(array, path, Checks.IsValidFileForAddingArray(path));
                            //if (errFlag)
                            //{
                            //    //size = array.Count();
                            //    //Array.Resize(ref SortArray, size);

                            //    Sort.SortEvenOdd2(array, SortArray);
                            //    SeeArray(size, array);
                            //    Console.WriteLine("___________________");
                            //    SeeArray(size, SortArray);
                            //    Save(array, SortArray);
                            //}
                            break;
                    }

                }
                else
                    Console.WriteLine("Такого пункта нет в меню.");
            }
        }
    }
}
