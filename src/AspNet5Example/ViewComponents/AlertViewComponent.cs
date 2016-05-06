using AspNet5Example.Options;
using AspNet5Example.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5Example.ViewComponents
{
    public class AlertViewComponent : ViewComponent
    {
        private ISensorDataService _sensorDataService;
        private ThresholdOptions _thresholdConfig;

        public AlertViewComponent(ISensorDataService sensorDataService, IOptions<ThresholdOptions> thresholdConfig)
        {
            this._sensorDataService = sensorDataService;
            this._thresholdConfig = thresholdConfig.Value;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new List<string>();

            if (_sensorDataService.GetFishMotionPercentage().Value > _thresholdConfig.FishMotionMax)
                viewModel.Add("Too much fish activity");
            if (_sensorDataService.GetFishMotionPercentage().Value < _thresholdConfig.FishMotionMin)
                viewModel.Add("Looks like we have some dead fish");

            if (_sensorDataService.GetLightIntensityLumens().Value > _thresholdConfig.LightIntensityMax)
                viewModel.Add("Bright light, bright light!");
            if (_sensorDataService.GetLightIntensityLumens().Value < _thresholdConfig.LightIntensityMin)
                viewModel.Add("It's dark out here");

            if (_sensorDataService.GetWaterOpacityPercentage().Value > _thresholdConfig.WaterOpacityMax)
                viewModel.Add("The fish can't see you");
            if (_sensorDataService.GetWaterOpacityPercentage().Value < _thresholdConfig.WaterOpacityMin)
                viewModel.Add("Water too clean");

            if (_sensorDataService.GetWaterTemperatureFahrenheit().Value > _thresholdConfig.WaterTemperatureMax)
                viewModel.Add("Water too hot!");
            if (_sensorDataService.GetWaterTemperatureFahrenheit().Value < _thresholdConfig.WaterTemperatureMin)
                viewModel.Add("Water too cold!");

            return View(viewModel);
        }
    }
}