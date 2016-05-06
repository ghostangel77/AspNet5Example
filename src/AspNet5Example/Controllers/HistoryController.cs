using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AspNet5Example.ViewModels;

namespace AspNet5Example.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult GetWaterTemperatureChart()
        {
            return View("Chart", new ChartViewModel
            {
                Title = "Water Temperature",
                DataUrl = Url.Action("GetWaterTemperatureFahrenheitHistory", "HistoryData")
            });
        }

        public IActionResult GetWaterOpacityChart()
        {
            return View("Chart", new ChartViewModel
            {
                Title = "Water Opacity",
                DataUrl = Url.Action("GetWaterOpacityPercentageHistory", "HistoryData")
            });
        }

        public IActionResult GetFishMotionChart()
        {
            return View("Chart", new ChartViewModel
            {
                Title = "Fish Motion",
                DataUrl = Url.Action("GetFishMotionPercentageHistory", "HistoryData")
            });
        }

        public IActionResult GetLightIntensityLumensChart()
        {
            return View("Chart", new ChartViewModel
            {
                Title = "Light Intensity",
                DataUrl = Url.Action("GetLightIntensityLumensHistory", "HistoryData")
            });
        }
    }
}