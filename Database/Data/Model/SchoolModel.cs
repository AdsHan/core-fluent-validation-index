using System;

namespace Database.Data.Model
{
    public class SchoolModel
    {
        // EF Construtor
        public SchoolModel()
        {

        }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
