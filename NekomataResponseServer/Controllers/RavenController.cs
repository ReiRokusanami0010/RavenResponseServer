﻿using System.Web;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using NekomataResponseServer.Schemes;
using NekomataResponseServer.Services;

namespace NekomataResponseServer.Controllers {
    [Route("api/Raven")]
    [ApiController]
    public class RavenController : Controller {
        private static MongoClient _mongoClient = new MongoClient($"mongodb://{Settings.User}:{Settings.Pass}@{Settings.ServerUrl}");
        
        [HttpGet("hololive/{channelName}")]
        public ActionResult<List<UpcomingScheme>> GetAllHololiveColl(string channelName) {
            return DataBaseService.GetDocuments(_mongoClient, "Hololive", channelName);
        }
        [HttpGet("nijisanji/{channelName}")]
        public ActionResult<List<UpcomingScheme>> GetAllNijisanjiColl(string channelName) {
            return DataBaseService.GetDocuments(_mongoClient, "Nijisanji", channelName);
        }
        [HttpGet("animare/{channelName}")]
        public ActionResult<List<UpcomingScheme>> GetAllAnimareColl(string channelName) {
            return DataBaseService.GetDocuments(_mongoClient, "animare", channelName);
        }

        [HttpGet("collections/{databaseName}")]
        public ActionResult<List<string>> GetAllCollectionNames(string databaseName) {
            return DataBaseService.GetCollectionNames(_mongoClient, databaseName);
        }
#if DEBUG
        [HttpGet("debug/{testMsg}/{deviceName}")]
        public ActionResult<string> GetSocketDevice(string testMsg, string deviceName) {
            return deviceName == null 
                ? "Undefined DeviceName"
                : $"TestMsg : {testMsg}" + "\n" + $"Device : {deviceName}";
        }
#endif
    }
}