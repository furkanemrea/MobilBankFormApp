namespace MobilBankApp.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Eft")]
    public partial class Eft
    {
        public int Id { get; set; }

        public int GonderenID { get; set; }

        public string IBAN { get; set; }

        public decimal Tutar { get; set; }

        public string Aciklama { get; set; }

        public int BankaId { get; set; }

        public virtual Banka Banka { get; set; }

        public virtual Hesap Hesap { get; set; }
    }
}
