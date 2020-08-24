namespace MobilBankApp.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SigortaHareket")]
    public partial class SigortaHareket
    {
        public int Id { get; set; }

        public int Yaptiran { get; set; }

        public int SigortaKampanya { get; set; }

        public virtual Musteri Musteri { get; set; }

        public virtual SigortaKampanya SigortaKampanya1 { get; set; }
    }
}
