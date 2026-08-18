using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApplication
{
    public partial class Form1 : Form
    {
        private CalculatorClass cal;

        private double num1;
        private double num2;
        public Form1()
        {
            InitializeComponent();

            cal = new CalculatorClass();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                num1 = Convert.ToDouble(textBox1.Text);
                num2 = Convert.ToDouble(textBox2.Text);
                string op = comboBox1.SelectedItem?.ToString();
                
                cal.info = null;

                switch (op)
                {
                    case "+":
                        cal.CalculateEvent += cal.GetSum;
                        break;
                    case "-":
                        cal.CalculateEvent += cal.GetDifference;
                        break;
                    case "*":
                        cal.CalculateEvent += cal.GetProduct;
                        break;
                    case "/":
                        cal.CalculateEvent += cal.GetQuotient;
                        break;
                    default:
                        MessageBox.Show("Please select a valid operator.");
                        return;
                }

                double total = cal.info?.Invoke(num1, num2) ?? 0.0;
                label4.Text = total.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numerical inputs.");
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
