from collections import Counter
import string

# #Zadanie 1. Analiza Tekstu i Transformacje Funkcyjne
# Napisz program, który przyjmuje długi tekst (np. artykuł, książkę) i wykonuje kilka złożonych operacji
# analizy tekstu:
# • Zlicza liczbę słów, zdań, i akapitów w tekście.
# • Wyszukuje najczęściej występujące słowa, wykluczając tzw. stop words (np. "i", "a", "the").
# • Transformuje wszystkie wyrazy rozpoczynające się na literę "a" lub "A" do ich odwrotności (np.
# "apple" → "elppa").
# Wskazówka: Użyj map(), filter(), i list składanych, aby przeprowadzać transformacje na tekście.


tekst = """
September 30th, 1998. It's a day I'll never forget. The cop inside me died that day. And that night, Raccoon City was 
wiped out, thanks to the bioweapons created by Umbrella. Somehow, I made it out. But too many others...weren't so lucky.
I was "asked" later to join a top-secret government program. Not that I had a choice. The training, the punishing 
missions...nearly killed me, but at least they kept my mind off everything. If I could just forget what happened that
night - the pain, even for a second? This time, it can be different. It has to.
"""

stop_words = {"i", "a", "the", "are", "by", "is", "in", "of", "that", "it", "on", "this", "with", "for", "at", "as", "to"}
def analiza_tekstu(tekst):
    akapity = tekst.strip().split("\n")
    zdania = [zdanie for akapit in akapity for zdanie in akapit.split('.') if zdanie]
    slowa = [slowo.strip(string.punctuation).lower() for zdanie in zdania for slowo in zdanie.split()]
    return len(slowa), len(zdania), len(akapity), slowa

def najczesciej_wystepujace_slowa(slowa, stop_words, n=5):
    przefiltrowane_slowa = filter(lambda slowo: slowo not in stop_words, slowa)
    liczba_slow = Counter(przefiltrowane_slowa)
    return liczba_slow.most_common(n)

def slowa_aA(slowa):
    return list(map(lambda slowo: slowo[::-1] if slowo.startswith('a') else slowo, slowa))

liczba_slow, liczba_zdan, liczba_akapity, slowa = analiza_tekstu(tekst)

najczestsze_slowa = najczesciej_wystepujace_slowa(slowa, stop_words)

zmienione_slowa = slowa_aA(slowa)

print("Liczba słów:", liczba_slow)
print("Liczba zdań:", liczba_zdan)
print("Liczba akapitów:", liczba_akapity)
print("Najczęstsze słowa:", najczestsze_slowa)
print("Tekst po transformacji:", ' '.join(zmienione_slowa))
