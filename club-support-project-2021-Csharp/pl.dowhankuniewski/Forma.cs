using club_support_project_2021_Csharp.pl.dowhankuniewski.mapa;
using club_support_project_2021_Csharp.pl.dowhankuniewski.stworzliste;
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
using rtChart;

namespace club_support_project_2021_Csharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
        }

        string dateFile = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

        

        private void button1_Click(object sender, EventArgs e)
        {
            Start.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
            //backgroundWorker2.RunWorkerAsync();
            
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            rozmiarMapy.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = true;
            iloscCzlonkow.Enabled = true;
            iloscCzlonkow.Maximum = (rozmiarMapy.Value*rozmiarMapy.Value) /2;
            predkosc.Maximum = rozmiarMapy.Value / 4;
            iloscPol.Maximum = rozmiarMapy.Value * rozmiarMapy.Value;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            iloscCzlonkow.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = true;
            predkosc.Enabled = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            predkosc.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = true;
            iloscPol.Enabled = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            iloscPol.Enabled = false;
            checkBox4.Enabled = false;
            checkBox5.Enabled = true;
            iloscIteracji.Enabled = true;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            iloscIteracji.Enabled = false;
            checkBox5.Enabled = false;
            Start.Enabled = true;
            progressBar1.Maximum = (int)iloscIteracji.Value;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start($"LOGS_{dateFile}.txt");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            kayChart kmw = new kayChart(chart1, (int)iloscIteracji.Value);
            kayChart kmp = new kayChart(chart1, (int)iloscIteracji.Value);
            kmw.serieName = "KMW";
            kmp.serieName = "KMP";

            BackgroundWorker worker = sender as BackgroundWorker;

            Mapa mapa = new Mapa((int)rozmiarMapy.Value);
            StworzListePole stworzListePole = new StworzListePole((int)iloscPol.Value);
            StworzListeCzlonek stworzListeCzlonek = new StworzListeCzlonek((int)iloscCzlonkow.Value);

            Symulacja symulacja = new Symulacja(mapa, stworzListeCzlonek, stworzListePole, (int)iloscIteracji.Value, (int)predkosc.Value);
     
            symulacja.sprawdzCechySpecjalne();
            for (int iter = 1; iter < symulacja.maxIter + 1; iter++)
            {
                symulacja.wykonajRuch();
                symulacja.sprawdzWejscieNaPole();
                symulacja.sprawdzSpotkanieCzlonkow();
                symulacja.zapisLogowDoPliku(iter, dateFile);
                kmw.TriggeredUpdate(symulacja.KMWData());
                kmp.TriggeredUpdate(symulacja.KMPData());
                worker.ReportProgress(iter * 100 / symulacja.maxIter);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage * (int)iloscIteracji.Value / 100;
            label6.Text = (e.ProgressPercentage.ToString() + "%");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            linkLabel1.Enabled = true;
            linkLabel1.Visible = true;
        }
    }
}
