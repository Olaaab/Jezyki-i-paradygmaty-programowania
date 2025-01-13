// Zadanie 1. Stwórz aplikacjê konsolow¹, która oblicza wskaŸnik masy cia³a (BMI) u¿ytkownika na podstawie wprowadzonych przez niego wagi (kg) i wzrostu (cm). Program powinien komunikowaæ siê z 
// u¿ytkownikiem, odczytywaæ dane wejœciowe, przeliczaæ BMI i wyœwietlaæ wynik wraz z kategori¹ BMI.

open System

type User = {
    Weight: float
    Height: float
}

let calculateBMI (weight: float) (heightCm: float) : float =
    let heightM = heightCm / 100.0
    weight / (heightM ** 2.0)


let getBMICategory (bmi: float) : string =
    if bmi < 18.5 then "Niedowaga"
    elif bmi >= 18.5 && bmi < 24.9 then "Waga prawid³owa"
    elif bmi >= 25.0 && bmi < 29.9 then "Nadwaga"
    else "Oty³oœæ"

[<EntryPoint>]
let main argv =
    printfn "Czeœæ! Obliczmy Twój wskaŸnik BMI."

    printf "Podaj swoj¹ wagê (w kilogramach): "
    let weightInput = Console.ReadLine()
    let weight = 
        match Double.TryParse(weightInput) with
        | (true, value) -> value
        | _ -> 
            printfn "Niepoprawna wartoœæ dla wagi. Uruchom program ponownie."
            0.0  

    printf "Podaj swój wzrost (w centymetrach): "
    let heightInput = Console.ReadLine()
    let height = 
        match Double.TryParse(heightInput) with
        | (true, value) -> value
        | _ -> 
            printfn "Niepoprawna wartoœæ dla wzrostu. Uruchom program ponownie."
            0.0  

    let user = { Weight = weight; Height = height }
    
    let bmi = calculateBMI user.Weight user.Height
    printfn "Twoje BMI wynosi: %.2f" bmi
    
    let category = getBMICategory bmi
    printfn "Twoja kategoria BMI: %s" category
    
    0 
