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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Book GetBook()
        {
            // Retrieve data from Form2
            string bookCode = textBox1.Text;
            string title = textBox2.Text;
            string author = textBox3.Text;
            string category = textBox4.Text;
            int quantity;
            if (!int.TryParse(textBox5.Text, out quantity))
            {
                MessageBox.Show("Invalid quantity.");
                return null;
            }

            // Create a new Book object
            return new Book
            {
                BookCode = bookCode,
                Title = title,
                Author = author,
                Category = category,
                Quantity = quantity
            };
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Retrieve book data from Form2
            Book newBook = GetBook();

            // Check if book data is valid
            if (newBook != null)
            {
                // Create a message to display book details
                string message = $"Book added successfully:\n\n" +
                                 $"Book Code: {newBook.BookCode}\n" +
                                 $"Title: {newBook.Title}\n" +
                                 $"Author: {newBook.Author}\n" +
                                 $"Category: {newBook.Category}\n" +
                                 $"Quantity: {newBook.Quantity}";

                // Show MessageBox with book details
                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Confirm the addition and close Form2
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Mã sách")
            {
                textBox1.Text = null;
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Tên sách")
            {
                textBox2.Text = null;
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Tác giả")
            {
                textBox3.Text = null;
            }
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == "Loại sách")
            {
                textBox4.Text = null;
            }
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox5.Text == "Số lượng")
            {
                textBox5.Text = null;
            }
        }
    }
}
