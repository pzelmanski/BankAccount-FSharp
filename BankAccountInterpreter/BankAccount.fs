﻿namespace BankAccountInterpreter

open System
open BankAccountSpecification.Operations
open BankAccountSpecification.Language

module BankAccount =
    let create: CreateBankAccount =
        fun () -> PreActivatedAccount.PreActivated { Identity = Guid.NewGuid() |> string }

    let ``open``: OpenAccount =
        fun (PreActivatedAccount.PreActivated account) ->
            { Account = account
              Transactions = []
              Balance = 0.0m }

    let close account = failwith "You need to implement this function."

    let balance: GetBalance =
        fun account -> account.Balance

// My idea on how in a near future it will look like:

//     event: accountId, Debit(5m)
//     HandleDebit(accountId, Debit)
//          let account = Persistance.GetAccount(accountId)
//          updateBalance2(account, debit)
//          Persistance.Persist(account)
//          SendEvent UpdatedBalance accountId, transactionId

//    let updateBalance2 account -> OpenedAcccount
//        match account with
//           | open -> updateBalance()     
//           | _ -> DoNothing
//  
        
    let updateBalance: ChangeBalance =
        fun transaction account ->
            { Account = account.Account
              Transactions = transaction :: account.Transactions
              Balance =
                  account.Balance + (transaction
                                     |> function
                                     | Credit c -> c.Amount
                                     | Debit d -> -d.Amount) }

    let takeLastTransaction: TakeLastTransaction =
        fun account -> account.Transactions |> List.tryHead
