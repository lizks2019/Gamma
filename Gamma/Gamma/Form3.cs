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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        char[] al = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        const int N = 33;

        private void button1_Click(object sender, EventArgs e)
        {
            string ot = source_text.Text;
            string key = gamma_text.Text;
            try
            {
                // Преобразуем буквы в цифры для зашифрования слова
                int[] mass = new int[ot.Length];
                for (int i = 0; i < ot.Length; i++)             
                    for (int j = 0; j < N; j++)
                    {
                        if (ot[i] == al[j]) //Если данный символ соответствует символу алфавита
                        {
                            mass[i] = j; //То присвоить номер символа по алфавиту
                            break;
                        }

                    }
                // Преобразуем буквы в цифры для гаммы
                int[] keymass = new int[key.Length];
                for (int i = 0; i < key.Length; i++)
                    for (int j = 0; j < N; j++)
                    {
                        if (key[i] == al[j]) //Если данный символ соответствует символу алфавита
                        {
                            keymass[i] = j; //То присвоить номер символа по алфавиту
                            break;
                        }
                    }

                int[] res = new int[ot.Length];

                //сложение по модулю 33
                for (int i = 0; i < ot.Length; i++)
                {
                    res[i] = (mass[i] + keymass[i]) % N;
                }
                // Преобразуем цифры в буквы для результата
                string result = "";
                for (int i = 0; i < res.Length; i++)
                        for (int n = 0; n < N; n++)
                        {
                            if (res[i] == n)
                            {
                                result += al[n];
                                break;
                            }
                        }
                result_text.Text = result;
            }
            catch
            {
                if (ot.Length == 0) MessageBox.Show("Введите текст!");
                if (key.Length == 0) MessageBox.Show("Введите ключ!");
                if (key.Length > ot.Length) MessageBox.Show("Гамма должна быть той же длины, что и введенный текст!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ot = result_text.Text;
            string key = gamma_text.Text;
            try
            {
                int[] mass = new int[ot.Length];
                for (int i = 0; i < ot.Length; i++)
                    for (int j = 0; j < N; j++)
                    {
                        if (ot[i] == al[j]) //Если данный символ соответствует символу алфавита
                        {
                            mass[i] = j; //То присвоить номер символа по алфавиту
                            break;
                        }

                    }

                int[] keymass = new int[key.Length];
                for (int i = 0; i < key.Length; i++)
                    for (int j = 0; j < N; j++)
                    {
                        if (key[i] == al[j]) //Если данный символ соответствует символу алфавита
                        {
                            keymass[i] = j; //То присвоить номер символа по алфавиту
                            break;
                        }
                    }

                int[] res = new int[ot.Length];

                //сложение по модулю 33
                for (int i = 0; i < ot.Length; i++)
                {
                    res[i] = (mass[i] + N - keymass[i]) % N;
                }

                string result = "";
                for (int i = 0; i < res.Length; i++)
                    for (int n = 0; n < N; n++)
                    {
                        if (res[i] == n)
                        {
                            result += al[n];
                            break;
                        }
                    }
                encript_text.Text = result;
            }
            catch
            {
                if (ot.Length == 0) MessageBox.Show("Введите текст!");
                if (key.Length == 0) MessageBox.Show("Введите ключ!");
                if (key.Length > ot.Length) MessageBox.Show("Гамма должна быть той же длины, что и введенный текст!");
            }
        }
    }
}
