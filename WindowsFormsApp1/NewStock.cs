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
    public partial class NewStock : Form
    {
        int mov;
        int movX;
        int movY;
        public NewStock()
        {
            InitializeComponent();
        }

        private void panelBanner_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panelBanner_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panelBanner_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;

        }
        public void FillGrid()
        {
            OtoContext otoContext = new OtoContext();
            object query2 = (from stok in otoContext.Stok
                             join urundetay in otoContext.UrunDetay
                             on stok.UrunDetayId equals urundetay.UrunDetayId
                             select new
                             {
                                 StokID = stok.UrunId,
                                 //UrunMarka = urundetay.UrunMarka,
                                 UrunModel = urundetay.UrunModel,
                                 UrunUretimTarihi = urundetay.UrunUretimTarihi,
                                 Adet = stok.Adet,
                                 Birimi = stok.Birimi,
                             }).ToList();
            dataGridView1.DataSource = query2;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            var grStok = new GenericRepository<Stok>(new OtoContext());
            //int urundetayid = int.Parse(comboBoxUrunmarka.SelectedValue.ToString());//Selected Value olmasına dikkat!
            int urundetayid = int.Parse(comboBoxUrunmodel.SelectedValue.ToString());//Selected Value olmasına dikkat!
            //MessageBox.Show(comboBoxUrunmodel.SelectedValue.ToString());
            
            grStok.Create(new Stok()
            {
                UrunDetayId = urundetayid,
                Birimi = comboBoxBirim.Text,
                Adet = int.Parse(textBoxAdet.Text)
            });
            
            FillGrid();
            
        }

        private void NewStock_Load(object sender, EventArgs e)
        {
            var grUrunDetay = new GenericRepository<UrunDetay>(new OtoContext());
            /*
            grUrunDetay.Create(new UrunDetay()
            {
                UrunMarka = "Mercedes",
                UrunModel = "Mercedes Ayna",
                UrunUretimTarihi = DateTime.Now
            });
            grUrunDetay.Create(new UrunDetay()
            {
                UrunMarka = "Mercedes",
                UrunModel = "Mercedes boya",
                UrunUretimTarihi = DateTime.Now
            });
            */
            /*
            comboBoxUrunmarka.DataSource = grUrunDetay.GetAll().Where(i=>i.UrunDetayId==).ToList();
            comboBoxUrunmarka.DisplayMember = "UrunMarka";
            comboBoxUrunmarka.ValueMember = "UrunDetayId";
            */
            comboBoxUrunmodel.DataSource = grUrunDetay.GetAll().ToList();
            comboBoxUrunmodel.DisplayMember = "UrunModel";
            comboBoxUrunmodel.ValueMember = "UrunDetayId";

            comboBoxBirim.Items.Add("Adet");
            comboBoxBirim.Items.Add("Kg");
            FillGrid();

        }
        int indexRow;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            //Cells[1] 1 ile başlıyor çünkü 0 da primary key olan Servis No var
            textBoxUrunid.Text = row.Cells[0].Value.ToString();
            string Durum = row.Cells[1].Value.ToString();
            comboBoxUrunmodel.SelectedIndex = comboBoxUrunmodel.FindStringExact(Durum);
            DateTime UretimTarihi = DateTime.Parse(row.Cells[2].Value.ToString());
            dateTimePickerUretimtarihi.Value = UretimTarihi;
            textBoxAdet.Text = row.Cells[3].Value.ToString();
            string Birim = row.Cells[4].Value.ToString();
            comboBoxBirim.SelectedIndex = comboBoxBirim.FindStringExact(Birim);     
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var grStok = new GenericRepository<Stok>(new OtoContext());
            grStok.Update(new Stok()
            {
                UrunId = int.Parse(textBoxUrunid.Text),
                UrunDetayId = int.Parse(comboBoxUrunmodel.SelectedValue.ToString()),
                Adet = int.Parse(textBoxAdet.Text),
                Birimi = comboBoxBirim.Text,
            }, int.Parse(textBoxUrunid.Text));
            var grUrundetay = new GenericRepository<UrunDetay>(new OtoContext());
            grUrundetay.Update(new UrunDetay()
            {
                UrunDetayId = int.Parse(comboBoxUrunmodel.SelectedValue.ToString()),
                UrunModel = comboBoxUrunmodel.Text,
                UrunUretimTarihi = dateTimePickerUretimtarihi.Value
            }, int.Parse(comboBoxUrunmodel.SelectedValue.ToString()));
            FillGrid();
        }
        int UrunId;
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (row > -1)
                {
                    dataGridView1.Rows[row].Selected = true;//bu tıkladığımız alanı seçtiriyoruz
                    UrunId = int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
                }
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var gRUrun = new GenericRepository<Stok>(new OtoContext());
            Stok urun = gRUrun.GetById(UrunId);
            gRUrun.Delete(urun);
            FillGrid();
        }
    }
}
