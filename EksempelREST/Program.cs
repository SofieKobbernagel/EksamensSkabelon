using EksamensSkabelon;
using EksamensSkabelon.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

//Hvis Database:
/*
IClassRepo _repo;
var optionsBuilder = new DbContextOptionsBuilder<ClassDbContext>();
optionsBuilder.UseSqlServer(EksamensSkabelon.Secret.ConnectionString);
ClassDbContext _dbContext = new(optionsBuilder.Options);
_repo = new ClassRepoDb(_dbContext);
builder.Services.AddSingleton<IClassRepo>(_repo);
*/

//ellers
builder.Services.AddSingleton<IClassRepo, ClassRepo>();


// formål med CORS er at styre og sikre, hvilke webapplikationer (origins) der må tilgå din server fra en browser.
// Her defineres en CORS-politik med navnet "allowFromController", som tillader anmodninger fra alle domæner, metoder og headers.
// uden cors ville browseren blokere anmodninger fra andre domæner end det, hvor serveren kører.
builder.Services.AddCors(options =>
{
    options.AddPolicy("allowAll",
        builder =>
            builder
                .AllowAnyOrigin() //Tillader anmodninger fra alle domæner.
                .AllowAnyMethod() //Tillader alle HTTP-metoder (GET, POST, PUT, DELETE osv.).
                .AllowAnyHeader() //Tillader alle HTTP-headers.
    );
    options.AddPolicy("allowVueApp",
        builder =>
            builder
                .WithOrigins("http://localhost:5500") //Tillader kun anmodninger fra dette domæne (VueApp).
                .AllowAnyMethod() //Tillader alle HTTP-metoder (GET, POST, PUT, DELETE osv.).
                .AllowAnyHeader() //Tillader alle HTTP-headers.
    );
});


var app = builder.Build();


//Installer Swashbuckle.AspNetCore v.9.0.6

app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("allowVueApp");

app.UseAuthorization();

app.MapControllers();

app.Run();

