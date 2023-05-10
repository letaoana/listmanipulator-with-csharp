namespace ListManipulator.App;

public interface IListManRepository
{
    List<string> GetFinalList((List<int>, List<int>) input);

    (List<int>, List<int>) DivideTheInput(List<string> input);
}