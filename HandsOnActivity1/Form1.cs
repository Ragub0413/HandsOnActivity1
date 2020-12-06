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
    public partial class FrmLab1 : Form
    {
       
        public FrmLab1()
        {

            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmFileName fileName = new FrmFileName();
            fileName.ShowDialog();
           
            String getInput = txtInput.Text;


            String docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath,FrmFileName.SetFileName)))
            {
                outputFile.WriteLine(getInput);
                Console.WriteLine(getInput);
            }

            
        }
    }
}
