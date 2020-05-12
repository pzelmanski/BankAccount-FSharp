namespace EventsSpecification

open System

module Language =
    type AccountLanguageOperation = BankAccountSpecification.Language.Operation
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
        Timestamp: DateTime
        TypeAndContext: BankEventInner
        }