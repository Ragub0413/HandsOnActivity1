using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Laboratory1
{
    public partial class FrmRegistration : Form
    {
        public static string FileNames;


        private String _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;


        public long StudentNumber(string studNum)
        {

            _StudentNo = long.Parse(studNum);

            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }
            else
            {
                throw new FormatException();
                throw new ArgumentNullException();
                throw new OverflowException();
                throw new IndexOutOfRangeException();
            }

            return _ContactNo;
        }
        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }
            else
            {
                throw new ArgumentNullException();
            }


            return _FullName;
        }
        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }
            else
            {
                throw new FormatException();
                throw new ArgumentNullException();
                throw new OverflowException();
                throw new IndexOutOfRangeException();
            }

            return _Age;
        }


        public FrmRegistration()
        {
            InitializeComponent();
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {

                string[] Information = new string[]{

                "Student No.: " + StudentNumber(txtStudentNo.Text),
                "Full Name: " + FullName(txtLastName.Text,txtFirstName.Text,txtMiddleInitial.Text),
                "Program: "+ cbProgram.Text,
                "Gender: " + cbGender.Text,
                "Age: " + Age(txtAge.Text),
                "Birthday: "+ dpBirthday.Value.ToString("yyyy-MM-dd"),
                "Contact No.: " + ContactNo(txtContactNo.Text)
            };


                FileNames = txtStudentNo.Text + ".txt";

                String docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, FileNames)))
                {

                    foreach (string i in Information)
                    {
                        outputFile.WriteLine(i);
                        Console.WriteLine(i);
                    }

                    txtAge.Clear();
                    txtStudentNo.Clear();
                    txtFirstName.Clear();
                    txtLastName.Clear();
                    txtMiddleInitial.Clear();
                    txtContactNo.Clear();
                }
            }
            catch (FormatException f)
            {
                MessageBox.Show(f.Message);
            }
            catch (ArgumentNullException a)
            {
                MessageBox.Show(a.Message);
            }
            catch (OverflowException o)
            {
                MessageBox.Show(o.Message);
            }
            catch (IndexOutOfRangeException i)
            {
                MessageBox.Show(i.Message);
            }

               
            
           
        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
            
            "BS Information Technology",
            "BS Computer Science",
            "BS Information Systems",
            "BS in Accountancy",
            "BS in Hospitality Management",
            "BS in Tourism Management"
            };
            for (int i = 0; i < 6; i++)
            {
                cbProgram.Items.Add(ListOfProgram[i].ToString());
            }


            string[] Genders = new string[]{
                "Male", "Female"
            };
            for (int i = 0; i < 2; i++)
            {
                cbGender.Items.Add(Genders[i].ToString());
            }
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmStudentRecord record = new FrmStudentRecord();
            record.Show();

            

        }

        
      
    }
}
