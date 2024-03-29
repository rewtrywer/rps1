﻿using System;

namespace rps1
{
    internal class Interface
    {
        public static void GiveWelcomeMessage()
        {
            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine("Вариант №3 работы №1 был выполнен студенткой группы 423 Барановой Ариной.");
            Console.WriteLine("Задание: Решить уравнение методом хорд.");
        }

        enum item1
        {
            manual = 1,
            file,
            test,
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
            Console.WriteLine("3. Тестирование");
            Console.WriteLine("4. Выход");
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

        public static double[] AddArray( double[] array)
        {
            int size = array.Length;
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

           // MathFunctionsTests obj = new MathFunctionsTests();
            while (true)
            {
                GiveMainMenu();
                if (int.TryParse(Console.ReadLine(), out int choice) && choice <= 4 && choice >= 1)
                {
                    item1 solution = (item1) choice;
                    double[] array = new double[0];
                    double[] conditions = new double[0];
                    double x = 0;
                    double result = 0;
                    bool errFlagCalc = true;
                    bool errFlagFile = true;
                    bool areEqual = true;
                    double[] zeroArrayCoeff = new double[] { 0, 0, 0, 0 };

                    switch (solution){
                        case item1.manual:
                            Array.Resize(ref array, 4);
                            Array.Resize(ref conditions, 3);
                            InstructionEquation();
                            array = AddArray(array);
                           
                            areEqual = array.SequenceEqual(zeroArrayCoeff);
                            if (!areEqual)
                            {
                                InstructionConditions();
                                conditions = AddArray(conditions);
                                if (conditions[0] >= conditions[1])
                                {
                                    Console.WriteLine("Некорректные данные.");
                                }
                                else
                                {
                                    (result, errFlagCalc) = Calc.MethodChord(array, conditions);
                                    if (errFlagCalc)
                                        Console.WriteLine("Ответ: " + result);
                                    else
                                        Console.WriteLine("Нет корней на данном интервале.");

                                    SaveMenu(array, conditions, x);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Некорректные данные.");
                                
                            }

                            break;

                        case item1.file:
                            Console.WriteLine();
                            string path = File.GetFilePath();
 
                            (array, conditions, errFlagFile) = File.AddArrayFromFile(array, conditions, path, Checks.IsValidFileForAddingArray(path));
                            if (errFlagFile)
                            {
                                areEqual = array.SequenceEqual(zeroArrayCoeff);
                                if (!areEqual && (conditions[0] < conditions[1]))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Коэффециенты кубического уравнения:");
                                    SeeArray(array);
                                    Console.WriteLine();
                                    Console.WriteLine("Условия:");
                                    SeeArray(conditions);

                                    (result, errFlagCalc) = Calc.MethodChord(array, conditions);
                                    if (errFlagCalc)
                                    {
                                        Console.WriteLine("Ответ: " + result);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Нет корней на данном интервале.");
                                    }

                                    SaveMenu(array, conditions, x);
                                }
                                else
                                {
                                    Console.WriteLine("Некорректные данные.");
                                }
                            }

                            break;

                        case item1.test:
                            Console.WriteLine();
                            bool test1 = MathFunctionsTests.MethodChord_WhenRootExists_ReturnsCorrectSolutionAndFlag();
                            bool test2 = MathFunctionsTests.MethodChord_WhenNoRootInInterval_ReturnsFlagAndNoSolution();
                            if (test1 && test2)
                            {
                                Console.WriteLine("Тест пройден.");
                            }
                            else
                                Console.WriteLine("Тест не пройден.");

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
