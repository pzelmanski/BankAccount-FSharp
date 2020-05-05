namespace BankAccountIntegration

open BankAccountInterpreter
open Persistance
open Persistence


module BankAccountIntegration =
    let create =
        BankAccount.create()
        |> AccountHelpers.add AccountDatabase.Instance.addAccount
