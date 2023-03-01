using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Hangfire.States;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        private List<string> actions = new List<string>();
        private List<string> time = new List<string>();
        private string SqlExpression;
        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=RemindersDB;Integrated Security=True");
            timer1.Interval = 1000; 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            connection.Open();
        }

        private void ReadFromBase()
        {
            SqlExpression = "USE RemindersDB SELECT * FROM Reminders";
            SqlCommand command = new SqlCommand(SqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                object _id = reader.GetValue(0);
                object _title = reader.GetValue(1);
                object _actions = reader.GetValue(2);
                object _time = reader.GetValue(3);
                time.Add($"{_time}");
                actions.Add($"{_actions}");
                checkedListBox1.Items.Add(_id.ToString() + "    " + _title.ToString() + "    " + _actions.ToString() + "    " + _time.ToString());
            }
            connection.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           // connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                ReadFromBase();
            }
            else
            {
                MessageBox.Show("Список дел отсутсвует!");
            }
           // connection.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // connection.Open();
            for (int i = 0; i < actions.Count; i++)
            {
                if (time[i] == DateTime.Now.ToString("T") | time[i] == DateTime.Now.ToString("G"))
                {
                    SoundPlayer player = new SoundPlayer(Environment.CurrentDirectory + "\\Sound.wav");
                    player.Play();
                    DialogResult result = MessageBox.Show(actions[i], "Действие выполнено?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        player.Stop();
                    }
                    else if (result == DialogResult.No)
                    {
                        player.Stop();
                    }
                }
            }
           // connection.Close();
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            connection.Open();
            foreach (string s in checkedListBox1.CheckedItems)
            {
                string i = s.Split(' ')[0];
                SqlExpression = $"DELETE FROM Reminders WHERE Id={i};";
                SqlCommand command = new SqlCommand(SqlExpression, connection);
                command.ExecuteNonQuery();
            }
            checkedListBox1.Items.Clear();
            ReadFromBase();
            connection.Close();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            connection.Open();
            if (textBoxTitle.Text != "" && textBoxAction.Text != "" && textBoxDateTime.Text != "")
            {
                
                SqlExpression = $"INSERT INTO Reminders([Title], [Action], [ReminderDateTime]) VALUES(N'{textBoxTitle.Text}', N'{textBoxAction.Text}', '{textBoxDateTime.Text}');";
                SqlCommand command = new SqlCommand(SqlExpression, connection);
                command.ExecuteNonQuery();
                checkedListBox1.Items.Clear();
                ReadFromBase();
                textBoxTitle.Clear();
                textBoxAction.Clear();
                textBoxDateTime.Clear();
                
            }
            else
            {
                MessageBox.Show("Есть не заполненные поля! ");
            }
            connection.Close();
        }

        private void buttonQuestion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Для добавления записи нужно заполнить все поля.\n" +
                "2. Поле \"Тема\" - коротко вписывается общий смысл напоминания (50 знаков).\n" +
                "3. Поле \"Действия\" - расписывается более подробно смысл напоминания (100 знаков).\n" +
                "4. Поле \"Дата и время\" - ужедневные напоминания:\n" +
                "     * вписывается толко время в формате 15:30:00\n" +
                "   напоминания в конкретную дату:\n" +
                "     * вписывается дата и время в формате 01.03.2022 15:30:00", "Помощь");
        }

        private void textBoxDateTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^[0-9\. :]+$");
            if (regex.IsMatch(textBoxDateTime.Text + e.KeyChar) | e.KeyChar == '')
            {
                return;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("НЕКОРРЕКТНЫЙ ВВОД:\nчтобы узнать формат ввода нажмите на знак вопроса");
            }
            regex = new Regex(@"^\d{2}\.\d{2}\.\d{4}\s\d{2}:\d{2}:\d{2}$");
        }
    }
}
