using System;
using System.Windows.Forms;
using Nhom3_QuanLyNhanSu.Models;
using System.Collections.Generic;
using Nhom3_QuanLyNhanSu.Entities;
using System.Drawing;
using System.Data;

namespace Nhom3_QuanLyNhanSu
{
    public partial class FrmNhanVien : Form
    {

        #region Function
        private infoTab tab = null;
        public ChangeStateButton change;

        private Validate validate = new Validate();

        private bool BeforeInsert = false;


        public void setTab(infoTab tab)
        {
            this.tab = tab;

            this.tab.AddNew = new infoTab.EventButton(Them);
            this.tab.Cancel = new infoTab.EventButton(HuyBo);
            this.tab.Save = new infoTab.EventButton(LuuLai);
            this.tab.Delete = new infoTab.EventButton(Xoa);
            this.tab.Edit = new infoTab.EventButton(Sua);
            this.tab.Refresh = new infoTab.EventButton(CapNhat);
            this.tab.Print = new infoTab.EventButton(In);
            this.tab.callBackChangeData = new EventChangeData(callBackChangeData);
        }

        private void changeStateButton(bool b1, bool b2, bool b3, bool b4, bool b5)
        {
            tab.Them = b1;
            tab.Sua = b2;
            tab.Luu = b3;
            tab.CapNhat = b4;
            tab.In = b5;

            change();
        }

        private void callBackChangeData(int index) {
            switch (index) { 
                case 1:
                    UpdateCbbChucVu();
                    break;
                case 2:
                    UpdateCbbDanToc();
                    break;
                case 3:
                    UpdatecbbLuong();
                    break;
                case 4:
                    UpdateCbbPhongBan();
                    break;
                case 5:
                    UpdatecbbTonGiao();
                    break;
                case 6:
                    UpdatecbbTrinhDo();
                    break;
            }
        }

        private void HiddenIconTextBox()
        {
           
        }

        private void EnableTextBox(bool b)
        {
            foreach (Control ct in groupBox4.Controls) {
                if (ct is ComboBox)
                {
                    ComboBox cb = ct as ComboBox;
                    cb.DropDownStyle = (!b?ComboBoxStyle.Simple:ComboBoxStyle.DropDownList);
                }
                if (ct is Panel) {
                    foreach (Control sub in ct.Controls) {
                        if (sub is RadioButton) {
                            sub.Enabled = b;
                        }
                    }
                }
            }   
        }


