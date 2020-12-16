namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public partial class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskId { get; set; }

        public int TopicId { get; set; }

        public byte[] Text { get; set; }

        [StringLength(50)]
        public string Answer { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
