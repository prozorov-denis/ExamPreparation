namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MessageId { get; set; }

        public int StudentId { get; set; }

        public int TeacherId { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        public int UserTypeId { get; set; }

        public virtual Student Student { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
