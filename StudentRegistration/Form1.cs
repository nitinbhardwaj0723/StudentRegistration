using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace StudentRegistration
{
    public class Form1 : Form
    {
        private readonly TextBox txtName = new();
        private readonly TextBox txtEmail = new();
        private readonly TextBox txtPhone = new();
        private readonly RadioButton rbMale = new();
        private readonly RadioButton rbFemale = new();
        private readonly ComboBox cmbCourse = new();
        private readonly CheckBox chkReading = new();
        private readonly CheckBox chkSports = new();
        private readonly CheckBox chkMusic = new();
        private readonly DateTimePicker dtpDOB = new();
        private readonly Label lblSummary = new();

        public Form1()
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = "Student Registration Form";
            ClientSize = new Size(680, 650);
            AutoScroll = true;
            AutoScrollMinSize = new Size(0, 790);

            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Font = new Font("Segoe UI", 9F);

            Label title = new()
            {
                Text = "STUDENT REGISTRATION",
                Font = new Font("Segoe UI", 19F, FontStyle.Bold),
                ForeColor = Color.FromArgb(35, 75, 130),
                Location = new Point(155, 20),
                Size = new Size(390, 42)
            };
            Controls.Add(title);

            AddLabel("Student Name:", 60, 95);
            ConfigureTextBox(txtName, "txtName", 220, 90, 380);

            AddLabel("Email:", 60, 145);
            ConfigureTextBox(txtEmail, "txtEmail", 220, 140, 380);

            AddLabel("Phone Number:", 60, 195);
            ConfigureTextBox(txtPhone, "txtPhone", 220, 190, 380);
            txtPhone.MaxLength = 10;

            GroupBox genderBox = new()
            {
                Text = "Gender",
                Name = "grpGender",
                Location = new Point(60, 230),
                Size = new Size(540, 65)
            };
            rbMale.Text = "Male";
            rbMale.Name = "rbMale";
            rbMale.Location = new Point(145, 27);
            rbFemale.Text = "Female";
            rbFemale.Name = "rbFemale";
            rbFemale.Location = new Point(275, 27);
            genderBox.Controls.Add(rbMale);
            genderBox.Controls.Add(rbFemale);
            Controls.Add(genderBox);

            AddLabel("Select Course:", 60, 320);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Location = new Point(220, 315);
            cmbCourse.Size = new Size(380, 28);
            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourse.Items.AddRange(new object[]
            {
                "BCA", "B.Tech", "Diploma in IT", "MCA", "B.Sc"
            });
            Controls.Add(cmbCourse);

            GroupBox hobbiesBox = new()
            {
                Text = "Hobbies",
                Name = "grpHobbies",
                Location = new Point(60, 360),
                Size = new Size(540, 75)
            };
            ConfigureCheckBox(chkReading, "chkReading", "Reading", 85);
            ConfigureCheckBox(chkSports, "chkSports", "Sports", 225);
            ConfigureCheckBox(chkMusic, "chkMusic", "Music", 355);
            hobbiesBox.Controls.Add(chkReading);
            hobbiesBox.Controls.Add(chkSports);
            hobbiesBox.Controls.Add(chkMusic);
            Controls.Add(hobbiesBox);

            AddLabel("Date of Birth:", 60, 465);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Location = new Point(220, 460);
            dtpDOB.Size = new Size(200, 27);
            dtpDOB.Format = DateTimePickerFormat.Short;
            dtpDOB.MaxDate = DateTime.Today;
            Controls.Add(dtpDOB);

            Button btnSubmit = new()
            {
                Name = "btnSubmit",
                Text = "Submit",
                Location = new Point(220, 510),
                Size = new Size(145, 40),
                BackColor = Color.RoyalBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSubmit.Click += btnSubmit_Click;
            Controls.Add(btnSubmit);

            Button btnClear = new()
            {
                Name = "btnClear",
                Text = "Clear",
                Location = new Point(385, 510),
                Size = new Size(120, 40)
            };
            btnClear.Click += btnClear_Click;
            Controls.Add(btnClear);

            Label summaryTitle = new()
            {
                Text = "Student Summary",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(60, 565),
                Size = new Size(250, 28)
            };
            Controls.Add(summaryTitle);

            lblSummary.Name = "lblSummary";
            lblSummary.Location = new Point(60, 595);
            lblSummary.Size = new Size(540, 165);
            lblSummary.BorderStyle = BorderStyle.FixedSingle;
            lblSummary.Padding = new Padding(8);
            lblSummary.Text = "Submitted student details will appear here.";
            Controls.Add(lblSummary);
        }

        private void AddLabel(string text, int x, int y)
        {
            Controls.Add(new Label
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10F)
            });
        }

        private void ConfigureTextBox(TextBox box, string name, int x, int y, int width)
        {
            box.Name = name;
            box.Location = new Point(x, y);
            box.Size = new Size(width, 27);
            Controls.Add(box);
        }

        private void ConfigureCheckBox(CheckBox box, string name, string text, int x)
        {
            box.Name = name;
            box.Text = text;
            box.Location = new Point(x, 30);
            box.AutoSize = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (name == "")
            {
                MessageBox.Show("Please enter Student Name.", "Validation Error");
                txtName.Focus();
                return;
            }

            if (email == "")
            {
                MessageBox.Show("Please enter Email.", "Validation Error");
                txtEmail.Focus();
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid Email address.", "Validation Error");
                txtEmail.Focus();
                return;
            }

            if (phone == "")
            {
                MessageBox.Show("Please enter Phone Number.", "Validation Error");
                txtPhone.Focus();
                return;
            }

            if (!Regex.IsMatch(phone, @"^[0-9]{10}$"))
            {
                MessageBox.Show("Phone Number must contain exactly 10 digits.", "Validation Error");
                txtPhone.Focus();
                return;
            }

            if (!rbMale.Checked && !rbFemale.Checked)
            {
                MessageBox.Show("Please select Gender.", "Validation Error");
                return;
            }

            if (cmbCourse.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Course.", "Validation Error");
                cmbCourse.Focus();
                return;
            }

            if (!chkReading.Checked && !chkSports.Checked && !chkMusic.Checked)
            {
                MessageBox.Show("Please select at least one Hobby.", "Validation Error");
                return;
            }

            string gender = rbMale.Checked ? "Male" : "Female";
            string hobbies = "";
            if (chkReading.Checked) hobbies += "Reading, ";
            if (chkSports.Checked) hobbies += "Sports, ";
            if (chkMusic.Checked) hobbies += "Music, ";
            hobbies = hobbies.TrimEnd(',', ' ');

            lblSummary.Text =
                "STUDENT REGISTRATION DETAILS\r\n\r\n" +
                "Name: " + name + "\r\n" +
                "Email: " + email + "\r\n" +
                "Phone: " + phone + "\r\n" +
                "Gender: " + gender + "\r\n" +
                "Course: " + cmbCourse.Text + "\r\n" +
                "Hobbies: " + hobbies + "\r\n" +
                "Date of Birth: " + dtpDOB.Value.ToString("dd-MM-yyyy");

            MessageBox.Show("Student registered successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InitializeComponent()
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            rbMale.Checked = false;
            rbFemale.Checked = false;
            cmbCourse.SelectedIndex = -1;
            chkReading.Checked = false;
            chkSports.Checked = false;
            chkMusic.Checked = false;
            dtpDOB.Value = DateTime.Today;
            lblSummary.Text = "Submitted student details will appear here.";
            txtName.Focus();
        }
    }
}
