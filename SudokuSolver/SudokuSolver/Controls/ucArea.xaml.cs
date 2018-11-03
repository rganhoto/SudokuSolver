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

namespace SudokuSolver.Controls
{
    /// <summary>
    /// Interaction logic for ucArea.xaml
    /// </summary>
    public partial class ucArea : UserControl
    {
        public ucArea()
        {
            InitializeComponent();
            t1.TextChanged += text_TextChanged;
            t2.TextChanged += text_TextChanged;
            t3.TextChanged += text_TextChanged;
            t4.TextChanged += text_TextChanged;
            t5.TextChanged += text_TextChanged;
            t6.TextChanged += text_TextChanged;
            t7.TextChanged += text_TextChanged;
            t8.TextChanged += text_TextChanged;
            t9.TextChanged += text_TextChanged;
        }

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {
            //VALIDATE
        }

        public int getNumber(int x, int y)
        {
            string text = GetText(x, y);

            int data = 0;
            if (int.TryParse(text, out data))
                return data;
            return 0;
        }

        private string GetText(int x, int y)
        {
            switch (y * 3 + x)
            {
                case 0:
                    return t1.Text;
                case 1:
                    return t2.Text;
                case 2:
                    return t3.Text;
                case 3:
                    return t4.Text;
                case 4:
                    return t5.Text;
                case 5:
                    return t6.Text;
                case 6:
                    return t7.Text;
                case 7:
                    return t8.Text;
                case 8:
                    return t9.Text;
                default:
                    throw new NotImplementedException();

            }
        }

        public void SetText(int x, int y, int number)
        {
            string text = number.ToString();
            if (number == 0)
                text = "";

            switch (y * 3 + x)
            {
                case 0:
                    t1.Text = text;
                    break;
                case 1:
                    t2.Text = text;
                    break;
                case 2:
                    t3.Text = text;
                    break;
                case 3:
                    t4.Text = text;
                    break;
                case 4:
                    t5.Text = text;
                    break;
                case 5:
                    t6.Text = text;
                    break;
                case 6:
                    t7.Text = text;
                    break;
                case 7:
                    t8.Text = text;
                    break;
                case 8:
                    t9.Text = text;
                    break;
                default:
                    throw new NotImplementedException();

            }
        }
    }
}
