namespace PersistanceTests

open System
open Persistance
open Persistance.Language
open Xunit
open FsUnit.Xunit
open BankAccountSpecification.Language


module PersistanceHelpersTests = 
    [<Fact>]
    let ``AccountDatabase should be empty on init`` () =
        AccountDatabase.Instance.Accounts
        |> List.isEmpty
        |> should equal true
        
    [<Fact>]
    let ``When adding to AccountDatabase it should persist`` () =
//        account
//        |> persistanceHelpers.addAccount
        
        // TODO: this is all hardcoded for now
        AccountHelpers.get AccountDatabase.Instance.getAccount "id"
        |> function
            | Ok _ ->
                function
                    | Opened x -> x.Balance |> should equal 1m
                    | _ -> failwith "account not found"
            | _ -> failwith "account not found"
//        BankAccount.create ()
//        |> ``open``
//        |> updateBalance (Debit { Amount = 10m })
//        |> takeLastTransaction
//        |> should equal (Some(Debit { Amount = 10m }))
