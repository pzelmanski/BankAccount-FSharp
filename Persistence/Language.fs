namespace Persistance

open System
open BankAccountSpecification.Language

module Language =
    // Singleton example:
    //type A private () =
    //    static let instance = A()
    //    static member Instance = instance
    //    member this.Action() = printfn "action"
    //
    //let DesignPatter1() = 
    //    let a = A.Instance;
    //    a.Action()
    
    type AllAccounts = AllAccount list
    type AccountDatabase private () =
        static let instance = AccountDatabase()
        static member Instance = instance
        member this.Accounts : AllAccounts = []
        member this.getAccount() =
            Ok (Opened <| { Identity = {Identity = Guid.NewGuid() |> string }
                            Transactions = []
                            Balance = 1m })
            
            // this should be closer to domain logic, not persistance
//            instance.Accounts.Head
            // with
//                | Opened x -> 6
//                | Closed x -> 6
//                | PreActivated x -> 6
