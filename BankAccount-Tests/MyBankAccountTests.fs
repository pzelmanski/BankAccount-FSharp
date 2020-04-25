namespace BankAccount_Tests

open Xunit
open BankAccount_Interpreter.BankAccount
open FsUnit.Xunit

module MyBankAccountTests =
    [<Fact>]
    let ``Returns empty balance after opening`` () =
        create()
            |> openAccount
            |> balance
            |> should equal 0.0m
