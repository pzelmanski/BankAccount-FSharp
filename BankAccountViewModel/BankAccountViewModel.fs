namespace BankAccountViewModel

open BankAccountDataGateway

module BankAccountViewModel =
    let createAccount identity =
        async {
            match! Command.AddAccount identity with
            | Ok _ -> ()
            | Error msg -> failwith msg
        } |> Async.RunSynchronously
        
    let getAccount identity =
        async {
            let! result = identity |> Query.GetAccount
            match result with
            | Ok x -> return x
            | Error _ -> return None
        } |> Async.RunSynchronously
        