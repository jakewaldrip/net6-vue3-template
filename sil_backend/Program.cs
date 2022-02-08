using sil_backend.Helpers;
using sil_backend.Repositories;
using sil_backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddDbContextFactory<MyDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IResetPasswordRepository, ResetPasswordRepository>();
builder.Services.AddScoped<IResetPasswordService, ResetPasswordService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseHttpsRedirection();
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();
app.Run();
