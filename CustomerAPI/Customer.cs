using System.ComponentModel.DataAnnotations;

namespace CustomerAPI
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(20)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(11)]
        public string TcNo { get; set; } = string.Empty;

        [StringLength(30)]
        public string Email { get; set; } = string.Empty;

        [StringLength(11)]
        public string TelNo { get; set; } = string.Empty;

        [StringLength(11)]
        public string? TelNo2 { get; set; } = string.Empty;

        [StringLength(20)]
        public string City { get; set; } = string.Empty;

        public int GenderId { get; set; }

        public Gender? Gender { get; set; }
        public string Adress { get; set; } = string.Empty;

       
        public string? Adress2 { get; set; } = string.Empty;

        public bool? Siradisi { get; set; } = false;
    }
}
