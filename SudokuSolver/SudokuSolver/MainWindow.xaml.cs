using SudokuSolver.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SudokuSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //INIT SUDOKU

            btnSolve.Click += BtnSolve_Click;

            a1.SetText(0, 0, 5);
            a1.SetText(1, 0, 3);
            a1.SetText(0, 1, 6);
            a1.SetText(1, 2, 9);
            a1.SetText(2, 2, 8);

            a2.SetText(1, 0, 7);
            a2.SetText(0, 1, 1);
            a2.SetText(1, 1, 9);
            a2.SetText(2, 1, 5);

            a3.SetText(1, 2, 6);

            a4.SetText(0, 0, 8);
            a4.SetText(0, 1, 4);
            a4.SetText(0, 2, 7);

            a5.SetText(1, 0, 6);
            a5.SetText(0, 1, 8);
            a5.SetText(2, 1, 3);
            a5.SetText(1, 2, 2);

            a6.SetText(2, 0, 3);
            a6.SetText(2, 1, 1);
            a6.SetText(2, 2, 6);

            a7.SetText(1, 0, 6);

            a8.SetText(0, 1, 4);
            a8.SetText(1, 1, 1);
            a8.SetText(2, 1, 9);
            a8.SetText(1, 2, 8);

            a9.SetText(0, 0, 2);
            a9.SetText(1, 0, 8);
            a9.SetText(2, 1, 5);
            a9.SetText(1, 2, 7);
            a9.SetText(2, 2, 9);

        }

        private void BtnSolve_Click(object sender, RoutedEventArgs e)
        {
            //build matrix
            var matrix = UiToMatrix();
            var _solvedMatrix = new SolveMatrix().Solve(matrix);

            MatrixToUi(_solvedMatrix);
        }

        private int[,] UiToMatrix()
        {
            int[,] matrix = new int[9, 9];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    //fill matrix
                    matrix[x, y] = a1.getNumber(x, y);
                    matrix[x + 3, y] = a2.getNumber(x, y);
                    matrix[x + 6, y] = a3.getNumber(x, y);
                    matrix[x, y + 3] = a4.getNumber(x, y);
                    matrix[x + 3, y + 3] = a5.getNumber(x, y);
                    matrix[x + 6, y + 3] = a6.getNumber(x, y);
                    matrix[x, y + 6] = a7.getNumber(x, y);
                    matrix[x + 3, y + 6] = a8.getNumber(x, y);
                    matrix[x + 6, y + 6] = a9.getNumber(x, y);
                }
            }
            return matrix;
        }


        private void MatrixToUi(int[,] matrix)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    //fill matrix
                    a1.SetText(x, y, matrix[x, y]);
                    a2.SetText(x, y, matrix[x + 3, y]);
                    a3.SetText(x, y, matrix[x + 6, y]);
                    a4.SetText(x, y, matrix[x, y + 3]);
                    a5.SetText(x, y, matrix[x + 3, y + 3]);
                    a6.SetText(x, y, matrix[x + 6, y + 3]);
                    a7.SetText(x, y, matrix[x, y + 6]);
                    a8.SetText(x, y, matrix[x + 3, y + 6]);
                    a9.SetText(x, y, matrix[x + 6, y + 6]);
                }
            }
        }



    }
}
