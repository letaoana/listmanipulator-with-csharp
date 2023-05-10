using ListManipulator.App;
using System.Text;

namespace ListManipulator.UI
{
    public static class Program
    {
        private static void Main()
        {            
            var continueCapturing = true;
            var sb = new StringBuilder();
            while (continueCapturing)
            {
                PromptUserForInput();
                var number = ProcessUserInput();
                if (string.IsNullOrEmpty(number)) continue;
                if (ExitApplication(number) || number == "p")
                {
                    continueCapturing = false;
                    continue;
                }
                sb.Append(sb.Length > 0 ? $",{number}" : number);
            }

            var app = new ListManService(new ListManRepository(), Util.CreateLogger());
            app.Print(sb.ToString());
            Console.Read();
        }

        private static bool ExitApplication(string number)
        {
            return number == "x";
        }

        private static string ProcessUserInput()
        {
            var userInput = CaptureUserInput();
            if (userInput == null) return string.Empty;
            return int.TryParse(userInput, out var number) ? number.ToString() : userInput;
        }

        private static void PromptUserForInput()
        {
            Console.WriteLine("Type in a number to continue | Type in x to exit the application | Type in p to print out the numbers...");
        }

        private static string CaptureUserInput()
        {
            return Console.ReadLine();
        }
    }
}