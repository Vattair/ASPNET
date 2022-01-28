# Projekt w ramach zajęć "Programowanie w środowisku ASP.NET"

Niezbędne do uruchomienia jest:

 1. Posiadanie wszystkich pakietów nuget
 2. Ustawienie ścieżki dostępu do bazy danych w pliku appsettings.json

    "ASPNETContextConnection": "Server=<Nazwa servera>;Database=<Nazwa bazydanych>;Trusted_Connection=True;MultipleActiveResultSets=true;"

 3. Wykonanie poleceń w konsoli menedżera pakietów

    add-migration <nazwa-migracji>
    update-database
