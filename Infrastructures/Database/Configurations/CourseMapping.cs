namespace Infrastructures.Database.Configurations
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses"); // Tên bảng trong database
            builder.HasKey(c => c.CourseId); // Khóa chính
            builder.Property(x => x.CourseId);
            builder.Property(x => x.CourseId)
                .ValueGeneratedOnAdd(); // Tự động tăng
            builder.Property(x => x.CourseName)
                .HasMaxLength(255); // Tên khóa học có độ dài là 255
        }
    }
}