using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProgramPP
{
    public partial class Form2 : Form
    {
        private Projekt okno;
        private Series dane;
        private Series odz;
        public Form2(Projekt okno)
        {
            InitializeComponent();
            this.okno = okno;
            this.dane = this.chart2.Series[0];
            this.chart2.Series[0].Name = "Wartos probki";
            this.odz = this.chart2.Series[1];
            this.chart2.Series[1].Name = "Wartosc srednia";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Przypisywanie wartosci do danych na wykresie(chyba tak to sie nazywa)
        private void Form2_Load(object sender, EventArgs e)
        {
            int n = 1;
            this.dane.Points.Clear();
            this.odz.Points.Clear();
            foreach(float n3 in this.okno.liczby)
            {
                this.dane.Points.AddXY((double)n, (double)n3);
                this.odz.Points.AddXY((double)n, (double)this.okno.odz);
                n++;
            }

        }
        //Wlacz, wylacz wartosc probek, pokaz na wykresie, ukryj
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.chart2.Series[0].Enabled = this.checkBox1.Checked;
            this.comboBox1.Enabled = this.checkBox1.Checked;
        }
        //Wlacz, wylacz wartosc srednia, pokaz na wykresie, ukryj
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.chart2.Series[1].Enabled = this.checkBox2.Checked;
            this.comboBox2.Enabled = this.checkBox2.Checked;
        }
        //Wlacz, wylacz legende, pokaz na wykresie, ukryj
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            this.chart2.Legends[0].Enabled = this.checkBox3.Checked;
        }
        //Zmiana koloru wykersu wartosc probek
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.chart2.Series[0].Color = (this.comboBox1.SelectedIndex != 0) ? ((this.comboBox1.SelectedIndex != 1) ? Color.Blue : Color.Green) : Color.Red;
        }
        //Zmiana koloru wykersu wartosc srednia
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.chart2.Series[1].Color = (this.comboBox2.SelectedIndex != 0) ? ((this.comboBox2.SelectedIndex != 1) ? Color.Blue : Color.Green) : Color.Red;
        }
        //zamknij
        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
