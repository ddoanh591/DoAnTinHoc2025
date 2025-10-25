using System.Text;
using System.Data;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;


namespace DoAnTinHoc_DuLieuLuongNhanVien
{
    public partial class Form1 : Form
    {
        XuLyCSV xl = new XuLyCSV();
        string filecsv = "Employers_data.csv";
        List<NhanVien> dsNV = new List<NhanVien>();
        public Form1()
        {
            InitializeComponent();
        }

   
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(filecsv))
                {
                    MessageBox.Show("File CSV không tồn tại!");
                    return;
                }

                dsNV = xl.DocFileCSV(filecsv);
                dataGridView1.DataSource = dsNV;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file CSV: " + ex.Message);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            {
                try
                {
                    if (dataGridView1.DataSource == null)
                    {
                        MessageBox.Show("Không có dữ liệu để ghi!");
                        return;
                    }

                    dsNV = (List<NhanVien>)dataGridView1.DataSource;
                    xl.GhiFile(filecsv, dsNV);
                    MessageBox.Show("✅ Đã ghi lại file CSV thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Lỗi khi ghi file CSV: " + ex.Message);
                }
            }

        }
    }
}