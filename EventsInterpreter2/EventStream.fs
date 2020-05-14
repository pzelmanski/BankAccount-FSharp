namespace EventsInterpreter2

open EventsSpecification.Language

type EventStream private () =
    let mutable eventStream: seq<BankEvent> = Seq.empty
    static let instance = EventStream()
    static member Instance = instance
    member this.getAll() = async { return eventStream }

    member this.insert(event: BankEvent) =
        async {
            eventStream <- Seq.append eventStream (seq [ event ])
            return Ok()
        }
