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

namespace ProgramPP
{
    public partial class Projekt : Form
    {
        public float minimum;
        public float maksimum;
        public float odz;
        private string[] odstep_tekst;
        public float[] liczby;
        private Form2 wykres;
        

        public Projekt()
        {
            InitializeComponent();
            this.wykres = new Form2(this);
           
        }

        private void Projekt_Load(object sender, EventArgs e)
        {

        }
        //Otwieranie pliku i wyswietlanie wartosci probek
        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            bool flaga = false;
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                    try
                {
                    s = File.ReadAllText(this.openFileDialog1.FileName);
                    flaga = true;
                }
                catch
                {
                    DialogResult rezultat = MessageBox.Show("Blad z plikiem, cos poszlo nie tak");
                }
                if (flaga)
                {
                    this.odz = 0f;
                    this.minimum = 0f;
                    this.maksimum = 0f;
                    this.textBox1.Text = s;
                    this.button2_wykres.Enabled = true;
                    this.button3_zapisz.Enabled = true;
                    this.button4_generowanie.Enabled = true;
                    char[] odstep = new char[] { ';' };
                    this.odstep_tekst = s.Split(odstep);
                    float[] liczby = new float[this.odstep_tekst.Length];
                    int a = 0; //indeks
                    string[] tekst = this.odstep_tekst;
                    int n3 = 0;
                    while (true)
                    {
                        if(n3 >= tekst.Length)
                        {
                            this.liczby = new float[a];
                            int n4 = 0;
                            while (true)
                            {
                                if(n4 >= a)
                                {
                                    float[] liczby2 = this.liczby;
                                    int n5 = 0;
                                    while (true)
                                    {
                                        if(n5 >= liczby2.Length)
                                        {
                                            this.odz /= (float)this.liczby.Length;
                                            this.textBox2.Text = this.odz.ToString(); // przypisanie wartosci sredniej do textBoxa wartosc srednia
                                            float n2 = 0f;
                                            float[] liczby3 = this.liczby;
                                            int n7 = 0;
                                            while (true)
                                            {
                                                if(n7>= liczby3.Length)
                                                {
                                                    n2 /= (float)this.liczby.Length;
                                                    this.textBox3.Text = n2.ToString(); //przypisanie wartosci do textBoxa wariancja
                                                    this.minimum = this.liczby[0];
                                                    float[] liczby4 = this.liczby;
                                                    int n9 = 0;
                                                    while(true)
                                                    {
                                                        if(n9 >= liczby4.Length)
                                                        {
                                                        this.textBox4.Text = this.minimum.ToString(); // przypisanie wartosci minimalnej do textBoxa wartosc minimalna
                                                            this.maksimum = this.liczby[0];
                                                            float[] liczby5 = this.liczby;
                                                            int n11 = 0;
                                                            while(true)
                                                            {
                                                                if(n11 >= liczby5.Length)
                                                                {
                                                                    this.textBox5.Text = this.maksimum.ToString(); // przypisanie wartosci maksimum do textBoxa wartosc maksimum
                                                                    break;
                                                                }
                                                                float n12 = liczby5[n11];
                                                                if(n12 > this.maksimum)
                                                                {
                                                                    this.maksimum = n12; // przypisanie do wartosci maksymalnej wartosc zmiennej n12
                                                                }
                                                                n11++;
                                                            }
                                                            break;
                                                        }
                                                        float n10 = liczby4[n9];
                                                        if (n10 < this.minimum)
                                                        {
                                                            this.minimum = n10; //przypisanie do wartosci minimalnej wartosc zmiennej n10
                                                        }
                                                        n9++;
                                                    }
                                                    break;
                                                }
                                                float n8 = liczby3[n7];
                                                n2 += (n8 - this.odz) * (n8 - this.odz);
                                                n7++;
                                            }
                                            break;
                                        }
                                        float n6 = liczby2[n5];
                                        this.odz += n6;
                                        n5++;
                                    }
                                    break;
                                }
                                this.liczby[n4] = liczby[n4];
                                n4++;
                            }
                            break;
                        }
                        string d = tekst[n3];
                        if (float.TryParse(d, out liczby[a]))
                        {
                            a++;
                        }
                        n3++;
                    }

                }
            }

        }


        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        //Zapisywanie wartosci obliczonych do pliku
        private void button3_zapisz_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter wypisz = new StreamWriter(this.saveFileDialog1.FileName))
                    {
                        wypisz.WriteLine("Wartość średnia wynosi: " + this.textBox2.Text);
                        wypisz.WriteLine("Wariancja wynosi: " + this.textBox3.Text);
                        wypisz.WriteLine("Wartość minimalna wynosi: " + this.textBox4.Text);
                        wypisz.WriteLine("Wartość maksymalnawynosi: " + this.textBox5.Text);
                    }

                    DialogResult rezultat = MessageBox.Show("Plik zawierajacy obliczenia zostal zapisany", "Informacja o zapisie", MessageBoxButtons.OK);
                }
                catch
                {
                    DialogResult rezultat2 = MessageBox.Show("Uwaga, plik z obliczeniami nie zostal zapisany", "Bład zapisu", MessageBoxButtons.OK);
                }
            }
        }
        // Przechodznie do wykresu
        private void button2_wykres_Click(object sender, EventArgs e)
        {
            this.wykres.ShowDialog();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        //Generowanie nowych probek i ich zapis
        private void button4_generowanie_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            if (this.saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter zapiszz = new StreamWriter(this.saveFileDialog2.FileName))
                    {
                        int n = 0;
                        while (true)
                        {
                            if (n >= ((int)this.probki.Value))
                            {
                                break;
                            }
                            double n2 = ((this.maksimum - this.minimum) * random.NextDouble()) + this.minimum;
                            zapiszz.WriteLine(((float)n2).ToString() + ";");
                            n++;
                        }
                    }

                    DialogResult result = MessageBox.Show("Nowe wartosci probek zostaly zapisane", "Informacja o zapisie", MessageBoxButtons.OK );
                }
                catch
                {
                    DialogResult result2 = MessageBox.Show("Uwaga, plik z nowymi wartosciami probek nie zostal zapisany", "Błąd o zapisie", MessageBoxButtons.OK );
                }
            }
        }
    }
}
