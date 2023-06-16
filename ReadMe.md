# Stockfinder
## Autorzy
* Kamil Poniewierski

## Temat:
   Aplikacja pełni funkcję panelu giełdowego, w obrębie którego można przeszukiwać archiwalne dane giełdowe. Użytkownik panelu może oznaczać spółki jako ulubione, co wyróżnia je wizualnie oraz zapisywać wyszukiwania, w celu sprawdzenia ich później.

## Wykorzystane tabele:
* Informacje o spółce
* Informacje kursowe
* Ulubione spółki
* Zapisane wyszukiwania

## Przykłady użycia
* Strona spółek ("Stocks")
    * Sprawdzenie historycznych danych giełdowych poprzez naciśnięcie tickera danej spółki
    * Oznaczenie aplikacji jako ulubionej, co umieści ją na górze listy spółek
* Strona wyszukiwania ("Search stocks")
    * Przeszukanie danego okresu w poszukiwaniu spółek, które przebiły dany wynik giełdowy
       * w przypadku podania oczekiwanej zmiany równej zero zostaną wyświetlone wszystkie spółki
       * dla liczb większych od zera wyświetlone zostaną spółki, które osiągnęły wynik lepszy, dla mniejszych - gorszy
     * W przypadku gdy w którymś z krańcowych dni sesja się nie odbyła (z powodu weekendu lub święta), aplikacja sama spróbuje dopasować najbardziej pasującą datę
     * Jeśli dane są poprawne, zostanie wyświetlona strona z rezultatami zapytania
       * Jeśli nie znaleziono takich spółek, wyświetlony zostanie odpowiedni komunikat
       * W przeciwnym wypadku wyświetlone zostaną dane spółek -- tabela zawierająca nazwy spółek, zmianę procentową oraz ceny otwarcia/zamknięcia z tego okresu
       * Każde wyszukiwanie można zapisać
## Uruchomienie aplikacji
Najprostszym sposobem jest otworzenie repozytorium w VS Code i wykorzystanie istniejących konfiguracji w launchSettings.json.

## Źródło danych
Archiwum [stooq.pl](stooq.pl)