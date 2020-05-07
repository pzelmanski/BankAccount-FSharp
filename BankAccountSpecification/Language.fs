namespace BankAccountSpecification

module Language = 
    type Money = decimal
    type Amount = decimal
    
    type TransactionDetails =
          { Amount : Amount }
    
    type Transaction =
         | Debit of TransactionDetails
         | Credit of TransactionDetails
         
    type Transactions = Transaction list
    
    type Id = string
    type Account = { Identity : Id }
    
    // some draft of an idea for a persistance layer
    // list of accounts [id]
    // create an event (accountId : id)
    // find an account with accountId
    // changeBalance of given account
    
    type OpenedAccount =
        { Identity : Account
          Transactions : Transactions
          Balance : Amount}

    type ClosedAccount = { Identity : Account }
    
    type PreActivatedAccount = { Identity : Account }
        
    type AllAccount =
        | PreActivated of PreActivatedAccount
        | Opened of OpenedAccount
        | Closed of ClosedAccount
