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
