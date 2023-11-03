using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4._2._2Calculator
{
    /// <summary>
    /// The main attempt at this calculator was to replicate the UI and function as closly as possible to the iPhone's iOS. Dividing by O prints Error on the text box just as in iOS
    /// the added benefit also allows easy handling for succeeding calculations without the need of having to press the clear button.
    /// Because of how the variables and code are set up once you have the calculation from the equation you can continue using operators with that calculation and recieving accurate calculations
    /// I've designed everything to be as similar do the iOS calculator so it will not throw exceptions or message boxes instead it will either Print Error or 0 in the case of an overflow exception
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        string sign;
        public decimal num;
        public decimal calc;
        public Form1()
        {
            InitializeComponent();
        }
        public void Calculate(string sign)
        {
           
            

            switch (sign)
            {
                case "+":
                    calc = decimal.Parse(retxtResult.Text);
                    Calculator addition = new Calculator();
                    var x = (addition.Add(num, calc));
                    retxtResult.Text = Convert.ToString(x);

                    break;
                case "-":
                    calc = decimal.Parse(retxtResult.Text);
                    Calculator subtraction = new Calculator();
                    var y = (subtraction.Subtract(num, calc));
                    retxtResult.Text = Convert.ToString(y);
                    break;
                case "*":
                    calc = decimal.Parse(retxtResult.Text);
                    Calculator multiplication = new Calculator();
                    var z = (multiplication.Multiply(num, calc));
                    retxtResult.Text = Convert.ToString(z);
                    break;
                case "/":
                    calc = decimal.Parse(retxtResult.Text);
                    Calculator division = new Calculator();
                    var c = (division.Divide(num, calc));
                    retxtResult.Text = Convert.ToString(c);
                    if(retxtResult.Text == "0")
                    {
                        retxtResult.Text = "Error"; //returns error when dividing by 0 instead of just 0, inadvertently helps with continued calculations
                    }
                    break;
                default:
                    break;

            }
        }

            private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region MyRegion
        private void button1_Click(object sender, EventArgs e)
        {
            if (retxtResult.Text == "" || retxtResult.Text == "Error") //by using this if statement whenever an operator button is pressed without anything being passed it will just clear the text box instead of throwing an exception
            {
                retxtResult.Clear();
            }
            else //if there is a number being passed then the num variable will store it and then the clear method will be called to clear the text box
            {
                num = decimal.Parse(retxtResult.Text);
                 retxtResult.Clear();
                sign = "/"; //the sign variable will store the sign for use in the Calculate method's switch case
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (retxtResult.Text == "" || retxtResult.Text == "Error")
            {
                retxtResult.Clear();
            }
            else
            {
                num = decimal.Parse(retxtResult.Text);
                 retxtResult.Clear();
                sign = "-";
            }
                
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (!retxtResult.Text.Contains('.') || retxtResult.Text == "") //the decimal will only be added to the textbox if their isn't already a decimal in the string
            {
                retxtResult.Text += btnDec.Text;
            }
            else
            {
                if (retxtResult.Text == ".")
                    retxtResult.Text = "";
            }
        } 
        #endregion

        private void retxtResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (retxtResult.Text == "Error") //if there is an error text from a previous gone awry calculation then the text will be cleared before adding the number to the digit
            {
                retxtResult.Clear();
            }
            retxtResult.Text += decimal.Parse(btn3.Text); //this will parse the text into a format to acceptable for calculations
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (retxtResult.Text == "Error")
            {
                retxtResult.Clear();
            }
            retxtResult.Text += decimal.Parse(btn9.Text);
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            if (retxtResult.Text == "" || retxtResult.Text == "Error") //
            {
                retxtResult.Clear();
            }
            else
            {
                num = decimal.Parse(retxtResult.Text);
                retxtResult.Clear();
                sign = "*"; //because some of the characters are from outside sources(ie, Google) I had to hard code the sign instead of taking it from the button text
            }               //I used google for some of the character because of their similiarity to the iOS calculator
        }

            private void btn6_Click(object sender, EventArgs e)
        {
            if (retxtResult.Text == "Error")
            {
                retxtResult.Clear();
            }
            retxtResult.Text += decimal.Parse(btn6.Text);
            
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (retxtResult.Text == "Error")
            {
                retxtResult.Clear();
            }
            retxtResult.Text += decimal.Parse(btn7.Text);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (retxtResult.Text == "Error")
            {
                retxtResult.Clear();
            }
            retxtResult.Text += decimal.Parse(btn4.Text);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (retxtResult.Text == "Error")
            {
                retxtResult.Clear();
            }
            retxtResult.Text += decimal.Parse(btn1.Text);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (retxtResult.Text == "Error")
            {
                retxtResult.Clear();
            }
            retxtResult.Text += decimal.Parse(btn2.Text);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (retxtResult.Text == "Error")
            {
                retxtResult.Clear();
            }
            retxtResult.Text += decimal.Parse(btn5.Text);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (retxtResult.Text == "Error")
            {
                retxtResult.Clear();
            }
            retxtResult.Text += decimal.Parse(btn8.Text);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (retxtResult.Text == "Error")
            {
                retxtResult.Clear();
            }
            retxtResult.Text += decimal.Parse(btn0.Text);
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (retxtResult.Text == "Error" || retxtResult.Text == "" || retxtResult.Text == "-" || retxtResult.Text == ".") //to mitigate a format exception in case the end user attempts to calculate on any of these strings themselves
            {
                if (retxtResult.Text == "-" || retxtResult.Text ==".")//I don't want a format exception but I also don't want to clear the neg sign if the = btn is press so I came up with this to put into a sort of loop that won't continue
                {
                    if (retxtResult.Text == ".") //there is almost certainly an easier and more readable way to go about this so any advice would be welcomed
                    {
                        retxtResult.Text = ".";
                    }
                    else
                        retxtResult.Text = "-";
                }
                else
                {
                    retxtResult.Clear(); //
                }
            }
            else
            {
                
                calc =decimal.Parse(retxtResult.Text);
                Calculate(sign);
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            retxtResult.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(retxtResult.Text == "" || retxtResult.Text == "Error")
            {
                retxtResult.Clear();

            }
           else
           {
                num = decimal.Parse(retxtResult.Text); //because I use the parsed result textbox I can then use the result from any preceding calculation for use in any future calculations
                retxtResult.Clear();
                sign = btnAdd.Text;

           }
            
            
        }

        private void btnNeg_Click(object sender, EventArgs e)
        {
            if (retxtResult.Text == "Error")
            {
                retxtResult.Clear();
            }
            if (!retxtResult.Text.Contains('-') && retxtResult.Text =="") //Added the option for a negative sign, only downside is I can't figure out a simple way to remove it without clearing text
            {
                retxtResult.Text += '-';
            }
            else //I figured it out
            {
                if(retxtResult.Text=="-")
                retxtResult.Text = "";
            }

        }

        private void btnPer_Click(object sender, EventArgs e)
        {
            if (retxtResult.Text == "Error")
            {
                retxtResult.Clear();
            }
            if (!retxtResult.Text.Contains("0.") && retxtResult.Text == "")
            {
                retxtResult.Text += "0.";
            }
            else
            {
                if (retxtResult.Text == "0.")
                    retxtResult.Text = "";
            }
        }

        private void btnNeg_Validating(object sender, CancelEventArgs e)
        {

        }

        private void btnNeg_Validated(object sender, EventArgs e)
        {
        }
    }
}
