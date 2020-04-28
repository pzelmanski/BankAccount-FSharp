namespace BankAccount_Tests

open BankAccountInterpreter
open Xunit
open BankAccountInterpreter.BankAccount
open FsUnit.Xunit

module MyBankAccountTests =
    [<Fact>]
    let ``Returns empty balance after opening`` () =
        BankAccount.create()
            |> ``open``
            |> balance
            |> should equal 0.0m
