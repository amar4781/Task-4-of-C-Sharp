namespace Exam_Management_System
{
    public abstract class Question
    {
        public Question(string level, string content, int mark)
        {
            Level = level;
            Content = content;
            Mark = mark;
        }

        public string Level { get; set; }
        public string Content { get; set; }
        public int Mark { get; set; }

        public abstract void displayQuestion();

        public abstract int gradeQuestion();
    }

    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string level, string content, int mark, bool correctAnswer)
            : base(level, content, mark)
        {
            CorrectAnswer = correctAnswer;
        }

        public bool CorrectAnswer { get; private set; }

        public override void displayQuestion()
        {
            Console.WriteLine($"Question: {Content}");
            Console.WriteLine("1.True");
            Console.WriteLine("2.False");
        }

        public override int gradeQuestion()
        {
            Console.WriteLine("Enter your answer (1 for True, 2 for False):");
            string userInput = Console.ReadLine();
            bool userAnswer = userInput == "1";
            if (userAnswer == CorrectAnswer)
            {
                return Mark;
            }
            else
            {
                return 0;
            }
        }
    }

    public abstract class ChoiceQuestion : Question
    {
        protected ChoiceQuestion(string level, string content, int mark, List<string> choices)
            : base(level, content, mark)
        {
            Choices = choices;
        }

        public List<string> Choices { get; protected set; }

        public override void displayQuestion()
        {
            Console.WriteLine($"Question: {Content}");
            for (int i = 0; i < Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{Choices[i]}");
            }
        }
    }

    public class OneChoiceQuestion : ChoiceQuestion
    {
        public OneChoiceQuestion(string level, string content, int mark, List<string> choices, int correctAnswerIndex)
            : base(level, content, mark, choices)
        {
            CorrectAnswerIndex = correctAnswerIndex;
        }

        public int CorrectAnswerIndex { get; private set; }

        public override int gradeQuestion()
        {
            Console.WriteLine("Enter the number of your answer:");
            string userInput = Console.ReadLine();
            int userAnswerIndex = int.Parse(userInput) - 1;
            if (userAnswerIndex == CorrectAnswerIndex)
            {
                return Mark;
            }
            else
            {
                return 0;
            }
        }
    }

    public class MultipleChoiceQuestion : ChoiceQuestion
    {
        public MultipleChoiceQuestion(string level, string content, int mark, List<string> choices, List<int> correctAnswerIndices)
            : base(level, content, mark, choices)
        {
            CorrectAnswerIndices = correctAnswerIndices;
        }
        public List<int> CorrectAnswerIndices { get; private set; }

        public override int gradeQuestion()
        {
            Console.WriteLine("Enter the numbers of your answer separated by space:");
            string userInput = Console.ReadLine();
            List<int> userAnswerIndices = userInput
                .Split(' ')
                .Where(s => int.TryParse(s, out _))
                .Select(s => int.Parse(s) - 1)
                .ToList();
            if (userAnswerIndices.OrderBy(x => x).SequenceEqual(CorrectAnswerIndices.OrderBy(x => x)))
            {
                return Mark;
            }
            else
            {
                return 0;
            }
        }
    }
}