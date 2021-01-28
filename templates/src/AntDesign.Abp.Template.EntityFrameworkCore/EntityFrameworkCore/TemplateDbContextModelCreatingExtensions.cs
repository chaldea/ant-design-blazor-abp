using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace AntDesign.Abp.Template.EntityFrameworkCore
{
    public static class TemplateDbContextModelCreatingExtensions
    {
        public static void ConfigureTemplate(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(TemplateConsts.DbTablePrefix + "YourEntities", TemplateConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}