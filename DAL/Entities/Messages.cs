namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Messages
    {
        [Key]
        public int Messages_ID { get; set; }

        public int Students_ID { get; set; }

        public int Teachers_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Message_Text { get; set; }

        public DateTime Message_Date { get; set; }

        public virtual Students Students { get; set; }

        public virtual Teachers Teachers { get; set; }
    }
}
