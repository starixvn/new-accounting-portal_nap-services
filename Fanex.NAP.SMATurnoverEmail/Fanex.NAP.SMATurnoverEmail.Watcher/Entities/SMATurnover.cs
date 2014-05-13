// --------------------------------------------------------------------------
// <copyright file="SMATurnover.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.9">Created</change>
// </history>

namespace Fanex.NAP.SMATurnoverEmail.Watcher.Entities
{
    using System;

    /// <summary>
    /// SMA Turnover entity contains data queried from DB.
    /// </summary>
    public class SMATurnover
    {
        public int SportType { get; set; }

        public int LeagueID { get; set; }

        public int MatchID { get; set; }

        public string MatchCode { get; set; }

        public int HomeID { get; set; }

        public int AwayID { get; set; }

        public DateTime? EventDate { get; set; }

        public int CustID { get; set; }

        public string Username { get; set; }

        public byte? RoldeID { get; set; }

        public string Currency { get; set; }

        public decimal? MaxTurnover { get; set; }

        public decimal? TotalTurnover { get; set; }

        public int PercentageUsed { get; set; }
    }
}