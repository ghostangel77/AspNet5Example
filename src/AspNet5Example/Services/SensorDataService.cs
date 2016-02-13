﻿using AspNet5Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5Example.Services
{
    public class SensorDataService : ISensorDataService
    {
        private readonly Random random = new Random();
        private IEnumerable<IntHistoryModel> waterTemperatureHistory;
        private IEnumerable<IntHistoryModel> fishMotionHistory;
        private IEnumerable<IntHistoryModel> waterOpacityHistory;
        private IEnumerable<IntHistoryModel> lightOpacityHistory;


        public IntHistoryModel GetWaterTemperatureFahrenheit()
        {
            return GetWaterTemperatureFahrenheitHistory().Last();
        }

        public IEnumerable<IntHistoryModel> GetWaterTemperatureFahrenheitHistory()
        {
            return waterTemperatureHistory ?? (waterTemperatureHistory = GetHistory(70, 90));
        }


        public IntHistoryModel GetFishMotionPercentage()
        {
            return GetFishMotionPercentageHistory().Last();
        }

        public IEnumerable<IntHistoryModel> GetFishMotionPercentageHistory()
        {
            return fishMotionHistory ?? (fishMotionHistory = GetHistory(0, 100));
        }


        public IntHistoryModel GetWaterOpacityPercentage()
        {
            return GetWaterOpacityPercentageHistory().Last();
        }

        public IEnumerable<IntHistoryModel> GetWaterOpacityPercentageHistory()
        {
            return waterOpacityHistory ?? (waterOpacityHistory = GetHistory(0, 100));
        }


        public IntHistoryModel GetLightIntensityLumens()
        {
            return GetLightIntensityLumensHistory().Last();
        }

        public IEnumerable<IntHistoryModel> GetLightIntensityLumensHistory()
        {
            return lightOpacityHistory ?? (lightOpacityHistory = GetHistory(0, 5000));
        }


        private IEnumerable<IntHistoryModel> GetHistory(int min, int max)
        {
            var result = new List<IntHistoryModel>();
            for (int i = -10; i < 1; i++)
            {
                result.Add(new IntHistoryModel(DateTime.Now.AddHours(i), random.Next(min, max)));
            }
            return result;
        }
    }
}
