var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

// ��������� ����������� �������
#region CUSTOM_SERVICES

var connectionString = builder.Configuration.GetConnectionString("Default");

// Entity Framework Core
builder.Services.AddDbContext<EShopDbContext>(builder =>
{
    builder.UseSqlServer(connectionString);
});

builder.Services.AddTransient<IUserService, UserService>();

#endregion

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
