﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Develappers.BillomatNet.Api;
using Develappers.BillomatNet.Types;
using Account = Develappers.BillomatNet.Types.Account;
using Article = Develappers.BillomatNet.Types.Article;
using ArticleProperty = Develappers.BillomatNet.Types.ArticleProperty;
using ArticleTag = Develappers.BillomatNet.Types.ArticleTag;
using Client = Develappers.BillomatNet.Types.Client;
using ClientProperty = Develappers.BillomatNet.Types.ClientProperty;
using ClientTag = Develappers.BillomatNet.Types.ClientTag;
using Contact = Develappers.BillomatNet.Types.Contact;
using Offer = Develappers.BillomatNet.Types.Offer;
using OfferItem = Develappers.BillomatNet.Types.OfferItem;
using Invoice = Develappers.BillomatNet.Types.Invoice;
using InvoiceComment = Develappers.BillomatNet.Types.InvoiceComment;
using InvoiceDocument = Develappers.BillomatNet.Types.InvoiceDocument;
using OfferDocument = Develappers.BillomatNet.Types.OfferDocument;
using Attachment = Develappers.BillomatNet.Types.Attachment;
using InvoiceMail = Develappers.BillomatNet.Types.InvoiceMail;
using InvoiceItem = Develappers.BillomatNet.Types.InvoiceItem;
using InvoicePayment = Develappers.BillomatNet.Types.InvoicePayment;
using InvoiceTag = Develappers.BillomatNet.Types.InvoiceTag;
using Settings = Develappers.BillomatNet.Types.Settings;
using Supplier = Develappers.BillomatNet.Types.Supplier;
using SupplierPropertyValue = Develappers.BillomatNet.Types.SupplierPropertyValue;
using SupplierTag = Develappers.BillomatNet.Types.SupplierTag;
using TagCloudItem = Develappers.BillomatNet.Types.TagCloudItem;
using Tax = Develappers.BillomatNet.Types.Tax;
using Unit = Develappers.BillomatNet.Types.Unit;

namespace Develappers.BillomatNet.Mapping
{
    internal static class MappingExtensions
    {
        private static readonly ArticleMapper s_articleMapper = new ArticleMapper();
        private static readonly UnitMapper s_unitMapper = new UnitMapper();
        private static readonly AccountMapper s_accountMapper = new AccountMapper();
        private static readonly TaxMapper s_taxMapper = new TaxMapper();
        private static readonly InvoiceMapper s_invoiceMapper = new InvoiceMapper();
        private static readonly OfferMapper s_offerMapper = new OfferMapper();
        private static readonly OfferDocumentMapper s_offerDocumentMapper = new OfferDocumentMapper();
        private static readonly OfferItemMapper s_offerItemMapper = new OfferItemMapper();
        private static readonly SettingsMapper s_settingsMapper = new SettingsMapper();
        private static readonly InvoiceItemMapper s_invoiceItemMapper = new InvoiceItemMapper();
        private static readonly InvoiceDocumentMapper s_invoiceDocumentMapper = new InvoiceDocumentMapper();
        private static readonly InvoiceMailMapper s_invoiceMailMapper = new InvoiceMailMapper();
        private static readonly InvoiceCommentMapper s_invoiceCommentMapper = new InvoiceCommentMapper();
        private static readonly InvoicePaymentMapper s_invoicePaymentMapper = new InvoicePaymentMapper();
        private static readonly InvoiceTagMapper s_invoiceTagMapper = new InvoiceTagMapper();
        private static readonly ContactMapper s_contactMapper = new ContactMapper();
        private static readonly ArticlePropertyMapper s_articlePropertyMapper = new ArticlePropertyMapper();
        private static readonly ArticleTagMapper s_articleTagMapper = new ArticleTagMapper();
        private static readonly ClientMapper s_clientMapper = new ClientMapper();
        private static readonly ClientTagMapper s_clientTagMapper = new ClientTagMapper();
        private static readonly ClientPropertyMapper s_clientPropertyMapper = new ClientPropertyMapper();
        private static readonly SupplierMapper s_supplierMapper = new SupplierMapper();
        private static readonly SupplierPropertyValueMapper s_supplierPropertyValueMapper = new SupplierPropertyValueMapper();
        private static readonly SupplierTagMapper s_supplierTagMapper = new SupplierTagMapper();
        private static readonly PurchaseInvoiceMapper s_purchaseInvoiceMapper = new PurchaseInvoiceMapper();
        private static readonly PurchaseInvoiceDocumentMapper s_purchaseInvoiceDocumentMapper = new PurchaseInvoiceDocumentMapper();
        private static readonly PurchaseInvoiceTagMapper s_purchaseInvoiceTagMapper = new PurchaseInvoiceTagMapper();
        private static readonly InboxDocumentMapper s_inboxDocumentMapper = new InboxDocumentMapper();

