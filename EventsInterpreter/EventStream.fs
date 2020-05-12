namespace EventsInterpreter
open EventsSpecification.Language

module EventStreamModule =
    type EventStream private () =
        let mutable events: seq<BankEvent> = Seq.empty
        static let instance = EventStream()
        static member Instance = instance
        member this.getAll =
            async {
                return events
            }

        member this.insert event =
            async {
                events <- Seq.append events (seq [event])
                return Ok()
            }