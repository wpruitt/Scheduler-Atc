using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ATCScheduler.Data;
using ATCScheduler.Models;

namespace ATCScheduler.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170921145548_ShiftModelAddition")]
    partial class ShiftModelAddition
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ATCScheduler.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("Zipcode");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ATCScheduler.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApproverId");

                    b.Property<string>("ApproverNote");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndTime");

                    b.Property<bool>("Medical");

                    b.Property<int>("RequestStatus");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("UserId");

                    b.HasKey("AppointmentId");

                    b.HasIndex("ApproverId");

                    b.HasIndex("UserId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("ATCScheduler.Models.ATController", b =>
                {
                    b.Property<int>("ControllerId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("FlyingStatus");

                    b.Property<int?>("ShiftId");

                    b.Property<int>("SkillLevelId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("ControllerId");

                    b.HasIndex("ShiftId");

                    b.HasIndex("SkillLevelId");

                    b.HasIndex("UserId");

                    b.ToTable("ATController");
                });

            modelBuilder.Entity("ATCScheduler.Models.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ATControllerControllerId");

                    b.Property<string>("Abbreviation")
                        .IsRequired();

                    b.Property<int?>("ShiftId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("PositionId");

                    b.HasIndex("ATControllerControllerId");

                    b.HasIndex("ShiftId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("ATCScheduler.Models.Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ATControllerId");

                    b.Property<DateTime>("EndTime");

                    b.Property<int>("ShiftStatus");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ShiftId");

                    b.ToTable("Shift");
                });

            modelBuilder.Entity("ATCScheduler.Models.SkillLevel", b =>
                {
                    b.Property<int>("SkillLevelId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PositionId");

                    b.Property<string>("Title");

                    b.HasKey("SkillLevelId");

                    b.HasIndex("PositionId");

                    b.ToTable("SkillLevel");
                });

            modelBuilder.Entity("ATCScheduler.Models.TimeOffRequest", b =>
                {
                    b.Property<int>("TimeOffRequestId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApproverId");

                    b.Property<string>("ApproverNotes");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("TORStatus");

                    b.Property<string>("UserId");

                    b.HasKey("TimeOffRequestId");

                    b.HasIndex("ApproverId");

                    b.HasIndex("UserId");

                    b.ToTable("TimeOffRequest");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ATCScheduler.Models.Appointment", b =>
                {
                    b.HasOne("ATCScheduler.Models.ApplicationUser", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverId");

                    b.HasOne("ATCScheduler.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ATCScheduler.Models.ATController", b =>
                {
                    b.HasOne("ATCScheduler.Models.Shift")
                        .WithMany("ATCControllers")
                        .HasForeignKey("ShiftId");

                    b.HasOne("ATCScheduler.Models.SkillLevel", "SkillLevel")
                        .WithMany()
                        .HasForeignKey("SkillLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ATCScheduler.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ATCScheduler.Models.Position", b =>
                {
                    b.HasOne("ATCScheduler.Models.ATController")
                        .WithMany("QualifiedPositions")
                        .HasForeignKey("ATControllerControllerId");

                    b.HasOne("ATCScheduler.Models.Shift")
                        .WithMany("RequiredPositions")
                        .HasForeignKey("ShiftId");
                });

            modelBuilder.Entity("ATCScheduler.Models.SkillLevel", b =>
                {
                    b.HasOne("ATCScheduler.Models.Position")
                        .WithMany("SkillLevels")
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("ATCScheduler.Models.TimeOffRequest", b =>
                {
                    b.HasOne("ATCScheduler.Models.ApplicationUser", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverId");

                    b.HasOne("ATCScheduler.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ATCScheduler.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ATCScheduler.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ATCScheduler.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
