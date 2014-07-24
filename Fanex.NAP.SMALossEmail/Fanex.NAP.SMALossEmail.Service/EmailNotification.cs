// --------------------------------------------------------------------------
// <copyright file="EmailNotification.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.26">Created</change>
// </history>

namespace Fanex.NAP.SMALossEmail.Service
{
    using System;
    using System.Data.SqlClient;
    using System.ServiceProcess;
    using System.Timers;
    using Fanex.Data.Configuration;
    using Fanex.Logging;
    using Fanex.NAP.SMALossEmail.Watcher.Configurations;
    using Fanex.NAP.SMALossEmail.Watcher.Services;

    /// <summary>
    /// SMA Turnover email service.
    /// </summary>
    public partial class EmailNotification : ServiceBase
    {
        private const string TemplateUrl = @"/Templates/EmailTemplate.cshtml";

        private TimeSpan _startTime;
        private Timer _timer = null;
        private ISMALossService _lossService = null;

        public EmailNotification()
        {
            InitializeComponent();
            DbSettingProviderManager.Current.Start();
            this._lossService = new SMALossService();
            this._startTime = new TimeSpan(AppSettings.SendEmailHour, AppSettings.SendEmailMinute, 0);
        }

        /// <summary>
        /// Starts the service.
        /// </summary>
        public void Start()
        {
            ResetTimer();
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Start command is sent to the service by the Service Control Manager (SCM)
        /// or when the operating system starts (for a service that starts automatically). Specifies actions to take when the service starts.
        /// </summary>
        /// <param name="args">Data passed by the start command.</param>
        protected override void OnStart(string[] args)
        {
            this.Start();
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Stop command is sent to the service by the Service Control Manager (SCM).
        /// Specifies actions to take when a service stops running.
        /// </summary>
        protected override void OnStop()
        {
        }

        /// <summary>
        /// Resets the timer.
        /// </summary>
        private void ResetTimer()
        {
            TimeSpan interval = this._startTime.Subtract(DateTime.Now.TimeOfDay); ////new TimeSpan(DateTime.Now.Ticks).Subtract(this._startTime);
            double intervalMilisecond = interval.TotalMilliseconds;

            if (intervalMilisecond <= 0)
            {
                interval = interval.Add(new TimeSpan(24, 0, 0));
                intervalMilisecond = interval.TotalMilliseconds;
            }

            this._timer = new Timer(intervalMilisecond);
            this._timer.AutoReset = false;
            this._timer.Enabled = true;
            this._timer.Elapsed += new ElapsedEventHandler(this.CallService);
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
                if (this._lossService != null)
                {
                    this._timer.Enabled = false;
                    this._lossService.NotifyEmail(TemplateUrl);
                    ResetTimer();
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
            SqlException sqlEx = ex as SqlException;
            string exceptionFormat = "{0}\r\nType: {1}\r\nSource: {2}\r\nTargetSite: {3}\r\nStackTrace: {4}";
            string message = string.Format(
                                        exceptionFormat,
                                        ex.Message,
                                        ex.GetType().ToString(),
                                        ex.Source,
                                        ex.TargetSite,
                                        ex.StackTrace);

            if (sqlEx != null)
            {
                message += string.Format(
                                      "\r\nProcedure: {0}\r\nLine Number: {1}\r\nServer: {2}",
                                      sqlEx.Procedure,
                                      sqlEx.LineNumber,
                                      sqlEx.Server);
            }

            LogService.Error(message);
        }
    }
}