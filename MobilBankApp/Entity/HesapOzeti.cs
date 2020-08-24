namespace MobilBankApp.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HesapOzeti")]
    public partial class HesapOzeti
    {
        public int Id { get; set; }

        public string Ad { get; set; }

        public decimal IslemTutar { get; set; }

        public int HesapId { get; set; }

        public DateTime Tarih { get; set; }

        public int? IslemId { get; set; }

        public virtual Hesap Hesap { get; set; }

        public virtual IslemTur IslemTur { get; set; }
    }
}
