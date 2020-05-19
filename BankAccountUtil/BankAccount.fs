namespace BankAccountInterpreter

open System
open BankAccountSpecification
open BankAccountSpecification.Operations
open BankAccountSpecification.Language

module BankAccount =
    let create: CreateBankAccount =
        fun (identity) ->
            { Identity = { Identity = identity } }

    let makeOpen: OpenAccount =
        fun (account) ->
            { Identity = account.Identity
              Transactions = []
              Balance = 0.0m }

    let close (account : OpenedAccount) =
        { ClosedAccount.Identity = account.Identity }
        
    let balance: GetBalance =
        fun account -> account.Balance

    let updateBalance: ChangeBalance =
        fun transaction account ->
            { Identity = account.Identity
              Transactions = transaction :: account.Transactions
              Balance =
                  account.Balance + (transaction
                                     |> function
                                     | Credit c -> c.Amount
                                     | Debit d -> -d.Amount) }

    let takeLastTransaction: TakeLastTransaction =
        fun account -> account.Transactions |> List.tryHead

    let createTransaction : CreateTransaction =
        fun openedAccount money ->
            {
                Identity = openedAccount.Identity
                TimeStamp = DateTime.Now
                Amount = money
            } |> Transaction.Credit
            