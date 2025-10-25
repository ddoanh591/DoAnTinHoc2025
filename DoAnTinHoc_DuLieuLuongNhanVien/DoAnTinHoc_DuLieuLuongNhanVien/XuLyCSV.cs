using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace DoAnTinHoc_DuLieuLuongNhanVien
{
    public class XuLyCSV
    {
        DataTable dt = new DataTable();
        string filecsv = "\\Employers_data.csv";
        List<NhanVien> dsNV = new List<NhanVien>();
        public List<NhanVien> DocFileCSV(string path)
        {
            var dsNV = new List<NhanVien>();
            bool boQuaTieuDe = true;


            foreach (var line in File.ReadLines(path))
            {


                if (boQuaTieuDe)
                {
                    boQuaTieuDe = false;
                    continue;
                }

                if (string.IsNullOrWhiteSpace(line)) continue;

                // Xử lý chuỗi có dấu phẩy trong dữ liệu (dạng "text, text")
                var parts = line.Split(',');

                var nv = new NhanVien
                {
                    EmployeeID = int.Parse(parts[0]),
                    Name = parts[1],
                    Age = int.Parse(parts[2]),
                    Gender = parts[3],
                    Department = parts[4],
                    JobTitle = parts[5],
                    ExperienceYears = int.Parse(parts[6]),
                    EducationLevel = parts[7],
                    Location = parts[8],
                    Salary = double.Parse(parts[9])
                };
                dsNV.Add(nv);
            }

            return dsNV;
        }


        public void GhiFile(string gf, List<NhanVien> dsNV)
        {
            using (var writer = new StreamWriter(gf))
            {
                // Ghi dòng tiêu đề
                writer.WriteLine("Employee_ID,Name,Age,Gender,Department,Job_Title,Experience_Years,Education_Level,Location,Salary");

                // Ghi từng dòng dữ liệu
                foreach (var nv in dsNV)
                {
                    writer.WriteLine($"{nv.EmployeeID},{nv.Name},{nv.Age},{nv.Gender},{nv.Department},{nv.JobTitle},{nv.ExperienceYears},{nv.EducationLevel},{nv.Location},{nv.Salary}");
                }
            }
        }
    }
}
