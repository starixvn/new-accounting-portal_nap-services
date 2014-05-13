// --------------------------------------------------------------------------
// <copyright file="Program.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.9">Created</change>
// </history>

namespace Fanex.NAP.SMATurnoverEmail.Service
{
    using System.ServiceProcess;
    using System.Threading;

    /// <summary>
    /// Service starting point.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main()
        {
#if DEBUG
            var service = new EmailNotification();

            service.Start();
            Thread.Sleep(600000);
#else
            var servicesToRun = new ServiceBase[]
            {
                new EmailNotification()
            };

            ServiceBase.Run(servicesToRun);
#endif
        }
    }
}