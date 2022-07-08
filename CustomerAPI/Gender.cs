using System.ComponentModel.DataAnnotations;

namespace CustomerAPI
{
    public class Gender
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string GenOption { get; set; } = String.Empty;
    }
}
