namespace BankAccountIntegration

open BankAccountInterpreter
open Persistance
open Persistence

module DataGateway =
    let createAccount =
        BankAccount.create()
        |> AccountHelpers.add AccountDatabase.Instance.upsert
    
    let getAccount identity = async {
        let result = identity |> AccountHelpers.get AccountDatabase.Instance.get
        match! result with
        | Ok x -> return x
        | Error _ -> return None }