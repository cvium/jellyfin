using System.IO;
using System.Threading.Tasks;
using System.Net.Http;

namespace MediaBrowser.Common.Net
{
    /// <summary>
    /// Interface IHttpClient
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>Task{HttpResponseInfo}.</returns>
        Task<HttpResponseInfo> GetResponse(HttpRequestOptions options);

        /// <summary>
        /// Gets the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>Task{Stream}.</returns>
        Task<Stream> Get(HttpRequestOptions options);

        /// <summary>
        /// Warning: Deprecated function,
        /// use 'Task<HttpResponseInfo> SendAsync(HttpRequestOptions options, HttpMethod httpMethod);' instead
        /// Sends the asynchronous.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <returns>Task{HttpResponseInfo}.</returns>
        Task<HttpResponseInfo> SendAsync(HttpRequestOptions options, string httpMethod);

        /// <summary>
        /// Sends the asynchronous.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <returns>Task{HttpResponseInfo}.</returns>
        Task<HttpResponseInfo> SendAsync(HttpRequestOptions options, HttpMethod httpMethod);

        /// <summary>
        /// Posts the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>Task{HttpResponseInfo}.</returns>
        Task<HttpResponseInfo> Post(HttpRequestOptions options);

        /// <summary>
        /// Downloads the contents of a given url into a temporary location
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>Task{System.String}.</returns>
        /// <exception cref="System.ArgumentNullException">progress</exception>
        /// <exception cref="Model.Net.HttpException"></exception>
        Task<string> GetTempFile(HttpRequestOptions options);

        /// <summary>
        /// Gets the temporary file response.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>Task{HttpResponseInfo}.</returns>
        Task<HttpResponseInfo> GetTempFileResponse(HttpRequestOptions options);
    }
}
