using Microsoft.EntityFrameworkCore;
using ThucHanhWebAPInetcoreEntity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if (1 < 0) // gán cứng bằng lệnh
    builder.Services.AddDbContext<StudentContext>(options =>
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CMCUni2;Integrated Security=True;"));
else // lấy từ cấu hình appsettings.json
    builder.Services.AddDbContext<StudentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDBConnectionString")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
