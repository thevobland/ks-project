using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIIGIAIK_luchsiy_VUZ
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            if ((radioButton1.Checked == false) && (radioButton2.Checked == false))
            {
                button2.Enabled = false;
            }
 

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Name_TextChanged(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            string name, lastName, patron, login, password, secure;
            string date;
            int sex = 1;
            int num = 0;
            password = null;
                //имя
            if ((int.TryParse(NameP.Text, out num)) || (NameP.Text == null))
            {
                NameP.Text = null;
                NameP.BackColor = Color.FromArgb(250, 30, 30);
            }
            else
            {
                name = NameP.Text;
            }


            if ((int.TryParse(LastName.Text, out num)) || (LastName.Text == null))
                //Фамилия
            {
                LastName.Text = null;
                LastName.BackColor = Color.FromArgb(250, 30, 30);
            }
            else
            {
                lastName = LastName.Text;
            }


            if ((int.TryParse(Patron.Text, out num)) )
                //Отчество
            {
                Patron.Text = null;
            }
            else
            {
                patron = Patron.Text;
            }


            if (textBox1.Text == null)
                //Логин
            {
                textBox1.Text = null;
                textBox1.BackColor = Color.FromArgb(250, 30, 30);
            }
            else
            {
                login = textBox1.Text;
            }


            if ( (textBox2.Text == null) || ( (textBox2.Text.Length < 5) || (textBox2.Text.Length > 20)))
                //Пароль
            {
                textBox2.Text = null;
                MessageBox.Show("Ваш пароль должен быть в диапазоне от 5 до 20 символов");
                textBox2.BackColor = Color.FromArgb(250, 30, 30);
            }
            else
            {
                password = textBox2.Text;
            }

            if (textBox3.Text != password)
                //проверка повтороного ввода пароля
            {
                textBox3.Text = null;
                MessageBox.Show("Пароли не совпадают!");
                textBox3.BackColor = Color.FromArgb(250, 30, 30);
            }
            else
            {
                secure = textBox3.Text;
 
            }
            
            if ((radioButton1.Checked==true) && (radioButton2.Checked==false))
            {
                sex = 1;
            }
            else if ((radioButton1.Checked == false) && (radioButton2.Checked == true))
            {
                sex = 2;
            }

            //if ((dateTimePicker1.Value.Subtract(Convert.ToDateTime("19.02.2020"))));
            date = dateTimePicker1.Value.ToString("yyyy-MM-dd");

 
            //MessageBox.Show(date);

                if ( (NameP.Text != null) && (LastName.Text != null) && (textBox1.Text != null) && (textBox2.Text != null) && (textBox3.Text != null) )
                //Вывод успешной регистрации
            {
                Timer timer = new Timer();
               // for (int i = 5; timer < i; )
                label17.Text = ("Регистрация успешно пройдена!");
            }

            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
                button2.Enabled = true;
            }


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;
                button2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            StartForm startForm = new StartForm();
            startForm.FindForm();
        }
    }
}
