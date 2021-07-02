using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CrudUsers.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string email { get; set; }
        public string? role { get; set; }
        public string password { get; set; }
        public string? refreshToken { get; set; }
        public string? refreshTokenExpires { get; set; }
        public int? cityCode { get; set; }
        public string? sponsorCode { get; set; }
        public string? picture { get; set; }
        public string? address { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }



    }
}
