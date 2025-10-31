namespace Exam_Management_System
{
    public class QuestionList
    {
        public List<Question> Questions { get; private set; }
        public QuestionList()
        {
            Questions = new List<Question>();
        }
        public void addQuestion(Question question)
        {
            Questions.Add(question);
        }
    }
}