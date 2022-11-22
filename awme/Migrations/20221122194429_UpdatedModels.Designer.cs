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
    [Migration("20221122194429_UpdatedModels")]
    partial class UpdatedModels
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
                    b.Property<string>("FollowersUsername")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FollowingUsername")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FollowersUsername", "FollowingUsername");

                    b.HasIndex("FollowingUsername");

                    b.ToTable("ProfileProfile");
                });

            modelBuilder.Entity("awme.Data.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int>("AnimalTypeId")
                        .HasColumnType("int");

                    b.Property<string>("AvatarImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalTypeId");

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

                    b.Property<string>("FirstProfileUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProfileUsername")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SecondProfileUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FirstProfileUsername")
                        .IsUnique();

                    b.HasIndex("ProfileUsername");

                    b.HasIndex("SecondProfileUsername")
                        .IsUnique();

                    b.ToTable("Chats");
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

                    b.Property<string>("ProfileUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("ProfileUsername")
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

                    b.Property<string>("ProfileUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("ProfileUsername")
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

                    b.Property<int>("SenderUsername")
                        .HasColumnType("int");

                    b.Property<string>("SenderUsername1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("SenderUsername1");

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

                    b.Property<string>("UserProfileUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileUsername");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("awme.Data.Models.Profile", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Username");

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

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@admin.com",
                            FirstName = "Admin",
                            LastName = "Admin",
                            PasswordHash = new byte[] { 187, 173, 92, 65, 181, 112, 247, 207, 224, 196, 77, 59, 151, 217, 144, 248, 174, 100, 8, 84, 1, 21, 194, 108, 240, 51, 136, 77, 1, 104, 91, 11, 165, 43, 235, 101, 59, 233, 200, 50, 167, 58, 126, 18, 200, 179, 100, 194, 17, 203, 240, 137, 240, 190, 30, 191, 146, 110, 106, 5, 197, 103, 250, 14 },
                            PasswordSalt = new byte[] { 198, 4, 34, 206, 36, 54, 6, 155, 247, 90, 95, 254, 1, 161, 197, 86, 51, 26, 37, 228, 58, 158, 200, 90, 136, 240, 232, 42, 105, 9, 160, 48, 35, 163, 214, 132, 134, 214, 97, 223, 47, 237, 232, 223, 46, 211, 19, 225, 39, 200, 104, 83, 57, 239, 12, 206, 108, 140, 253, 74, 175, 20, 75, 177, 228, 68, 220, 17, 161, 215, 220, 185, 143, 219, 7, 90, 72, 151, 192, 234, 19, 98, 164, 12, 48, 201, 39, 195, 84, 155, 233, 234, 254, 87, 154, 182, 186, 199, 179, 200, 25, 214, 194, 172, 206, 127, 198, 158, 217, 59, 185, 186, 246, 24, 224, 231, 205, 60, 253, 125, 118, 99, 8, 14, 95, 82, 67, 138 },
                            Role = "Admin"
                        });
                });

            modelBuilder.Entity("ProfileProfile", b =>
                {
                    b.HasOne("awme.Data.Models.Profile", null)
                        .WithMany()
                        .HasForeignKey("FollowersUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("awme.Data.Models.Profile", null)
                        .WithMany()
                        .HasForeignKey("FollowingUsername")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("awme.Data.Models.Animal", b =>
                {
                    b.HasOne("awme.Data.Models.AnimalType", "Type")
                        .WithMany("Animals")
                        .HasForeignKey("AnimalTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("awme.Data.Models.User", "User")
                        .WithMany("Animals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");

                    b.Navigation("User");
                });

            modelBuilder.Entity("awme.Data.Models.Chat", b =>
                {
                    b.HasOne("awme.Data.Models.Profile", "FirstProfile")
                        .WithOne()
                        .HasForeignKey("awme.Data.Models.Chat", "FirstProfileUsername")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("awme.Data.Models.Profile", null)
                        .WithMany("Chats")
                        .HasForeignKey("ProfileUsername");

                    b.HasOne("awme.Data.Models.Profile", "SecondProfile")
                        .WithOne()
                        .HasForeignKey("awme.Data.Models.Chat", "SecondProfileUsername")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FirstProfile");

                    b.Navigation("SecondProfile");
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
                        .HasForeignKey("awme.Data.Models.Comment", "ProfileUsername")
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
                        .HasForeignKey("awme.Data.Models.Like", "ProfileUsername")
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
                        .HasForeignKey("SenderUsername1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("awme.Data.Models.Post", b =>
                {
                    b.HasOne("awme.Data.Models.Profile", "UserProfile")
                        .WithMany("Posts")
                        .HasForeignKey("UserProfileUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
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

                    b.Navigation("Profile")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
