namespace EventsSpecification

open System

module Language =
    type AccountLanguageOperation =
        | CreateAccount
        | OpenAccount
        | CloseAccount
    type AccountLanguageTransaction = BankAccountSpecification.Language.Transaction
    type AccountLanguageIdentity = BankAccountSpecification.Language.Account
    
    type BankEventType = string

    type TransactionEvent = {
        Identity: AccountLanguageIdentity
        Context: AccountLanguageTransaction
    }
    
    type AccountOperationEvent = {
        Identity: AccountLanguageIdentity
        Context: AccountLanguageOperation
    }
    
    type BankEventInner =
        | AccountOperation of AccountOperationEvent
        | Transaction of TransactionEvent
    
    type BankEvent = {
        Identity : string
        Timestamp: DateTime
        TypeAndContext: BankEventInner
        }