namespace PersistanceTests

open Persistance
open Persistence
open Xunit
open FsUnit
open BankAccountSpecification.Language
open BankAccountInterpreter

module PersistanceHelpersTests =
    [<Fact>]
    let ``When adding to AccountDatabase it should persist`` () =
        async {
            let r = BankAccount.create () |> AccountHelpers.add AccountDatabase.Instance.addAccount

            match! r with
            | Ok _ ->
                let! r2 = AccountHelpers.get AccountDatabase.Instance.getAccount "1"
                match r2 with
                | Ok account ->
                    match account with
                    | Opened x -> x.Balance |> should equal 1m
                    | _ -> failwith "account not found"
                | Error e -> failwith e
            | Error e -> failwith e
        }
