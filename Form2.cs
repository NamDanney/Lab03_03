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
    public partial class Form2 : Form
    {
        private Form1 mainForm;
        public Form2()
        {
            InitializeComponent();
            mainForm = (Form1)Application.OpenForms["Form1"];
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "Công nghệ thông tin";
            radioButton2.Checked = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string masv = textBox1.Text;
            string name = textBox2.Text;
            string gender = radioButton1.Checked ? "Nam" : "Nữ";
            Decimal diemTB;
            string khoa = comboBox1.SelectedItem.ToString();

            if (string.IsNullOrEmpty(masv) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (masv.Length != 10 || !long.TryParse(masv, out _))
            {
                MessageBox.Show("Mã số sinh viên không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (name.Length < 3 || name.Length > 100 || name.Any(c => !char.IsLetter(c) && c != ' '))
            {
                MessageBox.Show("Họ tên không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Decimal.TryParse(textBox3.Text, out diemTB) || diemTB < 0 || diemTB > 10)
            {
                MessageBox.Show("Điểm trung bình không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mainForm.AddStudent(masv, name, gender, diemTB.ToString("0.0"), khoa);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string masv = textBox1.Text;
            string name = textBox2.Text;
            string gender = radioButton1.Checked ? "Nam" : "Nữ";
            Decimal diemTB;
            string khoa = comboBox1.SelectedItem.ToString();

            if (string.IsNullOrEmpty(masv) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (masv.Length != 10 || !long.TryParse(masv, out _))
            {
                MessageBox.Show("Mã số sinh viên không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (name.Length < 3 || name.Length > 100 || name.Any(c => !char.IsLetter(c) && c != ' '))
            {
                MessageBox.Show("Họ tên không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Decimal.TryParse(textBox3.Text, out diemTB) || diemTB < 0 || diemTB > 10)
            {
                MessageBox.Show("Điểm trung bình không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mainForm.UpdateStudent(masv, name, gender, diemTB.ToString("0.0"), khoa);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
