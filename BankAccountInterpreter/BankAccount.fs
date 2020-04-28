namespace BankAccountInterpreter

open System
open BankAccountSpecification.Operations
open BankAccountSpecification.Language

module BankAccount =
    let create: CreateBankAccount =
        fun () -> PreActivatedAccount.PreActivatedAccount { Identity = Guid.NewGuid |> string }

    let ``open``: OpenAccount =
        fun (PreActivatedAccount account) ->
            { Account = account
              Transactions = []
              Balance = 0.0m }

    let close account = failwith "You need to implement this function."

    let balance: GetBalance =
        fun account -> account.Balance

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
