namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Plans
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plans()
        {
            Modules = new HashSet<Modules>();
        }

        [Key]
        public int Plans_ID { get; set; }

        public int Students_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Exam_Date { get; set; }

        public int Exam_Score { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Modules> Modules { get; set; }

        public virtual Students Students { get; set; }
    }
}
