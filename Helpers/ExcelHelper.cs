using ClosedXML.Excel;
using Csms_api.Models;

namespace Csms_api.Helpers
{
  public class ExcelHelper
    {
        private readonly string[] companyHeaders =
        {
             "First Name", "Last Name", "Position", "Email", "Phone",
            "Company Name", "Company Address", "Company Email", "Company Number"
        };

        public byte[] generatecompanytemplate()
        {
            var workBook = new XLWorkbook();
            var workSheet = workBook.Worksheets.Add("Company Template");

            for (int i = 0; i < companyHeaders.Length; i++)
            {
                workSheet.Cell(1, i + 1).Value = companyHeaders[i];
                workSheet.Cell(1, i + 1).Style.Font.Bold = true;
                workSheet.Column(i + 1).AdjustToContents();
            }

            var example = 2;
            workSheet.Cell(example, 1).Value = "Juan";
            workSheet.Cell(example, 2).Value = "Dela Cruz";
            workSheet.Cell(example, 3).Value = "Sales Person";
            workSheet.Cell(example, 4).Value = "delacruzjuan@gmail.com";
            workSheet.Cell(example, 5).Value = "09123456789";
            workSheet.Cell(example, 6).Value = "Bounty Fresh";
            workSheet.Cell(example, 7).Value = "2GRG+574, Talomo, Davao City, Davao del Sur";
            workSheet.Cell(example, 8).Value = "bountyfresh@magnolia.ph";
            workSheet.Cell(example, 9).Value = "211587";

            var stream = new MemoryStream();
            workBook.SaveAs(stream);
            return stream.ToArray();
        }

        public byte[] exportcompanies(IEnumerable<Company> companies)
        {
            var workBook = new XLWorkbook();
            var workSheet = workBook.Worksheets.Add("Companies");

            for (int i = 0; i < companyHeaders.Length; i++)
            {
                workSheet.Cell(1, i + 1).Value = companyHeaders[i];
                workSheet.Cell(1, i + 1).Style.Font.Bold = true;
            }

            int row = 2;
            foreach(var company in companies)
            {
                workSheet.Cell(row, 1).Value = company.First_name;
                workSheet.Cell(row, 2).Value = company.Last_name;
                workSheet.Cell(row, 3).Value = company.Position;
                workSheet.Cell(row, 4).Value = company.Email;
                workSheet.Cell(row, 5).Value = company.Phone;
                workSheet.Cell(row, 6).Value = company.Company_name;
                workSheet.Cell(row, 7).Value = company.Company_address;
                workSheet.Cell(row, 8).Value = company.Company_email;
                workSheet.Cell(row, 9).Value = company.Company_number;
                row++;
            }

            workSheet.Columns().AdjustToContents();
            var stream = new MemoryStream();
            workBook.SaveAs(stream);
            return stream.ToArray();
        }

        public List<Company> importcompanies(IFormFile file)
        {
            var companies = new List<Company>();

            var stream = new MemoryStream();
            file.CopyTo(stream);
            var workBook = new XLWorkbook(stream);
            var workSheet = workBook.Worksheets.First();
            var rows = workSheet.RowsUsed().Skip(1); // Skip headers

            foreach ( var row in rows)
            {
                companies.Add(new Company
                {
                    First_name = row.Cell(1).GetValue<string>(),
                    Last_name = row.Cell(2).GetValue<string>(),
                    Position = row.Cell(3).GetValue<string>(),
                    Email = row.Cell(4).GetValue<string>(),
                    Phone = row.Cell(5).GetValue<string>(),
                    Company_name = row.Cell(6).GetValue<string>(),
                    Company_address = row.Cell(7).GetValue<string>(),
                    Company_email = row.Cell(8).GetValue<string>(),
                    Company_number = row.Cell(9).GetValue<string>(),
                });
            }
            return companies;
        }
    }
}
