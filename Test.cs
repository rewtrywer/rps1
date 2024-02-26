using System;

namespace rps1
{

    internal class MathFunctionsTests
    {

        public static bool MethodChord_WhenRootExists_ReturnsCorrectSolutionAndFlag()
        {
            double[] array = new double[] { 1, -3, 3, -1 };
            double[] conditions = new double[] { 0, 1, 0.001 };

            (double resultCalc, bool err) = Calc.MethodChord(array, conditions);


            double result = 0.9006000999388758;
            if (resultCalc == result)
            {
                return true;
            }
            else
                return false;
        }
            
        public static bool MethodChord_WhenNoRootInInterval_ReturnsFlagAndNoSolution()
        {
            double[] array = new double[] { 1, 2, 3, 4 };
            double[] conditions = new double[] { 0, 1, 0,001 };

            (double result, bool err) = Calc.MethodChord(array, conditions);

            if(err == false)
            {
                return true;
            }
            else
                return false;
        }
    }
}
