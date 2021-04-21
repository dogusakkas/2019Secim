using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2019Seçim
{
    public partial class frmGrafikler : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source = DOGUSAKKAS; Initial " +
                                                   "Catalog = SECIM2019; Integrated " +
                                                   "Security = True");

        public frmGrafikler()
        {
            InitializeComponent();
        }

        private void frmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut=new SqlCommand("select ILCEAD from TBLILCE",baglanti);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }



            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2=new SqlCommand("select SUM(AKP),SUM(CHP),SUM(IYI)," +
                                             "SUM(DP),SUM(MHP) FROM TBLILCE",baglanti);

            SqlDataReader dr2 = komut2.ExecuteReader();

            while (dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("AKP", dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("CHP", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("IYI", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("DP", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("MHP",dr2[4]);
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut=new SqlCommand("Select * From TBLILCE where ILCEAD=@P1",baglanti);
            komut.Parameters.AddWithValue("@P1",comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                lblakp.Text = (dr[2].ToString());
                lblchp.Text = (dr[3].ToString());
                lbldp.Text = (dr[4].ToString());
                lbliyi.Text = (dr[5].ToString());
                lblmhp.Text = (dr[6].ToString());
            }
            baglanti.Close();

            /*baglanti.Open();
            SqlCommand komut2=new SqlCommand("Select * From TBLILCE",baglanti);
            komut2.Parameters.AddWithValue("@P2",comboBox1.Text);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                pbakptümoylar.Value = int.Parse(dr2[2].ToString());
                pbchptümoylar.Value = int.Parse(dr[3].ToString());
                pbdptümoylar.Value = int.Parse(dr[4].ToString());
                pbiyitümoylar.Value = int.Parse(dr2[5].ToString());
                pbmhptümoylar.Value = int.Parse(dr2[6].ToString());
            }
            baglanti.Close();*/

        }
    }
}
