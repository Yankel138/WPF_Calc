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

namespace WPF_Calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string text = "";
        static double result = 0;
        static double temp = 0;
        static string operation = "";
        static bool first = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (first)
            {
                textBlock2.Text = "";
                first = false;
            }
            text += (sender as Button).Content;
            textBlock2.Text += (sender as Button).Content;
        }

        private void Button_Click_Oper(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                if (text != "")
                {
                    result = Convert.ToDouble(text);
                }
                text = "";
            }
            else if (text != "")
            {
                Button_Click_Ravno(sender, e);
            }
            operation = (string)(sender as Button).Content;
            textBlock1.Text = result.ToString() + operation;
            first = true;
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            result = 0;
            temp = 0;
            text = "";
            operation = "";
            textBlock1.Text = "";
            textBlock2.Text = "0";
            first = true;
        }

        private void Button_Click_ClearEnter(object sender, RoutedEventArgs e)
        {
            temp = 0;
            text = "";
            textBlock2.Text = "0";
            first = true;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            text = text.Remove(text.Length - 1);
            textBlock2.Text = text;
        }

        private void Button_Click_Action(object sender, RoutedEventArgs e)
        {
            temp = Convert.ToDouble(textBlock2.Text);
            switch ((string)(sender as Button).Content)
            {
                case "1/x":
                    temp = 1 / temp;
                    break;
                case "x²":
                    temp = temp * temp;
                    break;
                case "√":
                    temp = Math.Sqrt(temp);
                    break;
                case "%":
                    temp = result * (temp / 100);
                    break;
                case "±":
                    temp = temp * (-1);
                    break;
            }
            text = temp.ToString();

            if (operation != "")
                textBlock1.Text = result + operation + text;
            else
                textBlock1.Text = text;

            textBlock2.Text = text;
            first = true;
        }


        private void Button_Click_Ravno(object sender, RoutedEventArgs e)
        {
            textBlock1.Text = result.ToString() + operation + text + "=";
            temp = Convert.ToDouble(text);
            text = "";
            switch (operation)
            {
                case "+":
                    result += temp;
                    break;
                case "-":
                    result -= temp;
                    break;
                case "x":
                    result *= temp;
                    break;
                case "÷":
                    result /= temp;
                    break;
            }
            textBlock2.Text = result.ToString();
            operation = "";
            first = true;
            temp = result;
        }
        public void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Button).FontSize = 24;
        }

        public void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Button).FontSize = 18;
        }


    }
}