        internal static Types.PagedList<Article> ToDomain(this ArticleListWrapper value)
        {
            return s_articleMapper.ApiToDomain(value);
        }

        internal static Article ToDomain(this ArticleWrapper value)
        {
            return s_articleMapper.ApiToDomain(value);
        }

        internal static Api.Article ToApi(this Article value)
        {
            return s_articleMapper.DomainToApi(value);
        }

        internal static Types.PagedList<Unit> ToDomain(this UnitListWrapper value)
        {
            return s_unitMapper.ApiToDomain(value);
        }

        internal static Unit ToDomain(this UnitWrapper value)
        {
            return s_unitMapper.ApiToDomain(value);
        }

        internal static Api.Unit ToApi(this Unit value)
        {
            return s_unitMapper.DomainToApi(value);
        }

        internal static Account ToDomain(this AccountWrapper value)
        {
            return s_accountMapper.ApiToDomain(value);
        }

        internal static Tax ToDomain(this TaxWrapper value)
        {
            return new TaxMapper().ApiToDomain(value);
        }

        internal static Types.PagedList<Tax> ToDomain(this TaxListWrapper value)
        {
            return s_taxMapper.ApiToDomain(value);
        }

        internal static Api.Tax ToApi(this Tax value)
        {
            return s_taxMapper.DomainToApi(value);
        }

        internal static Api.Invoice ToApi(this Invoice value)
        {
            return s_invoiceMapper.DomainToApi(value);
        }

