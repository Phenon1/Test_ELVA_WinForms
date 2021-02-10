using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace Test_ELVA_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBoxService.Items.Add(Model.OSM.name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBoxArea.Text=="")
            {
                MessageBox.Show("Заполните поле область!");
                return;
            }
            if (comboBoxService.SelectedIndex<0)
            {
                MessageBox.Show("Выберите сервис!");
                return;
            }
            Model.OSM OSM = new Model.OSM();
            OSM.GetJson(textBoxArea.Text);
            OSM.Trim((int)numericUpDownSpace.Value);

            if (saveFileDialogJson.ShowDialog() == DialogResult.Cancel)
                return;
           
            string filename = saveFileDialogJson.FileName;

            System.IO.File.WriteAllText(filename, OSM.Serilize());
            MessageBox.Show("Файл сохранен");

        }
    }
}
