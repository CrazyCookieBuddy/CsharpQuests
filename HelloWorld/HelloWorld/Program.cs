using System;
using System.Globalization;
#pragma warning disable IDE0051
namespace HelloWorld
{
    class Read
    {
        static readonly string ConsoleIndicator = "\n> ";
        static bool valid = false;
        public static int Int(string ConsoleText, string ErrorMessage)
        {
            valid = false;
            int integer = 0;
            do
            {
                try
                {
                    Console.Write(ConsoleText + ConsoleIndicator);
                    string temp = Console.ReadLine();
                    if (temp == "q" || temp == "quit")
                    {
                        Program.MainMenu();
                        return 0;
                    }
                    integer = Convert.ToInt32(temp);
                    valid = true;
                }
                catch
                {
                    Console.WriteLine(ErrorMessage);
                    valid = false;
                }

            } while (!valid);
            return integer;
        }
        static float Float(string ConsoleText, string ErrorMessage)
        {
            valid = false;
            float floatnumber = 0;
            do
            {
                try
                {
                    Console.Write(ConsoleText + ConsoleIndicator);
                    string temp = Console.ReadLine();
                    if (temp == "q" || temp == "quit")
                    {
                        Program.MainMenu();
                        return 0;
                    }
                    floatnumber = float.Parse(temp);
                    valid = true;
                }
                catch
                {
                    Console.WriteLine(ErrorMessage);
                    valid = false;
                }

            } while (!valid);
            return floatnumber;
        }
        public static string String(string ConsoleText)
        {
            Console.Write(ConsoleText + ConsoleIndicator);
            string input = Console.ReadLine();
            return input;
            //valid = false;
            //return "";
        }

        public static bool YesNo(string ConsoleText, string ErrorMessage)
        {
            string yesno = "Y/N";
            valid = false;
            bool yes = false;
            do
            {
                Console.WriteLine(ConsoleText + " " + yesno);
                ConsoleKey input = Console.ReadKey().Key;
                Console.WriteLine();
                if (input == ConsoleKey.Q)
                {
                    Program.MainMenu();
                    return false;
                }
                else if (input == ConsoleKey.Y)
                {
                    valid = true;
                    yes = true;
                }
                else if (input == ConsoleKey.N)
                {
                    valid = true;
                    yes = false;
                }
                else
                {
                    Console.WriteLine(ErrorMessage);
                    valid = false;
                }

            } while (!valid);
            return yes;
        }

    }
    class Program
    {
        #region randomvars
        public static string Worldstring = "Ham and Eggs are better than \"Hello World!\"";
        public static int TheAnswer = 42;
        public static bool WorldFlat = true;
        #endregion

        public static string UserName;
        public static int UserAge;
        static bool MainMenuOpened;
        public enum ReturnType
        {
            valid,
            invalid,
            quit
        }
        public enum OperationType
        {
            naught,
            subtract,
            add,
            multiply,
            divide,
            retry
        }
        public enum Weekdays
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        public enum Months
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }
        public enum EnumSecret
        {
            Power,
            Bananas,
            Complication,
            Programming,
            Everything
        }
        public static Random rnd = new Random(DateTime.Now.GetHashCode());
        static bool calendarHasMonth;
        static bool calendarHasYear;
        static int guessingNumber = 0;
        public static string divider = "----------------------------";
        static void Main()
        {
            MainMenu();
        }
        static void DrawDivider()
        {
            Console.WriteLine(divider);
        }
        public static void MainMenu(bool unknownInput = false)
        {
            if (!unknownInput)
            {
                Console.WriteLine("Welcome " + ((MainMenuOpened == true) ? "back " : "") + "to the Main Menu.");
            }
            MainMenuOpened = true;
            string input = Read.String("Please input your command.");
            switch (input)
            {
                case "help":
                case "h":
                    Console.WriteLine("Here a list of available commands. ()Brackets indicate shortcuts. \n> help \n> calendar \n> guessing game \n> super smart (ai) \n> (c)alculator \n> name \n> age \n> random number \n> (e)xit or (q)uit");
                    break;
                case "calendar":
                    DrawMonth();
                    break;
                case "q":
                case "quit":
                case "exit":
                case "e":
                    Environment.Exit(1);
                    break;
                case "super smart ai":
                case "super smart AI":
                case "AI":
                case "ai":
                    SuperSmartAI();
                    break;
                case "calculator":
                case "calc":
                case "c":
                    Calculator();
                    break;
                case "name":
                    Name();
                    break;
                case "age":
                    Age();
                    break;
                case "random number":
                    GenerateRandomNumberBetween();
                    break;
                case "guessing game":
                    GuessingGame(1, 5);
                    break;
                default:
                    Console.Write("Unknown Input. ");
                    MainMenu(true);
                    break;
            }
            MainMenu();
        }

