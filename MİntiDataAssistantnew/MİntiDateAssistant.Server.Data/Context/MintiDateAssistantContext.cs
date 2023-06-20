using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MİntiDateAssistant.Server.Data.Models;

public partial class MintiDateAssistantContext : DbContext
{
    public MintiDateAssistantContext()
    {
    }

    public MintiDateAssistantContext(DbContextOptions<MintiDateAssistantContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<BloodGroup> BloodGroups { get; set; }

    public virtual DbSet<BodySize> BodySizes { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Dealer> Dealers { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<GuestActivityDetail> GuestActivityDetails { get; set; }

    public virtual DbSet<MinticityUser> MinticityUsers { get; set; }

    public virtual DbSet<TravelType> TravelTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=185.8.33.20;Database=MintiDateAssistant;User Id= tugce; Password=Tugçe.54321;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PK__Activity__45F4A7F13AE54F1D");

            entity.ToTable("Activity");

            entity.Property(e => e.ActivityId).HasColumnName("ActivityID");
            entity.Property(e => e.ActivityName).HasMaxLength(50);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<BloodGroup>(entity =>
        {
            entity.HasKey(e => e.BloodId).HasName("PK__BloodGro__952FE87D975ABF07");

            entity.Property(e => e.BloodId).HasColumnName("BloodID");
            entity.Property(e => e.BloodGroup1)
                .HasMaxLength(10)
                .HasColumnName("BloodGroup");
        });

        modelBuilder.Entity<BodySize>(entity =>
        {
            entity.HasKey(e => e.SizeId).HasName("PK__BodySize__83BD095AF84C2123");

            entity.Property(e => e.SizeId).HasColumnName("SizeID");
            entity.Property(e => e.BodySize1)
                .HasMaxLength(5)
                .HasColumnName("BodySize");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__Cities__F2D21A969DBBA3EA");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CityName)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Dealer>(entity =>
        {
            entity.HasKey(e => e.DealerId).HasName("PK__Dealers__CA2F8E92FD7EC22A");

            entity.Property(e => e.DealerId).HasColumnName("DealerID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.DealerName)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.GuestId).HasName("PK__Guests__0C423C32B2A63A49");

            entity.Property(e => e.GuestId).HasColumnName("GuestID");
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.BloodId).HasColumnName("BloodID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.DealerId).HasColumnName("DealerID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.GuestName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.PersonalNumber)
                .HasMaxLength(11)
                .IsFixedLength();
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.SchoolId).HasColumnName("SchoolID");
            entity.Property(e => e.SizeId).HasColumnName("SizeID");
            entity.Property(e => e.SmokingId).HasColumnName("SmokingID");
        });

        modelBuilder.Entity<GuestActivityDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId).HasName("PK__GuestAct__135C314DFD37E6FC");

            entity.Property(e => e.DetailId).HasColumnName("DetailID");
            entity.Property(e => e.ActivityId).HasColumnName("ActivityID");
            entity.Property(e => e.ArrivalDate).HasColumnType("datetime");
            entity.Property(e => e.CheckInDate).HasColumnType("datetime");
            entity.Property(e => e.CheckOutDate).HasColumnType("datetime");
            entity.Property(e => e.DepartureDate).HasColumnType("datetime");
            entity.Property(e => e.GuestId).HasColumnName("GuestID");
            entity.Property(e => e.RoomNumber).HasMaxLength(10);
            entity.Property(e => e.RoommateId1).HasColumnName("RoommateID1");
            entity.Property(e => e.RoommateId2).HasColumnName("RoommateID2");
            entity.Property(e => e.TransferDate).HasColumnType("datetime");
            entity.Property(e => e.TravelTypeId).HasColumnName("TravelTypeID");
        });

        modelBuilder.Entity<MinticityUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Minticit__1788CCAC9C40AE94");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(256);
            entity.Property(e => e.Salt).HasMaxLength(10);
        });

        modelBuilder.Entity<TravelType>(entity =>
        {
            entity.HasKey(e => e.TravelId).HasName("PK__TravelTy__E93152158888DD8F");

            entity.Property(e => e.TravelId).HasColumnName("TravelID");
            entity.Property(e => e.TravelName)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
