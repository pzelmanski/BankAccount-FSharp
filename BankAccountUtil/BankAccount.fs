namespace BankAccountInterpreter

open BankAccountSpecification.Operations
open BankAccountSpecification.Language

module BankAccount =
    let create: CreateBankAccount =
        fun (identity) ->
            { Identity = { Identity = identity } }

    let ``open``: OpenAccount =
        fun (account) ->
            { Identity = account.Identity
              Transactions = []
              Balance = 0.0m }

    let close account = failwith "You need to implement this function."

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
