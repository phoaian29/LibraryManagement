using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestWinform.Properties
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public Card GetCard()
        {
            // Retrieve data from Form2
            string personID = textBox1.Text;
            string cardID = textBox2.Text;
            string date = textBox3.Text;
            string bookBorrow = " ";

            // Create a new Book object
            return new Card
            {
                ReaderID = personID,
                CardID = cardID,
                CardExp = date,
                BookBorrow = bookBorrow,
            };
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Mã độc giả")
            {
                textBox1.Text = null;
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Mã thẻ")
            {
                textBox2.Text = null;
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Hạn thẻ (mm/dd/yyyy)")
            {
                textBox3.Text = null;
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            // Retrieve book data from Form2
            Card newCard = GetCard();

            // Check if book data is valid
            if (newCard != null)
            {
                // Create a message to display book details
                string message = $"Card added successfully:\n\n" +
                                 $"Reader ID: {newCard.ReaderID}\n" +
                                 $"Card ID: {newCard.CardID}\n" +
                                 $"Card Exp: {newCard.CardExp}\n";

                // Show MessageBox with book details
                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Confirm the addition and close Form3
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
