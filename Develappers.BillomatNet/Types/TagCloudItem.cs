﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Develappers.BillomatNet.Types
{
    /// <summary>
    /// Represents the tag cloud item.
    /// </summary>
    public class TagCloudItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }
    }
}
