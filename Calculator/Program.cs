namespace Calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Ange symbol '+', '-', '*' eller '/' (ange något annat för att avsluta programmet)");
                var symbol = Console.ReadLine();
                if (symbol != "+" && symbol != "-" && symbol != "*" && symbol != "/" && symbol!="c") { running = false; break; }
                Console.WriteLine("Ange tal 1");
                int.TryParse(Console.ReadLine(), out int tal1);
                Console.WriteLine("Ange tal 2");
                int.TryParse(Console.ReadLine(), out int tal2);
                switch (symbol)
                {
                    case "+":
                        Addition(tal1, tal2);
                        break;
                    case "-":
                        Subtraction(tal1, tal2);
                        break;
                    case "/":
                        Division(tal1, tal2);
                        break;
                    case "*":
                        Multiplication(tal1, tal2);
                        break;
                    case "c":
                        GetNewTextColor();
                        break;
                }
            }
        }

        public static void Addition(int tal1, int tal2)
        {
            Console.WriteLine($"{tal1}+{tal2}={tal1 + tal2}");
        }
        public static void Subtraction(int tal1, int tal2)
        {
            Console.WriteLine($"{tal1}-{tal2}={tal1 - tal2}");
        }
        public static void Multiplication(int tal1, int tal2)
        {
            Console.WriteLine($"{tal1}*{tal2}={tal1 * tal2}");
        }
        public static void Division(int tal1, int tal2)
        {
            if (tal2 == 0)
                Console.WriteLine("Var snäll mot din miniräknare och dela inte saker med 0 :(");
            else
                Console.WriteLine($"{tal1}-{tal2}={tal1 / tal2}");
        }
        public static void GetNewTextColor()
        {
            Random r = new Random();
            var dice = r.Next(1, 7);
            if (dice == 1)
                Console.ForegroundColor = ConsoleColor.Blue;
            else if(dice == 2)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (dice == 3)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (dice == 4)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else if (dice == 5)
                Console.ForegroundColor = ConsoleColor.Magenta;
            else if (dice == 6)
                Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}