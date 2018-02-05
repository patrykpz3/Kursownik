using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

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

        private void przyciskEuro_Click(object sender, EventArgs e)
        {
            // XPathDocument document = new XPathDocument(@"F:\test\authors.xml");
            // XPathNavigator navigator = document.CreateNavigator();
            // XPathNodeIterator nodes = navigator.Select("ExchangeRatesTable/Rates/Rate");
            // while (nodes.MoveNext())
            // {
            //     textBox2.Text = nodes.Current.Name;
            //}

            XmlDocument XmlDoc = new XmlDocument();
            try
            {
                XmlDoc.Load(@"F:\test\authors.xml");
                int Count = XmlDoc.GetElementsByTagName("Rate").Count;

                for (int i = 0; i < Count; i++)
                {
                    textBox2.Text = XmlDoc.GetElementsByTagName("Currency").Item(0).InnerText;
                }
            }
            catch (XmlException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
