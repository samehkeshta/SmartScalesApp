using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Business.Algorithms.WeightConvertor
{
    public class WeightConvertorFactory
    {
        public static IWeightConvertor GetWeightConvertor(WeightMeasure weightMeasure)
        {
            return weightMeasure switch
            {
                WeightMeasure.Stones => new StonesWeightConvertor(),
                WeightMeasure.Kilograms => new KilogramsWeightConvertor(),
                WeightMeasure.Gallons => new GallonsWeightConvertor(),
                WeightMeasure.Pounds => new PoundsWeightConvertor(),
                _ => new PoundsWeightConvertor(),
            };
        }
    }
}