namespace ListManipulator.App
{
    public class ListManipulator
    {
        private List<int> NegativeNumbers { get; init; }
        private List<int> PositiveNumbers { get; init; }

        public ListManipulator()
        {
            NegativeNumbers = new List<int>();
            PositiveNumbers = new List<int>();
        }

        public void PrintTheNumbers(IReadOnlyList<string> input)
        {
            if (input.Any())
            {
                DivideTheInput(input);
                var finalList = GetFinalList();
                var output = string.Join(',', finalList);
                Console.Write(output);
                Console.Read();
            }
            else
                Console.WriteLine("No input provided, please try again.");
        }

        private List<string> GetFinalList()
        {
            var finalList = new List<string>();
            if (NegativeNumbers.Any())
            {
                finalList.Add("|");
                for (var i = 0; i < PositiveNumbers.Count; i++)
                    finalList.Add(i.ToString());
            }
            else
                for (var j = 0; j < PositiveNumbers.Count; j++)
                    finalList.Add(j.ToString());

            return finalList;
        }

        private void DivideTheInput(IEnumerable<string> input)
        {
            foreach (var t in input)
            {
                var x = int.Parse(t.Trim());
                if (x < 0)
                    NegativeNumbers.Add(int.Parse(t));
                else
                    PositiveNumbers.Add(int.Parse(t));
            }
        }
    }
}