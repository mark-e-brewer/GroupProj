﻿// <auto-generated />
using System;
using GroupProj;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GroupProj.Migrations
{
    [DbContext(typeof(RareUsersDbContext))]
    partial class RareUsersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GroupProj.Models.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Label")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Label = "Comedy"
                        });
                });

            modelBuilder.Entity("GroupProj.Models.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PostsId")
                        .HasColumnType("integer");

                    b.Property<int>("RareUsersId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PostsId");

                    b.HasIndex("RareUsersId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "this is content",
                            CreatedOn = new DateTime(2023, 9, 12, 19, 39, 53, 893, DateTimeKind.Local).AddTicks(3939),
                            PostsId = 1,
                            RareUsersId = 1
                        });
                });

            modelBuilder.Entity("GroupProj.Models.Posts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Approved")
                        .HasColumnType("boolean");

                    b.Property<int?>("CategoriesId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("ImageURL")
                        .HasColumnType("text");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("RareUsersId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoriesId");

                    b.HasIndex("RareUsersId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Approved = true,
                            CategoriesId = 1,
                            Content = "Blah Blah Blah",
                            ImageURL = "Post Image Url",
                            PublicationDate = new DateTime(2023, 9, 12, 19, 39, 53, 893, DateTimeKind.Local).AddTicks(4103),
                            RareUsersId = 1
                        });
                });

            modelBuilder.Entity("GroupProj.Models.RareUsers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool?>("IsStaff")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("ProfileImageURL")
                        .HasColumnType("text");

                    b.Property<int?>("SubscriptionsId")
                        .HasColumnType("integer");

                    b.Property<string>("UID")
                        .HasColumnType("text");

                    b.Property<int?>("UserTypeChangeRequestsId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionsId");

                    b.HasIndex("UserTypeChangeRequestsId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Bio = "This a bio",
                            CreatedOn = new DateTime(2023, 9, 12, 19, 39, 53, 893, DateTimeKind.Local).AddTicks(3647),
                            Email = "this@email.com",
                            FirstName = "Bob",
                            IsStaff = true,
                            LastName = "BobberSon",
                            ProfileImageURL = "This is a url",
                            UID = ""
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Bio = "This a bio",
                            CreatedOn = new DateTime(2023, 9, 12, 19, 39, 53, 893, DateTimeKind.Local).AddTicks(3701),
                            Email = "this@email.com",
                            FirstName = "Sandra",
                            IsStaff = true,
                            LastName = "BobberSon",
                            ProfileImageURL = "This is a url",
                            UID = ""
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            Bio = "This a bio",
                            CreatedOn = new DateTime(2023, 9, 12, 19, 39, 53, 893, DateTimeKind.Local).AddTicks(3708),
                            Email = "this@email.com",
                            FirstName = "Tim",
                            IsStaff = false,
                            LastName = "Timmerson",
                            ProfileImageURL = "This is a url",
                            UID = ""
                        });
                });

            modelBuilder.Entity("GroupProj.Models.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageURL")
                        .HasColumnType("text");

                    b.Property<string>("Label")
                        .HasColumnType("text");

                    b.Property<int>("RareUsersId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RareUsersId");

                    b.ToTable("Reactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageURL = "A url",
                            Label = "this a label",
                            RareUsersId = 1
                        });
                });

            modelBuilder.Entity("GroupProj.Models.Subscriptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("EndedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("FollowerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CreatedOn = new DateTime(2023, 9, 12, 19, 39, 53, 893, DateTimeKind.Local).AddTicks(4016),
                            EndedOn = new DateTime(2023, 9, 12, 19, 39, 53, 893, DateTimeKind.Local).AddTicks(4021),
                            FollowerId = 2
                        });
                });

            modelBuilder.Entity("GroupProj.Models.Tags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Label")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Label = "Tag Label"
                        });
                });

            modelBuilder.Entity("GroupProj.Models.UserTypeChangeRequests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .HasColumnType("text");

                    b.Property<int>("AdminOneId")
                        .HasColumnType("integer");

                    b.Property<int>("AdminTwoId")
                        .HasColumnType("integer");

                    b.Property<int>("ModifiedUserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UserTypeChangeRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Action = " Action",
                            AdminOneId = 1,
                            AdminTwoId = 2,
                            ModifiedUserId = 3
                        });
                });

            modelBuilder.Entity("PostsReaction", b =>
                {
                    b.Property<int>("PostsId")
                        .HasColumnType("integer");

                    b.Property<int>("ReactionsId")
                        .HasColumnType("integer");

                    b.HasKey("PostsId", "ReactionsId");

                    b.HasIndex("ReactionsId");

                    b.ToTable("PostsReaction");

                    b.HasData(
                        new
                        {
                            PostsId = 1,
                            ReactionsId = 1
                        });
                });

            modelBuilder.Entity("PostsTags", b =>
                {
                    b.Property<int>("PostsId")
                        .HasColumnType("integer");

                    b.Property<int>("TagsId")
                        .HasColumnType("integer");

                    b.HasKey("PostsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("PostsTags");
                });

            modelBuilder.Entity("GroupProj.Models.Comments", b =>
                {
                    b.HasOne("GroupProj.Models.Posts", "Posts")
                        .WithMany("Comments")
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupProj.Models.RareUsers", "RareUsers")
                        .WithMany()
                        .HasForeignKey("RareUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Posts");

                    b.Navigation("RareUsers");
                });

            modelBuilder.Entity("GroupProj.Models.Posts", b =>
                {
                    b.HasOne("GroupProj.Models.Categories", "Categories")
                        .WithMany()
                        .HasForeignKey("CategoriesId");

                    b.HasOne("GroupProj.Models.RareUsers", "RareUsers")
                        .WithMany()
                        .HasForeignKey("RareUsersId");

                    b.Navigation("Categories");

                    b.Navigation("RareUsers");
                });

            modelBuilder.Entity("GroupProj.Models.RareUsers", b =>
                {
                    b.HasOne("GroupProj.Models.Subscriptions", null)
                        .WithMany("RareUsers")
                        .HasForeignKey("SubscriptionsId");

                    b.HasOne("GroupProj.Models.UserTypeChangeRequests", null)
                        .WithMany("RareUsers")
                        .HasForeignKey("UserTypeChangeRequestsId");
                });

            modelBuilder.Entity("GroupProj.Models.Reaction", b =>
                {
                    b.HasOne("GroupProj.Models.RareUsers", "RareUsers")
                        .WithMany("Reactions")
                        .HasForeignKey("RareUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RareUsers");
                });

            modelBuilder.Entity("PostsReaction", b =>
                {
                    b.HasOne("GroupProj.Models.Posts", null)
                        .WithMany()
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupProj.Models.Reaction", null)
                        .WithMany()
                        .HasForeignKey("ReactionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PostsTags", b =>
                {
                    b.HasOne("GroupProj.Models.Posts", null)
                        .WithMany()
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupProj.Models.Tags", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupProj.Models.Posts", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("GroupProj.Models.RareUsers", b =>
                {
                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("GroupProj.Models.Subscriptions", b =>
                {
                    b.Navigation("RareUsers");
                });

            modelBuilder.Entity("GroupProj.Models.UserTypeChangeRequests", b =>
                {
                    b.Navigation("RareUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
