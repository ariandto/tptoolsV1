using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TapControlDemo
{
    public partial class frm : Form
    {
        public frm()
        {
            InitializeComponent();
            richTextBox1.Focus();
            radioButton1.Checked = true;
        }


        void pilihkls()
        {
            string Nol = "000";
            string koma = ";";
            string hasil = "";
            string message = "Richtextbox masih kosong || String Length == 0";
            string title = "Information || Error!";
            var lines = richTextBox1.Text.Split('\n', '\r').ToList();

            if (radioButton2.Checked == true)
                foreach (var line in lines.Distinct())
                {

                    hasil = line + koma;
                    hasil = System.Text.RegularExpressions.Regex.Replace(hasil, " ", "");
                    richTextBox2.AppendText(hasil);
                }

            if (richTextBox1.Text.Length == 0)
            {
                MessageBox.Show(message, title);
            }
            else if (radioButton1.Checked == true)
            {
                foreach (var line in lines.Distinct())
                {

                    hasil = Nol + line + koma;
                    hasil = System.Text.RegularExpressions.Regex.Replace(hasil, " ", "");
                    hasil = System.Text.RegularExpressions.Regex.Replace(hasil, "000;", "");
                    richTextBox2.AppendText(hasil);
                    //richTextBox2.AppendText("\r\n");
                }

            }
        }

            void pilihace()
            {
                string Nol = "00";
                string koma = ";";
                string hasil = "";
                string message = "Richtextbox masih kosong || String Length == 0";
                string title = "Information || Error!";
                var lines = richTextBox1.Text.Split('\n', '\r').ToList();

                if (radioButton2.Checked == true)
                    foreach (var line in lines.Distinct())
                    {

                        hasil = line + koma;
                        hasil = System.Text.RegularExpressions.Regex.Replace(hasil, " ", "");
                        richTextBox2.AppendText(hasil);
                    }

                if (richTextBox1.Text.Length == 0)
                {
                    MessageBox.Show(message, title);
                }
                else if (radioButton1.Checked == true)
                {
                    foreach (var line in lines.Distinct())
                    {

                        hasil = Nol + line + koma;
                        hasil = System.Text.RegularExpressions.Regex.Replace(hasil, " ", "");
                        hasil = System.Text.RegularExpressions.Regex.Replace(hasil, "00;", "");
                        richTextBox2.AppendText(hasil);
                        //richTextBox2.AppendText("\r\n");
                    }

                }
            }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length != 0 || richTextBox2.Text.Length != 0)
            {
                richTextBox1.Text = "";
                richTextBox2.Text = "";

            }
        }

       
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length != 0 || richTextBox2.Text.Length != 0)
            {
                richTextBox1.Text = "";
                richTextBox2.Text = "";

            }
        }

        private void frm_Load(object sender, EventArgs e)
        {

            this.BackColor = System.Drawing.Color.WhiteSmoke;
            // Get the hostname

            string myHost = System.Net.Dns.GetHostName();

            // Show the hostname

            label2.Text = myHost;

            // Get the IP from the host name

            string myIP = System.Net.Dns.GetHostByName(myHost).AddressList[0].ToString();

            // Show the IP

            label4.Text = myIP;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "Tidak Bisa Copy ke Clipboard karena kosong || Cannot copy string into your Clipboard";
            string title = "Information || Error!";
            if (richTextBox2.Text.Length == 0)
            {
                MessageBox.Show(message, title);
            }
            else
                richTextBox2.Focus();
                richTextBox2.SelectAll();
                richTextBox2.Copy();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string message = "Anda belum memilih BU KLS/AHI, Pilih salah satu!!";
            string tittle = "Information || Error!";
            
            if (this.comboBox1.SelectedItem == "KLS")
            {
                pilihkls();
            }
            else if (this.comboBox1.SelectedItem == "AHI")
            {
                pilihace();
            }
            else
                MessageBox.Show(message, tittle);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = "Richtextbox kosong || Empty string!!";
            string title = "Information || Error!";
            if (richTextBox1.Text.Length == 0)
            {
                MessageBox.Show(message, title);
            }
            else
                richTextBox1.Text = "";
                richTextBox2.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
