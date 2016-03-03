using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AspNet5Example.Services;
using AspNet5Example.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNet5Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly IViewModelService _viewModelService;
        public HomeController(IViewModelService viewModelService)
        {
            this._viewModelService = viewModelService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = "Fish tank dashboard app";
            return View(_viewModelService.GetDashboardViewModel());
        }

        public IActionResult Feed(int foodAmount)
        {
            DashboardViewModel model = _viewModelService.GetDashboardViewModel();
            model.LastFed = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}. Amount: {foodAmount}";
            return View("Index", model);
        }
    }
}