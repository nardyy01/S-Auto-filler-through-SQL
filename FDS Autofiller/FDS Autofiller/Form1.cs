using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading;

namespace FDS_Autofiller
{
    public partial class Form1 : Form
    {
        //Variables
        Entry entry;
        public static int FDS_Submitted = 1;
        public Random number = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Login automatically
                webBrowser1.Document.GetElementById("text_username").SetAttribute("value", "xxxx");//Replaced Info
                webBrowser1.Document.GetElementById("text_password").SetAttribute("value", "xxxx");//Replaced Info
                webBrowser1.Document.GetElementById("buttonSubmit").InvokeMember("click");
            }
            catch { errorProvider.SetError(button1,"You click the wrong button for this page!"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //set the date
                webBrowser1.Document.GetElementById("datet_125243").SetAttribute("value", DateTime.Today.ToString("MM/dd/yyyy"));

                //Marking first set of checkboxes
                webBrowser1.Document.GetElementById("check_145333_1").InvokeMember("click");
                webBrowser1.Document.GetElementById("check_145333_3").InvokeMember("click");
                webBrowser1.Document.GetElementById("check_145333_5").InvokeMember("click");
                webBrowser1.Document.GetElementById("check_145333_7").InvokeMember("click");

                //Marking second set of checkboxes
                webBrowser1.Document.GetElementById("check_145334_4").InvokeMember("click");
                webBrowser1.Document.GetElementById("check_145334_5").InvokeMember("click");

                //Marking third set of cbxs and submit
                webBrowser1.Document.GetElementById("check_145335_0").InvokeMember("click");
                webBrowser1.Document.GetElementById("check_145335_2").InvokeMember("click");
                webBrowser1.Document.GetElementById("check_145335_4").InvokeMember("click");
                webBrowser1.Document.GetElementById("check_145335_6").InvokeMember("click");
                webBrowser1.Document.GetElementById("check_145335_8").InvokeMember("click");
                webBrowser1.Document.GetElementById("check_145335_10").InvokeMember("click");
                webBrowser1.Document.GetElementById("check_145335_12").InvokeMember("click");
                webBrowser1.Document.GetElementById("check_145335_14").InvokeMember("click");
                webBrowser1.Document.GetElementById("check_145335_16").InvokeMember("click");
                webBrowser1.Document.GetElementById("check_145335_18").InvokeMember("click");
                webBrowser1.Document.GetElementById("check_145335_19").InvokeMember("click");
                webBrowser1.Document.GetElementById("check_145335_20").InvokeMember("click");
                webBrowser1.Document.GetElementById("button_next").InvokeMember("click");
            }
            catch { errorProvider.SetError(button2, "You click the wrong button for this page!"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //select everything and hit next
                webBrowser1.Document.GetElementById("radio_124916_" + number.Next(6)).InvokeMember("click");
                webBrowser1.Document.GetElementById("radio_125491_" + number.Next(6)).InvokeMember("click");
                webBrowser1.Document.GetElementById("radio_124917_" + number.Next(6)).InvokeMember("click");
                webBrowser1.Document.GetElementById("radio_125492_" + number.Next(6)).InvokeMember("click");
                webBrowser1.Document.GetElementById("radio_134422_" + number.Next(6)).InvokeMember("click");
                webBrowser1.Document.GetElementById("radio_134423_" + number.Next(6)).InvokeMember("click");
                webBrowser1.Document.GetElementById("button_next").InvokeMember("click");
            }
            catch { errorProvider.SetError(button3, "You click the wrong button for this page!"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //select everything and hit next
                webBrowser1.Document.GetElementById("radio_134425_" + number.Next(6)).InvokeMember("click");
                webBrowser1.Document.GetElementById("radio_134426_" + number.Next(6)).InvokeMember("click");
                webBrowser1.Document.GetElementById("radio_145337_" + number.Next(7)).InvokeMember("click");
                webBrowser1.Document.GetElementById("radio_145338_" + number.Next(7)).InvokeMember("click");
                webBrowser1.Document.GetElementById("button_next").InvokeMember("click");
            }
            catch { errorProvider.SetError(button4, "You click the wrong button for this page!"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }




    }
}

        
