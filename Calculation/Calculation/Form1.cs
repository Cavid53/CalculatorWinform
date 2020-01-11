using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculation
{
    public partial class Form1 : Form
    {

        double resultValue = 0;
        string operatorType = "";
        bool isOperator = false;
        string error = "0 - a bolmek olmaz";

        public Form1()
        {
            InitializeComponent();
        }

        private void NumbersBtn_Click(object sender,EventArgs e)
        {
            Button button = (Button)sender;

            if (txbResult.Text == error)
                txbResult.Clear();

            if (txbResult.Text == "0")
            {
                if (button.Text == ".")
                {
                    txbResult.Text += button.Text;
                }
            }

            if ((txbResult.Text == "0") || (isOperator))
                txbResult.Clear();


            if (button.Text == ".")
            {
          
                if (!txbResult.Text.Contains("."))
                {
                    txbResult.Text += button.Text;
                    isOperator = false;
                }
            }
            else 
            {
                txbResult.Text += button.Text;
                isOperator = false;
            }
        }

        private void OperatorBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                operatorType = button.Text;
                resultValue = double.Parse(txbResult.Text);
                isOperator = true;
            }
            catch 
            {

                txbResult.Clear();
            }
        

        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            switch (operatorType)
            {
                case "+":
                    txbResult.Text = (resultValue + double.Parse(txbResult.Text)).ToString();
                    break;
                case "-":
                    txbResult.Text = (resultValue - double.Parse(txbResult.Text)).ToString();
                    break;
                case "*":
                    txbResult.Text = (resultValue * double.Parse(txbResult.Text)).ToString();
                    break;
                case "/":
                    try
                    {
                        if (txbResult.Text == "0")
                        {
                            txbResult.Text = error;
                            return;
                        }

                        txbResult.Text = (resultValue / double.Parse(txbResult.Text)).ToString();
                        break;
                    }
                    catch 
                    {
                        return;
                    }
                 
                default:
                    break;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            txbResult.Text = "0";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            txbResult.Text = "0";
            resultValue = 0;
        }
    }
}
