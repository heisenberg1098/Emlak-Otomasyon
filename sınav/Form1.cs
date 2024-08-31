using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace sınav
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-GNKKFD3;Database=kiralama_otomasyon;Integrated Security=True;");
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand komut = new SqlCommand(string.Format("select * from ilce where il_id={0}",comboBox1.SelectedIndex+1), baglanti);
            baglanti.Open();
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["ilce_ad"]).ToString();
            }reader.Close();
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
            SqlCommand komut = new SqlCommand("select * from il", baglanti);
            baglanti.Open();
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["il_ad"]).ToString();
            }baglanti.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { string İLCE = " ";
            SqlCommand komutt = new SqlCommand(string.Format("select ilce_id from ilce where ilce_ad='{0}'", comboBox2.Text), baglanti);
            baglanti.Open();
            İLCE = komutt.ExecuteScalar().ToString();
            baglanti.Close();
            string oda="";
            string konum = "";
            if (radioButton1.Checked==true)
            {
                oda = "1+1";
            }else if (radioButton2.Checked==true)
            {
                oda = "2+1";
            }else if (radioButton3.Checked==true)
            {
                oda = "3+1";
            }
            if (checkBox1.Checked == true)
            {
                konum = "markete yakın";
            }
            if (checkBox2.Checked == true)
            {
                konum = "otobüse yakın";
            }
            if (checkBox3.Checked == true)
            {
                konum = "camiye yakın";
            }
            SqlCommand komut = new SqlCommand(String.Format("insert into evler(il_id,ilce_ıd,oda_sayısı,m2,konum) values({0},{1},'{2}','{3}','{4}')",comboBox1.SelectedIndex+1,İLCE,oda,textBox1.Text,konum), baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        void listele()
        {
            SqlCommand komut = new SqlCommand("select * from evler inner join il on il.il_id=evler.il_id inner join ilce on ilce.ilce_id=evler.ilce_ıd", baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            dataGridView1.DataSource = tb;
            baglanti.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand(String.Format("delete from evler where ev_id={0}",textBox2.Text), baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string İLCE = " ";
            SqlCommand komutt = new SqlCommand(string.Format("select ilce_id from ilce where ilce_ad='{0}'", comboBox2.Text), baglanti);
            baglanti.Open();
            İLCE = komutt.ExecuteScalar().ToString();
            baglanti.Close();
            string oda = "";
            string konum = "";
            if (radioButton1.Checked == true)
            {
                oda = "1+1";
            }
            else if (radioButton2.Checked == true)
            {
                oda = "2+1";
            }
            else if (radioButton3.Checked == true)
            {
                oda = "3+1";
            }
            if (checkBox1.Checked == true)
            {
                konum = "markete yakın";
            }
            if (checkBox2.Checked == true)
            {
                konum = "otobüse yakın";
            }
            if (checkBox3.Checked == true)
            {
                konum = "camiye yakın";
            }          
            SqlCommand komut = new SqlCommand(String.Format("update evler set il_id={0},ilce_ıd={1}, oda_sayısı='{2}', m2='{3}' ,konum='{4}' where ev_id={5}", comboBox1.SelectedIndex + 1, İLCE, oda, textBox1.Text, konum,textBox2.Text), baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand(string.Format("select * from evler where m2>{0}",textBox3.Text), baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            dataGridView1.DataSource = tb;
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from evler where konum='markete yakın'", baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            dataGridView1.DataSource = tb;
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from evler where oda_sayısı='1+1'", baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            dataGridView1.DataSource = tb;
            baglanti.Close();
        }
    }
}
