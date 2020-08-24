namespace MobilBankApp.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Musteri")]
    public partial class Musteri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Musteri()
        {
            Fatura = new HashSet<Fatura>();
            Hesap = new HashSet<Hesap>();
            KrediBasvuru = new HashSet<KrediBasvuru>();
            SigortaHareket = new HashSet<SigortaHareket>();
        }

        public int Id { get; set; }

        public string KimlikNo { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Mail { get; set; }

        public string TelefonNumarasi { get; set; }

        public int Sehir { get; set; }

        public decimal Bakiye { get; set; }

        public string Sifre { get; set; }

        public bool Aktif { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fatura> Fatura { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hesap> Hesap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KrediBasvuru> KrediBasvuru { get; set; }

        public virtual Sehir Sehir1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SigortaHareket> SigortaHareket { get; set; }
    }
}
