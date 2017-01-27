namespace TheVidStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'195338bc-d214-470c-a6cb-2142c069bcd1', N'test@test.com', 0, N'AOYOzP49v9LLmpQcLW9PGGVKbTjxTMTUYmjcy41I78ol4fawmptyPkPm37WTgx70rQ==', N'5da96e28-d47e-43ef-80f6-3ac8e937600e', NULL, 0, 0, NULL, 1, 0, N'test@test.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7aac2844-5349-4155-b759-2f0a772eea0d', N'admin@thevidstore.com', 0, N'ABQQAKlKZ8GtyKKHtcbfdjLq6jmfIXVOkl13Mtg0ngRLt8poYp3nZyTE5mIL+CeKBA==', N'5a4e306f-649a-4f77-81ac-817a14b71773', NULL, 0, 0, NULL, 1, 0, N'admin@thevidstore.com')


INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fa136b90-e054-456d-82df-414723534549', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7aac2844-5349-4155-b759-2f0a772eea0d', N'fa136b90-e054-456d-82df-414723534549')

");
        }
        
        public override void Down()
        {
        }
    }
}
