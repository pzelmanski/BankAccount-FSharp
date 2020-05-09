namespace EventsSpecification

module Mappers =
    type toDomainEvent<'bankEvent, 'domainEvent> =
        'bankEvent -> 'domainEvent
