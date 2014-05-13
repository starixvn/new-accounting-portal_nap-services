// --------------------------------------------------------------------------
// <copyright file="ISMATurnoverRepository.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.9">Created</change>
// </history>

namespace Fanex.NAP.SMATurnoverEmail.Watcher.Repositories
{
    using System.Collections.Generic;
    using Fanex.NAP.SMATurnoverEmail.Watcher.Entities;

    public interface ISMATurnoverRepository
    {
        /// <summary>
        /// Gets the receivers.
        /// </summary>
        /// <param name="functionID">Function ID.</param>
        /// <returns>Recipients objects.</returns>
        Recipients GetReceivers(int functionID);

        /// <summary>
        /// Gets the notified SMA turnover.
        /// </summary>
        /// <returns>List of SMATurnover objects.</returns>
        IEnumerable<SMATurnover> GetNotifiedSMATurnover();

        /// <summary>
        /// Updates the notified status.
        /// </summary>
        /// <param name="updatingData">The updating data.</param>
        void UpdateNotifiedStatus(UpdatingNotifiedSMATurnover updatingData);
    }
}