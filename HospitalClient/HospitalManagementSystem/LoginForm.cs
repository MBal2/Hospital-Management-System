using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    public partial class LoginForm : Form
    {
        IMongoCollection<Users> userCollection;
        public LoginForm()
        {
            InitializeComponent();

            var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            var databaseName = MongoUrl.Create(connectionString).DatabaseName;
            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase(databaseName);
            userCollection = database.GetCollection<Users>("Users");
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            // 1. get info from the user
            string username = textBox_username.Text;
            string password = textBox_password.Text;

            // 2. check user info against the database to see if it exists
            var filter = Builders<Users>.Filter.Eq("Username", username) &
                Builders<Users>.Filter.Eq("Password", password);

            var user = userCollection.Find(filter).FirstOrDefault();

            // if user exist, send them to main form, otherwise show them the error message
            if (user != null)
            {
                // send them to main form
                Form1 mainForm = new Form1();
                mainForm.SetUser(user);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                //error, Login failed
                MessageBox.Show("Invalid username or password");
            }

        }

        private void button_register_Click(object sender, EventArgs e)
        {
            // 1. get info from the user
            string username = textBox_username.Text;
            string password = textBox_password.Text;

            // 2. check if the user already exist
            var filter = Builders<Users>.Filter.Eq("Username", username);
            var existingUser = userCollection.Find(filter).FirstOrDefault();

            // user does not exist, we can add it
            if (existingUser == null)
            {
                // add the user to the Mongodb    
                // 3. Create an instance of object User

                var user = new Users
                {
                    Username = username,
                    Password = password
                };

                // 4. add it to the database
                userCollection.InsertOne(user);

                MessageBox.Show("Registration Successful!");
            }
            else
            {
                //user already exist, show them the message
                MessageBox.Show("Username already exist, Please choose a different one");
            }
        }
    }
}
