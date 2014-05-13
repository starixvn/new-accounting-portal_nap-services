// --------------------------------------------------------------------------
// <copyright file="SMATurnoverService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.9">Created</change>
// </history>

namespace Fanex.NAP.SMATurnoverEmail.Watcher.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Fanex.MailDeliver.MailClient.API;
    using Fanex.MailDeliver.Model;
    using Fanex.NAP.SMATurnoverEmail.Watcher.Configurations;
    using Fanex.NAP.SMATurnoverEmail.Watcher.Entities;
    using Fanex.NAP.SMATurnoverEmail.Watcher.Repositories;
    using RazorEngine;

    /// <summary>
    /// Send email service.
    /// </summary>
    public class SMATurnoverService : ISMATurnoverService
    {
        private ISMATurnoverRepository _repository = null;
        private string _template = null;

        public SMATurnoverService() :
            this(null)
        {
        }

        public SMATurnoverService(ISMATurnoverRepository repository)
        {
            this._repository = repository ?? new SMATurnoverRepository();
        }

        /// <summary>
        /// Notifies the email.
        /// </summary>
        /// <param name="templateUrl">The template URL.</param>
        /// <returns>Boolean value indicates whether the email is sent successfully or not.</returns>
        public bool NotifyEmail(string templateUrl)
        {
            var isNotified = true;
            var timezone = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Hours;
            var subject = string.Format(AppSettings.Subject, DateTime.Now, string.Format("{0}{1}", timezone > 0 ? "+" : string.Empty, timezone));
            var recipients = GetRecipients();
            IEnumerable<FormattedSMATurnover> turnovers = GetReachedSMATurnover();

            if (recipients != null && turnovers != null && turnovers.Any())
            {
                string template = GetTemplate(templateUrl);
                var content = Razor.Parse(template, turnovers);
                var updatingList = new UpdatingNotifiedSMATurnover(turnovers);

                SendMail(new EmailContent
                    {
                        Recievers = recipients,
                        Title = AppSettings.Title,
                        Subject = subject,
                        Body = content
                    });

                if (updatingList.IsValid())
                {
                    this._repository.UpdateNotifiedStatus(updatingList);

                    if (updatingList.ErrCode != 0)
                    {
                        throw new Exception(updatingList.ErrMsg);
                    }
                }
            }

            return isNotified;
        }

        /// <summary>
        /// Gets the template.
        /// </summary>
        /// <param name="templateUrl">The template URL.</param>
        /// <returns>The email template.</returns>
        private string GetTemplate(string templateUrl)
        {
            if (this._template == null)
            {
                string appLocation = AppDomain.CurrentDomain.BaseDirectory;

                this._template = File.ReadAllText(appLocation + templateUrl);
            }

            return this._template;
        }

        /// <summary>
        /// Gets the recipients.
        /// </summary>
        /// <returns>Recipients object.</returns>
        private Recipients GetRecipients()
        {
            Recipients recipients = this._repository.GetReceivers(AppSettings.FunctionID);

            recipients = recipients.IsAvailabe != 0 ? recipients : null;

            return recipients;
        }

        /// <summary>
        /// Gets the reached SMA turnover.
        /// </summary>
        /// <returns>List of FormattedSMATurnover objects.</returns>
        private IEnumerable<FormattedSMATurnover> GetReachedSMATurnover()
        {
            IEnumerable<SMATurnover> rawData = this._repository.GetNotifiedSMATurnover();
            IEnumerable<FormattedSMATurnover> result = null;

            if (rawData != null && rawData.Any())
            {
                result = rawData.Select(obj => new FormattedSMATurnover(obj));
            }

            return result;
        }

        /// <summary>
        /// Sends the mail.
        /// </summary>
        /// <param name="content">The content.</param>
        private void SendMail(EmailContent content)
        {
            using (var client = new MailDeliver())
            {
                var mailItem = new MailRecord
                {
                    MailTo = content.Recievers.ToList,
                    MailCc = content.Recievers.CcList,
                    MailBcc = content.Recievers.BccList,
                    Title = content.Title,
                    Subject = content.Subject,
                    Body = content.Body
                };

                client.SendMail(mailItem);
            }
        }
    }
}