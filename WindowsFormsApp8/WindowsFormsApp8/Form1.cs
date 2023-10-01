using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //// ulozeni hry (souboru.txt)
            //SaveFileDialog dialog = new SaveFileDialog();
            //dialog.DefaultExt = ".txt";
            //dialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    //StreamWriter zapisovac = new StreamWriter(dialog.FileName);
            //    //zapisovac.WriteLine("Ahoj!");


            //    //zapisovac.Close();
            //}
            StreamReader sr = null;
            try
            {
                int n = Convert.ToInt32(textBox1.Text);
                sr = new StreamReader("cisla.txt");
                int patecislo = 0;
                int umocneni = 0;
                for(int i = 0;i != 5; i++)
                {
                    patecislo = Convert.ToInt32(sr.ReadLine());
                }
                umocneni = patecislo;
                label5.Text = "Páté číslo: " +patecislo.ToString();
                
                if (n == 0)
                {
                    umocneni = 1;
                }
                else if (n > 0)
                {
                    for (int x = n; x != 1; x--)
                    {
                        umocneni = umocneni * patecislo;
                    }
                }
                label1.Text = "Umocnění: " + umocneni;
                double podil = 0;
                try {
                    podil = patecislo % n;

                }catch(DivideByZeroException ex)
                {
                    MessageBox.Show(ex.Message);
                }catch(FileNotFoundException ex) { MessageBox.Show(ex.Message); }

                label2.Text = "Podíl: " + podil;

                double soucet = 0;
                try
                {
                    sr.DiscardBufferedData();
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);
                    while (!sr.EndOfStream) { soucet += Convert.ToInt32(sr.ReadLine()); }
                }
                catch(OverflowException ex) { MessageBox.Show("Pretecenipri souctu" + ex.Message); }
                catch(ArithmeticException ex) { MessageBox.Show(ex.Message); }
                label3.Text = "Součet: " + soucet;

            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(OverflowException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(sr!=null)sr.Close();
            }
        }
    }
}
