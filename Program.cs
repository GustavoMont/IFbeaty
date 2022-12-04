using IFbeaty.Repositorios;
using IFbeaty.Services;
using IFBeaty.Data;
using IFBeaty.Repositorios;
using IFBeaty.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<DiaFuncionamentoRepositorio>();
builder.Services.AddScoped<DiaFuncionamentoServico>();
builder.Services.AddScoped<ProcedimentoServico>();
builder.Services.AddScoped<ProcedimentoRepositorio>();
builder.Services.AddScoped<AgendamentoServico>();
builder.Services.AddScoped<AgendamentoRepositorio>();

builder.Services.AddDbContext<ContextoBD>(
  options =>
  options.UseMySql(
      builder.Configuration.GetConnectionString("ConexaoBanco"),
      ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConexaoBanco"))
  )
);



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
