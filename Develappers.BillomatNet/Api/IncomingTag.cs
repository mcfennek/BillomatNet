// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Newtonsoft.Json;

namespace Develappers.BillomatNet.Api
{
    internal class IncomingTag
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("incoming_id")]
        public int IncomingId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
