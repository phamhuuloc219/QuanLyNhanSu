using System;
using System.Windows.Forms;
using Nhom3_QuanLyNhanSu.Models;

namespace Nhom3_QuanLyNhanSu
{
    public partial class FrmThanNhan : Form
    {
        public delegate void AddNewTN(string HoTen, string GioiTinh, string QuanHe, string NamSinh, string NgheNghiep);
        public delegate void AddNewTNWithId(string Id,string HoTen, string GioiTinh, string QuanHe, string NamSinh, string NgheNghiep);
        public AddNewTN addnew=null;

        public AddNewTNWithId addnewid = null;

        public AddNewTN edit = null;

        private int Loai=0;

        private ThanNhanModel model = null;

        private string MaHS = null;

        public FrmThanNhan()
        {
            InitializeComponent();
            AddDataToComboBox();
            this.Text = "Thêm Thân Nhân";
        }

        public FrmThanNhan(string MaHS)
        {
            InitializeComponent();
            AddDataToComboBox();
            this.Text = "Thêm Thân Nhân";
            Loai = 2;
            model = new ThanNhanModel();
            this.MaHS = MaHS;
        }

        public FrmThanNhan(string MaQHGD, string HoTen, string GioiTinh, string QuanHe, string NamSinh, string NgheNghiep)
        {
            InitializeComponent();
            AddDataToComboBox();
            this.Text = "Sửa Thân Nhân";
            textBox1.Text = HoTen;
            radioButton1.Checked = (GioiTinh.Equals("Nam"));
            radioButton2.Checked = (GioiTinh.Equals("Nữ"));
            textBox2.Text = QuanHe;
            textBox4.Text = NgheNghiep;
            SelectedCbb(NamSinh);
            Loai = 3;
            model = new ThanNhanModel();
            this.MaHS = MaQHGD;
        }

        public FrmThanNhan(string HoTen, string GioiTinh, string QuanHe, string NamSinh, string NgheNghiep)
        {
            InitializeComponent();
            AddDataToComboBox();
            this.Text = "Sửa Thân Nhân";
            textBox1.Text = HoTen;
            radioButton1.Checked = (GioiTinh.Equals("Nam"));
            radioButton2.Checked = (GioiTinh.Equals("Nữ"));
            textBox2.Text = QuanHe;
            textBox4.Text = NgheNghiep;
            SelectedCbb(NamSinh);
            Loai = 1;
        }

        private void SelectedCbb(string namsinh) {
            for (int i = 0; i < comboBox1.Items.Count; i++) {
                if (comboBox1.Items[i].ToString().Equals(namsinh)) {
                    comboBox1.SelectedIndex = i;
                    break;
                }
            }
        }

        private void AddDataToComboBox() {
            int endnam = DateTime.Now.Year - 30;
            int beginnam = endnam - 80;

            for (int i = beginnam; i < endnam; i++)
            {
                comboBox1.Items.Add(i);
            }
            comboBox1.SelectedIndex = comboBox1.Items.Count - 5;

        }

        private Validate validate = new Validate();

        private void FrmThanNhan_Load(object sender, EventArgs e)
        {
            validate.SetTooltip(toolTip1);
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            validate.Check(new ValidateParam(ValidateType.NULL, textBox1.Text, lblIconHoTen, "Vui lòng nhập họ tên"));
            validate.Check(new ValidateParam(ValidateType.NULL, textBox2.Text, lblIconQuanHe, "Vui lòng nhập quan hệ"));
            validate.Check(new ValidateParam(ValidateType.NUMBER, comboBox1.Text, lblIconNamSinh, "Vui lòng chọn năm sinh"));
            if (!validate.Check(lblIconHoTen, lblIconQuanHe, lblIconNamSinh))
            {
                MessageBox.Show("Có lỗi. Không thể lưu");
                return;
            }
            switch(Loai){
                case 0:
                    addnew(validate.formatStringToName(textBox1.Text),radioButton1.Checked?"Nam":"Nữ",validate.formatStringToName(textBox2.Text),comboBox1.Text,validate.formatStringToName(textBox4.Text));
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox4.Text = "";
                    textBox1.Focus();
                    lblIconHoTen.Visible = false;
                    lblIconNamSinh.Visible = false;
                    lblIconQuanHe.Visible = false;
                    break;
                case 1:
                    edit(validate.formatStringToName(textBox1.Text), radioButton1.Checked ? "Nam" : "Nữ", validate.formatStringToName(textBox2.Text), comboBox1.Text, validate.formatStringToName(textBox4.Text));
                    this.Dispose();
                    break;
                case 2:
                    int result=model.Insert(validate.formatStringToName(textBox1.Text), radioButton1.Checked ? "Nam" : "Nữ", validate.formatStringToName(textBox2.Text), comboBox1.Text, validate.formatStringToName(textBox4.Text), MaHS);
                    if (result == -1)
                    {
                        MessageBox.Show("Thân nhân đã tồn tại. Không thể lưu");
                        return;
                    }
                    addnewid(result.ToString(),validate.formatStringToName(textBox1.Text), radioButton1.Checked ? "Nam" : "Nữ", validate.formatStringToName(textBox2.Text), comboBox1.Text, validate.formatStringToName(textBox4.Text));
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox4.Text = "";
                    textBox1.Focus();
                    lblIconHoTen.Visible = false;
                    lblIconNamSinh.Visible = false;
                    lblIconQuanHe.Visible = false;
                    break;
                case 3:
                    if (model.Update(validate.formatStringToName(textBox1.Text), radioButton1.Checked ? 1 : 0, validate.formatStringToName(textBox2.Text), comboBox1.Text, validate.formatStringToName(textBox4.Text), MaHS) > 0)
                    {
                        edit(validate.formatStringToName(textBox1.Text), radioButton1.Checked ? "Nam" : "Nữ", validate.formatStringToName(textBox2.Text), comboBox1.Text, validate.formatStringToName(textBox4.Text));
                        this.Dispose();
                    }
                    else {
                        MessageBox.Show("Có lỗi. Sửa thất bại. Vui lòng thử lại.");
                        return;
                    }
                    break;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            validate.Check(new ValidateParam(ValidateType.NULL,textBox1.Text,lblIconHoTen,"Vui lòng nhập họ tên"));
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            validate.Check(new ValidateParam(ValidateType.NULL,textBox2.Text,lblIconQuanHe,"Vui lòng nhập quan hệ"));
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            validate.Check(new ValidateParam(ValidateType.NUMBER,comboBox1.Text,lblIconNamSinh,"Vui lòng chọn năm sinh"));
        }
    }
}
