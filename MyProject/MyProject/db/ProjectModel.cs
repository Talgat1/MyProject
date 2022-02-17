using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyProject
{
    [Table("Project")]
    public class ProjectModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Image { get; set; }

        public ProjectModel(string name, string description, string telephoneNumber1, string email, string address, string image)
        {
            Name = name;
            Description = description;
            PhoneNum = telephoneNumber1;
            Email = email;
            Adress = address;
            Image = image;
        }

        public ProjectModel()
        {

        }
    }
}
