// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Develappers.BillomatNet.Types
{
    /// <summary>
    /// Represents a purchase invoice tag.
    /// </summary>
    public class PurchaseInvoiceTag
    {
        public int Id { get; set; }
        public int PurchaseInvoiceId { get; set; }
        public string Name { get; set; }
    }
}