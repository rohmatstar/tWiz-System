using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class TwizDbContext : DbContext
{
    public TwizDbContext(DbContextOptions<TwizDbContext> options) : base(options) { }

    // Table
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyParticipant> CompanyParticipants { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeParticipant> EmployeeParticipants { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventDoc> EventDocs { get; set; }
    public DbSet<EventPayment> EventPayments { get; set; }
    public DbSet<RegisterPayment> RegisterPayments { get; set; }
    public DbSet<Role> Roles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Constraint Unique
        modelBuilder.Entity<Account>()
            .HasIndex(a => new
            {
                a.Email,
                a.Token
            }).IsUnique();

        modelBuilder.Entity<AccountRole>()
            .HasIndex(ar => new
            {
                ar.AccountGuid,
                ar.RoleGuid
            }).IsUnique();
        modelBuilder.Entity<Role>()
            .HasIndex(r => new
            {
                r.Name,

            }).IsUnique();


        modelBuilder.Entity<Employee>()
            .HasIndex(e => new
            {
                e.Nik,
                e.AccountGuid,
                e.PhoneNumber
            }).IsUnique();

        modelBuilder.Entity<Company>()
            .HasIndex(c => new
            {
                c.AccountGuid

            }).IsUnique();

        modelBuilder.Entity<Bank>()
            .HasIndex(b => new
            {
                b.Code,
                b.Name,

            }).IsUnique();

        modelBuilder.Entity<RegisterPayment>()
            .HasIndex(rp => new
            {
                rp.VaNumber,
                rp.CompanyGuid

            }).IsUnique();

        modelBuilder.Entity<EventPayment>()
            .HasIndex(ep => new
            {
                ep.VaNumber

            }).IsUnique();

        //Account - Account Roles (One to Many)
        modelBuilder.Entity<Account>()
            .HasMany(account => account.AccountRoles)
            .WithOne(accountroles => accountroles.Account)
            .HasForeignKey(accountroles => accountroles.AccountGuid);

        //Account Roles - Roles (One to Many)
        modelBuilder.Entity<AccountRole>()
            .HasOne(accountroles => accountroles.Role)
            .WithMany(roles => roles.AccountRoles)
            .HasForeignKey(accountrole => accountrole.RoleGuid);

        //Account - Employee (One to One)
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Employee)
            .WithOne(e => e.Account);

        //Account - Company (One to One)
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Company)
            .WithOne(c => c.Account);

        //Event - EmployeeParticipant (One to Many)
        modelBuilder.Entity<Event>()
            .HasMany(ev => ev.EmployeeParticipants)
            .WithOne(ep => ep.Event);
            
        //Event - CompanyParticipant (One to Many)
        modelBuilder.Entity<Event>()
            .HasMany(ev => ev.CompanyParticipants)
            .WithOne(cp => cp.Event);

        //Event - EventDoc (One to One)
        modelBuilder.Entity<Event>()
            .HasOne(ev => ev.EventDoc)
            .WithOne(ed => ed.Event);

        //Event - EventPayment (One to Many)
        modelBuilder.Entity<Event>()
            .HasMany(ev => ev.EventPayment)
            .WithOne(evp => evp.Event);

        //Bank - EventPayment (One to Many)
        modelBuilder.Entity<Bank>()
            .HasMany(b => b.EventPayments)
            .WithOne(ep => ep.Bank);

        //Bank - RegisterPayment (One to Many)
        modelBuilder.Entity<Bank>()
            .HasMany (b => b.RegisterPayments)
            .WithOne(rp => rp.Bank);

        //Comapny - RegisterPayment (One to One)
        modelBuilder.Entity<Company>()
            .HasOne(c => c.RegisterPayment)
            .WithOne(rp => rp.Company);
    }

}
