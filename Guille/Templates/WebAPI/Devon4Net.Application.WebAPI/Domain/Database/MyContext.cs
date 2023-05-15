using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Devon4Net.Application.WebAPI.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Domain.Database
{
    public partial class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accesscode> Accesscodes { get; set; }
        public virtual DbSet<Queue> Queues { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=master;User Id=sa;Password=sdiaasDan!sgiafASFa2501!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accesscode>(entity =>
            {
                entity.ToTable("accesscodes", "jtq");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createdTime");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("endTime");

                entity.Property(e => e.QueueId).HasColumnName("queueId");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("startTime");

                entity.Property(e => e.Status)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Queue)
                    .WithMany(p => p.Accesscodes)
                    .HasForeignKey(d => d.QueueId)
                    .HasConstraintName("FK__accesscod__queue__184C96B4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Accesscodes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__accesscod__userI__1940BAED");
            });

            modelBuilder.Entity<Queue>(entity =>
            {
                entity.ToTable("queues", "jtq");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CloseTime)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("closeTime");

                entity.Property(e => e.Closed).HasColumnName("closed");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Link)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("link");

                entity.Property(e => e.Logo)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("logo");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.OpenTime)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("openTime");

                entity.Property(e => e.Started).HasColumnName("started");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Queues)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__queues__userId__15702A09");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "jtq");

                entity.HasIndex(e => e.Username, "UQ__users__F3DBC57230815AB3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
