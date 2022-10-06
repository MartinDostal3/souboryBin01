using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace souboryBin01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("CelaCisla.txt");

          
            
            listBox1.Items.Clear();
            while (!sr.EndOfStream)
            {

                listBox1.Items.Add(sr.ReadLine());
            }
            sr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("CelaCisla.txt");
            FileStream fs = new FileStream("celaCisla.dat", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            while(!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                int cislo = int.Parse(s);
                bw.Write(cislo);
            }
            fs.Close();
            sr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            FileStream fs = new FileStream("celaCisla.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            while (fs.Position < fs.Length)
            {
                int cislo = br.ReadInt32();
                listBox2.Items.Add(cislo);
            }
            br.Close();
            fs.Close();
        }
    }
}
