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
            Result = new HashSet<Result>();
        }

        [Key]
        public int Tasks_ID { get; set; }

        public int Topics_ID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Task_Text { get; set; }

        [Required]
        [StringLength(50)]
        public string Answer { get; set; }

        [Column(TypeName = "xml")]
        public string Task_Xml { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Result { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
