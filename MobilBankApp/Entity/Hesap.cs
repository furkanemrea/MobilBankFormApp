namespace MobilBankApp.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hesap")]
    public partial class Hesap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hesap()
        {
            Eft = new HashSet<Eft>();
            Havale = new HashSet<Havale>();
            HesapOzeti = new HashSet<HesapOzeti>();
        }

        public int Id { get; set; }

        public int MusteriId { get; set; }

        public string IBAN { get; set; }

        public decimal Bakiye { get; set; }

        public string HesapAdi { get; set; }

        public bool Aktif { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Eft> Eft { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Havale> Havale { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HesapOzeti> HesapOzeti { get; set; }

        public virtual Musteri Musteri { get; set; }
    }
}
