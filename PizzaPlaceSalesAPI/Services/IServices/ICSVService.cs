namespace PizzaPlaceSalesAPI.Services.IServices
{
    public interface ICSVService
    {
        public IEnumerable<T> ReadCSV<T>(Stream file);
    }
}
