using AspNet5Example.Models;
using AspNet5Example.Services;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5Example.Controllers.api
{
    public class HistoryDataController : Controller
    {
        private readonly ISensorDataService _sensorDataService;

        public HistoryDataController(ISensorDataService sensorDataService)
        {
            this._sensorDataService = sensorDataService;
        }


        public IEnumerable<IntHistoryModel> GetWaterTemperatureFahrenheitHistory()
        {
            return _sensorDataService.GetWaterTemperatureFahrenheitHistory();
        }

        public IEnumerable<IntHistoryModel> GetWaterOpacityPercentageHistory()
        {
            return _sensorDataService.GetWaterOpacityPercentageHistory();
        }

        public IEnumerable<IntHistoryModel> GetFishMotionPercentageHistory()
        {
            return _sensorDataService.GetFishMotionPercentageHistory();
        }

        public IEnumerable<IntHistoryModel> GetLightIntensityLumensHistory()
        {
            return _sensorDataService.GetLightIntensityLumensHistory();
        }
    }
}
