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
    
    type OpenedAccount =
        { Account : Account
          Transactions : Transactions
          Balance : Amount}

    type ClosedAccount =
        | ClosedAccount of Account
    
    type PreActivatedAccount =
        | PreActivatedAccount of Account