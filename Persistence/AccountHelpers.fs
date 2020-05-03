namespace Persistance

open BankAccountSpecification.Language
open Persistance.Language

module AccountHelpers =
    let get (getAccount : unit -> Result<AllAccount, string>) (id : string) : Result<AllAccount, string>  =
        getAccount()
        
//    let add (addAccount : PreActivated)
