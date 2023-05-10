namespace ListManipulator.App
{
    public class ListManRepository : IListManRepository
    {
        public List<string> GetFinalList((List<int>, List<int>) input)
        {
            var finalList = new List<string>();
            if (input.Item1.Any())
            {
                input.Item1.ForEach(number => { finalList.Add(number.ToString()); });

                if (!input.Item2.Any()) return finalList;

                finalList.Add("|");

                input.Item2.ForEach(number => { finalList.Add(number.ToString()); });
            }
            else
                input.Item2.ForEach(number => { finalList.Add(number.ToString()); });

            return finalList;
        }

        public (List<int>, List<int>) DivideTheInput(List<string> input)
        {
            var negativeNumbers = new List<int>();
            var positiveNumbers = new List<int>();

            foreach (var x in input.Select(int.Parse))
            {
                if (x < 0)
                    negativeNumbers.Add(x);
                else
                    positiveNumbers.Add(x);
            }

            return (negativeNumbers, positiveNumbers);
        }
    }
}