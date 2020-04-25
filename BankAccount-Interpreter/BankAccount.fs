namespace BankAccount_Interpreter

open System
open BankAccount_Specification.Operations.Operations
open BankAccount_Specification.Language

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