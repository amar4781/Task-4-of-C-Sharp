namespace Exam_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuestionList questionList = new QuestionList();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("How many questions do you want ?");
            Console.ResetColor();
            int numQuestions;
            while (!int.TryParse(Console.ReadLine(), out numQuestions) || numQuestions <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a positive number: ");
                Console.ResetColor();
            }

            for (int i = 0; i < numQuestions; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"--- Creating Question {i + 1}/{numQuestions} ---");
                Console.WriteLine("What's the type of questions do you want ?");
                Console.WriteLine("1. True or False Question");
                Console.WriteLine("2. OneChoice Question");
                Console.WriteLine("3. MultibleChoice  Question");
                Console.ResetColor();
            

            string choice;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("choose between numbers (1-2-3): ");
                Console.ResetColor();

                choice = Console.ReadLine();
            } while (choice != "1" && choice != "2" && choice != "3");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter the Question level: ");
            Console.ResetColor();

            string level = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter the Question: ");
            Console.ResetColor();

            string content = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Question Mark: ");
            Console.ResetColor();

            int mark;
            while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid mark. Please enter a positive number: ");
                Console.ResetColor();
            }

            switch (choice)
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("answer? (True/False): ");
                    Console.ResetColor();
                    bool tfAnswer;
                    while (!bool.TryParse(Console.ReadLine(), out tfAnswer))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter 'True' or 'False': ");
                        Console.ResetColor();
                    }
                    questionList.addQuestion(new TrueFalseQuestion(level, content, mark, tfAnswer));
                    break;

                case "2":
                    List<string> onechoice = new List<string>();

                    for (int j = 1; j <= 4; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"Enter the choose number {j}: ");
                        Console.ResetColor();
                        onechoice.Add(Console.ReadLine());
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Question Answer? (Enter the number of the correct choice): ");
                    Console.ResetColor();

                    int oneAnswer;
                    while (!int.TryParse(Console.ReadLine(), out oneAnswer) || oneAnswer < 1 || oneAnswer > 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a positive number between 1 and 4: ");
                        Console.ResetColor();
                    }
                    questionList.addQuestion(new OneChoiceQuestion(level, content, mark, onechoice, oneAnswer -1));
                    break;

                case "3":
                    List<string> multiplechoice = new List<string>();
                    for (int j = 1; j <= 4; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"Enter the choose number {j}: ");
                        Console.ResetColor();
                        multiplechoice.Add(Console.ReadLine());
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Enter the correct answer number separated by space: ");
                    Console.ResetColor();

                    string userAnswers = Console.ReadLine();
                    List<int> correctIndices = userAnswers.Split(' ')
                        .Where(s => int.TryParse(s, out _))
                        .Select(s => int.Parse(s) - 1)
                        .ToList();
                    questionList.addQuestion(new MultipleChoiceQuestion(level, content, mark, multiplechoice, correctIndices));
                    break;
            }
        }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===============start exam===============");
            Console.ResetColor();
            Exam exam = new PracticeExam(DateTime.Now, numQuestions);
            exam.showExam(questionList);
            if (exam.grade == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"your grade is: {exam.grade} from {exam.MarkOfExam}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"your grade is: {exam.grade} from {exam.MarkOfExam}");
                Console.ResetColor();
            }
        }
    }
}