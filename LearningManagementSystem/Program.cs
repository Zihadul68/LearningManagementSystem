using BLL.Services;
using DAL.EF;
using DAL.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CourseRepo>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<StudentRepo>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<EnrollmentRepo>();
builder.Services.AddScoped<EnrollmentService>();
builder.Services.AddDbContext<LMSContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
