﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using Develappers.BillomatNet.Api;
using Develappers.BillomatNet.Types;

namespace Develappers.BillomatNet.Mapping
{
    internal class PurchaseInvoiceMapper : IMapper<Incoming, PurchaseInvoice>
    {
        public PurchaseInvoice ApiToDomain(Incoming value)
        {
            if (value == null)
            {
                return null;
            }

            return new PurchaseInvoice
            {
                Id = value.Id.ToInt(),
                Address = value.Address.Sanitize(),
                Number = value.Number.Sanitize(),
                DueDate = value.DueDate.ToOptionalDateTime(),
                Category = value.Category.Sanitize(),
                ClientNumber = value.ClientNumber.Sanitize(),
                Created = value.Created.ToDateTime(),
                CurrencyCode = value.CurrencyCode.Sanitize(),
                Date = value.Date.ToDateTime(),
                ExpenseAccountNumber = value.ExpenseAccountNumber.Sanitize(),
                Label = value.Label.Sanitize(),
                Note = value.Note.Sanitize(),
                OpenAmount = value.OpenAmount.ToFloat(),
                PageCount = value.PageCount.ToInt(),
                PaidAmount = value.PaidAmount.ToFloat(),
                Quote = value.Quote.ToFloat(),
                Status = value.Status.ToPurchaseInvoiceStatus(),
                SupplierId = value.SupplierId.ToInt(),
                TotalGross = value.TotalGross.ToFloat(),
                TotalNet = value.TotalNet.ToFloat(),
                Updated = value.Updated.ToDateTime()
            };
        }


        public Api.Incoming DomainToApi(PurchaseInvoice value)
        {
            if (value == null)
            {
                return null;
            }

            if (value.PdfContent != null && value.PdfContent.Length == 0)
            {
                value.PdfContent = null;
            }

            return new Api.Incoming
            {

                Id = value.Id.ToApiInt(),
                Address = value.Address,
                Number = value.Number,
                DueDate = value.DueDate.ToApiDate(),
                Category = value.Category,
                ClientNumber = value.ClientNumber,
                Created = value.Created.ToApiDateTime(),
                CurrencyCode = value.CurrencyCode,
                Date = value.Date.ToApiDate(),
                ExpenseAccountNumber = value.ExpenseAccountNumber,
                Label = value.Label,
                Note = value.Note,
                OpenAmount = value.OpenAmount.ToApiFloat(),
                PageCount = value.PageCount.ToApiInt(),
                PaidAmount = value.PaidAmount.ToApiFloat(),
                Quote = value.Quote.ToApiFloat(),
                Status = value.Status.ToApiValue(),
                SupplierId = value.SupplierId.ToApiInt(),
                TotalGross = value.TotalGross.ToApiFloat(),
                TotalNet = value.TotalNet.ToApiFloat(),
                Updated = value.Updated.ToApiDateTime(),
                Base64File = value.PdfContent != null ? Convert.ToBase64String(value.PdfContent) : null,
                Customfield = value.Customfield
            };
        }

        public PurchaseInvoice ApiToDomain(IncomingWrapper value)
        {
            return ApiToDomain(value?.Incoming);
        }

        public Types.PagedList<PurchaseInvoice> ApiToDomain(IncomingListWrapper value)
        {
            return ApiToDomain(value?.Item);
        }

        public Types.PagedList<PurchaseInvoice> ApiToDomain(IncomingList value)
        {
            if (value == null)
            {
                return null;
            }

            return new Types.PagedList<PurchaseInvoice>
            {
                Page = value.Page,
                ItemsPerPage = value.PerPage,
                TotalItems = value.Total,
                List = value.List?.Select(ApiToDomain).ToList()
            };
        }
    }
}
