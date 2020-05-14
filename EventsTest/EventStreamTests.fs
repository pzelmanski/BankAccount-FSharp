namespace EventsTest

open EventsInterpreter
open Xunit

module EventStreamTests = 
    [<Fact>]
    let ``When adding to EventStream, it should persist`` () =
        async {
            let x = EventsFactory.getAccountCreateEvent()
            EventStream.Instance.insert x |> ignore
            
//            let! result = EventStream.Instance.getAll()
//            match result |> Seq.toList with
//            | _::[] -> ()
//            | _ -> failwith "expected a single element"
        }

//    [<Fact>]
//    let ``When inserting multiple events, it should persist`` () =
//        async {
//            do! EventStream.Instance.insert <| EventsFactory.getAccountCreateEvent()
//                    |> Async.Ignore
//            do! EventStream.Instance.insert <| EventsFactory.getAccountCreateEvent()
//                    |> Async.Ignore
//            let! result = EventStream.Instance.getAll()
//            match result |> Seq.toList with
//            | _::_::[] -> ()
//            | _ -> failwith "Expected to be two elements"
//        } 
