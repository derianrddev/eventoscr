﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BZPAY_BE.Models
{
    public partial class MembershipContext : DbContext
    {
        public MembershipContext()
        {
        }

        public MembershipContext(DbContextOptions<MembershipContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspnetApplication> AspnetApplications { get; set; } = null!;
        public virtual DbSet<AspnetMembership> AspnetMemberships { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;

        public virtual DbSet<Asiento> Asientos { get; set; }

        public virtual DbSet<Compra> Compras { get; set; }

        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

        public virtual DbSet<Entrada> Entradas { get; set; }

        public virtual DbSet<Escenario> Escenarios { get; set; }

        public virtual DbSet<Evento> Eventos { get; set; }

        public virtual DbSet<Proyecto1specialticketuser> Proyecto1specialticketusers { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Roleclaim> Roleclaims { get; set; }

        public virtual DbSet<TipoEscenario> TipoEscenarios { get; set; }

        public virtual DbSet<TipoEvento> TipoEventos { get; set; }

        public virtual DbSet<Userclaim> Userclaims { get; set; }

        public virtual DbSet<Userlogin> Userlogins { get; set; }

        public virtual DbSet<Usertoken> Usertokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("MembershipContext");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspnetApplication>(entity =>
            {
                entity.HasKey(e => e.ApplicationId)
                    .HasName("PK__aspnet_A__C93A4C98949BB888")
                    .IsClustered(false);

                entity.ToTable("aspnet_Applications");

                entity.HasIndex(e => e.LoweredApplicationName, "UQ__aspnet_A__17477DE4B9F37709")
                    .IsUnique();

                entity.HasIndex(e => e.ApplicationName, "UQ__aspnet_A__30910331C3BBCA84")
                    .IsUnique();

                entity.HasIndex(e => e.LoweredApplicationName, "aspnet_Applications_Index")
                    .IsClustered();

                entity.Property(e => e.ApplicationId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ApplicationName).HasMaxLength(256);

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredApplicationName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspnetMembership>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__aspnet_M__1788CC4DF9C24318")
                    .IsClustered(false);

                entity.ToTable("aspnet_Membership");

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredEmail }, "aspnet_Membership_index")
                    .IsClustered();

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredEmail).HasMaxLength(256);

                entity.Property(e => e.MobilePin)
                    .HasMaxLength(16)
                    .HasColumnName("MobilePIN");

                entity.Property(e => e.Password).HasMaxLength(128);

                entity.Property(e => e.PasswordAnswer).HasMaxLength(128);

                entity.Property(e => e.PasswordQuestion).HasMaxLength(256);

                entity.Property(e => e.PasswordSalt).HasMaxLength(128);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetMemberships)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Me__Appli__7C4F7684");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.AspnetMembership)
                    .HasForeignKey<AspnetMembership>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Me__UserI__7D439ABD");
            });

            //modelBuilder.Entity<Users>(entity =>
            //{
            //    entity.HasKey(e => e.UserId)
            //        .HasName("PK__aspnet_U__1788CC4D1F46F085")
            //        .IsClustered(false);

            //    entity.ToTable("Users");

            //    entity.HasIndex(e => new { e.ApplicationId, e.LoweredUserName }, "aspnet_Users_Index")
            //        .IsUnique()
            //        .IsClustered();

            //    entity.HasIndex(e => new { e.ApplicationId, e.LastActivityDate }, "aspnet_Users_Index2");

            //    entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

            //    entity.Property(e => e.LoweredUserName).HasMaxLength(256);

            //    entity.Property(e => e.MobileAlias).HasMaxLength(16);

            //    entity.Property(e => e.UserName).HasMaxLength(256);

            //    entity.HasOne(d => d.Application)
            //        .WithMany(p => p.Users)
            //        .HasForeignKey(d => d.ApplicationId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__aspnet_Us__Appli__03F0984C");
            //});

            modelBuilder.Entity<Asiento>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("asiento", tb => tb.HasComment("tipos de asiento del escenario"));

                entity.HasIndex(e => e.IdEscenario, "id_escenario");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Cantidad).HasColumnName("cantidad");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");
                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion")
                    .UseCollation("utf8mb3_spanish_ci")
                    .HasCharSet("utf8mb3");
                entity.Property(e => e.IdEscenario).HasColumnName("id_escenario");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");
                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");

                entity.HasOne(d => d.IdEscenarioNavigation).WithMany(p => p.Asientos)
                    .HasForeignKey(d => d.IdEscenario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("asiento_ibfk_1");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity
                    .ToTable("compra")
                    .HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.IdCliente, "id_cliente");

                entity.HasIndex(e => e.IdEntrada, "id_entrada");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Cantidad).HasColumnName("cantidad");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");
                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
                entity.Property(e => e.FechaPago)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_pago");
                entity.Property(e => e.FechaReserva)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_reserva");
                entity.Property(e => e.IdCliente)
                    .HasColumnName("id_cliente")
                    .UseCollation("utf8mb4_0900_ai_ci")
                    .HasCharSet("utf8mb4");
                entity.Property(e => e.IdEntrada).HasColumnName("id_entrada");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("compra_ibfk_1");

                entity.HasOne(d => d.IdEntradaNavigation).WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdEntrada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("compra_ibfk_2");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);
                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Entrada>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("entradas");

                entity.HasIndex(e => e.IdEvento, "id_evento");

                entity.HasIndex(e => new { e.TipoAsiento, e.IdEvento }, "uk_entradas_tipo_asiento_id_evento").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");
                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
                entity.Property(e => e.Disponibles).HasColumnName("disponibles");
                entity.Property(e => e.IdEvento).HasColumnName("id_evento");
                entity.Property(e => e.Precio)
                    .HasPrecision(10)
                    .HasColumnName("precio");
                entity.Property(e => e.TipoAsiento)
                    .HasMaxLength(100)
                    .HasColumnName("tipo_asiento")
                    .UseCollation("utf8mb3_spanish_ci")
                    .HasCharSet("utf8mb3");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");
                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");

                entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.IdEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("entradas_ibfk_1");
            });

            modelBuilder.Entity<Escenario>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("escenario");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");
                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
                entity.Property(e => e.Localizacion)
                    .HasMaxLength(100)
                    .HasColumnName("localizacion")
                    .UseCollation("utf8mb3_spanish_ci")
                    .HasCharSet("utf8mb3");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre")
                    .UseCollation("utf8mb3_spanish_ci")
                    .HasCharSet("utf8mb3");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");
                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("evento");

                entity.HasIndex(e => e.IdEscenario, "id_escenario1");

                entity.HasIndex(e => e.IdTipoEvento, "id_tipo_evento");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");
                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion")
                    .UseCollation("utf8mb3_spanish_ci")
                    .HasCharSet("utf8mb3");
                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");
                entity.Property(e => e.IdEscenario).HasColumnName("id_escenario");
                entity.Property(e => e.IdTipoEvento).HasColumnName("id_tipo_evento");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");
                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");

                entity.HasOne(d => d.IdEscenarioNavigation).WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdEscenario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("evento_ibfk_1");

                entity.HasOne(d => d.IdTipoEventoNavigation).WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdTipoEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("evento_ibfk_2");
            });

            modelBuilder.Entity<Proyecto1specialticketuser>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("proyecto1specialticketusers");

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.Proyecto1specialticketuser)
                    .HasForeignKey<Proyecto1specialticketuser>(d => d.Id)
                    .HasConstraintName("FK_Proyecto1SpecialTicketUsers_Users_Id");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("roles");
            });

            modelBuilder.Entity<Roleclaim>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("roleclaims");

                entity.HasIndex(e => e.RoleId, "FK_RoleClaims_Roles_RoleId");

                entity.HasOne(d => d.Role).WithMany(p => p.Roleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RoleClaims_Roles_RoleId");
            });

            modelBuilder.Entity<TipoEscenario>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("tipo_escenario");

                entity.HasIndex(e => e.IdEscenario, "id_escenario2");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");
                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion")
                    .UseCollation("utf8mb3_spanish_ci")
                    .HasCharSet("utf8mb3");
                entity.Property(e => e.IdEscenario).HasColumnName("id_escenario");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");
                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");

                entity.HasOne(d => d.IdEscenarioNavigation).WithMany(p => p.TipoEscenarios)
                    .HasForeignKey(d => d.IdEscenario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tipo_escenario_ibfk_1");
            });

            modelBuilder.Entity<TipoEvento>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("tipo_evento");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");
                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion")
                    .UseCollation("utf8mb3_spanish_ci")
                    .HasCharSet("utf8mb3");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");
                entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.UserName).HasColumnName("UserName").HasColumnType("longtext");
                entity.Property(e => e.NormalizedUserName).HasColumnName("NormalizedUserName").HasColumnType("longtext");
                entity.Property(e => e.Email).HasColumnName("Email").HasColumnType("longtext");
                entity.Property(e => e.NormalizedEmail).HasColumnName("NormalizedEmail").HasColumnType("longtext");
                entity.Property(e => e.EmailConfirmed).HasColumnName("EmailConfirmed").HasColumnType("tinyint(1)");
                entity.Property(e => e.PasswordHash).HasColumnName("PasswordHash").HasColumnType("longtext");
                entity.Property(e => e.SecurityStamp).HasColumnName("SecurityStamp").HasColumnType("longtext");
                entity.Property(e => e.ConcurrencyStamp).HasColumnName("ConcurrencyStamp").HasColumnType("longtext");
                entity.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber").HasColumnType("longtext");
                entity.Property(e => e.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed").HasColumnType("tinyint(1)");
                entity.Property(e => e.TwoFactorEnabled).HasColumnName("TwoFactorEnabled").HasColumnType("tinyint(1)");
                entity.Property(e => e.LockoutEnd).HasColumnName("LockoutEnd").HasColumnType("datetime(6)");
                entity.Property(e => e.LockoutEnabled).HasColumnName("LockoutEnabled").HasColumnType("tinyint(1)");
                entity.Property(e => e.AccessFailedCount).HasColumnName("AccessFailedCount");


                entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "Userrole",
                        r => r.HasOne<Role>().WithMany()
                            .HasForeignKey("RoleId")
                            .HasConstraintName("FK_UserRoles_Roles_RoleId"),
                        l => l.HasOne<User>().WithMany()
                            .HasForeignKey("UserId")
                            .HasConstraintName("FK_UserRoles_Users_UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId")
                                .HasName("PRIMARY")
                                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                            j.ToTable("userroles");
                            j.HasIndex(new[] { "RoleId" }, "FK_UserRoles_Roles_RoleId");
                        });
            });

            modelBuilder.Entity<Userclaim>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("userclaims");

                entity.HasIndex(e => e.UserId, "FK_UserClaims_Users_UserId");

                entity.HasOne(d => d.User).WithMany(p => p.Userclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserClaims_Users_UserId");
            });

            modelBuilder.Entity<Userlogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("userlogins");

                entity.HasIndex(e => e.UserId, "FK_UserLogins_Users_UserId");

                entity.HasOne(d => d.User).WithMany(p => p.Userlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserLogins_Users_UserId");
            });

            modelBuilder.Entity<Usertoken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("usertokens");

                entity.HasOne(d => d.User).WithMany(p => p.Usertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserTokens_Users_UserId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
