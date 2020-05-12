namespace EventsInterpreter
open EventsSpecification.Language

module EventStreamModule =
    type EventStream private () =
        let mutable eventStream: seq<BankEvent> = Seq.empty
        static let instance = EventStream()
        static member Instance = instance
        member this.getAll =
            async {
                return eventStream
            }

        member this.insert event =
            async {
                eventStream <- Seq.append eventStream (seq [event])
                return Ok()
            }