using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Product.Models
{
    public class TProdMatMapping : IEntityTypeConfiguration<TProdMat>
    {
        public void Configure(EntityTypeBuilder<TProdMat> entity)
        {
            entity.ToTable("t_prod_mat");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Barcode).HasColumnName("barcode");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.CatLvl_1).HasColumnName("cat_lvl_1");
            entity.Property(e => e.CatLvl_2).HasColumnName("cat_lvl_2");
            entity.Property(e => e.CatLvl_3).HasColumnName("cat_lvl_3");
            entity.Property(e => e.Spec).HasColumnName("spec");
            entity.Property(e => e.X).HasColumnName("x");
            entity.Property(e => e.XUnit).HasColumnName("x_unit");
            entity.Property(e => e.Y).HasColumnName("y");
            entity.Property(e => e.YUnit).HasColumnName("y_unit");
            entity.Property(e => e.Z).HasColumnName("z");
            entity.Property(e => e.ZUnit).HasColumnName("z_unit");
            entity.Property(e => e.PUom).HasColumnName("p_uom");
            entity.Property(e => e.PToA).HasColumnName("p_to_a");
            entity.Property(e => e.AUom).HasColumnName("a_uom");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by");
            entity.Property(e => e.LastModifiedTime).HasColumnName("last_modified_time");
        }
    }
}