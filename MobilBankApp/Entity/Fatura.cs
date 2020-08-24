namespace MobilBankApp.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fatura")]
    public partial class Fatura
    {
        public int Id { get; set; }

        public int? MusteriId { get; set; }

        public int? FaturaTur { get; set; }

        public decimal? Tutar { get; set; }

        public bool? Aktif { get; set; }

        public virtual FaturaTur FaturaTur1 { get; set; }

        public virtual Musteri Musteri { get; set; }
    }
}
