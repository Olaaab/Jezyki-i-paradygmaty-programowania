// Zaproponuj system do zarz¹dzania kontami bankowymi, który bêdzie implementowa³ operacje CRUD. 
type BankAccount(accountNumber: string, initialBalance: float) =
    let mutable balance = initialBalance

    member this.AccountNumber = accountNumber
    member this.Balance with get() = balance

    member this.Deposit(amount: float) =
        if amount > 0.0 then
            balance <- balance + amount
            printfn "Wp³acono %.2f z³. Aktualne saldo: %.2f z³." amount balance
        else
            printfn "Kwota wp³aty musi byæ dodatnia!"

    member this.Withdraw(amount: float) =
        if amount > 0.0 && amount <= balance then
            balance <- balance - amount
            printfn "Wyp³acono %.2f z³. Aktualne saldo: %.2f z³." amount balance
        elif amount > balance then
            printfn "Nie masz wystarczaj¹cych œrodków na koncie!"
        else
            printfn "Kwota wyp³aty musi byæ dodatnia!"

type Bank() =
    let mutable accounts = Map.empty<string, BankAccount>

    member this.CreateAccount(accountNumber: string, initialBalance: float) =
        if accounts.ContainsKey(accountNumber) then
            printfn "Konto o tym numerze ju¿ istnieje!"
        else
            let newAccount = BankAccount(accountNumber, initialBalance)
            accounts <- accounts.Add(accountNumber, newAccount)
            printfn "Konto o numerze %s zosta³o utworzone. Saldo pocz¹tkowe: %.2f z³." accountNumber initialBalance

    member this.GetAccount(accountNumber: string) =
        match accounts.TryFind(accountNumber) with
        | Some(account) -> Some(account)  
        | None -> 
            printfn "Nie znaleziono konta o numerze %s!" accountNumber
            None  


    member this.UpdateAccount(accountNumber: string, newBalance: float) =
        match accounts.TryFind(accountNumber) with
        | Some(account) -> 
            printfn "Zaktualizowane saldo konta %s: %.2f z³." accountNumber newBalance
        | None -> printfn "Nie znaleziono konta o numerze %s!" accountNumber

    member this.DeleteAccount(accountNumber: string) =
        if accounts.ContainsKey(accountNumber) then
            accounts <- accounts.Remove(accountNumber)
            printfn "Konto o numerze %s zosta³o usuniête." accountNumber
        else
            printfn "Nie znaleziono konta o numerze %s!" accountNumber

    member this.ListAccounts() =
        if Map.isEmpty accounts then
            printfn "Brak kont w banku."
        else
            printfn "Lista kont w banku:"
            accounts |> Map.iter (fun accountNumber account -> printfn "Numer konta: %s, Saldo: %.2f z³" accountNumber account.Balance)

[<EntryPoint>]
let main argv =
    let bank = Bank()

    let rec showMenu() =
        printfn "\n------ SYSTEM BANKACCOUNT ------"
        printfn "1. Tworzenie konta"
        printfn "2. Odczyt konta"
        printfn "3. Wp³ata na konto"
        printfn "4. Wyp³ata z konta"
        printfn "5. Aktualizacja salda konta"
        printfn "6. Usuniêcie konta"
        printfn "7. Lista wszystkich kont"
        printfn "0. Zakoñczenie"
        printf "Wybierz opcjê: "

        match System.Console.ReadLine() with
        | "1" ->
            printf "Podaj numer konta: "
            let accountNumber = System.Console.ReadLine()
            printf "Podaj saldo pocz¹tkowe: "
            let initialBalance = System.Double.Parse(System.Console.ReadLine())
            bank.CreateAccount(accountNumber, initialBalance)
            showMenu()
        | "2" ->
            printf "Podaj numer konta do odczytu: "
            let accountNumber = System.Console.ReadLine()
            match bank.GetAccount(accountNumber) with
            | Some(account) -> 
                printfn "Numer konta: %s, Saldo: %.2f z³" account.AccountNumber account.Balance
            | None -> ()
            showMenu()
        | "3" ->
            printf "Podaj numer konta: "
            let accountNumber = System.Console.ReadLine()
            match bank.GetAccount(accountNumber) with
            | Some(account) -> 
                printf "Podaj kwotê wp³aty: "
                let amount = System.Double.Parse(System.Console.ReadLine())
                account.Deposit(amount)
            | None -> ()
            showMenu()
        | "4" ->
            printf "Podaj numer konta: "
            let accountNumber = System.Console.ReadLine()
            match bank.GetAccount(accountNumber) with
            | Some(account) -> 
                printf "Podaj kwotê wyp³aty: "
                let amount = System.Double.Parse(System.Console.ReadLine())
                account.Withdraw(amount)
            | None -> ()
            showMenu()
        | "5" ->
            printf "Podaj numer konta do aktualizacji salda: "
            let accountNumber = System.Console.ReadLine()
            printf "Podaj nowe saldo: "
            let newBalance = System.Double.Parse(System.Console.ReadLine())
            bank.UpdateAccount(accountNumber, newBalance)
            showMenu()
        | "6" ->
            printf "Podaj numer konta do usuniêcia: "
            let accountNumber = System.Console.ReadLine()
            bank.DeleteAccount(accountNumber)
            showMenu()
        | "7" ->
            bank.ListAccounts()
            showMenu()
        | "0" -> 
            printfn "Zakoñczenie programu."
        | _ -> 
            printfn "Niepoprawna opcja. Spróbuj ponownie."
            showMenu()

    showMenu()

    0
