using MathExprInterpreter.MathExpressionTree;

namespace MathExprInterpreter {
    internal class Program {
        static void Main(string[] args) {
            while (true) {
                try {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("MEI << ");
                    Console.ResetColor();

                    string? tInput = Console.ReadLine();
                    string input = tInput != null ? tInput : String.Empty;

                    if (input == "exit") {
                        Environment.Exit(0);
                    }

                    Lexer lexer = new Lexer(input);
                    Parser parser = new Parser(lexer.GetTokens());

                    IMET obj = parser.ParseExpression();
                    if (obj == null) {
                        continue;
                    }
                    Console.WriteLine(obj.Evaluate());

                    
                } catch (Exception e) {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
            }
        }
    }
}