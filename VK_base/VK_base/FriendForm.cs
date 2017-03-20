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
    public partial class FriendForm : Form
    {
        public string access_token;
        public string user_id;

        public FriendForm()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string request = "https://api.vk.com/method/friends.get.xml?user_id=" + user_id + "&fields=photo_100&access_token=" + access_token + "&v=5.62";
            doc.Load(request);

            listView1.Items.Clear();

            foreach(XmlNode level1 in doc.SelectNodes("response"))
            {
                foreach (XmlNode level2 in level1.SelectNodes("items"))
                {

                    foreach (XmlNode level3 in level2.SelectNodes("user"))
                    {
                        string name = "";

                        foreach (XmlNode level4 in level3.SelectNodes("first_name"))
                        {
                            name = level4.InnerText;
                        }
                        foreach (XmlNode level4 in level3.SelectNodes("last_name"))
                        {
                            name = name + " " + level4.InnerText;
                        }
                        foreach (XmlNode level4 in level3.SelectNodes("photo_100"))
                        {
                            pictureBox1.Load(level4.InnerText);
                        }

                        imageList1.Images.Add(pictureBox1.Image);
                        listView1.Items.Add(name,imageList1.Images.Count-1);
                        Application.DoEvents();
                        
                    }
                }
            }
        }
    }
}
