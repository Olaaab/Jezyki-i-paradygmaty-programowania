# Zadanie 3. Dynamiczne Wyznaczanie Ekstremów w Niejednorodnych Danych
# Napisz funkcję, która przyjmuje listę niejednorodnych danych (np. liczby, napisy, krotki, listy, słowniki) i wykonuje dynamiczną analizę danych, aby:
# • Zwrócić największą liczbę (lub wartość numeryczną) w danych.
# • Zwrócić najdłuższy napis.
# • Zwrócić krotkę o największej liczbie elementów.
# Wskazówka: Użyj filter() do selekcji odpowiednich typów danych oraz map() do przekształceń na elementach.
def analiza_danych(dane):
    liczby = list(filter(lambda x: isinstance(x, (int, float)), dane))
    napisy = list(filter(lambda x: isinstance(x, str), dane))
    krotki = list(filter(lambda x: isinstance(x, tuple), dane))

    max_liczba = max(liczby) if liczby else None

    najdluzszy_napis = max(napisy, key=len) if napisy else None

    najwieksza_krotka = max(krotki, key=len) if krotki else None

    return max_liczba, najdluzszy_napis, najwieksza_krotka

dane = [98, "Bardzo", "lubię", "Szpinak", (1, 6, 18, 23, 54, 77), 23.5, "Spanakopita", (9, 5), "Kotek", 74, (1, 5, 9, 12)]

max_liczba, najdluzszy_napis, najwieksza_krotka = analiza_danych(dane)

print("Największa liczba:", max_liczba)
print("Najdłuższy napis:", najdluzszy_napis)
print("Krotka o największej liczbie elementów:", najwieksza_krotka)
