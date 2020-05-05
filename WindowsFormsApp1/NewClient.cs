using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DAL;
using WindowsFormsApp1.Model.Context;
using WindowsFormsApp1.Model.Entity;

namespace WindowsFormsApp1
{
    public partial class NewClient : Form
    {
        int mov;
        int movX;
        int movY;
        public NewClient()
        {
            InitializeComponent();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelBanner_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panelBanner_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panelBanner_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public void FillGrid() 
        {
            OtoContext otoContext = new OtoContext();
            object query2 = (from cari in otoContext.Cari
                             select new
                             {
                                 cariID = cari.cariID,
                                 cariad = cari.ad,
                                 carisoyad = cari.soyad,
                                 carimail = cari.email,
                                 caritel = cari.tel,
                                 cariadresdetay = cari.adresdetay,
                                 cariil=cari.ilAdi,
                                 cariilce = cari.ilceAdi,
                                 carirol = cari.rolAdi
                             }).ToList();
            dataGridView1.DataSource = query2;
        }
        private void NewClient_Load(object sender, EventArgs e)
        {
            var cariIl= new GenericRepository<Il>(new OtoContext());
            comboBoxIl.DataSource = cariIl.GetAll().ToList();
            comboBoxIl.DisplayMember = "IlId";
            comboBoxIl.ValueMember = "IlAdi";
           
            
            var cariRol = new GenericRepository<Rol>(new OtoContext());
            comboBoxRol.DataSource = cariRol.GetAll().ToList();
            comboBoxRol.DisplayMember = "Rol";
            comboBoxRol.ValueMember = "RolAdi";
            /*var cariIlce = new GenericRepository<Ilce>(new OtoContext());
            comboBoxIlce.DataSource = cariIlce.GetAll().ToList();
            comboBoxIlce.DisplayMember = "Ilce";
            comboBoxIlce.ValueMember = "IlceAdi";*/
            dataGridView1.ForeColor = Color.Black;
            
            
        }
        List<Ilce> IlceGetir(int id)
        {
            
            var cariIlce1 = new GenericRepository<Ilce>(new OtoContext());
            return cariIlce1.GetAll().Where(i => i.Ilid == id).ToList();
        }
        private void comboBoxIl_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBoxIlce.DataSource = null;
            int ilid = comboBoxIl.SelectedIndex + 1;
            comboBoxIlce.DataSource = IlceGetir(ilid);
            comboBoxIlce.DisplayMember = "IlceAdi";
            comboBoxIlce.ValueMember = "IlceAdi";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBoxAd.TextLength < 1)
            {
                MessageBox.Show("Lütfen geçerli bir isim giriniz");
                textBoxAd.Focus();
            }
            if (textBoxMail.TextLength < 1)
            {
                MessageBox.Show("Lütfen geçerli bir mail giriniz");
                textBoxMail.Focus();
            }
            if (textBoxSoyad.TextLength < 1)
            {
                MessageBox.Show("Lütfen geçerli bir soyisim giriniz");
                textBoxSoyad.Focus();
            }
            if (textBoxTelefon.TextLength < 1)
            {
                MessageBox.Show("Lütfen geçerli bir telefon giriniz");
                textBoxTelefon.Focus();
            }
            else { 
            var genericRepository = new GenericRepository<Cari>(new OtoContext());
            string isim = textBoxAd.Text;
            string soyisim = textBoxSoyad.Text;
            string email = textBoxMail.Text;
            string tel = textBoxTelefon.Text;
            string adres = textBoxAdresdetay.Text;
            string il = comboBoxIl.SelectedValue.ToString();
            string ilce = comboBoxIlce.SelectedValue.ToString();
            string rol = comboBoxRol.SelectedValue.ToString();
            genericRepository.Create(new Cari()
            {
                ad=isim,
                soyad=soyisim,
                email=email,
                tel=tel,
                adresdetay=adres,
                ilAdi=il,
                ilceAdi=ilce,
                rolAdi=rol

            });
            FillGrid();
            }
        }
        public int indexRow;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            labelCarino.Text = row.Cells[0].Value.ToString();
            textBoxAd.Text = row.Cells[1].Value.ToString();
            textBoxSoyad.Text = row.Cells[2].Value.ToString();
            textBoxMail.Text = row.Cells[3].Value.ToString();
            textBoxTelefon.Text = row.Cells[4].Value.ToString();
            textBoxAdresdetay.Text = row.Cells[5].Value.ToString();
            comboBoxIl.SelectedItem = row.Cells[6].Value.ToString();
            comboBoxIlce.SelectedItem = row.Cells[7].Value.ToString();
            comboBoxRol.SelectedItem = row.Cells[8].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var upCari = new GenericRepository<Cari>(new OtoContext());
            upCari.Update(new Cari()
            {
                cariID = Convert.ToInt32(labelCarino.Text),
                ad = textBoxAd.Text,
                soyad = textBoxSoyad.Text,
                email = textBoxMail.Text,
                tel = textBoxTelefon.Text,
                adresdetay = textBoxAdresdetay.Text,
                ilAdi=comboBoxIl.SelectedValue.ToString(),
                ilceAdi = comboBoxIlce.SelectedValue.ToString(),
                rolAdi = comboBoxRol.SelectedValue.ToString()
            }, int.Parse(labelCarino.Text));
            FillGrid();
        }
        int Carino;
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (row > -1)
                {
                    dataGridView1.Rows[row].Selected = true;//bu tıkladığımız alanı seçtiriyoruz
                    Carino = int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
                }
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var delCari = new GenericRepository<Cari>(new OtoContext());
            Cari cari = delCari.GetById(Carino);
            delCari.Delete(cari);
            FillGrid();
        }
    }
}
