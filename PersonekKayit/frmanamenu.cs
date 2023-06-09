﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PersonekKayit
{
    public partial class frmanamenu : Form
    {
        public frmanamenu()
        {
            InitializeComponent();
        }
        SqlConnection baglanti=new SqlConnection("Data Source = DESKTOP-GLOA13K; Initial Catalog = PersonelVeriTabani; Integrated Security = True");
        void temizle()
        {
            txtPersonelid.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            cmbSehir.Text = "";
            mskdMaas.Text = "";
            radioButton1.Checked =false;
            radioButton2.Checked =false;
            txtMeslek.Text = "";

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (perad,persoyad,persehir,permaas,permeslek,perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbSehir.Text);
            komut.Parameters.AddWithValue("@p4",mskdMaas.Text);
            komut.Parameters.AddWithValue("@p5",txtMeslek.Text);
            komut.Parameters.AddWithValue("@p6",label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            if(radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("delete from tbl_personel where perid=@s1",baglanti);
            komutsil.Parameters.AddWithValue("@s1", txtPersonelid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt silindi");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen= dataGridView1.SelectedCells[0].RowIndex;

            txtPersonelid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text= dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text=dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskdMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutgncl=new SqlCommand("update tbl_personel set perad=@g1,persoyad=@g2,persehir=@g3,permaas=@g4,perdurum=@g5,permeslek=@g6 where perid=@g7",baglanti);
            komutgncl.Parameters.AddWithValue("@g1", txtAd.Text);
            komutgncl.Parameters.AddWithValue("@g2", txtSoyad.Text);
            komutgncl.Parameters.AddWithValue("@g3", cmbSehir.Text);
            komutgncl.Parameters.AddWithValue("@g4", mskdMaas.Text);
            komutgncl.Parameters.AddWithValue("@g5", label8.Text);
            komutgncl.Parameters.AddWithValue("@g6", txtMeslek.Text);
            komutgncl.Parameters.AddWithValue("@g7", txtPersonelid.Text);
            komutgncl.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel kayıt güncellendi");

        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Frmistatistik frm=new Frmistatistik();
            frm.Show();
        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
           FrmGrafikler frm=new FrmGrafikler();
            frm.Show();
        }
    }
}