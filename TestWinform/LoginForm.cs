using TestWinform.Properties;
namespace TestWinform
{
    public partial class LoginForm : Form
    {

        private List<Administrator> administrators;

        public LoginForm()
        {
            InitializeComponent();
            // Khởi tạo danh sách Quản trị viên
            administrators = new List<Administrator>();

            // Thêm các mẫu Quản trị viên
            administrators.Add(new Administrator("admin", "admin123"));
            administrators.Add(new Administrator("HoaiAn2912", "PhamHoaiAn29"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }


        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Clear();
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '*';
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            bool loginSuccessful = false;

            // Lặp qua danh sách các quản trị viên và kiểm tra đăng nhập
            foreach (var admin in administrators)
            {
                if (admin.Username == username && admin.Password == password)
                {
                    loginSuccessful = true;
                    break; // Thoát khỏi vòng lặp khi tìm thấy đúng người dùng
                }
            }

            if (loginSuccessful)
            {
                MessageBox.Show("Login successful!");
                // Thực hiện các hành động sau khi đăng nhập thành công
                Form1 Mn = new Form1();
                Mn.Show();
                Visible = false;
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }


        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Here you would typically add code to store the new user in a database or file
            // For simplicity, let's just update the admin object
            administrators.Add(new Administrator(username, password));
            MessageBox.Show("Registration successful!");
        }

        public class Administrator
        {
            public string Username { get; set; }
            public string Password { get; set; }

            public Administrator(string username, string password)
            {
                Username = username;
                Password = password;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
