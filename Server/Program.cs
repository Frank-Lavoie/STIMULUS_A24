using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using Serilog;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;
using STIMULUS_V2.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using STIMULUS_V2.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICodeService, CodeService>();
builder.Services.AddScoped<IComposantService, ComposantService>();
builder.Services.AddScoped<ICoursService, CoursService>();
builder.Services.AddScoped<IEtudiantService, EtudiantService>();
builder.Services.AddScoped<IExerciceService, ExerciceService>();
builder.Services.AddScoped<IFichierSauvegardeService, FichierSauvegardeService>();
builder.Services.AddScoped<IFichierSourceService, FichierSourceService>();
builder.Services.AddScoped<IGrapheService, GrapheService>();
builder.Services.AddScoped<IGroupeService, GroupeService>();
builder.Services.AddScoped<IGroupeEtudiantService, GroupeEtudiantService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IImportanceService, ImportanceService>();
builder.Services.AddScoped<INoeudService, NoeudService>();
builder.Services.AddScoped<IPageService, PageService>();
builder.Services.AddScoped<IProfesseurService, ProfesseurService>();
builder.Services.AddScoped<IReferenceService, ReferenceService>();
builder.Services.AddScoped<ITexteFormaterService, TexteFormaterService>();
builder.Services.AddScoped<IVideoService, VideoService>();
builder.Services.AddScoped<UtilisateurFactory>();
builder.Services.AddScoped<IPageEtudiantService, PageEtudiantService>();
builder.Services.AddScoped<INoeudEtudiantService, NoeudEtudiantService>();
builder.Services.AddDbContextPool<STIMULUSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("STIMULUSConnection")));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<STIMULUSContext>();

    //context.Database.EnsureDeleted();
    //context.Database.EnsureCreated();

    context.EnsureAdminUserCreated();
    context.EnsureEtuUserCreated();
    context.EnsureProfUserCreated();


    ////Création du trigger pour changer le status de bloqué/débloqué
    //context.Database.ExecuteSqlRaw(@"
    //    CREATE TRIGGER TRG_UpdateStatus
    //    ON Noeud
    //    AFTER UPDATE
    //    AS
    //    BEGIN
    //        -- Mettre à jour le statut dans la table Noeud_Etudiant
    //        UPDATE ne
    //        SET ne.Status = n.Status
    //        FROM Noeud_Etudiant ne
    //        INNER JOIN inserted i ON ne.NoeudId = i.NoeudId 
    //        INNER JOIN deleted d ON ne.NoeudId = d.NoeudId 
    //        INNER JOIN Noeud n ON ne.NoeudId = n.NoeudId
    //        WHERE i.Status <> d.Status OR (i.Status IS NULL AND d.Status IS NOT NULL) OR (i.Status IS NOT NULL AND d.Status IS NULL);
    //    END;
    //");
    ////Création du trigger pour inséré des données dans Noeud_Etudiant
    //context.Database.ExecuteSqlRaw(@"
    //    CREATE TRIGGER TRG_AfterInsertNoeud
    //    ON Noeud
    //    AFTER INSERT
    //    AS
    //    BEGIN
    //        -- Insertion des étudiants dans Noeud_Etudiant
    //        INSERT INTO Noeud_Etudiant (NoeudId, CodeDA, Status)
    //        SELECT i.NoeudId, ge.CodeDA, i.Status
    //        FROM inserted i
    //        JOIN Graphe g ON i.GrapheId = g.GrapheId
    //        JOIN Groupe_Etudiant ge ON g.GroupeId = ge.GroupeId;
    //    END;
    //");



}

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
