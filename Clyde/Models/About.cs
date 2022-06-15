using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clyde.Models
{
    public class About
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDay{ get; set; }
        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Image{ get; set; }
    }
}
