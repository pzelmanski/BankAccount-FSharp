namespace BankAccount_Specification

module Language = 
    type Money = decimal
    type Amount = decimal
//    type Details = string
//    type TransactionDetails =
//          { Amount : Amount
//            Details : Details }
//    
//    type Transaction =
//         | Debit of TransactionDetails
//         | Credit of TransactionDetails
//        
//    type Transactions = Transaction list

//    type Transaction =
//         | Debit of TransactionDetails
//         | Credit of TransactionDetails
    type Id = string
    type Account = { Identity : Id }
    
    type OpenedAccount =
        { Account : Account
          Balance : Amount}

    type ClosedAccount =
        | ClosedAccount of Account
    
    type PreActivatedAccount =
        | PreActivatedAccount of Account