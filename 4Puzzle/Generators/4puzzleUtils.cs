﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.Storage.Streams;
using Windows.System.Profile;

namespace _4Puzzle.Generators {
    class _4puzzleUtils {

        class Score {
            public string Name { get; set; }
            public string PlayerScore { get; set; }
            public string DateTime { get; set; }
            public string GameType { get; set; }
            public string PhoneGuid { get; set; }
        }

        public static string FilterName(string name) {
            if (name == null)
                return null;

            return Regex.Replace(name, "[^A-Za-z0-9_]", "");
        }

        static List<Score> GetScoreList() {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            object scoresObject = localSettings.Values["PlayerOfflineScores"];

            List<Score> scoreList = new List<Score>();
            if (scoresObject != null) {
                scoreList = JsonConvert.DeserializeObject<List<Score>>(scoresObject.ToString());
            }
            return scoreList;
        }

        static void SaveScoreList(List<Score> scoreList) {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["PlayerOfflineScores"] = scoreList != null ? JsonConvert.SerializeObject(scoreList) : null;
        }

        public static void SaveScoreOffline(string name, string gameType, string score) {
            List<Score> scoreList = GetScoreList();

            scoreList.Add(new Score() {
                Name = FilterName(name),
                PlayerScore = score,
                GameType = gameType,
                DateTime = DateTime.Now.ToString(),
                PhoneGuid = GetDeviceID()
            });

            SaveScoreList(scoreList);
        }

        public static void TrySendOfflineScore() {
            if (!(NetworkInterface.GetIsNetworkAvailable()))
                return;

            List<Score> scoreList = GetScoreList();
            foreach (Score score in scoreList) {
                if (score.Name == null)
                    HttpRequestUtils.InsertStatistics(score.PhoneGuid, score.GameType, score.DateTime);
                if (score.Name != null)
                    HttpRequestUtils.InsertHighScore(score.Name.ToString(), score.GameType, score.PlayerScore);
            }

            SaveScoreList(new List<Score>());
        }
        static string GetDeviceID() {
            HardwareToken token = HardwareIdentification.GetPackageSpecificToken(null);
            IBuffer hardwareId = token.Id;

            HashAlgorithmProvider hasher = HashAlgorithmProvider.OpenAlgorithm("MD5");
            IBuffer hashed = hasher.HashData(hardwareId);

            string hashedString = CryptographicBuffer.EncodeToHexString(hashed);
            return hashedString;
        }
    }
}
