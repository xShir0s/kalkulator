using System;
using Microsoft.Maui.Controls;
namespace Kalkulator
{
    public partial class MainPage : ContentPage
    {
        string currentEntry = "";
        string operatorEntry;
        double firstNumber, secondNumber;
        public MainPage()
        {
            InitializeComponent();
        }
        void OnNumberClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentEntry += button.Text;
            resultEntry.Text = currentEntry;  
        }
        void OnOperatorClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (!string.IsNullOrEmpty(currentEntry))
            {
                firstNumber = Convert.ToDouble(currentEntry);
                operatorEntry = button.Text;
                currentEntry = "";
            }
        }
        void OnClearClicked(object sender, EventArgs e)
        {
            currentEntry = "";
            operatorEntry = "";
            firstNumber = 0;
            secondNumber = 0;
            resultEntry.Text = "0";  
        }
        void OnEqualsClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentEntry))
            {
                secondNumber = Convert.ToDouble(currentEntry);
                double result = 0;
                switch (operatorEntry)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                            result = firstNumber / secondNumber;
                        break;
                }
                resultEntry.Text = result.ToString();
                currentEntry = result.ToString();
            }
        }
    }
}
