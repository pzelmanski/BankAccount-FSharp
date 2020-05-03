namespace Persistance

open BankAccountSpecification.Language
open Persistance.Language

module persistanceHelpers =
    let getAccount (getAccount : unit -> Result<AllAccount, string>) (id : string) : Result<AllAccount, string>  =
        getAccount()
    
//module persistance =
