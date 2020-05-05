module BankAccountTest

open Xunit
open FsUnit
open BankAccountInterpreter.BankAccount
open BankAccountSpecification.Language


[<Fact>]
let ``Check basic balance`` () =
    let account = create () |> ``open``
    let openingBalance = account |> balance

    let updatedBalance =
        account
        |> updateBalance (Credit { Amount = 10.0m })
        |> balance

    openingBalance |> should equal (0.0m)
    updatedBalance |> should equal (10.0m)

[<Fact>]
let ``Balance can increment or decrement`` () =
    let account = create () |> ``open``
    let openingBalance = account |> balance

    let addedBalance =
        account
        |> updateBalance (Credit { Amount = 10.0m })
        |> balance

    let subtractedBalance =
        account
        |> updateBalance (Debit { Amount = 15.0m })
        |> balance

    openingBalance |> should equal (0.0m)
    addedBalance |> should equal (10.0m)
    subtractedBalance |> should equal (-15.0M)

[<Fact>]
let ``Account can be closed`` () =
    let account =
        create ()
        |> ``open``
        |> close

    balance account |> should equal None
    account |> should not' (equal None)

[<Fact>]
let ``Account can be updated from multiple threads`` () =
    let account =
        create () |> ``open``

    let updateAccountAsync =
        async {
            account
            |> updateBalance (Credit { Amount = 1.0m })
            |> ignore
        }

    updateAccountAsync
    |> List.replicate 1000
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore

    balance account |> should equal (1000.0m)
