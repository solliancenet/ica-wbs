namespace NorthwindMVC.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=OracleConnectionString")
        {
        }

        public virtual DbSet<CATEGORy> CATEGORIES { get; set; }
        public virtual DbSet<CUSTOMERDEMOGRAPHIC> CUSTOMERDEMOGRAPHICS { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERS { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEES { get; set; }
        public virtual DbSet<ORDER_DETAILS> ORDER_DETAILS { get; set; }
        public virtual DbSet<ORDER> ORDERS { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTS { get; set; }
        public virtual DbSet<REGION> REGIONs { get; set; }
        public virtual DbSet<SHIPPER> SHIPPERS { get; set; }
        public virtual DbSet<SUPPLIER> SUPPLIERS { get; set; }
        public virtual DbSet<TERRITORy> TERRITORIES { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATEGORy>()
                .Property(e => e.CATEGORYNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORy>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERDEMOGRAPHIC>()
                .Property(e => e.CUSTOMERTYPEID)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERDEMOGRAPHIC>()
                .Property(e => e.CUSTOMERDESC)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.CUSTOMERID)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.COMPANYNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.CONTACTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.CONTACTTITLE)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.REGION)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.POSTALCODE)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .HasMany(e => e.CUSTOMERDEMOGRAPHICS)
                .WithMany(e => e.CUSTOMERS)
                .Map(m => m.ToTable("CUSTOMERCUSTOMERDEMO", "NW").MapLeftKey("CUSTOMERID").MapRightKey("CUSTOMERTYPEID"));

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.LASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.FIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.TITLE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.TITLEOFCOURTESY)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.REGION)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.POSTALCODE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.HOMEPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.EXTENSION)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.PHOTOPATH)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.EMPLOYEES1)
                .WithOptional(e => e.EMPLOYEE1)
                .HasForeignKey(e => e.REPORTSTO);

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.TERRITORIES)
                .WithMany(e => e.EMPLOYEES)
                .Map(m => m.ToTable("EMPLOYEETERRITORIES", "NW").MapLeftKey("EMPLOYEEID").MapRightKey("TERRITORYID"));

            modelBuilder.Entity<ORDER_DETAILS>()
                .Property(e => e.UNITPRICE)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ORDER_DETAILS>()
                .Property(e => e.DISCOUNT)
                .HasPrecision(7, 0);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.CUSTOMERID)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.FREIGHT)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.SHIPNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.SHIPADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.SHIPCITY)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.SHIPREGION)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.SHIPPOSTALCODE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.SHIPCOUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.ORDER_DETAILS)
                .WithRequired(e => e.ORDER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.PRODUCTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.QUANTITYPERUNIT)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.UNITPRICE)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PRODUCT>()
                .HasMany(e => e.ORDER_DETAILS)
                .WithRequired(e => e.PRODUCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REGION>()
                .Property(e => e.REGIONID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<REGION>()
                .Property(e => e.REGIONDESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<REGION>()
                .HasMany(e => e.TERRITORIES)
                .WithRequired(e => e.REGION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SHIPPER>()
                .Property(e => e.COMPANYNAME)
                .IsUnicode(false);

            modelBuilder.Entity<SHIPPER>()
                .Property(e => e.PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<SHIPPER>()
                .HasMany(e => e.ORDERS)
                .WithOptional(e => e.SHIPPER)
                .HasForeignKey(e => e.SHIPVIA);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.COMPANYNAME)
                .IsUnicode(false);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.CONTACTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.CONTACTTITLE)
                .IsUnicode(false);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.REGION)
                .IsUnicode(false);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.POSTALCODE)
                .IsUnicode(false);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<SUPPLIER>()
                .Property(e => e.HOMEPAGE)
                .IsUnicode(false);

            modelBuilder.Entity<TERRITORy>()
                .Property(e => e.TERRITORYID)
                .IsUnicode(false);

            modelBuilder.Entity<TERRITORy>()
                .Property(e => e.TERRITORYDESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TERRITORy>()
                .Property(e => e.REGIONID)
                .HasPrecision(38, 0);
        }
    }
}
