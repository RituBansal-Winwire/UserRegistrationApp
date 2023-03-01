using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserRegistrationApp
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string FName { get; set; }
        [MaxLength(255)]
        public string LName { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        [MaxLength(10)]
        public int Phone { get; set; }

        [MaxLength(255)]
        public string UName { get; set; }

        [MaxLength(255)]
        public string Pwd { get; set; }
    }
}
