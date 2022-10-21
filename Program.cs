using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string cs = @"server=172.17.0.2,3306;userid=root;password=my-secret-pw;database=testdb";//this connec string ws tested to be corect in utilityclasses,testdb.cs

//"Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword"

builder.Services.AddDbContext<dishContext>(options =>
    {
        options.UseMySql(cs ,ServerVersion.AutoDetect(cs));
        Console.WriteLine("Adddbcontext pool executed 2");
    }
);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
