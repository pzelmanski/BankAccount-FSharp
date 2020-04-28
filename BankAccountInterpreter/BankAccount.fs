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
        fun amount account ->
            let newTransaction = [ Credit { Amount = amount } ]
            { Account = account.Account
              Transactions = newTransaction |> List.append account.Transactions
              Balance = account.Balance + amount }

    let takeLastTransaction: TakeLastTransaction =
        fun account -> account.Transactions |> List.tryHead
