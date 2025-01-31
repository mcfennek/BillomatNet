﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Develappers.BillomatNet.Api.Json;
using Newtonsoft.Json;

namespace Develappers.BillomatNet.Api
{
    internal class IncomingTagCloudItemList : PagedList<TagCloudItem>
    {
        [JsonProperty("incoming-tag")]
        [JsonConverter(typeof(CollectionConverter<TagCloudItem>))]
        public override List<TagCloudItem> List { get; set; }
    }
}