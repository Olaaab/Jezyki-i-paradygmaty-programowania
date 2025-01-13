// Stw�rz aplikacj�, kt�ra symuluje podstawowe operacje bankowe.
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
        printfn "Brak wystarczaj�cych �rodk�w."
        account

let displayBalance account =
    printfn "Saldo konta %s wynosi %.2f" account.AccountNumber account.Balance

[<EntryPoint>]
let main argv =
    let mutable currentAccount : Account option = None

    let rec menu () =
        printfn "1. Stw�rz nowe konto"
        printfn "2. Depozyt"
        printfn "3. Wyp�ata"
        printfn "4. Wy�wietl saldo"
        printfn "5. Wyj�cie"
        printf "Wybierz opcj�: "

        match Console.ReadLine() with
        | "1" -> 
            printf "Podaj numer konta: "
            let number = Console.ReadLine()
            printf "Podaj saldo pocz�tkowe: "
            let balance = Console.ReadLine() |> float
            currentAccount <- Some (createAccount number balance)
            printfn "Konto zosta�o utworzone!!\n"
            menu()
        | "2" -> 
            match currentAccount with
            | Some account ->
                printf "Podaj kwot� depozytu: "
                let amount = Console.ReadLine() |> float
                currentAccount <- Some (deposit account amount)
                menu()
            | None -> printfn "Musisz najpierw stworzy� konto!!\n"; menu()
        | "3" -> 
            match currentAccount with
            | Some account ->
                printf "Podaj kwot� do wyp�aty: "
                let amount = Console.ReadLine() |> float
                currentAccount <- Some (withdraw account amount)
                menu()
            | None -> printfn "Musisz najpierw stworzy� konto!!\n"; menu()
        | "4" -> 
            match currentAccount with
            | Some account -> displayBalance account; menu()
            | None -> printfn "Musisz najpierw stworzy� konto!!\n"; menu()
        | "5" -> printfn "Do widzenia!!"
        | _ -> 
            printfn "Nieprawid�owy wyb�r."
            menu()
    
    menu()
    0
