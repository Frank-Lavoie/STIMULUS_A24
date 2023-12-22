using STIMULUS_V2.Client.Services;
using STIMULUS_V2.Client.Shared.NoeudComponents;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Client
{
    public class AppState
    {
        public List<Noeud_Etudiant> NoeudEtudiant { get; set; } = new List<Noeud_Etudiant>();
    }
}
