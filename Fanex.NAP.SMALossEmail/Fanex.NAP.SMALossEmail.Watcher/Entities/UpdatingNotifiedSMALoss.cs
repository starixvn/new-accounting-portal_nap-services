// --------------------------------------------------------------------------
// <copyright file="UpdatingNotifiedSMALoss.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.26">Created</change>
// </history>

namespace Fanex.NAP.SMALossEmail.Watcher.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Entity contains data that are needed for updating notification status.
    /// </summary>
    public class UpdatingNotifiedSMALoss
    {
        public UpdatingNotifiedSMALoss(IEnumerable<SMALoss> turnovers)
        {
            this.SMAIDs = string.Empty;

            if (turnovers != null && turnovers.Any())
            {
                foreach (SMALoss item in turnovers)
                {
                    this.SMAIDs += item.CustID + ",";
                }

                this.SMAIDs = this.SMAIDs.Remove(this.SMAIDs.Length - 1);
            }
        }

        public string SMAIDs { get; set; }

        public int ErrCode { get; set; }

        public string ErrMsg { get; set; }

        /// <summary>
        /// Determines whether this instance is valid.
        /// </summary>
        /// <returns>Boolean value.</returns>
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(this.SMAIDs);
        }
    }
}