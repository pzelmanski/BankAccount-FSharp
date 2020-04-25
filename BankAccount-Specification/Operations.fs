namespace BankAccount_Specification.Operations

open BankAccount_Specification.Language

module Operations =
    type GetBalance = OpenedAccount -> Money
    type CreateBankAccount = unit -> PreActivatedAccount
    type OpenAccount = PreActivatedAccount -> OpenedAccount
    