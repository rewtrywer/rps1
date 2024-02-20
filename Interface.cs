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
            Console.WriteLine();
            Console.WriteLine("Выберите метод ввода данных:");
            Console.WriteLine("1. Ручной ввод");
            Console.WriteLine("2. Ввод из файла");
            Console.WriteLine("3. Выход");
            Console.WriteLine();
        }

        public static void GiveSaveMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Сохранить результат");
            Console.WriteLine("2. Сохранить входные условия");
            Console.WriteLine("3. Главное меню");
            Console.WriteLine();
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
                array[i] = Checks.checkDouble();
            }
            return array;
        }

        public static void SeeArray(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
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

                            methodChord();

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
                            
                            Calc.MethodChord(array, conditions);
                            
                            SaveMenu(array, conditions, x);

                        break;

                        case item1.file:
                            Console.WriteLine();
                            string path = File.GetFilePath();

                            File.AddArrayFromFile(array, conditions, path, Checks.IsValidFileForAddingArray(path));
                            Console.WriteLine();

                            Console.WriteLine("Коэффециенты кубического уравнения:");
                            SeeArray(array);
                            Console.WriteLine();

                            Console.WriteLine("Условия:");
                            SeeArray(conditions);

                            Calc.MethodChord(array, conditions);

                            SaveMenu(array, conditions, x);

                            break;

                        case item1.exit:

                            Environment.Exit(0);

                            break;
                    }

                }
                else
                    Console.WriteLine("Такого пункта нет в меню.");
            }
        }
    }
}
