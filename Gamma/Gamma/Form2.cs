using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gamma
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void isSimple(int a)
        {

            for (int i = 2; i <= a / 2; i++)
            {
                if (a % i == 0) MessageBox.Show("Введите простое число!");
            }
            if ((a == 1) || (a == 2)) MessageBox.Show("Введите простое число!");
        }

        public bool isThreeModFour(int v, int w)
        {
            if ((v % 4 == 3) && (w % 4 == 3))
                return true;
            else
            {
                if (v % 4 != 3)
                    MessageBox.Show("Введите другое простое число, отличное от " + v);

                if (w % 4 != 3)
                    MessageBox.Show("Введите другое простое число, отличное от " + w);
                return false;
            }

        }

        public void Encdecryption()
        {
            string text = textBox1.Text;
            string gamma = "";
            byte[] text_mass = Encoding.GetEncoding(1251).GetBytes(text);
            char[] res = new char[text.Length];
            int[] x = new int[text.Length * 4];
            string[] text_bin = new string[text.Length];
            string[,] t = new string[text.Length, 8];
            string[] x_bin = new string[text.Length * 4];
            string[] x_sub = new string[text.Length * 4];
            string[] sym_gam = new string[text.Length];
            string[,] sym_g = new string[sym_gam.Length, 8];
            string cipher = "";
            string[] c = new string[text.Length];
            int m;
            dataGridView1.ColumnCount = text.Length + 2;
            dataGridView1.RowCount = 6;
            dataGridView2.ColumnCount = 4;
            dataGridView2.RowCount = text.Length * 4;
            dataGridView1.Rows[0].Cells[0].Value = "Исходный текст";
            dataGridView1.Rows[2].Cells[0].Value = "Гамма";
            dataGridView1.Rows[4].Cells[0].Value = "Результат обработки";
            dataGridView2.Columns[0].HeaderText = "№";
            dataGridView2.Columns[1].HeaderText = "x[i](Dec-код)";
            dataGridView2.Columns[2].HeaderText = "x[i](Bin-код)";
            dataGridView2.Columns[3].HeaderText = "2 младших бита";
            try
            {
                int x0 = Convert.ToInt32(textBox2.Text);
                int p = Convert.ToInt32(textBox3.Text);
                int q = Convert.ToInt32(textBox4.Text);
                int k = 0;
                int o = 0;
                isSimple(x0);
                isSimple(p);
                isSimple(q);
                isThreeModFour(p, q);
                m = p * q;
                x[0] = x0;
                for (int i = 1; i < x.Length; i++)
                {
                    x[i] = Convert.ToInt32(Math.Pow(x[i - 1], 2) % m);
                }

                for (int i = 0; i < x_bin.Length; i++)
                {
                    x_bin[i] = Convert.ToString(x[i], 2);
                }

                for (int i = 0; i < x_sub.Length; i++)
                {
                    x_sub[i] = x_bin[i].Substring((x_bin[i].Length - 2));
                    gamma += x_sub[i];
                    label9.Text = "Полученная гамма: " + gamma;
                }

                for (int i = 0; i < sym_gam.Length; i++)
                {
                    sym_gam[i] = gamma.Substring((8 * i), 8);
                }

                for (int i = 0; i < sym_gam.Length; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        sym_g[i, j] = sym_gam[i].Substring(j, 1);
                    }
                }

                for (int i = 0; i < text.Length; i++)
                {
                    text_bin[i] = Convert.ToString(text_mass[i], 2);
                    if (text_bin[i].Length < 8)
                        while (text_bin[i].Length < 8)
                        {
                            text_bin[i] = "0" + text_bin[i];
                        }
                }

                for (int i = 0; i < text_bin.Length; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        t[i, j] = text_bin[i].Substring(j, 1);
                    }
                }

                //сложение по модулю 2
                for (int i = 0; i < sym_gam.Length; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (sym_g[i, j] == t[i, j])
                            cipher += "0";
                        else cipher += "1";
                    }
                }

                string[] c_dec = new string[text.Length];
                byte[] c_b = new byte[text.Length];
                for (int i = 0; i < text.Length; i++)
                {
                    c[i] = cipher.Substring((8 * i), 8);
                    c_dec[i] = Convert.ToString(Convert.ToInt32(c[i], 2));
                    c_b[i] = Convert.ToByte(c_dec[i]);
                    res = Encoding.GetEncoding(1251).GetChars(c_b);
                    textBox5.Text += Convert.ToString(res[i]);
                }


                //вывод таблицы генерации гаммы
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    {
                        dataGridView2.Rows[i].Cells[0].Value = Convert.ToString(i);
                        dataGridView2.Rows[i].Cells[1].Value = Convert.ToString(x[i]);
                        dataGridView2.Rows[i].Cells[2].Value = x_bin[i];
                        dataGridView2.Rows[i].Cells[3].Value = x_sub[i];
                    }
                }

                //вывод таблицы зашифрования/расшифрования
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 2; j < dataGridView1.ColumnCount; j++)
                    {
                        if (i % 2 != 0) dataGridView1.Rows[i].Cells[1].Value = "Bin-код";
                        else dataGridView1.Rows[i].Cells[1].Value = "Dec-код";
                        dataGridView1.Rows[0].Cells[j].Value = text_mass[j - 2];
                        dataGridView1.Rows[1].Cells[j].Value = Convert.ToString(text_mass[j - 2], 2);
                        dataGridView1.Rows[2].Cells[j].Value = Convert.ToString(Convert.ToInt32(sym_gam[j - 2], 2));
                        dataGridView1.Rows[3].Cells[j].Value = sym_gam[j - 2];
                        dataGridView1.Rows[4].Cells[j].Value = Convert.ToString(Convert.ToInt32(c[j - 2], 2));
                        dataGridView1.Rows[5].Cells[j].Value = c[j - 2];
                    }
                }
            }
            catch
            {
                if (textBox1.Text.Length == 0) MessageBox.Show("Введите текст!");
                if (textBox2.Text.Length == 0) MessageBox.Show("Введите x0!");
                if (textBox3.Text.Length == 0) MessageBox.Show("Введите p!");
                if (textBox4.Text.Length == 0) MessageBox.Show("Введите q!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Encdecryption();
        }
    }
}
