namespace Persistance

open BankAccountSpecification.Language
open Persistance.Language

module persistanceHelpers =
    let getAccount (persistance : AccountDatabase) (id : string) : AllAccount  =
        persistance.getAccount()
    
//module persistance =
