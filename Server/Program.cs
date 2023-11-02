using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using Serilog;
using STIMULUS_V2.Server.Services.Interfaces;
using STIMULUS_V2.Shared.Models.Entities;
using STIMULUS_V2.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddDbContextPool<STIMULUSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("STIMULUSConnection")));

builder.Services.AddScoped<IModelService<Code, int>, CodeService>();
builder.Services.AddScoped<IModelService<Composant, int>, ComposantService>();
builder.Services.AddScoped<IModelService<Cours, int>, CoursService>();
builder.Services.AddScoped<IModelService<Etudiant, string>, EtudiantService>();
builder.Services.AddScoped<IModelService<Exercice, int>, ExercieService>();
builder.Services.AddScoped<IModelService<FichierSauvegarde, int>, FichierSauvegardeService>();
builder.Services.AddScoped<IModelService<FichierSource, int>, FichierSourceService>();
builder.Services.AddScoped<IModelService<Graphe, int>, GrapheService>();
builder.Services.AddScoped<IModelService<Groupe, int>, GroupeService>();
builder.Services.AddScoped<IModelService<Image, int>, ImageService>();
builder.Services.AddScoped<IModelService<Importance, int>, ImportanceService>();
builder.Services.AddScoped<IModelService<Noeud, int>, NoeudService>();
builder.Services.AddScoped<IModelService<Page, int>, PageService>();
builder.Services.AddScoped<IModelService<Professeur, string>, ProfesseurService>();
builder.Services.AddScoped<IModelService<Reference, int>, ReferenceService>();
builder.Services.AddScoped<IModelService<TexteFormater, int>, TexteFormaterService>();
builder.Services.AddScoped<IModelService<Video, int>, VideoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
