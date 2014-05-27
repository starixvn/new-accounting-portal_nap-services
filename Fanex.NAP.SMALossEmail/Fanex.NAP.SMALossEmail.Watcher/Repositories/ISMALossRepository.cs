// --------------------------------------------------------------------------
// <copyright file="ISMALossRepository.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.26">Created</change>
// </history>

namespace Fanex.NAP.SMALossEmail.Watcher.Repositories
{
    using System.Collections.Generic;
    using Fanex.NAP.SMALossEmail.Watcher.Entities;

    public interface ISMALossRepository
    {
        /// <summary>
        /// Gets the receivers.
        /// </summary>
        /// <param name="functionID">Function ID.</param>
        /// <returns>Recipients objects.</returns>
        Recipients GetReceivers(int functionID);

        /// <summary>
        /// Gets the notified SMA loss.
        /// </summary>
        /// <returns>List of SMALoss objects.</returns>
        IEnumerable<SMALoss> GetNotifiedSMATurnover();

        /// <summary>
        /// Updates the notified status.
        /// </summary>
        /// <param name="updatingData">The updating data.</param>
        void UpdateNotifiedStatus(UpdatingNotifiedSMALoss updatingData);
    }
}