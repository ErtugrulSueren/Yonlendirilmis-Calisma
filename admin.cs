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

namespace WindowsFormsApplication1
{
    public partial class admin : Form
    {
        SqlConnection bagla = new SqlConnection("Data Source=PC-BILGISAYAR\\ERTU;Initial Catalog=Kullanıcı;Integrated Security=True");
        SqlCommand sil = new SqlCommand();
        public admin()
        {
            InitializeComponent();

            verilerigörüntüle();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kayit kyt = new kayit();
            kyt.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bagla.Open();
            sil.CommandText = "DELETE FROM dbo.giris WHERE Ad='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
            sil.Connection = bagla;
            sil.ExecuteNonQuery();
            verilerigörüntüle();
            bagla.Close();
        }
        private void verilerigörüntüle()
        {
            SqlCommand komut = new SqlCommand("SELECT * From dbo.giris ", bagla);

            komut.Connection = bagla;

            SqlDataAdapter adap = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();

            adap.Fill(tablo);

            dataGridView1.DataSource = tablo;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            verilerigörüntüle();
        }
    }
}
