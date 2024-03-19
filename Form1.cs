
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;



namespace Triliza
{
    

    
    public partial class Form1 : Form
    {
        int c;
        string x;
        bool a;
       
       
        public Form1()
        {
            
            InitializeComponent();
            
           
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {



            
            

            x = textBox1.Text;
            var isNumeric = int.TryParse(textBox1.Text, out _);
            if (isNumeric)
            {
                c = int.Parse(x);



                if (c % 2 == 1 && c >= 3)
                {
                    TicTac f2 = new TicTac();
                   
                   
                    
                    a = radioButton2.Checked;
                    f2.B00l(a);

                    f2.Dimensions(x.ToString());

                    f2.Show();
                }
                else
                {
                    MessageBox.Show("Not acceptable Dimensions");
                }

            }
            else
            {
                MessageBox.Show("Please type a number on the textbox");
            }


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
              
                radioButton2.Checked = false;

               

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
              

                radioButton1.Checked = false;
            }

        }
    }
}
