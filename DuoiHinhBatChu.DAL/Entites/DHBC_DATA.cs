using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DuoiHinhBatChu.DAL.Entites
{
    public partial class DHBC_DATA : DbContext
    {
        public DHBC_DATA()
            : base("name=DHBC_DATA")
        {
        }

        public virtual DbSet<AnsweredQuestion> AnsweredQuestions { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasMany(e => e.AnsweredQuestions)
                .WithRequired(e => e.Player)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.AnsweredQuestions)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Players)
                .WithOptional(e => e.Question)
                .HasForeignKey(e => e.LastQuestion);
        }
    }
}
