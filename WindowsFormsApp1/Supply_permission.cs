namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supply_permission
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Stock_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Item_Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Supplier_Id { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int permission_Id { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? permission_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? production_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Expiray_Date { get; set; }

        public virtual Item Item { get; set; }

        public virtual Stock Stock { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
