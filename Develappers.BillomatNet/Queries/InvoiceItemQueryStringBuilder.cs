// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Web;
using Develappers.BillomatNet.Mapping;
using Develappers.BillomatNet.Types;

namespace Develappers.BillomatNet.Queries
{
    internal class InvoiceItemQueryStringBuilder : QueryStringBuilder<InvoiceItem, Api.InvoiceItem, InvoiceItemFilter>
    {
        protected internal override string GetFilterStringFor(InvoiceItemFilter filter)
        {
            if (filter == null)
            {
                return string.Empty;
            }

            var filters = new List<string>();

            if (filter.InvoiceId.HasValue)
            {
                filters.Add($"invoice_id={filter.InvoiceId.Value}");
            }

            if (filter.Position.HasValue)
            {
                filters.Add($"position={filter.Position.Value}");
            }

            if (!string.IsNullOrEmpty(filter.Title))
            {
                filters.Add($"title={HttpUtility.UrlEncode(filter.Title)}");
            }

            if (!string.IsNullOrEmpty(filter.Description))
            {
                filters.Add($"description={HttpUtility.UrlEncode(filter.Description)}");
            }

            if (!string.IsNullOrEmpty(filter.Customfield))
            {
                filters.Add($"customfield={HttpUtility.UrlEncode(filter.Customfield)}");
            }

            return string.Join("&", filters);
        }
    }
}
