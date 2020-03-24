using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Çekiliş_Uygulaması
{
    public partial class Form1 : Form
    {
        //count how many items exist in the list
        int count = 0;
        public Form1()
        {
            InitializeComponent();
            Properties.Settings.Default.DefColor = Color.White;
        }
        //declare a color dialog object
        ColorDialog Col = new ColorDialog();
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }//close the app when in case

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK==Col.ShowDialog())
            {
                this.BackColor = Col.Color;
                Properties.Settings.Default.Renk = Col.Color;
                Properties.Settings.Default.Save();

            }
        }   //color settings

        private void Form1_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.Locked = this.Size;
            Properties.Settings.Default.Save();
            this.BackColor = Properties.Settings.Default.DefColor;
        }       //Form settings

        private void button2_Click(object sender, EventArgs e)      //restarts the app
        {
            Application.Restart();
        }

        private void button1_Click(object sender, EventArgs e)  
        {
            if (textBox1.Text == "")
            {
                //when textbox1 is empty
                MessageBox.Show("Please type a name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                //add  item to listbox1
                listBox1.Items.Add(textBox1.Text);
                count++;
                textBox1.Clear();
                textBox1.Focus();
            }

        } //when the Add Button triggered
        private void button3_Click(object sender, EventArgs e)      //when the delete Button triggered
        {
            try
            {
                //add item to listbox, if error occurs go ahead inside the catch block
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                count--;
                textBox1.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Please choose a name to delete","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBox1.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random Ran = new Random();
            int x = Ran.Next(0, count);
            try
            {
                MessageBox.Show($"The Winner:{listBox1.Items[x]}");
                textBox1.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("There's no name given","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBox1.Focus();
            }
        }   //choose the winner

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Size = Properties.Settings.Default.Locked;
        }    //don't let the user resize the form

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.Enter)
            {
                MessageBox.Show("Please hit enter after typing","Exception",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBox1.Clear();
            }
        }//when the user typed and straight hit enter
    }
}