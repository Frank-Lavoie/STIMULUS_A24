using STIMULUS_V2.Shared.Interface.ParentInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Interface.ChildInterface
{
    public interface INoeudEtudiantService : IModelService<Noeud_Etudiant, int>
    {
        Task<APIResponse<IEnumerable<Noeud_Etudiant>>> GetAllNoeudForStudent(string id);

        Task<APIResponse<Noeud_Etudiant>> GetByNoeudId(int id);
        Task<APIResponse<Noeud_Etudiant>> GetByNoeudAndDa(int id, string da);
    }
}
