namespace DuoiHinhBatChu.DAL.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Player
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Player()
        {
            AnsweredQuestions = new HashSet<AnsweredQuestion>();
        }

        public int PlayerID { get; set; }

        [Required]
        [StringLength(50)]
        public string PlayerName { get; set; }

        public int HintCount { get; set; }

        public int? TotalTime { get; set; }

        public int? TotalScore { get; set; }

        public int? LastQuestion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnsweredQuestion> AnsweredQuestions { get; set; }

        public virtual Question Question { get; set; }
    }
}
