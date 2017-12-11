using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }
        public string LastName { get; set; }
    }
}