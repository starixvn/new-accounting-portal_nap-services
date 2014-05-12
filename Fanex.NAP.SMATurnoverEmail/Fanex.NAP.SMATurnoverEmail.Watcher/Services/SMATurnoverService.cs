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
    using RazorEngine;

    /// <summary>
    /// Send email service.
    /// </summary>
    public class SMATurnoverService : ISMATurnoverService
    {
        /// <summary>
        /// Notifies the email.
        /// </summary>
        /// <param name="templateUrl">The template URL.</param>
        /// <returns>Boolean value indicates whether the email is sent successfully or not.</returns>
        public bool NotifyEmail(string templateUrl)
        {
            var isNotified = true;
            var timezone = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Hours;
            var subject = string.Format(AppSettings.Subject, DateTime.Now, string.Format("{0}{1}", timezone > 0 ? "+" : string.Empty), timezone);
            var recipients = GetRecipients();
            IEnumerable<FormattedSMATurnover> turnovers = GetReachedSMATurnover();

            if (turnovers != null && turnovers.Any())
            {
                string appLocation = AppDomain.CurrentDomain.BaseDirectory;
                var template = File.ReadAllText(appLocation + templateUrl);
                var content = Razor.Parse(template, turnovers);

                SendMail(new EmailContent
                    {
                        Recievers = recipients,
                        Title = "IT Team",
                        Subject = subject,
                        Body = content
                    });

                // @@TODO: Update status.
            }

            return isNotified;
        }

        /// <summary>
        /// Gets the recipients.
        /// </summary>
        /// <returns>Recipients object.</returns>
        private Recipients GetRecipients()
        {
            Recipients recipients = null;

            recipients = new Recipients
            {
                To = "jason.ly@nexcel.vn",
                Cc = "jason.ly@nexcel.vn",
                Bcc = "jason.ly@nexcel.vn"
            };

            return recipients;
        }

        /// <summary>
        /// Gets the reached SMA turnover.
        /// </summary>
        /// <returns>List of FormattedSMATurnover objects.</returns>
        private IEnumerable<FormattedSMATurnover> GetReachedSMATurnover()
        {
            List<FormattedSMATurnover> result = null;

            result = new List<FormattedSMATurnover>();
            result.Add(new FormattedSMATurnover(new SMATurnover
                {
                    SportID = 1,
                    LeagueID = 3,
                    HomeID = 1,
                    AwayID = 2,
                    MatchCode = "Test",
                    EventDate = DateTime.Now,
                    RoldeID = 4,
                    Username = "Test",
                    Currency = "UUS",
                    MaxTOAmount = 1000000,
                    MemberTO = 100000,
                    PercentageUsed = 10
                }));

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
                    MailTo = content.Recievers.To,
                    MailCc = content.Recievers.Cc,
                    MailBcc = content.Recievers.Bcc,
                    Title = content.Title,
                    Subject = content.Subject,
                    Body = content.Body
                };

                client.SendMail(mailItem);
            }
        }
    }
}