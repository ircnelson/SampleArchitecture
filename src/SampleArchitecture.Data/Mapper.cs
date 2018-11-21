namespace SampleArchitecture.Data
{
    public class Mapper
    {
        public static T Map<T>(dynamic input)
        {
            var mappy = new Mappy.Mappy();
            
            return mappy.Map<T>(input);
        }
    }
}