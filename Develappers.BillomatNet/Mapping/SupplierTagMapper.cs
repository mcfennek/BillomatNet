// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq;
using Develappers.BillomatNet.Api;
using SupplierTag = Develappers.BillomatNet.Types.SupplierTag;
using TagCloudItem = Develappers.BillomatNet.Types.TagCloudItem;

namespace Develappers.BillomatNet.Mapping
{
    internal class SupplierTagMapper : IMapper<Api.SupplierTag, SupplierTag>
    {
        public SupplierTag ApiToDomain(Api.SupplierTag value)
        {
            if (value == null)
            {
                return null;
            }

            return new SupplierTag
            {
                Id = value.Id,
                SupplierId = value.SupplierId,
                Name = value.Name
            };
        }

        public Api.SupplierTag DomainToApi(SupplierTag value)
        {
            if (value == null)
            {
                return null;
            }
            return new Api.SupplierTag
            {
                Id = value.Id,
                SupplierId = value.SupplierId,
                Name = value.Name
            };
        }

        public SupplierTag ApiToDomain(SupplierTagWrapper value)
        {
            return ApiToDomain(value?.SupplierTag);
        }

        public Types.PagedList<SupplierTag> ApiToDomain(SupplierTagList value)
        {
            if (value == null)
            {
                return null;
            }

            return new Types.PagedList<SupplierTag>
            {
                Page = value.Page,
                ItemsPerPage = value.PerPage,
                TotalItems = value.Total,
                List = value.List?.Select(ApiToDomain).ToList()
            };
        }

        public Types.PagedList<SupplierTag> ApiToDomain(SupplierTagListWrapper value)
        {
            return ApiToDomain(value?.Item);
        }

        public Types.PagedList<TagCloudItem> ApiToDomain(SupplierTagCloudItemListWrapper value)
        {
            return value?.Item.ToDomain();
        }

        public Types.PagedList<TagCloudItem> ApiToDomain(SupplierTagCloudItemList value)
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
    }
}
