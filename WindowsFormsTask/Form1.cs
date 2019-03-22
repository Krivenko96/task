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

namespace WindowsFormsTask
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;

        public Form1()
        {
            InitializeComponent();
        }

        void selectFromDepartment()
        {
            try
            {

                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("Select * FROM [Department]", sqlConnection);
                sda.SelectCommand = command;
                DataTable dbTable = new DataTable();
                sda.Fill(dbTable);

                dataGridDepartment.DataSource = dbTable;
                sda.Update(dbTable);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void selectFromCompositionOfDepartment()
        {
            try
            {

                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("Select * FROM [CompositionOfDepartment]", sqlConnection);
                sda.SelectCommand = command;
                DataTable dbTable = new DataTable();
                sda.Fill(dbTable);

                dataGridCompositionOfDepartment.DataSource = dbTable;
                sda.Update(dbTable);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void selectFromWorker()
        {
            try
            {

                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("Select * FROM [Worker]", sqlConnection);
                sda.SelectCommand = command;
                DataTable dbTable = new DataTable();
                sda.Fill(dbTable);

                dataGridWorker.DataSource = dbTable;
                sda.Update(dbTable);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        void selectVacationWorker()
        {
            try
            {

                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("Select * FROM [Worker] WHERE [OnVacation]=@OnVacation", sqlConnection);
                command.Parameters.AddWithValue("OnVacation", checkBox2.Checked);
                sda.SelectCommand = command;
                DataTable dbTable = new DataTable();
                sda.Fill(dbTable);

                dataGridSearch.DataSource = dbTable;
                sda.Update(dbTable);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void selectWorkerByName()
        {
            try
            {

                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("Select * FROM [Worker] WHERE [Name]=@Name", sqlConnection);
                command.Parameters.AddWithValue("Name", textBox6.Text);
                sda.SelectCommand = command;
                DataTable dbTable = new DataTable();
                sda.Fill(dbTable);

                dataGridSearch.DataSource = dbTable;
                sda.Update(dbTable);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void selectWorkerByPosition()
        {
            try
            {

                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("Select * FROM [Worker] WHERE [Position]=@Position", sqlConnection);
                command.Parameters.AddWithValue("Position", textBox7.Text);
                sda.SelectCommand = command;
                DataTable dbTable = new DataTable();
                sda.Fill(dbTable);

                dataGridSearch.DataSource = dbTable;
                sda.Update(dbTable);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void insertIntoDepartment()
        {
            SqlCommand command = new SqlCommand("INSERT INTO  [Department] (Id, Name, NumberOfWorkers)VALUES(@Id, @Name, @NumberOfWorkers)", sqlConnection);
            command.Parameters.AddWithValue("Id", numericUpDown1.Value);
            command.Parameters.AddWithValue("Name", textBox2.Text);
            command.Parameters.AddWithValue("NumberOfWorkers", numericUpDown2.Value);
            try
            {
                if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(numericUpDown1.Value.ToString()) && !string.IsNullOrEmpty(numericUpDown2.Value.ToString()))
                {
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Поля Номер отдела, Название отдела и колличество сотрудников должны быть заполненны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        void insertIntoCompositionOfDepartment()
        {
            SqlCommand command = new SqlCommand("INSERT INTO  [CompositionOfDepartment] (IdRecord, IdDepartment, IdWorker) VALUES(@IdRecord, @IdDepartment, @IdWorker)", sqlConnection);
            command.Parameters.AddWithValue("IdRecord", numericUpDown3.Value);
            command.Parameters.AddWithValue("IdDepartment", numericUpDown4.Value);
            command.Parameters.AddWithValue("IdWorker", numericUpDown5.Value);
            try
            {
                if (!string.IsNullOrEmpty(numericUpDown3.Value.ToString()) && !string.IsNullOrEmpty(numericUpDown4.Value.ToString()) && !string.IsNullOrEmpty(numericUpDown5.Value.ToString()))
                {
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Поля Номер записи, Номер отдела и номер работника должны быть заполненны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void insertIntoWorker()
        {
            SqlCommand command = new SqlCommand("INSERT INTO  [Worker] (IdWorker, Name, Telephone, Position, Rank, OnVacation, VacationStart, VacationEnd) VALUES(@IdWorker, @Name, @Telephone, @Position, @Rank, @OnVacation, @VacationStart, @VacationEnd)", sqlConnection);
            command.Parameters.AddWithValue("IdWorker", numericUpDown6.Value);
            command.Parameters.AddWithValue("Name", textBox1.Text);
            command.Parameters.AddWithValue("Telephone", textBox3.Text);
            command.Parameters.AddWithValue("Position", textBox4.Text);
            command.Parameters.AddWithValue("Rank", textBox5.Text);
            command.Parameters.AddWithValue("OnVacation", checkBox1.Checked);
            command.Parameters.AddWithValue("VacationStart", dateTimePicker1.Value);
            command.Parameters.AddWithValue("VacationEnd", dateTimePicker2.Value);

            try
            {
                if (!string.IsNullOrEmpty(numericUpDown6.Value.ToString()) && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox3.Text) 
                    && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text))
                {
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Поля Номер работника, ФИО работника, телефон, должность, и разряд должны быть заполненны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void updateDepartment()
        {

            SqlCommand command = new SqlCommand("UPDATE  [Department] SET [Id]=@Id, [Name]=@Name, [NumberOfWorkers]=@NumberOfWorkers WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", numericUpDown1.Value);
            command.Parameters.AddWithValue("Name", textBox2.Text);
            command.Parameters.AddWithValue("NumberOfWorkers", numericUpDown2.Value);
            try
            {
                if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(numericUpDown1.Value.ToString()) && !string.IsNullOrEmpty(numericUpDown2.Value.ToString()))
                {
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Поля Номер отдела, Название отдела и колличество сотрудников должны быть заполненны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void updateCompositionOfDepartment()
        {
            SqlCommand command = new SqlCommand("UPDATE  [CompositionOfDepartment] SET [IdRecord]=@IdRecord, [IdDepartment]=@IdDepartment, [IdWorker]=@IdWorker WHERE [IdRecord]=@IdRecord", sqlConnection);
            command.Parameters.AddWithValue("IdRecord", numericUpDown3.Value);
            command.Parameters.AddWithValue("IdDepartment", numericUpDown4.Value);
            command.Parameters.AddWithValue("IdWorker", numericUpDown5.Value);
            try
            {
                if (!string.IsNullOrEmpty(numericUpDown3.Value.ToString()) && !string.IsNullOrEmpty(numericUpDown4.Value.ToString()) && !string.IsNullOrEmpty(numericUpDown5.Value.ToString()))
                {
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Поля Номер записи, Номер отдела и Номер работника должны быть заполненны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void updateWorker()
        {

            SqlCommand command = new SqlCommand("UPDATE  [Worker] SET [IdWorker]=@IdWorker, [Name]=@Name, [Telephone]=@Telephone, [Position]=@Position, [OnVacation]=@OnVacation, [VacationStart]=@VacationStart, [VacationEnd]=@VacationEnd  WHERE [IdWorker]=@IdWorker", sqlConnection);
            command.Parameters.AddWithValue("IdWorker", numericUpDown6.Value);
            command.Parameters.AddWithValue("Name", textBox1.Text);
            command.Parameters.AddWithValue("Telephone", textBox3.Text);
            command.Parameters.AddWithValue("Position", textBox4.Text);
            command.Parameters.AddWithValue("Rank", textBox5.Text);
            command.Parameters.AddWithValue("OnVacation", checkBox1.Checked);
            command.Parameters.AddWithValue("VacationStart", dateTimePicker1.Value);
            command.Parameters.AddWithValue("VacationEnd", dateTimePicker2.Value);
            try
            {
               if (!string.IsNullOrEmpty(numericUpDown6.Value.ToString()) && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox3.Text)
                    && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text))
               {
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Поля Номер работника, ФИО работника, телефон, должность, и разряд должны быть заполненны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        void deleteFromDepartment()
        {

            SqlCommand command = new SqlCommand("DELETE FROM [Department] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", numericUpDown1.Value);
            try
            {
                if (!string.IsNullOrEmpty(numericUpDown1.Value.ToString()))
                {
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Полe Номер записи должно быть заполненно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void deleteFromCompositionOfDepartment()
        {
            SqlCommand command = new SqlCommand("DELETE FROM [CompositionOfDepartment] WHERE [IdRecord]=@IdRecord", sqlConnection);
            command.Parameters.AddWithValue("IdRecord", numericUpDown3.Value);
            try
            {
                if (!string.IsNullOrEmpty(numericUpDown3.Value.ToString()))
                {
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Полe Номер записи должно быть заполненно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void deleteFromWorker()
        {

            SqlCommand command = new SqlCommand("DELETE FROM [Worker] WHERE [IdWorker]=@IdWorker", sqlConnection);
            command.Parameters.AddWithValue("IdWorker", numericUpDown6.Value);
            try
            {
                if (!string.IsNullOrEmpty(numericUpDown6.Value.ToString()))
                {
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Полe Номер работника должно быть заполненно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.Worker". При необходимости она может быть перемещена или удалена.
            this.workerTableAdapter.Fill(this.databaseDataSet.Worker);
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Danil\WindowsFormsTask\WindowsFormsTask\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            selectFromDepartment();
            selectFromCompositionOfDepartment();
            selectFromWorker();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            insertIntoDepartment();
            selectFromDepartment();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            updateDepartment();
            selectFromDepartment();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteFromDepartment();
            selectFromDepartment();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            insertIntoCompositionOfDepartment();
            selectFromCompositionOfDepartment();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            deleteFromCompositionOfDepartment();
            selectFromCompositionOfDepartment();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            updateCompositionOfDepartment();
            selectFromCompositionOfDepartment();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            insertIntoWorker();
            selectFromWorker();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            updateWorker();
            selectFromWorker();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            deleteFromWorker();
            selectFromWorker();
        }


        private void button11_Click(object sender, EventArgs e)
        {
            selectVacationWorker();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            selectWorkerByName();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            selectWorkerByPosition();
        }
    }
}
