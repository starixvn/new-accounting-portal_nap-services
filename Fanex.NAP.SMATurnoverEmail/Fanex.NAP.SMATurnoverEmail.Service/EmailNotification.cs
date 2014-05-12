// --------------------------------------------------------------------------
// <copyright file="EmailNotification.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.9">Created</change>
// </history>

namespace Fanex.NAP.SMATurnoverEmail.Service
{
    using System;
    using System.Data.SqlClient;
    using System.ServiceProcess;
    using System.Timers;
    using Fanex.Logging;
    using Fanex.NAP.SMATurnoverEmail.Watcher.Services;

    /// <summary>
    /// SMA Turnover email service.
    /// </summary>
    public partial class EmailNotification : ServiceBase
    {
        private const string TemplateUrl = @"/Templates/EmailTemplate.cshtml";

        private Timer _timer = null;
        private ISMATurnoverService _turnoverService = null;

        public EmailNotification()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Start command is sent to the service by the Service Control Manager (SCM)
        /// or when the operating system starts (for a service that starts automatically). Specifies actions to take when the service starts.
        /// </summary>
        /// <param name="args">Data passed by the start command.</param>
        protected override void OnStart(string[] args)
        {
            this._turnoverService = new SMATurnoverService();
            this._timer = new Timer();
            this._timer.Interval = 10000;
            this._timer.Elapsed += new ElapsedEventHandler(this.CallService);
            this._timer.Enabled = true;

            Test.WriteTest("Test window service started.");
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Stop command is sent to the service by the Service Control Manager (SCM).
        /// Specifies actions to take when a service stops running.
        /// </summary>
        protected override void OnStop()
        {
            this._timer.Enabled = false;
            Test.WriteTest("Test window service stopped.");
        }

        /// <summary>
        /// Calls the service.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void CallService(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (this._turnoverService != null)
                {
                    this._turnoverService.NotifyEmail(TemplateUrl);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="ex">The exception.</param>
        private void HandleException(Exception ex)
        {
            string exceptionFormat = "{0}\r\nType: {1}\r\nSource: {2}\r\nTargetSite: {3}\r\nStackTrace: {4}";
            string message = string.Format(
                                        exceptionFormat,
                                        ex.Message,
                                        ex.GetType().ToString(),
                                        ex.Source,
                                        ex.TargetSite,
                                        ex.StackTrace);

            if (ex is SqlException)
            {
                message += string.Format(
                                      "\r\nProcedure: {0}\r\nLine Number: {1}\r\nServer: {2}",
                                      (ex as SqlException).Procedure,
                                      (ex as SqlException).LineNumber,
                                      (ex as SqlException).Server);
            }

            LogService.Error(message);
        }
    }
}