 //Napisz program, kt�ry pozwala u�ytkownikowi na konwersj� kwoty z jednej waluty na inn�. Program powinien pobiera� od u�ytkownika: 
//� Kwot� do przeliczenia. 
//� Walut� �r�d�ow� (np. USD, EUR, GBP). 
//� Walut� docelow�.

open System

let exchangeRates = Map [
    ("PLN", 4.0)
    ("EUR", 0.85)
    ("GBP", 0.75)
    ("USD", 1.0)
    ("JPY", 110.0)  
    ("CHF", 0.92)  
    ("AUD", 1.3)   
    ("CAD", 1.25)         
]

let convertCurrency amount fromCurrency toCurrency =
    let rateFrom = Map.find fromCurrency exchangeRates
    let rateTo = Map.find toCurrency exchangeRates
    amount * (rateTo / rateFrom)

[<EntryPoint>]
let main argv =
    printfn "Podaj kwot� do przeliczenia: "
    let amount = Console.ReadLine() |> float

    printfn "Podaj walut� �r�d�ow�: "
    let fromCurrency = Console.ReadLine()

    printfn "Podaj walut� docelow�: "
    let toCurrency = Console.ReadLine()

    if Map.containsKey fromCurrency exchangeRates && Map.containsKey toCurrency exchangeRates then
        let convertedAmount = convertCurrency amount fromCurrency toCurrency
        printfn "Przeliczona kwota: %.2f %s" convertedAmount toCurrency
    else
        printfn "B��d, nieprawid�owa waluta."

    0
