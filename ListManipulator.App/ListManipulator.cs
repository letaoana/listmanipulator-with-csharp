using Microsoft.Extensions.Logging;

namespace ListManipulator.App
{
    public class ListManipulator
    {
        private readonly ILogger<ListManipulator> _logger;

        private List<int> NegativeNumbers { get; init; }
        private List<int> PositiveNumbers { get; init; }

        public ListManipulator()
        {
            NegativeNumbers = new List<int>();
            PositiveNumbers = new List<int>();
            _logger = CreateLogger();
        }

        private ILogger<ListManipulator> CreateLogger()
        {
            using var loggerFactory = LoggerFactory.Create(b =>
            {
                b.AddFilter("Microsoft", LogLevel.Warning)
                .AddFilter("System", LogLevel.Warning)
                .AddFilter("App.ListManipulator", LogLevel.Warning)
                .AddConsole();
            });

            return loggerFactory.CreateLogger<App.ListManipulator>();
        }

        public void PrintTheNumbers(IReadOnlyList<string> input)
        {
            if (input.Any())
            {
                DivideTheInput(input);
                var output = string.Join(", ", GetFinalList());
                _logger.LogInformation(output);
                Console.ReadLine();
            }
            else
                _logger.LogWarning("No input provided, please try again.");
        }

        private List<string> GetFinalList()
        {
            var finalList = new List<string>();
            if (NegativeNumbers.Any())
            {
                foreach (int num in NegativeNumbers)
                    finalList.Add(num.ToString());
                if (PositiveNumbers.Any())
                {
                    finalList.Add("|");
                    foreach (int num in PositiveNumbers)
                        finalList.Add(num.ToString());
                }
            }
            else
                foreach (int num in PositiveNumbers)
                    finalList.Add(num.ToString());

            return finalList;
        }

        private void DivideTheInput(IEnumerable<string> input)
        {
            foreach (var t in input)
            {
                var x = int.Parse(t);
                if (x < 0)
                    NegativeNumbers.Add(int.Parse(t));
                else
                    PositiveNumbers.Add(int.Parse(t));
            }
        }
    }
}