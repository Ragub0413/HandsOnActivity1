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
        public FrmRegistration()
        {
            InitializeComponent();
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
           

                string[] Information = new string[]{

                "Student No.: " + txtStudentNo.Text,
                "Full Name: " + txtLastName.Text + "," + txtFirstName.Text+ "," + txtMiddleInitial.Text,
                "Program: "+ cbProgram.Text,
                "Gender: " + cbGender.Text,
                "Age: " + txtAge.Text,
                "Birthday: "+ dpBirthday.Value.ToString("yyyy-MM-dd"),
                "Contact No.: " + txtContactNo.Text
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

                }


                txtAge.Clear();
                txtStudentNo.Clear();
                txtFirstName.Clear();
                txtLastName.Clear();
                txtMiddleInitial.Clear();
                txtContactNo.Clear();
            
           
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
