namespace IntegrationTests

open System
open EventsInterpreter2
open Xunit
open BankAccountViewModel
open BankAccountSpecification.Language
open FsUnit

module BankAccountViewModelTests =
    let getUniqueId () =
        Guid.NewGuid() |> string
    
    [<Fact>]
    let ``When VM creates an account, it should be created`` () =
        // Arrange
        let accountId = getUniqueId()
        
        // Act
        BankAccountViewModel.createAccount accountId
        
        // Assert
        match BankAccountViewModel.getAccount accountId with
        | Some account -> match account with
                          | PreActivated _ -> ()
                          | _ -> failwith "account should be pre-activated"
        | None -> failwith "no account found"

    [<Fact>]
    let ``VM should be able to open account`` () =
        // Arrange
        let accountId = getUniqueId()
        BankAccountViewModel.createAccount accountId
        
        // Act
        BankAccountViewModel.openAccount accountId
        
        // Assert
        match BankAccountViewModel.getAccount accountId with
        | Some account -> match account with
                          | Opened _ -> ()
                          | _ -> failwith "should be open"
        | None -> failwith "account not found"
        
    [<Fact>]
    let ``VM should be able to close account`` () =
        // Arrange
        let accountId = getUniqueId()
        
        BankAccountViewModel.createAccount accountId
        BankAccountViewModel.openAccount accountId
        
        // Act
        BankAccountViewModel.closeAccount accountId  
        
        // Assert
        match BankAccountViewModel.getAccount accountId with
        | Some account -> match account with
                          | Closed _ -> ()
                          | _ -> failwith "should be open"
        | None -> failwith "account not found"
        
    [<Fact>]
    let ``when adding monies it should add transaction to event stream`` () =
        // Arrange
        let accountId = getUniqueId()
        
        BankAccountViewModel.createAccount accountId
        BankAccountViewModel.openAccount accountId
        
        // Act
        BankAccountViewModel.insertMoney accountId 9.81m
        
        // Assert
        async{
        let! event = EventStream.Instance.getByAccountIdentity accountId
        event |> Seq.length |> should equal 1
        } 
