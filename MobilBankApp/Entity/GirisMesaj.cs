namespace MobilBankApp.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GirisMesaj")]
    public partial class GirisMesaj
    {
        public int Id { get; set; }

        public string Mesaj { get; set; }
    }
}
