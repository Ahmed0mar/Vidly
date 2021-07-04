namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMembershiptTypeData : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set Name = 'Pay as You Go' where Id=1 ");
            Sql("update MembershipTypes set Name = 'Monthly' where Id=2 ");
            Sql("update MembershipTypes set Name = 'Every 3 Months' where Id=3 ");
            Sql("update MembershipTypes set Name = 'Annually' where Id=4 ");
        }
        
        public override void Down()
        {
        }
    }
}
