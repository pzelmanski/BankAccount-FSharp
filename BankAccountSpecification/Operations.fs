namespace BankAccountSpecification

open Language

module Operations =
    type GetBalance = OpenedAccount -> Money
    type CreateBankAccount = unit -> PreActivatedAccount
    type OpenAccount = PreActivatedAccount -> OpenedAccount
    type ChangeBalance = Money -> OpenedAccount -> OpenedAccount
