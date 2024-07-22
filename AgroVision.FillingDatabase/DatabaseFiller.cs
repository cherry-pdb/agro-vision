using AgroVision.Core.Models;
using AgroVision.Core.Repositories;
using AgroVision.Database.Context;
using AgroVision.Database.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace AgroVision.FillingDatabase;

public class DatabaseFiller
{
    private readonly AgroVisionContext _dbContext;

    public DatabaseFiller(AgroVisionContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async void FillDatabaseAsync(string filepath)
    {
        TruncateTable();
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using var package = new ExcelPackage(new FileInfo(filepath));
        var worksheet = package.Workbook.Worksheets["2022"];
        const int rowCount = 31;

        for (var row = 4; row < rowCount; row++)
        {
            var id = Guid.NewGuid();
            var districtId = int.Parse(worksheet.Cells[row, 1].Value.ToString());
            var districtName = worksheet.Cells[row, 2].Value.ToString();
            var mobilePhosphorus = double.Parse(worksheet.Cells[row, 4].Value.ToString());
            var mobileKalium = double.Parse(worksheet.Cells[row, 5].Value.ToString());
            var saltExtract = double.Parse(worksheet.Cells[row, 6].Value.ToString());
            var humus = double.Parse(worksheet.Cells[row, 7].Value.ToString());
            var grainYield = double.Parse(worksheet.Cells[row, 8].Value.ToString());
            var potatoYield = double.Parse(worksheet.Cells[row, 9].Value.ToString());
            var sunflowerYield = double.Parse(worksheet.Cells[row, 10].Value.ToString());
            var openGroundVegetablesYield = double.Parse(worksheet.Cells[row, 11].Value.ToString());
            var srup = double.Parse(worksheet.Cells[row, 12].Value.ToString());
            var soilGradation = worksheet.Cells[row, 13].Value.ToString();

            var agrochemicalCharacteristic = new AgrochemicalСharacteristicsDb(
                id,
                districtId,
                districtName,
                mobilePhosphorus,
                mobileKalium,
                saltExtract,
                humus,
                grainYield,
                potatoYield,
                sunflowerYield,
                openGroundVegetablesYield,
                srup,
                soilGradation);
            
            await _dbContext.AgrochemicalСharacteristics.AddAsync(agrochemicalCharacteristic);
            Console.WriteLine($"{districtName} added");

        } 
        _dbContext.SaveChanges();
        Console.WriteLine("saved in db");
    }

    public void TruncateTable()
    {
        _dbContext.Database.ExecuteSql($"TRUNCATE TABLE \"AgrochemicalСharacteristics\"");
    }
}