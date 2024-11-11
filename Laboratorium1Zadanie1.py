#Zadanie 1  Problem Podziału Paczek
# Napisz funkcję, która przyjmuje listę wag paczek i maksymalną wagę.
# Użyj pętli for i instrukcji warunkowych if, else do iteracyjnego podziału paczek.
# Program powinien zwracać minimalną liczbę kursów oraz listę paczek w każdym kursie.

def podziel_paczki(wagi, max_waga):
    for waga in wagi:
        if waga > max_waga:
            raise ValueError(f"Paczka o wadze {waga} przekracza max dozwoloną wagę {max_waga} kg")

    wagi_sorted = sorted(wagi, reverse=True)

    kursy = []

    for waga in wagi_sorted:
        dodano = False
        for kurs in kursy:
            if sum(kurs) + waga <= max_waga:
                kurs.append(waga)
                dodano = True
                break
        if not dodano:
            kursy.append([waga])

    return len(kursy), kursy

wagi = [1, 2, 3, 4, 5, 6, 7, 8, 19, 20, 7]
max_waga = 25

liczba_kursow, kursy = podziel_paczki(wagi, max_waga)

for i, kurs in enumerate(kursy, 1):
    print(f"Kurs {i}: {kurs} - suma wag: {sum(kurs)} kg.")
