namespace BankAccount

open BankAccountSpecification.Language

module CreditDebit =
    let create amount =
        if(amount > 0m)
        then Some({Amount = amount})
        else None
