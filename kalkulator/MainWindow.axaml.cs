using Avalonia.Controls;

namespace kalkulator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        double firstNumber = 0;
        double secondNumber = 0;
        double result = 0;
        string oper;


        public void Check()
        {
            if (!string.IsNullOrEmpty(Tb.Text))
            {
                firstNumber = double.Parse(Tb.Text);
            }
           
        }

        private void Number_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

            string buttonOperOrNum = (sender as Button).Content.ToString();




            switch (buttonOperOrNum)
            {
                case "+":
                    Check();
                    oper = "+";
                    Tb.Text = "";
                 break;
                case "-":
                    Check();
                    oper = "-";
                    Tb.Text = "";
                    break;
                case "*":
                    Check();
                    oper = "*";
                    Tb.Text = "";
                    break;
                case "/":
                    Check();
                    oper = "/";
                    Tb.Text = "";
                    break;
                
                case "←":
                    
                    if (Tb.Text.Length > 0)
                    {
                        Tb.Text = Tb.Text.Remove(Tb.Text.Length - 1);
                    }
                   
                    break;
                case "x²":
                    if (!string.IsNullOrEmpty(Tb.Text))
                    {
                        double num = double.Parse(Tb.Text);
                        Tb.Text = (num * num).ToString();
                    }
                    break;
                case "C":
                    Tb.Text = "";
                    break;
                case "%":
                    Check();
                    oper = "%";
                    Tb.Text = "";
                    break;
                case ",":
                    if (Tb.Text.Contains(","))
                    {
                        break; 
                    }
                    if (string.IsNullOrEmpty(Tb.Text))
                    {
                        Tb.Text = "0";
                    }

                    Tb.Text += ",";
                    break;
                case "=":
                    if (string.IsNullOrEmpty(Tb.Text))
                    {
                        Tb.Text = "Ошибка";
                        return;
                    }

                    secondNumber = double.Parse(Tb.Text);

                    Tb.Text = "";

                    if (oper == "+")
                        result = firstNumber + secondNumber;
                    else if (oper == "-")
                        result = firstNumber - secondNumber;
                    else if (oper == "*")
                        result = firstNumber * secondNumber;
                    else if (oper == "/")
                    {
                        if (secondNumber == 0)
                        {
                            Tb.Text = "Ошибка";
                            return;
                        }
                        result = firstNumber / secondNumber;
                    }    
                        
                    else if (oper == "%")
                        result = firstNumber * secondNumber / 100;

                    Tb.Text = result.ToString();
                    break;

                default:
                   
                    Tb.Text += buttonOperOrNum;
        
                    break;

            }

             
        }

      
    }
}