namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Studying")]
    public partial class Studying
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudyingId { get; set; }

        public int StudentId { get; set; }

        public int TopicId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ComplationDate { get; set; }

        public virtual Student Student { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
