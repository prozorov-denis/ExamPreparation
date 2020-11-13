namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Module")]
    public partial class Module
    {
        [Key]
        public int Modules_ID { get; set; }

        public int Students_ID { get; set; }

        public int Number { get; set; }

        [Column(TypeName = "date")]
        public DateTime Start_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime End_Date { get; set; }

        public int Topics_ID { get; set; }

        public bool? Finished { get; set; }

        public virtual Student Student { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
