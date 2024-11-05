# 6-api_university

// Pour configurer
// Installer extension C# 
// Installer extension PDF

--> Pour initier un nouveau projet de type API web dans un répertoire ApiUniversity existant
git init
dotnet new webapi -n ApiUniversity -o .
dotnet new gitignore

--> Pour les autres projets de BDD
// dotnet tool install --global dotnet-ef // en amont dans fichier parent
// dotnet new gitignore // en amont dans fichier parent
// dotnet add package Microsoft.EntityFrameworkCore.Design // en amont dans fichier projet
// dotnet add package Microsoft.EntityFrameworkCore.Sqlite // en amont dans fichier projet
// dotnet add package Swashbuckle.AspNetCore.Annotations // pour les annotations dans la documentation de Swagger UI
// Créer fichier Models (dans le répertoire que le fichier *.csproj) et mettre Todo.cs dedans codé comme indiqué
// Coder tous les attributs de Todo en PUBLIC (e.g. 'public int Id {get; set;}')
// Créer un répertoire Data dans le fichier projet
// Créer le fichier TodoContext.cs dans le répertoire Data associé (et coller le code en fin d’énoncé du TP2)
// using Microsoft.EntityFrameworkCore; // A mettre en 1ère ligne de Program.cs pour exécuter les commandes de BDD
// Créer le fichier SeedData.cs pour la classe SeedData pour générer l'environnement d'exécution selon les modèles d'objets dans Models
// SeedData.Init(); // A mettre au début du code de Program.cs pour remplir la future BDD avec les objets selon les modèles de Models (cf. TP2/3)

// Pour créer la BDD
// Fermer tout autre projet .NET ouvert en parallèle
// Fermer et réouvrir VS Code
// dotnet ef migrations add InitialCreate // au début dans fichier projet
// dotnet ef migrations add "AddDeadline" // ensuite dans fichier projet pour toute mise à jour de la BDD en terme de Models (To undo this action, use 'ef migrations remove')
// dotnet ef database update // à la fin pour créer le fichier de BDD dans fichier projet et pour appliquer les migrations des mises à jour
// Ouvrir SQLite puis ouvrir le fichier de BDD crée à l'instant

// Pour exécuter
// 0- dotnet build // pour voir les erreurs
// 1- dotnet run
// 2- Aller sur http://localhost:5275/swagger/index.html (le numééro de port est indiqué après tous les dotnet run)
