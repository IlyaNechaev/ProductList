var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

// Добавляем собственные сервисы
#region CUSTOM_SERVICES

// Entity Framework Core
builder.Services.AddSqlDbContext(builder.Configuration);

builder.Services.AddTransient<IUserService, UserService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandler>();

app.UseHttpsRedirection();
app.UseCors(builder => {
    builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
    });

app.UseAuthorization();

app.MapControllers();

app.Run();
