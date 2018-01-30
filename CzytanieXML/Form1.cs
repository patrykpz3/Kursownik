using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CzytanieXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void ReadXmlButton_Click(object sender, EventArgs e)
        {
            string FilePath = @"F:\test\authors.xml";

            AuthorsDataSet.ReadXml(FilePath);
            dataGridView1.DataSource = AuthorsDataSet;
            dataGridView1.DataMember = "Rate";
        }

        private void ShowSchemaButton_Click(object sender, EventArgs e)
        {
            System.IO.StringWriter swXML = new System.IO.StringWriter();
            AuthorsDataSet.WriteXmlSchema(swXML);
            textBox1.Text = swXML.ToString();
        }
    }
}
