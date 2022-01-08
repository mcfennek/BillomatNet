// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Globalization;
using System.Linq;
using Develappers.BillomatNet.Api;
using Develappers.BillomatNet.Types;
using TagCloudItem = Develappers.BillomatNet.Types.TagCloudItem;

namespace Develappers.BillomatNet.Mapping
{
    internal class PurchaseInvoiceTagMapper : IMapper<Api.IncomingTag, PurchaseInvoiceTag>
    {
        public Types.PagedList<PurchaseInvoiceTag> ApiToDomain(IncomingTagListWrapper value)
        {
            return ApiToDomain(value?.Item);
        }

        internal Types.PagedList<PurchaseInvoiceTag> ApiToDomain(IncomingTagList value)
        {
            if (value == null)
            {
                return null;
            }

            return new Types.PagedList<PurchaseInvoiceTag>
            {
                Page = value.Page,
                ItemsPerPage = value.PerPage,
                TotalItems = value.Total,
                List = value.List?.Select(ApiToDomain).ToList()
            };
        }

        public Types.PagedList<TagCloudItem> ApiToDomain(IncomingTagCloudItemListWrapper value)
        {
            return value?.Item.ToDomain();
        }

        public Types.PagedList<TagCloudItem> ApiToDomain(IncomingTagCloudItemList value)
        {
            if (value == null)
            {
                return null;
            }

            return new Types.PagedList<TagCloudItem>
            {
                Page = value.Page,
                ItemsPerPage = value.PerPage,
                TotalItems = value.Total,
                List = value.List?.Select(x => x.ToDomain()).ToList()
            };
        }

        public PurchaseInvoiceTag ApiToDomain(IncomingTagWrapper value)
        {
            return ApiToDomain(value?.IncomingTag);
        }

        public PurchaseInvoiceTag ApiToDomain(Api.IncomingTag value)
        {
            if (value == null)
            {
                return null;
            }

            return new PurchaseInvoiceTag
            {
                Id = value.Id,
                PurchaseInvoiceId = value.IncomingId,
                Name = value.Name
            };
        }

        public Api.IncomingTag DomainToApi(PurchaseInvoiceTag value)
        {
            if (value == null)
            {
                return null;
            }

            return new Api.IncomingTag
            {
                Id = value.Id,
                IncomingId = value.PurchaseInvoiceId,
                Name = value.Name
            };
        }
    }
}
