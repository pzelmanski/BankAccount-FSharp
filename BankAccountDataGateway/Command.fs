namespace BankAccountDataGateway

open BankAccountSpecification.Language
open Persistance
open Persistence
open BankAccountInterpreter
open BankAccountSpecification

module Command =
    let addAccount identity =
        identity
        |> BankAccount.create
        |> AllAccount.PreActivated
        |> AccountDatabase.Instance.upsert
    
    let resultOrFail input =
        async{
            match! input with
            | Ok x -> return x
            | Error _ -> return None
        } |> Async.RunSynchronously
    
    let openAccount identity =
        identity
        |> AccountDatabase.Instance.get
        |> resultOrFail
        |> function
            | Some account -> account
                                |> function
                                    | AllAccount.PreActivated p -> BankAccount.makeOpen p
                                                                    |> AllAccount.Opened
                                                                    |> AccountDatabase.Instance.upsert
                                    | _ -> failwith "Account is not pre-activated"
            | None -> failwith "unable to get account"