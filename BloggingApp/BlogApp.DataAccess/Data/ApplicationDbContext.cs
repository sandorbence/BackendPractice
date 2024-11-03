using BlogApp.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Article> Articles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            AddSeedData(builder);
        }

        private void AddSeedData(ModelBuilder builder)
        {
            string userId = Guid.NewGuid().ToString();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = userId,
                    Name = "Sample User",
                    UserName = "sampleuser",
                    NormalizedUserName = "SAMPLE@USER.COM",
                    Email = "sample@user.com",
                    NormalizedEmail = "SAMPLE@USER.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAIAAYagAAAAEAAgOJfc0/GtJqqlhn3go5EwvL0ECMzcruLrHj1tOkgDujT9QY53SZUnm7/bIlZRHw==",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "123456",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                });

            builder.Entity<Article>().HasData(
                new Article
                {
                    Id = 1,
                    Title = "The Benefits of Minimalism",
                    Text = "In a world full of constant consumption and material excess, minimalism is gaining popularity as a lifestyle that promotes simplicity. But what is minimalism, and why are so many people embracing it?\n\nAt its core, minimalism is about intentionally focusing on what matters most, cutting out the distractions of material possessions, and finding fulfillment in experiences and relationships rather than things. One of the main benefits of minimalism is the reduction of stress. When your living space is free from clutter, your mind can be clearer and less distracted. Many who adopt minimalism find that their mental health improves, as they no longer feel the pressure to keep up with societal expectations of wealth and status.\n\nAnother significant advantage is the financial freedom it can bring. By buying less, people are able to save more money or invest in experiences like travel, hobbies, or education that bring more long-term happiness. A minimalist lifestyle also aligns with sustainability. When we reduce our consumption, we reduce waste, which is beneficial for the environment.\n\nOverall, minimalism isn't about depriving yourself of things you love—it's about being more intentional and living with purpose. Whether you declutter your home or simplify your schedule, minimalism offers a path toward a more peaceful and fulfilling life.",
                    ApplicationUserId = userId
                },
                new Article
                {
                    Id = 2,
                    Title = "The Science of Coffee Brewing",
                    Text = "Coffee is more than just a morning ritual—it’s a science. Whether you’re brewing a simple drip coffee or experimenting with a French press, understanding the science behind coffee brewing can enhance your experience and help you brew the perfect cup.\n\nThe first variable to consider is water temperature. Ideally, water should be heated to 195°F to 205°F (90°C to 96°C). Anything cooler will under-extract the coffee, leaving it weak and sour, while water that's too hot can result in a bitter brew.\n\nNext is the grind size. The size of the coffee grounds determines how fast or slow water extracts the flavor. For methods like espresso, a fine grind is necessary, while a coarser grind is ideal for French press brewing. If you’re using a drip coffee maker, medium grind works best. Incorrect grind size often leads to unbalanced flavors, so it’s important to match it to your brewing method.\n\nBrewing time also matters. Coffee that brews too quickly may be under-extracted and taste weak, while over-extracted coffee can become overly bitter. For a French press, for example, a 4-minute steep time is usually ideal.\n\nLastly, water quality makes a difference. Using filtered water free of impurities can improve the flavor and quality of your coffee.\n\nBy mastering these elements—temperature, grind size, brew time, and water quality—you can elevate your coffee from average to exceptional.",
                    ApplicationUserId = userId
                },
                new Article
                {
                    Id = 3,
                    Title = "The Rise of Electric Vehicles",
                    Text = "Electric vehicles (EVs) are becoming an increasingly popular choice for environmentally-conscious drivers, but what’s behind this shift?\n\nThe rise of EVs is largely due to advancements in technology, growing awareness of climate change, and government incentives promoting cleaner energy. Unlike traditional gasoline-powered cars, EVs produce zero emissions while driving, making them a key player in reducing greenhouse gases. Major car manufacturers are responding to the demand by developing more EV models with improved range, better performance, and lower costs.\n\nA significant barrier to EV adoption has been \"range anxiety,\" the fear of running out of battery power before finding a charging station. However, the situation is improving rapidly. Charging infrastructure is expanding globally, with faster charging technology being introduced that can charge an EV battery to 80% in under 30 minutes. Newer EVs also come with extended ranges of 200 to 300 miles on a single charge, which helps alleviate concerns about long-distance driving.\n\nIn addition to environmental benefits, EVs are cheaper to run in the long term. Electricity is generally less expensive than gasoline, and EVs have fewer moving parts, reducing maintenance costs.\n\nAs the technology matures and becomes more affordable, EVs are likely to become the mainstream mode of transportation. They not only offer a cleaner alternative but also pave the way for smarter, more sustainable cities.",
                    ApplicationUserId = userId
                });
        }
    }
}
