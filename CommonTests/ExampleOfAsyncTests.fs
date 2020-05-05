namespace CommonTests

open Xunit
module AsyncResultTests =
    let dummy: Async<Result<int, string>> =
        async { return Ok 15 }
    let dummy2 : Async<Result<int, string>> =
        15 |> Ok |> async.Return

    [<Fact>]
    let ``AsyncResult test`` () =
        async {
            match! dummy with
                | Error msg -> failwith msg
                | Ok _ -> ()
        } |> Async.RunSynchronously
    
    [<Fact>]
    let ``AsyncResult test2`` () = async{
        let! result = dummy2
        Assert.Equal(result, Ok 15)}
