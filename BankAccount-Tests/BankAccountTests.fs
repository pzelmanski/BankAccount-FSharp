// This file was created manually and its version is 2.0.0.

module BankAccountTest

open Xunit
open FsUnit.Xunit
open BankAccount_Interpreter.BankAccount

[<Fact>]
let ``Returns empty balance after opening`` () =
    let account = createBankAccount() |> openAccount

    getBalance account |> should equal (Some 0.0m)

[<Fact>]
let ``Check basic balance`` () =
    let account = createBankAccount() |> openAccount
    let openingBalance = account |> getBalance 

    let updatedBalance = 
        account
        |> updateBalance 10.0m
        |> getBalance

    openingBalance |> should equal (Some 0.0m)
    updatedBalance |> should equal (Some 10.0m)

[<Fact>]
let ``Balance can increment or decrement`` () =    
    let account = createBankAccount() |> openAccount
    let openingBalance = account |> getBalance 

    let addedBalance = 
        account 
        |> updateBalance 10.0m
        |> getBalance

    let subtractedBalance = 
        account 
        |> updateBalance -15.0m
        |> getBalance

    openingBalance |> should equal (Some 0.0m)
    addedBalance |> should equal (Some 10.0m)
    subtractedBalance |> should equal (Some -5.0m)

[<Fact>]
let ``Account can be closed`` () =
    let account = 
        createBankAccount()
        |> openAccount
        |> closeAccount

    getBalance account |> should equal None
    account |> should not' (equal None)
    
[<Fact>]
let ``Account can be updated from multiple threads`` () =
    let account = 
        createBankAccount()
        |> openAccount

    let updateAccountAsync =        
        async {                             
            account 
            |> updateBalance 1.0m
            |> ignore
        }

    updateAccountAsync
    |> List.replicate 1000
    |> Async.Parallel 
    |> Async.RunSynchronously
    |> ignore

    getBalance account |> should equal (Some 1000.0m)
