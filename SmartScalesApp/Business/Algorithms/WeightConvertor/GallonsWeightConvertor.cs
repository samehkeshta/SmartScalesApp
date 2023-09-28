namespace SmartScalesApp.Business.Algorithms.WeightConvertor
{
    public class GallonsWeightConvertor : IWeightConvertor
    {
        private const double PoundsInAGallon = 14;

        public decimal ConvertFromPounds(decimal weightInPounds)
        {
            return weightInPounds / ((decimal)PoundsInAGallon);
        }

        public decimal ConvertToPounds(decimal weight)
        {
            return (weight * (decimal)PoundsInAGallon);
        }
    }
}