using EliteDomus.Domain.Context;
using EliteDomus.Domain.Context.Accounting;
using EliteDomus.Domain.Context.Channex;
using EliteDomus.Domain.Context.Ross;
using EliteDomus.Domain.Models.Ross;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EliteDomus.Domain.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<MyUser> MyUsers { get; set; }
    public DbSet<Company> Company { get; set; }
    public DbSet<StripeProduct> StripeProducts { get; set; }
    public DbSet<UserSecurity> UserSecurities { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<BedAndBreakfast> BedAndBreakfasts { get; set; }
    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<ApartmentRoom> ApartmentRooms { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomTypeMinStayDaily> RoomTypeMinStayDailies { get; set; }
    public DbSet<RoomTypeStopSellDaily> RoomTypeStopSellDailies { get; set; }
    public DbSet<HotelRoom> HotelRooms { get; set; }
    public DbSet<BedAndBreakfastRoom> BedAndBreakfastRooms { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<RoomTypeImage> RoomTypeImages { get; set; }
    public DbSet<PropertyInformation> PropertyInformations{ get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ReservationProforma> ReservationProformas { get; set; }
    public DbSet<Proforma> Proformas { get; set; }
    public DbSet<ReservationInvoice> ReservationInvoices { get; set; }
    public DbSet<ReservationForm> ReservationForms { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<ExperienceReservation> ExperienceReservations { get; set; }
    public DbSet<ExperienceProperty> ExperienceProperties { get; set; }
    public DbSet<FoodAndBeverage> FoodAndBeverages { get; set; }
    public DbSet<FoodAndBeverageReservation> FoodAndBeverageReservations { get; set; }
    public DbSet<FoodAndBeverageProperty> FoodAndBeverageProperties { get; set; }
    public DbSet<DataPortal> DataPortals { get; set; }
    public DbSet<DataPortalISTAT> DataPortalsISTAT { get; set; }
    public DbSet<DataPortalPAW> DataPortalsPAW { get; set; }
    public DbSet<TouristTax> TouristTaxes { get; set; }
    public DbSet<PortaleFlussiTuristici> PortaliFlussiTuristici { get; set; }
    public DbSet<MovementBase> MovementBases { get; set; }
    public DbSet<MovementReservation> MovementReservations { get; set; }
    public DbSet<MovementArrival> MovementArrivals { get; set; }
    public DbSet<MovementDeparture> MovementDepartures { get; set; }
    public DbSet<CheckIn> CheckIns { get; set; }
    public DbSet<CheckInDoc> CheckInDocs { get; set; }
    public DbSet<CheckInGuest> CheckInGuests { get; set; }
    public DbSet<Municipality> Municipalities { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<GuestType> GuestTypes { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<ChannexPropertySetting> ChannexPropertySettings { get; set; }
    public DbSet<PropertyImage> PropertyImages { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<PriceListSetting> PriceListSettings { get; set; }
    public DbSet<PriceList> PriceLists { get; set; }
    public DbSet<PriceListDaily> PriceListDailies { get; set; }
    
    public DbSet<Old_PriceList> Old_PriceLists { get; set; }
    public DbSet<Old_PriceListDaily> Old_PriceListDailies { get; set; }
     
    public DbSet<CleanCompanyUser> CleanCompanyUsers { get; set; }
    public DbSet<CleanCompany> CleanCompanies { get; set; }
    public DbSet<CleanRoomHistory> CleanRoomHistories { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<QuoteForm> QuoteForms { get; set; }
    public DbSet<QuoteRoomType> QuoteRoomTypes { get; set; }
    public DbSet<ReservationPriceDetail> ReservationPriceDetail { get; set; }
    public DbSet<QuotePriceDetail> QuotePriceDetail { get; set; }
    public DbSet<ExperienceReservationPayment> ExperienceReservationPayments { get; set; }
    public DbSet<FoodAndBeverageReservationPayment> FoodAndBeverageReservationPayments { get; set; }
    public DbSet<ReservationPayment> ReservationPayments { get; set; }
    public DbSet<TouristTaxPayment> TouristTaxPayments { get; set; }
    public DbSet<TmpMedia> TmpMedias { get; set; }
    public DbSet<ChannexPropertyFacility> ChannexPropertyFacilities { get; set; }
    public DbSet<ChannexRoomTypeFacility> ChannexRoomTypeFacilities { get; set; }
    public DbSet<ChannexProperty> ChannexProperties { get; set; }
    public DbSet<ChannexRoomType> ChannexRoomTypes { get; set; }
    public DbSet<ChannexRoomTypeAvailability> ChannexRoomTypeAvailability { get; set; }
    public DbSet<ChannexRoomTypeRatePlan> ChannexRoomTypeRatePlans { get; set; }
    public DbSet<RatePlan> RatePlans { get; set; }
    public DbSet<RatePlanDaily> RatePlanDailies { get; set; }
    public DbSet<PropertyFacility> PropertyFacilities { get; set; }
    public DbSet<RoomTypeFacility> RoomTypeFacilities { get; set; }
    public DbSet<CouponCode> CouponCodes { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<CouponQuoteRoomType> CouponQuotes { get; set; }
    public DbSet<CouponReservation> CouponReservations { get; set; }
    public DbSet<RoomUnavailability> RoomUnavailabilities { get; set; }
    public DbSet<RoomTypeMaxStayDaily> RoomTypeMaxStayDailies { get; set; }
    public DbSet<RoomTypeClosedToArrivalDaily> RoomTypeClosedToArrivalDailies { get; set; }
    public DbSet<RoomTypeClosedToDepartureDaily> RoomTypeClosedToDepartureDailies { get; set; }
    public DbSet<VAT_Rate> VAT_Rates { get; set; }
    public DbSet<UnitMeasure> UnitMeasures { get; set; }
    public DbSet<PAWReceipt> PAWReceipts { get; set; }
    public DbSet<RossReceipt> RossReceipts { get; set; }
    public DbSet<ExperienceReservationProforma> ExperienceReservationProformas { get; set; }
    public DbSet<PassiveInvoice> PassiveInvoices { get; set; }
    public DbSet<PassiveInvoiceDeadline> PassiveInvoiceDeadlines { get; set; }
    public DbSet<CostItem> CostItems { get; set; }
    public DbSet<CostType> CostTypes { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<CustomerBusinessInfo> CustomerBusinessInfos { get; set; }
    public DbSet<ActiveInvoice> ActiveInvoices { get; set; }
    public DbSet<ActiveInvoiceDeadline> ActiveInvoiceDeadlines { get; set; }
    public DbSet<ActiveInvoiceItem> ActiveInvoiceItems { get; set; }
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<ReceiptReservation> ReceiptReservations { get; set; }
    
    
    #region OnModelCreating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReceiptReservation>().HasKey(a => new { a.ReceiptId, a.ReservationId });
        modelBuilder.Entity<ExperienceReservationProforma>().HasKey(a => new { a.ExperienceReservationId, a.ProformaId });
        modelBuilder.Entity<ReservationProforma>().HasKey(a => new { a.ReservationId, a.ProformaId });
        modelBuilder.Entity<ActiveInvoiceReservation>().HasKey(a => new { a.ReservationId, a.ActiveInvoiceId });
        modelBuilder.Entity<RoomTypeFacility>().HasKey(a => new { a.RoomTypeId, a.ChannexRoomTypeFacilityId });
        modelBuilder.Entity<PropertyFacility>().HasKey(a => new { a.PropertyId, a.ChannexPropertyFacilityId });
        modelBuilder.Entity<CouponQuoteRoomType>().HasKey(a => new { a.CouponCodeId, a.QuoteRoomTypeId });
        modelBuilder.Entity<CouponReservation>().HasKey(a => new { a.CouponCodeId, a.ReservationId });
        modelBuilder.Entity<CouponRoomType>().HasKey(a => new { a.CouponId, a.RoomTypeId });
        modelBuilder.Entity<CleanCompanyUser>().HasKey(a => new { a.CleanCompanyId, a.MyUserId });
        modelBuilder.Entity<ExperienceProperty>().HasKey(a => new { a.ExperienceId, a.PropertyId });
        modelBuilder.Entity<FoodAndBeverageProperty>().HasKey(a => new { a.FoodAndBeverageId, a.PropertyId });
        modelBuilder.Entity<RoomType>().HasMany(ho=>ho.Reservations).WithOne(wo=>wo.RoomType).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<ChannexRoomTypeRatePlan>().HasOne(ho=>ho.RatePlan).WithOne(wo=>wo.ChannexRoomTypeRatePlans).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<RatePlan>().HasOne(ho=>ho.ChannexRoomTypeRatePlans).WithOne(wo=>wo.RatePlan).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<MovementReservation>().HasIndex(hi => hi.Idswh).IsUnique();
        modelBuilder.Entity<MovementReservation>().HasIndex(hi => new { hi.PropertyId, hi.ReservationId }).IsUnique();
        modelBuilder.Entity<MovementArrival>().HasIndex(hi => hi.Idswh).IsUnique();
        modelBuilder.Entity<MovementArrival>().HasIndex(hi => new { hi.PropertyId, hi.ReservationId, hi.CheckInGuestId }).IsUnique();
        modelBuilder.Entity<MovementDeparture>().HasIndex(hi => hi.Idswh).IsUnique();
        modelBuilder.Entity<MovementDeparture>().HasIndex(hi => new { hi.PropertyId, hi.ReservationId, hi.CheckInGuestId }).IsUnique();
        modelBuilder.Entity<CheckIn>().HasIndex(hi=>hi.CheckInCode).IsUnique();
        modelBuilder.Entity<PriceListSetting>().HasIndex(uk => new { uk.RoomTypeId, uk.PriceListVariationType }).IsUnique();
        // modelBuilder.Entity<Reservation>().HasIndex(uk => new {uk.ChannexBookingId, uk.ChannexRatePlanId, uk.ChannexRoomTypeId}).IsUnique();
        
        base.OnModelCreating(modelBuilder);
    }
    #endregion
    
    #region OnSaveChanges
    public async Task<int> SaveChangesAsync(string userId)
    {
        this.ChangeTracker.DetectChanges();
        var added = this.ChangeTracker.Entries()
            .Where(t => t.State == EntityState.Added)
            .Select(t => t.Entity)
            .ToArray();
        var now = DateTime.Now;
        foreach (var entity in added)
        {
            if (entity is ITrack)
            {
                var track = entity as ITrack;
                track.CreatedDate = now;
                track.LastModifiedDate = now;
                track.CreatedBy = userId;
                track.LastModifiedBy = userId;
            }
        }

        var modified = this.ChangeTracker.Entries()
            .Where(t => t.State == EntityState.Modified)
            .Select(t => t.Entity)
            .ToArray();

        foreach (var entity in modified)
        {
            if (entity is ITrack)
            {
                var track = entity as ITrack;
                track.LastModifiedDate = now;
                track.LastModifiedBy = userId;
            }
        }
        return await base.SaveChangesAsync();
    }
    #endregion
}