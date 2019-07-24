namespace EFTestApp
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Transaction
    {
        public decimal ID { get; set; }

        public DateTime Datetime { get; set; }

        public decimal Amount { get; set; }

        [Required]
        [StringLength(3)]
        public string Currency { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }

        [JsonIgnore]
        public decimal CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
