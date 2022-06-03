using TDD_CloudCustomers.API.Services.Abstract.UserServices;
using TDD_CloudCustomers.API.Services.Implementation.UserServices;

var builder = WebApplication.CreateBuilder(args);

#region DI

builder.Services.AddTransient<IUserService, UserService>();


#endregion


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




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
