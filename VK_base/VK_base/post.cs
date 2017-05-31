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
            string request = "https://api.vk.com/method/wall.get.xml?owner_id=-147418714&filter=owner";
            doc.Load(request);

            listView1.Items.Clear();

            foreach (XmlNode level1 in doc.SelectNodes("response"))
            {
                    string name = "";

                foreach (XmlNode level2 in level1.SelectNodes("post"))
                {
                   

                    foreach (XmlNode level3 in level2.SelectNodes("text"))
                    {

                        name = level3.InnerText;

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

                            listView1.Items.Add(name, imageList1.Images.Count - 1);

                            Application.DoEvents();                            
                        
                    }
                }
            }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void post_Load(object sender, EventArgs e)
        {

        }
         }
      }

