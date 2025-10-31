namespace Exam_Management_System
{
    public abstract class Exam
    {
        protected Exam(DateTime examTime, int numberOfQuestions)
        {
            ExamTime = examTime;
            NumberOfQuestions = numberOfQuestions;
            MarkOfExam = 0;
            grade = 0;
        }

        public DateTime ExamTime { get; protected set; }
        public int NumberOfQuestions { get; protected set; }
        public int MarkOfExam { get; protected set; }
        public int grade { get; protected set; }

        public abstract void showExam(QuestionList questionList);
    }

    public class PracticeExam : Exam
    {
        public PracticeExam(DateTime examTime, int numberOfQuestions) : base(examTime, numberOfQuestions)
        {

        }
        public override void showExam(QuestionList questionList)
        {
            Console.WriteLine($"Time of this exam: {ExamTime}");
            Console.WriteLine($"Number of questions: {NumberOfQuestions}");
            int QuestionNumber = 1;
            foreach (var question in questionList.Questions)
            {
                Console.WriteLine($"Question {QuestionNumber++}");
                question.displayQuestion();
                grade += question.gradeQuestion();
                MarkOfExam += question.Mark;
            }

        }
    }
}