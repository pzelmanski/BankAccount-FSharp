namespace EventsTests
//
//open EventsInterpreter.EventStreamModule
//open Xunit
//
//module EventStreamTests = 
//    [<Fact>]
//    let ``When adding to AccountDatabase it should persist`` () =
//        async {
//            let! _ = EventStream.Instance.insert "Event"
//            
//            let! result = EventStream.Instance.getAll
//            match result |> Seq.toList with
//            | _::[] -> ()
//            | _ -> failwith "expected a single element"
//        }
//
//    [<Fact>]
//    let ``When inserting multiple events it should persist`` () =
//        async {
//            let! _ = EventStream.Instance.insert "Event"
//            let! _ = EventStream.Instance.insert "Event2"
//            
//            let! result = EventStream.Instance.getAll
//            match result |> Seq.toList with
//            | _::_::[] -> ()
//            | _ -> failwith "Expected to be two elements"
//        }
