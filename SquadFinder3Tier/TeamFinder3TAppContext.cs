using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SquadFinder3Tier
{
    public partial class TeamFinder3TAppContext : DbContext
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public TeamFinder3TAppContext()
        {
            
        }

        public TeamFinder3TAppContext(DbContextOptions<TeamFinder3TAppContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Squad> Squad { get; set; }
        public virtual DbSet<SquadMembers> SquadMembers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TeamFinder3TApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Members>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__Members__42A68F27F37EE0FC");

                entity.Property(e => e.MemberId)
                    .HasColumnName("Member_ID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Squad>(entity =>
            {
                entity.Property(e => e.SquadId)
                    .HasColumnName("Squad_ID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfSquadMembers).HasColumnName("No_Of_Squad_Members");

                entity.Property(e => e.Sport).IsUnicode(false);

                entity.Property(e => e.SquadLeader)
                    .HasColumnName("Squad_Leader")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SquadMembers>(entity =>
            {
                entity.HasKey(e => e.SquadMemberId)
                    .HasName("PK__SquadMem__AAC029378FF38BFC");

                entity.Property(e => e.SquadMemberId)
                    .HasColumnName("Squad_Member_ID")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasColumnName("Member_ID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SquadId)
                    .IsRequired()
                    .HasColumnName("Squad_ID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.SquadMembers)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SquadMemb__Membe__797309D9");

                entity.HasOne(d => d.Squad)
                    .WithMany(p => p.SquadMembers)
                    .HasForeignKey(d => d.SquadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SquadMemb__Squad__787EE5A0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
