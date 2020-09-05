using System;
namespace GALAXY_NETCORE.Models.DTO
{
    public class UserApp
    {
        public int UserId { get; set; }
        public string Credential { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
