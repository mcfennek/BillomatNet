﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace Develappers.BillomatNet.Queries
{
    /// <summary>
    /// Represents the filter for the client.
    /// </summary>
    public class ClientFilter
    {
        public string Name { get; set; }
        public string ClientNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryCode { get; set; }
        public string Note { get; set; }
        public string Customfield { get; set; }
        public List<int> InvoiceIds { get; set; }
        public List<string> Tags { get; set; }
    }
}