        static void GuessingGame(int a, int b, bool generate = true)
        {
            DrawDivider();
            if (a > b)
            {
                Console.WriteLine(a + "is bigger than " + b + ". Cancelling request.");
                return;
            }
            //Generate a random number the user has to guess. Ask the user for a number in a range of [n1-nn] and compare it with the value
            if (generate)
            {
                guessingNumber = rnd.Next(a, b);
                Console.WriteLine("Generating a number from " + a + " to " + b + "...");
            }
            int input = Read.Int("Guess the number!", "Not a valid number. Please guess again.");
            if (input == guessingNumber)
            {
                Console.WriteLine("Congratulations! You Win!");
                DrawDivider();
            }
            else if (input > guessingNumber)
            {
                Console.Write("You guessed too high... ");
                if (Read.YesNo("Guess again?", "Invalid input."))
                {
                    GuessingGame(a, b, false);
                    return;
                }
                DrawDivider();
            }
            else if (input < guessingNumber)
            {
                Console.Write("You guessed too low... ");
                if (Read.YesNo("Guess again?", "Invalid input."))
                {
                    GuessingGame(a, b, false);
                    return;
                }
                DrawDivider();
            }
            else
            {
                Console.Write("ERROR."); //shouldn't be able to reach this code
            }
        }
        static void DrawMonth()
        {
            bool current;
            switch (Read.String("Do you want the current or a different month?"))
            {
                case "c":
                case "current":
                    current = true;
                    break;
                case "d":
                case "different":
                    current = false;
                    break;
                case "q":
                case "quit":
                case "b":
                case "back":
                    return;
                default:
                    DrawMonth();
                    return;
            }

            int month = 0;
            int year = 0;
            #region GetMonthYear
            if (current)
            {
                month = DateTime.Now.Month;
                year = DateTime.Now.Year;

            }
            else
            {
                if (!calendarHasYear)
                {
                    year = Read.Int("Please input the year you're looking for:", "Sorry, that was not a valid year. Please input a positive integer.");
                    calendarHasYear = true;
                }
                if (!calendarHasMonth)
                {
                    month = Read.Int("Please input the month you're looking for:", "Sorry, that was not a valid month. Please input a integer between 1 and 12.");
                    calendarHasMonth = true;
                }
            }
            #endregion
            #region DrawHeaders
            Console.Write("\n");
            Console.WriteLine(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month) + ", " + year);
            Console.WriteLine("Su Mo Tu We Th Fr Sa"); //weird cause some ppl start week on sunday
            #endregion
            #region FillCalendar
            /* todo: 
             * 1. get first day of the month. 
             * 2. get weekday of that day
             * 3. get last day of month / amount of days
             * 4. make a 2d array of the month
             * 5. populate array with offset depending on first weekday
             * 6. stop populating if we reached the last day of the month
             * 7. draw array
             * 7.1 don't forget that numbers can be single space
             * 8. ??? 
             * 9. profit
            */
            DateTime date = new DateTime(year, month, 1); // get the datetime for the first day of the month? i think
            int daysInMonth = DateTime.DaysInMonth(year, month); //get the amount of days in the month for this section of the calendar to draw
            int[,] calendar = new int[6, 7]; //make our calendar 2D array, in this case being the weeks & weekdays
            int dayOfWeek = Convert.ToInt32(date.DayOfWeek) + 1; //get the day of the week of the first day in the month as an int, plus one because week does not start on sunday
            int currentlyDrawingDay = 1; //start counting here

