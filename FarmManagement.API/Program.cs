using FarmManagement.API;

var builder = WebApplication.CreateBuilder(args);

var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

await app.ApplyMigrationAndSeedData(builder);

app.Run();