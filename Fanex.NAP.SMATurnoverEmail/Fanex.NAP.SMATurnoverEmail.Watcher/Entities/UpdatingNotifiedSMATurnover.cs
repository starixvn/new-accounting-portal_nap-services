// --------------------------------------------------------------------------
// <copyright file="UpdatingNotifiedSMATurnover.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.12">Created</change>
// </history>

namespace Fanex.NAP.SMATurnoverEmail.Watcher.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Entity contains data that are needed for updating notification status.
    /// </summary>
    public class UpdatingNotifiedSMATurnover
    {
        public UpdatingNotifiedSMATurnover(IEnumerable<FormattedSMATurnover> turnovers)
        {
            this.MatchIDs = string.Empty;
            this.SMAIDs = string.Empty;

            if (turnovers != null && turnovers.Any())
            {
                foreach (FormattedSMATurnover item in turnovers)
                {
                    this.MatchIDs += item.MatchID + ",";
                    this.SMAIDs += item.CustID + ",";
                }

                this.MatchIDs = this.MatchIDs.Remove(this.MatchIDs.Length - 1);
                this.SMAIDs = this.SMAIDs.Remove(this.SMAIDs.Length - 1);
            }
        }

        public string MatchIDs { get; set; }

        public string SMAIDs { get; set; }

        public int ErrCode { get; set; }

        public string ErrMsg { get; set; }

        /// <summary>
        /// Determines whether this instance is valid.
        /// </summary>
        /// <returns>Boolean value.</returns>
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(this.MatchIDs) && !string.IsNullOrEmpty(this.SMAIDs);
        }
    }
}