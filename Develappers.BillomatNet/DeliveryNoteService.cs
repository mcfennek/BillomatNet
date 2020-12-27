﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using Develappers.BillomatNet.Api.Net;

namespace Develappers.BillomatNet
{
    public class DeliveryNoteService : ServiceBase
    {
        private readonly Configuration _configuration;
        private const string EntityUrlFragment = "deliverynotes";

        /// <summary>
        /// Creates a new instance of <see cref="DeliveryNoteService"/>.
        /// </summary>
        /// <param name="configuration">The service configuration.</param>
        public DeliveryNoteService(Configuration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Creates a new instance of <see cref="DeliveryNoteService"/> for unit tests.
        /// </summary>
        /// <param name="httpClientFactory">The function which creates a new <see cref="IHttpClient" /> implementation.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        internal DeliveryNoteService(Func<IHttpClient> httpClientFactory) : base(httpClientFactory)
        {
        }

        /// <summary>
        /// Gets the portal URL for this entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The url to this entity in billomat portal.</returns>
        /// <exception cref="ArgumentException">Thrown when the id is invalid.</exception>
        public string GetPortalUrl(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("invalid delivery note id", nameof(id));
            }

            return $"https://{_configuration.BillomatId}.billomat.net/app/{EntityUrlFragment}/show/entityId/{id}";
        }
    }
}
