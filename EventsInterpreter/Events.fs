namespace EventsInterpreter

open EventStreamModule
open EventsSpecification.Language
open EventsSpecification.Mappers
open EventsSpecification.Specification
open BankAccountSpecification.Language
open Persistence

module Events =
    
    
    // Make some AccountId as a parameter
    let getCurrentState (accountId : string) (mapper : toDomainEvent<BankEvent, AccountEvent>) =
        let eventsToApply = accountId
                            |> EventStream.Instance.get
                            |> Async.RunSynchronously
                            |> function
                                | Ok resultOption ->
                                    match resultOption with
                                    | Some result ->
                                        result
                                        |> Seq.map mapper
                                    | None -> Seq.empty
                                | Error _ -> Seq.empty
        let currentState = accountId
                           |> AccountDatabase.Instance.get
                           |> Async.RunSynchronously
                           |> function
                               | Ok resultOption -> resultOption
                               | Error _ -> failwith "Failed"
//        
//        let aggregate = {
//            Current = currentState
//            (*
//            Execute : 'state -> 'command -> 'event
//            Apply : 'state -> 'event -> 'state
//            *)
//            Execute =
//            Apply = 
//        }
                               
        eventsToApply