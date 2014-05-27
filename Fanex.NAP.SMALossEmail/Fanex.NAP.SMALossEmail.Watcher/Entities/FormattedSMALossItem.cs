// --------------------------------------------------------------------------
// <copyright file="FormattedSMALossItem.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.26">Created</change>
// </history>

namespace Fanex.NAP.SMALossEmail.Watcher.Entities
{
    using Fanex.Common;
    using Fanex.NAP.SMALossEmail.Watcher.Helpers;

    /// <summary>
    /// Formatted SMA Loss which is used to bind with the template.
    /// </summary>
    public class FormattedSMALossItem
    {
        public FormattedSMALossItem(SMALoss rawData)
        {
            if (rawData != null)
            {
                this.CustID = rawData.CustID;
                this.Username = rawData.Username;
                this.Level = GetCustomerLevel(rawData.RoleID);
                this.Currency = rawData.Currency;
                this.TotalBalance = Converter.ToDecimal(rawData.TotalBalance).FormatDecimal();
                this.MaxLoss = Converter.ToDecimal(rawData.MaxLoss).FormatDecimal();
                this.LossPercentage = Converter.ToInt(rawData.PercentageLoss).FormatInteger();
            }
        }

        public int CustID { get; set; }

        public string Username { get; set; }

        public string Level { get; set; }

        public string Currency { get; set; }

        public string TotalBalance { get; set; }

        public string MaxLoss { get; set; }

        public string LossPercentage { get; set; }

        /// <summary>
        /// Gets the customer level.
        /// </summary>
        /// <param name="roleID">The role identifier.</param>
        /// <returns>The level name.</returns>
        private string GetCustomerLevel(byte? roleID)
        {
            var level = string.Empty;

            if (roleID.HasValue)
            {
                switch (roleID.Value)
                {
                    case 4:
                        level = "Super";
                        break;

                    case 3:
                        level = "Master";
                        break;

                    case 2:
                        level = "Agent";
                        break;

                    case 1:
                        level = "Member";
                        break;
                }
            }

            return level;
        }
    }
}