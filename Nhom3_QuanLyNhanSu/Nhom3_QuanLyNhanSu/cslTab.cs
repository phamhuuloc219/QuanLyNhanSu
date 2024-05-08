namespace Nhom3_QuanLyNhanSu
{
    public delegate void ChangeStateButton();
    public delegate void EventChangeData(int index);

    

    public enum ActionForm{
        THEM,SUA,KHONG
    }

    public enum ValidateType
    {
        NULL, NUMBER, PHONENUMBER,PRICE, CMND
    }


    public class infoTab
    {
        public bool Them = true;
        public bool Sua = false;
        public bool CapNhat = false;
        public bool In = false;
        public bool Luu = false;

        public ActionForm action=ActionForm.KHONG;

        public int index = 0;

        public delegate void EventButton();

        public EventButton AddNew=null;
        public EventButton Edit = null;
        public EventButton Delete = null;

        public EventButton Save = null;
        public EventButton Cancel = null;

        public EventButton Refresh = null;

        public EventButton Print = null;

        public EventChangeData UpdateData = null;

        public EventChangeData callBackChangeData = null;
    }


    public class ValidateParam {
        public ValidateType type;
        public string text;
        public System.Windows.Forms.Label lb;
        public string Message = "";

        public ValidateParam(ValidateType type, string text, System.Windows.Forms.Label lb,string Message)
        {
            this.type = type;
            this.text = text;
            this.lb = lb;
            this.Message = Message;
        }
    }

    public class Validate {
        public System.Drawing.Bitmap imgError = Properties.Resources.erroricon;
        public System.Drawing.Bitmap imgOk = Properties.Resources.yes;
        private System.Windows.Forms.ToolTip tooltip = null;

        public void SetTooltip(System.Windows.Forms.ToolTip tooltip)
        {
            this.tooltip = tooltip;
        }
        public bool Check(params System.Windows.Forms.Label[] lbs) {
            foreach (System.Windows.Forms.Label lb in lbs) {
                if (lb.Image == imgError)
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkPrice(string text) {
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^[0-9]{1,3}( |-|\.|\,)?[0-9]{3}(( |-|\.|\,)?[0-9]{3})?(( |-|\.|\,)?[0-9]{3})?(( |-|\.|\,)?[0-9]{3})?$");
            System.Text.RegularExpressions.Match m = rg.Match(text);
            return m.Success || text.Trim().Equals("0") || text.Trim().Equals("00");
        }

        public bool checkPhoneNumber(string text)
        {
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^0([0-9]{2,3})(\.|-| )?([0-9]{3,4})(\.|-| )?([0-9]{3,4})$$");
            System.Text.RegularExpressions.Match m = rg.Match(text);
            return m.Success;
        }

        public bool checkEmail(string text)
        {
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$");
            System.Text.RegularExpressions.Match m = rg.Match(text);
            return m.Success;
        }

        private bool checkCMND(string text) {
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^[0-9]{9,10}$");
            System.Text.RegularExpressions.Match m = rg.Match(text.Trim());
            return m.Success;
        }

        public string formatPrice(string price) {
            return price.Replace(" ", "").Replace(".", "").Replace(",", "").Replace("-", "");
        }

        private string UpperFirst(string str)
        {
            string str2 = str[0].ToString().ToUpper() + str.Substring(1);
            return str2;
        }

        public string formatStringToName(string name)
        {
            name = name.ToLower();

            string[] arr = name.Split(' ');

            name = "";

            foreach (string str in arr) {
                if(str!="")
                name += UpperFirst(str)+" ";
            }

            return name.TrimEnd();
        }

        public bool Check(params ValidateParam[] ps) {
            foreach (ValidateParam p in ps) {
                switch (p.type) {
                    case ValidateType.NULL:
                        p.lb.Visible = true;
                        if (p.text.Trim().Equals("")) {
                            p.lb.Image = imgError;
                            if (tooltip != null) {
                                tooltip.SetToolTip(p.lb, p.Message);
                            }
                            return false;
                        }
                        p.lb.Image = imgOk;
                        if (tooltip != null)
                        {
                            tooltip.SetToolTip(p.lb, "");
                        }
                        return true;
                    case ValidateType.NUMBER:
                        p.lb.Visible = true;
                        try
                        {
                            int.Parse(p.text.Trim());
                            p.lb.Image = imgOk;
                            if (tooltip != null)
                            {
                                tooltip.SetToolTip(p.lb, "");
                            }
                            return true;
                        }
                        catch {
                            p.lb.Image = imgError;
                            if (tooltip != null)
                            {
                                tooltip.SetToolTip(p.lb, p.Message);
                            }
                            return false;
                        }
                    case ValidateType.PRICE:
                        p.lb.Visible = true;
                        if (checkPrice(p.text.Trim())) {
                            p.lb.Image = imgOk;
                            if (tooltip != null)
                            {
                                tooltip.SetToolTip(p.lb,"");
                            }
                            return true;
                        } 
                         p.lb.Image = imgError;
                         if (tooltip != null)
                         {
                             tooltip.SetToolTip(p.lb, p.Message);
                         }
                            return false;
                    case ValidateType.CMND:
                        p.lb.Visible = true;
                        if (checkCMND(p.text)) {
                            p.lb.Image = imgOk;
                            if (tooltip != null)
                            {
                                tooltip.SetToolTip(p.lb,"");
                            }
                            return true;
                        } 
                         p.lb.Image = imgError;
                         if (tooltip != null)
                         {
                             tooltip.SetToolTip(p.lb, p.Message);
                         }
                            return false;
                        
                }
            }

            return false;
        }
    }

    public class clsTab
    {
        public int CurrentTab = 0;

        private System.Collections.Generic.List<infoTab> l = new System.Collections.Generic.List<infoTab>();

        private infoTab search(int index) {
            infoTab info = null;

            foreach (infoTab item in l)
            {
                if (item.index == index)
                {
                    info = item;
                    break;
                }
            }

            return info;
        }

        public infoTab current()
        {
            if (CurrentTab == 0)
                return null;
            return search(CurrentTab);
        }

        public infoTab current(int index)
        {
            return search(index);
        }

        public void addTab(int index,bool print)
        {
            infoTab info = new infoTab();
            info.index = index;
            info.In = print;

            l.Add(info);
        }

        public void AddEventChangeData(EventChangeData method) {
            if (CurrentTab != 3 && CurrentTab!=0) {
                infoTab cur = current();
                cur.UpdateData = method;
            }
        }

        public void removeTab(int index)
        {
            infoTab info = search(index);
            if (info != null)
            {
                l.Remove(info);
            }
        }

        public void clearTab()
        {
            l.Clear();
        }
    }

    public class NVLG {
        public static string MaNVLG = "";
        public static string HoTenNVLG = "";
    }
}
