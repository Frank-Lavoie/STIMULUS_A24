using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using STIMULUS_V2.Client;
using STIMULUS_V2.Client.CustomAuthentication;
using STIMULUS_V2.Client.Services;
using STIMULUS_V2.Client.Services.AuthenticationService;
using STIMULUS_V2.Shared.Interface.ChildInterface;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddBlazoredLocalStorage();
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
builder.Services.AddScoped<IPageEtudiantService, PageEtudiantService>();
builder.Services.AddScoped<INoeudEtudiantService, NoeudEtudiantService>();

builder.Services.AddSingleton<IUpdateService, UpdateService>();
builder.Services
            .AddSingleton<MouseService>()
            .AddSingleton<IMouseService>(ff => ff.GetRequiredService<MouseService>());
builder.Services.AddSingleton<AppState>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ICoursService, CoursService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<RerenderService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();
