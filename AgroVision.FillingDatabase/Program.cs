using AgroVision.Database.Context;
using AgroVision.Database.Repositories;
using AgroVision.FillingDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var excelTablePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;

var configBuilder = new ConfigurationBuilder().AddJsonFile(Path.Combine(excelTablePath, "appsettings.json"));
IConfiguration configuration = configBuilder.Build();

var dbContextOptions = new DbContextOptionsBuilder<AgroVisionContext>()
    .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
    .Options;
var context = new AgroVisionContext(dbContextOptions);
var agrochemicalCharacteristicRepository = new AgrochemicalCharacteristicsRepository(context);

var excelFileName = "data.xlsx";
var fullFilepath = Path.Combine(excelTablePath, excelFileName);

var databaseFiller = new DatabaseFiller(context);
databaseFiller.FillDatabaseAsync(fullFilepath);