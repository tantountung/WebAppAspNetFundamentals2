using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAspNetFundamentals2.Models.Data
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(60)]
        public string PhoneNumber { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        [Required]
        public City City { get; set; }


    }
}
