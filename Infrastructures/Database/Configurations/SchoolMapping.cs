namespace Infrastructures.Database.Configurations
{
    public class SchoolMapping : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("Schools"); // Tên bảng trong database
            builder.HasKey(s => s.Id); // Khóa chính
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd(); // Tự động tăng
            builder.Property(x => x.SchoolName)
                .HasMaxLength(255); // Tên trường có độ dài là 255
            builder.Property(x => x.Address)
                .HasMaxLength(255);
        }
    }
}