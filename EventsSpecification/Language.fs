namespace EventsSpecification

open System

module Language =
    type BankEvent = string
    
    
    type CreateAccountType = {
        Id : int
        Data : string
    }
    
    type OpenAccountType = {
        I2d : string
        Timestamp : DateTime
    }
    
    // I've got some initial state
    // I've got some list of events
    // I apply events on initial state via List.fold
    // I persist state as current
        // Mark somehow which events are applied
    // When a new event appears, I apply this event (or list of events)
        // onto current state
        // Mark event as applied
    // Save state as current
    
    
    // BankCommand generates BankEvent2 
    type BankCommand =
        | CreateAccount of CreateAccountType
        | OpenAccount of OpenAccountType
        | TodoOtherTypes
    
    type BankEvent2 =
        | AccountCreated of CreateAccountType
        | AccountOpened of OpenAccountType
        | TodoOtherTypes
        
    
    type StreamId = string


