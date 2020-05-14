namespace IntegrationTests

open Xunit
open BankAccountViewModel

module BankAccountViewModelTests =
    [<Fact>]
    let ``When VM creates an account, it should be created`` () =
        async{
            // Act
            BankAccountViewModel.createAccount "asd"
            
            // Assert
            match BankAccountViewModel.getAccount "asd" with
            | Some account -> () //TODO: assert account
            | None -> failwith "no account found"
        }