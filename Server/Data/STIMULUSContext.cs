using Microsoft.EntityFrameworkCore;
using STIMULUS.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Data
{
    public class STIMULUSContext : DbContext
    {
        public STIMULUSContext(DbContextOptions<STIMULUSContext> options) : base(options)
        {

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
        public DbSet<LienUtile> LienUtile { get; set; }
        public DbSet<Noeud> Noeud { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<Page_Etudiant> Page_Etudiant { get; set; }
        public DbSet<Professeur> Professeur { get; set; }
        public DbSet<Reference> Reference { get; set; }
        public DbSet<StatusGraphe> StatusGraphe { get; set; }
        public DbSet<TexteFormater> TexteFormater { get; set; }
        public DbSet<Video> Video { get; set; }
    }
}
