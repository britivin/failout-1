using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class Sravnenie : Form
    {
        public string user_id;
        public string access_token;
        public string[] name = new string[2];
       
        public Sravnenie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                label1.Text = null;
                label1.Text = listView1.SelectedItems[0].SubItems[0].Text;
                
            }
    
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                label2.Text = null;
                label2.Text = listView2.SelectedItems[0].SubItems[0].Text;

            }
        }

        private void Sravnenie_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string request = "https://api.vk.com/method/wall.get.xml?owner_id=-147418714&filter=owner";
            doc.Load(request);

            listView1.Items.Clear();

            foreach (XmlNode level1 in doc.SelectNodes("response"))
            {

                foreach (XmlNode level2 in level1.SelectNodes("post"))
                {


                    foreach (XmlNode level3 in level2.SelectNodes("text"))
                    {

                        name[1] = level3.InnerText;

                    }

                    foreach (XmlNode level4 in level2.SelectNodes("attachment"))
                    {

                        foreach (XmlNode level5 in level4.SelectNodes("photo"))
                        {

                            foreach (XmlNode level6 in level5.SelectNodes("src_big"))
                            {

                                pictureBox1.Load(level6.InnerXml);


                            }
                        }
                    }



                    imageList1.Images.Add(pictureBox1.Image);

                    listView1.Items.Add(name[1], imageList1.Images.Count - 1);
                    listView2.Items.Add(name[1], imageList1.Images.Count - 1);

                    Application.DoEvents();



                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label1.Text == label2.Text) { label3.Text = "Совпадение!"; } else { label3.Text = "Error"; }
        }
    }
}
