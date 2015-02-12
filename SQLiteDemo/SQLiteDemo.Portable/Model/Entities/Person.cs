using SQLite.Net.Attributes;

namespace SQLiteDemo.Portable.Model.Entities
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
