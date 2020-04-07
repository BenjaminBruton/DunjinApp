using System;
using SQLite;

namespace Dunjin.Model
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        
        public string Username { get; set; }       
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }         
        public string Phone { get; set; }
    }
}
