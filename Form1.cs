using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "0";
            toolStripTextBox2.Text = "0";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        public void AddStudent(string masv, string name, string gender, string diemTB, string khoa)
        {
            int index = dataGridView1.Rows.Count;
            dataGridView1.Rows.Add(index, masv, name, gender, diemTB, khoa);
            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (gender == "Nam")
            {
                toolStripTextBox1.Text = (int.Parse(toolStripTextBox1.Text) + 1).ToString();
            }
            else if (gender == "Nữ")
            {
                toolStripTextBox2.Text = (int.Parse(toolStripTextBox2.Text) + 1).ToString();
            }
        }

        public void UpdateStudent(string masv, string name, string gender, string diemTB, string khoa)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == masv)
                {
                    string oldGender = row.Cells[3].Value.ToString();
                    row.Cells[2].Value = name;
                    row.Cells[3].Value = gender;
                    row.Cells[4].Value = diemTB;
                    row.Cells[5].Value = khoa;

                    if(oldGender != gender)
                    {
                        if (oldGender == "Nam")
                        {
                            toolStripTextBox1.Text = (int.Parse(toolStripTextBox1.Text) - 1).ToString();
                        }
                        else if (oldGender == "Nữ")
                        {
                            toolStripTextBox2.Text = (int.Parse(toolStripTextBox2.Text) - 1).ToString();
                        }
                        if(gender== "Nam")
                        {
                            toolStripTextBox1.Text = (int.Parse(toolStripTextBox1.Text) + 1).ToString();
                        }else if (gender== "Nữ")
                        {
                            toolStripTextBox2.Text = (int.Parse(toolStripTextBox2.Text) + 1).ToString();
                        }
                    }
                    MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } MessageBox.Show("Mã số sinh viên không tồn tài!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void toolStripTextBox3_Click(object sender, EventArgs e)
        {

        }
        // Tìm kiếm sinh viên theo tên sinh viên
        private void toolStripTextBox3_TextChanged(object sender, EventArgs e)
        {
            string searchItem = toolStripTextBox3.Text.ToLower();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells[2].Value != null && row.Cells[2].Value.ToString().ToLower().Contains(searchItem))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }


        public void ShowStudentGrades()
        {
            int xuatSac = 0;
            int gioi = 0;
            int kha = 0;
            int trungBinh = 0;
            int yeu = 0;
            int kem = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    if (decimal.TryParse(row.Cells[4].Value.ToString(), out decimal diemTB))
                    {
                        if (diemTB >= 9.0m && diemTB <= 10.0m)
                        {
                            xuatSac++;
                        }
                        else if (diemTB >= 8.0m && diemTB < 9.0m)
                        {
                            gioi++;
                        }
                        else if (diemTB >= 7.0m && diemTB < 8.0m)
                        {
                            kha++;
                        }
                        else if (diemTB >= 5.0m && diemTB < 7.0m)
                        {
                            trungBinh++;
                        }
                        else if (diemTB >= 4.0m && diemTB < 5.0m)
                        {
                            yeu++;
                        }
                        else if (diemTB < 4.0m)
                        {
                            kem++;
                        }
                    }
                }
            }

            string message = $"Xuất sắc: {xuatSac}\n" +
                             $"Giỏi: {gioi}\n" +
                             $"Khá: {kha}\n" +
                             $"Trung bình: {trungBinh}\n" +
                             $"Yếu: {yeu}\n" +
                             $"Kém: {kem}";

            MessageBox.Show(message, "Thống kê xếp loại", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ShowStudentGrades();
        }
    }
}
