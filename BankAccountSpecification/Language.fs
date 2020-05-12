namespace BankAccountSpecification


module Language = 
    type Money = decimal
    type Amount = decimal
    
    type TransactionDetails =
          { Amount : Amount }
    
    type Transaction =
         | Debit of TransactionDetails
         | Credit of TransactionDetails
         
    
    type Operation =
        | CreateAccount
        | OpenAccount
        | CloseAccount
    
    type Id = string
    type Account = { Identity : Id }
    
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
