using System.Diagnostics.CodeAnalysis;

[module: SuppressMessage(
            "Microsoft.Design",
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Scope = "member",
            Target = "Fanex.NAP.SMALossEmail.Service.EmailNotification.#CallService(System.Object,System.Timers.ElapsedEventArgs)",
            Justification = "Reviewed.")]

[module: SuppressMessage(
            "Microsoft.Usage",
            "CA2201:DoNotRaiseReservedExceptionTypes",
            Scope = "member",
            Target = "Fanex.NAP.SMALossEmail.Service.EmailNotification.#CallService(System.Object,System.Timers.ElapsedEventArgs)",
            Justification = "Reviewed.")]