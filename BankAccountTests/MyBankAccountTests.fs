namespace BankAccount_Tests

open BankAccountInterpreter
open Xunit
open BankAccountInterpreter.BankAccount
open FsUnit.Xunit
open BankAccountSpecification.Language

module MyBankAccountTests =
    [<Fact>]
    let ``Returns empty balance after opening`` () =
        BankAccount.create ()
        |> ``open``
        |> balance
        |> should equal 0.0m

    [<Fact>]
    let ``When account is open given a credit transaction it should persist transaction and increase balance`` () =
        BankAccount.create ()
        |> ``open``
        |> updateBalance (Credit { Amount = 10m })
        |> takeLastTransaction
        |> should equal (Some(Credit { Amount = 10m }))

    [<Fact>]
    let ``When account is open given a credit transaction it should persist transaction and decrease balance`` () =
        BankAccount.create ()
        |> ``open``
        |> updateBalance (Debit { Amount = 10m })
        |> takeLastTransaction
        |> should equal (Some(Debit { Amount = 10m }))
