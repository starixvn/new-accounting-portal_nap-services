// --------------------------------------------------------------------------
// <copyright file="FormattedSMATurnover.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.9">Created</change>
// </history>

namespace Fanex.NAP.SMATurnoverEmail.Watcher.Entities
{
    using Fanex.Common;
    using Fanex.NAP.SMATurnoverEmail.Watcher.Helpers;

    /// <summary>
    /// Formatted SMA Turnover which is used to bind with the template.
    /// </summary>
    public class FormattedSMATurnover
    {
        public FormattedSMATurnover(SMATurnover rawData)
        {
            if (rawData != null)
            {
                this.SportName = CacheRef.GetSportName(rawData.SportType);
                this.LeagueName = CacheRef.GetLeagueName(rawData.LeagueID);
                this.MatchID = rawData.MatchID;
                this.MatchCode = rawData.MatchCode;
                this.MatchName = string.Format("{0} vs. {1}", CacheRef.GetTeamName(rawData.HomeID), CacheRef.GetTeamName(rawData.AwayID));
                this.EventDate = Converter.ToDateTime(rawData.EventDate).FormatShortDate();
                this.CustID = rawData.CustID;
                this.Username = rawData.Username;
                this.Level = CacheRef.GetCustomerLevel(rawData.RoldeID);
                this.Currency = rawData.Currency;
                this.MaxTOAmount = Converter.ToDecimal(rawData.MaxTurnover).FormatDecimal();
                this.MemberTO = Converter.ToDecimal(rawData.TotalTurnover).FormatDecimal();
                this.PercentageUsed = rawData.PercentageUsed.FormatInteger();
            }
        }

        public string SportName { get; set; }

        public string LeagueName { get; set; }

        public int MatchID { get; set; }

        public string MatchCode { get; set; }

        public string MatchName { get; set; }

        public string EventDate { get; set; }

        public int CustID { get; set; }

        public string Username { get; set; }

        public string Level { get; set; }

        public string Currency { get; set; }

        public string MaxTOAmount { get; set; }

        public string MemberTO { get; set; }

        public string PercentageUsed { get; set; }
    }
}