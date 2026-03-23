namespace DuoiHinhBatChu.DAL.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AnsweredQuestion
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlayerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestionID { get; set; }

        public int AnswerTime { get; set; }

        public bool? UseHint { get; set; }

        public int Score { get; set; }

        public virtual Player Player { get; set; }

        public virtual Question Question { get; set; }
    }
}
