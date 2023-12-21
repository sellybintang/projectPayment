using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace project.Models
{
    public class projectPayment
    {
        [Key]
        public int paymentId { get; set; }

        [Column (TypeName = "nvarchar(100)")]
        public string userName { get; set; } = "";

        [Column (TypeName ="nvarchar(20)")]
        public string cardNumber { get; set; } = "";

        [Column (TypeName = "nvarchar(5)")]
        public string expirationDate { get; set; } = "";

        [Column (TypeName= "nvarchar(3)")]
        public string securityCode { get; set; } = "";
        
        public bool status { get; set; } = true;

        public int total { get; set; } 

    }
}
