open System

let read parser =
    Seq.initInfinite (fun _ -> Console.ReadLine())
    |> Seq.takeWhile (fun s -> not (String.IsNullOrWhiteSpace s))
    |> Seq.choose parser
    |> Seq.fold (fun (l1, l2) (i1, i2) -> (i1::l1, i2::l2)) ([], [])


let parse (s: string) =
    let parts = s.Split (" ", StringSplitOptions.TrimEntries ||| StringSplitOptions.RemoveEmptyEntries)
    match parts with
    | [|a; b|] -> Some (Int32.Parse a, Int32.Parse b)
    | _ -> None

let left, right = read parse

let result =
    List.zip (List.sort left) (List.sort right)
    |> List.map (fun (a, b) -> Math.Abs (a - b))
    |> List.sum

printfn $"%d{result}"


