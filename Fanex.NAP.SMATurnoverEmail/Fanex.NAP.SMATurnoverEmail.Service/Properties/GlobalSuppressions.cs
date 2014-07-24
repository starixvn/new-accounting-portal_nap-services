using System.Diagnostics.CodeAnalysis;

[module: SuppressMessage(
            "Microsoft.Design",
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Scope = "member",
            Target = "Fanex.NAP.SMATurnoverEmail.Service.EmailNotification.#CallService(System.Object,System.Timers.ElapsedEventArgs)",
            Justification = "Reviewed.")]