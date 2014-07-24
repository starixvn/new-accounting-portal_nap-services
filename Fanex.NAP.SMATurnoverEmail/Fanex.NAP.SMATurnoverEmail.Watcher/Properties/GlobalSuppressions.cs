using System.Diagnostics.CodeAnalysis;

[module: SuppressMessage(
            "Microsoft.Design",
            "CA1024:UsePropertiesWhereAppropriate",
            Scope = "member",
            Target = "Fanex.NAP.SMATurnoverEmail.Watcher.Repositories.ISMATurnoverRepository.#GetNotifiedSMATurnover()",
            Justification = "Reviewed.")]
[module: SuppressMessage(
            "Microsoft.Usage",
            "CA2201:DoNotRaiseReservedExceptionTypes",
            Scope = "member",
            Target = "Fanex.NAP.SMATurnoverEmail.Watcher.Services.SMATurnoverService.#NotifyEmail(System.Uri)",
            Justification = "Reviewed.")]