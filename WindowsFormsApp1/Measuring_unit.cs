namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Measuring_unit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Item_Id { get; set; }

        [StringLength(50)]
        public string unit { get; set; }

        public virtual Item Item { get; set; }

        public virtual Item Item1 { get; set; }
    }
}
