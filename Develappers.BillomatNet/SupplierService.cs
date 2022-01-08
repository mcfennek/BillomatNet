// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Develappers.BillomatNet.Api;
using Develappers.BillomatNet.Api.Net;
using Develappers.BillomatNet.Mapping;
using Develappers.BillomatNet.Queries;
using Develappers.BillomatNet.Types;
using Supplier = Develappers.BillomatNet.Types.Supplier;
using SupplierTag = Develappers.BillomatNet.Types.SupplierTag;

namespace Develappers.BillomatNet
{
    public class SupplierService : ServiceBase,
        IEntityService<Supplier, SupplierFilter>
    {
        private const string EntityUrlFragment = "suppliers";

        /// <summary>
        /// Creates a new instance of <see cref="SupplierService"/>.
        /// </summary>
        /// <param name="httpClient">The http client.</param>
        public SupplierService(IHttpClient httpClient) : base(httpClient)
        {
        }

        /// <summary>
        /// Retrieves a list of all clients.
        /// </summary>
        /// <param name="token">The cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the list of suppliers.
        /// </returns>
        public Task<Types.PagedList<Supplier>> GetListAsync(CancellationToken token = default)
        {
            return GetListAsync(null, token);
        }

        /// <summary>
        /// Retrieves a list of all suppliers.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the list of suppliers.
        /// </returns>
        public async Task<Types.PagedList<Supplier>> GetListAsync(Query<Supplier, SupplierFilter> query, CancellationToken token = default)
        {
            var jsonModel = await GetListAsync<SupplierListWrapper>($"/api/{EntityUrlFragment}", QueryString.For(query), token).ConfigureAwait(false);
            return jsonModel.ToDomain();
        }

        /// <summary>
        /// Retrieves an supplier by it's ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the supplier.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the parameter check fails.</exception>
        /// <exception cref="NotAuthorizedException">Thrown when not authorized to access this resource.</exception>
        /// <exception cref="NotFoundException">Thrown when the resource url could not be found.</exception>
        public async Task<Supplier> GetByIdAsync(int id, CancellationToken token = default)
        {
            if (id <= 0)
            {
                throw new ArgumentException("invalid supplier id", nameof(id));
            }

            var jsonModel = await GetItemByIdAsync<SupplierWrapper>($"/api/{EntityUrlFragment}/{id}", token).ConfigureAwait(false);
            return jsonModel.ToDomain();
        }

        /// <summary>
        /// Deletes the supplier with the given ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the parameter check fails.</exception>
        /// <exception cref="NotAuthorizedException">Thrown when not authorized to access this resource.</exception>
        /// <exception cref="NotFoundException">Thrown when the resource url could not be found.</exception>
        public Task DeleteAsync(int id, CancellationToken token = default)
        {
            if (id <= 0)
            {
                throw new ArgumentException("invalid client id", nameof(id));
            }
            return DeleteAsync($"/api/{EntityUrlFragment}/{id}", token);
        }

        /// <summary>
        /// Updates the specified supplier.
        /// </summary>
        /// <param name="value">The supplier.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the updated supplier.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the parameter check fails.</exception>
        /// <exception cref="NotAuthorizedException">Thrown when not authorized to access this resource.</exception>
        /// <exception cref="NotFoundException">Thrown when the resource url could not be found.</exception>
        public async Task<Supplier> EditAsync(Supplier value, CancellationToken token = default)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.Id <= 0)
            {
                throw new ArgumentException("invalid client id", nameof(value));
            }

            var wrappedModel = new SupplierWrapper
            {
                Supplier = value.ToApi()
            };

            var jsonModel = await PutAsync($"/api/{EntityUrlFragment}/{value.Id}", wrappedModel, token);
            return jsonModel.ToDomain();
        }

        /// <summary>
        /// Creates a supplier.
        /// </summary>
        /// <param name="value">The supplier to create.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the new supplier.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the parameter check fails.</exception>
        /// <exception cref="NotAuthorizedException">Thrown when not authorized to access this resource.</exception>
        /// <exception cref="NotFoundException">Thrown when the resource url could not be found.</exception>
        public async Task<Supplier> CreateAsync(Supplier value, CancellationToken token = default)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (value.Id != 0)
            {
                throw new ArgumentException("invalid supplier id", nameof(value));
            }

            var wrappedModel = new SupplierWrapper
            {
                Supplier = value.ToApi()
            };

            var jsonModel = await PostAsync($"/api/{EntityUrlFragment}", wrappedModel, token).ConfigureAwait(false);
            return jsonModel.ToDomain();
        }

        /// <summary>
        /// Creates a supplier tag.
        /// </summary>
        /// <param name="value">The supplier tag.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result returns the newly created supplier tag with the ID.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the parameter check fails.</exception>
        /// <exception cref="NotAuthorizedException">Thrown when not authorized to access this resource.</exception>
        /// <exception cref="NotFoundException">Thrown when the resource url could not be found.</exception>
        public async Task<SupplierTag> CreateTagAsync(SupplierTag value, CancellationToken token = default)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (value.SupplierId == 0 || string.IsNullOrEmpty(value.Name) || value.Id != 0)
            {
                throw new ArgumentException("invalid property values for supplier tag", nameof(value));
            }
            var wrappedModel = new SupplierTagWrapper
            {
                SupplierTag = value.ToApi()
            };
            try
            {
                var result = await PostAsync("/api/supplier-tags", wrappedModel, token);
                return result.ToDomain();
            }
            catch (WebException wex)
                when (wex.Status == WebExceptionStatus.ProtocolError && (wex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException("wrong input parameter", nameof(value), wex);
            }
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
                throw new ArgumentException("invalid supplier id", nameof(id));
            }

            return $"{HttpClient.BaseUrl}app/{EntityUrlFragment}/show/entityId/{id}";
        }
    }
}
