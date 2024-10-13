﻿// <auto-generated />
using System;
using BlogApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlogApp.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241013180534_SeedDatabase")]
    partial class SeedDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BlogApp.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationUserId = "169bbddf-2a4e-4977-a744-efd20ce1acf0",
                            Text = "In a world full of constant consumption and material excess, minimalism is gaining popularity as a lifestyle that promotes simplicity. But what is minimalism, and why are so many people embracing it?\n\nAt its core, minimalism is about intentionally focusing on what matters most, cutting out the distractions of material possessions, and finding fulfillment in experiences and relationships rather than things. One of the main benefits of minimalism is the reduction of stress. When your living space is free from clutter, your mind can be clearer and less distracted. Many who adopt minimalism find that their mental health improves, as they no longer feel the pressure to keep up with societal expectations of wealth and status.\n\nAnother significant advantage is the financial freedom it can bring. By buying less, people are able to save more money or invest in experiences like travel, hobbies, or education that bring more long-term happiness. A minimalist lifestyle also aligns with sustainability. When we reduce our consumption, we reduce waste, which is beneficial for the environment.\n\nOverall, minimalism isn't about depriving yourself of things you love—it's about being more intentional and living with purpose. Whether you declutter your home or simplify your schedule, minimalism offers a path toward a more peaceful and fulfilling life.",
                            Title = "The Benefits of Minimalism"
                        },
                        new
                        {
                            Id = 2,
                            ApplicationUserId = "169bbddf-2a4e-4977-a744-efd20ce1acf0",
                            Text = "Coffee is more than just a morning ritual—it’s a science. Whether you’re brewing a simple drip coffee or experimenting with a French press, understanding the science behind coffee brewing can enhance your experience and help you brew the perfect cup.\n\nThe first variable to consider is water temperature. Ideally, water should be heated to 195°F to 205°F (90°C to 96°C). Anything cooler will under-extract the coffee, leaving it weak and sour, while water that's too hot can result in a bitter brew.\n\nNext is the grind size. The size of the coffee grounds determines how fast or slow water extracts the flavor. For methods like espresso, a fine grind is necessary, while a coarser grind is ideal for French press brewing. If you’re using a drip coffee maker, medium grind works best. Incorrect grind size often leads to unbalanced flavors, so it’s important to match it to your brewing method.\n\nBrewing time also matters. Coffee that brews too quickly may be under-extracted and taste weak, while over-extracted coffee can become overly bitter. For a French press, for example, a 4-minute steep time is usually ideal.\n\nLastly, water quality makes a difference. Using filtered water free of impurities can improve the flavor and quality of your coffee.\n\nBy mastering these elements—temperature, grind size, brew time, and water quality—you can elevate your coffee from average to exceptional.",
                            Title = "The Science of Coffee Brewing"
                        },
                        new
                        {
                            Id = 3,
                            ApplicationUserId = "169bbddf-2a4e-4977-a744-efd20ce1acf0",
                            Text = "Electric vehicles (EVs) are becoming an increasingly popular choice for environmentally-conscious drivers, but what’s behind this shift?\n\nThe rise of EVs is largely due to advancements in technology, growing awareness of climate change, and government incentives promoting cleaner energy. Unlike traditional gasoline-powered cars, EVs produce zero emissions while driving, making them a key player in reducing greenhouse gases. Major car manufacturers are responding to the demand by developing more EV models with improved range, better performance, and lower costs.\n\nA significant barrier to EV adoption has been \"range anxiety,\" the fear of running out of battery power before finding a charging station. However, the situation is improving rapidly. Charging infrastructure is expanding globally, with faster charging technology being introduced that can charge an EV battery to 80% in under 30 minutes. Newer EVs also come with extended ranges of 200 to 300 miles on a single charge, which helps alleviate concerns about long-distance driving.\n\nIn addition to environmental benefits, EVs are cheaper to run in the long term. Electricity is generally less expensive than gasoline, and EVs have fewer moving parts, reducing maintenance costs.\n\nAs the technology matures and becomes more affordable, EVs are likely to become the mainstream mode of transportation. They not only offer a cleaner alternative but also pave the way for smarter, more sustainable cities.",
                            Title = "The Rise of Electric Vehicles"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator().HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BlogApp.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "169bbddf-2a4e-4977-a744-efd20ce1acf0",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "874ac93d-e66e-4c0d-b180-f69cfad2895a",
                            Email = "sample@user.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "SAMPLE@USER.COM",
                            NormalizedUserName = "SAMPLE@USER.COM",
                            PasswordHash = "hashedpassword",
                            PhoneNumber = "123456",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1a90667c-4912-4de3-b29c-44c711c65652",
                            TwoFactorEnabled = false,
                            UserName = "sampleuser",
                            Name = "Sample User"
                        });
                });

            modelBuilder.Entity("BlogApp.Models.Article", b =>
                {
                    b.HasOne("BlogApp.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
