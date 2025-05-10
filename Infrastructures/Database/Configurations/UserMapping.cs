namespace Infrastructures.Database.Configurations
{
    internal class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.EmailAddress)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(u => u.Role)
                .HasConversion(
                    codeToDataBase => (int)codeToDataBase,
                    dataBaseToCode => (Role)dataBaseToCode
                    );
        }
    }
}