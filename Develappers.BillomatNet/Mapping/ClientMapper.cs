// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Globalization;
using System.Linq;
using Develappers.BillomatNet.Api;
using Client = Develappers.BillomatNet.Types.Client;

namespace Develappers.BillomatNet.Mapping
{
    internal class ClientMapper : IMapper<Api.Client, Client>
    {
        public Client ApiToDomain(Api.Client value)
        {
            if (value == null)
            {
                return null;
            }

            return new Client
            {
                Id = int.Parse(value.Id),
                Created = DateTime.Parse(value.Created, CultureInfo.InvariantCulture),
                Archived = value.Archived != "0",
                ClientNumber = value.ClientNumber,
                Number = int.Parse(value.Number),
                NumberPre = value.NumberPre,
                NumberLength = int.Parse(value.NumberLength),
                Name = value.Name,
                Salutation = value.Salutation,
                FirstName = value.FirstName,
                LastName = value.LastName,
                Street = value.Street,
                Zip = value.Zip,
                City = value.City,
                State = value.State,
                CountryCode = value.CountryCode,
                Address = value.Address,
                Phone = value.Phone,
                Fax = value.Fax,
                Mobile = value.Mobile,
                Email = value.Email,
                Www = value.Www,
                TaxNumber = value.TaxNumber,
                VatNumber = value.VatNumber,
                BankAccountOwner = value.BankAccountOwner,
                BankNumber = value.BankNumber,
                BankName = value.BankName,
                BankAccountNumber = value.BankAccountNumber,
                BankSwift = value.BankSwift,
                BankIban = value.BankIban,
                EnableCustomerportal = value.EnableCustomerportal != "0",
                CustomerportalUrl = value.CustomerportalUrl,
                SepaMandate = value.SepaMandate,
                SepaMandateDate = value.SepaMandateDate.ToOptionalDateTime(),
                TaxRule = value.TaxRule.ToTaxRuleType(),
                NetGross = value.NetGross.ToNetGrossSettingsType(),
                DefaultPaymentTypes = value.DefaultPaymentTypes.Split(',').ToList().Select(x => x.ToPaymentType()).ToList(),
                Reduction = value.Reduction.ToOptionalFloat(),
                DiscountRateType = value.DiscountRateType.ToDiscountType(),
                DiscountRate = value.DiscountRate.ToOptionalFloat(),
                DiscountDaysType = value.DiscountDaysType.ToDiscountType(),
                DicountDays = value.DicountDays.ToOptionalInt(),
                DueDaysType = value.DueDaysType.ToDiscountType(),
                DueDays = value.DueDays.ToOptionalInt(),
                ReminderDueDaysType = value.ReminderDueDaysType.ToDiscountType(),
                ReminderDueDays = value.ReminderDueDays.ToOptionalInt(),
                OfferValidityDaysType = value.OfferValidityDaysType.ToDiscountType(),
                OfferValidityDays = value.OfferValidityDays.ToOptionalInt(),
                CurrencyCode = value.CurrencyCode,
                PriceGroup = value.PriceGroup.ToOptionalInt(),
                DebitorAccountNumber = value.DebitorAccountNumber.ToOptionalInt(),
                DunningRun = value.DunningRun != "0",
                Note = value.Note,
                RevenueGross = value.RevenueGross.ToOptionalFloat(),
                RevenueNet = value.RevenueNet.ToOptionalFloat(),
                Customfield = value.Customfield
            };
        }

        public Api.Client DomainToApi(Client value)
        {
            if (value == null)
            {
                return null;
            }

            string defaultPaymentTypes = null;
            if (value.DefaultPaymentTypes != null && value.DefaultPaymentTypes.Count != 0)
            {
                defaultPaymentTypes = string.Join(",", value.DefaultPaymentTypes.Select(x => x.ToApiValue()).ToList());
            }

            return new Api.Client
            {
                Id = value.Id.ToApiInt(),
                Created = value.Created.ToApiDateTime(),
                Archived = value.Archived.BoolToString(),
                ClientNumber = value.ClientNumber,
                Number = value.Number.ToApiInt(),
                NumberPre = value.NumberPre,
                NumberLength = value.NumberLength.ToApiInt(),
                Name = value.Name,
                Salutation = value.Salutation,
                FirstName = value.FirstName,
                LastName = value.LastName,
                Street = value.Street,
                Zip = value.Zip,
                City = value.City,
                State = value.State,
                CountryCode = value.CountryCode,
                Address = value.Address,
                Phone = value.Phone,
                Fax = value.Fax,
                Mobile = value.Mobile,
                Email = value.Email,
                Www = value.Www,
                TaxNumber = value.TaxNumber,
                VatNumber = value.VatNumber,
                BankAccountOwner = value.BankAccountOwner,
                BankNumber = value.BankNumber,
                BankName = value.BankName,
                BankAccountNumber = value.BankAccountNumber,
                BankSwift = value.BankSwift,
                BankIban = value.BankIban,
                EnableCustomerportal = value.EnableCustomerportal.BoolToString(),
                CustomerportalUrl = value.CustomerportalUrl,
                SepaMandate = value.SepaMandate,
                SepaMandateDate = value.SepaMandateDate.ToApiDate(),
                TaxRule = value.TaxRule.ToApiValue(),
                NetGross = value.NetGross.ToApiValue(),
                DefaultPaymentTypes = defaultPaymentTypes,
                Reduction = value.Reduction.ToApiOptionalFloat(),
                DiscountRateType = value.DiscountRateType.ToApiValue(),
                DiscountRate = value.DiscountRate.ToApiOptionalFloat(),
                DiscountDaysType = value.DiscountDaysType.ToApiValue(),
                DicountDays = value.DicountDays.ToApiOptionalInt(),
                DueDaysType = value.DueDaysType.ToApiValue(),
                DueDays = value.DueDays.ToApiOptionalInt(),
                ReminderDueDaysType = value.ReminderDueDaysType.ToApiValue(),
                ReminderDueDays = value.ReminderDueDays.ToApiOptionalInt(),
                OfferValidityDaysType = value.OfferValidityDaysType.ToApiValue(),
                OfferValidityDays = value.OfferValidityDays.ToApiOptionalInt(),
                CurrencyCode = value.CurrencyCode,
                PriceGroup = value.PriceGroup.ToApiOptionalInt(),
                DebitorAccountNumber = value.DebitorAccountNumber.ToApiOptionalInt(),
                DunningRun = value.DunningRun.BoolToString(),
                Note = value.Note,
                RevenueGross = value.RevenueGross.ToApiOptionalFloat(),
                RevenueNet = value.RevenueNet.ToApiOptionalFloat(),
                Customfield = value.Customfield
            };
        }

        public Client ApiToDomain(ClientWrapper value)
        {
            return ApiToDomain(value?.Client);
        }

        public Types.PagedList<Client> ApiToDomain(ClientList value)
        {
            if (value == null)
            {
                return null;
            }

            return new Types.PagedList<Client>
            {
                Page = value.Page,
                ItemsPerPage = value.PerPage,
                TotalItems = value.Total,
                List = value.List?.Select(ApiToDomain).ToList()
            };
        }

        public Types.PagedList<Client> ApiToDomain(ClientListWrapper value)
        {
            return ApiToDomain(value?.Item);
        }
    }
}
