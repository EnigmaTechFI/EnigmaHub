using EliteDomus.Domain.Constants;
using EliteDomus.Domain.Context;
using EliteDomus.Domain.Models.Ross;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace EliteDomus.Domain.Data;

public class DbInitializer
{
    public static async Task SeedUsersAndRoles(UserManager<MyUser> userManager, RoleManager<IdentityRole> roleManager,
        ApplicationDbContext applicationDbContext, IConfiguration config, Company customerCompany)
    {
        #region AddRoles
        IdentityResult roleResult;
        string[] roleNames = { Roles.User, Roles.Admin, Roles.Guest, Roles.Cleaner, Roles.Develop};
        foreach (var roleName in roleNames)
        {
            var roleExist = roleManager.RoleExistsAsync(roleName).Result;
            if (!roleExist)
                roleResult = roleManager.CreateAsync(new IdentityRole(roleName)).Result;
        }
        
        #endregion

        #region AddUserAndCompany

        var adm2 = userManager.FindByEmailAsync("elitedomus@enigma-tech.it").Result;
        if (adm2 == null)
        {
            adm2 = new MyUser
            {
                Id = "da010659-e752-4902-9d06-73dde10af9f0",
                FirstName = "Elite",
                LastName = "Domus",
                Address = "Via Antonio Gramsci, 37",
                UserName = "elite_domus",
                Email = "elitedomus@enigma-tech.it",
                EmailConfirmed = true,
                City = "Scarperia E San Piero",
                Nation = "Italy",
                ZipCode = "50038",
                Province = "Florence",
                PhoneNumber = "3396227051"
            };

            IdentityResult result = userManager.CreateAsync(adm2, "Antani123!").Result;
            var addedRole = userManager.AddToRolesAsync(adm2, new[] { Roles.Develop}).Result;
        }

        var channex = userManager.FindByEmailAsync("channex@enigma-tech.it").Result;
        if (channex == null)
        {
            channex = new MyUser
            {
                Id = "channex9-e752-4902-9d06-73ddechannex",
                FirstName = "Channex",
                LastName = "Channex",
                Address = "Via Antonio Gramsci, 37",
                UserName = "channex_user",
                Email = "channex@enigma-tech.it",
                EmailConfirmed = true,
                City = "Scarperia E San Piero",
                Nation = "Italy",
                ZipCode = "50038",
                Province = "Florence",
                PhoneNumber = "3396227051"
            };

            IdentityResult result = userManager.CreateAsync(channex, "Antani123!").Result;
            var addedRole = userManager.AddToRolesAsync(channex, new[] { Roles.Develop}).Result;
        }
        
        var company = applicationDbContext.Company.SingleOrDefault();
        if (company == null)
        {
            customerCompany = applicationDbContext.Add(customerCompany).Entity;
            await applicationDbContext.SaveChangesAsync(EliteDomusConstants.DevUser.Id);
        }
        
        var adm1 = userManager.FindByEmailAsync("develop@enigma-tech.it").Result;
        if (adm1 == null)
        {
            adm1 = new MyUser
            {
                CompanyId = customerCompany.Id,
                FirstName = "Lorenzo",
                LastName = "Vettori",
                Address = "Via Antonio Gramsci, 37",
                UserName = "develop_enigma",
                Email = "develop@enigma-tech.it",
                EmailConfirmed = true,
                City = "Scarperia E San Piero",
                Nation = "Italy",
                ZipCode = "50038",
                Province = "Florence",
                PhoneNumber = "3396227051"
            };

            IdentityResult result = userManager.CreateAsync(adm1, "Antani123!").Result;
            var addedRole = userManager.AddToRolesAsync(adm1, new[] { Roles.Admin}).Result;
        }
        var adm3 = userManager.FindByEmailAsync("margherita@villaerbaiarelais.com").Result;
        if (adm3 == null)
        {
            adm3 = new MyUser
            {
                CompanyId = customerCompany.Id,
                FirstName = "Margherita",
                LastName = "Questori",
                Address = "Via Erbaia, 73",
                UserName = "margherita_questori",
                Email = "margherita@villaerbaiarelais.com",
                EmailConfirmed = true,
                City = "Borgo San Lorenzo",
                Nation = "Italy",
                ZipCode = "50032",
                Province = "Florence",
                PhoneNumber = "3342267310"
            };

            IdentityResult result = userManager.CreateAsync(adm3, "VillaErbaia2@24!").Result;
            var addedRole = userManager.AddToRolesAsync(adm3, new[] { Roles.Admin}).Result;
        }

        #endregion
        
        #region AddPortaleFlussiTuristici
        
        var portaliFlussiTur = new List<PortaleFlussiTuristici>()
        {
            new (){Name = "Regione Piemonte", WsUrl = "https://piemontedatiturismo.regione.piemonte.it/ws/checkinV2?wsdl", IsActive = true },
            new (){Name = "Città Metropolitana di Firenze", WsUrl = "https://turismo5firenze.regione.toscana.it/ws/checkinV2?wsdl", IsActive = true },
            new (){Name = "Provincia di Pistoia", WsUrl = "https://turismo5pistoia.regione.toscana.it/ws/checkinV2?wsdl", IsActive = true },
            new (){Name = "Provincia di Prato", WsUrl = "https://turismo5prato.regione.toscana.it/ws/checkinV2?wsdl", IsActive = true },
            new (){Name = "Regione Abruzzo", WsUrl = "https://app.regione.abruzzo.it/Turismo5/ws/checkinV2?wsdl", IsActive = true },
            new (){Name = "Regione Veneto", WsUrl = "https://flussituristici.regione.veneto.it/ws/checkinV2?wsdl", IsActive = true },
            new (){Name = "Regione Emilia-Romagna", WsUrl = "https://datiturismo.regione.emilia-romagna.it/ws/checkinV2?wsdl", IsActive = true },
            new (){Name = "Regione Marche", WsUrl = "https://istrice-ross1000.turismo.marche.it/ws/checkinV2?wsdl", IsActive = true },
            new (){Name = "Regione Lombardia", WsUrl = "https://www.flussituristici.servizirl.it/Turismo5/app/ws/checkinV2?wsdl", IsActive = true },
            new (){Name = "Regione Calabria", WsUrl = "https://sirdat.regione.calabria.it/ws/checkinV2?wsdl", IsActive = true },
            new (){Name = "Regione Sardegna", WsUrl = "https://sardegnaturismo.ross1000.it/ws/checkinV2?wsdl", IsActive = true },
            new (){Name = "Regione TEST", WsUrl = "https://q-veneto.turitweb.it/ws/checkinV2?wsdl", IsActive = false }
        };
        var old_portali = applicationDbContext.PortaliFlussiTuristici.ToList();
        var portale_to_add = portaliFlussiTur.Except(old_portali, new PortaliComparer());

        await applicationDbContext.PortaliFlussiTuristici.AddRangeAsync(portale_to_add);
        await applicationDbContext.SaveChangesAsync();
        #endregion
        
        #region AddVATRate
        
        var vat_rate = new List<VAT_Rate>()
        {
            new (){VAT = 22, Description = "22%"},
            new (){VAT = 10, Description = "10%"},
            new (){VAT = 5, Description = "5%"},
            new (){VAT = 4, Description = "4%"},
            new (){VAT = 0, Name = "Escluso", Description = "Art.15 DPR 633/72"},
            new (){VAT = 0, Name = "Non soggetto", Description = "Regime forfettario Art.1, c. 54-89, L. 190/2014 non soggetta ad IVA né a ritenuta ai sensi dell’Art. 1, C. 67 L. 190/2014 e successive modificazioni"},
            new (){VAT = 0, Name = "Non soggetto", Description = "Regime dei minimi Art.1, c. 96-117, L.244/2007 come modif. da Art.27, DL 98/2011"},
            new (){VAT = 0, Name = "Non soggetto", Description = "Art.1 c. 939 Legge 205/2017 - Carburanti in dep fiscali"},
            new (){VAT = 0, Name = "Non soggetto", Description = "Art.2 DPR 633/72"},
            new (){VAT = 0, Name = "Non soggetto", Description = "Art.3 c. 4 e 5 DPR 633/72"},
            new (){VAT = 0, Name = "Non soggetto", Description = "Art.4 c.5 DPR 633/72"},
            new (){VAT = 0, Name = "Non soggetto", Description = "Art.5 DPR 633/72"},
            new (){VAT = 0, Name = "Non soggetto", Description = "Art 7 ter DPR 633/72 - Servizi resi a soggetto estero in Reverse Charge"},
            new (){VAT = 0, Name = "Non soggetto", Description = "Artt da 7 a 7-septies DPR 633/72 - Non Soggetta ad IVA"},
            new (){VAT = 0, Name = "Non soggetto", Description = "Art.8 comma 35 Legge 67/88 - Distacco del personale"},
            new (){VAT = 0, Name = "Non soggetto", Description = "Art.8 Legge 266/91 - Organiz. Volontario"},
        };
        var old_vat_rate = applicationDbContext.VAT_Rates.ToList();
        var vat_rate_to_add = vat_rate.Except(old_vat_rate, new VATComparer());

        await applicationDbContext.VAT_Rates.AddRangeAsync(vat_rate_to_add);
        await applicationDbContext.SaveChangesAsync();
        #endregion
        
        #region AddUnitMeasure
        
        var unit_measure = new List<UnitMeasure>()
        {
            new (){Name = "Milligrammi", Abbreviation = "mg"},
            new (){Name = "Grammi", Abbreviation = "g"},
            new (){Name = "Chilogrammi", Abbreviation = "kg"},
            new (){Name = "Millilitri", Abbreviation = "ml"},
            new (){Name = "Centilitri", Abbreviation = "cl"},
            new (){Name = "Litri", Abbreviation = "l"},
            new (){Name = "Pezzi", Abbreviation = "pz"},
            new (){Name = "Porzioni", Abbreviation = "porz"},
            new (){Name = "Fette", Abbreviation = "fette"},
            new (){Name = "Bottiglie", Abbreviation = "bott"},
            new (){Name = "Scatole", Abbreviation = "scat"},
            new (){Name = "Confezioni", Abbreviation = "conf"},
            new (){Name = "Pacchi", Abbreviation = "pac"},
        };
        var old_unit_measure = applicationDbContext.UnitMeasures.ToList();
        var unit_measure_to_add = unit_measure.Except(old_unit_measure, new UnitMeasureComparer());

        await applicationDbContext.UnitMeasures.AddRangeAsync(unit_measure_to_add);
        await applicationDbContext.SaveChangesAsync();
        #endregion

        #region AddCurrency

        var new_currencies = new List<Currency>()
        {
            new () { Name = "Afghani", AlphabeticCode = "AFN", NumericCode = 971, MinorUnit = 2 },
            new () { Name = "Euro", AlphabeticCode = "EUR", NumericCode = 978, MinorUnit = 2 },
            new () { Name = "Lek", AlphabeticCode = "ALL", NumericCode = 8, MinorUnit = 2 },
            new () { Name = "Algerian Dinar", AlphabeticCode = "DZD", NumericCode = 12, MinorUnit = 2 },
            new () { Name = "US Dollar", AlphabeticCode = "USD", NumericCode = 840, MinorUnit = 2 },
            new () { Name = "Kwanza", AlphabeticCode = "AOA", NumericCode = 973, MinorUnit = 2 },
            new () { Name = "East Caribbean Dollar", AlphabeticCode = "XCD", NumericCode = 951, MinorUnit = 2 },
            new () { Name = "Argentine Peso", AlphabeticCode = "ARS", NumericCode = 32, MinorUnit = 2 },
            new () { Name = "Armenian Dram", AlphabeticCode = "AMD", NumericCode = 51, MinorUnit = 2 },
            new () { Name = "Aruban Florin", AlphabeticCode = "AWG", NumericCode = 533, MinorUnit = 2 },
            new () { Name = "Australian Dollar", AlphabeticCode = "AUD", NumericCode = 36, MinorUnit = 2 },
            new () { Name = "Azerbaijan Manat", AlphabeticCode = "AZN", NumericCode = 944, MinorUnit = 2 },
            new () { Name = "Bahamian Dollar", AlphabeticCode = "BSD", NumericCode = 44, MinorUnit = 2 },
            new () { Name = "Bahraini Dinar", AlphabeticCode = "BHD", NumericCode = 48, MinorUnit = 3 },
            new () { Name = "Taka", AlphabeticCode = "BDT", NumericCode = 50, MinorUnit = 2 },
            new () { Name = "Barbados Dollar", AlphabeticCode = "BBD", NumericCode = 52, MinorUnit = 2 },
            new () { Name = "Belarusian Ruble", AlphabeticCode = "BYN", NumericCode = 933, MinorUnit = 2 },
            new () { Name = "Belize Dollar", AlphabeticCode = "BZD", NumericCode = 84, MinorUnit = 2 },
            new () { Name = "CFA Franc BCEAO", AlphabeticCode = "XOF", NumericCode = 952, MinorUnit = 0 },
            new () { Name = "Bermudian Dollar", AlphabeticCode = "BMD", NumericCode = 60, MinorUnit = 2 },
            new () { Name = "Indian Rupee", AlphabeticCode = "INR", NumericCode = 356, MinorUnit = 2 },
            new () { Name = "Ngultrum", AlphabeticCode = "BTN", NumericCode = 64, MinorUnit = 2 },
            new () { Name = "Boliviano", AlphabeticCode = "BOB", NumericCode = 68, MinorUnit = 2 },
            new () { Name = "Mvdol", AlphabeticCode = "BOV", NumericCode = 984, MinorUnit = 2 },
            new () { Name = "Convertible Mark", AlphabeticCode = "BAM", NumericCode = 977, MinorUnit = 2 },
            new () { Name = "Pula", AlphabeticCode = "BWP", NumericCode = 72, MinorUnit = 2 },
            new () { Name = "Norwegian Krone", AlphabeticCode = "NOK", NumericCode = 578, MinorUnit = 2 },
            new () { Name = "Brazilian Real", AlphabeticCode = "BRL", NumericCode = 986, MinorUnit = 2 },
            new () { Name = "Brunei Dollar", AlphabeticCode = "BND", NumericCode = 96, MinorUnit = 2 },
            new () { Name = "Bulgarian Lev", AlphabeticCode = "BGN", NumericCode = 975, MinorUnit = 2 },
            new () { Name = "Burundi Franc", AlphabeticCode = "BIF", NumericCode = 108, MinorUnit = 0 },
            new () { Name = "Cabo Verde Escudo", AlphabeticCode = "CVE", NumericCode = 132, MinorUnit = 2 },
            new () { Name = "Riel", AlphabeticCode = "KHR", NumericCode = 116, MinorUnit = 2 },
            new () { Name = "CFA Franc BEAC", AlphabeticCode = "XAF", NumericCode = 950, MinorUnit = 0 },
            new () { Name = "Canadian Dollar", AlphabeticCode = "CAD", NumericCode = 124, MinorUnit = 2 },
            new () { Name = "Cayman Islands Dollar", AlphabeticCode = "KYD", NumericCode = 136, MinorUnit = 2 },
            new () { Name = "Chilean Peso", AlphabeticCode = "CLP", NumericCode = 152, MinorUnit = 0 },
            new () { Name = "Unidad de Fomento", AlphabeticCode = "CLF", NumericCode = 990, MinorUnit = 4 },
            new () { Name = "Yuan Renminbi", AlphabeticCode = "CNY", NumericCode = 156, MinorUnit = 2 },
            new () { Name = "Colombian Peso", AlphabeticCode = "COP", NumericCode = 170, MinorUnit = 2 },
            new () { Name = "Unidad de Valor Real", AlphabeticCode = "COU", NumericCode = 970, MinorUnit = 2 },
            new () { Name = "Comorian Franc ", AlphabeticCode = "KMF", NumericCode = 174, MinorUnit = 0 },
            new () { Name = "Congolese Franc", AlphabeticCode = "CDF", NumericCode = 976, MinorUnit = 2 },
            new () { Name = "New Zealand Dollar", AlphabeticCode = "NZD", NumericCode = 554, MinorUnit = 2 },
            new () { Name = "Costa Rican Colon", AlphabeticCode = "CRC", NumericCode = 188, MinorUnit = 2 },
            new () { Name = "Kuna", AlphabeticCode = "HRK", NumericCode = 191, MinorUnit = 2 },
            new () { Name = "Cuban Peso", AlphabeticCode = "CUP", NumericCode = 192, MinorUnit = 2 },
            new () { Name = "Peso Convertible", AlphabeticCode = "CUC", NumericCode = 931, MinorUnit = 2 },
            new () { Name = "Netherlands Antillean Guilder", AlphabeticCode = "ANG", NumericCode = 532, MinorUnit = 2 },
            new () { Name = "Czech Koruna", AlphabeticCode = "CZK", NumericCode = 203, MinorUnit = 2 },
            new () { Name = "Danish Krone", AlphabeticCode = "DKK", NumericCode = 208, MinorUnit = 2 },
            new () { Name = "Djibouti Franc", AlphabeticCode = "DJF", NumericCode = 262, MinorUnit = 0 },
            new () { Name = "Dominican Peso", AlphabeticCode = "DOP", NumericCode = 214, MinorUnit = 2 },
            new () { Name = "Egyptian Pound", AlphabeticCode = "EGP", NumericCode = 818, MinorUnit = 2 },
            new () { Name = "El Salvador Colon", AlphabeticCode = "SVC", NumericCode = 222, MinorUnit = 2 },
            new () { Name = "Nakfa", AlphabeticCode = "ERN", NumericCode = 232, MinorUnit = 2 },
            new () { Name = "Lilangeni", AlphabeticCode = "SZL", NumericCode = 748, MinorUnit = 2 },
            new () { Name = "Ethiopian Birr", AlphabeticCode = "ETB", NumericCode = 230, MinorUnit = 2 },
            new () { Name = "Falkland Islands Pound", AlphabeticCode = "FKP", NumericCode = 238, MinorUnit = 2 },
            new () { Name = "Fiji Dollar", AlphabeticCode = "FJD", NumericCode = 242, MinorUnit = 2 },
            new () { Name = "CFP Franc", AlphabeticCode = "XPF", NumericCode = 953, MinorUnit = 0 },
            new () { Name = "Dalasi", AlphabeticCode = "GMD", NumericCode = 270, MinorUnit = 2 },
            new () { Name = "Lari", AlphabeticCode = "GEL", NumericCode = 981, MinorUnit = 2 },
            new () { Name = "Ghana Cedi", AlphabeticCode = "GHS", NumericCode = 936, MinorUnit = 2 },
            new () { Name = "Gibraltar Pound", AlphabeticCode = "GIP", NumericCode = 292, MinorUnit = 2 },
            new () { Name = "Quetzal", AlphabeticCode = "GTQ", NumericCode = 320, MinorUnit = 2 },
            new () { Name = "Pound Sterling", AlphabeticCode = "GBP", NumericCode = 826, MinorUnit = 2 },
            new () { Name = "Guinean Franc", AlphabeticCode = "GNF", NumericCode = 324, MinorUnit = 0 },
            new () { Name = "Guyana Dollar", AlphabeticCode = "GYD", NumericCode = 328, MinorUnit = 2 },
            new () { Name = "Gourde", AlphabeticCode = "HTG", NumericCode = 332, MinorUnit = 2 },
            new () { Name = "Lempira", AlphabeticCode = "HNL", NumericCode = 340, MinorUnit = 2 },
            new () { Name = "Hong Kong Dollar", AlphabeticCode = "HKD", NumericCode = 344, MinorUnit = 2 },
            new () { Name = "Forint", AlphabeticCode = "HUF", NumericCode = 348, MinorUnit = 2 },
            new () { Name = "Iceland Krona", AlphabeticCode = "ISK", NumericCode = 352, MinorUnit = 0 },
            new () { Name = "Rupiah", AlphabeticCode = "IDR", NumericCode = 360, MinorUnit = 2 },
            new () { Name = "SDR (Special Drawing Right)", AlphabeticCode = "XDR", NumericCode = 960, MinorUnit = 0 },
            new () { Name = "Iranian Rial", AlphabeticCode = "IRR", NumericCode = 364, MinorUnit = 2 },
            new () { Name = "Iraqi Dinar", AlphabeticCode = "IQD", NumericCode = 368, MinorUnit = 3 },
            new () { Name = "New Israeli Sheqel", AlphabeticCode = "ILS", NumericCode = 376, MinorUnit = 2 },
            new () { Name = "Jamaican Dollar", AlphabeticCode = "JMD", NumericCode = 388, MinorUnit = 2 },
            new () { Name = "Yen", AlphabeticCode = "JPY", NumericCode = 392, MinorUnit = 0 },
            new () { Name = "Jordanian Dinar", AlphabeticCode = "JOD", NumericCode = 400, MinorUnit = 3 },
            new () { Name = "Tenge", AlphabeticCode = "KZT", NumericCode = 398, MinorUnit = 2 },
            new () { Name = "Kenyan Shilling", AlphabeticCode = "KES", NumericCode = 404, MinorUnit = 2 },
            new () { Name = "North Korean Won", AlphabeticCode = "KPW", NumericCode = 408, MinorUnit = 2 },
            new () { Name = "Won", AlphabeticCode = "KRW", NumericCode = 410, MinorUnit = 0 },
            new () { Name = "Kuwaiti Dinar", AlphabeticCode = "KWD", NumericCode = 414, MinorUnit = 3 },
            new () { Name = "Som", AlphabeticCode = "KGS", NumericCode = 417, MinorUnit = 2 },
            new () { Name = "Lao Kip", AlphabeticCode = "LAK", NumericCode = 418, MinorUnit = 2 },
            new () { Name = "Lebanese Pound", AlphabeticCode = "LBP", NumericCode = 422, MinorUnit = 2 },
            new () { Name = "Loti", AlphabeticCode = "LSL", NumericCode = 426, MinorUnit = 2 },
            new () { Name = "Rand", AlphabeticCode = "ZAR", NumericCode = 710, MinorUnit = 2 },
            new () { Name = "Liberian Dollar", AlphabeticCode = "LRD", NumericCode = 430, MinorUnit = 2 },
            new () { Name = "Libyan Dinar", AlphabeticCode = "LYD", NumericCode = 434, MinorUnit = 3 },
            new () { Name = "Swiss Franc", AlphabeticCode = "CHF", NumericCode = 756, MinorUnit = 2 },
            new () { Name = "Pataca", AlphabeticCode = "MOP", NumericCode = 446, MinorUnit = 2 },
            new () { Name = "Denar", AlphabeticCode = "MKD", NumericCode = 807, MinorUnit = 2 },
            new () { Name = "Malagasy Ariary", AlphabeticCode = "MGA", NumericCode = 969, MinorUnit = 2 },
            new () { Name = "Malawi Kwacha", AlphabeticCode = "MWK", NumericCode = 454, MinorUnit = 2 },
            new () { Name = "Malaysian Ringgit", AlphabeticCode = "MYR", NumericCode = 458, MinorUnit = 2 },
            new () { Name = "Rufiyaa", AlphabeticCode = "MVR", NumericCode = 462, MinorUnit = 2 },
            new () { Name = "Ouguiya", AlphabeticCode = "MRU", NumericCode = 929, MinorUnit = 2 },
            new () { Name = "Mauritius Rupee", AlphabeticCode = "MUR", NumericCode = 480, MinorUnit = 2 },
            new () { Name = "ADB Unit of Account", AlphabeticCode = "XUA", NumericCode = 965, MinorUnit = 0 },
            new () { Name = "Mexican Peso", AlphabeticCode = "MXN", NumericCode = 484, MinorUnit = 2 },
            new () { Name = "Mexican Unidad de Inversion (UDI)", AlphabeticCode = "MXV", NumericCode = 979, MinorUnit = 2 },
            new () { Name = "Moldovan Leu", AlphabeticCode = "MDL", NumericCode = 498, MinorUnit = 2 },
            new () { Name = "Tugrik", AlphabeticCode = "MNT", NumericCode = 496, MinorUnit = 2 },
            new () { Name = "Moroccan Dirham", AlphabeticCode = "MAD", NumericCode = 504, MinorUnit = 2 },
            new () { Name = "Mozambique Metical", AlphabeticCode = "MZN", NumericCode = 943, MinorUnit = 2 },
            new () { Name = "Kyat", AlphabeticCode = "MMK", NumericCode = 104, MinorUnit = 2 },
            new () { Name = "Namibia Dollar", AlphabeticCode = "NAD", NumericCode = 516, MinorUnit = 2 },
            new () { Name = "Nepalese Rupee", AlphabeticCode = "NPR", NumericCode = 524, MinorUnit = 2 },
            new () { Name = "Cordoba Oro", AlphabeticCode = "NIO", NumericCode = 558, MinorUnit = 2 },
            new () { Name = "Naira", AlphabeticCode = "NGN", NumericCode = 566, MinorUnit = 2 },
            new () { Name = "Rial Omani", AlphabeticCode = "OMR", NumericCode = 512, MinorUnit = 3 },
            new () { Name = "Pakistan Rupee", AlphabeticCode = "PKR", NumericCode = 586, MinorUnit = 2 },
            new () { Name = "Balboa", AlphabeticCode = "PAB", NumericCode = 590, MinorUnit = 2 },
            new () { Name = "Kina", AlphabeticCode = "PGK", NumericCode = 598, MinorUnit = 2 },
            new () { Name = "Guarani", AlphabeticCode = "PYG", NumericCode = 600, MinorUnit = 0 },
            new () { Name = "Sol", AlphabeticCode = "PEN", NumericCode = 604, MinorUnit = 2 },
            new () { Name = "Philippine Peso", AlphabeticCode = "PHP", NumericCode = 608, MinorUnit = 2 },
            new () { Name = "Zloty", AlphabeticCode = "PLN", NumericCode = 985, MinorUnit = 2 },
            new () { Name = "Qatari Rial", AlphabeticCode = "QAR", NumericCode = 634, MinorUnit = 2 },
            new () { Name = "Romanian Leu", AlphabeticCode = "RON", NumericCode = 946, MinorUnit = 2 },
            new () { Name = "Russian Ruble", AlphabeticCode = "RUB", NumericCode = 643, MinorUnit = 2 },
            new () { Name = "Rwanda Franc", AlphabeticCode = "RWF", NumericCode = 646, MinorUnit = 0 },
            new () { Name = " ASCENSION AND TRISTAN DA CUNHA", AlphabeticCode = "SHP", NumericCode = 654, MinorUnit = 2 },
            new () { Name = "Tala", AlphabeticCode = "WST", NumericCode = 882, MinorUnit = 2 },
            new () { Name = "Dobra", AlphabeticCode = "STN", NumericCode = 930, MinorUnit = 2 },
            new () { Name = "Saudi Riyal", AlphabeticCode = "SAR", NumericCode = 682, MinorUnit = 2 },
            new () { Name = "Serbian Dinar", AlphabeticCode = "RSD", NumericCode = 941, MinorUnit = 2 },
            new () { Name = "Seychelles Rupee", AlphabeticCode = "SCR", NumericCode = 690, MinorUnit = 2 },
            new () { Name = "Leone", AlphabeticCode = "SLL", NumericCode = 694, MinorUnit = 2 },
            new () { Name = "Singapore Dollar", AlphabeticCode = "SGD", NumericCode = 702, MinorUnit = 2 },
            new () { Name = "Sucre", AlphabeticCode = "XSU", NumericCode = 994, MinorUnit = 0 },
            new () { Name = "Solomon Islands Dollar", AlphabeticCode = "SBD", NumericCode = 90, MinorUnit = 2 },
            new () { Name = "Somali Shilling", AlphabeticCode = "SOS", NumericCode = 706, MinorUnit = 2 },
            new () { Name = "South Sudanese Pound", AlphabeticCode = "SSP", NumericCode = 728, MinorUnit = 2 },
            new () { Name = "Sri Lanka Rupee", AlphabeticCode = "LKR", NumericCode = 144, MinorUnit = 2 },
            new () { Name = "Sudanese Pound", AlphabeticCode = "SDG", NumericCode = 938, MinorUnit = 2 },
            new () { Name = "Surinam Dollar", AlphabeticCode = "SRD", NumericCode = 968, MinorUnit = 2 },
            new () { Name = "Swedish Krona", AlphabeticCode = "SEK", NumericCode = 752, MinorUnit = 2 },
            new () { Name = "WIR Euro", AlphabeticCode = "CHE", NumericCode = 947, MinorUnit = 2 },
            new () { Name = "WIR Franc", AlphabeticCode = "CHW", NumericCode = 948, MinorUnit = 2 },
            new () { Name = "Syrian Pound", AlphabeticCode = "SYP", NumericCode = 760, MinorUnit = 2 },
            new () { Name = "New Taiwan Dollar", AlphabeticCode = "TWD", NumericCode = 901, MinorUnit = 2 },
            new () { Name = "Somoni", AlphabeticCode = "TJS", NumericCode = 972, MinorUnit = 2 },
            new () { Name = " UNITED REPUBLIC OF", AlphabeticCode = "TZS", NumericCode = 834, MinorUnit = 2 },
            new () { Name = "Baht", AlphabeticCode = "THB", NumericCode = 764, MinorUnit = 2 },
            new () { Name = "Pa'anga", AlphabeticCode = "TOP", NumericCode = 776, MinorUnit = 2 },
            new () { Name = "Trinidad and Tobago Dollar", AlphabeticCode = "TTD", NumericCode = 780, MinorUnit = 2 },
            new () { Name = "Tunisian Dinar", AlphabeticCode = "TND", NumericCode = 788, MinorUnit = 3 },
            new () { Name = "Turkish Lira", AlphabeticCode = "TRY", NumericCode = 949, MinorUnit = 2 },
            new () { Name = "Turkmenistan New Manat", AlphabeticCode = "TMT", NumericCode = 934, MinorUnit = 2 },
            new () { Name = "Uganda Shilling", AlphabeticCode = "UGX", NumericCode = 800, MinorUnit = 0 },
            new () { Name = "Hryvnia", AlphabeticCode = "UAH", NumericCode = 980, MinorUnit = 2 },
            new () { Name = "UAE Dirham", AlphabeticCode = "AED", NumericCode = 784, MinorUnit = 2 },
            new () { Name = "US Dollar (Next day)", AlphabeticCode = "USN", NumericCode = 997, MinorUnit = 2 },
            new () { Name = "Peso Uruguayo", AlphabeticCode = "UYU", NumericCode = 858, MinorUnit = 2 },
            new () { Name = "Uruguay Peso en Unidades Indexadas (UI)", AlphabeticCode = "UYI", NumericCode = 940, MinorUnit = 0 },
            new () { Name = "Unidad Previsional", AlphabeticCode = "UYW", NumericCode = 927, MinorUnit = 4 },
            new () { Name = "Uzbekistan Sum", AlphabeticCode = "UZS", NumericCode = 860, MinorUnit = 2 },
            new () { Name = "Vatu", AlphabeticCode = "VUV", NumericCode = 548, MinorUnit = 0 },
            new () { Name = "BolÃ­var Soberano", AlphabeticCode = "VES", NumericCode = 928, MinorUnit = 2 },
            new () { Name = "Dong", AlphabeticCode = "VND", NumericCode = 704, MinorUnit = 0 },
            new () { Name = "Yemeni Rial", AlphabeticCode = "YER", NumericCode = 886, MinorUnit = 2 },
            new () { Name = "Zambian Kwacha", AlphabeticCode = "ZMW", NumericCode = 967, MinorUnit = 2 },
            new () { Name = "Zimbabwe Dollar", AlphabeticCode = "ZWL", NumericCode = 932, MinorUnit = 2 },
            new () { Name = "Bond Markets Unit European Composite Unit (EURCO)", AlphabeticCode = "XBA", NumericCode = 955, MinorUnit = 0 },
            new () { Name = "Bond Markets Unit European Monetary Unit (E.M.U.-6)", AlphabeticCode = "XBB", NumericCode = 956, MinorUnit = 0 },
            new () { Name = "Bond Markets Unit European Unit of Account 9 (E.U.A.-9)", AlphabeticCode = "XBC", NumericCode = 957, MinorUnit = 0 },
            new () { Name = "Bond Markets Unit European Unit of Account 17 (E.U.A.-17)", AlphabeticCode = "XBD", NumericCode = 958, MinorUnit = 0 },
            new () { Name = "Codes specifically reserved for testing purposes", AlphabeticCode = "XTS", NumericCode = 963, MinorUnit = 0 },
            new () { Name = "The codes assigned for transactions where no currency is involved", AlphabeticCode = "XXX", NumericCode = 999, MinorUnit = 0 },
            new () { Name = "Gold", AlphabeticCode = "XAU", NumericCode = 959, MinorUnit = 0 },
            new () { Name = "Palladium", AlphabeticCode = "XPD", NumericCode = 964, MinorUnit = 0 },
            new () { Name = "Platinum", AlphabeticCode = "XPT", NumericCode = 962, MinorUnit = 0 },
        };

        var old_currencies = applicationDbContext.Currencies.ToList();
        var currencies_toadd = new_currencies.Except(old_currencies, new CurrencyComparer());

        await applicationDbContext.Currencies.AddRangeAsync(currencies_toadd);
        await applicationDbContext.SaveChangesAsync();

        #endregion
    }
}

