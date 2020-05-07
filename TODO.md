# TODO:
[X] GetAccount returns Ok None if no record found but wihout an exception
[X] AsyncResult -> add it into AccountHelpers at Persistance layer
[ ] Build TestAPI -> factories for mocks (or stubs or sth)
    [ ] Add a factory for persistance tests
[ ] Add an event store
[ ] Make sure that Credit and Debit are positive
[X] Implement Transactions (balance)
[ ] Use more aliases to manage amiguity
[X] Improve Persistance layer
    [X] Adding account
    [X] Getting account
    [X] Updating account
[ ] Custom equals for entity types
[ ] Try to create project per bounded context OR add NoEquality on entities to prevent checking for equality
[ ] Treat an account as an aggregate root. It should take care of calculating balance every time a transaction comes in.
[X] Add Result<> type and handle errors
[ ] Add validation of domain rules (transaction always > 0) via private ctor & factory method returning Result<'a>
    * Then to get the value in pattern matching, I'd use the value function for returning the wrapped value `let value(UnitQty qty) = qty`