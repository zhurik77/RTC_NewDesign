using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace tets_bogdan.Models
{
    public partial class RTKDatabaseContext : DbContext
    {
        public RTKDatabaseContext()
        {
        }

        public RTKDatabaseContext(DbContextOptions<RTKDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Competition> Competitions { get; set; } = null!;
        public virtual DbSet<CompetitionType> CompetitionTypes { get; set; } = null!;
        public virtual DbSet<Participant> Participants { get; set; } = null!;
        public virtual DbSet<Robot> Robots { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<Trainer> Trainers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=DESKTOP-ITVEB8Q\\SQLEXPRESS;Trusted_connection=Yes;DataBase=RTKDatabase;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competition>(entity =>
            {
                entity.ToTable("Competition");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CompetitionTypeId).HasColumnName("competitionTypeId");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Place)
                    .HasMaxLength(50)
                    .HasColumnName("place");

                entity.Property(e => e.SelectCategoryId)
                    .HasMaxLength(10)
                    .HasColumnName("selectCategoryId")
                    .IsFixedLength();

                entity.Property(e => e.StageTypeId).HasColumnName("stageTypeId");

                entity.HasOne(d => d.CompetitionType)
                    .WithMany(p => p.Competitions)
                    .HasForeignKey(d => d.CompetitionTypeId)
                    .HasConstraintName("FK_Competition_CompetitionType");
            });

            modelBuilder.Entity<CompetitionType>(entity =>
            {
                entity.ToTable("CompetitionType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.ToTable("Participant");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.Documents)
                    .HasMaxLength(100)
                    .HasColumnName("documents");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Mesto)
                    .HasMaxLength(100)
                    .HasColumnName("mesto");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Robot>(entity =>
            {
                entity.ToTable("Robot");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.Photo)
                    .HasMaxLength(100)
                    .HasColumnName("photo");

                entity.Property(e => e.VideoLink)
                    .HasMaxLength(100)
                    .HasColumnName("videoLink");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DateTest)
                    .HasColumnType("date")
                    .HasColumnName("dateTest");

                entity.Property(e => e.FirstParticipantId).HasColumnName("firstParticipantId");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.SecondParticipantId).HasColumnName("secondParticipantId");

                entity.Property(e => e.SelectedStageId).HasColumnName("selectedStageId");

                entity.Property(e => e.TrainerId).HasColumnName("trainerId");

                entity.HasOne(d => d.FirstParticipant)
                    .WithMany(p => p.TeamFirstParticipants)
                    .HasForeignKey(d => d.FirstParticipantId)
                    .HasConstraintName("FK_Team_Participant");

                entity.HasOne(d => d.Robot)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.RobotId)
                    .HasConstraintName("FK_Team_Robot");

                entity.HasOne(d => d.SecondParticipant)
                    .WithMany(p => p.TeamSecondParticipants)
                    .HasForeignKey(d => d.SecondParticipantId)
                    .HasConstraintName("FK_Team_Participant1");

                entity.HasOne(d => d.SelectedStage)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.SelectedStageId)
                    .HasConstraintName("FK_Team_Competition");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.TrainerId)
                    .HasConstraintName("FK_Team_Trainer");
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.ToTable("Trainer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.Documents)
                    .HasMaxLength(100)
                    .HasColumnName("documents");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Mesto)
                    .HasMaxLength(100)
                    .HasColumnName("mesto");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
