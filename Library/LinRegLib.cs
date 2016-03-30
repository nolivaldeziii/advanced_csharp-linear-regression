using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LinearRegressionLibrary
{
    public struct Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction(int num, int den)
        {
            numerator = num;
            denominator = den;
        }

        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        public int Denominator
        {
            get { return denominator; }
            set { denominator = value; }
        }
    }

    public class Operations
    {
        int[,] XPointsArray = new int[1, 1];
        int[,] YPointsArray = new int[1, 1];
        public int[,] XPoints(List<int[]> points)
        {
            int[,] pointsArray = new int[points.ToArray().Length, 2];
            for (int i = 0; i < points.ToArray().Length; i++)
            {
                pointsArray[i, 1] = points[i][0];
                pointsArray[i, 0] = 1;
            }
            XPointsArray = pointsArray;
            return pointsArray;
        }
        public int[,] YPoints(List<int[]> points)
        {
            int[,] pointsArray = new int[points.ToArray().Length, 1];
            for (int i = 0; i < points.ToArray().Length; i++)
            {
                pointsArray[i, 0] = points[i][1];
            }
            YPointsArray = pointsArray;
            return pointsArray;
        }
        public  int[,] TransposeMatrix(int[,] toBeTransposed)
        {
            int[,] transposed = new int[toBeTransposed.GetLength(1), toBeTransposed.GetLength(0)];
            for (int i = 0; i < toBeTransposed.GetLength(0); i++)
            {
                for (int j = 0; j < toBeTransposed.GetLength(1); j++)
                {
                    transposed[j, i] = toBeTransposed[i, j];
                }
            }
            return transposed;
        }
        public  int[,] MultiplyMatrix(int[,] matA, int[,] matB)
        {

            int[,] prodMatrix = null;
            int[,] transposedB = null;
            ArrayList tempArray = new ArrayList();

            prodMatrix = new int[matA.GetLength(0), matB.GetLength(1)];
            transposedB = TransposeMatrix(matB);

            for (int i = 0; i < matA.GetLength(0); i++)
            {
                for (int k = 0; k < matB.GetLength(1); k++)
                {
                    int temp = 0;
                    for (int j = 0; j < matA.GetLength(1); j++)
                    {
                        temp += transposedB[k, j] * matA[i, j];
                    }
                    tempArray.Add(temp);
                }
            }
            int x = 0;
            for (int i = 0; i < tempArray.ToArray().Length; i++)
            {
                if (i != 0 && i % prodMatrix.GetLength(1) == 0)
                {
                    x++;
                }
                prodMatrix[x, i % prodMatrix.GetLength(1)] = Convert.ToInt32(tempArray[i]);
            }
            return prodMatrix;

        }
        public int GetDeterminant(int[,] toBeDetermined)
        {
            int det = (toBeDetermined[0, 0] * toBeDetermined[1, 1]) - (toBeDetermined[0, 1] * toBeDetermined[1, 0]);
            if (det == 0)
                throw new DeterminantIsZero();
            return det;
        }

        public int[,] GetPseudoInverse(int[,] toPseudoInverse)
        {
            int[,] pseudoInverse = new int[2, 2];

            pseudoInverse[0, 0] = toPseudoInverse[1, 1];
            pseudoInverse[1, 1] = toPseudoInverse[0, 0];
            pseudoInverse[0, 1] = -1 * toPseudoInverse[0, 1];
            pseudoInverse[1, 0] = -1 * toPseudoInverse[1, 0];

            return pseudoInverse;
        }
        //FractionOperations
        public Fraction SimplifyFraction(Fraction toSimplify)
        {
            int GCF = 1;

            List<int> factorsNumerator = new List<int>();
            List<int> factorsDenominator = new List<int>();

            bool numeratorIsNeg = toSimplify.Numerator < 0;
            bool denominatorisNeg = toSimplify.Denominator <0;

            int numeratorTemp = Math.Abs(toSimplify.Numerator);
            int denominatorTemp = Math.Abs(toSimplify.Denominator);

            // numerator loop
            while (true)
            {
                if (numeratorTemp % 3 == 0)
                {
                    factorsNumerator.Add(3);
                    numeratorTemp = numeratorTemp / 3;
                }
                else if (numeratorTemp % 5 == 0)
                {
                    factorsNumerator.Add(5);
                    numeratorTemp = numeratorTemp / 5;
                }
                else if (numeratorTemp % 7 == 0)
                {
                    factorsNumerator.Add(7);
                    numeratorTemp = numeratorTemp / 7;
                }
                else if (numeratorTemp % 2 == 0)
                {
                    factorsNumerator.Add(2);
                    numeratorTemp = numeratorTemp / 2;
                }
                else
                {
                    factorsNumerator.Add(numeratorTemp);
                    break;
                }
            }

            // denominator loop

            while (true)
            {
                if (denominatorTemp % 3 == 0)
                {
                    factorsDenominator.Add(3);
                    denominatorTemp = denominatorTemp / 3;
                }
                else if (denominatorTemp % 5 == 0)
                {
                    factorsDenominator.Add(5);
                    denominatorTemp = denominatorTemp / 5;
                }
                else if (denominatorTemp % 7 == 0)
                {
                    factorsDenominator.Add(7);
                    denominatorTemp = denominatorTemp / 7;
                }
                else if (denominatorTemp % 2 == 0)
                {
                    factorsDenominator.Add(2);
                    denominatorTemp = denominatorTemp / 2;
                }
                else
                {
                    factorsDenominator.Add(denominatorTemp);
                    break;

                }
            }

            for (int i = 0; i < factorsNumerator.ToArray().Length; i++)
            {
                for (int j = 0; j < factorsDenominator.ToArray().Length; j++)
                {
                    if (factorsNumerator[i] == factorsDenominator[j])
                    {
                        GCF *= factorsNumerator[i];
                        factorsDenominator[j] = int.MinValue;
                        break;

                    }
                }
            }
            Fraction result =  new Fraction(toSimplify.Numerator / GCF, toSimplify.Denominator / GCF);         
            if (denominatorisNeg)
                result = new Fraction(toSimplify.Numerator / GCF * -1, toSimplify.Denominator / GCF * -1);
            else if (numeratorIsNeg && denominatorisNeg)
                 result =  new Fraction(toSimplify.Numerator / GCF*-1, toSimplify.Denominator / GCF*-1);
            else
                result = new Fraction(toSimplify.Numerator / GCF, toSimplify.Denominator / GCF); 

            return result;
        }
        public double ApproximateFraction(Fraction toApproximate, int decimalPlaces)
        {
            double quo = (double)toApproximate.Numerator / (double)toApproximate.Denominator;
           
            return Math.Round(quo, decimalPlaces);
        }
        public string ExactFraction(int numerator, int denominator)
        {
            Fraction f = SimplifyFraction(new Fraction(numerator, denominator));
            string fraction = f.Numerator + "/" + f.Denominator;
            return fraction;
        }
        public Fraction SubtractFraction(Fraction one, Fraction two)
        {
            if (one.Denominator == two.Denominator)
            {
                return SimplifyFraction(new Fraction(one.Numerator - two.Numerator, one.Denominator));
            }
            else
            {
                Fraction sum = new Fraction();

                int LCM = 1;

                List<int> factorsNumerator = new List<int>();
                List<int> factorsDenominator = new List<int>();

                int numeratorTemp = one.Numerator;
                int denominatorTemp = two.Denominator;

                // numerator loop
                while (true)
                {
                    if (numeratorTemp % 3 == 0)
                    {
                        factorsNumerator.Add(3);
                        numeratorTemp = numeratorTemp / 3;
                    }
                    else if (numeratorTemp % 5 == 0)
                    {
                        factorsNumerator.Add(5);
                        numeratorTemp = numeratorTemp / 5;
                    }
                    else if (numeratorTemp % 7 == 0)
                    {
                        factorsNumerator.Add(7);
                        numeratorTemp = numeratorTemp / 7;
                    }
                    else if (numeratorTemp % 2 == 0)
                    {
                        factorsNumerator.Add(2);
                        numeratorTemp = numeratorTemp / 2;
                    }
                    else
                    {
                        factorsNumerator.Add(numeratorTemp);
                        break;

                    }
                }

                // denominator loop

                while (true)
                {
                    if (denominatorTemp % 3 == 0)
                    {
                        factorsDenominator.Add(3);
                        denominatorTemp = denominatorTemp / 3;
                    }
                    else if (denominatorTemp % 5 == 0)
                    {
                        factorsDenominator.Add(5);
                        denominatorTemp = denominatorTemp / 5;
                    }
                    else if (denominatorTemp % 7 == 0)
                    {
                        factorsDenominator.Add(7);
                        denominatorTemp = denominatorTemp / 7;
                    }
                    else if (denominatorTemp % 2 == 0)
                    {
                        factorsDenominator.Add(2);
                        denominatorTemp = denominatorTemp / 2;
                    }
                    else
                    {
                        factorsDenominator.Add(denominatorTemp);
                        break;
                    }
                }

                for (int i = 0; i < factorsNumerator.ToArray().Length; i++)
                {
                    for (int j = 0; j < factorsDenominator.ToArray().Length; j++)
                    {
                        if (factorsNumerator[i] == factorsDenominator[j])
                        {
                            LCM *= factorsNumerator[i];
                            factorsDenominator[j] = 1;
                            factorsNumerator[i] = 1;
                            break;

                        }
                    }
                }

                for (int i = 0; i < factorsNumerator.ToArray().Length; i++)
                {
                    LCM *= factorsNumerator[i];
                }

                for (int i = 0; i < factorsDenominator.ToArray().Length; i++)
                {
                    LCM *= factorsDenominator[i];
                }

                sum.Denominator = LCM;
                sum.Numerator = (sum.Denominator / one.Denominator * one.Numerator) -
                                (sum.Denominator / two.Denominator * two.Numerator);


                return SimplifyFraction(sum);
            }
        }
        public object MultiplyFractionByInt(Fraction one, int two)
        {
            Fraction prod = new Fraction();
            prod.Numerator = one.Numerator * two;
            prod.Denominator = one.Denominator;
            prod = SimplifyFraction(prod);

            if (prod.Denominator != 1)
                return prod;
            else
                return prod.Numerator;

        }
        public object[] Collinear(int X1, int Y1)
        {
            object[] result = new object[2];

            // object[0] is the slope
            // object[1] is the intercept

            Fraction slope =  SimplifyFraction(new Fraction(Y1, X1));
            if (slope.Denominator == 1)
                result[0] = slope.Numerator;
            else
                result[0] = slope;   
            
            object xSlopeProduct = MultiplyFractionByInt(slope, X1);

            if (xSlopeProduct is Fraction)
                result[1] = SubtractFraction(new Fraction(Y1, 1), (Fraction)xSlopeProduct);
            else
                result[1] = Y1 - (int)xSlopeProduct;

            return result;
        }
        public bool Is45Degrees(List<int[]> vals)
        {
            for (int i = 1; i < vals.ToArray().Length; i++)
            {
                if ((vals[i - 1][0] * vals[i][1]) - (vals[i - 1][1] * vals[i][0]) != 0)
                    return false;
            }

            return true;
        }
        public bool IsVertical(List<int[]> vals)
        {
            int temp = vals[0][0];
            for (int i = 0; i < vals.ToArray().Length; i++)
            {
                if (temp != vals[i][0])
                    return false;
            }
            return true;
        }
        public bool isHorizontal(List<int[]> vals)
        {
            int temp = vals[0][1];
            for (int i = 0; i < vals.ToArray().Length; i++)
            {
                if (temp != vals[i][1])
                    return false;
            }
            return true;
        }
        public bool IsJustEqual(List<int[]> vals)
        {
            int temp1 = vals[0][0];
            int temp2 = vals[0][1];
            for (int i = 0; i < vals.ToArray().Length; i++)
            {
                if (temp1 != vals[i][0] || temp2 != vals[i][1])
                    return false;
            }
            return true;
        }
    }


    public class DeterminantIsZero : SystemException
    {
        public DeterminantIsZero()
            : base()
        { }
    }
    public class Is45Degrees : SystemException
    {
        public Is45Degrees()
            : base()
        { }
    }
    public class IsVerticalException : SystemException
    {
        public IsVerticalException()
            : base()
        { }
    }
    public class IsHorizontalException : SystemException
    {
        public IsHorizontalException()
            : base()
        { }
    }
    public class IsJustEqualException : SystemException
    {
        public IsJustEqualException()
            : base()
        { }
    }
}
