# NumismaticManager

[EN] This application was created for anyone who want to manage his numismatic collection easier.

[PL] Ta aplikacja powstała dla każdego kto chce łatwiej zarządzać swoją kolekcją numizmatów.

# [EN] How it works

+Application allows to download commemorative coins minted in Poland. App connects to www.nbp.pl and then using HtmlAgilityPack downloads coins catalog year by year, each is served by a separate thread. Finally, the application copies them to the local database (SQLite), checking beforehand if any of them is duplicated.

+The user can simply view the downloaded data, start to modify the number of selected coins or add those that were not in the database at www.nbp.pl/home.aspx?f=/banknoty_i_monety/monety_okolicznosciowe/katalog.html.

+Using the settings window, the user can decide which denominations are to be displayed.

+The user can choose one of four display modes
  
  -all coins collected in database regardless of the number of owned coins
  
  -all owned coins
  
  -all redundant coins (the number above which the coins will be considered excess is to be set in options)
  
  -all not owned coins

+There is posibility to export data to files like .txt or .pdf using PDFsharp. Data contained in the file depends on the selected display mode, so if the user select owned coins display mode and order coins by date then exported will be only owned coins and they will be ordered by date.

+Application is equipped with a system of withdrawing changes and creating backup copies.

# [PL] Jak to działa

+Aplikacja pozwala na pobieranie monet okolicznościowych wybitych w Polsce. Apka łączy się z serwisem www.nbp.pl a następnie używając HtmlAgilityPack-a pobiera dane z katalogu według roku, każdy z nich obsługiwany jest przez osobny wątek. Ostatecznie aplikacja kopiuje pobrane monety do lokalnej bazy (SQLite), sprawdzając uprzednio czy nie występują duplikaty monet.

+Użytkownik może po prostu przeglądać pobrane dane, zacząć modyfikować ilość wybranych monet lub dodać te któych nie było zawartych w na stronie www.nbp.pl/home.aspx?f=/banknoty_i_monety/monety_okolicznosciowe/katalog.html.

+Używając okna ustawień, użytkownik może zdecydować które nominały zostaną wyświetlone.

+Użytkownik może wybrać jedne z czterech trybów wyświetlania
  
  -wszystkie monety zawarte w baze bez względu na ilość posiadanych egzemplarzy
  
  -wszystkie posiadane monety
  
  -wszystkie nadmiarowe (liczbę po przekroczeniu któej monety będą uznawane za nadmiarowe można zmieniać w ustawieniach)
  
  -wszystkie nieposiadane

+Jest też możliwość wyeksportowania danych do pliku .txt lub .pdf korzystając z framework-a PDFsharp. Dane zawarte w pliku zależą od wybranego trybu wyświetlania, więc jeżeli użytkownik wybierze wyświetlanie tylko posiadanych monet i posortuje je według daty to w wyeksportowanym pliku znajdą się tylko posiadane monety posortowane według daty.

+Aplikacja wyposażona jest w system cofania zmian oraz tworzenia kopii zapasowych.
