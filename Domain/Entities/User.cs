using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public byte[] Salt { get; set; }
        [JsonIgnore]
        public string HashPassword { get; set; }
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string ReTypePassword { get; set; }
        [NotMapped]
        public string CurrentPassword { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public bool IsDelete { get; set; }

    }
}
