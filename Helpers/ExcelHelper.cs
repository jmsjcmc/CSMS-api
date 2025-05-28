using ClosedXML.Excel;
using Csms_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Csms_api.Helpers
{
  public class ExcelHelper
    {
        private readonly AuthHelper _authHelper;
        private readonly AppDbContext _context;
        private readonly string[] companyHeaders =
        {
             "First Name", "Last Name", "Position", "Email", "Phone",
            "Company Name", "Company Address", "Company Email", "Company Number"
        };

        private readonly string[] palletHeaders =
        {
            "Pallet Type", "Pallet Number"
        };

        private readonly string[] productHeaders =
        {
            "Product Code", "Product Name", "Variant", "Sku", "Product Packaging",
            "Delivery Unit", "Quantity", "UOM", "Weight", "Unit", "Company Name"
        };

        public ExcelHelper(AuthHelper authHelper, AppDbContext context)
        {
            _authHelper = authHelper;
            _context = context;
        }

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

        public byte[] generatepallettemplate()
        {
            var workBook = new XLWorkbook();
            var workSheet = workBook.Worksheets.Add("Pallet Template");

            for (int i = 0; i < palletHeaders.Length; i++)
            {
                workSheet.Cell(1, i + 1).Value = companyHeaders[i];
                workSheet.Cell(1, i + 1).Style.Font.Bold = true;
                workSheet.Column(i + 1).AdjustToContents();
            }

            var example = 2;
            workSheet.Cell(example, 1).Value = "Wood";
            workSheet.Cell(example, 2).Value = "00000001";

            var stream = new MemoryStream();
            workBook.SaveAs(stream);
            return stream.ToArray();
        }

        public byte[] generateproducttemplate()
        {
            var workBook = new XLWorkbook();
            var workSheet = workBook.Worksheets.Add("Product Template");

            for (int i = 0; i < productHeaders.Length; i++)
            {
                workSheet.Cell(1, i + 1).Value = productHeaders[i];
                workSheet.Cell(1, i + 1).Style.Font.Bold = true;
                workSheet.Column(i + 1).AdjustToContents();
            }

            var example = 2;
            workSheet.Cell(example, 1).Value = "000-000-0001";
            workSheet.Cell(example, 2).Value = "Frozen Chicken Tocino";
            workSheet.Cell(example, 3).Value = "Teriyaki";
            workSheet.Cell(example, 4).Value = "250g";
            workSheet.Cell(example, 5).Value = "Can";
            workSheet.Cell(example, 6).Value = "Box";
            workSheet.Cell(example, 7).Value = "60";
            workSheet.Cell(example, 8).Value = "Can";
            workSheet.Cell(example, 9).Value = 100.52;
            workSheet.Cell(example, 10).Value = "Kg";
            workSheet.Cell(example, 11).Value = "Bounty Fresh";

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
            foreach (var company in companies)
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

        public byte[] exportpallets(IEnumerable<Pallet> pallets)
        {
            var workBook = new XLWorkbook();
            var workSheet = workBook.Worksheets.Add("Pallets");

            for (int i = 0; i < palletHeaders.Length; i++)
            {
                workSheet.Cell(1, i + 1).Value = palletHeaders[i];
                workSheet.Cell(1, i + 1).Style.Font.Bold = true;
            }

            int row = 2;
            foreach (var pallet in pallets)
            {
                workSheet.Cell(row, 1).Value = pallet.Pallet_type;
                workSheet.Cell(row, 2).Value = pallet.Pallet_no;
                row++;
            }

            workSheet.Columns().AdjustToContents();
            var stream = new MemoryStream();
            workBook.SaveAs(stream);
            return stream.ToArray();
        }

        public byte[] exportproducts(IEnumerable<Product> products)
        {
            var workBook = new XLWorkbook();
            var workSheet = workBook.Worksheets.Add("Products");

            for (int i = 0; i < productHeaders.Length; i++)
            {
                workSheet.Cell(1, i + 1).Value = productHeaders[i];
                workSheet.Cell(1, i + 1).Style.Font.Bold = true;
            }

            int row = 2;
            foreach (var product in products)
            {
                workSheet.Cell(row, 1).Value = product.Product_code;
                workSheet.Cell(row, 2).Value = product.Product_name;
                workSheet.Cell(row, 3).Value = product.Variant;
                workSheet.Cell(row, 4).Value = product.Sku;
                workSheet.Cell(row, 5).Value = product.Product_packaging;
                workSheet.Cell(row, 6).Value = product.Delivery_unit;
                workSheet.Cell(row, 7).Value = product.Quantity;
                workSheet.Cell(row, 8).Value = product.Uom;
                workSheet.Cell(row, 9).Value = product.Weight;
                workSheet.Cell(row, 10).Value = product.Unit;

            }

            workSheet.Columns().AdjustToContents();
            var stream = new MemoryStream();
            workBook.SaveAs(stream);
            return stream.ToArray();
        }

        public List<Company> importcompanies (IFormFile file)
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

        public List<Pallet> importpallets (IFormFile file)
        {
            var pallets = new List<Pallet>();

            var stream = new MemoryStream();
            file.CopyTo(stream);

            var workBook = new XLWorkbook(stream);
            var workSheet = workBook.Worksheets.First();
            var rows = workSheet.RowsUsed().Skip(1);

            foreach (var row in rows)
            {
                pallets.Add(new Pallet
                {
                    Pallet_type = row.Cell(1).GetValue<string>(),
                    Pallet_no = row.Cell(2).GetValue<int>(),
                    Occupied = false,
                    Active = true,
                    Removed = false,
                    Creator_id = _authHelper.GetUserID(),
                    Created_on = TimeHelper.GetPhilippineTime(),
                    Updated_id = null,
                    Updated_on = null
                });
            }
            return pallets;
        }

        public async Task<List<Product>> importproducts (IFormFile file)
        {
            var products = new List<Product>();

            var stream = new MemoryStream();
            file.CopyTo(stream);

            var workBook = new XLWorkbook(stream);
            var workSheet = workBook.Worksheets.First();
            var rows = workSheet.RowsUsed().Skip(1);

            foreach (var row in rows)
            {
                var companyName = row.Cell(11).GetValue<string>();
                var companyId = await GetCompanyId(companyName);

                products.Add(new Product
                {
                    Product_code = row.Cell(1).GetValue<string>(),
                    Product_name = row.Cell(2).GetValue<string>(),
                    Variant = row.Cell(3).GetValue<string>(),
                    Sku = row.Cell(4).GetValue<string>(),
                    Product_packaging = row.Cell(5).GetValue<string>(),
                    Delivery_unit = row.Cell(6).GetValue<string>(),
                    Quantity = row.Cell(7).GetValue<int>(),
                    Uom = row.Cell(8).GetValue<string>(),
                    Weight = row.Cell(9).GetValue<double>(),
                    Unit = row.Cell(10).GetValue<string>(),
                    Active = true,
                    Removed = false,
                    Creator_id = _authHelper.GetUserID(),
                    Created_on = TimeHelper.GetPhilippineTime(),
                    Updater_id = null,
                    Updated_on = null,
                    Company_id = companyId
                });
            }
            return products;
        }

        public async Task<int> GetCompanyId(string companyName)
        {
            return await _context.Companies
                .Where(c => c.Company_name == companyName)
                .Select(c => c.Id)
                .FirstOrDefaultAsync();
        }
    }
}
