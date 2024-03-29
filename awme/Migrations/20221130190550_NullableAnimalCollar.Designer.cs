﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using awme.Data;

#nullable disable

namespace awme.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221130190550_NullableAnimalCollar")]
    partial class NullableAnimalCollar
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProfileProfile", b =>
                {
                    b.Property<int>("FollowersId")
                        .HasColumnType("int");

                    b.Property<int>("FollowingId")
                        .HasColumnType("int");

                    b.HasKey("FollowersId", "FollowingId");

                    b.HasIndex("FollowingId");

                    b.ToTable("ProfileProfile");
                });

            modelBuilder.Entity("awme.Data.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CollarId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CollarId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("awme.Data.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("AvatarImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CollarId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CollarId")
                        .IsUnique()
                        .HasFilter("[CollarId] IS NOT NULL");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("awme.Data.Models.AnimalType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnimalTypes");
                });

            modelBuilder.Entity("awme.Data.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FirstProfileId")
                        .HasColumnType("int");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.Property<int>("SecondProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirstProfileId")
                        .IsUnique();

                    b.HasIndex("ProfileId");

                    b.HasIndex("SecondProfileId")
                        .IsUnique();

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("awme.Data.Models.Collar", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("InUse")
                        .HasColumnType("bit");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Collars");
                });

            modelBuilder.Entity("awme.Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("ProfileId")
                        .IsUnique();

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("awme.Data.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LikedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("ProfileId")
                        .IsUnique();

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("awme.Data.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ChatId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("awme.Data.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("awme.Data.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("awme.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@admin.com",
                            FirstName = "Admin",
                            LastName = "Admin",
                            PasswordHash = new byte[] { 61, 229, 166, 172, 151, 182, 154, 31, 203, 111, 121, 104, 158, 122, 157, 233, 248, 126, 150, 80, 169, 193, 17, 167, 57, 99, 22, 158, 59, 196, 216, 42, 25, 54, 63, 66, 70, 60, 172, 108, 167, 47, 244, 177, 157, 177, 203, 68, 222, 66, 84, 126, 154, 69, 150, 141, 159, 184, 37, 127, 60, 219, 160, 237 },
                            PasswordSalt = new byte[] { 231, 220, 15, 116, 27, 59, 43, 134, 10, 33, 21, 143, 26, 21, 24, 36, 51, 180, 210, 65, 211, 200, 146, 160, 50, 132, 36, 136, 35, 64, 127, 77, 12, 53, 186, 13, 170, 142, 107, 3, 4, 208, 136, 68, 27, 77, 156, 75, 103, 228, 34, 188, 170, 19, 145, 76, 113, 74, 108, 184, 70, 74, 142, 156, 1, 201, 40, 12, 90, 235, 170, 160, 144, 28, 133, 126, 37, 164, 120, 101, 92, 85, 243, 158, 177, 68, 134, 189, 163, 184, 134, 71, 9, 235, 125, 240, 100, 236, 18, 158, 65, 238, 163, 230, 22, 199, 31, 67, 109, 100, 216, 221, 117, 200, 184, 148, 67, 103, 155, 180, 123, 123, 234, 13, 91, 222, 201, 93 },
                            Role = 1
                        });
                });

            modelBuilder.Entity("ProfileProfile", b =>
                {
                    b.HasOne("awme.Data.Models.Profile", null)
                        .WithMany()
                        .HasForeignKey("FollowersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("awme.Data.Models.Profile", null)
                        .WithMany()
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("awme.Data.Models.Activity", b =>
                {
                    b.HasOne("awme.Data.Models.Collar", "Collar")
                        .WithMany()
                        .HasForeignKey("CollarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collar");
                });

            modelBuilder.Entity("awme.Data.Models.Animal", b =>
                {
                    b.HasOne("awme.Data.Models.Collar", "Collar")
                        .WithOne("Animal")
                        .HasForeignKey("awme.Data.Models.Animal", "CollarId");

                    b.HasOne("awme.Data.Models.AnimalType", "Type")
                        .WithMany("Animals")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("awme.Data.Models.User", "User")
                        .WithMany("Animals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collar");

                    b.Navigation("Type");

                    b.Navigation("User");
                });

            modelBuilder.Entity("awme.Data.Models.Chat", b =>
                {
                    b.HasOne("awme.Data.Models.Profile", "FirstProfile")
                        .WithOne()
                        .HasForeignKey("awme.Data.Models.Chat", "FirstProfileId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("awme.Data.Models.Profile", null)
                        .WithMany("Chats")
                        .HasForeignKey("ProfileId");

                    b.HasOne("awme.Data.Models.Profile", "SecondProfile")
                        .WithOne()
                        .HasForeignKey("awme.Data.Models.Chat", "SecondProfileId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FirstProfile");

                    b.Navigation("SecondProfile");
                });

            modelBuilder.Entity("awme.Data.Models.Collar", b =>
                {
                    b.HasOne("awme.Data.Models.User", null)
                        .WithMany("Collars")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("awme.Data.Models.Comment", b =>
                {
                    b.HasOne("awme.Data.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("awme.Data.Models.Profile", "Profile")
                        .WithOne()
                        .HasForeignKey("awme.Data.Models.Comment", "ProfileId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("awme.Data.Models.Like", b =>
                {
                    b.HasOne("awme.Data.Models.Post", "post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("awme.Data.Models.Profile", "Profile")
                        .WithOne()
                        .HasForeignKey("awme.Data.Models.Like", "ProfileId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Profile");

                    b.Navigation("post");
                });

            modelBuilder.Entity("awme.Data.Models.Message", b =>
                {
                    b.HasOne("awme.Data.Models.Chat", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatId");

                    b.HasOne("awme.Data.Models.Profile", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("awme.Data.Models.Post", b =>
                {
                    b.HasOne("awme.Data.Models.Profile", "Profile")
                        .WithMany("Posts")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("awme.Data.Models.Profile", b =>
                {
                    b.HasOne("awme.Data.Models.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("awme.Data.Models.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("awme.Data.Models.AnimalType", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("awme.Data.Models.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("awme.Data.Models.Collar", b =>
                {
                    b.Navigation("Animal")
                        .IsRequired();
                });

            modelBuilder.Entity("awme.Data.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("awme.Data.Models.Profile", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("awme.Data.Models.User", b =>
                {
                    b.Navigation("Animals");

                    b.Navigation("Collars");

                    b.Navigation("Profile")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
