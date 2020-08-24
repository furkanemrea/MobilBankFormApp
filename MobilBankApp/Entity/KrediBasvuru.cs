namespace MobilBankApp.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KrediBasvuru")]
    public partial class KrediBasvuru
    {
        public int Id { get; set; }

        public int KrediTur { get; set; }

        public int MusteriId { get; set; }

        public decimal Tutar { get; set; }

        public int Vade { get; set; }

        public DateTime Tarih { get; set; }

        public virtual Musteri Musteri { get; set; }

        public virtual KrediTur KrediTur1 { get; set; }
    }
}
