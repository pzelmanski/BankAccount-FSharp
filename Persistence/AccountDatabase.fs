namespace Persistence

open BankAccountSpecification.Language
open System
open Persistance.Language

type AccountDatabase private () =
    static let instance = AccountDatabase()
    static member Instance = instance
    member this.Accounts : AllAccounts = []
    
    member this.getAccount() =
        Ok (Opened <| { Identity = {Identity = Guid.NewGuid() |> string }
                        Transactions = []
                        Balance = 1m })
    
//    member this.addAccount(account) =
//        let x =  this.Accounts = this.Accounts::account
//        Ok ()
