using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BorsaKazançHesaplama_orj
{
    public partial class BorsaKazançHesaplama : Form
    {
        public BorsaKazançHesaplama()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BorsaKazançHesaplama_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool isAnyTextBoxEmpty = false;
                if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty ||
                    textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty)
                {
                    isAnyTextBoxEmpty = true;
                }

                if (isAnyTextBoxEmpty)
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz!");
                }
                else
                {
                    // ListBox'ı temizle
                    listBox1.Items.Clear();
                    // Kullanıcıdan girilen verileri alalım
                    double hısse_fıyat = double.Parse(textBox1.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                    double artıs_mıktarı = double.Parse(textBox2.Text.Replace(",", "."), CultureInfo.InvariantCulture) / 100;
                    int gün = int.Parse(textBox3.Text);
                    double lot = double.Parse(textBox4.Text);
                    double hısse_fıyatal = hısse_fıyat;

                    for (int i = 0; i < gün; i++)
                    {
                        double hısse_fıyat2 = (hısse_fıyat * artıs_mıktarı);
                        hısse_fıyat += hısse_fıyat2;

                        listBox1.Items.Add($"Gün {i + 1} .Kazancın: {hısse_fıyat} ₺ ");
                    }

                    double net_kazanc = lot * hısse_fıyat;
                    label10.Text = $"  {net_kazanc:C} ₺ ";
                    double lot2 = net_kazanc - (hısse_fıyatal * lot);
                    label11.Text = $" {lot2} ₺ ";
                     
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen geçerli bir sayı girin!");
            }








        }

        private void button2_Click(object sender, EventArgs e)
        {
            var controlsToClear = new Control[] { textBox1, textBox2, textBox3, textBox4,  };
            foreach (var control in controlsToClear)
            {
                control.ResetText();

            }
                listBox1.Items.Clear();

            label10.Text = label11.Text = "0 ₺";

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
