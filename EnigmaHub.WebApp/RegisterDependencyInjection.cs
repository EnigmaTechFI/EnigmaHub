using EliteDomus.Channex.Implementation;
using EliteDomus.Channex.Interface;
using EliteDomus.Domain.Context;
using EliteDomus.Domain.Context.Accounting;
using EliteDomus.Domain.Context.Channex;
using EliteDomus.Domain.Context.Ross;
using EliteDomus.Domain.Data;
using EliteDomus.Email;
using EliteDomus.Extranet;
using EliteDomus.FatturazioneElettronica;
using EliteDomus.FileManager;
using EliteDomus.GeneralUtils.Utils;
using EliteDomus.OpenAPI;
using EliteDomus.Presentation.Helper;
using EliteDomus.Service.Implementation;
using EliteDomus.Service.Interface;
using EliteDomus.Service.Repositories;
using EliteDomus.Service.Repositories.Impl;
using EliteDomus.Stripe;
using EliteDomus.Stripe.Helper;
using EliteDomus.Validators;

namespace EliteDomus.WebApp;

public static class RegisterDependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
    {
        #region Repository Dependency Injection
        serviceCollection.AddScoped<IEliteDomusUoW<ActiveInvoice>, EliteDomusUoW<ActiveInvoice>>();
        serviceCollection.AddScoped<IEliteDomusUoW<Receipt>, EliteDomusUoW<Receipt>>();
        serviceCollection.AddScoped<IEliteDomusUoW<CustomerBusinessInfo>, EliteDomusUoW<CustomerBusinessInfo>>();
        serviceCollection.AddScoped<IEliteDomusUoW<PassiveInvoiceDeadline>, EliteDomusUoW<PassiveInvoiceDeadline>>();
        serviceCollection.AddScoped<IEliteDomusUoW<CostItem>, EliteDomusUoW<CostItem>>();
        serviceCollection.AddScoped<IEliteDomusUoW<Supplier>, EliteDomusUoW<Supplier>>();
        serviceCollection.AddScoped<IEliteDomusUoW<PassiveInvoice>, EliteDomusUoW<PassiveInvoice>>();
        serviceCollection.AddScoped<IEliteDomusUoW<CostType>, EliteDomusUoW<CostType>>();
        serviceCollection.AddScoped<IEliteDomusUoW<RossReceipt>, EliteDomusUoW<RossReceipt>>();
        serviceCollection.AddScoped<IEliteDomusUoW<FoodAndBeverageReservationPayment>, EliteDomusUoW<FoodAndBeverageReservationPayment>>();
        serviceCollection.AddScoped<IEliteDomusUoW<FoodAndBeverageReservation>, EliteDomusUoW<FoodAndBeverageReservation>>();
        serviceCollection.AddScoped<IEliteDomusUoW<ExperienceReservationPayment>, EliteDomusUoW<ExperienceReservationPayment>>();
        serviceCollection.AddScoped<IEliteDomusUoW<ExperienceReservation>, EliteDomusUoW<ExperienceReservation>>();
        serviceCollection.AddScoped<IEliteDomusUoW<PAWReceipt>, EliteDomusUoW<PAWReceipt>>();
        serviceCollection.AddScoped<IEliteDomusUoW<UnitMeasure>, EliteDomusUoW<UnitMeasure>>();
        serviceCollection.AddScoped<IEliteDomusUoW<FoodAndBeverage>, EliteDomusUoW<FoodAndBeverage>>();
        serviceCollection.AddScoped<IEliteDomusUoW<VAT_Rate>, EliteDomusUoW<VAT_Rate>>();
        serviceCollection.AddScoped<IEliteDomusUoW<Proforma>, EliteDomusUoW<Proforma>>();
        serviceCollection.AddScoped<IEliteDomusUoW<UserSecurity>, EliteDomusUoW<UserSecurity>>();
        serviceCollection.AddScoped<IEliteDomusUoW<TouristTax>, EliteDomusUoW<TouristTax>>();
        serviceCollection.AddScoped<IEliteDomusUoW<Property>, EliteDomusUoW<Property>>();
        serviceCollection.AddScoped<IEliteDomusUoW<Room>, EliteDomusUoW<Room>>();
        serviceCollection.AddScoped<IEliteDomusUoW<RoomType>, EliteDomusUoW<RoomType>>();
        serviceCollection.AddScoped<IEliteDomusUoW<PriceList>, EliteDomusUoW<PriceList>>();
        serviceCollection.AddScoped<IEliteDomusUoW<Old_PriceList>, EliteDomusUoW<Old_PriceList>>();
        serviceCollection.AddScoped<IEliteDomusUoW<Old_PriceListDaily>, EliteDomusUoW<Old_PriceListDaily>>();
        serviceCollection.AddScoped<IEliteDomusUoW<PriceListDaily>, EliteDomusUoW<PriceListDaily>>();
        serviceCollection.AddScoped<IEliteDomusUoW<PriceListSetting>, EliteDomusUoW<PriceListSetting>>();
        serviceCollection.AddScoped<IEliteDomusUoW<PropertyImage>, EliteDomusUoW<PropertyImage>>();
        serviceCollection.AddScoped<IEliteDomusUoW<RoomTypeImage>, EliteDomusUoW<RoomTypeImage>>();
        serviceCollection.AddScoped<IEliteDomusUoW<RoomTypeMinStayDaily>, EliteDomusUoW<RoomTypeMinStayDaily>>();
        serviceCollection.AddScoped<IEliteDomusUoW<RoomTypeStopSellDaily>, EliteDomusUoW<RoomTypeStopSellDaily>>();
        serviceCollection.AddScoped<IEliteDomusUoW<RoomTypeClosedToDepartureDaily>, EliteDomusUoW<RoomTypeClosedToDepartureDaily>>();
        serviceCollection.AddScoped<IEliteDomusUoW<RoomTypeClosedToArrivalDaily>, EliteDomusUoW<RoomTypeClosedToArrivalDaily>>();
        serviceCollection.AddScoped<IEliteDomusUoW<RoomTypeMaxStayDaily>, EliteDomusUoW<RoomTypeMaxStayDaily>>();
        serviceCollection.AddScoped<IEliteDomusUoW<Experience>, EliteDomusUoW<Experience>>();
        serviceCollection.AddScoped<IEliteDomusUoW<DataPortal>, EliteDomusUoW<DataPortal>>();
        serviceCollection.AddScoped<IEliteDomusUoW<MovementDeparture>, EliteDomusUoW<MovementDeparture>>();
        serviceCollection.AddScoped<IEliteDomusUoW<MovementArrival>, EliteDomusUoW<MovementArrival>>();
        serviceCollection.AddScoped<IEliteDomusUoW<MovementReservation>, EliteDomusUoW<MovementReservation>>();
        serviceCollection.AddScoped<IEliteDomusUoW<ApplicationDbContext>, EliteDomusUoW<ApplicationDbContext>>();
        serviceCollection.AddScoped<IEliteDomusUoW<ExperienceProperty>, EliteDomusUoW<ExperienceProperty>>();
        serviceCollection.AddScoped<IEliteDomusUoW<CleanCompany>, EliteDomusUoW<CleanCompany>>();
        serviceCollection.AddScoped<IEliteDomusUoW<CleanCompanyUser>, EliteDomusUoW<CleanCompanyUser>>();
        serviceCollection.AddScoped<IEliteDomusUoW<CleanRoomHistory>, EliteDomusUoW<CleanRoomHistory>>();
        serviceCollection.AddScoped<IEliteDomusUoW<Reservation>, EliteDomusUoW<Reservation>>();
        serviceCollection.AddScoped<IEliteDomusUoW<CheckIn>, EliteDomusUoW<CheckIn>>();
        serviceCollection.AddScoped<IEliteDomusUoW<CheckInGuest>, EliteDomusUoW<CheckInGuest>>();
        serviceCollection.AddScoped<IEliteDomusUoW<CheckInDoc>, EliteDomusUoW<CheckInDoc>>();
        serviceCollection.AddScoped<IEliteDomusUoW<Municipality>, EliteDomusUoW<Municipality>>();
        serviceCollection.AddScoped<IEliteDomusUoW<State>, EliteDomusUoW<State>>();
        serviceCollection.AddScoped<IEliteDomusUoW<Province>, EliteDomusUoW<Province>>();
        serviceCollection.AddScoped<IEliteDomusUoW<GuestType>, EliteDomusUoW<GuestType>>();
        serviceCollection.AddScoped<IEliteDomusUoW<DocumentType>, EliteDomusUoW<DocumentType>>();
        serviceCollection.AddScoped<IEliteDomusUoW<Quote>, EliteDomusUoW<Quote>>();
        serviceCollection.AddScoped<IEliteDomusUoW<QuotePriceDetail>, EliteDomusUoW<QuotePriceDetail>>();
        serviceCollection.AddScoped<IEliteDomusUoW<QuoteRoomType>, EliteDomusUoW<QuoteRoomType>>();
        serviceCollection.AddScoped<IEliteDomusUoW<ReservationPriceDetail>, EliteDomusUoW<ReservationPriceDetail>>();
        serviceCollection.AddScoped<IEliteDomusUoW<ReservationPayment>, EliteDomusUoW<ReservationPayment>>();
        serviceCollection.AddScoped<IEliteDomusUoW<TouristTaxPayment>, EliteDomusUoW<TouristTaxPayment>>();
        serviceCollection.AddScoped<IEliteDomusUoW<TmpMedia>, EliteDomusUoW<TmpMedia>>();
        serviceCollection.AddScoped<IEliteDomusUoW<UserSecurity>, EliteDomusUoW<UserSecurity>>();
        serviceCollection.AddScoped<IEliteDomusUoW<Company>, EliteDomusUoW<Company>>();
        serviceCollection.AddScoped<IEliteDomusUoW<ChannexRoomTypeFacility>, EliteDomusUoW<ChannexRoomTypeFacility>>();
        serviceCollection.AddScoped<IEliteDomusUoW<ChannexPropertyFacility>, EliteDomusUoW<ChannexPropertyFacility>>();
        serviceCollection.AddScoped<IEliteDomusUoW<PropertyFacility>, EliteDomusUoW<PropertyFacility>>();
        serviceCollection.AddScoped<IEliteDomusUoW<RoomTypeFacility>, EliteDomusUoW<RoomTypeFacility>>();
        serviceCollection.AddScoped<IEliteDomusUoW<ChannexProperty>, EliteDomusUoW<ChannexProperty>>();
        serviceCollection.AddScoped<IEliteDomusUoW<Coupon>, EliteDomusUoW<Coupon>>();
        serviceCollection.AddScoped<IEliteDomusUoW<CouponCode>, EliteDomusUoW<CouponCode>>();
        serviceCollection.AddScoped<IEliteDomusUoW<CouponRoomType>, EliteDomusUoW<CouponRoomType>>();
        serviceCollection.AddScoped<IEliteDomusUoW<CouponReservation>, EliteDomusUoW<CouponReservation>>();
        serviceCollection.AddScoped<IEliteDomusUoW<RoomUnavailability>, EliteDomusUoW<RoomUnavailability>>();
        serviceCollection.AddScoped<IEliteDomusUoW<ChannexRoomType>, EliteDomusUoW<ChannexRoomType>>();
        serviceCollection.AddScoped<IEliteDomusUoW<ChannexRoomTypeAvailability>, EliteDomusUoW<ChannexRoomTypeAvailability>>();
        serviceCollection.AddScoped<IEliteDomusUoW<ChannexRoomTypeRatePlan>, EliteDomusUoW<ChannexRoomTypeRatePlan>>();
        serviceCollection.AddScoped<IEliteDomusUoW<RoomTypeAvailability>, EliteDomusUoW<RoomTypeAvailability>>();
        serviceCollection.AddScoped<IEliteDomusUoW<RatePlan>, EliteDomusUoW<RatePlan>>();
        serviceCollection.AddScoped<IEliteDomusUoW<RatePlanDaily>, EliteDomusUoW<RatePlanDaily>>();
        serviceCollection.AddScoped<IEliteDomusUoW<Currency>, EliteDomusUoW<Currency>>();
        serviceCollection.AddScoped<IMyUserRepository, MyUserRepository>();
        #endregion
        
        #region Service Dependency Injection
        serviceCollection.AddTransient<IFatturazioneElettronicaService, FatturazioneElettronicaService>();
        serviceCollection.AddTransient<IBaseService, BaseService>();
        serviceCollection.AddTransient<IAccountService, AccountService>();
        serviceCollection.AddTransient<IPropertyService, PropertyService>();
        serviceCollection.AddTransient<IMediaService, MediaService>();
        serviceCollection.AddTransient<IExtraService, ExtraService>();
        serviceCollection.AddTransient<ITouristTaxService, TouristTaxService>();
        serviceCollection.AddTransient<IRossService, RossService>();
        serviceCollection.AddTransient<IRoomService, RoomService>();
        serviceCollection.AddTransient<ICleanService, CleanService>();
        serviceCollection.AddTransient<IPriceListService, PriceListService>();
        serviceCollection.AddTransient<IReservationService, ReservationService>();
        serviceCollection.AddTransient<ICheckInService, CheckInService>();
        serviceCollection.AddTransient<IPoliceTableService, PoliceTableService>();
        serviceCollection.AddTransient<IQuoteService, QuoteService>();
        serviceCollection.AddTransient<IPortalService, PortalService>();
        serviceCollection.AddTransient<IChannexService, ChannexService>();
        serviceCollection.AddTransient<ICouponService, CouponService>();
        serviceCollection.AddTransient<IOpenAPIService, OpenAPIService>();
        serviceCollection.AddTransient<IAccountingService, AccountingService>();
        #endregion

        #region Utils Dependency Injection
        serviceCollection.AddHttpClient<IChannexHttpClient, ChannexHttplClient>();
        serviceCollection.AddHttpClient<IOpenAPIHttpClient, OpenAPIHttplClient>();
        serviceCollection.AddScoped<IChannexHttpService, ChannexHttpService>();
        serviceCollection.AddScoped<IEmailSender, EmailSender>();
        serviceCollection.AddScoped<ICsvService, CsvService>();
        serviceCollection.AddScoped<IPdfService, PdfService>();
        serviceCollection.AddScoped<IFileService, FileService>();
        serviceCollection.AddTransient<DataSecurity>();
        serviceCollection.AddTransient<IStripeService, StripeService>();
        serviceCollection.AddTransient<StripeHelper>();
        serviceCollection.AddHttpClient<Ross1000.IRossSendingService, EliteDomus.Ross1000.RossSendingService>();

        #endregion
    
        #region Validator Dependency Injection
        serviceCollection.AddTransient<CustomerBusinessInfoValidator>();
        serviceCollection.AddTransient<PropertyValidator>();
        serviceCollection.AddTransient<MediaValidator>();
        serviceCollection.AddTransient<ExperienceValidator>();
        serviceCollection.AddTransient<RoomValidator>();
        serviceCollection.AddTransient<RoomTypeValidator>();
        serviceCollection.AddTransient<TouristTaxValidator>();
        serviceCollection.AddTransient<CleanValidator>();
        serviceCollection.AddTransient<ReservationValidator>();
        serviceCollection.AddTransient<CheckInGuestValidator>();
        serviceCollection.AddTransient<QuoteValidator>();
        serviceCollection.AddTransient<CouponValidator>();
        serviceCollection.AddTransient<PriceListSettingValidator>();
        serviceCollection.AddTransient<FoodAndBeverageValidator>();
        serviceCollection.AddTransient<CostTypeValidator>();
        #endregion

        #region Helper Dependency Injection
        serviceCollection.AddTransient<HomeHelper>();
        serviceCollection.AddTransient<AuthHelper>();
        serviceCollection.AddTransient<AccountHelper>();
        serviceCollection.AddTransient<PropertyHelper>();
        serviceCollection.AddTransient<MediaHelper>();
        serviceCollection.AddTransient<CommonHelper>();
        serviceCollection.AddTransient<ExtraHelper>();
        serviceCollection.AddTransient<RoomHelper>();
        serviceCollection.AddTransient<PriceListHelper>();
        serviceCollection.AddTransient<CleanHelper>();
        serviceCollection.AddTransient<ReservationHelper>();
        serviceCollection.AddTransient<CheckInHelper>();
        serviceCollection.AddTransient<QuoteHelper>();
        serviceCollection.AddTransient<CustomerHelper>();
        serviceCollection.AddTransient<ChannexHelper>();
        serviceCollection.AddTransient<CouponHelper>();
        serviceCollection.AddTransient<RossHelper>();
        serviceCollection.AddTransient<FileHelper>();
        serviceCollection.AddTransient<ExternalEventsHelper>();
        serviceCollection.AddTransient<DataPortalHelper>();
        serviceCollection.AddTransient<OpenAPIHelper>();
        serviceCollection.AddTransient<AccountingHelper>();
        #endregion
        
        return serviceCollection;
    }
}