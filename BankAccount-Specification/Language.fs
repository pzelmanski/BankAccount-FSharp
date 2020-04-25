namespace BankAccount_Specification

module Language = 
    type Money = decimal
    type Amount = decimal
    type Details = string
    type TransactionDetails =
          { Amount : Amount
            Details : Details }
    
    type Transaction =
         | Debit of TransactionDetails
         | Credit of TransactionDetails
        
    type Transactions = Transaction list
    
    type Account =
        { History : Transactions
    }
