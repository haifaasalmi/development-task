using System;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog of = new OpenFileDialog() { Filter = "Text Documents|*.txt", Multiselect = false, ValidateNames = true })
                {
                    if (of.ShowDialog() == DialogResult.OK)
                    {
                        // عرض اسم الملف في الليبل
                        textBox7.Text = Path.GetFileName(of.FileName); // عرض اسم الملف 

                        using (StreamReader sr = new StreamReader(of.FileName))
                        {
                            //  split 
                            string content = await sr.ReadToEndAsync();
                            string[] items = content.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                            // تعيين القيم في  Labels
                            if (items.Length > 0) textBox2.Text = items.Length > 0 ? items[0].Trim() : "";
                            if (items.Length > 1) textBox3.Text = items.Length > 1 ? items[1].Trim() : "";
                            if (items.Length > 2) textBox4.Text = items.Length > 2 ? items[2].Trim() : "";
                            if (items.Length > 3) textBox5.Text = items.Length > 3 ? items[3].Trim() : "";
                            if (items.Length > 4) textBox6.Text = items.Length > 4 ? items[4].Trim() : "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}