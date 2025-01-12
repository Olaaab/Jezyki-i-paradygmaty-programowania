// Stw�rz funkcj�, kt�ra sprawdza, czy podany ci�g znak�w jest palindromem (czytany od przodu i od ty�u jest taki sam). Program powinien pobiera� tekst od u�ytkownika i wy�wietla� odpowiedni komunikat.

open System

let isPalindrome (text: string) =
    let cleanedText =
        text.ToLower()
        |> Seq.filter (fun c -> Char.IsLetterOrDigit(c)) 
        |> Seq.toArray

    let reversedText = Array.rev cleanedText
    cleanedText = reversedText

[<EntryPoint>]
let main _ =
    printfn "Podaj tekst:"
    let input = Console.ReadLine()
    
    if isPalindrome input then
        printfn "Podany ci�g jest palindromem."
    else
        printfn "Podany ci�g nie jest palindromem."

    0 
