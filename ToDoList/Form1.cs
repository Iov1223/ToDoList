using System;
using System.Globalization;
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
    public partial class Напоминалка : Form
    {
        private SqlConnection connection;
        private List<string> actions = new List<string>();
        private List<string> time = new List<string>();
        private string SqlExpression;
        public Напоминалка()
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
            if (connection.State == ConnectionState.Open)
            {
                ReadFromBase();
            }
            else
            {
                MessageBox.Show("Список дел отсутсвует!");
            }
        }
        private void Clear()
        {
            checkedListBox1.Items.Clear();
            ReadFromBase();
            textBoxTitle.Clear();
            textBoxAction.Clear();
            textBoxDateTime.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

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
                        Regex regex = new Regex(@"\d{2}\.\d{2}\.\d{4}");
                        if (regex.IsMatch(time[i]))
                        {
                            connection.Open();
                            SqlExpression = $"DELETE FROM Reminders WHERE [Action]=N'{actions[i]}';";
                            SqlCommand command = new SqlCommand(SqlExpression, connection);
                            command.ExecuteNonQuery();
                            checkedListBox1.Items.Clear();
                            ReadFromBase();
                            connection.Close();
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        player.Stop();
                    }
                }
            }
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
            Regex regex = new Regex(@"^\d{2}\.\d{2}\.\d{4}\s\d{2}:\d{2}:\d{2}$"), regexOther = new Regex(@"^([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$");
            if (regex.IsMatch(textBoxDateTime.Text) || regexOther.IsMatch(textBoxDateTime.Text))
            {
                connection.Open();
                if (textBoxTitle.Text != "" && textBoxAction.Text != "" && textBoxDateTime.Text != "")
                {

                    SqlExpression = $"INSERT INTO Reminders([Title], [Action], [ReminderDateTime]) VALUES(N'{textBoxTitle.Text}', N'{textBoxAction.Text}', '{textBoxDateTime.Text}');";
                    SqlCommand command = new SqlCommand(SqlExpression, connection);
                    command.ExecuteNonQuery();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Есть не заполненные поля", "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("Чтобы узнать формат ввода нажмите на знак вопроса", "НЕКОРРЕКТНЫЙ ВВОД", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                textBoxDateTime.Clear();
            }
        }

        private void buttonQuestion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Для добавления записи нужно заполнить все поля.\n" +
                "2. Поле \"Тема\" - вписывается заголовок напоминания одним словом (15 знаков).\n" +
                "3. Поле \"Действия\" - расписывается более подробно\nсмысл напоминания (100 знаков).\n" +
                "4. Поле \"Дата и время\" - ужедневные напоминания:\n" +
                "     - вписывается толко время в формате 15:30:00\n" +
                "        напоминания в конкретную дату:\n" +
                "     - вписывается дата и время в формате 01.03.2022\n       15:30:00\n" +
                "5. Для редактирования записи:\n" +
                "     - нужно выбрать запись (появится галчка)\n" +
                "     - редактируются толко поля \"Действия\" и \"Дата и время\"\n" +
                "     - вписать нужные изменения\n" +
                "     - нажать кнопку \"Редактировать запись\"\n" +
                "6. Для удаления нужно выбрать одну или несколько записей и нажать соответствующую кнопку.\n" +
                "7. При ответе \"да\" на напоминание в конкретную дату, запись о действии удаляется автоматически.", "ИНФОРМАЦИЯ ПО ИСПОЛЬЗОВАНИЮ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
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
                MessageBox.Show("Чтобы узнать формат ввода нажмите на знак вопроса", "НЕКОРРЕКТНЫЙ ВВОД", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^\d{2}\.\d{2}\.\d{4}\s\d{2}:\d{2}:\d{2}$"), regexOther = new Regex(@"^([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$");
            if (regex.IsMatch(textBoxDateTime.Text) || regexOther.IsMatch(textBoxDateTime.Text))
            {
                connection.Open();
                    string _tmp = checkedListBox1.SelectedItem.ToString();
                    string i = _tmp.Split(' ')[0];
                if (textBoxAction.Text != "" && textBoxDateTime.Text != "")
                {
                    SqlExpression = $"UPDATE Reminders SET [Action]=N'{textBoxAction.Text}', ReminderDateTime='{textBoxDateTime.Text}' WHERE Id={i};";
                    SqlCommand command = new SqlCommand(SqlExpression, connection);
                    command.ExecuteNonQuery();
                    Clear();
                }
                else if (textBoxAction.Text != "" && textBoxDateTime.Text == "")
                {
                    SqlExpression = $"UPDATE Reminders SET [Action]=N'{textBoxAction.Text}' WHERE Id={i};";
                    SqlCommand command = new SqlCommand(SqlExpression, connection);
                    command.ExecuteNonQuery();
                    Clear();
                }
                else if (textBoxAction.Text == "" && textBoxDateTime.Text != "")
                {
                    SqlExpression = $"UPDATE Reminders SET  ReminderDateTime='{textBoxDateTime.Text}' WHERE Id={i};";
                    SqlCommand command = new SqlCommand(SqlExpression, connection);
                    command.ExecuteNonQuery();
                    Clear();
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("Чтобы узнать формат ввода нажмите на знак вопроса", "НЕКОРРЕКТНЫЙ ВВОД ИЛИ ЗАПИСЬ НЕ ВЫБРАНА", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                textBoxDateTime.Clear();
            }
        }
    }
}
