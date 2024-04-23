using FormulaOne.DataService;
using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repository;
using FormulaOne.DataService.Repository.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddTransient<IDriverRepository,DriverRepository>();
builder.Services.AddTransient<IAchievementRepository,AchievementsRepository>();
builder.Services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapControllers();
app.Run();


