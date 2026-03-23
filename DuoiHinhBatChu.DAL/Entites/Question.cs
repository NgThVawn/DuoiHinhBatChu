namespace DuoiHinhBatChu.DAL.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            AnsweredQuestions = new HashSet<AnsweredQuestion>();
            Players = new HashSet<Player>();
        }

        public int QuestionID { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [Required]
        [StringLength(50)]
        public string Answer { get; set; }

        [Required]
        [StringLength(255)]
        public string Hint { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnsweredQuestion> AnsweredQuestions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Player> Players { get; set; }
    }
}
