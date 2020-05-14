namespace EventsTest

open EventsInterpreter2
open Xunit
open FsUnit

module EventStreamTests = 
    [<Fact>]
    let ``When adding to EventStream, it should persist`` () =
        async {
            do! EventStream.Instance.insert <| EventsFactory.getAccountCreateEvent() |> Async.Ignore
            
            let! result = EventStream.Instance.getAll()
            match result |> Seq.toList with
            | _::[] -> ()
            | _ -> failwith "expected a single element"
        }

    [<Fact>]
    let ``When inserting multiple events, it should persist`` () =
        async {
            do! EventStream.Instance.insert <| EventsFactory.getAccountCreateEvent()
                    |> Async.Ignore
            do! EventStream.Instance.insert <| EventsFactory.getAccountCreateEvent()
                    |> Async.Ignore
            let! result = EventStream.Instance.getAll()
            result |> Seq.length |> should equal 2
            // TODO: Fix this
//            match result |> Seq.toList with
//            | _::_::[] -> ()
//            | _ -> failwith "Expected to be two elements"
        } 
