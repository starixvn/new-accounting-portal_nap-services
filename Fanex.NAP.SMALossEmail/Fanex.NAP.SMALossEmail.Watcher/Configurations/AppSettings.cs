// --------------------------------------------------------------------------
// <copyright file="AppSettings.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.26">Created</change>
// </history>

namespace Fanex.NAP.SMALossEmail.Watcher.Configurations
{
    using System.Configuration;
    using Fanex.Common;

    /// <summary>
    /// Application settings.
    /// </summary>
    public static class AppSettings
    {
        private static int sendEmailTime;
        private static string title;
        private static string subject;
        private static int functionID;

        public static int SendEmailTime
        {
            get
            {
                if (sendEmailTime == 0)
                {
                    sendEmailTime = Converter.ToInt(GetValue("SendEmailTime"));
                }

                return sendEmailTime;
            }
        }

        public static string Title
        {
            get
            {
                if (title == null)
                {
                    title = GetValue("Title");
                }

                return title;
            }
        }

        public static string Subject
        {
            get
            {
                if (subject == null)
                {
                    subject = GetValue("Subject");
                }

                return subject;
            }
        }

        public static int FunctionID
        {
            get
            {
                if (functionID == 0)
                {
                    functionID = Converter.ToInt(GetValue("FunctionID"));
                }

                return functionID;
            }
        }

        /// <summary>
        /// Gets the value from web configuration.
        /// </summary>
        /// <param name="key">The key which is used to identify the value.</param>
        /// <returns>Associated value of passed key.</returns>
        private static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}