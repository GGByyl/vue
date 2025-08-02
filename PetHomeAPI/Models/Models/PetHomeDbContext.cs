using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models.Models;

public partial class PetHomeDbContext : DbContext
{
    public PetHomeDbContext()
    {
    }

    public PetHomeDbContext(DbContextOptions<PetHomeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Adopt> Adopts { get; set; }

    public virtual DbSet<Appoint> Appoints { get; set; }

    public virtual DbSet<AppointState> AppointStates { get; set; }

    public virtual DbSet<Collect> Collects { get; set; }

    public virtual DbSet<Commodity> Commodities { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderType> OrderTypes { get; set; }

    public virtual DbSet<Pending> Pendings { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<PetFosterCare> PetFosterCares { get; set; }

    public virtual DbSet<ServeType> ServeTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=rm-bp1r3nayr364hpq70xo.sqlserver.rds.aliyuncs.com, 3433;uid=sa123;pwd=Aa123bba;database=PetHomeDB;trustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Aid).HasName("PK__Account__C6970A108E0407ED");

            entity.ToTable("Account");

            entity.Property(e => e.IdNumber).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Nickname).HasMaxLength(50);
            entity.Property(e => e.Number).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Sex).HasDefaultValue(1);
        });

        modelBuilder.Entity<Adopt>(entity =>
        {
            entity.HasKey(e => e.AdId).HasName("PK__Adopt__7130D58ED1D498B1");

            entity.ToTable("Adopt");

            entity.Property(e => e.AdId).HasColumnName("AdID");
            entity.Property(e => e.AdoptUserId).HasColumnName("AdoptUserID");
            entity.Property(e => e.Apid).HasColumnName("APID");
            entity.Property(e => e.Describe).HasMaxLength(200);
        });

        modelBuilder.Entity<Appoint>(entity =>
        {
            entity.HasKey(e => e.Aid).HasName("PK__Appoint__C69007C8DB4D2E58");

            entity.ToTable("Appoint");

            entity.Property(e => e.Aid).HasColumnName("AID");
            entity.Property(e => e.Astate).HasColumnName("AState");
            entity.Property(e => e.Atime).HasColumnName("ATime");
            entity.Property(e => e.Atype).HasColumnName("AType");
            entity.Property(e => e.Auid).HasColumnName("AUID");
        });

        modelBuilder.Entity<AppointState>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__AppointS__CA195970AB3DD239");

            entity.ToTable("AppointState");

            entity.Property(e => e.Sid).HasColumnName("SID");
            entity.Property(e => e.State).HasMaxLength(50);
        });

        modelBuilder.Entity<Collect>(entity =>
        {
            entity.HasKey(e => e.CoId).HasName("PK__Collect__A25F3E0B52615532");

            entity.ToTable("Collect");

            entity.Property(e => e.CoId).HasColumnName("CoID");
            entity.Property(e => e.Cid).HasColumnName("CID");
            entity.Property(e => e.Eid).HasColumnName("EID");
        });

        modelBuilder.Entity<Commodity>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__Commodit__C1F8DC5985EC246A");

            entity.ToTable("Commodity");

            entity.Property(e => e.Cid).HasColumnName("CID");
            entity.Property(e => e.Cname)
                .HasMaxLength(50)
                .HasColumnName("CName");
            entity.Property(e => e.DateIssued).HasColumnType("datetime");
            entity.Property(e => e.Describe).HasMaxLength(200);
            entity.Property(e => e.ManufactureTiem).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Yieldly).HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderNumber).HasName("PK__Orders__CAC5E742B61456BE");

            entity.Property(e => e.OrderNumber).HasMaxLength(200);
            entity.Property(e => e.OrderGoodsId).HasColumnName("OrderGoodsID");
            entity.Property(e => e.OrderSite).HasMaxLength(200);
            entity.Property(e => e.OrderTime).HasColumnType("datetime");
            entity.Property(e => e.OrderUserId).HasColumnName("OrderUserID");
            entity.Property(e => e.TotalPrices).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<OrderType>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__OrderTyp__CA19597083278329");

            entity.ToTable("OrderType");

            entity.Property(e => e.Sid).HasColumnName("SID");
            entity.Property(e => e.Stype)
                .HasMaxLength(50)
                .HasColumnName("SType");
        });

        modelBuilder.Entity<Pending>(entity =>
        {
            entity.HasKey(e => e.PeId).HasName("PK__Pending__A640F3641042BFFC");

            entity.ToTable("Pending");

            entity.Property(e => e.PeId).HasColumnName("PeID");
            entity.Property(e => e.Affair).HasMaxLength(200);
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__Pet__C577552093B3BB27");

            entity.ToTable("Pet");

            entity.Property(e => e.Pid).HasColumnName("PID");
            entity.Property(e => e.Breed).HasMaxLength(50);
            entity.Property(e => e.Describe).HasMaxLength(200);
            entity.Property(e => e.Pname)
                .HasMaxLength(50)
                .HasColumnName("PName");
            entity.Property(e => e.Psex).HasColumnName("PSex");
            entity.Property(e => e.Source).HasMaxLength(50);
            entity.Property(e => e.Vaccine).HasMaxLength(50);
        });

        modelBuilder.Entity<PetFosterCare>(entity =>
        {
            entity.HasKey(e => e.Fid).HasName("PK__PetFoste__C1BEA5A240F9400F");

            entity.ToTable("PetFosterCare");

            entity.Property(e => e.Fid).HasColumnName("FID");
            entity.Property(e => e.Describe).HasMaxLength(200);
            entity.Property(e => e.Fpid).HasColumnName("FPID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<ServeType>(entity =>
        {
            entity.HasKey(e => e.Seid).HasName("PK__ServeTyp__F56A975E75055D4B");

            entity.ToTable("ServeType");

            entity.Property(e => e.Seid).HasColumnName("SEID");
            entity.Property(e => e.Setype)
                .HasMaxLength(50)
                .HasColumnName("SEType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
