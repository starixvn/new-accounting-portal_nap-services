// --------------------------------------------------------------------------
// <copyright file="Recipients.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.26">Created</change>
// </history>

namespace Fanex.NAP.SMALossEmail.Watcher.Entities
{
    /// <summary>
    /// The recipients of an email.
    /// </summary>
    public class Recipients
    {
        public int SiteID { get; set; }

        public string Site { get; set; }

        public string ToList { get; set; }

        public string CcList { get; set; }

        public string BccList { get; set; }

        public int IsAvailabe { get; set; }
    }
}