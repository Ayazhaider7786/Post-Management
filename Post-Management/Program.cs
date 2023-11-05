using AspnetIdentityRoleBasedTutorial.Services;
using Microsoft.EntityFrameworkCore;
using Post_Management.Data;
using Post_Management.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PostManagementDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiConnectionString"))
    );

builder.Services.AddScoped<PostRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<CommentManagementService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Posts}/{action=StartServer}/{id?}");

app.MapControllers();

app.Run();
