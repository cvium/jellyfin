using System.Threading.Tasks;
using MediaBrowser.Controller.Net;
using MediaBrowser.Model.Entities;
using MediaBrowser.Model.Globalization;
using ServiceStack;

namespace MediaBrowser.Api
{
    /// <summary>
    /// Class GetCultures
    /// </summary>
    [Route("/Localization/Cultures", "GET", Summary = "Gets known cultures")]
    public class GetCultures : Model.Services.IReturn<CultureDto[]>
    {
    }

    /// <summary>
    /// Class GetCountries
    /// </summary>
    [Route("/Localization/Countries", "GET", Summary = "Gets known countries")]
    public class GetCountries : Model.Services.IReturn<CountryInfo[]>
    {
    }

    /// <summary>
    /// Class ParentalRatings
    /// </summary>
    [Route("/Localization/ParentalRatings", "GET", Summary = "Gets known parental ratings")]
    public class GetParentalRatings : Model.Services.IReturn<ParentalRating[]>
    {
    }

    /// <summary>
    /// Class ParentalRatings
    /// </summary>
    [Route("/Localization/Options", "GET", Summary = "Gets localization options")]
    public class GetLocalizationOptions : Model.Services.IReturn<LocalizationOption[]>
    {
    }

    /// <summary>
    /// Class CulturesService
    /// </summary>
    [Authenticated(AllowBeforeStartupWizard = true)]
    public class LocalizationService : BaseApiService
    {
        /// <summary>
        /// The _localization
        /// </summary>
        private readonly ILocalizationManager _localization;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizationService"/> class.
        /// </summary>
        /// <param name="localization">The localization.</param>
        public LocalizationService(ILocalizationManager localization)
        {
            _localization = localization;
        }

        /// <summary>
        /// Gets the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>System.Object.</returns>
        public object Get(GetParentalRatings request)
        {
            var result = _localization.GetParentalRatings();

            return ToOptimizedResult(result);
        }

        public object Get(GetLocalizationOptions request)
        {
            var result = _localization.GetLocalizationOptions();

            return ToOptimizedResult(result);
        }

        /// <summary>
        /// Gets the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>System.Object.</returns>
        public async Task<object> Get(GetCountries request)
        {
            var result = await _localization.GetCountries();

            return ToOptimizedResult(result);
        }

        /// <summary>
        /// Gets the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>System.Object.</returns>
        public object Get(GetCultures request)
        {
            var result = _localization.GetCultures();

            return ToOptimizedResult(result);
        }
    }

}
