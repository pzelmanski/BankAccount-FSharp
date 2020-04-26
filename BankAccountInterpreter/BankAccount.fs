﻿namespace BankAccountInterpreter

open System
open BankAccountSpecification.Operations
open BankAccountSpecification.Language

module BankAccount =
    let create : CreateBankAccount =
        fun () ->
            PreActivatedAccount.PreActivatedAccount { Identity = Guid.NewGuid |> string }

    let openAccount : OpenAccount =
        fun (PreActivatedAccount account) ->
            { Account = account
              Balance = 0.0m }

    let closeAccount account = failwith "You need to implement this function."

    let balance : GetBalance =
        fun account ->
            account.Balance

    let updateBalance change account = failwith "You need to implement this function."