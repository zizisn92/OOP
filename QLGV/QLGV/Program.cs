using System;
using System.Collections.Generic;

namespace QLGV
{
    public class MonHoc
    {
        public string TenMonHoc { set; get; }
        public string TenLop { set; get; }
        public int SoTinChi { set; get; }
        public int SiSo { set; get; }

        // Tinh gio chuan theo dieu kien
        public double TinhSoGioChuan(int soTinChi,int siSo)
        {
            if(siSo<20)
            {
                return Math.Round(0.8 * soTinChi*18,2);
            }
            else if(siSo<30)
            {
                return Math.Round(0.9 * soTinChi*18,2);
            }
            else if(siSo<60)
            {
                return Math.Round(1.0 * soTinChi*18,2);
            }
            else
            {
                return Math.Round(1.1 * soTinChi*18,2);
            }
        }
        public void NhapThongTinMonHoc()
        {
            Console.WriteLine("Nhap ten mon hoc:");
            TenMonHoc = Console.ReadLine();
            Console.WriteLine("Nhap so tin chi:");
            SoTinChi = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Nhap ten lop:");
            TenLop = Console.ReadLine();
            Console.WriteLine("Nhap si so:");
            SiSo = Int32.Parse(Console.ReadLine());
        }
    }
    public class GiaoVien
    {
        public string MaGiaoVien { set; get; }
        public string TenGiaoVien { set; get; }
        public List<MonHoc> MonHocs { set; get; } = new List<MonHoc>();
        public void NhapThongTinGiaoVien()
        {
            int index = 1;
            Console.WriteLine("Nhap ma giao vien:");
            MaGiaoVien = Console.ReadLine();
            Console.WriteLine("Nhap ten giao vien:");
            TenGiaoVien = Console.ReadLine();
            Console.WriteLine($"Nhap danh sach mon hoc:");
            while (true)
            {
                Console.WriteLine("1.Nhap thong tin mon hoc");
                Console.WriteLine("2.Exit");
                int option;
                option = Int32.Parse(Console.ReadLine());
                if (option==1)
                {
                    Console.WriteLine($"Mon hoc thu {index}:");
                    MonHoc monHoc = new MonHoc();
                    monHoc.NhapThongTinMonHoc();
                    MonHocs.Add(monHoc);
                    index++;
                }
                else
                {
                    break;
                }
            }
        }
        public void HienThiThongTinGiaoVien()
        {
            Console.WriteLine("Hien thi thong tin giao vien");
            Console.Write(MaGiaoVien.PadLeft(15));
            Console.WriteLine(TenGiaoVien);
            Console.Write("Mon hoc".PadLeft(15));
            Console.Write("So tin chi".PadLeft(15));
            Console.Write("Lop".PadLeft(15));
            Console.Write("Si so".PadLeft(15));
            Console.Write("Gio chuan".PadLeft(15));
            Console.WriteLine();
            for (int i=0;i< MonHocs.Count;i++)
            {
                Console.Write(MonHocs[i].TenMonHoc.PadLeft(15));
                Console.Write(MonHocs[i].SoTinChi.ToString().PadLeft(15));
                Console.Write(MonHocs[i].TenLop.ToString().PadLeft(15));
                Console.Write(MonHocs[i].SiSo.ToString().PadLeft(15));
                Console.Write(MonHocs[i].TinhSoGioChuan(MonHocs[i].SoTinChi, MonHocs[i].SiSo).ToString().PadLeft(15));
                Console.WriteLine();
            }
        }
        public void HienThiTatCacLopTheoDieuKien()
        {
            int count = 0;
            Console.WriteLine("Danh sach tat ca cac lop si so > 50 va so TC > 2");
            Console.WriteLine($"{MaGiaoVien}-{TenGiaoVien}");
            Console.Write("Mon hoc".PadLeft(15));
            Console.Write("So tin chi".PadLeft(15));
            Console.Write("Lop".PadLeft(15));
            Console.Write("Si so".PadLeft(15));
            Console.Write("Gio chuan".PadLeft(15));
            Console.WriteLine();
            for (int i = 0; i < MonHocs.Count; i++)
            {
                if(MonHocs[i].SiSo>50 && MonHocs[i].SoTinChi>2)
                {
                    count++;
                    Console.Write(MonHocs[i].TenMonHoc.PadLeft(15));
                    Console.Write(MonHocs[i].SoTinChi.ToString().PadLeft(15));
                    Console.Write(MonHocs[i].TenLop.ToString().PadLeft(15));
                    Console.Write(MonHocs[i].SiSo.ToString().PadLeft(15));
                    Console.Write(MonHocs[i].TinhSoGioChuan(MonHocs[i].SoTinChi, MonHocs[i].SiSo).ToString().PadLeft(15));
                    Console.WriteLine();
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Khong lop nao thoa man dieu dieu si so > 50 va so TC > 2");
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            GiaoVien giaoVien = new GiaoVien();
            giaoVien.NhapThongTinGiaoVien();
            giaoVien.HienThiThongTinGiaoVien();
            giaoVien.HienThiTatCacLopTheoDieuKien();
            Console.ReadKey();
        }
    }
}
