// Stwórz aplikacjê, która symuluje podstawowe operacje bankowe.
open System

type Account = { AccountNumber: string; Balance: float }

let createAccount number initialBalance =
    { AccountNumber = number; Balance = initialBalance }

let deposit account amount =
    { account with Balance = account.Balance + amount }

let withdraw account amount =
    if amount <= account.Balance then
        { account with Balance = account.Balance - amount }
    else
        printfn "Brak wystarczaj¹cych œrodków."
        account

let displayBalance account =
    printfn "Saldo konta %s wynosi %.2f" account.AccountNumber account.Balance

[<EntryPoint>]
let main argv =
    let mutable currentAccount : Account option = None

    let rec menu () =
        printfn "1. Stwórz nowe konto"
        printfn "2. Depozyt"
        printfn "3. Wyp³ata"
        printfn "4. Wyœwietl saldo"
        printfn "5. Wyjœcie"
        printf "Wybierz opcjê: "

        match Console.ReadLine() with
        | "1" -> 
            printf "Podaj numer konta: "
            let number = Console.ReadLine()
            printf "Podaj saldo pocz¹tkowe: "
            let balance = Console.ReadLine() |> float
            currentAccount <- Some (createAccount number balance)
            printfn "Konto zosta³o utworzone!!\n"
            menu()
        | "2" -> 
            match currentAccount with
            | Some account ->
                printf "Podaj kwotê depozytu: "
                let amount = Console.ReadLine() |> float
                currentAccount <- Some (deposit account amount)
                menu()
            | None -> printfn "Musisz najpierw stworzyæ konto!!\n"; menu()
        | "3" -> 
            match currentAccount with
            | Some account ->
                printf "Podaj kwotê do wyp³aty: "
                let amount = Console.ReadLine() |> float
                currentAccount <- Some (withdraw account amount)
                menu()
            | None -> printfn "Musisz najpierw stworzyæ konto!!\n"; menu()
        | "4" -> 
            match currentAccount with
            | Some account -> displayBalance account; menu()
            | None -> printfn "Musisz najpierw stworzyæ konto!!\n"; menu()
        | "5" -> printfn "Do widzenia!!"
        | _ -> 
            printfn "Nieprawid³owy wybór."
            menu()
    
    menu()
    0
