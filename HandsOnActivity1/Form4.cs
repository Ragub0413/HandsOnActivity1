using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Laboratory1
{
    public partial class FrmStudentRecord : Form
    {
        public FrmStudentRecord()
        {
            InitializeComponent();
        }
        void Find()
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text File";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "txt file (*.txt)| *.txt| All files (*.*)|*.*";
            openFileDialog1.ShowDialog();
            String path = openFileDialog1.FileName;

            using (StreamReader streamReader = File.OpenText(path))
            {
                String _getText = "";
                while ((_getText = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(_getText);
                    lvShowData.Items.Add(_getText);
                }

            }
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmRegistration register = new FrmRegistration();
            register.ShowDialog();

            
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully Uploaded");
            lvShowData.Items.Clear();
        }
    }
}
