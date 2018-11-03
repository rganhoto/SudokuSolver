using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Core
{
    public class SolveMatrix
    {

        bool[,] editabledData = new bool[9, 9];
        int[,] xxxcurrentMatrix = new int[9, 9];
        bool _foundSolution = false;

        List<int> avialableValues = new List<int>();

        public int[,] Solve(int[,] matrix)
        {

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    editabledData[x, y] = matrix[x, y] == 0;
                    xxxcurrentMatrix[x, y] = matrix[x, y];
                }

                avialableValues.Add(x + 1);
            }




            FindCell(matrix, 0);

            //for (int i = 0; i < 9; i++)
            //{
            //    matrix[i, 0] = i + 1;
            //}

            return xxxcurrentMatrix;
        }

        private bool VerifyLine(ref int[,] matrix, int x, bool full)
        {
            List<int> values = new List<int>();
            for (int y = 0; y < 9; y++)
            {
                if (matrix[x, y] != 0)
                {
                    values.Add(matrix[x, y]);
                }
                else if (full)
                {
                    return false;
                }

            }

            if (values.Count == values.Distinct().Count())
                return true;
            return false;
        }

        private bool VerifyRow(ref int[,] matrix, int y, bool full)
        {
            List<int> values = new List<int>();
            for (int x = 0; x < 9; x++)
            {
                if (matrix[x, y] != 0)
                {
                    values.Add(matrix[x, y]);
                }
                else if (full)
                {
                    return false;
                }

            }

            if (values.Count == values.Distinct().Count())
                return true;
            return false;
        }

        private bool verifyCube(ref int[,] matrix, int x, int y, bool full)
        {
            int x1 = x / 3;
            int y1 = y / 3;

            List<int> values = new List<int>();
            for (x = x1 * 3; x < x1 * 3 + 3; x++)
            {
                for (y = y1 * 3; y < y1 * 3 + 3; y++)
                {
                    if (matrix[x, y] != 0)
                    {
                        values.Add(matrix[x, y]);
                    }
                    else if (full)
                    {
                        return false;
                    }

                }
            }

            if (values.Count == values.Distinct().Count())
                return true;
            return false;

        }
        
        private bool FindCell(int[,] matrix, int Current)
        {
            int x = Current % 9;
            int y = Current / 9;

            int[,] outputmatrix = matrix.Clone() as int[,];
            if (editabledData[x, y])
            {
                //TEST CELL
                Parallel.ForEach(avialableValues, (i, state) =>
                //for (int i = 1; i <= 9; i++)
                {

                    if (_foundSolution)
                    {
                        state.Break();
                        return;
                    }
                    //CLONE?
                    int[,] clonematrix = outputmatrix.Clone() as int[,];
                    clonematrix[x, y] = i;
                    //CleanUp(ref clonematrix, Current + 1);


                    //if (Current == 2)
                    //    PrintCurrentMatrix(outputmatrix);

                    if (!VerifyLine(ref clonematrix, x, false))
                        return;
                    if (!VerifyRow(ref clonematrix, y, false))
                        return;
                    if (!verifyCube(ref clonematrix, x, y, false))
                        return;

                    if (y == 8 && x == 8)
                    {
                        //FULL VERIFICATION
                        if (FullVerification(ref clonematrix))
                        {
                            outputmatrix = clonematrix;
                            xxxcurrentMatrix = outputmatrix;
                            _foundSolution = true;
                            state.Break();
                            return;
                        }
                        return;
                    }
                    else if (FindCell(clonematrix, Current + 1))
                    {
                        return;
                    }
                });
            }
            else
            {
                if (y == 8 && x == 8)
                {
                    //FULL VERIFICATION
                    if (FullVerification(ref matrix))
                    {
                        xxxcurrentMatrix = matrix;
                        return true;
                    }
                }

                //CleanUp(Current + 1);
                if (FindCell(matrix, Current + 1))
                    return true;
            }

            matrix = outputmatrix;

            return false;
        }


        private void CleanUp(ref int[,] matrix, int Current)
        {
            int x1 = Current % 9;
            int y1 = Current / 9;

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (x == x1 && y >= y1 || x > x1)
                        if (editabledData[x, y])
                            matrix[x, y] = 0;
                }
            }

        }

        private bool FullVerification(ref int[,] matrix)
        {
            for (int i = 0; i < 9; i++)
            {
                if (!VerifyLine(ref matrix, i, true))
                    return false;
                if (!VerifyRow(ref matrix, i, true))
                    return false;
            }

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (!verifyCube(ref matrix, x * 3, y * 3, true))
                        return false;
                }
            }
            return true;
        }


        //private void PrintCurrentMatrix(int[,] matrix)
        //{

        //    Debug.WriteLine("--------------------------------------------");
        //    Debug.WriteLine("--------------------------------------------");
        //    Debug.WriteLine("--------------------------------------------");
        //    for (int y = 0; y < 9; y++)
        //    {
        //        for (int x = 0; x < 9; x++)
        //        {
        //            Debug.Write(matrix[x, y] + " ");
        //        }
        //        Debug.WriteLine("");

        //    }

        //}

    }
}
