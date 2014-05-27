// --------------------------------------------------------------------------
// <copyright file="ISMALossService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.26">Created</change>
// </history>

namespace Fanex.NAP.SMALossEmail.Watcher.Services
{
    public interface ISMALossService
    {
        /// <summary>
        /// Notifies the email.
        /// </summary>
        /// <param name="templateUrl">The template URL.</param>
        /// <returns>Boolean value indicates whether the email is sent successfully or not.</returns>
        bool NotifyEmail(string templateUrl);
    }
}