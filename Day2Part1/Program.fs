// For more information see https://aka.ms/fsharp-console-apps
open System

let isSafe (report: string) =
    let values =
        report.Split (" ", StringSplitOptions.TrimEntries ||| StringSplitOptions.RemoveEmptyEntries)
        |> Seq.map Int32.Parse
        |> Seq.pairwise
        |> Seq.map (fun (a, b) -> b - a)


    values |> Seq.forall (function -3 | -2 | -1 -> true | _ -> false) ||
    values |> Seq.forall (function 3 | 2 | 1 -> true | _ -> false)





Seq.initInfinite (fun _ -> Console.ReadLine())
|> Seq.takeWhile (fun s -> not (String.IsNullOrWhiteSpace s))
|> Seq.where isSafe
|> Seq.length
|> printf "%d"
