using System;
using System.Linq;
using DuoiHinhBatChu.DAL.Entites;
namespace DuoiHinhBatChu.BLL
{
    public class QuestionService
    {
        public Question GetRandomQuestion(int playerID)
        {
            using (DHBC_DATA db = new DHBC_DATA())
            {
                var answeredQuestions = db.AnsweredQuestions.Where(aq => aq.PlayerID == playerID).Select(aq => aq.QuestionID).ToList();
                var questions = db.Questions.Where(q => !answeredQuestions.Contains(q.QuestionID)).ToList();
                if (questions.Count == 0)
                {
                    return null;
                }
                Random random = new Random();
                int randomIndex = random.Next(0, questions.Count);
                return questions[randomIndex];
            }
        }
        public Question GetQuestionByID(int questionID)
        {
            using (DHBC_DATA db = new DHBC_DATA())
            {
                return db.Questions.FirstOrDefault(q => q.QuestionID == questionID);
            }
        }

        public string GetHint(int currentQuestionID)
        {
            using (DHBC_DATA db = new DHBC_DATA())
            {
                Question question = db.Questions.FirstOrDefault(q => q.QuestionID == currentQuestionID);
                if (question != null)
                {
                    return question.Hint;
                }
                return null;
            }
        }
        public int NumberOfQuestions()
        {
            using (DHBC_DATA db = new DHBC_DATA())
            {
                return db.Questions.Count();
            }
        }

        public bool CheckCompleted(int playerID)
        {
            using (DHBC_DATA db = new DHBC_DATA())
            {
                return db.AnsweredQuestions.ToList().Count(s => s.PlayerID == playerID) == NumberOfQuestions();
            }
        }
    }
}
