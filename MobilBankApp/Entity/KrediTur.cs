namespace MobilBankApp.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KrediTur")]
    public partial class KrediTur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KrediTur()
        {
            KrediBasvuru = new HashSet<KrediBasvuru>();
        }

        public int Id { get; set; }

        public string Ad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KrediBasvuru> KrediBasvuru { get; set; }
    }
}
