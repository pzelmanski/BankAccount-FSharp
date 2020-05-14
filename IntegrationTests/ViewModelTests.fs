namespace IntegrationTests

open Xunit
open BankAccountViewModel
open BankAccountSpecification.Language

module BankAccountViewModelTests =
    [<Fact>]
    let ``When VM creates an account, it should be created`` () =
        // Act
        BankAccountViewModel.createAccount "asd"
        
        // Assert
        match BankAccountViewModel.getAccount "asd" with
        | Some account -> match account with
                          | PreActivated _ -> ()
                          | _ -> failwith "account should be pre-activated"
        | None -> failwith "no account found"

    [<Fact>]
    let ``VM should be able to open account`` () =
        // Arrange
        BankAccountViewModel.createAccount "1"
        
        // Act
        BankAccountViewModel.openAccount "1"
        
        // Assert
        match BankAccountViewModel.getAccount "1" with
        | Some account -> match account with
                          | Opened _ -> ()
                          | _ -> failwith "should be open"
        | None -> failwith "account not found"
        
    