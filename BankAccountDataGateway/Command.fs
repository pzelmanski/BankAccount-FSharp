namespace BankAccountDataGateway

open Persistance
open Persistence
open BankAccountInterpreter

module Command =
    let AddAccount identity =
        identity
        |> BankAccount.create
        |> AccountHelpers.add AccountDatabase.Instance.upsert
    