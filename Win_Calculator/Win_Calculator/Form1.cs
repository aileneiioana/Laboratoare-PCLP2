using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_Calculator
{
    public partial class Form1 : Form
    {
        Double value = 0;
        String operation = "";
        bool operation_pressed = false;
        bool btnMCEnabled = false;
        bool btnMREnabled = false;
        bool memflag = false;
        Double memory = 0;
        Double iCelsius, iKelvin, iFahrenheit;
        char iOperation;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((result.Text == "0") || (operation_pressed) || (memflag))
                result.Clear();
            operation_pressed = false;
            memflag = false;
            Button b = (Button)sender;
            if (b.Text == ".")
            {
                if (!result.Text.Contains("."))
                    result.Text = result.Text + b.Text;
            }
            else
                result.Text = result.Text + b.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            
                operation = b.Text;
                value = Double.Parse(result.Text);
                operation_pressed = true;
                equation.Text = value + " " + operation;
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            equation.Text = "";
            switch (operation)
            {
                case "+":
                    // result.Text = (value + Double.Parse(result.Text)).ToString();
                    result.Text = Operators.Add(value, Double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    // result.Text = (value - Double.Parse(result.Text)).ToString();
                    result.Text = Operators.Sub(value, Double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    //result.Text = (value * Double.Parse(result.Text)).ToString();
                    result.Text = Operators.Times(value, Double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    // result.Text = (value / Double.Parse(result.Text)).ToString();
                    result.Text = Operators.Div(value, Double.Parse(result.Text)).ToString();
                    break;
                case "Mod": result.Text = (value % Double.Parse(result.Text)).ToString();
                    break;
                case "Exp":
                     double i = Double.Parse(result.Text);
                    double q;
                    q = (value);
                    result.Text = Math.Exp(i * Math.Log(q * 4)).ToString();
                    break;
                default: break;
            }
            value = Int32.Parse(result.Text);
            operation = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            result.Clear();
            value = 0;
            equation.Text = "";
        }

        /*private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            switch (e.KeyChar.ToString())
            {
                case "1":
                    one.PerformClick();
                    break;
                case "2":
                    two.PerformClick();
                    break;
                case "3":
                    three.PerformClick();
                    break;
                case "4":
                    four.PerformClick();
                    break;
                case "5":
                    five.PerformClick();
                    break;
                case "6":
                    six.PerformClick();
                    break;
                case "7":
                    seven.PerformClick();
                    break;
                case "8":
                    eight.PerformClick();
                    break;
                case "9":
                    nine.PerformClick();
                    break;
                case "0":
                    zero.PerformClick();
                    break;
                case "+":
                    add.PerformClick();
                    break;
                case "-":
                    sub.PerformClick();
                    break;
                case "*":
                    times.PerformClick();
                    break;
                case "Enter":
                    equal.PerformClick();
                    break;
                case "=":
                    equal.PerformClick();
                    break;
                case ".":
                    dec.PerformClick();
                    break;
                default: break;
            }
        }*/


        private void button2_Click(object sender, EventArgs e)
        {
            if (result.Text.Length > 0)
                result.Text = result.Text.Remove(result.Text.Length - 1, 1);
            if (result.Text == "")
                result.Text = "0";
        }

        private void procent_click(object sender, EventArgs e)
        {

            result.Text = System.Convert.ToString(Convert.ToDouble(result.Text) / Convert.ToDouble(100));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(result.Text) * Convert.ToDouble(result.Text);
            result.Text = System.Convert.ToString(a);
        }


        private void MC_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            memory = 0;
            btnMREnabled = false;
            btnMCEnabled = false;
        }

        private void MR_Click(object sender, EventArgs e)
        {
            result.Text = memory.ToString();
            memflag = true;
        }

        private void Mplus_Click(object sender, EventArgs e)
        {
            memory += Double.Parse(result.Text);
        }

        private void Mminus_Click(object sender, EventArgs e)
        {

            memory -= Double.Parse(result.Text);
        }

        private void MS_Click(object sender, EventArgs e)
        {
            memory = Double.Parse(result.Text);
            btnMCEnabled = true;
            btnMREnabled = true;
            memflag = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Double v = Double.Parse(result.Text);
            result.Text = (-v).ToString();
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            double qsinh = Double.Parse(result.Text);
            equation.Text = System.Convert.ToString("sinh" + "(" + (result.Text) + ")");
            qsinh = Math.Sinh(qsinh);
            result.Text = System.Convert.ToString(qsinh);
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 234;
            result.Width = 199;

        }

        private void scientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 450;
            result.Width = 416;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 234;
            result.Width = 199;
        }
        private void temperatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width =799;
            result.Width = 416;
            textConvert.Focus();
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            groupBox1.Location = new Point(450, 27);
            groupBox1.Width = 321;
            groupBox1.Height = 345;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            result.Text = "3.14159265 358979";
        }

        private void log_Click(object sender, EventArgs e)
        {
            double ilog = Double.Parse(result.Text);
            equation.Text= System.Convert.ToString("log"+ "("+ (result.Text) +")");
            ilog = Math.Log10(ilog);
            result.Text = System.Convert.ToString(ilog);  
        }

        private void sqrt_click(object sender, EventArgs e)
        {
            double sq = Double.Parse(result.Text);
            equation.Text = System.Convert.ToString("sqrt" + "(" + (result.Text) + ")");
            sq = Math.Sqrt(sq);
            result.Text = System.Convert.ToString(sq);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            double qsin = Double.Parse(result.Text);
            equation.Text = System.Convert.ToString("sin" + "(" + (result.Text) + ")");
            qsin = Math.Sin(qsin);
            result.Text = System.Convert.ToString(qsin);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            double qcosh = Double.Parse(result.Text);
            equation.Text = System.Convert.ToString("cosh" + "(" + (result.Text) + ")");
            qcosh = Math.Cosh(qcosh);
            result.Text = System.Convert.ToString(qcosh);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            double qcos = Double.Parse(result.Text);
            equation.Text = System.Convert.ToString("cos" + "(" + (result.Text) + ")");
            qcos = Math.Cos(qcos);
            result.Text = System.Convert.ToString(qcos);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            double qtanh = Double.Parse(result.Text);
            equation.Text = System.Convert.ToString("tanh" + "(" + (result.Text) + ")");
            qtanh = Math.Tanh(qtanh);
            result.Text = System.Convert.ToString(qtanh);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            double qtan = Double.Parse(result.Text);
            equation.Text = System.Convert.ToString("tan" + "(" + (result.Text) + ")");
            qtan = Math.Tan(qtan);
            result.Text = System.Convert.ToString(qtan);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int a = int.Parse(result.Text);
            result.Text = System.Convert.ToString(a, 2);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int a = int.Parse(result.Text);
            result.Text = System.Convert.ToString(a, 16);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int a = int.Parse(result.Text);
            result.Text = System.Convert.ToString(a, 8);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int a = int.Parse(result.Text);
            result.Text = System.Convert.ToString(a);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(result.Text) * Convert.ToDouble(result.Text) * Convert.ToDouble(result.Text);
            result.Text = System.Convert.ToString(a);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(1.0) / Convert.ToDouble(result.Text) ;
            result.Text = System.Convert.ToString(a);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            double iln = Double.Parse(result.Text);
            equation.Text = System.Convert.ToString("ln" + "(" + (result.Text) + ")");
            iln = Math.Log(iln);
            result.Text = System.Convert.ToString(iln);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            iOperation = 'F';
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            iOperation ='K';
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textConvert.Clear();
            lblConvert.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a;
            a = Convert.ToInt32(textMultiply.Text);
            for (int i =0;i<=10;i++)
            {
                lstMultiply.Items.Add(i+"x"+a+"="+a*i);
            }
        }

        private void multiplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 799;
            result.Width = 416;
            textMultiply.Focus();
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            groupBox3.Location = new Point(450, 27);
            groupBox3.Width = 321;
            groupBox3.Height = 345;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            lstMultiply.Items.Clear();
            textMultiply.Clear();
        }

        private void textConvert_TextChanged(object sender, EventArgs e)
        {
            result.Enabled = false;
            result.ReadOnly = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            iOperation = 'C';

        }

        private void button22_Click(object sender, EventArgs e)
        {
            switch(iOperation)
            {
                case 'C':
                    iCelsius = float.Parse(textConvert.Text);
                    lblConvert.Text = (((9 * iCelsius) / 5) + 32).ToString();
                    break;
                case 'F':
                    iFahrenheit = float.Parse(textConvert.Text);
                    lblConvert.Text = (((iFahrenheit-32) * 5) / 9).ToString();
                    break;
                case 'K':
                    iKelvin = float.Parse(textConvert.Text);
                    lblConvert.Text = ((((9 * iKelvin) / 5) + 32)+273.15).ToString();
                    break;

            }
        }
    }
}