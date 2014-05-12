// --------------------------------------------------------------------------
// <copyright file="CacheRef.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.9">Created</change>
// </history>

namespace Fanex.NAP.SMATurnoverEmail.Watcher.Helpers
{
    using Fanex.Common;
    using RemotingRef;

    /// <summary>
    /// Caching remote data.
    /// </summary>
    public static class CacheRef
    {
        /// <summary>
        /// Gets sport name by ID.
        /// </summary>
        /// <param name="sportID">Sport ID value.</param>
        /// <returns>Sport name.</returns>
        public static string GetSportName(object sportID)
        {
            return RefData.GetSportName(Converter.ToString2(sportID), TWLang("en-US"), string.Empty);
        }

        /// <summary>
        /// Gets team name.
        /// </summary>
        /// <param name="teamID">Team ID value.</param>
        /// <returns>Team name.</returns>
        public static string GetTeamName(object teamID)
        {
            return RefData.GetTeamName(Converter.ToString2(teamID), TWLang("en-US"), string.Empty);
        }

        /// <summary>
        /// Gets league name by ID.
        /// </summary>
        /// <param name="leagueID">League ID.</param>
        /// <returns>League name.</returns>
        public static string GetLeagueName(object leagueID)
        {
            return RefData.GetLeagueName(Converter.ToString2(leagueID), TWLang("en-US"), string.Empty);
        }

        /// <summary>
        /// Gets the customer level.
        /// </summary>
        /// <param name="roleID">The role identifier.</param>
        /// <returns>The level name.</returns>
        public static string GetCustomerLevel(byte? roleID)
        {
            var level = string.Empty;

            if (roleID.HasValue)
            {
                switch (roleID.Value)
                {
                    case 4:
                        level = "Super";
                        break;

                    case 3:
                        level = "Master";
                        break;

                    case 2:
                        level = "Agent";
                        break;

                    case 1:
                        level = "Member";
                        break;
                }
            }

            return level;
        }

        /// <summary>
        /// Gets language ID.
        /// </summary>
        /// <param name="lang">Language string.</param>
        /// <returns>Language ID.</returns>
        private static string TWLang(string lang)
        {
            switch (lang)
            {
                case "en-US": return "en"; // US English
                case "zh-TW": return "ch"; // Traditional
                case "zh-CN": return "cs"; // Simplified
                case "ja-JP": return "jp"; // Japanese
                case "th-TH": return "th"; // Thai
                default: return "en";
            }
        }
    }
}