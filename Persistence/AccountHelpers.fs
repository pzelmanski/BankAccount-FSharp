namespace Persistance

open BankAccountSpecification.Language

module AccountHelpers =
    let get (getAccount : unit -> Result<AllAccount, string>) (id : string) : Result<AllAccount, string>  =
        getAccount()
        
    let add addAccount newAccount : Result<unit, string> =
        addAccount newAccount
