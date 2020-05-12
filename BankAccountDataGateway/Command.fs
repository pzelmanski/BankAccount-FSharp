namespace BankAccountDataGateway

open Persistance
open Persistence

module Command =
    let AddAccount =
        AccountHelpers.add AccountDatabase.Instance.upsert
