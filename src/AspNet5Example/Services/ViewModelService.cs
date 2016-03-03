using AspNet5Example.ViewModels;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5Example.Services
{
    public class ViewModelService : IViewModelService
    {
        private readonly ISensorDataService _sensorDataService;
        private readonly IUrlHelper _urlHelper;


        public ViewModelService(ISensorDataService sensorDataService, IUrlHelper urlHelper)
        {
            this._sensorDataService = sensorDataService;
            this._urlHelper = urlHelper;
        }


        public DashboardViewModel GetDashboardViewModel()
        {
            return new DashboardViewModel
            {
                WaterTemperatureTile = new SensorTileViewModel {
                    Title = "Water temperature",
                    Value = _sensorDataService.GetWaterTemperatureFahrenheit().Value,
                    ColorCssClass = "panel-primary",
                    IconCssClass = "fa-sliders",
                    Url = _urlHelper.Action("GetWaterTemperatureChart","History")
                },
                WaterOpacityTile = new SensorTileViewModel
                {
                    Title = "Water opacity",
                    Value = _sensorDataService.GetWaterOpacityPercentage().Value,
                    ColorCssClass = "panel-info",
                    IconCssClass = "fa-adjust",
                    Url = _urlHelper.Action("GetWaterOpacityChart", "History")
                },
                LightIntensityTile = new SensorTileViewModel
                {
                    Title = "Light intensity",
                    Value = _sensorDataService.GetLightIntensityLumens().Value,
                    ColorCssClass = "panel-danger",
                    IconCssClass = "fa-lightbulb-o",
                    Url = _urlHelper.Action("GetLightIntensityLumensChart", "History")
                },
                FishMotionTile = new SensorTileViewModel
                {
                    Title = "Fish motion",
                    Value = _sensorDataService.GetFishMotionPercentage().Value,
                    ColorCssClass = "panel-success",
                    IconCssClass = "fa-sliders",
                    Url = _urlHelper.Action("GetWaterTemperatureChart", "History")
                }
            };
        }
    }
}
