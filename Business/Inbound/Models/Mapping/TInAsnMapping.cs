using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TInAsnMapping : IEntityTypeConfiguration<TInAsn>
    {
        public void Configure(EntityTypeBuilder<TInAsn> entity)
        {
            entity.HasKey(e => new { e.Id })
                .HasName("PRIMARY");

            entity.ToTable("t_in_asn");

            entity.HasComment("到货通知单主表");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)")
                .HasComment("主键ID")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.CreatedTime)
                .HasColumnName("created_time")
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间");

            entity.Property(e => e.Comment).HasColumnName("comment");

            entity.Property(e => e.BatchNo)
                .IsRequired()
                .HasColumnName("batch_no")
                .HasColumnType("varchar(30)")
                .HasComment("批号 客户有的话用客户的，没有自己输入一个")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.BizCode)
                .IsRequired()
                .HasColumnName("biz_code")
                .HasColumnType("varchar(30)")
                .HasComment("业务类型 零售/电商/标签/混合")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.BrandId)
                .HasColumnName("brand_id")
                .HasColumnType("int(11)")
                .HasComment("品牌ID");

            entity.Property(e => e.CartonQty)
                .HasColumnName("carton_qty")
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'0'")
                .HasComment("总箱数");

            entity.Property(e => e.CheckStatus)
                .IsRequired()
                .HasColumnName("check_status")
                .HasColumnType("varchar(30)")
                .HasComment("验货状态 未验货,验货中,已完成")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code")
                .HasColumnType("varchar(30)")
                .HasComment("单据编号")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("created_by")
                .HasColumnType("varchar(30)")
                .HasComment("创建人")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.CustId)
                .HasColumnName("cust_id")
                .HasColumnType("int(11)")
                .HasComment("客户ID");

            entity.Property(e => e.DeliveyTo)
                .HasColumnName("delivey_to")
                .HasColumnType("varchar(100)")
                .HasComment("收货人")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.ExpAt)
                .HasColumnName("exp_at")
                .HasColumnType("datetime")
                .HasComment("预计到达时间");

            entity.Property(e => e.GoodsType)
                .IsRequired()
                .HasColumnName("goods_type")
                .HasColumnType("varchar(30)")
                .HasComment("货物类型 物料/商品 Mat/Prod")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.InvoiceNo)
                .HasColumnName("invoice_no")
                .HasColumnType("varchar(30)")
                .HasComment("发票号 如果是人工导入的，直接填成与批号一致")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.IsCiq)
                .HasColumnName("is_ciq")
                .HasColumnType("bit(1)")
                .HasComment("是否有CIQ 1是，0否");

            entity.Property(e => e.IsDeleted)
                .HasColumnName("is_deleted")
                .HasColumnType("bit(1)")
                .HasDefaultValueSql("b'0'")
                .HasComment("是否删除");

            entity.Property(e => e.LastModifiedBy)
                .HasColumnName("last_modified_by")
                .HasColumnType("varchar(30)")
                .HasComment("修改人")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.LastModifiedTime)
                .HasColumnName("last_modified_time")
                .HasColumnType("datetime")
                .HasComment("修改时间");

            entity.Property(e => e.PieceQty)
                .HasColumnName("piece_qty")
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'0'")
                .HasComment("总件数");

            entity.Property(e => e.RefCode)
                .HasColumnName("ref_code")
                .HasColumnType("varchar(30)")
                .HasComment("客户方单号 来源于客户系统的单据编号")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.RefPo)
                .HasColumnName("ref_po")
                .HasColumnType("varchar(30)")
                .HasComment("客户的采购单号")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.SrcCode)
                .IsRequired()
                .HasColumnName("src_code")
                .HasColumnType("varchar(30)")
                .HasComment("数据来源 导入Import,接口Interface")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("varchar(30)")
                .HasComment("单据状态")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.TransCode)
                .IsRequired()
                .HasColumnName("trans_code")
                .HasColumnType("varchar(30)")
                .HasComment("作业类型 入库/出库/退货/退仓/盘点/调整/移货/补货/冻结/解冻")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.TypeCode)
                .IsRequired()
                .HasColumnName("type_code")
                .HasColumnType("varchar(30)")
                .HasComment("单据类型 到货通知单")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.Volume)
                .HasColumnName("volume")
                .HasDefaultValueSql("'0'")
                .HasComment("总体积");

            entity.Property(e => e.Weight)
                .HasColumnName("weight")
                .HasDefaultValueSql("'0'")
                .HasComment("总重量");

            entity.Property(e => e.WhId)
                .HasColumnName("wh_id")
                .HasColumnType("int(11)")
                .HasComment("仓库ID");
        }
    }
}