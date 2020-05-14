namespace PersistanceTests

open Persistence
open Xunit
open BankAccountSpecification.Language
open BankAccountInterpreter

module PersistenceHelpersTests =
    [<Fact>]
    let ``When adding to AccountDatabase it should persist`` () =
        async {
            let r = BankAccount.create ("1")
                    |> AllAccount.PreActivated
                    |> AccountDatabase.Instance.upsert

            match! r with
            | Ok _ ->
                let! r2 = AccountDatabase.Instance.get "1"
                match r2 with
                | Ok account ->
                    match account with
                        | Some account -> match account with
                                            | PreActivated _ -> ()
                                            | _ -> failwith "account is not in opened state"
                        | None -> failwith "account not existing"
                | Error e -> failwith e
            | Error e -> failwith e
        }
