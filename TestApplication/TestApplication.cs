using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinearRegressionLibrary;
namespace TestApplication
{
    class TestApplication
    {

        static void Main(string[] args)
        {

            Operations op = new Operations();

            ////////////////////////////////////////////////////////////////
            Console.WriteLine("Please enter the points");
            List<int[]> toBePassed = new List<int[]>();
            int iss = 0;
            while (iss < 5)
            {
                Console.Write("Please enter a point: ");
                string temp = Console.ReadLine();
                int[] temp2 = new int[] {int.Parse(temp.Split(' ')[0]), int.Parse(temp.Split(' ')[1])};
                toBePassed.Add(temp2);

                iss++;
            }
            ////////////////////////////////////////////////////////////////
            int[,] resultX = op.XPoints(toBePassed);
            int[,] resultY = op.YPoints(toBePassed);

            for (int i = 0; i < resultX.GetLength(0); i ++)
            {
                for (int j = 0; j < resultX.GetLength(1); j++)
                {
                    Console.Write(resultX[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < resultY.GetLength(0); i++)
            {
                for (int j = 0; j < resultY.GetLength(1); j++)
                {
                    Console.Write(resultY[i, j] + " ");
                }
                Console.WriteLine();
            }

            /////////////////////////////////////////////////////////////////////////


            int[,] productX = op.MultiplyMatrix(op.TransposeMatrix(resultX), resultX);
            int[,] productY = op.MultiplyMatrix(op.TransposeMatrix(resultX), resultY);
            Console.WriteLine("\n\nTranspose(X) * X= ");
            for (int i = 0; i < productX.GetLength(0); i++)
            {
                for (int j = 0; j < productX.GetLength(1); j++)
                {
                    Console.Write(productX[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\nTranspose(X) * Y= ");
            for (int i = 0; i < productY.GetLength(0); i++)
            {
                for (int j = 0; j < productY.GetLength(1); j++)
                {
                    Console.Write(productY[i, j] + " ");
                }
                Console.WriteLine();
            }



            ////////////////////////////////////////////////////////////////////
            int[,] pseudoInverse = op.GetPseudoInverse(productX);

            Console.WriteLine("\n\nPseudoInverse(prodX) * prodY: ");
            int[,] pseudoProduct = op.MultiplyMatrix(pseudoInverse, productY);
            for (int i = 0; i < pseudoProduct.GetLength(0); i++)
            {
                for (int j = 0; j < pseudoProduct.GetLength(1); j++)
                {
                    Console.Write(pseudoProduct[i, j] + " ");
                   
                }
                Console.WriteLine();
            }


            Console.WriteLine("\n\nDecimal Approximation:");
            for (int i = 0; i < pseudoProduct.GetLength(0); i++)
            {
                for (int j = 0; j < pseudoProduct.GetLength(1); j++)
                {
                    Console.Write(op.ApproximateFraction(new Fraction(pseudoProduct[i, j], op.GetDeterminant(productX)), 6));
                }
                Console.WriteLine();
            }


            Console.WriteLine("\n\nExact Value:");
            for (int i = 0; i < pseudoProduct.GetLength(0); i++)
            {
                for (int j = 0; j < pseudoProduct.GetLength(1); j++)
                {
                    Console.Write(op.ExactFraction(pseudoProduct[i,j], op.GetDeterminant(productX)));
                }
                Console.WriteLine();
            }

            
        }
    }
}
