// Napisz funkcjê, która ³¹czy dwie listy ³¹czone w jedn¹. 

type LinkedList<'T> =
    | Empty
    | Node of 'T * LinkedList<'T>

let rec concatenate list1 list2 =
    match list1 with
    | Empty -> list2 
    | Node(value, next) -> Node(value, concatenate next list2) 

let fromList lst =
    List.foldBack (fun x acc -> Node(x, acc)) lst Empty

let rec printList list =
    match list with
    | Empty -> ()
    | Node(value, next) ->
        printf "%A " value
        printList next

let lista1 = fromList [3; 2; 1]
let lista2 = fromList [7; 6; 5]

printf "Lista1: "
printList lista1

printf "\nLista2: "
printList lista2

let laczonalista = concatenate lista1 lista2
printf "\nPo³¹czona lista: "
printList laczonalista
