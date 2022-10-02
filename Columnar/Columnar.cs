using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Columnar
{
    public partial class Columnar : Form
    {
        public Columnar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int key = textBox2.Text.Length;
            string plane = textBox1.Text.ToUpper();
            List<List<string>> list = new List<List<string>>();
            for (int k = 0; k < key; k++)
            {
                list.Add(new List<string>());
                list[k].Add("");
            }
            int num = 0;
            for (int i = 0; i < plane.Length; i++)
            {
                if(num == key)
                {
                    num = 0;
                }
                list[num][0] += plane[i];
                num++;
            }

            List<char> ke = textBox2.Text.ToUpper().ToList();
            ke.Sort();
            for (int m = 0; m < key; m++)
            {
                int index = textBox2.Text.ToUpper().IndexOf(ke[m]);
                textBox3.Text += list[index][0];
            }
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int col = textBox3.Text.Length / textBox2.Text.Length;

            int still = (textBox3.Text.Length % textBox2.Text.Length);

            string cipher = textBox3.Text;
            List<char> sorted = new List<char>();
            List<string> items = new List<string>();
            for (int i = 0; i < textBox2.Text.Length; i++)
            {
                items.Add("");
                sorted.Add(textBox2.Text[i]);
            }
            sorted.Sort();
            int check = still;
            for (int c = 0; c < textBox2.Text.Length; c++)
            {
                int index = textBox2.Text.IndexOf(sorted[c]);

                items[index] += cipher.Substring(0, col);
                cipher = cipher.Remove(0, col);
                if (still > 0 && check > index)
                {
                    items[index] += cipher.Substring(0, 1);
                    cipher = cipher.Remove(0, 1);
                    still--;
                }
            }
            
            for (int n = 0; n < col+1; n++)
            {
                for (int l = 0; l < textBox2.Text.Length; l++)
                {
                    try
                    {
                        textBox4.Text += items[l][n];
                    }
                    catch
                    {

                    }
                }
            }
            //int key = textBox2.Text.Length;
            //int cilen = textBox3.Text.Length;
            //int emp = 0;
            //while(cilen%key != 0)
            //{
            //    cilen++;
            //    emp++;
            //}
            //int col_num = cilen / key;
            //List<string> items = new List<string>();


        }
    }
}
