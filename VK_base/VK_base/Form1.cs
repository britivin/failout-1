﻿using System;
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
    public partial class Form1 : Form
    {
        public string access_token;
        public string user_id; 

        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://oauth.vk.com/authorize?client_id=5889611&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=friends&response_type=token&v=5.37");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string url = e.Url.ToString();
            if (url.Contains("access_token"))
            {
                
                int index = url.IndexOf("access_token=");
                int index2 = url.IndexOf("&expires_in");
                access_token = url.Substring(index + 13, index2 - index - 13);
                index = url.IndexOf("user_id=");
                user_id = url.Substring(index + 8);


                XmlDocument doc = new XmlDocument();

                string request = "https://api.vk.com/method/users.get.xml?fields=photo_100&access_token=" + access_token + "&v=5.62";

                doc.Load(request);
                if (doc.InnerXml.Contains("error"))
                {
                    MessageBox.Show("Ошибка получения данных о пользователе!");
                }
                foreach (XmlNode level1 in doc.SelectNodes("response"))
                {
                    foreach (XmlNode level2 in level1.SelectNodes("user"))
                    {
                        foreach (XmlNode level3 in level2.SelectNodes("first_name"))
                        {
                            label1.Text = level3.InnerText;
                        }
                        foreach (XmlNode level3 in level2.SelectNodes("last_name"))
                        {
                            label2.Text = level3.InnerText;
                        }
                        foreach (XmlNode level3 in level2.SelectNodes("photo_100"))
                        {
                            pictureBox1.ImageLocation = level3.InnerText;
                        }
                    }
                }
                webBrowser1.Visible = false;


                find_groups_box.Text = access_token + " " + user_id;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SpamButton_Click(object sender, EventArgs e)
        {
            SpamForm frm = new SpamForm();
            frm.ShowDialog();
        }

        private void DogPatulButton_Click(object sender, EventArgs e)
        {
            DogPatrulForm frm = new DogPatrulForm();
            frm.ShowDialog();
        }

        private void AutoLike_button_Click(object sender, EventArgs e)
        {
            AutoLike_form frm = new AutoLike_form();
            frm.ShowDialog();
        }

        private void addFriends_Click(object sender, EventArgs e)
        {

        }

        private void gropssercbaton_Click(object sender, EventArgs e)
        {
            Gropsserc serc = new Gropsserc();
            serc.ShowDialog();
        }

        private void Laikbutton_Click(object sender, EventArgs e)
        {
            AutoLike_form serc = new AutoLike_form();
            serc.ShowDialog();
        }

        private void find_groups_button_Click(object sender, EventArgs e)
        {
            Sravnenie SravGroups = new Sravnenie();

            SravGroups.user_id = user_id;
            SravGroups.access_token = access_token;
            SravGroups.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            FriendForm blabla = new FriendForm();
            blabla.access_token = access_token;
            blabla.user_id = user_id;
            blabla.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            post postGroups = new post();
            
            postGroups.user_id = user_id;
            postGroups.access_token = access_token;
            postGroups.ShowDialog();
        }

    }
}
