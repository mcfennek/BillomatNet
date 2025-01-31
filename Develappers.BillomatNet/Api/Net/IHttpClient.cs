﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Develappers.BillomatNet.Api.Net
{
    public interface IHttpClient
    {
        /// <summary>
        /// Makes GET web request to specific URL.
        /// </summary>
        /// <param name="relativeUri">The specific URI.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the request result from the stream.
        /// </returns>
        /// <exception cref="IOException"> Throws when the response was null.</exception>
        Task<byte[]> GetBytesAsync(Uri relativeUri, CancellationToken token = default);

        /// <summary>
        /// Makes a GET web request to specific URL.
        /// </summary>
        /// <param name="relativeUri">The specific URI.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the request result from the stream.
        /// </returns>
        Task<string> GetAsync(Uri relativeUri, CancellationToken token = default);

        /// <summary>
        /// Makes GET web request with filter to specific URL
        /// </summary>
        /// <param name="relativeUri">The specific URI.</param>
        /// <param name="query">The filter.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the request result from the stream.
        /// </returns>
        /// <exception cref="IOException"> Throws when the response was null.</exception>
        Task<string> GetAsync(Uri relativeUri, string query, CancellationToken token = default);

        /// <summary>
        /// Makes DELETE web request.
        /// </summary>
        /// <param name="relativeUri">The specific URI.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the request from the stream.
        /// </returns>
        /// <exception cref="IOException"> Throws when the response was null.</exception>
        Task<string> DeleteAsync(Uri relativeUri, CancellationToken token);

        /// <summary>
        /// Makes PUT web request.
        /// </summary>
        /// <param name="relativeUri">The specific URI.</param>
        /// <param name="data">The data to be sent to the server.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the request result from the stream.
        /// </returns>
        /// <exception cref="IOException"> Throws when the response was null.</exception>
        Task<string> PutAsync(Uri relativeUri, string data, CancellationToken token);

        /// <summary>
        /// Makes POST web request.
        /// </summary>
        /// <param name="relativeUri">The specific URI.</param>
        /// <param name="data">The data to be sent to the server.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the request result from the stream.
        /// </returns>
        /// <exception cref="IOException"> Throws when the response was null.</exception>
        Task<string> PostAsync(Uri relativeUri, string data, CancellationToken token);

        /// <summary>
        /// The billomat instance url.
        /// </summary>
        string BaseUrl { get; }

        /// <summary>
        /// The call limit for the current user.
        /// </summary>
        int ApiCallLimit { get; }

        /// <summary>
        /// The point in time when the call limit resets.
        /// </summary>
        DateTime ApiCallLimitResetsAt { get; }
    }
}
