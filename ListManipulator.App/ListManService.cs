using Microsoft.Extensions.Logging;

namespace ListManipulator.App
{
    public class ListManService : IListManService
    {
        private readonly IListManRepository _manRepository;
        private readonly ILogger _logger;

        public ListManService(IListManRepository manRepository, ILogger logger)
        {
            _manRepository = manRepository;
            _logger = logger;
        }

        public void Print(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                var dividedInput = _manRepository.DivideTheInput(input.Split(",").ToList());
                var finalList = _manRepository.GetFinalList(dividedInput);
                _logger.LogInformation(string.Join(", ", finalList));
            }
            else
                _logger.LogWarning("No input provided, please try again.");
        }
    }

    public interface IListManService
    {
        void Print(string input);
    }
}