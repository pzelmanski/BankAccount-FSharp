namespace EventsSpecification

module Specification =
    type execute<'state, 'command, 'event> =
        'state -> 'command -> 'event
    
    // take event
    // match it with possible event types
    // apply event on StateIn, to get stateOut
    // return stateOut
    type apply<'stateIn, 'event, 'stateOut> =
        'stateIn -> 'event -> 'stateOut
        
    type ExecuteCommand<'state, 'command, 'event> = 'state -> 'command -> 'event
    type ApplyCommand<'state, 'event> = 'state -> 'event -> 'state
    
    // 'state is AllAccount
    // Execute could potentially produce list of events
        // instead of a single event 
    type AggregateOfStateActions<'state, 'command, 'event> = {
        Current : 'state
        Execute : 'state -> 'command -> 'event
        Apply : 'state -> 'event -> 'state
    }