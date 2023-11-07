using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using Serilog;
using STIMULUS_V2.Shared.Interface.ChildInterface;
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

builder.Services.AddScoped<ICodeService, CodeService>();
builder.Services.AddScoped<IComposantService, ComposantService>();
builder.Services.AddScoped<ICoursService, CoursService>();
builder.Services.AddScoped<IEtudiantService, EtudiantService>();
builder.Services.AddScoped<IExerciceService, ExerciceService>();
builder.Services.AddScoped<IFichierSauvegardeService, FichierSauvegardeService>();
builder.Services.AddScoped<IFichierSourceService, FichierSourceService>();
builder.Services.AddScoped<IGrapheService, GrapheService>();
builder.Services.AddScoped<IGroupeService, GroupeService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IImportanceService, ImportanceService>();
builder.Services.AddScoped<INoeudService, NoeudService>();
builder.Services.AddScoped<IPageService, PageService>();
builder.Services.AddScoped<IProfesseurService, ProfesseurService>();
builder.Services.AddScoped<IReferenceService, ReferenceService>();
builder.Services.AddScoped<ITexteFormaterService, TexteFormaterService>();
builder.Services.AddScoped<IVideoService, VideoService>();


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
