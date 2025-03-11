namespace Dependency_Injection.Services
{
    public interface IRandomNumberService
    {
        int GetRandomNumber();
    }
    public class RandomNumberService : IRandomNumberService
    {
        private readonly int _random;
        public RandomNumberService()
        {
            _random =   new Random().Next(1, 100);
        }
        public int GetRandomNumber()
        {
            return _random;
        }
    }
}
