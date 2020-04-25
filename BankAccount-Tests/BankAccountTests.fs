// This file was created manually and its version is 2.0.0.

module BankAccountTest

open Xunit
open FsUnit.Xunit
open BankAccount_Interpreter.BankAccount

[<Fact>]
let ``Returns empty balance after opening`` () =
    let account = create() |> openAccount
    balance account |> should equal (Some 0.0m)

[<Fact>]
let ``Check basic balance`` () =
    let account = create() |> openAccount
    let openingBalance = account |> balance 

    let updatedBalance = 
        account
        |> updateBalance 10.0m
        |> balance

    openingBalance |> should equal (Some 0.0m)
    updatedBalance |> should equal (Some 10.0m)

[<Fact>]
let ``Balance can increment or decrement`` () =    
    let account = create() |> openAccount
    let openingBalance = account |> balance 

    let addedBalance = 
        account 
        |> updateBalance 10.0m
        |> balance

    let subtractedBalance = 
        account 
        |> updateBalance -15.0m
        |> balance

    openingBalance |> should equal (Some 0.0m)
    addedBalance |> should equal (Some 10.0m)
    subtractedBalance |> should equal (Some -5.0m)

[<Fact>]
let ``Account can be closed`` () =
    let account = 
        create()
        |> openAccount
        |> closeAccount

    balance account |> should equal None
    account |> should not' (equal None)
    
[<Fact>]
let ``Account can be updated from multiple threads`` () =
    let account = 
        create()
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

    balance account |> should equal (Some 1000.0m)
