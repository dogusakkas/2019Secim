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
    public partial class frmSecim2019 : Form
    {

        SqlConnection baglanti=new SqlConnection("Data Source = DOGUSAKKAS; Initial " + 
                                                 "Catalog = SECIM2019; Integrated " +
                                                 "Security = True");

        public frmSecim2019()
        {
            InitializeComponent();
        }

        private void btnoygiriş_Click(object sender, EventArgs e)
        {
            if (txtilçead.Text != "" && txtakp.Text !="" && txtchp.Text !="" && 
                txtdp.Text !="" && txtiyi.Text !="" && txtmhp.Text !="")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into TBLILCE " +
                                                  "(ILCEAD,AKP,CHP,IYI,DP,MHP) " +
                                                  "values(@P1,@P2,@P3,@P4,@P5,@P6)", baglanti);

                komut.Parameters.AddWithValue("@P1", txtilçead.Text);
                komut.Parameters.AddWithValue("@P2", txtakp.Text);
                komut.Parameters.AddWithValue("@P3", txtchp.Text);
                komut.Parameters.AddWithValue("@P4", txtiyi.Text);
                komut.Parameters.AddWithValue("@P5", txtdp.Text);
                komut.Parameters.AddWithValue("@P6", txtmhp.Text);

                komut.ExecuteNonQuery();
                MessageBox.Show("Oylar Girildi.");

                baglanti.Close();
                
            }

            else
            {
                MessageBox.Show("Satırlar Boş Olamaz !");
            }
                
            }
            
        

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            frmGrafikler frm=new frmGrafikler();
            frm.Show();
            this.Hide();
        }
    }
}
