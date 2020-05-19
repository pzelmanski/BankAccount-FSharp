module BankAccountTest

open Xunit
open FsUnit
open BankAccountInterpreter.BankAccount
open BankAccountSpecification.Language

[<Fact>]
let ``Account can be updated from multiple threads`` () =
    let account =
        create ("1") |> makeOpen

    let updateAccountAsync =
        async {
            account
//            |> updateBalance (Credit { Amount = 1.0m })
            |> ignore
        }

    updateAccountAsync
    |> List.replicate 1000
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore

    balance account |> should equal (1000.0m)
