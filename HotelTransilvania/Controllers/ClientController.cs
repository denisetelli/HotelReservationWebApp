using System.Threading.Tasks;
using Business.Services.Interfaces;
using Business.Validators;
using Commom.DTOs;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace HotelTransilvania.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IToastNotification _toastNotification;

        public ClientController(IClientService clientService, IToastNotification toastNotification)
        {
            _clientService = clientService;
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_clientService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string name)
        {
            ViewData["CurrentFilter"] = name;
            var client = _clientService.FindByName(name);
            return View(client);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientDTO client)
        {
            if (!IsDocumentValid(client, out string errorMsg))
            {
                ViewData["ErrorMessage"] = errorMsg;
                return View(client);
            }

            _clientService.Add(client);
            return RedirectToAction("Index", client);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_clientService.FindById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientDTO client)
        {
            if (!IsDocumentValid(client, out string errorMsg))
            {
                ViewData["ErrorMessage"] = errorMsg;
                return View(client);
            }

            _clientService.Edit(client);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (_clientService.Delete(id))
            {
                return RedirectToAction("Index");
            }
            _toastNotification.AddErrorToastMessage("Não foi possível apagar este cliente.", new ToastrOptions() { Title = "Oops" });
            return RedirectToAction("Index");
        }

        public bool IsDocumentValid(ClientDTO client, out string errorMessage)
        {
            errorMessage = string.Empty;

            //if the docs exist in th DB, do NOT add user
            if (_clientService.IsDocAlreadyRegistered(client))
            {
                if (client.Type == Commom.Enums.ClientTypeEnum.Person)
                {
                    errorMessage = "CPF já cadastrado para outro cliente.";
                }
                else if (client.Type == Commom.Enums.ClientTypeEnum.Organization)
                {
                    errorMessage = "CNPJ já cadastrado para outro cliente.";
                }

                return false;
            }

            //check if the docs are valid (last digits check)
            IDocValidator docValidator = DocValidatorFactory.Create(client.Type);

            if (!docValidator.ValidateDoc(client))
            {
                errorMessage = "Documento inválido";
                return false;
            }

            return true;
        }
    }
}