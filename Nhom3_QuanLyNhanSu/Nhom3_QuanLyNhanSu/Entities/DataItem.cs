namespace Nhom3_QuanLyNhanSu.Entities
{
    public class DataItem
    {
        public string Value { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
