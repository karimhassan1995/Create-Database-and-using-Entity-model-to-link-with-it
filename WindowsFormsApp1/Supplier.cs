namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            Dispence_Permission = new HashSet<Dispence_Permission>();
            Supply_permission = new HashSet<Supply_permission>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Supplier_Id { get; set; }

        [StringLength(50)]
        public string Supplier_Name { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dispence_Permission> Dispence_Permission { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supply_permission> Supply_permission { get; set; }
    }
}
