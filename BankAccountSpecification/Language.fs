namespace BankAccountSpecification

open System


module Language = 
    type Money = decimal
    type Amount = decimal
    
    type Account = { Identity : string }
    
    type TransactionDetails =
          {
              Identity : Account
              TimeStamp : DateTime
              Amount : Amount
          }
    
    type Transaction =
         | Debit of TransactionDetails
         | Credit of TransactionDetails
         
    type Transactions = Transaction list
    
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
