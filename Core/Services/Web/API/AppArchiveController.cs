﻿using Newtonsoft.Json;
using NLog;
using Symbiote.Core.App;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace Symbiote.Core.Services.Web.API
{
    /// <summary>
    /// Handles the API methods for AppArchives.
    /// </summary>
    public class AppArchiveController : ApiController
    {
        #region Variables

        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private ProgramManager manager = ProgramManager.Instance();

        /// <summary>
        /// The Logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The default serialization properties for an AppArchive.
        /// </summary>
        private static List<string> appArchiveSerializationProperties = new List<string>(new string[] { "FQN", "FileName", "Version", "AppType", "ConfigurationDefinition" });

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns the list of available AppArchives.
        /// </summary>
        /// <returns>The list of available AppArchives.</returns>
        [Route("api/apparchive")]
        [HttpGet]
        public HttpResponseMessage ListAppArchives()
        {
            APIOperationResult<List<AppArchive>> retVal = new APIOperationResult<List<AppArchive>>(Request);
            retVal.LogRequest(logger);

            retVal.Result = manager.AppManager.AppArchives;

            retVal.LogResult(logger);
            return retVal.CreateResponse(JsonFormatter(appArchiveSerializationProperties, ContractResolverType.OptIn, true));
        }

        /// <summary>
        /// Reloads the list of AppArchives from disk and returns the list.
        /// </summary>
        /// <returns>The reloaded list of available AppArchives.</returns>
        [Route("api/apparchive/reload")]
        [HttpGet]
        public HttpResponseMessage ReloadAppArchives()
        {
            APIOperationResult<OperationResult<List<AppArchive>>> retVal = new APIOperationResult<OperationResult<List<AppArchive>>>(Request);
            retVal.LogRequest(logger);

            retVal.Result = manager.AppManager.ReloadAppArchives();

            if (retVal.Result.ResultCode == OperationResultCode.Failure)
                retVal.StatusCode = HttpStatusCode.InternalServerError;

            retVal.LogResult(logger);
            return retVal.CreateResponse(JsonFormatter(appArchiveSerializationProperties, ContractResolverType.OptIn, true));
        }

        /// <summary>
        /// Returns the AppArchive from the list of available AppArchives that matches the supplied FQN.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the AppArchive to return.</param>
        /// <returns>The matching AppArchive.</returns>
        [Route("api/apparchive/{fqn}")]
        [HttpGet]
        public HttpResponseMessage GetAppArchive(string fqn)
        {
            APIOperationResult<AppArchive> retVal = new APIOperationResult<AppArchive>(Request);
            retVal.LogRequest(logger);

            retVal.Result = manager.AppManager.FindAppArchive(fqn);

            if (retVal.Result == default(AppArchive))
                retVal.StatusCode = HttpStatusCode.NotFound;

            retVal.LogResult(logger);
            return retVal.CreateResponse(JsonFormatter(new List<string>(new string[] { }), ContractResolverType.OptOut, true));
        }

        /// <summary>
        /// Installs the supplied AppArchive.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the AppArchive to install.</param>
        /// <returns>The App instance resulting from the installation.</returns>
        [Route("api/apparchive/{fqn}/install")]
        [HttpGet]
        public async Task<HttpResponseMessage> InstallApp(string fqn)
        {
            APIOperationResult<OperationResult<App.App>> retVal = new APIOperationResult<OperationResult<App.App>>(Request);
            retVal.LogRequest(logger);

            if (manager.AppManager.InstallInProgress)
                retVal.Result = new OperationResult<App.App>().AddError("Another install is already in progress.");
            else
                retVal.Result = await manager.AppManager.InstallAppAsync(fqn);

            if ((retVal.Result == default(OperationResult<App.App>)) || (retVal.Result.ResultCode == OperationResultCode.Failure))
                retVal.StatusCode = HttpStatusCode.InternalServerError;

            retVal.LogResult(logger);
            return retVal.CreateResponse(JsonFormatter(new List<string>(new string[] { }), ContractResolverType.OptOut, true));
        }

        [Route("api/apparchive/{fqn}/download")]
        [HttpGet]
        public HttpResponseMessage DownloadAppArchive(string fqn)
        {
            string appArchive = System.IO.Path.Combine(manager.InternalSettings.AppDirectory, manager.AppManager.FindAppArchive(fqn).FileName);

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);

            result.Content = new StreamContent(new System.IO.FileStream(appArchive, System.IO.FileMode.Open));
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = System.IO.Path.GetFileName(appArchive) };

            return result;
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Returns the JsonMediaTypeFormatter to use with this controller.
        /// </summary>
        /// <param name="serializationProperties">A list of properties to exclude or include, depending on the ContractResolverType, in the serialized result.</param>
        /// <param name="contractResolverType">A ContractResolverType representing the desired behavior of serializationProperties, OptIn or OptOut.</param>
        /// <param name="includeSecondaryTypes">True if secondary types, such as those loaded from Plugins, should be included in the serialization.</param>
        /// <returns>A configured instance of JsonMediaTypeFormatter</returns>
        private static JsonMediaTypeFormatter JsonFormatter(List<string> serializationProperties, ContractResolverType contractResolverType, bool includeSecondaryTypes = false)
        {
            JsonMediaTypeFormatter retVal = new JsonMediaTypeFormatter();

            retVal.SerializerSettings = new JsonSerializerSettings();

            retVal.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            retVal.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            retVal.SerializerSettings.Formatting = Formatting.Indented;
            retVal.SerializerSettings.ContractResolver = new ContractResolver(serializationProperties, contractResolverType, includeSecondaryTypes);
            retVal.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

            return retVal;
        }

        #endregion
    }
}