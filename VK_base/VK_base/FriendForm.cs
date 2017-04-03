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
                        string[] name = new string[2];

                        foreach (XmlNode level4 in level3.SelectNodes("first_name"))
                        {
                            name[0] = level4.InnerText;
                        }
                        foreach (XmlNode level4 in level3.SelectNodes("last_name"))
                        {
                            name[1] = name + " " + level4.InnerText;
                        }
                        foreach (XmlNode level4 in level3.SelectNodes("photo_100"))
                        {
                            pictureBox1.Load(level4.InnerText);
                        }
                         ListViewItem item = new ListViewItem(name,imageList1.Images.Count-1);
                        imageList1.Images.Add(pictureBox1.Image);
                        listView1.Items.Add(item);
                        Application.DoEvents();
                        
                    }
                }
            }

            XmlDocument docGP = new XmlDocument();
            string Groups = "https://api.vk.com/method/groups.get.xml?fields=photo_100&access_token=" + access_token + "&extended=1&v=5.62";
            docGP.Load(Groups);

            foreach (XmlNode level1 in docGP.SelectNodes("response"))
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
                            pictureBox2.Load(level4.InnerText);
                            //name = name + " " + level4.InnerText;
                        }
                        foreach (XmlNode level4 in level3.SelectNodes("photo_100"))
                        {
                            
                        }

                        imageList2.Images.Add(pictureBox2.Image);
                        listView2.Items.Add(name, imageList2.Images.Count - 1);
                        Application.DoEvents();

                    }
                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
