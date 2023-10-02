using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string> // User, Employee
                {
                    RoleId = "4d781862-0c63-4c85-a970-982ae6dced13",
                    UserId = "01fd8d01-76fa-4366-b3fb-a066eafdb4c4"
                },
                new IdentityUserRole<string> // Administrator
                {
                    RoleId = "e1bf98da-7a39-4d5b-8b55-c693cdb66e8c",
                    UserId = "4fdc920b-954e-4b9b-ba94-18f8f6ad40e2"
                }
            );
        }
    }
}
