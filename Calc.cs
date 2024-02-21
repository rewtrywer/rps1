using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rps1
{
    internal class Calc
    {
        private static double F(double x, double a, double b, double c, double d)
        {
            double result = a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + c * x + d;
            return result;
        }

        public static (double solution, bool errflag) MethodChord(double[] array, double[] conditions)
        {
            double a = array[0];
            double b = array[1];
            double c = array[2];
            double d = array[3];
            double x0 = conditions[0];
            double x1 = conditions[1];
            double e = conditions[2];

            // Начать с предположения, что корень находится в середине интервала.
            double solution = (x0 + x1) / 2;
            bool errflag = true;

            if (F(x0, a, b, c, d) * F(x1, a, b, c, d) > 0)
            {
                errflag = false;
                return (solution, errflag);
               // Console.WriteLine("Нет корней в данном интервале.");
            }
            else
            { 
                // Продолжать итерации до тех пор, пока значение функции в точке решения не будет в пределах желаемого интервала ошибок.
                while (Math.Abs(F(solution, a, b, c, d)) > e)
                {
                    solution = x0 - F(x0, a, b, c, d) * (solution - x0) /
                                                 (F(solution, a, b, c, d) - F(x0, a, b, c, d));
                    //Console.WriteLine(Math.Abs(F(solution, a, b, c, d)) + " " + e + " " + solution);
                }
                // Console.WriteLine("Ответ: " + solution);
                return (solution, errflag);
            }  
        }
    }

}

