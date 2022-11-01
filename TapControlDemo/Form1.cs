using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TapControlDemo
{
    public partial class Form1 : Form
    {
        Image closeImage, closeImageAct;
        public Form1()
        {
            InitializeComponent();
        }
       
        private void AddTabPage(Form frm)
        {
            int t = KTFormTonTai(frm);
            if (t >= 0) 
            {
                
                if (tabControl1.SelectedTab == tabControl1.TabPages[t])
                    MessageBox.Show("Tab \"" + frm.Text.Trim() + "\" is active!");
                else
                    tabControl1.SelectedTab = tabControl1.TabPages[t];
            }
            else // them 
            {
                TabPage newTab = new TabPage(frm.Text.Trim());
                tabControl1.TabPages.Add(newTab);
                frm.TopLevel = false;
                frm.Parent = newTab;
                tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabCount - 1];
                frm.Show();
                frm.Dock = DockStyle.Fill;

            }
        }
        private int KTFormTonTai(Form frm)
        {
            for (int i = 0; i < tabControl1.TabCount; i++)
                if (tabControl1.TabPages[i].Text == frm.Text.Trim())
                    return i;
            return -1;
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            
            Rectangle rect = tabControl1.GetTabRect(e.Index);
            Rectangle imageRec = new Rectangle(rect.Right - closeImage.Width, 
                rect.Top + (rect.Height - closeImage.Height) / 2,
                closeImage.Width, closeImage.Height);
            
            rect.Size = new Size(rect.Width+20, 38);
          
            Font f;
            Brush br = Brushes.Black;
            StringFormat strF=new StringFormat(StringFormat.GenericDefault);
           
            if(tabControl1.SelectedTab==tabControl1.TabPages[e.Index])
            {
                
                e.Graphics.DrawImage(closeImageAct, imageRec);
                f = new Font("Arial", 10, FontStyle.Bold);
                
                e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text,
                    f,br,rect, strF);
            }
            else
            {
                
                e.Graphics.DrawImage(closeImage, imageRec);
                f = new Font("Arial", 9, FontStyle.Regular);
                
                e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text,
                    f, br, rect, strF);
            }
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            
            for(int i=0; i< tabControl1.TabCount;i++)
            {
               
                Rectangle rect = tabControl1.GetTabRect(i);
                Rectangle imageRec = new Rectangle(rect.Right - closeImage.Width,
                    rect.Top + (rect.Height - closeImage.Height) / 2,
                    closeImage.Width, closeImage.Height);

                if (imageRec.Contains(e.Location))
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        private void addTabPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new frm());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size mysize = new System.Drawing.Size(20, 20); 
            Bitmap bt = new Bitmap(Properties.Resources.close); 
            
            Bitmap btm = new Bitmap(bt, mysize);
            closeImageAct = btm;
           
            Bitmap bt2 = new Bitmap(Properties.Resources.closeBlack);
            
            Bitmap btm2 = new Bitmap(bt2, mysize);
            closeImage = btm2;
            tabControl1.Padding = new Point(30);

        }

        private void updateJalurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPage(new frm2());
        }
    }
}
