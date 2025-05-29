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
        private readonly XLWorkbook _workBook;
        private readonly MemoryStream _stream;
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
            _workBook = new XLWorkbook();
            _stream = new MemoryStream();
        }

        public byte[] generatecompanytemplate()
        {
            var workSheet = CreateWorkSheet("Company Template");
            var row = 2;

            for (int i = 0; i < companyHeaders.Length; i++)
            {
                workSheet.Cell(1, i + 1).Value = companyHeaders[i];
                workSheet.Cell(1, i + 1).Style.Font.Bold = true;
                workSheet.Column(i + 1).AdjustToContents();
            }

            workSheet.Cell(row, 1).Value = "Juan";
            workSheet.Cell(row, 2).Value = "Dela Cruz";
            workSheet.Cell(row, 3).Value = "Sales Person";
            workSheet.Cell(row, 4).Value = "delacruzjuan@gmail.com";
            workSheet.Cell(row, 5).Value = "09123456789";
            workSheet.Cell(row, 6).Value = "Bounty Fresh";
            workSheet.Cell(row, 7).Value = "2GRG+574, Talomo, Davao City, Davao del Sur";
            workSheet.Cell(row, 8).Value = "bountyfresh@magnolia.ph";
            workSheet.Cell(row, 9).Value = "211587";

            Save();
            return GetBytes();
        }

        public byte[] generatepallettemplate()
        {
            var workSheet = CreateWorkSheet("Pallet Template");
            var row = 2;

            for (int i = 0; i < palletHeaders.Length; i++)
            {
                workSheet.Cell(1, i + 1).Value = companyHeaders[i];
                workSheet.Cell(1, i + 1).Style.Font.Bold = true;
                workSheet.Column(i + 1).AdjustToContents();
            }

           
            workSheet.Cell(row, 1).Value = "Wood";
            workSheet.Cell(row, 2).Value = "00000001";

            Save();
            return GetBytes();
        }

        public byte[] generateproducttemplate()
        {
            var workSheet = CreateWorkSheet("Product Template");
            var row = 2;

            for (int i = 0; i < productHeaders.Length; i++)
            {
                workSheet.Cell(1, i + 1).Value = productHeaders[i];
                workSheet.Cell(1, i + 1).Style.Font.Bold = true;
                workSheet.Column(i + 1).AdjustToContents();
            }

            workSheet.Cell(row, 1).Value = "000-000-0001";
            workSheet.Cell(row, 2).Value = "Frozen Chicken Tocino";
            workSheet.Cell(row, 3).Value = "Teriyaki";
            workSheet.Cell(row, 4).Value = "250g";
            workSheet.Cell(row, 5).Value = "Can";
            workSheet.Cell(row, 6).Value = "Box";
            workSheet.Cell(row, 7).Value = "60";
            workSheet.Cell(row, 8).Value = "Can";
            workSheet.Cell(row, 9).Value = 100.52;
            workSheet.Cell(row, 10).Value = "Kg";
            workSheet.Cell(row, 11).Value = "Bounty Fresh";

            Save();
            return GetBytes();
        }

        public byte[] exportcompanies(IEnumerable<Company> companies)
        {
            var workSheet = CreateWorkSheet("Companies");
            int row = 2;

            for (int i = 0; i < companyHeaders.Length; i++)
            {
                workSheet.Cell(1, i + 1).Value = companyHeaders[i];
                workSheet.Cell(1, i + 1).Style.Font.Bold = true;
            }

            foreach (var company in companies)
            {
                var values = new object[]
                {
                    company.First_name, company.Last_name, company.Position,
                    company.Email, company.Phone, company.Company_name,
                    company.Company_address, company.Company_email, company.Company_number
                };
                for (int col = 0; col < values.Length; col++)
                    workSheet.Cell(row, col + 1).Value = values[col]?.ToString();
                row++;
            }

            workSheet.Columns().AdjustToContents();
            Save();
            return GetBytes();
        }

        public byte[] exportpallets(IEnumerable<Pallet> pallets)
        {
            var workSheet = CreateWorkSheet("Pallets");
            int row = 2;

            for (int i = 0; i < palletHeaders.Length; i++)
            {
                workSheet.Cell(1, i + 1).Value = palletHeaders[i];
                workSheet.Cell(1, i + 1).Style.Font.Bold = true;
            }

            foreach (var pallet in pallets)
            {
                var values = new object[]
                {
                   pallet.Pallet_type, pallet.Pallet_no
                };

                for (int col = 0; col < values.Length; col++)
                    workSheet.Cell(row, col + 1).Value = values[col]?.ToString();
                row++;
            }

            workSheet.Columns().AdjustToContents();
            Save();
            return GetBytes();
        }

        public async Task<byte[]> exportproducts(IEnumerable<Product> products)
        {
            var productList = products.ToList();
            var companyMap = await GetCompanyMap(productList.Select(p => p.Company_id));
            var workSheet = CreateWorkSheet("Products");
            int row = 2;

            for (int i = 0; i < productHeaders.Length; i++)
            {
                workSheet.Cell(1, i + 1).Value = productHeaders[i];
                workSheet.Cell(1, i + 1).Style.Font.Bold = true;
            }

            foreach ( var product in productList)
            {
                string companyName = companyMap.TryGetValue(product.Company_id, out var name)
                     ? name
                     : "Unknown";

                var values = new object[]
                {
                    product.Product_code, product.Product_name,
                    product.Variant, product.Sku,
                    product.Product_packaging, product.Delivery_unit,
                    product.Quantity, product.Uom,
                    product.Weight, product.Unit,
                    companyName
                };

                for (int col = 0; col < values.Length; col++)
                    workSheet.Cell(row, col + 1).Value = values[col]?.ToString();
                row++;
            }
            workSheet.Columns().AdjustToContents();
            Save();
            return GetBytes();
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

        public IXLWorksheet CreateWorkSheet(string sheetName)
        {
            return _workBook.Worksheets.Add(sheetName);
        }

        public void Save()
        {
            _workBook.SaveAs(_stream);
        }

        public byte[] GetBytes()
        {
            return _stream.ToArray();
        }

        public void Dispose()
        {
            _workBook.Dispose();
            _stream.Dispose();
        }

        public async Task<int> GetCompanyId(string companyName)
        {
            return await _context.Companies
                .Where(c => c.Company_name == companyName)
                .Select(c => c.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<Dictionary<int, string>> GetCompanyMap(IEnumerable<int> companyIds)
        {
            var ids = companyIds
               .Distinct()
               .ToList();

            return await _context.Companies
                .Where(c => ids.Contains(c.Id))
                .ToDictionaryAsync(c => c.Id, c => c.Company_name);
        }
    }
}
