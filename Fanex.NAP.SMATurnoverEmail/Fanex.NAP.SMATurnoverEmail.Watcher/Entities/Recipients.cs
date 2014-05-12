// --------------------------------------------------------------------------
// <copyright file="Recipients.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.9">Created</change>
// </history>

namespace Fanex.NAP.SMATurnoverEmail.Watcher.Entities
{
    /// <summary>
    /// The recipients of an email.
    /// </summary>
    public class Recipients
    {
        public string To { get; set; }

        public string Cc { get; set; }

        public string Bcc { get; set; }
    }
}