// --------------------------------------------------------------------------
// <copyright file="EmailContent.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.9">Created</change>
// </history>

namespace Fanex.NAP.SMATurnoverEmail.Watcher.Entities
{
    /// <summary>
    /// Email content.
    /// </summary>
    public class EmailContent
    {
        public Recipients Recievers { get; set; }

        public string Title { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}