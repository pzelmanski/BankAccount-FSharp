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
    
    type AccountOperationEvent = {
        Identity: AccountLanguageIdentity
        Context: AccountLanguageOperation
    }
    
    type TransactionOperationEvent = {
        Identity: AccountLanguageIdentity
        Context: AccountLanguageTransaction
    }
    
    type BankEventInner =
        | AccountOperation of AccountOperationEvent
        | Transaction of TransactionOperationEvent
    
    type BankEvent = {
        Identity : string
        Timestamp: DateTime
        TypeAndContext: BankEventInner
        }