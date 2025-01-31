﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Develappers.BillomatNet.Api;
using Develappers.BillomatNet.Api.Net;
using Develappers.BillomatNet.Mapping;
using Develappers.BillomatNet.Queries;
using Offer = Develappers.BillomatNet.Types.Offer;
using OfferDocument = Develappers.BillomatNet.Types.OfferDocument;
using OfferItem = Develappers.BillomatNet.Types.OfferItem;

namespace Develappers.BillomatNet
{
    public class OfferService : ServiceBase, IEntityService<Offer, OfferFilter>
    {
        /// <summary>
        /// Creates a new instance of <see cref="OfferService"/>.
        /// </summary>
        /// <param name="httpClient">The http client.</param>
        public OfferService(IHttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<Offer> GetByIdAsync(int id, CancellationToken token = default)
        {
            var jsonModel = await GetItemByIdAsync<OfferWrapper>($"/api/offers/{id}", token).ConfigureAwait(false);
            return jsonModel.ToDomain();
        }

        public async Task<OfferDocument> GetPdfAsync(int id, CancellationToken token = default)
        {
            var jsonModel = await GetItemByIdAsync<OfferDocumentWrapper>($"/api/offers/{id}/pdf", token).ConfigureAwait(false);
            return jsonModel.ToDomain();
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
                throw new ArgumentException("invalid offer id", nameof(id));
            }

            return $"{HttpClient.BaseUrl}app/offers/show/entityId/{id}";
        }

        Task IEntityService<Offer, OfferFilter>.DeleteAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException("This service is not implemented by now. You can help us by contributing to our project on github.");
        }

        Task<Offer> IEntityService<Offer, OfferFilter>.CreateAsync(Offer model, CancellationToken token)
        {
            throw new NotImplementedException("This service is not implemented by now. You can help us by contributing to our project on github.");
        }

        Task<Offer> IEntityService<Offer, OfferFilter>.EditAsync(Offer model, CancellationToken token)
        {
            throw new NotImplementedException("This service is not implemented by now. You can help us by contributing to our project on github.");
        }

        /// <summary>
        /// Gets the list asynchronous.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the result of the requested page.
        /// </returns>
        public Task<Types.PagedList<Offer>> GetListAsync(CancellationToken token = default)
        {
            return GetListAsync(null, token);
        }

        /// <summary>
        /// Get list as an asynchronous operation.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the result of the requested page.
        /// </returns>
        public async Task<Types.PagedList<Offer>> GetListAsync(Query<Offer, OfferFilter> query, CancellationToken token = default)
        {
            var jsonModel = await GetListAsync<OfferListWrapper>("/api/offers", QueryString.For(query), token).ConfigureAwait(false);
            return jsonModel.ToDomain();
        }

        /// <summary>
        /// Returns and offer by it's ID.
        /// </summary>
        /// <param name="id">The ID of the offer.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the offer item.
        /// </returns>
        public async Task<OfferItem> GetItemByIdAsync(int id, CancellationToken token = default)
        {
            var jsonModel = await GetItemByIdAsync<OfferItemWrapper>($"/api/offer-items/{id}", token).ConfigureAwait(false);
            return jsonModel.ToDomain();
        }

        /// <summary>
        /// Retrieves a list of the items (articles) used in the offer.
        /// </summary>
        /// <param name="offerId">The ID of the invoice.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The invoice items list or null if not found.</returns>
        public async Task<Types.PagedList<OfferItem>> GetItemsAsync(int offerId, CancellationToken token = default)
        {
            var jsonModel = await GetListAsync<OfferItemListWrapper>("/api/offer-items", $"offer_id={offerId}", token).ConfigureAwait(false);
            return jsonModel.ToDomain();
        }
    }
}
