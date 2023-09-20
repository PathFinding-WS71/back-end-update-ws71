using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class UpdateDbContext :DbContext
{
    public UpdateDbContext()
    {
    }
    
    public UpdateDbContext(DbContextOptions<UpdateDbContext> options) : base(options)
    {
    }
    
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Community> Communities { get; set; }
    public DbSet<Participation> Participations { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CommunityMember> CommunityMembers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=sql10.freemysqlhosting.net,3306;Uid=sql10628925;Pwd=87H6PJfi91;Database=sql10628925;", serverVersion);
        }
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);

        builder.Entity<Activity>().ToTable("activities");
        builder.Entity<Activity>().HasKey(a => a.Id);
        builder.Entity<Activity>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Activity>().Property(a => a.ActivityTitle).IsRequired().HasMaxLength(60);
        builder.Entity<Activity>().Property(a => a.ActivityDescription).IsRequired().HasMaxLength(240);
        builder.Entity<Activity>().Property(a => a.ActivityDate).IsRequired();
        builder.Entity<Activity>().Property(a => a.ActivityType).IsRequired().HasMaxLength(30);
        builder.Entity<Activity>().Property(a => a.DateCreated).IsRequired().ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
        builder.Entity<Activity>().Property(a => a.IsActive).IsRequired();
        //Relationship One to Many with Location
        builder.Entity<Activity>()
            .HasOne<Location>(a => a.Location)
            .WithMany(l => l.Activities)
            .HasForeignKey(a => a.LocationId);
        
        builder.Entity<Community>().ToTable("communities");
        builder.Entity<Community>().HasKey(c => c.Id);
        builder.Entity<Community>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Community>().Property(c => c.CommunityName).IsRequired().HasMaxLength(30);
        builder.Entity<Community>().Property(c => c.CommunityDescription).IsRequired().HasMaxLength(500);
        builder.Entity<Community>().Property(c => c.CommunityVisibility).IsRequired().HasMaxLength(30);
        builder.Entity<Community>().Property(c => c.DateCreated).IsRequired().ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
        builder.Entity<Community>().Property(c => c.IsActive).IsRequired();

        builder.Entity<Participation>().ToTable("participations");
        builder.Entity<Participation>().HasKey(p => p.Id);
        builder.Entity<Participation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Participation>().Property(p => p.DateCreated).IsRequired().ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
        builder.Entity<Participation>().Property(p => p.IsActive).IsRequired();
        //Relationship One to Many with Activity
        /* builder.Entity<Participation>()
            .HasOne<Activity>(p => p.Activity)
            .WithMany(a => a.Participations)
            .HasForeignKey(p => p.ActivityId); */
        //Relationship One to Many with GroupMembers
        builder.Entity<Participation>()
            .HasOne<CommunityMember>(p => p.CommunityMember)
            .WithMany(c => c.Participations)
            .HasForeignKey(p => p.CommunityMemberId);

        builder.Entity<Location>().ToTable("locations");
        builder.Entity<Location>().HasKey(l => l.Id);
        builder.Entity<Location>().Property(l => l.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Location>().Property(l => l.LocationDescription).IsRequired().HasMaxLength(60);
        builder.Entity<Location>().Property(l => l.DateCreated).IsRequired().ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
        builder.Entity<Location>().Property(l => l.IsActive).IsRequired();

        builder.Entity<Role>().ToTable("roles");
        builder.Entity<Role>().HasKey(r => r.Id);
        builder.Entity<Role>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Role>().Property(r => r.Name).IsRequired().HasMaxLength(15);
        builder.Entity<Role>().Property(r => r.DateCreated).IsRequired().ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
        builder.Entity<Role>().Property(r => r.IsActive).IsRequired();

        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(c => c.Username).IsRequired().HasMaxLength(60);
        builder.Entity<User>().Property(c => c.Password).IsRequired().HasMaxLength(120);
        builder.Entity<User>().Property(c => c.IsActive).IsRequired().HasDefaultValue(true);

        builder.Entity<CommunityMember>().ToTable("community_members");
        builder.Entity<CommunityMember>().HasKey(c => c.Id);
        builder.Entity<CommunityMember>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<CommunityMember>().Property(c => c.DateCreated).IsRequired().ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
        builder.Entity<CommunityMember>().Property(c => c.IsActive).IsRequired().HasDefaultValue(true);
        builder.Entity<CommunityMember>().Property(c => c.MembershipDate).IsRequired().HasDefaultValue(DateOnly.FromDateTime(DateTime.Now)).ValueGeneratedOnAdd();
        //Relationship One to Many with Roles
        builder.Entity<CommunityMember>()
            .HasOne<Role>(c => c.Role)
            .WithMany(r => r.CommunityMembers)
            .HasForeignKey(c => c.RoleId);
        //Relationship One to Many with Communities
        builder.Entity<CommunityMember>()
            .HasOne<Community>(c => c.Community)
            .WithMany(c => c.CommunityMembers)
            .HasForeignKey(c => c.CommunityId);
    }
}