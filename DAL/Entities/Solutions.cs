namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Solutions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Solutions_ID { get; set; }

        public int Tasks_ID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Solution_Text { get; set; }

        public virtual Tasks Tasks { get; set; }
    }
}
