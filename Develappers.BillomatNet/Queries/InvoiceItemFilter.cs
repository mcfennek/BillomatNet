﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using Develappers.BillomatNet.Types;

namespace Develappers.BillomatNet.Queries
{
    /// <summary>
    /// Represents the filter for the invoice item.
    /// </summary>
    public class InvoiceItemFilter
    {
        public int? InvoiceId { get; set; }
        public int? Position { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Customfield { get; set; }
    }
}
