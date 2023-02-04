namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Customer_id { get; set; }

        [StringLength(50)]
        public string Customer_Name { get; set; }

        [StringLength(15)]
        public string phone { get; set; }

        [StringLength(50)]
        public string fax { get; set; }

        [StringLength(15)]
        public string mobile { get; set; }

        [StringLength(50)]
        public string mail { get; set; }

        [StringLength(50)]
        public string website { get; set; }
    }
}
