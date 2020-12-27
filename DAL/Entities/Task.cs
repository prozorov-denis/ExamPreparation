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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Task()
        {
            TaskResult = new HashSet<TaskResult>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskId { get; set; }

        public int TopicId { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string TaskText { get; set; }

        public byte[] TaskImage { get; set; }

        [Required]
        [StringLength(50)]
        public string Answer { get; set; }

        [Column(TypeName = "text")]
        public string SolutionText { get; set; }

        public byte[] SolutionImage { get; set; }

        public virtual Topic Topic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaskResult> TaskResult { get; set; }
    }
}
