using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoListAPI
{
    public class ToDoList
    {
        public Guid id { get; set; }
        // public string title { get; set; }
        public string title { get; set; } = string.Empty;

        public bool done { get; set; }

        public DateTime addedDate { get; set; }
        public DateTime? updatedDate { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime? doneDate { get; set; }




    }
    public class ToDoListConfig : IEntityTypeConfiguration<ToDoList>
    {
        public void Configure(EntityTypeBuilder<ToDoList> b)
        {
            //b.HasKey(x => x.id)
            b.HasKey(x => x.id).IsClustered();
            b.Property(x => x.id).ValueGeneratedOnAdd().HasDefaultValueSql("newsequentialid()");
            // b.HasIndex(x => x.id).IsUnique();          
            b.Property(x => x.addedDate).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
            b.Property(x => x.updatedDate).ValueGeneratedOnUpdate().HasDefaultValueSql("getdate()");
        }
    }
}
