namespace Calculator
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            bool running = true;
            double savedResult = 0;
            while (running)
            {
                bool arrayable = true;
               // Console.WriteLine(savedResult);
                Console.WriteLine("Ange symbol '+', '-', '*' eller '/' (ange något annat för att avsluta programmet)");
                var symbol = Console.ReadLine();
                if (symbol != "+" && symbol != "-" && symbol != "*" && symbol != "/" && symbol != "c") { running = false; break; }
                Console.WriteLine("Ange tal 1 (skriv r för att använda senaste resultat)");
                var numb = Console.ReadLine();
                double tal1 = 0;
                if (numb == "r")
                    tal1 = savedResult;
                else
                {
                    if (double.TryParse(numb, out tal1))
                        arrayable = false;
                }

                Console.WriteLine("Ange tal 2 (skriv r för att använda senaste resultat)");
                var numb2 = Console.ReadLine();
                double tal2 = 0;
                if (numb2 == "r")
                    tal2 = savedResult;
                else
                {
                    if (double.TryParse(numb2, out tal2))
                    {
                        arrayable = false;
                    }
                }
                Console.Clear();

                switch (symbol)
                {
                    case "+":
                        if (arrayable == true)
                            savedResult = Addition(ArrayMaker(numb + numb2));
                        else
                            savedResult = Addition(tal1, tal2);
                        
                        break;
                    case "-":
                        if (arrayable == true)
                            savedResult = Subtraction(ArrayMaker(numb + numb2));
                        else
                            savedResult =Subtraction(tal1, tal2);
                        break;
                    case "/":
                        savedResult=Division(tal1, tal2).Result;
                        break;
                    case "*":
                        savedResult=Multiplication(tal1, tal2);
                        break;
                    case "c":
                        GetNewTextColor();
                        break;

                }

            }
        }

        public static double Addition(double tal1, double tal2)
        {
            var sum = tal1 + tal2;
            Console.WriteLine($"{tal1}+{tal2}={sum}");
            return sum;
        }
        public static double Subtraction(double tal1, double tal2)
        {
            var result = tal1-tal2;
            Console.WriteLine($"{tal1}-{tal2}={result}");
            return result;
        }

        //Overload add and sub

        public static double Addition(double[] talserie)
        {
            double sum = 0;
            foreach (var tal in talserie)
            {
                sum += tal;
            }
            Console.WriteLine(sum);
            return sum;
        }
        public static double Subtraction(double[] talserie)
        {
            double result = talserie[0];
            talserie[0] = 0;
            foreach (var tal in talserie)
            {
                result -= tal;
            }
            Console.WriteLine(result);
            return result;
        }

        public static double Multiplication(double tal1, double tal2)
        {
            var result = tal1 * tal2;
            Console.WriteLine($"{tal1}*{tal2}={result}");
            return result;
        }
        public static DivisionReturnValue Division(double tal1, double tal2)
        {
            DivisionReturnValue drv = new DivisionReturnValue();
            drv.Division0 = false;
            double result = 0;
            if (tal2 == 0)
            {
                drv.Division0 = true;
                Console.WriteLine("Var snäll mot din miniräknare och dela inte saker med 0 :(");
            }
            else
            {
                result = tal1 / tal2;
                drv.Result = result;
                Console.WriteLine($"{tal1}/{tal2}={result}");
            }
            return (drv);
        }
        public static void GetNewTextColor()
        {
            Random r = new Random();
            var dice = r.Next(1, 7);
            if (dice == 1)
                Console.ForegroundColor = ConsoleColor.Blue;
            else if (dice == 2)
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

        public static double[] ArrayMaker(string talserie)
        {
            List<double> talList = new List<double>();
            string tempNumb = "";

            foreach (char c in talserie)
            {

                if (Char.IsDigit(c) || c==',' || c =='-')
                {
                    tempNumb += c;
                }
                else if (tempNumb.Length > 0)
                {               
                    int pos = 1 + tempNumb.IndexOf(',');
                    tempNumb = tempNumb.Substring(0, pos) + tempNumb.Substring(pos).Replace(",", string.Empty);
                    talList.Add(double.Parse(tempNumb));
                    tempNumb = "";
                }
            }
            if (tempNumb.Length > 0)
            {
                int pos = 1 + tempNumb.IndexOf(',');
                tempNumb = tempNumb.Substring(0, pos) + tempNumb.Substring(pos).Replace(",", string.Empty);
                talList.Add(double.Parse(tempNumb));
            }

            return (talList.ToArray());
        }

    }

    public class DivisionReturnValue{
        public bool Division0 { get; set; }
        public double Result { get; set; }
    }
}