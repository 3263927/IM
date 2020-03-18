using IntuitMarketing.Domain.HelpModels;
using Microsoft.EntityFrameworkCore;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class intuitContext : DbContext
    {
        public intuitContext()
        {
        }

        public intuitContext(DbContextOptions<intuitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountLeads> AccountLeads { get; set; }
        public virtual DbSet<Campaigns> Campaings { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<ConvertedLeads> ConvertedLeads { get; set; }
        public virtual DbSet<Counties> Counties { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Dmas> Dmas { get; set; }
        public virtual DbSet<InvalidSubmissions> InvalidSubmissions { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<LeadStatusHistory> LeadStatusHistory { get; set; }
        public virtual DbSet<Leads> Leads { get; set; }
        public virtual DbSet<LocationWorkingHours> LocationWorkingHours { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Pages> Pages { get; set; }
        public virtual DbSet<ReportColumns> ReportColumns { get; set; }
        public virtual DbSet<ReportFilters> ReportFilters { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<SendingRules> SendingRules { get; set; }
        public virtual DbSet<Sites> Sites { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<ZipCodes> ZipCodes { get; set; }
        public virtual DbSet<ZipLocationMapping> ZipLocationMapping { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(StaticServerSettings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AccountLeads>(entity =>
            {
                entity.ToTable("account_leads");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.AccountLeads)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("account_leads_fk");
            });

            modelBuilder.Entity<Campaigns>(entity =>
            {
                entity.ToTable("campaigns");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("character varying");

                entity.Property(e => e.ClientType).HasColumnName("type");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Campaings)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("campaings_fk");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountyId).HasColumnName("county_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.County)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.CountyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("city_fk");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.ToTable("comments");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.LeadId).HasColumnName("lead_id");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasColumnType("character varying");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.LeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_fk_1");
            });

            modelBuilder.Entity<ConvertedLeads>(entity =>
            {
                entity.ToTable("converted_leads");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Properties)
                    .HasColumnName("properties")
                    .HasColumnType("json");
            });

            modelBuilder.Entity<Counties>(entity =>
            {
                entity.ToTable("counties");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Counties)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("counties_fk");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.ToTable("countries");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Dmas>(entity =>
            {
                entity.ToTable("dmas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<InvalidSubmissions>(entity =>
            {
                entity.ToTable("invalid_submissions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Field)
                    .IsRequired()
                    .HasColumnName("field")
                    .HasColumnType("character varying");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasColumnType("character varying");

                entity.Property(e => e.PageId).HasColumnName("page_id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.InvalidSubmissions)
                    .HasForeignKey(d => d.PageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("invalid_submissions_fk");
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.ToTable("invoices");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CampaingId).HasColumnName("campaing_id");

                entity.Property(e => e.Date).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Campaing)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CampaingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("invoices_fk");
            });

            modelBuilder.Entity<LeadStatusHistory>(entity =>
            {
                entity.ToTable("lead_status_history");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.ServiceName)
                    .HasColumnName("service_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.LeadId).HasColumnName("lead_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.LeadStatusHistory)
                    .HasForeignKey(d => d.LeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("lead_status_histpry_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LeadStatusHistory)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("lead_status_histpry_fk_1");
            });

            modelBuilder.Entity<Leads>(entity =>
            {
                entity.ToTable("leads");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("json");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("character varying");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasColumnType("character varying");

                entity.Property(e => e.Macros)
                    .IsRequired()
                    .HasColumnName("macros")
                    .HasColumnType("json");

                entity.Property(e => e.ProjectLeadId)
                    .HasColumnName("project_lead_id");

                entity.Property(e => e.PageId).HasColumnName("page_id");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phone_number")
                    .HasColumnType("character varying");
                
                entity.Property(e => e.RestName)
                    .HasColumnName("rest_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.SourceId)
                    .IsRequired()
                    .HasColumnName("source_id")
                    .HasColumnType("character varying");
                
                entity.Property(e => e.Sub1)
                    .HasColumnName("sub1")
                    .HasColumnType("character varying");

                entity.Property(e => e.Sub2)
                    .HasColumnName("sub2")
                    .HasColumnType("character varying");

                entity.Property(e => e.Sub3)
                    .HasColumnName("sub3")
                    .HasColumnType("character varying");

                entity.Property(e => e.TransactionId)
                    .IsRequired()
                    .HasColumnName("transaction_id")
                    .HasColumnType("character varying");

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasColumnName("zip")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.Leads)
                    .HasForeignKey(d => d.PageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("leads_fk");
            });

            modelBuilder.Entity<LocationWorkingHours>(entity =>
            {
                entity.ToTable("location_working_hours");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AppHours)
                    .HasColumnName("app_hours")
                    .HasColumnType("character varying");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.WorkingHours)
                    .IsRequired()
                    .HasColumnName("working_hours")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationWorkingHours)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("location_working_hours_fk");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.ToTable("locations");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Emails)
                    .IsRequired()
                    .HasColumnName("emails")
                    .HasColumnType("character varying");

                entity.Property(e => e.Phones)
                    .IsRequired()
                    .HasColumnName("phones")
                    .HasColumnType("character varying");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("character varying");

                entity.Property(e => e.CampaignId)
                    .IsRequired()
                    .HasColumnName("campaignid");

                entity.HasOne(d => d.Campaing)
                    .WithMany(e => e.Locations)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("locations_fk");
            });

            modelBuilder.Entity<Pages>(entity =>
            {
                entity.ToTable("pages");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveDates)
                    .HasColumnName("active_dates")
                    .HasColumnType("json");

                entity.Property(e => e.CampaingId).HasColumnName("campaing_id");

                entity.Property(e => e.Clicks).HasColumnName("clicks");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Campaing)
                    .WithMany(p => p.Pages)
                    .HasForeignKey(d => d.CampaingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pages_fk");
            });

            modelBuilder.Entity<ReportColumns>(entity =>
            {
                entity.ToTable("report_columns");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Index).HasColumnName("index");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasColumnType("character varying");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportColumns)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("report_columns_fk");
            });

            modelBuilder.Entity<ReportFilters>(entity =>
            {
                entity.ToTable("report_filters");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasColumnType("character varying");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Values)
                    .HasColumnName("values")
                    .HasColumnType("json");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportFilters)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("report_filters_fk");
            });

            modelBuilder.Entity<Reports>(entity =>
            {
                entity.ToTable("reports");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Query)
                    .IsRequired()
                    .HasColumnName("query")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<SendingRules>(entity =>
            {
                entity.ToTable("sending_rules");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasColumnType("character varying");

                entity.Property(e => e.CampaingId).HasColumnName("campaing_id");

                entity.Property(e => e.Descriptor)
                    .HasColumnName("descriptor")
                    .HasColumnType("json");

                entity.Property(e => e.Parameters)
                    .HasColumnName("parameters")
                    .HasColumnType("json");

                entity.Property(e => e.Selector)
                    .HasColumnName("selector")
                    .HasColumnType("character varying");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.Campaing)
                    .WithMany(p => p.SendingRules)
                    .HasForeignKey(d => d.CampaingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sending_rules_fk");
            });

            modelBuilder.Entity<Sites>(entity =>
            {
                entity.ToTable("sites");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CampaingId).HasColumnName("campaing_id");

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasColumnName("domain")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Campaing)
                    .WithMany(p => p.Sites)
                    .HasForeignKey(d => d.CampaingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sites_fk");
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.ToTable("states");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("states_fk");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("character varying");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasColumnType("character varying");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("character varying");

                entity.Property(e => e.Permisions)
                    .HasColumnName("permisions")
                    .HasColumnType("json");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<ZipCodes>(entity =>
            {
                entity.ToTable("zip_codes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.DmaId).HasColumnName("dma_id");

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasColumnName("zip")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.ZipCodes)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zip_codes_fk_1");

                entity.HasOne(d => d.Dma)
                    .WithMany(p => p.ZipCodes)
                    .HasForeignKey(d => d.DmaId)
                    .HasConstraintName("zip_codes_fk");
            });

            modelBuilder.Entity<ZipLocationMapping>(entity =>
            {
                entity.ToTable("zip_location_mapping");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.ZipId).HasColumnName("zip_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.ZipLocationMapping)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zip_location_mapping_fk");

                entity.HasOne(d => d.Zip)
                    .WithMany(p => p.ZipLocationMapping)
                    .HasForeignKey(d => d.ZipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zip_location_mapping_fk_1");
            });
        }
    }
}
