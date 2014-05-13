// --------------------------------------------------------------------------
// <copyright file="Extensions.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.9">Created</change>
// </history>

namespace Fanex.NAP.SMATurnoverEmail.Watcher.Helpers
{
    using System;

    /// <summary>
    /// Number extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Formats the decimal.
        /// </summary>
        /// <param name="value">The value that needs to be formatted.</param>
        /// <returns>The formatted value.</returns>
        public static string FormatDecimal(this decimal value)
        {
            return string.Format("{0:0,0.00}", value);
        }

        /// <summary>
        /// Formats the integer.
        /// </summary>
        /// <param name="value">The value that needs to be formatted.</param>
        /// <returns>The formatted value.</returns>
        public static string FormatInteger(this int value)
        {
            return string.Format("{0:0,0}", value);
        }

        /// <summary>
        /// Formats the short date.
        /// </summary>
        /// <param name="value">The value that needs to be formatted.</param>
        /// <returns>The formatted value.</returns>
        public static string FormatShortDate(this DateTime value)
        {
            return value.ToString("MM/dd/yyyy");
        }
    }
}