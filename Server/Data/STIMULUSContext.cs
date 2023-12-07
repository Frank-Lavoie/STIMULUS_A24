using Microsoft.EntityFrameworkCore;
using Serilog;
using STIMULUS_V2.Shared.Models.Authentication;
using STIMULUS_V2.Shared.Models.Entities;


namespace STIMULUS_V2.Server.Data
{
    public class STIMULUSContext : DbContext
    {
        public STIMULUSContext(DbContextOptions<STIMULUSContext> options) : base(options)
        {

        }    
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etudiant>().ToTable("Etudiant");
            modelBuilder.Entity<Professeur>().ToTable("Professeur");
            modelBuilder.Entity<Admin>().ToTable("Admin");
        }

        public void EnsureAdminUserCreated()
        {
            if (!Admin.Any())
            {
                var password = "admin";
                // Aucun compte administrateur n'existe, créer un par défaut
                var admin = new Admin
                {
                    // Ajoutez les propriétés nécessaires pour le compte administrateur
                    Identifiant = "admin",
                    Nom = "Admin",
                    Prenom = "Admin",
                    Email = "admin@example.com",
                    MotDePasse = BCrypt.Net.BCrypt.HashPassword(password), // N'oubliez pas de hasher le mot de passe dans un scénario de production
                    Role = "ADMIN"
                };

                // Ajoutez le compte administrateur à la base de données
                Admin.Add(admin);
                SaveChanges();
            }
        }

        public void EnsureProfUserCreated()
        {
            if (!Professeur.Any())
            {
                var password = "prof";
                var professeur = new Professeur
                {
                    Identifiant = "prof",
                    Nom = "Prof",
                    Prenom = "Prof",
                    Email = "prof@cegepjonquiere.ca",
                    MotDePasse = BCrypt.Net.BCrypt.HashPassword(password), 
                    Role = "PROFESSEUR"
                };

                Professeur.Add(professeur);
                SaveChanges();
            }
        }

        public void EnsureEtuUserCreated()
        {
            if (!Etudiant.Any())
            {
                var password = "etu";
                var etudiant = new Etudiant
                {
                    Identifiant = "etu",
                    Nom = "Etu",
                    Prenom = "Etu",
                    Email = "etu@etu.cegepjonquiere.ca",
                    MotDePasse = BCrypt.Net.BCrypt.HashPassword(password),
                    Role = "ETUDIANT"
                };

                Etudiant.Add(etudiant);
                SaveChanges();
            }
        }

        public DbSet<Code> Code { get; set; }
        public DbSet<Composant> Composant { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<Etudiant> Etudiant { get; set; }
        public DbSet<Exercice> Exercice { get; set; }
        public DbSet<FichierSauvegarde> FichierSauvegarde { get; set; }
        public DbSet<FichierSource> FichierSource { get; set; }
        public DbSet<Graphe> Graphe { get; set; }
        public DbSet<Groupe> Groupe { get; set; }
        public DbSet<Groupe_Etudiant> Groupe_Etudiant { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Importance> Importance { get; set; }
        public DbSet<Noeud> Noeud { get; set; }
        public DbSet<Noeud_Etudiant> Noeud_Etudiant { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<Page_Etudiant> Page_Etudiant { get; set; }
        public DbSet<Professeur> Professeur { get; set; }
        public DbSet<Reference> Reference { get; set; }
        public DbSet<TexteFormater> TexteFormater { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Utilisateur> Utilisateur { get; set; }
        public DbSet<TokenInfo> TokenInfo { get; set; }
        public DbSet<Admin> Admin { get; set; }
    }
}