        public void ShowEditAnDeleteButton()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (isAdmin)
                {
                    changeStateButton(true, true, false, true, true);
                }
                else {
                    changeStateButton(false, false, false, true, true);
                }
                EnableTextBox(false);
            }
            HiddenIconTextBox();

        }

        private void In()
        {
            List<ReportNhanVien> ldata = new List<ReportNhanVien>();
            int stt = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                ReportNhanVien nv = new ReportNhanVien();
                nv.STT = stt++;
                nv.MaNV = row.Cells[0].Value.ToString();
                nv.Ho = row.Cells[1].Value.ToString();
                nv.Ten = row.Cells[2].Value.ToString();
                nv.GioiTinh = row.Cells[3].Value.ToString().Equals("True") ? "Nam" : "Nữ";
                DateTime ngaysinh=(DateTime)row.Cells[4].Value;
                nv.NgaySinh = (ngaysinh.Day<10?"0":"")+ngaysinh.Day+"/"+(ngaysinh.Month<10?"0":"")+ngaysinh.Month+"/"+ngaysinh.Year;
                nv.SoDT = row.Cells[5].Value.ToString();
                nv.Phong = row.Cells[7].Value.ToString();
                nv.ChucVu = row.Cells[8].Value.ToString();

                ldata.Add(nv);
            }

            string TieuDe = "DANH SÁCH NHÂN VIÊN";

            if (tvPhongBan.SelectedNode != null) {
                if (! tvPhongBan.SelectedNode.Text.Equals("Tất Cả")) {
                    TieuDe += " PHÒNG " + tvPhongBan.SelectedNode.Text.ToUpper();
                }
            }

            if (treeView1.SelectedNode != null)
            {
                if (!treeView1.SelectedNode.Text.Equals("Tất Cả"))
                {
                    TieuDe +=" "+treeView1.SelectedNode.Text.ToUpper();
                }
            }

            new Reports.Frm_Report_NhanVien(ldata, TieuDe).Show();
        }

        private void ShowDetail(DataGridViewRow row)
        {
            if (row != null && (tab != null && (tab.action == ActionForm.KHONG || tab.action==ActionForm.SUA)) || tab == null || BeforeInsert)
            {
                txtMaNV.Text = row.Cells[0].Value.ToString();
                
                    txtHo.Text = row.Cells[1].Value.ToString();
                txtTen.Text = row.Cells[2].Value.ToString();
                bool b=(row.Cells[3].Value.ToString().Equals("True"));
                rdGTNam.Checked = b;
                rdGTNu.Checked = !b;
                dtNgaySInh.Value = (DateTime)row.Cells[4].Value;

                txtNoiSinh.Text = row.Cells[15].Value.ToString();
                cbbDanToc.SelectedValue = row.Cells[19].Value.ToString();
                cbbTonGiao.SelectedValue = row.Cells[20].Value.ToString();
                rtbHoKhau.Text = row.Cells[16].Value.ToString();
                rtbDiaChiLH.Text = row.Cells[17].Value.ToString();
                txtEmail.Text = row.Cells[21].Value.ToString();
                txtSoDT.Text = row.Cells[5].Value.ToString();
                txtNgoaiNgu.Text = row.Cells[22].Value.ToString();
                cbbCMND.Text = row.Cells[18].Value.ToString();
                cbbTrinhDo.SelectedValue = row.Cells[23].Value.ToString();
                cbbPhong.SelectedValue = row.Cells[7].Value.ToString();
                cbbChucVu.SelectedValue = row.Cells[8].Value.ToString();
                cbbLuong.SelectedValue = row.Cells[13].Value.ToString();

                dtNgayVaoLam.Value = (DateTime)row.Cells[9].Value;
                rtbGhiChu.Text = row.Cells[24].Value.ToString();

                string LoaiNV = row.Cells[6].Value.ToString();

                rdLoaiCT.Checked = LoaiNV.Equals("1");
                rdLoaiTV.Checked = LoaiNV.Equals("2");
                rdLoaiBTG.Checked = LoaiNV.Equals("3");
                rdLoaiTT.Checked = LoaiNV.Equals("4");

                string TinhTrang = row.Cells[10].Value.ToString();

                rdTTDL.Checked = TinhTrang.Equals("1");
                rdTTTN.Checked = TinhTrang.Equals("2");
                rdTTDNL.Checked = TinhTrang.Equals("3");

                b = (row.Cells[12].Value.ToString().Equals("True"));

                rdCVAdmin.Checked = b;
                rdCVUser.Checked = !b;

                if (!ChooseAvatar)
                {
                    try
                    {
                        pictureBox1.Image = Image.FromFile("avatars/" + row.Cells[14].Value.ToString() + ".jpg");
                    }
                    catch
                    {
                        pictureBox1.Image = Properties.Resources.noimage;
                    }
                }

                if(tableTN!=null)
                tableTN.DefaultView.RowFilter = "MAHS='"+row.Cells[14].Value.ToString()+"'";
            }
            else
            {
                clearInsert();
            }
        }

        private void clearInsert()
        {
            foreach (Control ct in groupBox4.Controls) {
                if (ct is TextBox || ct is RichTextBox) {
                    ct.Text = "";
                }
                if (ct is ComboBox) {
                    ComboBox cb = ct as ComboBox;
                    if(cb.Items.Count>0)
                        cb.SelectedIndex = 0;
                }
            }
            cbbCMND.Text = "";
            dtNgaySInh.Value = DateTime.Now.AddYears(-18);
            dtNgayVaoLam.Value = DateTime.Now;
        }

        private void EnableButton(bool b) {
            btnThemDT.Enabled = b;
            btnThemTG.Enabled = b;
            btnThemTD.Enabled = b;
            btnThemCV.Enabled = b;
            btnThemPhong.Enabled = b;
            btnThemLuong.Enabled = b;

            btnXemCTCMND.Enabled = isAdmin;
            btnResetPass.Enabled = isAdmin;
            btnThemTN.Enabled = isAdmin;
            btnSuaTN.Enabled = isAdmin;
            btnXoaTN.Enabled = isAdmin;
        }

        private void Them()
        {
            changeStateButton(false, false, true, false, true);
            tab.action = ActionForm.THEM;

            
            EnableTextBox(true);
            try
            {
                tableTN.DefaultView.RowFilter = "MAQHGD=0";
            }
            catch { }
            clearInsert();
            txtMaNV.Focus();
            dataGridView1.Enabled = false;
            EnableButton(true);
            pictureBox1.Image = Properties.Resources.noimage;
        }

        private void HuyBoFull()
        {
            changeStateButton(true, true, false, true, true);
            tab.action = ActionForm.KHONG;

            EnableTextBox(false);


            HiddenIconTextBox();
            BeforeInsert = false;
            txtMaNV.Enabled = true;
            errorProvider1.Clear();
            dataGridView1.Enabled = true;
            EnableButton(false);
        }

        private void HuyBo()
        {
            if (((txtMaNV.Text.Trim() != "" && txtTen.Text.Trim()!="" && txtHo.Text.Trim()!="") || dataGridView2.Rows.Count > 0) && tab.action==ActionForm.THEM)
            {
                if (MessageBox.Show("Bạn có chắc muốn hủy?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
                    return;
                }
            }
            List<DataRow> rowsremove = new List<DataRow>();
            foreach (DataRow row in tableTN.Rows)
            {
                if (row["MAQHGD"].ToString().Equals("0"))
                {
                    rowsremove.Add(row);
                }
            }
            foreach (DataRow row in rowsremove) {
                tableTN.Rows.Remove(row);
            }
            HuyBoFull();
            ShowDetail(dataGridView1.CurrentRow);
            
        }

        private bool ChooseAvatar = false;

        private void LuuLai()
        {
            if (!CheckMa() || !checkEmpty(txtHo) ||
                    !checkEmpty(txtTen) ||
                    !checkEmpty(txtNoiSinh) ||
                    !checkNgaySinh() ||
                    !checkEmail() ||
                    !checkSoDT())
            {
                MessageBox.Show("Có lỗi không thể lưu");
                return;
            }



            BeforeInsert = true;

            int LoaiNhanVien = 0;
            if (rdLoaiCT.Checked)
                LoaiNhanVien = 1;
            if (rdLoaiTV.Checked)
                LoaiNhanVien = 2;
            if (rdLoaiBTG.Checked)
                LoaiNhanVien = 3;
            if (rdLoaiTT.Checked)
                LoaiNhanVien = 4;

            int TinhTrangNV = 0;
            if (rdTTDL.Checked)
                TinhTrangNV = 1;
            if (rdTTTN.Checked)
                TinhTrangNV = 2;
            if (rdTTDNL.Checked)
                TinhTrangNV = 3;
            switch (tab.action)
            {
                case ActionForm.THEM:
                    
                    string MaHS=model.insertNV(new NhanVien()
                    {
                        MaNV = txtMaNV.Text.Trim().ToUpper(),
                        Ho = validate.formatStringToName(txtHo.Text),
                        Ten = validate.formatStringToName(txtTen.Text),
                        GioiTinh = rdGTNam.Checked,
                        NgaySinh = dtNgaySInh.Value,
                        NoiSinh = validate.formatStringToName(txtNoiSinh.Text),
                        DanToc = int.Parse(((DataItem)cbbDanToc.SelectedItem).Value),
                                                  TonGiao = int.Parse(((DataItem)cbbTonGiao.SelectedItem).Value),HoKhau=rtbHoKhau.Text.Trim(),DiaChiLH=rtbDiaChiLH.Text.Trim(),Email=txtEmail.Text.Trim(),
                                                  SoDT=txtSoDT.Text.Trim(),NgoaiNgu=txtNgoaiNgu.Text.Trim(),CMND=cbbCMND.Text,
                                                  TrinhDo = int.Parse(((DataItem)cbbTrinhDo.SelectedItem).Value),Phong=((DataItem)cbbPhong.SelectedItem).Value,
                                                  ChucVu = ((DataItem)cbbChucVu.SelectedItem).Value,LoaiNV=LoaiNhanVien,TinhTrang=TinhTrangNV,
                                                  LaAdmin = rdCVAdmin.Checked,
                                                  BacLuong = int.Parse(((DataItem)cbbLuong.SelectedItem).Value),
                                                  NgayVaoLam=dtNgayVaoLam.Value,
                                                  GhiChu=rtbGhiChu.Text.Trim()
                    });

                    if (MaHS != "")
                    {
                        foreach (DataRow row in tableTN.Rows)
                        {
                            if (row["MAQHGD"].ToString().Equals("0"))
                            {
                                string ma = model.insertTN(row["HOTEN"].ToString(), row["GIOI_TINH"].ToString().Equals("Nam"), row["QUAN_HE"].ToString(), row["NAM_SINH"].ToString(), row["NGHE_NGHIEP"].ToString(), MaHS);
                               
                                row["MAQHGD"] = ma;
                                row["MAHS"] = MaHS;
                            }
                        }

                        if (pictureBox1.Image != null && ChooseAvatar)
                        {
                            try
                            {
                                pictureBox1.Image.Save("avatars/" + MaHS + ".jpg");
                            }
                            catch {
                                pictureBox1.Image = Properties.Resources.noimage;
                            }
                        }
                    }
                    ChooseAvatar = false;
                    HuyBoFull();
                    break;
                case ActionForm.SUA:
                    model.update(new NhanVien()
                    {
                        MaNV = txtMaNV.Text,
                        Ho = validate.formatStringToName(txtHo.Text),
                        Ten = validate.formatStringToName(txtTen.Text),
                        GioiTinh = rdGTNam.Checked,
                        NgaySinh = dtNgaySInh.Value,
                        NoiSinh = validate.formatStringToName(txtNoiSinh.Text),
                        DanToc = int.Parse(((DataItem)cbbDanToc.SelectedItem).Value),
                        TonGiao = int.Parse(((DataItem)cbbTonGiao.SelectedItem).Value),
                        HoKhau = rtbHoKhau.Text.Trim(),
                        DiaChiLH = rtbDiaChiLH.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        SoDT = txtSoDT.Text.Trim(),
                        NgoaiNgu = txtNgoaiNgu.Text.Trim(),
                        TrinhDo = int.Parse(((DataItem)cbbTrinhDo.SelectedItem).Value),
                        Phong = ((DataItem)cbbPhong.SelectedItem).Value,
                        ChucVu = ((DataItem)cbbChucVu.SelectedItem).Value,
                        LoaiNV = LoaiNhanVien,
                        TinhTrang = TinhTrangNV,
                        LaAdmin = rdCVAdmin.Checked,
                        BacLuong = int.Parse(((DataItem)cbbLuong.SelectedItem).Value),
                        NgayVaoLam = dtNgayVaoLam.Value,
                        GhiChu = rtbGhiChu.Text.Trim(),
                        MaHS=dataGridView1.CurrentRow.Cells[14].Value.ToString()
                    });
                    HuyBoFull();
                    break;
            }
        }

        private void Sua()
        {
            changeStateButton(false, false, true, false, true);
            tab.action = ActionForm.SUA;

            EnableTextBox(true);
            txtHo.Focus();
            txtMaNV.Enabled = false;
            EnableButton(true);
        }

        private void Xoa()
        {
            if (tab.action == ActionForm.KHONG)
            {
                if (txtMaNV.Text.Equals(NVLG.MaNVLG)) {
                    MessageBox.Show("Bạn không thể xóa chính mình.");
                    return;
                }
                model.delete();
            }
        }

        private void CapNhat()
        {
            if (tab.action == ActionForm.KHONG)
            {
                model.getAllData();
                ShowDetail(dataGridView1.CurrentRow);
            }
        }

        

        #endregion

        private NhanVienModel model = null;

        private DataTable tableTN = null;

        private DataTable tableNV = null;

        private bool isAdmin;

        public FrmNhanVien(bool isAdmin)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
        }

        private void HiddenColumnGridView() {
            for (int i = 9; i < dataGridView1.Columns.Count; i++) {
                dataGridView1.Columns[i].Visible = false;
            }
        }

        private void LoadDataToCombobox(ComboBox cbb,string query) {
            cbb.DataSource = model.getList(query);
            cbb.ValueMember = "Value";
            cbb.DisplayMember = "Name";
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            model = new NhanVienModel();
            model.setControl(dataGridView1, lblMessage);

            TreeNode nodefirst = new TreeNode("Tất Cả");
            nodefirst.Tag = "0";

            tvPhongBan.Nodes.Add(nodefirst);
            nodefirst = new TreeNode("Tất Cả");
            nodefirst.Tag = "0";
            tvChucVu.Nodes.Add(nodefirst);

            List<DataItem> lpb = model.getList("select MAPB,TEN_PB from PHONG_BAN order by TEN_PB");

            foreach (DataItem item in lpb)
            {
                TreeNode node = new TreeNode(item.Name);
                node.Tag = item.Value;


                tvPhongBan.Nodes.Add(node);
            }

            

            lpb.Clear();

            List<DataItem> lcv = model.getList("select MACV,TEN_CV from CHUC_VU order by TEN_CV");

            foreach (DataItem item in lcv)
            {
                TreeNode node = new TreeNode(item.Name);
                node.Tag = item.Value;


                tvChucVu.Nodes.Add(node);
            }

            lcv.Clear();

            LoadDataToCombobox(cbbDanToc, "select MADT,TEN_DT from DAN_TOC");
            LoadDataToCombobox(cbbTonGiao, "select MATG,TEN_TG from TON_GIAO");
            LoadDataToCombobox(cbbTrinhDo, "select MAHV,TENHV+'('+CHUYEN_NGANH+')' as TEN from HOC_VAN");
            LoadDataToCombobox(cbbPhong, "select MAPB,TEN_PB from PHONG_BAN");
            LoadDataToCombobox(cbbChucVu, "select MACV,TEN_CV+'('+substring(convert(varchar(15),cast(PHU_CAP as money),-1),0,LEN(convert(varchar(15),cast(PHU_CAP as money),-1))-2)+')' as TEN from CHUC_VU");
            LoadDataToCombobox(cbbLuong, "select BACLUONG,substring(convert(varchar(15),cast(LUONG_CO_BAN as money),-1),0,LEN(convert(varchar(15),cast(LUONG_CO_BAN as money),-1))-2) as luong from LUONG");

            tableTN = model.getDataThanNhan();
            dataGridView2.DataSource = tableTN;

            model.getAllData();

            HiddenColumnGridView();

            model.ShowDetail(ShowDetail);

            ShowDetail(dataGridView1.CurrentRow);

            foreach (Control ct in groupBox4.Controls)
            {
                if (ct is TextBox || ct is RichTextBox || ct is ComboBox)
                {
                    ct.KeyPress += new KeyPressEventHandler(ct_KeyPress);
                }
                
            }

            EnableButton(false);
        }

        void ct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tab.action == ActionForm.KHONG)
                e.Handled = true;
        }



        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.Value.ToString().Equals("True"))
                {
                    e.Value = "Nam";
                }
                else
                    e.Value = "Nũ";
            }
            else {
                if (e.ColumnIndex == 6)
                {
                    switch (e.Value.ToString())
                    {
                        case "1":
                            e.Value = "NV Chính Thức";
                            break;
                        case "2":
                            e.Value = "NV Thử Việc";
                            break;
                        case "3":
                            e.Value = "NV Bán Thời Gian";
                            break;
                        case "4":
                            e.Value = "NV Thực Tập";
                            break;
                    }
                }
                else {
                    if (e.ColumnIndex == 4) {
                        DateTime dt = (DateTime)e.Value;
                        e.Value = dt.Day + "/" + dt.Month + "/" + dt.Year;
                    }
                }
              
            }

        }

        private void Search(string query)
        {
            if (tableNV == null) {
                tableNV = dataGridView1.DataSource as DataTable;
            }

            tableNV.DefaultView.RowFilter = query;
        }

        private string TaoQuery() {
            string query = "";
            if (tvPhongBan.SelectedNode != null) {
                if (tvPhongBan.SelectedNode.Text.Equals("Tất Cả"))
                {
                    query = "PHONG<>''";
                }
                else
                {
                    query="PHONG='" + tvPhongBan.SelectedNode.Tag.ToString() + "'";
                }
            }
            if (tvChucVu.SelectedNode != null)
            {
                if(query!=""){
                    query+=" AND ";
                }
                if (tvChucVu.SelectedNode.Text.Equals("Tất Cả"))
                {
                    query += "CHUCVU<>''";
                }
                else
                {
                    query += "CHUCVU='" + tvChucVu.SelectedNode.Tag.ToString() + "'";
                }
            }

            if (treeView1.SelectedNode != null)
            {
                if (query != "")
                {
                    query += " AND ";
                }
                if (treeView1.SelectedNode.Text.Equals("Tất Cả"))
                {
                    query += "LOAI_NV<>0";
                }
                else
                {
                    query += "LOAI_NV=" + treeView1.SelectedNode.Tag.ToString();
                }
            }

            return query;
        }

        private void tvPhongBan_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Search(TaoQuery());
        }

        private bool CheckMa()
        {
            if (tab.action == ActionForm.THEM)
            {
                bool flag = true;
                string Ma = txtMaNV.Text.Trim().ToUpper();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(Ma))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag && Ma != "")
                {
                    errorProvider1.SetError(txtMaNV, "");
                    return true;
                }
                errorProvider1.SetError(txtMaNV, "Mã Nhân Viên Đã Tồn Tại");
                return false;

            }
            return true;
        }

        private bool checkEmail() {
            if (txtEmail.Text.Trim() != "")
            {
                if (!validate.checkEmail(txtEmail.Text.Trim()))
                {
                    errorProvider1.SetError(txtEmail, "Email không hợp lệ");
                    return false;
                }
                errorProvider1.SetError(txtEmail, "");
                return true;
            }
            errorProvider1.SetError(txtEmail, "");
            return true;
        }

        private bool checkNgaySinh() {
            DateTime now = DateTime.Now;
            DateTime ngaysinh = dtNgaySInh.Value;

            bool flag = false;

            if ((now.Year - ngaysinh.Year) < 18)
            {
                errorProvider1.SetError(dtNgaySInh, "Nhân viên chưa đủ 18 tuổi");
            }
            else
            {
                if (now.Year - ngaysinh.Year == 18)
                {
                    if ((ngaysinh.Day > now.Day && ngaysinh.Month >= now.Month) || (ngaysinh.Month > now.Month))
                    {
                        errorProvider1.SetError(dtNgaySInh, "Nhân viên chưa đủ 18 tuổi");
                    }
                    else
                    {
                        errorProvider1.SetError(dtNgaySInh, "");
                        flag = true;
                    }
                }
                else
                {
                    errorProvider1.SetError(dtNgaySInh, "");
                    flag = true;
                }
            }

            return flag;
        }

        private bool checkEmpty(TextBox txt) {
            if (txt.Text.Trim() == "")
            {
                errorProvider1.SetError(txt, "Không được để trống");
                return false;
            }
            errorProvider1.SetError(txt, "");
            return true;
        }

        private bool checkSoDT() {
            if (txtSoDT.Text.Trim() != "")
            {
                if (!validate.checkPhoneNumber(txtSoDT.Text.Trim()))
                {
                    errorProvider1.SetError(txtSoDT, "Số ĐT không hợp lệ");
                    return false;
                }
                errorProvider1.SetError(txtSoDT, "");
                return true;
            }
            errorProvider1.SetError(txtSoDT, "");
            return true;
        }

        private void txtMaNV_Leave(object sender, EventArgs e)
        {
            CheckMa();
        }

        private void txtHo_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            checkEmpty(txt);
        }

        private void dtNgaySInh_ValueChanged(object sender, EventArgs e)
        {
            checkNgaySinh();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            checkEmail();
        }

        private void txtSoDT_Leave(object sender, EventArgs e)
        {
            checkSoDT();
        }

        private void btnThemCMND_Click(object sender, EventArgs e)
        {

        }

        private void UpdateCbbDanToc(string key=null) {
            if (key == null)
            {
                key = cbbDanToc.SelectedValue.ToString();
            }
            LoadDataToCombobox(cbbDanToc, "select MADT,TEN_DT from DAN_TOC");

            cbbDanToc.SelectedValue = key;
        }

        private void btnThemDT_Click(object sender, EventArgs e)
        {
            if (tab.action != ActionForm.KHONG) {
                FrmDanToc frm = new FrmDanToc(((DataItem)cbbDanToc.SelectedItem).Value);
                if (frm.ShowDialog() == DialogResult.Cancel) {
                    if (frm.isChangeData)
                    {
                        UpdateCbbDanToc(frm.CurrentRowSelected);
                    }
                    else {
                        if (frm.CurrentRowSelected!=null)
                        cbbDanToc.SelectedValue = frm.CurrentRowSelected;
                    }
                }
            }
        }

        private void btnThemTG_Click(object sender, EventArgs e)
        {
            if (tab.action != ActionForm.KHONG)
            {
                FrmTonGiao frm = new FrmTonGiao(((DataItem)cbbTonGiao.SelectedItem).Value);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    if (frm.isChangeData)
                    {
                        UpdatecbbTonGiao(frm.CurrentRowSelected);
                    }
                    else
                    {
                        if (frm.CurrentRowSelected != null)
                            cbbTonGiao.SelectedValue = frm.CurrentRowSelected;
                    }
                }
            }
        }

        private void UpdatecbbTonGiao(string key=null)
        {
            if(key==null)
            key = cbbTonGiao.SelectedValue.ToString();
            
            LoadDataToCombobox(cbbTonGiao, "select MATG,TEN_TG from TON_GIAO");

            cbbTonGiao.SelectedValue = key;
        }

        private void UpdateCbbPhongBan(string key=null)
        {
            if(key==null)
            key = cbbPhong.SelectedValue.ToString();
            
            LoadDataToCombobox(cbbPhong, "select MAPB,TEN_PB from PHONG_BAN");

            cbbPhong.SelectedValue = key;
        }

        private void UpdateCbbChucVu(string key=null)
        {
            if(key==null)
             key = cbbChucVu.SelectedValue.ToString();
            
            LoadDataToCombobox(cbbChucVu, "select MACV,TEN_CV+'('+substring(convert(varchar(15),cast(PHU_CAP as money),-1),0,LEN(convert(varchar(15),cast(PHU_CAP as money),-1))-2)+')' as TEN from CHUC_VU");

            cbbChucVu.SelectedValue = key;
        }

        private void UpdatecbbLuong(string key=null)
        {
            if(key==null)
            key = cbbLuong.SelectedValue.ToString();
            
            LoadDataToCombobox(cbbLuong, "select BACLUONG,substring(convert(varchar(15),cast(LUONG_CO_BAN as money),-1),0,LEN(convert(varchar(15),cast(LUONG_CO_BAN as money),-1))-2) as luong from LUONG");

            cbbLuong.SelectedValue = key;
        }

        private void UpdatecbbTrinhDo(string key=null)
        {
            if(key==null)
            key = cbbTrinhDo.SelectedValue.ToString();
            
            LoadDataToCombobox(cbbTrinhDo, "select MAHV,TENHV+'('+CHUYEN_NGANH+')' as TEN from HOC_VAN");

            cbbTrinhDo.SelectedValue = key;
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            if (tab.action != ActionForm.KHONG)
            {
                FrmPhongBan frm = new FrmPhongBan(((DataItem)cbbPhong.SelectedItem).Value);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    if (frm.isChangeData)
                    {
                        UpdateCbbPhongBan(frm.CurrentRowSelected);
                    }
                    else
                    {
                        if (frm.CurrentRowSelected != null)
                            cbbPhong.SelectedValue = frm.CurrentRowSelected;
                    }
                }
            }
        }

        private void btnThemCV_Click(object sender, EventArgs e)
        {
            if (tab.action != ActionForm.KHONG)
            {
                FrmChucVu frm = new FrmChucVu(((DataItem)cbbChucVu.SelectedItem).Value);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    if (frm.isChangeData)
                    {
                        UpdateCbbChucVu(frm.CurrentRowSelected);
                    }
                    else
                    {
                        if (frm.CurrentRowSelected != null)
                            cbbChucVu.SelectedValue = frm.CurrentRowSelected;
                    }
                }
            }
        }

        private void btnThemLuong_Click(object sender, EventArgs e)
        {
            if (tab.action != ActionForm.KHONG)
            {
                FrmLuong frm = new FrmLuong(((DataItem)cbbLuong.SelectedItem).Value);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    if (frm.isChangeData)
                    {
                        UpdatecbbLuong(frm.CurrentRowSelected);
                    }
                    else
                    {
                        if (frm.CurrentRowSelected != null)
                            cbbLuong.SelectedValue = frm.CurrentRowSelected;
                    }
                }
            }
        }

        private void btnThemTD_Click(object sender, EventArgs e)
        {
            if (tab.action != ActionForm.KHONG)
            {
                FrmTrinhDo frm = new FrmTrinhDo(((DataItem)cbbTrinhDo.SelectedItem).Value);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    if (frm.isChangeData)
                    {
                        UpdatecbbTrinhDo(frm.CurrentRowSelected);
                    }
                    else
                    {
                        if (frm.CurrentRowSelected != null)
                            cbbTrinhDo.SelectedValue = frm.CurrentRowSelected;
                    }
                }
            }
        }

        private void AddNewTN(string HoTen, string GioiTinh, string QuanHe, string NamSinh, string NgheNghiep) {

            foreach (DataRow item in tableTN.Rows) {
                if (item["HOTEN"].ToString().Equals(HoTen) && item["QUAN_HE"].ToString().Equals(QuanHe))
                {
                    MessageBox.Show("Thân nhân đã tồn tại. Không thể lưu");
                    return;
                }
            }
            DataRow row = tableTN.NewRow();
            row["HOTEN"] = HoTen;
            row["QUAN_HE"] = QuanHe;
            row["GIOI_TINH"] = GioiTinh;
            row["NAM_SINH"] = NamSinh;
            row["NGHE_NGHIEP"] = NgheNghiep;
            row["MAQHGD"] =0;

            tableTN.Rows.Add(row);
        }

        private void AddNewTNId(string Id,string HoTen, string GioiTinh, string QuanHe, string NamSinh, string NgheNghiep)
        {

            DataRow row = tableTN.NewRow();
            row["HOTEN"] = HoTen;
            row["QUAN_HE"] = QuanHe;
            row["GIOI_TINH"] = GioiTinh;
            row["NAM_SINH"] = NamSinh;
            row["NGHE_NGHIEP"] = NgheNghiep;
            row["MAQHGD"] = Id;
            row["MAHS"] = dataGridView1.CurrentRow.Cells["MAHS"].Value.ToString();
            tableTN.Rows.Add(row);
        }

        private void EditTN(string HoTen, string GioiTinh, string QuanHe, string NamSinh, string NgheNghiep)
        {
            DataGridViewRow row = dataGridView2.CurrentRow;

            row.Cells["QUANHE"].Value = QuanHe;
            row.Cells["HOTEN"].Value = HoTen;
            row.Cells["GIOI_TINHTN"].Value = GioiTinh;
            row.Cells["NAMSINH"].Value = NamSinh;
            row.Cells["NGHENGHIEP"].Value = NgheNghiep;
            
        }

        private void btnThemTN_Click(object sender, EventArgs e)
        {
            if (!isAdmin) {
                return;
            }
            switch (tab.action) { 
                case ActionForm.THEM:
                    FrmThanNhan frm = new FrmThanNhan();
                    frm.addnew = new FrmThanNhan.AddNewTN(AddNewTN);
                    frm.ShowDialog();
                    break;
                case ActionForm.KHONG: case ActionForm.SUA:
                    if (dataGridView1.CurrentRow != null) { 
                            FrmThanNhan frm1 = new FrmThanNhan(dataGridView1.CurrentRow.Cells["MAHS"].Value.ToString());
                            frm1.addnewid = new FrmThanNhan.AddNewTNWithId(AddNewTNId);
                            frm1.ShowDialog();
                    }
                    break;
            }
            
        }

        private void btnSuaTN_Click(object sender, EventArgs e)
        {
            if (!isAdmin) {
                return;
            }
                

            DataGridViewRow row = dataGridView2.CurrentRow;
            switch (tab.action) { 
                case ActionForm.THEM:
                    
                    if (row != null)
                    {
                        FrmThanNhan frm = new FrmThanNhan(row.Cells["HOTEN"].Value.ToString(), row.Cells["GIOI_TINHTN"].Value.ToString(), row.Cells["QUANHE"].Value.ToString(), row.Cells["NAMSINH"].Value.ToString(), row.Cells["NGHENGHIEP"].Value.ToString());
                        frm.edit = new FrmThanNhan.AddNewTN(EditTN);
                        frm.ShowDialog();
                    }
                    break;
                case ActionForm.KHONG:
                case ActionForm.SUA:
                    if (row != null)
                    {
                        FrmThanNhan frm1 = new FrmThanNhan(row.Cells["MAQHGD"].Value.ToString(), row.Cells["HOTEN"].Value.ToString(), row.Cells["GIOI_TINHTN"].Value.ToString(), row.Cells["QUANHE"].Value.ToString(), row.Cells["NAMSINH"].Value.ToString(), row.Cells["NGHENGHIEP"].Value.ToString());
                        frm1.edit = new FrmThanNhan.AddNewTN(EditTN);
                        frm1.ShowDialog();
                    }
                    break;
            }
        }

        private void btnXoaTN_Click(object sender, EventArgs e)
        {
            if (!isAdmin) {
                return;
            }
            DataGridViewRow row = dataGridView2.CurrentRow;
            if (row != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa thân nhân " + row.Cells["HOTEN"].Value.ToString() + "?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    switch (tab.action) { 
                        case ActionForm.THEM:
                            dataGridView2.Rows.Remove(row);
                            break;
                        case ActionForm.KHONG:
                        case ActionForm.SUA:
                            if (model.XoaTN(row.Cells["MAQHGD"].Value.ToString()) >0) {
                                dataGridView2.Rows.Remove(row);
                            }
                            break;
                    }
                }
            }
        }

        private void btnXemCTCMND_Click(object sender, EventArgs e)
        {
            if(isAdmin && dataGridView1.CurrentRow!=null){
                if (!checkNgaySinh())
                {
                    MessageBox.Show("Nhân viên chưa đủ 18 tuổi.");
                    return;
                }
                FrmCMND cmnd = null;
                if (tab.action == ActionForm.THEM)
                {
                    cmnd = new FrmCMND(dtNgaySInh.Value);
                }
                else {
                    cmnd = new FrmCMND(cbbCMND.Text, dataGridView1.CurrentRow.Cells["MAHS"].Value.ToString(), dtNgaySInh.Value);
                }
                if (cmnd.ShowDialog() == DialogResult.Cancel) {
                    cbbCMND.Text = cmnd.SOCMND;
                    dataGridView1.CurrentRow.Cells[18].Value = cbbCMND.Text;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (isAdmin && dataGridView1.CurrentRow != null)
            {
                string Path = "avatars/" + dataGridView1.CurrentRow.Cells["MAHS"].Value.ToString() + ".jpg";
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image|*.jpg;*.png;*.gif;*.bmp";

                if (open.ShowDialog() == DialogResult.OK) {
                    if (tab.action != ActionForm.THEM)
                    {
                        if (pictureBox1.Image != null)
                        {
                            pictureBox1.Image.Dispose();
                            pictureBox1.Image = null;
                            if (System.IO.File.Exists(Path))
                            {
                                try
                                {
                                    System.IO.File.Delete(Path);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }

                        pictureBox1.Image = Image.FromFile(open.FileName);
                        try
                        {
                            pictureBox1.Image.Save(Path);
                        }
                        catch { }
                    }
                    else {
                        pictureBox1.Image = Image.FromFile(open.FileName);
                        ChooseAvatar = true;
                    }
                }
            }
        }

        private void tvChucVu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Search(TaoQuery());
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Search(TaoQuery());
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals("Nhập Nội Dung Tìm Kiếm...")) {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim().Equals(""))
            {
                textBox2.Text = "Nhập Nội Dung Tìm Kiếm...";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox2.Text != "" && textBox2.Text != "Nhập Nội Dung Tìm Kiếm...")
            {
                string key=textBox2.Text.Trim() ;
                Search("MANV like '" + textBox2.Text.Trim() + "%' OR HO like '%" + key + "%' or TEN like '" + key + "%' or SO_DT like '" + key + "%'" + ((key.Equals("Nam") || key.Equals("Nữ")) ? (" OR GIOI_TINH="+(key.Equals("Nam")?1:0)) : ""));
            }
            else
            {
                Search(TaoQuery());
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (isAdmin) { 
                if(dataGridView1.CurrentRow!=null && (tab.action==ActionForm.KHONG || tab.action==ActionForm.SUA)){
                    if (MessageBox.Show("Bạn có chắc muốn reset mật khẩu cho nhân viên " + txtHo.Text + " " + txtTen.Text + "?.", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        if (model.ResetPass(txtMaNV.Text) == -1) {
                            MessageBox.Show("Có lỗi. Reset mật khẩu thất bại");
                        }else{
                            MessageBox.Show("Reset mật khẩu thành công. Mật khẩu là 123456");
                        }
                    }
                }
            }
        }
    }
}
