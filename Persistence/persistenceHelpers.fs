namespace Persistance

open BankAccountSpecification.Language
open Persistance.Language

module persistenceHelpers =
    let getAccount (getAccount : unit -> Result<AllAccount, string>) (id : string) : Result<AllAccount, string>  =
        getAccount()
        
    
