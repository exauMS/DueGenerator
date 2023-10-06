using DueWebApp.Dto;
using DueWebApp.Interfaces;
using DueWebApp.Models;
using DueWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Aspose.Words;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace DueWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static string? token;
        private User? currentUser;
        private readonly IUser userService;
        private readonly IMemoryCache memoryCache;
        private readonly IDepartement departementService;
        private readonly ICursus cursusService;
        private readonly IUE uEService;
        private readonly IAA aAService;
        private readonly ICompetence competenceService;
        private readonly ICapacite capaciteService;
        private readonly IFiche ficheService;
        private DateTime dateTime;

        public HomeController(ILogger<HomeController> logger, IUser userService, IMemoryCache memoryCache, IDepartement departementService, ICursus cursusService, IUE uEService, IAA aAService, ICompetence competenceService, ICapacite capaciteService, IFiche ficheService)
        {
            _logger = logger;
            this.userService = userService;
            this.memoryCache = memoryCache;
            this.departementService = departementService;
            this.cursusService = cursusService;
            this.uEService = uEService;
            this.aAService = aAService;
            this.competenceService = competenceService;
            this.capaciteService = capaciteService;
            this.ficheService = ficheService;
            dateTime = DateTime.UtcNow.AddMinutes(10);
        }

        public IActionResult Index()
        {
            
            if (memoryCache.Get("Token") != null)
            {
                return View("~/Views/Home/Profile.cshtml", memoryCache.Get("CurrentUser"));
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Admin()
        {
            if (memoryCache.Get("Token") != null)
            {
                currentUser = (User)memoryCache.Get("CurrentUser");
                if (currentUser.Role == "admin")
                {
                    List<User> users = await userService.GetUsers(memoryCache.Get("Token").ToString());
                    List<Departement> departements = await departementService.GetDepartements();
                    List<Cursus> cursus = await cursusService.GetCursus();
                    List<UE> ue = await uEService.GetUE();
                    List<Competence> competences = await competenceService.GetCompetences();
                    List<AA> aa = await aAService.GetAA();
                    AdminAccess adminAccess = new AdminAccess
                    {
                        Users = users,
                        Departements = departements,
                        Cursus = cursus,
                        UE = ue,
                        Competences = competences,
                        AA = aa,

                    };
                    memoryCache.Set("AdminAccess", adminAccess, new DateTimeOffset(dateTime));
                    adminAccess = (AdminAccess)memoryCache.Get("AdminAccess");
                    return View("~/Views/Home/Admin.cshtml", adminAccess);
                }


                TempData["Alert"] = "Only Administrators are allowed!";
                return View("~/Views/Home/Profile.cshtml", currentUser);
            }
            return View("~/Views/Home/Index.cshtml");
        }

        public async Task<IActionResult> Login(Login login)
        {
            List<User>? users=null;
            var dateTime = DateTime.UtcNow.AddMinutes(10);
            if (!memoryCache.TryGetValue("Token", out string? token))
            {
                try
                {
                    token = await userService.GetToken(login);
                }
                catch (Exception ex)
                {

                    TempData["Alert"] = ex.Message;
                    return Unauthorized();
                }
               
                memoryCache.Set("Token", token, new DateTimeOffset(dateTime));
            }

            try
            {
                users = await userService.GetUsers(token);
            }
            catch (Exception ex)
            {

                TempData["Alert"] = ex.Message;

            }
           

            if (token != null)
            {

                foreach (User user in users)
                {
                    if (user.Email == login.Email)
                    {


                        currentUser = user;
                        currentUser.Token = token;
                        memoryCache.Set("CurrentUser", currentUser, new DateTimeOffset(dateTime));


                    }
                }


                return View("~/Views/Home/Profile.cshtml", currentUser);
            }

            return View("~/Views/Home/Index.cshtml");

        }

        public async Task<IActionResult> AddUser(IFormCollection form)
        {

            List<User>? users = await userService.GetUsers(memoryCache.Get("Token").ToString());
            string username = form["UserName"];
            string email = form["Email"];
            string password = form["Password"];
            string role = form["Role"];
            UserDto user = new UserDto();



            user.Role = role;
            user.UserName = username;
            user.Email = email;
            user.Password = password;


            if (memoryCache.Get("Token") != null)
            {

                foreach (User u in users)
                {
                    if (u.UserName == username)
                    {
                        TempData["Alert"] = "User Already Exists.";
                        return View("~/Views/Home/Admin.cshtml");
                    }
                }
                var response = await userService.PostUser(user, memoryCache.Get("Token").ToString());
                TempData["Alert"] = response;


                return await Admin();
            }

            return BadRequest();

        }

        public async Task<IActionResult> DeleteUser(IFormCollection form)
        {
            
            List<User>? users = await userService.GetUsers(memoryCache.Get("Token").ToString());
            string username = form["UserDelete"];


            if (memoryCache.Get("Token") != null)
            {

                foreach (User u in users)
                {
                    if (u.UserName == username)
                    {
                        var response = userService.DeleteUser(u.Id, memoryCache.Get("Token").ToString());
                        TempData["Alert"] = "User deleted!";

                        return await Admin();

                    }
                }

                TempData["AlertMessage"] = "User Not Found.";

                return await Admin();
            }

            return BadRequest();

        }

        public async Task<IActionResult> CreateDepartement(IFormCollection form)
        {
            string name = form["departementNom"];


            DepartementDto dep = new DepartementDto();

            dep.Nom = name;
            var response = await departementService.PostDepartement(dep);
            TempData["Alert"] = "Departement Created.";
            return await Admin();

        }

        public async Task<IActionResult> CreateCursus(IFormCollection form)
        {
            List<Departement>? departements = await departementService.GetDepartements();
            string name = form["Nom"];
            string implantation = form["Implantation"];
            string tel = form["Tel"];
            string choixDepartement = form["Departement"];

            CursusDto cursus = new CursusDto();
            cursus.Name = name;
            cursus.Implentation = implantation;
            cursus.Telephone = tel;



            if (memoryCache.Get("Token") != null)
            {

                foreach (Departement d in departements)
                {
                    if (d.Nom == choixDepartement)
                    {
                        cursus.DepartementId = d.Id;
                        var response = await cursusService.PostCursus(cursus);
                        TempData["Alert"] = "Cursus Created.";
                        return await Admin();

                    }
                }
                TempData["AlertMessage"] = "Something went wrong.";

                return await Admin();
            }

            return BadRequest();

        }

        public async Task<IActionResult> CreateUE(IFormCollection form)
        {
            List<Cursus>? cursusList = await cursusService.GetCursus();
            string name = form["Nom"];
            string code = form["Code"];
            string cursus = form["Cursus"];

            UEDto ue = new UEDto();


            ue.Nom = name;
            ue.Code = code;


            if (memoryCache.Get("Token") != null)
            {

                foreach (Cursus c in cursusList)
                {
                    if (c.Name == cursus)
                    {
                        ue.CursusId = c.Id;
                        var response = await uEService.PostUE(ue);

                        TempData["Alert"] = "UE Created.";
                        return await Admin();

                    }
                }
                TempData["Alert"] = "Something went wrong.";

                return await Admin();
            }

            return BadRequest();

        }

        public async Task<IActionResult> CreateAA(IFormCollection form)
        {
            string name = form["Nom"];
            string prof = form["Professeur"];


            AADto aa = new AADto();

            if (memoryCache.Get("Token") != null)
            {

                aa.Nom = name;
                aa.Professeur = prof;
                var response = await aAService.PostAA(aa);

                TempData["Alert"] = "AA Created.";
                return await Admin();

            }

            return BadRequest();

        }

        public async Task<IActionResult> CreateCompetence(IFormCollection form)
        {
            string nom = form["Nom"];


            CompetenceDto competence = new CompetenceDto();

            competence.Nom = nom;
            var response = await competenceService.PostCompetence(competence);

            TempData["Alert"] = "Competence Created.";
            return await Admin();
        }

        public async Task<IActionResult> CreateCapacite(IFormCollection form)
        {
            List<Competence>? competences = await competenceService.GetCompetences();
            string description = form["Capacite"];
            string competence = form["Competence"];

            CapaciteDto capacite = new CapaciteDto();

            capacite.Description = description;


            if (memoryCache.Get("Token") != null)
            {

                foreach (Competence c in competences)
                {
                    if (c.Nom == competence)
                    {
                        capacite.CompetenceId = c.Id;
                        var response = await capaciteService.PostCapacite(capacite);

                        TempData["Alert"] = "Capacite Created.";
                        return await Admin();

                    }
                }
                TempData["Alert"] = "Something went wrong.";

                return await Admin();
            }

            return BadRequest();

        }

        public async Task<IActionResult> Fiche()
        {
            if (memoryCache.Get("Token") != null)
            {
                currentUser = (User)memoryCache.Get("CurrentUser");

                List<User> users = await userService.GetUsers(memoryCache.Get("Token").ToString());
                List<Departement> departements = await departementService.GetDepartements();
                List<Cursus> cursus = await cursusService.GetCursus();
                List<UE> ue = await uEService.GetUE();
                List<Competence> competences = await competenceService.GetCompetences();
                List<AA> aa = await aAService.GetAA();
                AdminAccess adminAccess = new AdminAccess
                {
                    Users = users,
                    Departements = departements,
                    Cursus = cursus,
                    UE = ue,
                    Competences = competences,
                    AA = aa,

                };
                memoryCache.Set("AdminAccess", adminAccess, new DateTimeOffset(dateTime));
                adminAccess = (AdminAccess)memoryCache.Get("AdminAccess");
                return View("~/Views/Home/Fiche.cshtml", adminAccess);

            }
            return View();
        }

        public async Task<IActionResult> FicheTraitement(IFormCollection form)
        {
            Fiche fiche = new Fiche();

            var listUE = await uEService.GetUE();
            var listCursus = await cursusService.GetCursus();
            var listAA = await aAService.GetAA();
            var listCompetence = await competenceService.GetCompetences();
            var listCapacite = await capaciteService.GetCapacite();

            fiche.Annee = form["Annee"];
            foreach (var ue in listUE)
            {
                if (form["UE"] == ue.Nom)
                {
                    fiche.Titre = ue.Nom;
                    fiche.Code = ue.Code;
                }
            }

            fiche.Departement = form["Departement"];

            foreach (var cu in listCursus)
            {
                if (form["Cursus"] == cu.Name)
                {
                    fiche.Cursus = cu.Name;
                    fiche.Implantation = cu.Implentation;
                    fiche.NumSecretariat = cu.Telephone;
                }
            }

            foreach (var cu in listCursus)
            {
                if (form["Cursus"] == cu.Name)
                {
                    fiche.Cursus = cu.Name;
                    fiche.Implantation = cu.Implentation;
                    fiche.NumSecretariat = cu.Telephone;
                }
            }
            fiche.Orientation = form["Orientation"];
            fiche.Cycle = form["Cycle"];
            fiche.Bloc = form["Bloc"];
            fiche.Quadrimestre = form["Quadri"];
            fiche.NiveauCertification = form["Certification"];
            fiche.UEPrerequis = form["Prerequis"];
            fiche.UECorequis = form["Corequis"];
            fiche.VolHoraire = form["Heures"];
            fiche.Ects = form["Ects"];
            fiche.LangueEnseignement = form["LangueEn"];
            fiche.LangueEvaluation = form["LangueEv"];
            fiche.ResponsableUE = form["ResponsableUE"];
            fiche.TitulaireAA = form["AA"];

            foreach (var co in listCompetence)
            {
                if (form["Competence"] == co.Nom)
                {
                    fiche.Competences = form["Competence"];
                    foreach (var ca in listCapacite)
                    {
                        if (ca.CompetenceId == co.Id)
                        {
                            fiche.Capacites += "* " + ca.Description + "\n";
                        }
                    }

                }
            }

            fiche.Acquis = form["Acquis"];
            fiche.ContenuSynthetique = form["ContenuSynth"];
            fiche.MethodeApprentissage = form["MethodeApp"];
            fiche.SupportCours = form["SupportCours"];
            fiche.TypeEvaluation = form["TypeEval"];
            fiche.CalculNote = form["CalculNote"];


            var response = await ficheService.PostFiche(fiche);
            TempData["Alert"] = "Fiche saved. Check it on download page.";
            return await Fiche();
        }

        public async Task<IActionResult> Download()
        {
            if (memoryCache.Get("Token") != null)
            {
                currentUser = (User)memoryCache.Get("CurrentUser");


                List<Fiche> fiches = await ficheService.GetFiches();
                AdminAccess adminAccess = new AdminAccess
                {
                    Fiches = fiches,
                    FilterFiches = fiches,

                };
                memoryCache.Set("AdminAccess", adminAccess, new DateTimeOffset(dateTime));
                adminAccess = (AdminAccess)memoryCache.Get("AdminAccess");
                return View("~/Views/Home/Download.cshtml", adminAccess);

            }
            return View("~/Views/Home/Index.cshtml");
        }

        public async Task<IActionResult> FilterFiche(IFormCollection form)
        {
            AdminAccess adminAccess = new();
            List<Fiche> fiches = await ficheService.GetFiches();
            List<Fiche> filterList = new();

            foreach (var fiche in fiches)
            {
                if (fiche.Annee == form["Filtre"])
                {
                    filterList.Add(fiche);
                }
            }
            adminAccess.Fiches = fiches;
            adminAccess.FilterFiches = filterList;
            if (filterList.Count == 0)
                adminAccess.FilterFiches = fiches;
            return View("~/Views/Home/Download.cshtml", adminAccess);
        }

        public async Task<IActionResult> GenerateFiche(IFormCollection form, IFormFile userFile)
        {
            List<Fiche> fiches = await ficheService.GetFiches();
            Fiche selectedFiche=null;
            string fileFinalName = "";

           
           

            foreach (var fiche in fiches)
            {
                if (fiche.Titre == form["Fiche"])
                    selectedFiche = fiche;
            }



            var fields = new string[]
            {
            "titre",
            "code",
            "departement",
            "cursus",
            "orientation",
            "implantation",
            "numero",
            "cycle",
            "bloc_étude",
            "quadrimestre",
            "niveau_certification",
            "ue_prerequis",
            "ue_corequis",
            "ects",
            "langue_enseignement",
            "langue_evaluation",
            "responsable_UE",
            "titulaires_des_AA",
            "compétences",
            "capacités",
            "acquis",
            "contenu_synth",
            "methode_app",
            "support",
            "type_eval",
            "calcul"
            };
            var values = new object[]
            {
            selectedFiche.Titre,
            selectedFiche.Code,
            selectedFiche.Departement,
            selectedFiche.Cursus,
            selectedFiche.Orientation,
            selectedFiche.Implantation,
            selectedFiche.NumSecretariat,
            selectedFiche.Cycle,
            selectedFiche.Bloc,
            selectedFiche.Quadrimestre,
            selectedFiche.NiveauCertification,
            selectedFiche.UEPrerequis,
            selectedFiche.UECorequis,
            selectedFiche.Ects,
            selectedFiche.LangueEnseignement,
            selectedFiche.LangueEvaluation,
            selectedFiche.ResponsableUE,
            selectedFiche.TitulaireAA,
            selectedFiche.Competences,
            selectedFiche.Capacites,
            selectedFiche.Acquis,
            selectedFiche.ContenuSynthetique,
            selectedFiche.MethodeApprentissage,
            selectedFiche.SupportCours,
            selectedFiche.TypeEvaluation,
            selectedFiche.CalculNote
            };

            if (userFile != null)
            {
                fileFinalName = "ficheD.docx";
                try
                {
                    string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), fileFinalName);
                    var stream = new FileStream(uploadpath, FileMode.Create);
                    userFile.CopyToAsync(stream);
                    stream.Close();
                }
                catch
                {
                    TempData["Alert"] = "File error.";
                }
            }
            else
            {
                fileFinalName = "DueTemplate.docx";
            }
            var doc = new Document(fileFinalName);
            doc.MailMerge.Execute(fields, values);
            string fileName = selectedFiche.Titre;

            if (form["Format"] == "Pdf")
            {
                doc.Save(fileName + ".pdf");
                byte[] fileBytes = System.IO.File.ReadAllBytes(fileName+".pdf");
                
                return File(fileBytes, "application/mspdf", fileName+".pdf");
            }
            else
            {
                doc.Save(fileName + ".docx");
                byte[] fileBytes = System.IO.File.ReadAllBytes(fileName + ".docx");
               
                return File(fileBytes, "application/msword", fileName + ".docx");
            }


            
        }

        public IActionResult Logout(IFormCollection form)
        {
            memoryCache.Remove("Token");
            return View("~/Views/Home/Index.cshtml");
        }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}