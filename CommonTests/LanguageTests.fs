namespace CommonTests


open Xunit
module AsyncResultTests =
    let dummy: Async<Result<int, string>> =
        async { return Ok 15 }
    let dummy2 : Async<Result<int, string>> =
        15 |> Ok |> async.Return

    [<Fact>]
    let ``AsyncResult test`` () =
        let x = dummy |> Async.RunSynchronously
        Assert.Equal(x, Ok 15)
    
    [<Fact>]
    let ``AsyncResult test2`` () = async{
        let! x = dummy2
        Assert.Equal(x, Ok 15)}