            for (int x = 0; x < calendar.GetLength(0); x++) //if x(current day of the week) is within the week (length of 0 axis in calendar array)
            {
                for (int y = 0; y < calendar.GetLength(1) && (currentlyDrawingDay - dayOfWeek + 1 /*plus one because we start counting at 1*/) <= daysInMonth; y++) //if y is within the week, and the currently drawing day minus the day of the week is within the month
                {
                    calendar[x, y] = currentlyDrawingDay - dayOfWeek + 1; //set the day to the index minus the starting date 
                    currentlyDrawingDay++;
                }
            }
            #endregion
            #region DrawCalendar
            //x in this case is downwards, y is sideways (x week, y day)
            for (int x = 0; x < calendar.GetLength(0); x++)
            {
                for (int y = 0; y < calendar.GetLength(1); y++)
                {
                    if (calendar[x, y] > 0)
                    {
                        if (calendar[x, y] < 10) //if the date does not have 2 numbers, we need to add an extra space or a 0(to accommodate the missing number)
                        {
                            Console.Write("0" + calendar[x, y] + " ");
                        }
                        else
                        {
                            Console.Write(calendar[x, y] + " ");
                        }
                    }
                    else
                    {
                        Console.Write("   ");
                    }

                }
                Console.WriteLine();
            }
            #endregion
            #region ClearMonthYear
            calendarHasMonth = false;
            calendarHasYear = false;
            #endregion
        }

        static double GenerateRandomNumberBetween(bool floatnumbers = false)
        {
            DrawDivider();
            int a = Read.Int("Please input the minmum:", "Sorry, that was not a valid integer. Try again.");

            int b = Read.Int("Please input the maximum:", "Sorry, that was not a valid Integer. Try again.");

            double randomnumber;
            if (floatnumbers)
            {
                Console.WriteLine("Generating random int number...");
                randomnumber = rnd.NextDouble();
            }
            else
            {
                Console.WriteLine("Generating random float number...");
                randomnumber = rnd.NextDouble() * (a - b) + b;
            }
            Console.WriteLine("Random Number: " + randomnumber);
            DrawDivider();
            return randomnumber;
        }

        static void PrintGrid(int x, int y)
        {
            for (int localx = 0; localx < x; localx++)
            {
                for (int localy = 0; localy < y; localy++)
                {
                    Console.Write(localx + "/" + localy);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        static string Secret()
        {
            string input = Read.String("Input a secret passphrase: ");

            switch (input)
            {
                case "Power":
                    return "The secret to power is... Milkshakes.";
                case "Bananas":
                case "Banana":
                case "bananas":
                case "banana":
                    return "Banana.Banana.Banana.Banana.Banana.Banana.Banana.Banana.Banana.Banana.Banana.";
                case "complication":
                    return "Sorry, there has been a complication. Goodbye.";
                case "Programming":
                    return "The secret to programming is trial and error.";
                case "Everything":
                    return "42";
                default:
                    return "Invalid Password.";
            }
        }

        static void Naughty(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine("\"I have been bad today, sorry!\"");
            }
        }
        static void SuperSmartAI()
        {

            DrawDivider();
            string input = Read.String("I am an AI. Hello. Ask me any question you'd like.");
            while (!input.Contains("exit") && !input.Contains("goodbye") && !input.Contains("quit"))
            {
                Console.WriteLine("Very good question, I will come back to you in a moment!");

                input = Read.String("I am an AI. Hello. Ask me any question you'd like.");
            }

            DrawDivider();
        }

        static void PrintWeekdayEnum()
        {
            foreach (string item in Enum.GetNames(typeof(Weekdays)))
            {
                Console.WriteLine(item);
            }
        }

        static void Calculator()
        {

            DrawDivider();
            Console.WriteLine("Calculator initiated.");
            if (!GetIntegerInput("A", out int a))
            {
                return;
            }

            if (!SetOperator(out OperationType operation))
            {
                return;
            }
            int b;
            if (operation != OperationType.naught)
            {
                if (!GetIntegerInput("B", out b))
                {
                    return;
                }
            }
            else
            {
                return;
            }
            int c;
            switch (operation)
            {
                case OperationType.subtract:
                    c = a - b;
                    break;
                case OperationType.add:
                    c = a + b;
                    break;
                case OperationType.multiply:
                    c = a * b;
                    break;
                case OperationType.divide:
                    c = a / b;
                    break;
                case OperationType.retry:
                    c = 0;
                    break;
                case OperationType.naught:
                    return;
                default:
                    c = 0;
                    break;
            }
            Console.WriteLine("Equals to " + c);
            DrawDivider();
        }
        static bool GetIntegerInput(string intName, out int integer)
        {
            switch (SetInteger(intName, out integer))
            {
                case ReturnType.valid:
                    return true;
                case ReturnType.invalid:
                    GetIntegerInput(intName, out integer);
                    return true;
                case ReturnType.quit:
                    return false;
                default:
                    return false;
            }
        }
        static ReturnType SetInteger(string intName, out int integer)
        {
            Console.Write("Input integer value for " + intName + ": ");
            try
            {
                string input = Console.ReadLine();
                if (input == "q")
                {
                    integer = 0;
                    return ReturnType.quit;
                }
                integer = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                Console.WriteLine("Input needs to be an integer.");
                integer = 0;
                return ReturnType.invalid;
            }
            return ReturnType.valid;
        }
        static bool SetOperator(out OperationType localoperator)
        {
            localoperator = OperationType.naught;
            Console.Write("Input an operator: ");
            switch (Console.ReadLine())
            {
                case "plus":
                case "add":
                case "+":
                    localoperator = OperationType.add;
                    break;
                case "minus":
                case "remove":
                case "-":
                    localoperator = OperationType.subtract;
                    break;
                case "multiply":
                case "*":
                case "x":
                    localoperator = OperationType.multiply;
                    break;
                case "by":
                case "divide":
                case "/":
                    localoperator = OperationType.divide;
                    break;
                case "b":
                case "q":
                case "quit":
                case "back":
                    return false;
                default:
                    Console.WriteLine("Unknown operator, try again.");
                    localoperator = OperationType.retry;
                    break;
            }
            return true;
        }
        static void DataTypes()
        {
            bool boolean = true;
            int integer = 1;
            double doublenumber = 1.00;
            float floatpoint = 1.11f;
            string textstring = "random text";
            char singlechar = 'a';
            Console.WriteLine("bool " + boolean);
            Console.WriteLine("int " + integer);
            Console.WriteLine("double " + doublenumber);
            Console.WriteLine("float " + floatpoint);
            Console.WriteLine("string " + textstring);
            Console.WriteLine("char " + singlechar);
        }
        static void ReadConsoleLine()
        {
            string amount = Console.ReadLine();
            int number;
            try
            {
                number = Convert.ToInt16(amount);
                Console.WriteLine(AddOne(number));
            }
            catch
            {
                Console.WriteLine("Not a number.");
            }

            Console.ReadLine();
        }
        static void Banana()
        {
            int sliceAmount = 1;
            bool sliced = true;

            switch (sliced)
            {
                case false:
                    Console.WriteLine("The banana is not sliced. " + "sliced = " + sliced);
                    break;
                case true:
                    Console.WriteLine("The banana is sliced. " + "sliced = " + sliced);
                    break;
            }

            Console.WriteLine("There are " + sliceAmount + " slices.");

        }
        static int AddOne(int number)
        {
            number++;
            return number;
        }
        static void Maths()
        {
            int a;
            int b;

            a = 10;
            b = 69;

            int c = a + b;

            Console.WriteLine(c);

            float d;
            float e;

            d = 12.400f;
            e = 57.44f;

            float f = d - e;

            Console.WriteLine(f);

            int g = a * b;
            float h = d * e;

            float i = g / h;

            Console.WriteLine(i);
        }
        static void Name()
        {
            string name;
            Console.Write("Please input your name: ");
            name = Console.ReadLine();
            if (name == "" && name != "b" && name != "back")
            {
                Name();
            }
            else if (name == "back" || name == "b" || name == "q" || name == "quit")
            {
                return;
            }

            Console.WriteLine("Hello, " + name + "!");
            UserName = name;
            Console.ReadLine();

        }
        static void Age()
        {
            int age = -1;
            Console.Write("Please input your age as a number: ");
            try
            {
                age = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input.");
                Age();
            }

            if (UserName != null)
            {
                Console.WriteLine("Hello, " + UserName + "! Thank you for telling me your age (which is " + age + ").");
                UserAge = age;
            }
            else
            {
                Console.WriteLine("Your age is " + age + ".");
                UserAge = age;
            }
            Console.ReadLine();
        }
    }

}
