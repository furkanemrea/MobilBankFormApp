namespace MobilBankApp.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SigortaKampanya")]
    public partial class SigortaKampanya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SigortaKampanya()
        {
            SigortaHareket = new HashSet<SigortaHareket>();
        }

        public int Id { get; set; }

        public string Ad { get; set; }

        public decimal Tutar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SigortaHareket> SigortaHareket { get; set; }
    }
}
