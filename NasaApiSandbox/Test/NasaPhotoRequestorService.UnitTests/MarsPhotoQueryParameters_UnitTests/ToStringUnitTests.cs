//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NasaMarsPhotos.DataService;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NasaMarsPhotosDataService.UnitTests.QueryParameters_UnitTests
//{
//    [TestClass]
//    public class ToStringUnitTests
//    {
//        protected const string dummyApiKey = "q3873hSRPvBKDyT6P2o30M0iHdMZO2sR";
//        protected MarsPhotoQueryParameters queryParamObj = new MarsPhotoQueryParameters()
//        {
//            Rover = MarsRoverEnum.Opportunity,
//            Camera = MarsRoverCameraEnum.MAST,
//            ApiKey = dummyApiKey,
//            MissionSol = 505
//        };

//        [TestMethod]
//        public void QueryParameters_ToString_Should_StartWithLeadingSlash()
//        {
//            const string expectedFragment = "/";
//            var actual = queryParamObj.ToString();
//            Assert.IsTrue(actual.StartsWith(expectedFragment));
//        }

//        [TestMethod]
//        public void QueryParameters_ToString_Should_UseRoverParam()
//        {
//            queryParamObj.Rover = MarsRoverEnum.Spirit;
//            const string expectedFragment = "spirit";
//            var actual = queryParamObj.ToString();
//            Assert.IsTrue(actual.Contains(expectedFragment));
//        }

//        [TestMethod]
//        public void QueryParameters_ToString_Should_UseCameraParam()
//        {
//            queryParamObj.Camera = MarsRoverCameraEnum.PANCAM;
//            const string expectedFragment = "&camera=pancam";
//            var actual = queryParamObj.ToString();
//            Assert.IsTrue(actual.Contains(expectedFragment));
//        }

//        [TestMethod]
//        public void QueryParameters_ToString_Should_UseApiKeyParam()
//        {
//            const string expectedFragment = "&api_key=" + dummyApiKey;
//            var actual = queryParamObj.ToString();
//            Assert.IsTrue(actual.Contains(expectedFragment));
//        }

//        [TestMethod]
//        public void QueryParameters_ToString_Should_UseSolParam()
//        {
//            queryParamObj.MissionSol = 101;
//            const string expectedFragment = "sol=101";
//            var actual = queryParamObj.ToString();
//            Assert.IsTrue(actual.Contains(expectedFragment));
//        }

//        [TestMethod]
//        public void QueryParameters_ToString_Should_UseEarthDateParam()
//        {
//            queryParamObj.EarthDate = new DateTime(2015, 4, 24);
//            const string expectedFragment = "earth_date=2015-4-24";
//            var actual = queryParamObj.ToString();
//            Assert.IsTrue(actual.Contains(expectedFragment));
//        }

//        [TestMethod]
//        public void QueryParameters_ToString_Should_IgnoreSolParamWhenEarthDateParamIsUsed()
//        {
//            queryParamObj.MissionSol = 101;
//            queryParamObj.EarthDate = new DateTime(2015, 11, 11);
//            const string marsDateFragment = "sol=101";
//            const string earthDateFragment = "earth_date=2015-11-11";
//            var actual = queryParamObj.ToString();
//            Assert.IsTrue(actual.Contains(earthDateFragment));
//            Assert.IsFalse(actual.Contains(marsDateFragment));
//        }

//        [TestMethod]
//        public void QueryParameters_ToString_WhenPageParamHasValue_Should_UsePageParam()
//        {
//            queryParamObj.Page = 10;
//            const string expectedFragment = "&page=10";
//            var actual = queryParamObj.ToString();
//            Assert.IsTrue(actual.Contains(expectedFragment));
//        }

//        [TestMethod]
//        public void QueryParameters_ToString_WhenPageParamValueIs1_Should_IgnorePageParam()
//        {
//            queryParamObj.Page = 1;
//            const string expectedFragment = "&page=1";
//            var actual = queryParamObj.ToString();
//            Assert.IsFalse(actual.Contains(expectedFragment));
//        }

//        [TestMethod]
//        public void QueryParameters_ToString_WhenUsingSol_Should_CombineAllParamsAsExpected()
//        {
//            queryParamObj = new MarsPhotoQueryParameters()
//            {
//                Rover = MarsRoverEnum.Curiosity,
//                Camera = MarsRoverCameraEnum.MARDI,
//                ApiKey = dummyApiKey,
//                MissionSol = 634
//            };
//            const string expected = "/curiosity/photos?sol=634&camera=mardi&api_key=" + dummyApiKey;
//            var actual = queryParamObj.ToString();
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void QueryParameters_ToString_WhenUsingEarthDate_Should_CombineAllParamsAsExpected()
//        {
//            queryParamObj = new MarsPhotoQueryParameters()
//            {
//                Rover = MarsRoverEnum.Curiosity,
//                Camera = MarsRoverCameraEnum.MARDI,
//                ApiKey = dummyApiKey,
//                EarthDate = new DateTime(2015, 4, 24),
//                Page = 3
//            };
//            const string expected = "/curiosity/photos?earth_date=2015-4-24&camera=mardi&page=3&api_key=" + dummyApiKey;
//            var actual = queryParamObj.ToString();
//            Assert.AreEqual(expected, actual);
//        }
//    }
//}