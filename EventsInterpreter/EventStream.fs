namespace EventsInterpreter
open EventsSpecification.Language

module EventStreamModule =
    type EventStream private () =
        let mutable events: Map<StreamId, seq<BankEvent>> = Map.empty
        static let instance = EventStream()
        static member Instance = instance

        (*
        // account number = streamId
        
        Person A
            - Account 1
                - GetBalance
                - GetActiveCreditCards
                - EventStream 1
                    - streamId
                        - "transactions"
                            -> List of transaction to calculate balance
                        - "PaymentInfo"
                            -> List of active credit cards
            - Account 2
                -EventStream 2
        *)
        
        
        member this.get streamId =
            async {
                return streamId
                       |> events.TryFind
                       |> function
                           | Some x -> Ok(Some x)
                           | None -> Ok(None)
            }

        member this.insert streamId event =
            async {
                streamId |> events.TryFind
                |> function
                    | Some e -> events <- events.Add(streamId, event::(e |> Seq.toList))
                    | None -> events <- events.Add(streamId, [event])
                return Ok()
            }