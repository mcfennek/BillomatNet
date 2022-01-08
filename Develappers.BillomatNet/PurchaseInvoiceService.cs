// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Develappers.BillomatNet.Api;
using Develappers.BillomatNet.Api.Net;
using Develappers.BillomatNet.Mapping;
using Develappers.BillomatNet.Queries;
using Develappers.BillomatNet.Types;

namespace Develappers.BillomatNet
{
    public class PurchaseInvoiceService : ServiceBase,
        IEntityService<PurchaseInvoice, PurchaseInvoiceFilter>
    {
        private const string EntityUrlFragment = "incomings";

        /// <summary>
        /// Creates a new instance of <see cref="PurchaseInvoiceService"/>.
        /// </summary>
        /// <param name="httpClient">The http client.</param>
        public PurchaseInvoiceService(IHttpClient httpClient) : base(httpClient)
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
                throw new ArgumentException("invalid incoming invoice id", nameof(id));
            }

            return $"{HttpClient.BaseUrl}app/{EntityUrlFragment}/show/entityId/{id}";
        }

        /// <summary>
        /// Retrieves a list of all incoming invoices.
        /// </summary>
        /// <param name="token">The cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the list of incoming invoices.
        /// </returns>
        public Task<Types.PagedList<PurchaseInvoice>> GetListAsync(CancellationToken token = default)
        {
            return GetListAsync(null, token);
        }

        /// <summary>
        /// Retrieves a list of all incoming invoices.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the list of incoming invoices.
        /// </returns>
        public async Task<Types.PagedList<PurchaseInvoice>> GetListAsync(Query<PurchaseInvoice, PurchaseInvoiceFilter> query, CancellationToken token = default)
        {
            var jsonModel = await GetListAsync<IncomingListWrapper>($"/api/{EntityUrlFragment}", QueryString.For(query), token).ConfigureAwait(false);
            return jsonModel.ToDomain();
        }

        /// <summary>
        /// Retrieves an purchase invoice by it's ID.
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
        public async Task<PurchaseInvoice> GetByIdAsync(int id, CancellationToken token = default)
        {
            if (id <= 0)
            {
                throw new ArgumentException("invalid purchase invoice id", nameof(id));
            }

            var jsonModel = await GetItemByIdAsync<IncomingWrapper>($"/api/{EntityUrlFragment}/{id}", token).ConfigureAwait(false);
            return jsonModel.ToDomain();
        }

        /// <summary>
        /// Gets the PDF as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the purchase invoice document.
        /// </returns>
        public async Task<PurchaseInvoiceDocument> GetPdfAsync(int id, CancellationToken token = default)
        {
            var jsonModel = await GetItemByIdAsync<IncomingDocumentWrapper>($"/api/{EntityUrlFragment}/{id}/pdf", token).ConfigureAwait(false);
            return jsonModel.ToDomain();
        }


        /// <summary>
        /// Deletes the purchase invoice with the given ID.
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
                throw new ArgumentException("invalid purchase invoice id", nameof(id));
            }
            return DeleteAsync($"/api/{EntityUrlFragment}/{id}", token);
        }

        /// <summary>
        /// Updates the specified purchase invoice.
        /// </summary>
        /// <param name="value">The purchase invoice.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the updated purchase invoice.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the parameter check fails.</exception>
        /// <exception cref="NotAuthorizedException">Thrown when not authorized to access this resource.</exception>
        /// <exception cref="NotFoundException">Thrown when the resource url could not be found.</exception>
        public async Task<PurchaseInvoice> EditAsync(PurchaseInvoice value, CancellationToken token = default)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.Id <= 0)
            {
                throw new ArgumentException("invalid purchase invoice id", nameof(value));
            }

            var wrappedModel = new IncomingWrapper
            {
                Incoming = value.ToApi()
            };

            var jsonModel = await PutAsync($"/api/{EntityUrlFragment}/{value.Id}", wrappedModel, token);
            return jsonModel.ToDomain();
        }

        /// <summary>
        /// Creates a purchase invoice.
        /// </summary>
        /// <param name="value">The purchase invoice to create.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the new purchase invoice.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the parameter check fails.</exception>
        /// <exception cref="NotAuthorizedException">Thrown when not authorized to access this resource.</exception>
        /// <exception cref="NotFoundException">Thrown when the resource url could not be found.</exception>
        public async Task<PurchaseInvoice> CreateAsync(PurchaseInvoice value, CancellationToken token = default)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (value.Id != 0)
            {
                throw new ArgumentException("invalid client id", nameof(value));
            }

            var wrappedModel = new IncomingWrapper
            {
                Incoming = value.ToApi()
            };

            var jsonModel = await PostAsync($"/api/{EntityUrlFragment}", wrappedModel, token).ConfigureAwait(false);
            return jsonModel.ToDomain();
        }

        /// <summary>
        /// Retrieves an invoice tag by it's ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the invoice tag.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the parameter check fails.</exception>
        /// <exception cref="NotAuthorizedException">Thrown when not authorized to access this resource.</exception>
        /// <exception cref="NotFoundException">Thrown when the resource url could not be found.</exception>
        public async Task<PurchaseInvoiceTag> GetTagByIdAsync(int id, CancellationToken token = default)
        {
            if (id <= 0)
            {
                throw new ArgumentException("invalid purchase invoice tag id", nameof(id));
            }
            var jsonModel = await GetItemByIdAsync<IncomingTagWrapper>($"/api/invoice-tags/{id}", token).ConfigureAwait(false);
            return jsonModel.ToDomain();
        }

        /// <summary>
        /// Creates an incoming tag.
        /// </summary>
        /// <param name="value">The incoming tag.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result returns the newly created incoming tag with the ID.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the parameter check fails.</exception>
        /// <exception cref="NotAuthorizedException">Thrown when not authorized to access this resource.</exception>
        /// <exception cref="NotFoundException">Thrown when the resource url could not be found.</exception>
        public async Task<PurchaseInvoiceTag> CreateTagAsync(PurchaseInvoiceTag value, CancellationToken token = default)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (value.PurchaseInvoiceId == 0 || string.IsNullOrEmpty(value.Name) || value.Id != 0)
            {
                throw new ArgumentException("invalid property values for purchase invoice tag", nameof(value));
            }
            var wrappedModel = new IncomingTagWrapper
            {
                IncomingTag = value.ToApi()
            };
            try
            {
                var result = await PostAsync("/api/incoming-tags", wrappedModel, token);
                return result.ToDomain();
            }
            catch (WebException wex)
                when (wex.Status == WebExceptionStatus.ProtocolError && (wex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException("wrong input parameter", nameof(value), wex);
            }
        }

        /// <summary>
        /// Deletes an purchase invoice tag.
        /// </summary>
        /// <param name="id">The ID of the purchase invoice tag.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the parameter check fails.</exception>
        /// <exception cref="NotAuthorizedException">Thrown when not authorized to access this resource.</exception>
        /// <exception cref="NotFoundException">Thrown when the resource url could not be found.</exception>
        public Task DeleteTagAsync(int id, CancellationToken token = default)
        {
            if (id <= 0)
            {
                throw new ArgumentException("invalid purchase invoice tag id", nameof(id));
            }
            return DeleteAsync($"/api/incoming-tags/{id}", token);
        }
    }
}
