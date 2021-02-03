using System;
using SpectrumTest.Database.Repository;

namespace SpectrumTest.Models
{
    public class User : BaseDatabaseItem
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
    }
}
