namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Theory")]
    public partial class Theory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Theory_ID { get; set; }

        public int Topics_ID { get; set; }

        public virtual Topics Topics { get; set; }
    }
}
