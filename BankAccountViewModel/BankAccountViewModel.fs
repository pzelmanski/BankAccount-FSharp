﻿namespace BankAccountViewModel

open BankAccountDataGateway

module BankAccountViewModel =
    let createAccount identity =
        async {
            match! Command.addAccount identity with
            | Ok _ -> ()
            | Error msg -> failwith msg
        } |> Async.RunSynchronously
        
    let getAccount identity =
        async {
            let! result = identity |> Query.getAccount
            match result with
            | Ok x -> return x
            | Error _ -> return None
        } |> Async.RunSynchronously
    
    let openAccount identity =
        async{
            let! result = identity |> Command.openAccount
            match result with
            | Ok _ -> ()
            | Error msg -> failwith msg
        } |> Async.RunSynchronously