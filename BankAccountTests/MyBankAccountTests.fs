namespace BankAccount_Tests

open BankAccountInterpreter
open Xunit
open BankAccountInterpreter.BankAccount
open FsUnit.Xunit
open BankAccountSpecification.Language

module MyBankAccountTests =
    [<Fact>]
    let ``Returns empty balance after opening`` () =
        BankAccount.create()
            |> ``open``
            |> balance
            |> should equal 0.0m

    [<Fact>]
    let ``When account is open given a transaction it is persisted within account`` () =
        let lastTransaction = BankAccount.create()
                                |> ``open``
                                |> updateBalance 10m
                                |> takeLastTransaction
        lastTransaction
            |> function
                | Some (Credit credit) -> credit.Amount
                | Some (Debit debit) -> debit.Amount
                | None -> 0m
            |> should equal 10m                        
