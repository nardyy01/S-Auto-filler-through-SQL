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
            try
            {
                //Get an entry from the sql database
                entry = getEntry();
                //Enter entry's First and Last name
                webBrowser1.Document.GetElementById("question_124926").SetAttribute("value", entry.firstName);
                webBrowser1.Document.GetElementById("question_124927").SetAttribute("value", entry.lastName);
                //Handle yes buttons
                webBrowser1.Document.GetElementById("radio_129859_0").InvokeMember("click");
                webBrowser1.Document.GetElementById("radio_125390_0").InvokeMember("click");
                webBrowser1.Document.GetElementById("button_next").InvokeMember("click");
            }
            catch { errorProvider.SetError(button4, "You click the wrong button for this page!"); }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //Enter entry's email
                webBrowser1.Document.GetElementById("question_124928").SetAttribute("value", entry.Email);
                webBrowser1.Document.GetElementById("button_next").InvokeMember("click");
                label1.Text = "# FDS Submitted: " + (FDS_Submitted); FDS_Submitted++;
            }
            catch { errorProvider.SetError(button6, "You click the wrong button for this page!"); }
        }
        
public Entry getEntry()
        {
            //Connection
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3FQRKAU;Initial Catalog=FDS_EntryList;Integrated Security=True");
            //DataAdapter - CommandBuilder - DataSet
            SqlDataAdapter da;
            SqlCommandBuilder cmdBuilder;
            DataSet entryDataSet = new DataSet();

            //Create a new entry to hold info
            Entry entry = new Entry();
            //Using my sql connection
            using (con)
            {
                //Pull all data from my Entries table
                string oString = "SELECT * FROM Entries";
                SqlCommand oCmd = new SqlCommand(oString, con);
                //Open the connection to sql

                con.Open();
                //Using what we are pulled
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    //Read through the data 
                    while (oReader.Read())
                    {
                        entry.firstName = oReader["FIRST_NAME"].ToString();
                        entry.lastName = oReader["LAST_NAME"].ToString();
                        entry.Email = oReader["EMAIL"].ToString();
                        entry.Used = oReader["USED"].ToString();
                        entry.EID = oReader["EID"].ToString();

                        //if the entry is not used keep it
                        if (entry.Used == "False")
                        {
                            oReader.Close();
                            //Initialize SQLDataAdapter
                            da = new SqlDataAdapter("SELECT * FROM Entries WHERE EID ='"+ entry.EID +"'", con);
                            //Initialize SQLCommandBuilder
                            cmdBuilder = new SqlCommandBuilder(da);
                            //Populate DataSet
                            da.Fill(entryDataSet, "Entries");

                            //Modify value for USED. Make true
                            entryDataSet.Tables["Entries"].Rows[0]["USED"] = "True";

                            //Post the data to database
                            da.Update(entryDataSet, "Entries");
                            break;
                        }
                    }               
                    //Close connection to sql
                    con.Close();
                }

            }
            //Return the entry that we kept
            return (entry);
        }
    }
}

        
