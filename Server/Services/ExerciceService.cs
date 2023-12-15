using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Renci.SshNet;
using Serilog;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Web;

namespace STIMULUS_V2.Server.Services
{
    public class ExerciceService : IExerciceService
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public ExerciceService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<Exercice>> Create(Exercice item)
        {
            try
            {
                sTIMULUSContext.Exercice.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Exercice.Contains(item))
                {
                    return new APIResponse<Exercice>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Exercice>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Exercice>(null, 500, $"Erreur lors de la création du model : {typeof(Exercice).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<string>> ExecuteCode(string da, string json)
        {
            try
            {
                DirectoryInfo dossier;
                string path = "Python/" + da;
                bool status = false;
                List<string> filenames = new List<string>();
                json = Uri.UnescapeDataString(json);

                if (!Directory.Exists(path))
                    dossier = Directory.CreateDirectory(path);

                JArray objetJson = JArray.Parse(json);
                foreach (var obj in objetJson)
                {
                    string name = (string)obj["Nom"];
                    string code = (string)obj["Contenu"];
                    StreamWriter fichier = new StreamWriter($"{path}/{name}");
                    fichier.Write(code);
                    fichier.Close();

                    filenames.Add(name);
                }

                var upload = await Upload_Code(da, filenames);
                if (!upload)
                    throw new Exception("Les fichiers n'ont pas pu être téléversé");

                string main = path + $"/output_{da}.txt";
                string file = "";

                using (StreamReader sr = new StreamReader(main))
                {
                    int nombreLignes = 1;
                    string ligne;

                    while ((ligne = sr.ReadLine()) != null)
                    {
                        file += ligne + "\n";
                        nombreLignes++;
                        if (nombreLignes == 25)
                        {
                            file += "Arrêt de la lecture : Nombre d'affichage trop important\nEst-il possible qu'il y ait une boucle infinie ?";
                            return new APIResponse<string>(file, 206, "Boucle détecté");
                        }
                    }
                }

                if (String.IsNullOrEmpty(file))
                    file = "Le code n'affiche pas de sortie";
                return new APIResponse<string>(file, 200, "Fichier récupéré avec succès");
            }
            catch (Exception ex)
            {
                return new APIResponse<string>(null, 500, $"Erreur lors de l'execution du code. Message : {ex.Message}");
            }
        }

        private async Task<bool> Upload_Code(string id, List<string> filenames)
        {
            string host = "10.10.10.100";
            string username = "tech";
            string password = "jambon1723!";

            int rand = new Random().Next(0, 99999);
            string name = $"interpreteur_{id}_{rand}";

            string localOutput = $"Python/{id}/output_{id}.txt";
            string remoteOutput = $"{name}/output_{name}.txt";

            try
            {
                using (SshClient client = new SshClient(host, username, password))
                {
                    client.Connect();
                    client.RunCommand($"cp -r base/ {name}/");

                    using (var scp = new ScpClient(client.ConnectionInfo))
                    {
                        scp.Connect();

                        foreach (var names in filenames)
                        {
                            using (var fileStream = new FileStream($"Python/{id}/{names}", FileMode.Open))
                            {
                                scp.Upload(fileStream, $"{name}/upload/{names}");
                            }
                        }

                        client.RunCommand($"cd {name} && ./start.sh {name}");

                        using (var fileStream = System.IO.File.Create(localOutput))
                        {
                            scp.Download(remoteOutput, fileStream);
                        }

                        scp.Disconnect();
                    }

                    client.RunCommand($"rm -rf {name}");
                    client.Disconnect();
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.Exercice.Where(item => item.ExerciceId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Exercice.FindAsync(id);
                    sTIMULUSContext.Exercice.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Exercice).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Exercice).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Exercice).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Exercice>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Exercice.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Exercice>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Exercice>(null, 404, $"{typeof(Exercice).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Exercice>(null, 500, $"Erreur lors de la récupération du model {typeof(Exercice).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Exercice>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.Exercice.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Exercice>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Exercice>>(null, 404, $"{typeof(Exercice).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Exercice>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Exercice).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Exercice>>> GetAllById(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Exercice.Where(item => item.ExerciceId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Exercice>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Exercice>>(null, 404, $"{typeof(Exercice).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Exercice>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Exercice).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<Exercice>> Update(int id, Exercice item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Exercice.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Exercice>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Exercice>(null, 404, $"{typeof(Exercice).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Exercice>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Exercice).Name}. Message : {ex.Message}.");
            }
        }
    }
}
