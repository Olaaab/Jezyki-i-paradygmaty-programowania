 //Napisz program, który pozwala u¿ytkownikowi na konwersjê kwoty z jednej waluty na inn¹. Program powinien pobieraæ od u¿ytkownika: 
//• Kwotê do przeliczenia. 
//• Walutê Ÿród³ow¹ (np. USD, EUR, GBP). 
//• Walutê docelow¹.

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
    printfn "Podaj kwotê do przeliczenia: "
    let amount = Console.ReadLine() |> float

    printfn "Podaj walutê Ÿród³ow¹: "
    let fromCurrency = Console.ReadLine()

    printfn "Podaj walutê docelow¹: "
    let toCurrency = Console.ReadLine()

    if Map.containsKey fromCurrency exchangeRates && Map.containsKey toCurrency exchangeRates then
        let convertedAmount = convertCurrency amount fromCurrency toCurrency
        printfn "Przeliczona kwota: %.2f %s" convertedAmount toCurrency
    else
        printfn "B³¹d, nieprawid³owa waluta."

    0
