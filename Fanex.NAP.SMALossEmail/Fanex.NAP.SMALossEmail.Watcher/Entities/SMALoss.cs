// --------------------------------------------------------------------------
// <copyright file="SMALoss.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.26">Created</change>
// </history>

namespace Fanex.NAP.SMALossEmail.Watcher.Entities
{
    using System;

    /// <summary>
    /// SMA Loss entity contains data queried from DB.
    /// </summary>
    public class SMALoss
    {
        public byte LevelID { get; set; }

        public int CustID { get; set; }

        public string Username { get; set; }

        public byte? RoleID { get; set; }

        public string Currency { get; set; }

        public decimal? YesterdayBalance { get; set; }

        public decimal? TotalBalance { get; set; }

        public decimal? MaxLoss { get; set; }

        public int? PercentageLoss { get; set; }

        public int? Movement { get; set; }
    }
}