namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Modules
    {
        [Key]
        public int Modules_ID { get; set; }

        public int Plans_ID { get; set; }

        public int Number { get; set; }

        [Column(TypeName = "date")]
        public DateTime Start_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime End_Date { get; set; }

        public int Topics_ID { get; set; }

        public virtual Plans Plans { get; set; }

        public virtual Topics Topics { get; set; }
    }
}
