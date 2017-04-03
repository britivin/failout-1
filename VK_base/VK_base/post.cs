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
    public partial class post : Form
    {

        public string user_id;
        public string access_token;

        public post()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string request = "https://api.vk.com/method/wall.get.xml?owner_id=-121327074&filter=owner";
            doc.Load(request);

            listView1.Items.Clear();

            foreach (XmlNode level1 in doc.SelectNodes("response"))
            {
                foreach (XmlNode level2 in level1.SelectNodes("items"))
                {

                    foreach (XmlNode level3 in level2.SelectNodes("group"))
                    {
                        string name = "";

                        foreach (XmlNode level4 in level3.SelectNodes("name"))
                        {
                            name = level4.InnerText;
                        }
                        foreach (XmlNode level4 in level3.SelectNodes("photo_100"))
                        {
                            pictureBox1.Load(level4.InnerText);
                            
                        }
                        foreach (XmlNode level4 in level3.SelectNodes("photo_100"))
                        {

                        }

                        imageList1.Images.Add(pictureBox1.Image);
                        listView1.Items.Add(name, imageList1.Images.Count - 1);
                        Application.DoEvents();

                    }
                }
            }
        }
    }
}
