namespace BankAccountViewModel

open BankAccountDataGateway
open BankAccountInterpreter
open BankAccountDataGateway.Query
open BankAccountDataGateway.Command

module BankAccountViewModel =
    let createAccount =
        BankAccount.create()
        |> Command.AddAccount
        
    let getAccount identity = async {
        let result = identity |> Query.GetAccount
        match! result with
        | Ok x -> return x
        | Error _ -> return None }

