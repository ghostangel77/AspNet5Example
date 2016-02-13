using System.Collections.Generic;
using AspNet5Example.Models;

namespace AspNet5Example.Services
{
    public interface ISensorDataService
    {
        IntHistoryModel GetFishMotionPercentage();
        IEnumerable<IntHistoryModel> GetFishMotionPercentageHistory();
        IntHistoryModel GetLightIntensityLumens();
        IEnumerable<IntHistoryModel> GetLightIntensityLumensHistory();
        IntHistoryModel GetWaterOpacityPercentage();
        IEnumerable<IntHistoryModel> GetWaterOpacityPercentageHistory();
        IntHistoryModel GetWaterTemperatureFahrenheit();
        IEnumerable<IntHistoryModel> GetWaterTemperatureFahrenheitHistory();
    }
}