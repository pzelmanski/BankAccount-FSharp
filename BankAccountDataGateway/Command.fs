namespace BankAccountDataGateway

open System
open BankAccountSpecification.Language
open EventsInterpreter2
open EventsSpecification.Language
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
        async {
            match! input with
            | Ok x -> return x
            | Error _ -> return None
        }
        |> Async.RunSynchronously

    let valueOrFail input =
        match (input |> resultOrFail) with
        | Some x -> x
        | None -> failwith "failed"


    let openAccount identity =
        identity
        |> AccountDatabase.Instance.get
        |> valueOrFail
        |> function
        | AllAccount.PreActivated p ->
            BankAccount.makeOpen p
            |> AllAccount.Opened
            |> AccountDatabase.Instance.upsert
        | _ -> failwith "Account is not pre-activated"

    let closeAccount identity =
        identity
        |> AccountDatabase.Instance.get
        |> valueOrFail
        |> function
        | AllAccount.Opened o ->
            BankAccount.close o
            |> AllAccount.Closed
            |> AccountDatabase.Instance.upsert
        | _ -> failwith "Account should be opened in order to close it"

    let insertMoney amount identity =
        let transaction =
            identity
            |> AccountDatabase.Instance.get
            |> valueOrFail
            |> function
            | AllAccount.Opened o ->
                (o, amount) ||> BankAccount.createTransaction
            | _ -> failwith "failed"

        let event ={
              BankEvent.Identity = Guid.NewGuid |> string
              BankEvent.Timestamp = DateTime.Now
              BankEvent.TypeAndContext = {
                  Identity = { Identity = identity } 
                  Context = transaction
              } |> BankEventInner.Transaction
        }

        event |> EventStream.Instance.insert
