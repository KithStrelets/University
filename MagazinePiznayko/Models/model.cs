using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.Entity;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagazinePiznayko.Models
{
    
    [Table("customers")]
    public class Customer
    { 
        [Key]
        public Guid idcustomer { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string product { get; set; }
        public string description { get; set; }
       
    }


    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MagazineContext : DbContext
    {
        public MagazineContext() : base("conn")
        { }
        public DbSet<Customer> customer { get; set; }
    }
} 