using iTextSharp.text;
using iTextSharp.text.pdf;
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
using WindowsFormsApp1.Model.Entity;

namespace WindowsFormsApp1
{
    public partial class PDF : Form
    {
        public PDF()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Servis> servisListesi = new List<Servis>();

            servisListesi.Add(new Servis()
            {
                AracSaseNo = "12315",
                ServisKayitNo = 12,
                CalisanNo = 1,
                CariId = 1,
                CikisTarihi = DateTime.Now,
                GirisTarihi = DateTime.Now,
                DurumId = 1
            });

            
            Document document = new Document(iTextSharp.text.PageSize.LETTER, 20, 20, 42, 35);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(@"deneme.pdf", FileMode.Create));
            document.Open();
            document.Add(new Paragraph("Servis Kayıt" + "\n" + "----------------------------------------------------------------------------"+"\n"+
                "servis kayit no : " + servisListesi[0].ServisKayitNo.ToString()+"\n"+"Arac şase no : "+
                servisListesi[0].AracSaseNo));
            document.Close();

        }
    }
}
