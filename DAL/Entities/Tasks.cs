namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tasks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tasks()
        {
            Results = new HashSet<Results>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tasks_ID { get; set; }

        public int Topics_ID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Task_Text { get; set; }

        [Required]
        [StringLength(50)]
        public string Answer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Results> Results { get; set; }

        public virtual Solutions Solutions { get; set; }

        public virtual Topics Topics { get; set; }
    }
}
