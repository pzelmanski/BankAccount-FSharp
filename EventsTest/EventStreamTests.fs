namespace EventsTest

open System
open EventsInterpreter2
open Xunit
open FsUnit

module EventStreamTests =
    let getUniqueEventId () =
        (Guid.NewGuid() |> string)
    
    [<Fact>]
    let ``When adding to EventStream, it should persist`` () =
        async {
            let eventId = getUniqueEventId()
            do! EventStream.Instance.insert <| EventsFactory.getAccountCreateEvent(eventId) |> Async.Ignore
            
            let! result = EventStream.Instance.getAll()
            let resultFiltered = result
                                 |> Seq.where(fun x -> x.Identity = eventId)
                                 |> Seq.toList
            match resultFiltered with
            | _::[] -> ()
            | _ -> failwith "expected a single element"
        }

    [<Fact>]
    let ``When inserting multiple events, it should persist`` () =
        async {
            let eventId1 = getUniqueEventId()
            let eventId2 = getUniqueEventId()
            do! EventStream.Instance.insert <| EventsFactory.getAccountCreateEvent(eventId1)
                    |> Async.Ignore
            do! EventStream.Instance.insert <| EventsFactory.getAccountCreateEvent(eventId2)
                    |> Async.Ignore
            let! result = EventStream.Instance.getAll()
            result
                |> Seq.where(fun x -> x.Identity = eventId1 || x.Identity = eventId2)
                |> Seq.length |> should equal 2
            match result |> Seq.toList with
            | _::_::[] -> ()
            | _ -> failwith "Expected to be two elements"
        }
