# TODO:
[ ] Add domain operations into BankAccountViewModel
    [ ] Open / close account
        [X] create account
        [X] open account
        [X] close account
    [ ] Make a transaction
    [ ] Get events and determine state of the account
    [ ] Get events and calculate balance given transactions
[ ] Implement ATM Module
[ ] Build TestAPI [its not exactly testApi] -> factories for mocks (or stubs or sth)
    [ ] Add a factory for persistance tests
[ ] Add Data gateway operations into BankAccount.Operations module
[ ] Use more aliases to manage amiguity
[ ] expand event test factory
[ ] Implement event consuming within BankAccount module
[ ] Make sure that Credit and Debit are positive
[ ] Add validation of domain rules (transaction always > 0) via private ctor & factory method returning Result<'a>
    * Then to get the value in pattern matching, I'd use the value function for returning the wrapped value `let value(UnitQty qty) = qty`
[ ] Custom equals for entity types
[ ] Try to create project per bounded context OR 
[ ] NoEquality on entities to prevent checking for equality
[ ] Treat an account as an aggregate root. It should take care of calculating balance every time a transaction comes in.
[X] GetAccount returns Ok None if no record found but wihout an exception
[X] AsyncResult -> add it into AccountHelpers at Persistance layer
[X] Fix tests for event stream
    [X] Create factory of events
    [X] Use it
[X] Add an event store
[X] Add ATM Module
[X] EventStream is created per account
    [X] Get rid of StreamId. Have a single EventStream, global for the whole system. (take a look at events drawing in /Notes/)
    [X] StreamId identifies a series of events within account which can be used to get latest state of a single entity within account
[X] Create proper BankEvent type
    [X] Implement credit / debit
    [X] Implement open / close account
[X] Implement Transactions (balance)
[X] Improve Persistance layer
    [X] Adding account
    [X] Getting account
    [X] Updating account
[X] Add Result<> type and handle errors