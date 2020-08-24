namespace MobilBankApp.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Havale")]
    public partial class Havale
    {
        public int Id { get; set; }

        public int GonderenID { get; set; }

        public string IBAN { get; set; }

        public decimal Tutar { get; set; }

        public string Aciklama { get; set; }

        public virtual Hesap Hesap { get; set; }
    }
}
