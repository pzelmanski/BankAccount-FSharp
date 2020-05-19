namespace EventsTest

open System
open EventsInterpreter2
open Xunit
open FsUnit

module EventStreamTests =
    let getUniqueId () =
        (Guid.NewGuid() |> string)
    
    [<Fact>]
    let ``When adding to EventStream, it should persist`` () =
        async {
            let eventId = getUniqueId()
            let accountId = getUniqueId()
            do! EventStream.Instance.insert <| ((eventId, accountId) ||> EventsFactory.getAccountCreateEvent) |> Async.Ignore
            
            let! result = EventStream.Instance.getByAccountIdentity(accountId)
            match result |> Seq.toList with
            | _::[] -> ()
            | _ -> failwith "expected a single element"
        }

    [<Fact>]
    let ``When inserting multiple events, it should persist`` () =
        async {
            let eventId1 = getUniqueId()
            let eventId2 = getUniqueId()
            let accountId = getUniqueId()
            
            do! accountId
                |> EventsFactory.getAccountCreateEvent eventId1
                |> EventStream.Instance.insert
                |> Async.Ignore
            do! accountId
                |> EventsFactory.getAccountCreateEvent eventId2
                |> EventStream.Instance.insert
                |> Async.Ignore
            let! result = EventStream.Instance.getByAccountIdentity(accountId)
            result |> Seq.length |> should equal 2
        }
