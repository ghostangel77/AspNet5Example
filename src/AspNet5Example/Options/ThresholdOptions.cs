using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5Example.Options
{
    public class ThresholdOptions
    {
        public int FishMotionMax { get; set; }
        public int FishMotionMin { get; set; }
        public int LightIntensityMax { get; set; }
        public int LightIntensityMin { get; set; }
        public int WaterOpacityMax { get; set; }
        public int WaterOpacityMin { get; set; }
        public int WaterTemperatureMax { get; set; }
        public int WaterTemperatureMin { get; set; }
    }
}