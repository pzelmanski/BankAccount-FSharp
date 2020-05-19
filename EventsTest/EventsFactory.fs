namespace EventsTest

open System
open EventsSpecification.Language

module EventsFactory =
    let getAccountCreateEvent (identity) : BankEvent =
        { BankEvent.Identity = identity
          BankEvent.Timestamp = DateTime(2020, 5, 5)
          BankEvent.TypeAndContext =
              BankEventInner.AccountOperation
                  { Identity = { Identity = Guid.NewGuid() |> string }
                    Context = CreateAccount } }
