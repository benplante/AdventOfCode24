﻿open System

let isSafe (report: int seq) =
    let values =
        report
        |> Seq.pairwise
        |> Seq.map (fun (a, b) -> b - a)

    values |> Seq.forall (function -3 | -2 | -1 -> true | _ -> false) ||
    values |> Seq.forall (function 3 | 2 | 1 -> true | _ -> false)

let parse (report: string) =
    report.Split " " |> Seq.map int

Seq.initInfinite (fun _ -> stdin.ReadLine())
|> Seq.takeWhile (fun s -> not (String.IsNullOrWhiteSpace s))
|> Seq.map parse
|> Seq.where isSafe
|> Seq.length
|> printf "%d"
