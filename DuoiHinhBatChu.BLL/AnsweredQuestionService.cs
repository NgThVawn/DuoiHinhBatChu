using DuoiHinhBatChu.DAL.Entites;

namespace DuoiHinhBatChu.BLL
{
    public class AnsweredQuestionService
    {
        public void Add(AnsweredQuestion answeredQuestion)
        {
           using(DHBC_DATA db = new DHBC_DATA())
            {
                db.AnsweredQuestions.Add(answeredQuestion);
                db.SaveChanges();
            }
        }
    }
}
