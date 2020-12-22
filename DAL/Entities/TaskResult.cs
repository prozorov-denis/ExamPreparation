namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaskResult")]
    public partial class TaskResult
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskResultId { get; set; }

        public int? StudentId { get; set; }

        public int? TaskId { get; set; }

        public bool? IsSolved { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public virtual Student Student { get; set; }

        public virtual Task Task { get; set; }
    }
}
