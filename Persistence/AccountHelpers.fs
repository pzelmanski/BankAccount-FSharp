namespace Persistance

open BankAccountSpecification.Language
open Common.Language

module AccountHelpers =
    let get (getAccount : string -> AsyncResult<AllAccount, string>) (id : string) : AsyncResult<AllAccount, string>  =
        getAccount id
        
    let add addAccount newAccount : AsyncResult<unit, string> =
        addAccount newAccount