        internal static Invoice ToDomain(this InvoiceWrapper value)
        {
            return s_invoiceMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<Invoice> ToDomain(this InvoiceListWrapper value)
        {
            return s_invoiceMapper.ApiToDomain(value);
        }

        internal static Offer ToDomain(this OfferWrapper value)
        {
            return s_offerMapper.ApiToDomain(value);
        }

        internal static OfferItem ToDomain(this OfferItemWrapper value)
        {
            return s_offerItemMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<OfferItem> ToDomain(this OfferItemListWrapper value)
        {
            return s_offerItemMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<Offer> ToDomain(this OfferListWrapper value)
        {
            return s_offerMapper.ApiToDomain(value);
        }

        internal static Settings ToDomain(this SettingsWrapper value)
        {
            return s_settingsMapper.ApiToDomain(value);
        }

        internal static Api.InvoiceItem ToApi(this InvoiceItem value)
        {
            return s_invoiceItemMapper.DomainToApi(value);
        }

        internal static Types.PagedList<InvoiceItem> ToDomain(this InvoiceItemListWrapper value)
        {
            return s_invoiceItemMapper.ApiToDomain(value);
        }

        internal static InvoiceItem ToDomain(this InvoiceItemWrapper value)
        {
            return s_invoiceItemMapper.ApiToDomain(value);
        }

        internal static InvoiceDocument ToDomain(this InvoiceDocumentWrapper value)
        {
            return s_invoiceDocumentMapper.ApiToDomain(value);
        }

        internal static PurchaseInvoiceDocument ToDomain(this IncomingDocumentWrapper value)
        {
            return s_purchaseInvoiceDocumentMapper.ApiToDomain(value);
        }

        internal static OfferDocument ToDomain(this OfferDocumentWrapper value)
        {
            return s_offerDocumentMapper.ApiToDomain(value);
        }

        internal static Api.InvoiceMail ToApi(this InvoiceMail value)
        {
            return s_invoiceMailMapper.DomainToApi(value);
        }

        internal static Api.Attachment ToApi(this Attachment value)
        {
            return s_invoiceMailMapper.DomainToApi(value);
        }

        internal static Types.PagedList<InvoiceComment> ToDomain(this InvoiceCommentListWrapper value)
        {
            return s_invoiceCommentMapper.ApiToDomain(value);
        }

        internal static InvoiceComment ToDomain(this InvoiceCommentWrapper value)
        {
            return s_invoiceCommentMapper.ApiToDomain(value);
        }

        internal static Api.InvoiceComment ToApi(this InvoiceComment value)
        {
            return s_invoiceCommentMapper.DomainToApi(value);
        }
        internal static Types.PagedList<InvoicePayment> ToDomain(this InvoicePaymentListWrapper value)
        {
            return s_invoicePaymentMapper.ApiToDomain(value);
        }

        internal static InvoicePayment ToDomain(this InvoicePaymentWrapper value)
        {
            return s_invoicePaymentMapper.ApiToDomain(value);
        }

        internal static Api.InvoicePayment ToApi(this InvoicePayment value)
        {
            return s_invoicePaymentMapper.DomainToApi(value);
        }


        internal static Types.PagedList<TagCloudItem> ToDomain(this InvoiceTagCloudItemListWrapper value)
        {
            return s_invoiceTagMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<TagCloudItem> ToDomain(this InvoiceTagCloudItemList value)
        {
            return s_invoiceTagMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<InvoiceTag> ToDomain(this InvoiceTagListWrapper value)
        {
            return s_invoiceTagMapper.ApiToDomain(value);
        }

        internal static InvoiceTag ToDomain(this InvoiceTagWrapper value)
        {
            return s_invoiceTagMapper.ApiToDomain(value);
        }

        internal static Api.InvoiceTag ToApi(this InvoiceTag value)
        {
            return s_invoiceTagMapper.DomainToApi(value);
        }

        internal static Types.PagedList<TagCloudItem> ToDomain(this IncomingTagCloudItemListWrapper value)
        {
            return s_purchaseInvoiceTagMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<TagCloudItem> ToDomain(this IncomingTagCloudItemList value)
        {
            return s_purchaseInvoiceTagMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<PurchaseInvoiceTag> ToDomain(this IncomingTagListWrapper value)
        {
            return s_purchaseInvoiceTagMapper.ApiToDomain(value);
        }

        internal static PurchaseInvoiceTag ToDomain(this IncomingTagWrapper value)
        {
            return s_purchaseInvoiceTagMapper.ApiToDomain(value);
        }

        internal static Api.IncomingTag ToApi(this PurchaseInvoiceTag value)
        {
            return s_purchaseInvoiceTagMapper.DomainToApi(value);
        }

        internal static Types.PagedList<Contact> ToDomain(this ContactListWrapper value)
        {
            return s_contactMapper.ApiToDomain(value);
        }

        internal static Contact ToDomain(this ContactWrapper value)
        {
            return s_contactMapper.ApiToDomain(value);
        }

        internal static Api.Contact ToApi(this Contact value)
        {
            return s_contactMapper.DomainToApi(value);
        }

        internal static ArticleProperty ToDomain(this ArticlePropertyWrapper value)
        {
            return s_articlePropertyMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<ArticleProperty> ToDomain(this ArticlePropertyListWrapper value)
        {
            return s_articlePropertyMapper.ApiToDomain(value);
        }

        internal static Api.ArticleProperty ToApi(this ArticleProperty value)
        {
            return s_articlePropertyMapper.DomainToApi(value);
        }

        internal static Types.PagedList<TagCloudItem> ToDomain(this ArticleTagCloudItemList value)
        {
            return s_articleTagMapper.ApiToDomain(value);
        }

        internal static ArticleTag ToDomain(this ArticleTagWrapper value)
        {
            return s_articleTagMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<TagCloudItem> ToDomain(this ArticleTagCloudItemListWrapper value)
        {
            return s_articleTagMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<ArticleTag> ToDomain(this ArticleTagListWrapper value)
        {
            return s_articleTagMapper.ApiToDomain(value);
        }

        internal static Api.ArticleTag ToApi(this ArticleTag value)
        {
            return s_articleTagMapper.DomainToApi(value);
        }

        internal static Types.PagedList<Client> ToDomain(this ClientListWrapper value)
        {
            return s_clientMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<Supplier> ToDomain(this SupplierListWrapper value)
        {
            return s_supplierMapper.ApiToDomain(value);
        }

        internal static Types.InboxDocument ToDomain(this InboxDocumentWrapper value)
        {
            return s_inboxDocumentMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<Types.InboxDocument> ToDomain(this InboxDocumentListWrapper value)
        {
            return s_inboxDocumentMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<PurchaseInvoice> ToDomain(this IncomingListWrapper value)
        {
            return s_purchaseInvoiceMapper.ApiToDomain(value);
        }

        internal static Client ToDomain(this ClientWrapper value)
        {
            return s_clientMapper.ApiToDomain(value);
        }

        internal static Api.Client ToApi(this Client value)
        {
            return s_clientMapper.DomainToApi(value);
        }

        internal static Types.PagedList<TagCloudItem> ToDomain(this ClientTagCloudItemListWrapper value)
        {
            return s_clientTagMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<TagCloudItem> ToDomain(this ClientTagCloudItemList value)
        {
            return s_clientTagMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<ClientTag> ToDomain(this ClientTagListWrapper value)
        {
            return s_clientTagMapper.ApiToDomain(value);
        }

        internal static ClientTag ToDomain(this ClientTagWrapper value)
        {
            return s_clientTagMapper.ApiToDomain(value);
        }

        internal static Api.ClientTag ToApi(this ClientTag value)
        {
            return s_clientTagMapper.DomainToApi(value);
        }

        internal static Types.PagedList<ClientProperty> ToDomain(this ClientPropertyListWrapper value)
        {
            return s_clientPropertyMapper.ApiToDomain(value);
        }

        internal static ClientProperty ToDomain(this ClientPropertyWrapper value)
        {
            return s_clientPropertyMapper.ApiToDomain(value);
        }

        internal static Api.ClientProperty ToApi(this ClientProperty value)
        {
            return s_clientPropertyMapper.DomainToApi(value);
        }

        internal static Supplier ToDomain(this SupplierWrapper value)
        {
            return s_supplierMapper.ApiToDomain(value);
        }

        internal static Api.Supplier ToApi(this Supplier value)
        {
            return s_supplierMapper.DomainToApi(value);
        }

        internal static PurchaseInvoice ToDomain(this IncomingWrapper value)
        {
            return s_purchaseInvoiceMapper.ApiToDomain(value);
        }

        internal static Api.Incoming ToApi(this PurchaseInvoice value)
        {
            return s_purchaseInvoiceMapper.DomainToApi(value);
        }

        internal static List<SupplierPropertyValue> ToDomain(this SupplierPropertyValuesWrapper value)
        {
            return s_supplierPropertyValueMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<TagCloudItem> ToDomain(this SupplierTagCloudItemListWrapper value)
        {
            return s_supplierTagMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<TagCloudItem> ToDomain(this SupplierTagCloudItemList value)
        {
            return s_supplierTagMapper.ApiToDomain(value);
        }

        internal static Types.PagedList<SupplierTag> ToDomain(this SupplierTagListWrapper value)
        {
            return s_supplierTagMapper.ApiToDomain(value);
        }

        internal static SupplierTag ToDomain(this SupplierTagWrapper value)
        {
            return s_supplierTagMapper.ApiToDomain(value);
        }

        internal static Api.SupplierTag ToApi(this SupplierTag value)
        {
            return s_supplierTagMapper.DomainToApi(value);
        }
    }
}
