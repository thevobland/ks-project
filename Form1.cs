using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MIIGIAIK_luchsiy_VUZ
{
    public partial class StartForm : Form
    {
        SqlConnection sqlConnection;
        public StartForm()
        {
            InitializeComponent();
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            int count_bd = 1;
            string connStr = @"Data Source=(local)\SQLEXPRESS; 
                           Initial Catalog=forC#; 
                           Integrated Security=True"; //Iitianal Catalog - ЭТО ВЫБОР БД НЕ ЗАБЫВАЙ
            sqlConnection = new SqlConnection(connStr);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT Login, Password FROM [UserForC]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (textBox1.Text == Convert.ToString(sqlReader["Login"]) && textBox2.Text == Convert.ToString(sqlReader["Password"]))
                    {

                        Method(Convert.ToString(textBox1.Text));
                        break;
                    }
                    if (count_bd == 5)
                    {
                        MessageBox.Show("Неправильно что-то");
                        if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                        {
                            sqlConnection.Close();
                        }
                        break;
                    }
                    else
                    {
                        count_bd += 1;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Тут все");
            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                    sqlReader = null;

                }
            }
        }
        public async void Method(string Login)
        {
            string conn = @"Data Source=(local)\SQLEXPRESS; 
                           Initial Catalog=forC#; 
                           Integrated Security=True"; //Iitianal Catalog - ЭТО ВЫБОР БД БЛЯТЬ НЕ ЗАБЫВАЙ
            sqlConnection = new SqlConnection(conn);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlRead = null;


            SqlCommand update = new SqlCommand("UPDATE [SignIn] SET [Login] = @Login , [Sign] = 1 WHERE [Login] = @Login", sqlConnection);
            update.Parameters.AddWithValue("Login", Login);
            try
            {
                await update.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Ошибка в Методе");
            }
            finally
            {
                if (sqlRead != null)
                {
                    sqlRead.Close();
                }
            }
        }
    }
}
