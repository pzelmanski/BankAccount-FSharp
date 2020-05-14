namespace EventsTest

open System
open EventsSpecification.Language

module EventsFactory =
    let getAccountCreateEvent () : BankEvent =
        { BankEvent.Timestamp = DateTime(2020, 5, 5)
          BankEvent.TypeAndContext =
              BankEventInner.AccountOperation
                  { Identity = { Identity = "asd" }
                    Context = CreateAccount } }
