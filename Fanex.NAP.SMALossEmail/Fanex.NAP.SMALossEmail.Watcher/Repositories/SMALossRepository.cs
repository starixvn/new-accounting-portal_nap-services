// --------------------------------------------------------------------------
// <copyright file="SMALossRepository.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.26">Created</change>
// </history>

namespace Fanex.NAP.SMALossEmail.Watcher.Repositories
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using Fanex.Common;
    using Fanex.Data;
    using Fanex.NAP.SMALossEmail.Watcher.Entities;

    /// <summary>
    /// The repository that is used to support getting data.
    /// </summary>
    public class SMALossRepository : ISMALossRepository
    {
        /// <summary>
        /// Gets the receivers.
        /// </summary>
        /// <param name="functionID">Function ID.</param>
        /// <returns>Recipients objects.</returns>
        public Recipients GetReceivers(int functionID)
        {
            Recipients result = null;

            using (var objDB = new ObjectDb("Acc_MailingListSel"))
            {
                objDB.AddInParameter("FuncID", DbType.Int32, functionID);
                result = objDB.QueryEntity<Recipients>();
            }

            return result;
        }

        /// <summary>
        /// Gets the notified SMA loss.
        /// </summary>
        /// <returns>List of SMALoss objects.</returns>
        public IEnumerable<SMALoss> GetNotifiedSMATurnover()
        {
            IEnumerable<SMALoss> result = null;

            using (var objDB = new ObjectDb("NAP_SMALoss_IsNotifiedSel"))
            {
                result = objDB.Query<SMALoss>();
            }

            return result;
        }

        /// <summary>
        /// Updates the notified status.
        /// </summary>
        /// <param name="updatingData">The updating data.</param>
        public void UpdateNotifiedStatus(UpdatingNotifiedSMALoss updatingData)
        {
            Hashtable output = null;

            using (var objDB = new ObjectDb("NAP_SMALoss_IsNotifiedUpd"))
            {
                objDB.AddInParameter("SMAIDs", DbType.String, updatingData.SMAIDs);
                objDB.AddOutParameter("ErrCode", DbType.Int32, 4);
                objDB.AddOutParameter("ErrMsg", DbType.String, 400);

                objDB.ExecuteNonQuery();

                output = objDB.GetOuputParams();

                if (output.ContainsKey("errcode"))
                {
                    updatingData.ErrCode = Converter.ToInt(output["errorcode"]);
                }

                if (output.ContainsKey("errmsg"))
                {
                    updatingData.ErrMsg = Converter.ToString2(output["errmsg"]);
                }
            }
        }
    }
}