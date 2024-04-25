using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO; // Import StreamReader from System.IO namespace
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace TestWinform.Properties
{
    public partial class Form1 : Form
    {
        private bool isEditMode = false; // Add a field to track edit mode

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.ReadOnly = true;

            //dataGridView1.Font = new Font("Arial", 12); // Example font that supports Vietnamese characters
        }



        //===============================Thêm độc giả từ cơ sở dữ liệu==============================//

        private void Person_AddDB_Click(object sender, EventArgs e)
        {
            // Read books from CSV
            List<Person> Persons = ReadPersonFromCSV("Person.csv");

            // Display books in DataGridView
            dataGridView1.DataSource = Persons;
        }

        private List<Person> ReadPersonFromCSV(string filePath)
        {
            List<Person> Persons = new List<Person>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    // Read each line in the file
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Split the line into parts
                        string[] parts = line.Split(',');

                        // Check if all fields are present
                        if (parts.Length >= 4)
                        {
                            // Create a Person object from the data
                            Person Person = new Person
                            {
                                ID = parts[0],
                                Name = parts[1],
                                Description = parts[2],
                                Fee = long.Parse(parts[3], CultureInfo.InvariantCulture)
                            };
                            Persons.Add(Person);
                        }
                        else
                        {
                            // Handle invalid line
                            Console.WriteLine("Invalid line: " + line);
                        }
                    }
                }

                //MessageBox.Show("Successfully read file: " + filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading CSV file: " + ex.Message);
            }

            return Persons;
        }

        //================================Thêm độc giả thủ công===================================//

        private void button3_Click(object sender, EventArgs e)
        {
            // Show Form2 to add a new book
            using (Form3 form3 = new Form3())
            {
                if (form3.ShowDialog() == DialogResult.OK)
                {
                    // Retrieve book data from Form2
                    Person newPerson = form3.GetPerson();

                    // Ensure newBook is not null
                    if (newPerson != null)
                    {
                        try
                        {
                            // Append new book data to the CSV file
                            AppendPersonToCSV(newPerson, "Person.csv");

                            // Display the updated list of books in DataGridView
                            List<Person> csvPersons = ReadPersonFromCSV("Person.csv");
                            dataGridView1.DataSource = csvPersons;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error adding book to CSV file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void AppendPersonToCSV(Person person, string filePath)
        {
            try
            {
                // Open the CSV file in append mode
                using (var writer = new StreamWriter(filePath, true))
                {
                    // Write the new book data to the end of the file
                    writer.WriteLine($"{person.ID},{person.Name},{person.Description},{person.Fee}");
                }

                MessageBox.Show("Successfully added book to CSV file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error appending book to CSV file: {ex.Message}");
            }
        }

        private void SavePersonToCSV(List<Person> Persons)
        {
            try
            {
                // Specify the path of the CSV file
                string filePath = "Person.csv";

                // Create or overwrite the CSV file
                using (var writer = new StreamWriter(filePath))
                {
                    // Write each book as a line in the CSV file
                    foreach (Person person in Persons)
                    {
                        writer.WriteLine($"{person.ID},{person.Name},{person.Description},{person.Fee}");
                    }
                }

                MessageBox.Show("Successfully saved data to CSV file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data to CSV file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //==============================Chỉnh sửa thông tin độc giả===============================//
        private void button4_Click(object sender, EventArgs e)
        {
            // Toggle edit mode
            isEditMode = !isEditMode;

            // Enable or disable DataGridView editing based on edit mode
            dataGridView1.ReadOnly = !isEditMode;

            // Optionally, you can also change the appearance of the DataGridView to indicate edit mode
            dataGridView1.DefaultCellStyle.BackColor = isEditMode ? Color.LightGray : Color.White;

            if (isEditMode)
            {
                // Change button text when in edit mode
                button4.Text = "Lưu thay đổi?";
            }
            else
            {
                // Change button text when not in edit mode
                button4.Text = "Chỉnh sửa thông tin";

                // Save changes to CSV
                List<Person> Persons = dataGridView1.DataSource as List<Person>;
                if (Persons != null)
                {
                    SavePersonToCSV(Persons);
                }
            }
        }
        //================================Xóa độc giả===========================================//


        private void button5_Click(object sender, EventArgs e)
        {
            // If in edit mode, delete the selected Person
            if (isEditMode)
            {
                // Get the index of the selected row
                int selectedIndex = dataGridView1.SelectedCells[0].RowIndex;

                // Get the list of Persons from the DataGridView DataSource
                List<Person> Persons = dataGridView1.DataSource as List<Person>;

                // Ensure there is a valid list and a valid selected index
                if (Persons != null && selectedIndex >= 0 && selectedIndex < Persons.Count)
                {
                    // Remove the selected Person from the list
                    Persons.RemoveAt(selectedIndex);

                    // Update the DataGridView DataSource with the updated list of Persons
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Persons;

                    // Optionally, you can refresh the DataGridView to ensure changes are reflected immediately
                    dataGridView1.Refresh();

                    // Save changes to CSV
                    SavePersonToCSV(Persons);

                    // Change button text back to "Xóa sách" after saving changes
                    button5.Text = "Xóa độc giả";

                    // Change DataGridView back to white background after saving changes
                    dataGridView1.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    MessageBox.Show("No Person selected or invalid selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Toggle edit mode
                isEditMode = !isEditMode;

                // Enable or disable DataGridView editing based on edit mode
                dataGridView1.ReadOnly = !isEditMode;

                // Optionally, you can also change the appearance of the DataGridView to indicate edit mode
                dataGridView1.DefaultCellStyle.BackColor = isEditMode ? Color.LightGray : Color.White;

                // Change button text to "Lưu thay đổi" when in edit mode
                button5.Text = isEditMode ? "Lưu thay đổi" : "Xóa sách";
            }
        }


        //================================Thêm sách từ cơ sở dữ liệu==============================//

        private void button1_Click(object sender, EventArgs e)
        {
            // Read books from CSV
            List<Book> csvBooks = ReadBooksFromCSV("Book_Data.csv");

            // Display CSV books in DataGridView
            dataGridView1.DataSource = csvBooks;
        }

        private List<Book> ReadBooksFromCSV(string filePath)
        {
            List<Book> books = new List<Book>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    // Read each line in the file
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Split the line into parts
                        string[] parts = line.Split(',');

                        // Check if all fields are present
                        if (parts.Length >= 5)
                        {
                            // Create a Book object from the data
                            Book book = new Book
                            {
                                BookCode = parts[0],
                                Title = parts[1],
                                Author = parts[2],
                                Category = parts[3],
                                Quantity = int.Parse(parts[4], CultureInfo.InvariantCulture)
                            };
                            books.Add(book);
                        }
                        else
                        {
                            // Handle invalid line
                            Console.WriteLine("Invalid line: " + line);
                        }
                    }
                }

                //MessageBox.Show("Successfully read file: " + filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading CSV file: " + ex.Message);
            }

            return books;
        }


        //================================Thêm sách bằng thủ công==============================//
        private void Book_AddNormal_Click(object sender, EventArgs e)
        {
            // Show Form2 to add a new book
            using (Form2 form2 = new Form2())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    // Retrieve book data from Form2
                    Book newBook = form2.GetBook();

                    // Ensure newBook is not null
                    if (newBook != null)
                    {
                        try
                        {
                            // Append new book data to the CSV file
                            AppendBookToCSV(newBook, "Book_Data.csv");

                            // Display the updated list of books in DataGridView
                            List<Book> csvBooks = ReadBooksFromCSV("Book_Data.csv");
                            dataGridView1.DataSource = csvBooks;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error adding book to CSV file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void AppendBookToCSV(Book book, string filePath)
        {
            try
            {
                // Open the CSV file in append mode
                using (var writer = new StreamWriter(filePath, true))
                {
                    // Write the new book data to the end of the file
                    writer.WriteLine($"{book.BookCode},{book.Title},{book.Author},{book.Category},{book.Quantity}");
                }

                MessageBox.Show("Successfully added book to CSV file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error appending book to CSV file: {ex.Message}");
            }
        }

        //================================Cập nhật giá trị về cơ sở dữ liệu==============================//
        private void SaveBooksToCSV(List<Book> books)
        {
            try
            {
                // Specify the path of the CSV file
                string filePath = "Book_Data.csv";

                // Create or overwrite the CSV file
                using (var writer = new StreamWriter(filePath))
                {
                    // Write each book as a line in the CSV file
                    foreach (Book book in books)
                    {
                        writer.WriteLine($"{book.BookCode},{book.Title},{book.Author},{book.Category},{book.Quantity}");
                    }
                }

                MessageBox.Show("Successfully saved data to CSV file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data to CSV file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //================================Chức năng chỉnh sửa==============================//
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Toggle edit mode
            isEditMode = !isEditMode;

            // Enable or disable DataGridView editing based on edit mode
            dataGridView1.ReadOnly = !isEditMode;

            // Optionally, you can also change the appearance of the DataGridView to indicate edit mode
            dataGridView1.DefaultCellStyle.BackColor = isEditMode ? Color.LightGray : Color.White;

            if (isEditMode)
            {
                // Change button text when in edit mode
                button1.Text = "Lưu thay đổi?";
            }
            else
            {
                // Change button text when not in edit mode
                button1.Text = "Chỉnh sửa thông tin";

                // Save changes to CSV
                List<Book> books = dataGridView1.DataSource as List<Book>;
                if (books != null)
                {
                    SaveBooksToCSV(books);
                }
            }
        }

        //================================Chức năng xóa sách==============================//

        private void button2_Click(object sender, EventArgs e)
        {
            // If in edit mode, delete the selected book
            if (isEditMode)
            {
                // Get the index of the selected row
                int selectedIndex = dataGridView1.SelectedCells[0].RowIndex;

                // Get the list of books from the DataGridView DataSource
                List<Book> books = dataGridView1.DataSource as List<Book>;

                // Ensure there is a valid list and a valid selected index
                if (books != null && selectedIndex >= 0 && selectedIndex < books.Count)
                {
                    // Remove the selected book from the list
                    books.RemoveAt(selectedIndex);

                    // Update the DataGridView DataSource with the updated list of books
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = books;

                    // Optionally, you can refresh the DataGridView to ensure changes are reflected immediately
                    dataGridView1.Refresh();

                    // Save changes to CSV
                    SaveBooksToCSV(books);

                    // Change button text back to "Xóa sách" after saving changes
                    button2.Text = "Xóa sách";

                    // Change DataGridView back to white background after saving changes
                    dataGridView1.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    MessageBox.Show("No book selected or invalid selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Toggle edit mode
                isEditMode = !isEditMode;

                // Enable or disable DataGridView editing based on edit mode
                dataGridView1.ReadOnly = !isEditMode;

                // Optionally, you can also change the appearance of the DataGridView to indicate edit mode
                dataGridView1.DefaultCellStyle.BackColor = isEditMode ? Color.LightGray : Color.White;

                // Change button text to "Lưu thay đổi" when in edit mode
                button2.Text = isEditMode ? "Lưu thay đổi" : "Xóa sách";
            }
        }

        //======================================================================================================================================//

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            List<Card> csvCards = ReadCardFromCSV("Card.csv");

            // Display CSV books in DataGridView
            dataGridView1.DataSource = csvCards;
        }

        private List<Card> ReadCardFromCSV(string filePath)
        {
            List<Card> cards = new List<Card>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    // Read each line in the file
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Split the line into parts
                        string[] parts = line.Split(',');

                        // Check if all fields are present
                        if (parts.Length >= 4)
                        {
                            // Create a Book object from the data
                            Card card = new Card
                            {
                                ReaderID = parts[0],
                                CardID = parts[1],
                                CardExp = parts[2],
                                BookBorrow = parts[3]
                            };
                            cards.Add(card);
                        }
                        else
                        {
                            // Handle invalid line
                            Console.WriteLine("Invalid line: " + line);
                        }
                    }
                }

                // MessageBox.Show("Successfully read file: " + filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading CSV file: " + ex.Message);
            }

            return cards;
        }


        private void SaveCardsToCSV(List<Card> cards)
        {
            try
            {
                // Specify the path of the CSV file
                string filePath = "Card.csv";

                // Create or overwrite the CSV file
                using (var writer = new StreamWriter(filePath))
                {
                    // Write each card as a line in the CSV file
                    foreach (Card card in cards)
                    {
                        // Combine the BookBorrow array into a single string separated by semicolons
                        string bookBorrowString = string.Join(";", card.BookBorrow);

                        // Write the card data to the CSV file
                        writer.WriteLine($"{card.ReaderID},{card.CardID},{card.CardExp},{bookBorrowString}");
                    }
                }

                MessageBox.Show("Successfully saved data to CSV file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data to CSV file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //================================Mượn sách============================================================//

        private void button8_Click(object sender, EventArgs e)
        {
            string cardID = Microsoft.VisualBasic.Interaction.InputBox("Nhập mã thẻ mượn:", "Mã thẻ", "");
            string bookCode = Microsoft.VisualBasic.Interaction.InputBox("Nhập mã sách cần mượn:", "Mã sách", "");

            // Load books from CSV
            List<Book> books = ReadBooksFromCSV("Book_Data.csv");

            // Load cards from CSV
            List<Card> cards = ReadCardFromCSV("Card.csv");

            // Find the book with the given bookCode
            Book borrowedBook = books.FirstOrDefault(book => book.BookCode == bookCode);

            // Find the card with the given cardID
            Card borrowerCard = cards.FirstOrDefault(card => card.CardID == cardID);

            if (borrowedBook != null && borrowerCard != null)
            {
                // Reduce the quantity of the borrowed book by 1
                borrowedBook.Quantity--;

                // Add the borrowed book's code to the borrower card's BookBorrow string
                if (string.IsNullOrEmpty(borrowerCard.BookBorrow))
                {
                    borrowerCard.BookBorrow = bookCode;
                }
                else
                {
                    borrowerCard.BookBorrow += " " + bookCode; // Using ';' as delimiter
                }

                // Save changes to the CSV files
                SaveBooksToCSV(books);
                SaveCardsToCSV(cards);

                MessageBox.Show("Sách đã được mượn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy thẻ hoặc sách tương ứng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView1.DataSource = cards;
        }

        //=============================================Trả sách=================================================//
        private void button7_MouseClick(object sender, MouseEventArgs e)
        {
            string cardID = Microsoft.VisualBasic.Interaction.InputBox("Nhập mã thẻ trả:", "Mã thẻ", "");
            string bookCode = Microsoft.VisualBasic.Interaction.InputBox("Nhập mã sách cần trả:", "Mã sách", "");

            // Load books from CSV
            List<Book> books = ReadBooksFromCSV("Book_Data.csv");

            // Load cards from CSV
            List<Card> cards = ReadCardFromCSV("Card.csv");

            // Find the book with the given bookCode
            Book borrowedBook = books.FirstOrDefault(book => book.BookCode == bookCode);

            // Find the card with the given cardID
            Card borrowerCard = cards.FirstOrDefault(card => card.CardID == cardID);

            if (borrowedBook != null && borrowerCard != null)
            {
                // Reduce the quantity of the borrowed book by 1
                borrowedBook.Quantity++;

                // Add the borrowed book's code to the borrower card's BookBorrow string
                if (string.IsNullOrEmpty(borrowerCard.BookBorrow))
                {
                    borrowerCard.BookBorrow = bookCode;
                }
                else
                {
                    borrowerCard.BookBorrow = borrowerCard.BookBorrow.Replace(" " + bookCode, "");
                }

                // Save changes to the CSV files
                SaveBooksToCSV(books);
                SaveCardsToCSV(cards);

                MessageBox.Show("Sách đã được trả thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy thẻ hoặc sách tương ứng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView1.DataSource = cards;
        }
        //================================Thêm thẻ============================================================//
        private void button10_MouseClick(object sender, MouseEventArgs e)
        {
            using (Form4 form4 = new Form4())
            {
                if (form4.ShowDialog() == DialogResult.OK)
                {
                    // Retrieve card data from Form4
                    Card newCard = form4.GetCard();

                    // Ensure newCard is not null
                    if (newCard != null)
                    {
                        try
                        {
                            // Append new card data to the CSV file
                            AppendCardToCSV(newCard, "Card.csv");

                            // Display the updated list of cards in DataGridView
                            List<Card> csvCards = ReadCardFromCSV("Card.csv");
                            dataGridView1.DataSource = csvCards;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error adding card to CSV file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void AppendCardToCSV(Card card, string filePath)
        {
            try
            {
                // Open the CSV file in append mode
                using (var writer = new StreamWriter(filePath, true))
                {
                    // Write the new card data to the end of the file
                    writer.WriteLine($"{card.ReaderID},{card.CardID},{card.CardExp},{card.BookBorrow}");
                }

                MessageBox.Show("Successfully added card to CSV file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error appending card to CSV file: {ex.Message}");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // If in edit mode, delete the selected Card
            if (isEditMode)
            {
                // Get the index of the selected row
                int selectedIndex = dataGridView1.SelectedCells[0].RowIndex;

                // Get the list of Cards from the DataGridView DataSource
                List<Card> Cards = dataGridView1.DataSource as List<Card>;

                // Ensure there is a valid list and a valid selected index
                if (Cards != null && selectedIndex >= 0 && selectedIndex < Cards.Count)
                {
                    // Remove the selected Card from the list
                    Cards.RemoveAt(selectedIndex);

                    // Update the DataGridView DataSource with the updated list of Cards
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Cards;

                    // Optionally, you can refresh the DataGridView to ensure changes are reflected immediately
                    dataGridView1.Refresh();

                    // Save changes to CSV
                    SaveCardsToCSV(Cards);

                    // Change button text back to "Xóa sách" after saving changes
                    button9.Text = "Xóa thẻ";

                    // Change DataGridView back to white background after saving changes
                    dataGridView1.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    MessageBox.Show("No Card selected or invalid selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Toggle edit mode
                isEditMode = !isEditMode;

                // Enable or disable DataGridView editing based on edit mode
                dataGridView1.ReadOnly = !isEditMode;

                // Optionally, you can also change the appearance of the DataGridView to indicate edit mode
                dataGridView1.DefaultCellStyle.BackColor = isEditMode ? Color.LightGray : Color.White;

                // Change button text to "Lưu thay đổi" when in edit mode
                button9.Text = isEditMode ? "Lưu thay đổi" : "Xóa thẻ";
            }
        }
    }
    //================================Các class xây dựng Sách, Độc giả và thẻ==============================//
    public class Book
    {
        public string BookCode { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
    }

    public class Person
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Fee { get; set; }
    }

    public class Card
    {
        public string ReaderID { get; set; }
        public string CardID { get; set; }
        public string CardExp { get; set; }
        public string BookBorrow { get; set; } // Change from string[] to string
    }

}
