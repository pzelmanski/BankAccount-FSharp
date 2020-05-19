namespace BankAccountSpecification

open Language

module Operations =
    // VM
    // transactions = Call DataGateway for GetTransactions
    // money = domain.ulits.ToBalance(transactions)
    // SendToClient(money)
    
//    type GetTransactions = AccountId -> AsyncResult<Transactions, string>
//    type ToBalance = Transactions -> Money
    type GetBalance = OpenedAccount -> Money
    type CreateBankAccount = string -> PreActivatedAccount
    type OpenAccount = PreActivatedAccount -> OpenedAccount
    type ChangeBalance = Transaction -> OpenedAccount -> OpenedAccount
    type TakeLastTransaction = OpenedAccount -> Transaction option
    type CreateTransaction = OpenedAccount -> Money -> Transaction
