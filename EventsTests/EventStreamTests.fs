namespace EventsTests

open EventsInterpreter.EventStreamModule
open Xunit

module EventStreamTests = 
    [<Fact>]
    let ``When adding to AccountDatabase it should persist`` () =
        async {
            let r = EventStream.Instance.insert "asd" "Event"

            match! r with
            | Ok _ ->
                let! r2 = EventStream.Instance.get "asd"
                match r2 with
                | Ok bankAccountEventOption ->
                    match bankAccountEventOption with
                        | Some _ -> ()
                        | None -> failwith "account not existing"
                | Error e -> failwith e
            | Error e -> failwith e
        }
