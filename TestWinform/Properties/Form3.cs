using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWinform.Properties
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public Person GetPerson()
        {
            // Retrieve data from Form2
            string personCode = textBox5.Text;
            string name = textBox6.Text;
            string description = textBox7.Text;
            long fee;
            if (!long.TryParse(textBox8.Text, out fee))
            {
                MessageBox.Show("Invalid fee.");
                return null;
            }

            // Create a new Book object
            return new Person
            {
                ID = personCode,
                Name = name,
                Description = description,
                Fee = fee,
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Retrieve book data from Form2
            Person newPerson = GetPerson();

            // Check if book data is valid
            if (newPerson != null)
            {
                // Create a message to display book details
                string message = $"Reader added successfully:\n\n" +
                                 $"Reader ID: {newPerson.ID}\n" +
                                 $"Name: {newPerson.Name}\n" +
                                 $"Description: {newPerson.Description}\n" +
                                 $"Fee: {newPerson.Fee}\n";

                // Show MessageBox with book details
                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Confirm the addition and close Form3
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void textBox5_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (textBox5.Text == "Mã độc giả")
            {
                textBox5.Text = null;
            }
        }

        private void textBox6_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (textBox6.Text == "Tên độc giả")
            {
                textBox6.Text = null;
            }
        }

        private void textBox7_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (textBox7.Text == "Loại độc giả")
            {
                textBox7.Text = null;
            }
        }

        private void textBox8_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (textBox8.Text == "Phí")
            {
                textBox8.Text = null;
            }
        }
    }
}