public class CurrencyComparer : IEqualityComparer<Currency>
{
    public bool Equals(Currency x, Currency y)
    {
        return x.AlphabeticCode == y.AlphabeticCode; // Sostituisci con la chiave primaria effettiva
    }

    public int GetHashCode(Currency obj)
    {
        return obj.AlphabeticCode.GetHashCode(); // Sostituisci con la chiave primaria effettiva
    }
}

public class PortaliComparer : IEqualityComparer<PortaleFlussiTuristici>
{
    public bool Equals(PortaleFlussiTuristici x, PortaleFlussiTuristici y)
    {
        return x.Name == y.Name; // Sostituisci con la chiave primaria effettiva
    }

    public int GetHashCode(PortaleFlussiTuristici obj)
    {
        return obj.Name.GetHashCode(); // Sostituisci con la chiave primaria effettiva
    }
}
public class VATComparer : IEqualityComparer<VAT_Rate>
{
    public bool Equals(VAT_Rate x, VAT_Rate y)
    {
        return x.Description == y.Description; // Sostituisci con la chiave primaria effettiva
    }

    public int GetHashCode(VAT_Rate obj)
    {
        return obj.Description.GetHashCode(); // Sostituisci con la chiave primaria effettiva
    }
}
public class UnitMeasureComparer : IEqualityComparer<UnitMeasure>
{
    public bool Equals(UnitMeasure x, UnitMeasure y)
    {
        return x.Name == y.Name; // Sostituisci con la chiave primaria effettiva
    }

    public int GetHashCode(UnitMeasure obj)
    {
        return obj.Name.GetHashCode(); // Sostituisci con la chiave primaria effettiva
    }
}

public class RoomTypeComparer : IEqualityComparer<RoomType>
{
    public bool Equals(RoomType x, RoomType y)
    {
        return x.Name == y.Name; // Sostituisci con la chiave primaria effettiva
    }

    public int GetHashCode(RoomType obj)
    {
        return obj.Name.GetHashCode(); // Sostituisci con la chiave primaria effettiva
    }
}