using Microsoft.EntityFrameworkCore;

namespace AuthorityManagementCent.Model
{
    public class ModelContext : DbContext
    {

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {

        }

        public DbSet<PermissionExpansion> PermissionExpansions { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<OrganizationExpansions> OrganizationExpansions { get; set; }

        public DbSet<Organizations> Organizations { get; set; }

        public DbSet<Permissionitems> Permissionitems { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<RolePermissions> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PermissionExpansion>(b =>
            {
                b.ToTable("permissionexpansion");
            });

            builder.Entity<UserRole>(b =>
            {
                b.HasKey(k => new { k.RoleId, k.UserId });
                b.Property<bool>("IsDeleted").HasColumnType("bit");
                b.ToTable("userrole");
            });

            builder.Entity<RolePermissions>(b =>
            {
                //b.HasKey(k => new { k.OrganizationScope, k.PermissionsId, k.RoledId });
                b.ToTable("rolepermissions");
            });

            builder.Entity<Users>(b =>
            {
                b.Property<bool>("IsDeleted").HasColumnType("bit");
                b.Property<bool>("Sex").HasColumnType("bit");
                b.ToTable("identityuser");
            });

            builder.Entity<Roles>(b =>
            {
                b.Property<bool>("IsDeleted").HasColumnType("bit");
                b.ToTable("identityrole");
            });

            builder.Entity<OrganizationExpansions>(b =>
            {
                b.Property<bool>("IsImmediate").HasColumnType("bit");
                b.HasKey(k => new { k.OrganizationId, k.SonId });
                b.ToTable("organizationexpansions");
            });

            builder.Entity<Organizations>(b =>
            {
                b.Property<bool>("IsDeleted").HasColumnType("bit");
                b.ToTable("organizations");
            });

            builder.Entity<Permissionitems>(b =>
            {
                b.Property<bool>("IsDeleted").HasColumnType("bit");
                b.ToTable("permissionitems");
            });

        }


    }
}
