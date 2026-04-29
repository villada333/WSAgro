using WSAgro.Extensiones;

var builder = WebApplication.CreateBuilder(args);

builder.InitConfigAPI();

var app = builder.Build();

app.InitConfigAPI();

app.Run();
