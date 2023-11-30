using STIMULUS_V2.Shared.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Interface.ChildInterface
{
    public interface IPageEtudiantService
    {
        Task<APIResponse<double>> CalculerPourcentage(int groupeId, string codeDa, string professeurIdentifiant);
    }
}
