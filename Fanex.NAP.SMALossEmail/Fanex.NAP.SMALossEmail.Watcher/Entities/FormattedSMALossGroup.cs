// --------------------------------------------------------------------------
// <copyright file="FormattedSMALossGroup.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.26">Created</change>
// </history>

namespace Fanex.NAP.SMALossEmail.Watcher.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// SMA loss group view model.
    /// </summary>
    public class FormattedSMALossGroup
    {
        public FormattedSMALossGroup(SMALoss rawData, string levelRange)
        {
            if (rawData != null)
            {
                this.LossLevel = rawData.LevelID;
                this.LossLevelRange = levelRange;
                this.SMALossItems = new List<FormattedSMALossItem>();
            }
        }

        public byte LossLevel { get; set; }

        public string LossLevelRange { get; set; }

        public List<FormattedSMALossItem> SMALossItems { get; set; }
    }
}