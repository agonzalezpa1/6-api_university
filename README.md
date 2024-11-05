# 6-api_university

// Extensions à installer
// Installer extension C# 
// Installer extension PDF
// Intaller extension PlantUML

--> Pour initier un nouveau projet de type API web dans un répertoire ApiUniversity existant (TP6)
git init // pas toujours nécessaire, il crée un répertoire GitHub à partir d'un fichier local
dotnet new webapi -n ApiUniversity -o .
dotnet new gitignore

--> Pour les autres projets application simple avec BDD
// dotnet new console -o "ProjectName"
// dotnet tool install --global dotnet-ef // en amont dans fichier parent
// dotnet new gitignore // en amont dans fichier parent

--- CONFIGURATIONS A FAIRE POUR TOUS LES PROJETS ----

// dotnet add package Microsoft.EntityFrameworkCore.Design // en amont dans fichier projet
// dotnet add package Microsoft.EntityFrameworkCore.Sqlite // en amont dans fichier projet
// dotnet add package Swashbuckle.AspNetCore.Annotations // pour les annotations dans la documentation de Swagger UI

// Créer fichier Models (dans le même répertoire que le fichier *.csproj) et mettre NomModele.cs dedans et coder sa classe comme indiqué dans diagramme UML SANS CONSTRUCTEUR
// Rajouter 'namespace NomProjet.Models;' au début de chaque fichier de classe, il permet d'établir des collections de noms de classe utilisés dans plusieurs applications différentes
// Coder tous les attributs en PUBLIC (e.g. 'public int Id {get; set;}')

// Créer un répertoire Data dans le fichier projet
// Créer le fichier NomProjetContext.cs dans le répertoire Data associé (et coller le code en fin d’énoncé du TP2)
// Vérifier de bien rajouter un attribut DbSet par modèle
// Vérifier que NomProjetContext soit bien le nom de la classe et du constructeur

// using Microsoft.EntityFrameworkCore; // A mettre en 1ère ligne de Program.cs pour exécuter les commandes de BDD
// Créer le fichier SeedData.cs pour la classe SeedData dans le fichier Data pour générer l'environnement d'exécution selon les modèles d'objets dans Models
// using ApiUniversity.Data; + SeedData.Init(); // A mettre au début du code de Program.cs pour remplir la future BDD avec les objets selon les modèles de Models (cf. TP2/3 ou modèle enoncé TP6)

// Pour créer la BDD
// Fermer tout autre projet .NET ouvert en parallèle
// Fermer et réouvrir VS Code
// dotnet ef migrations add InitialCreate // au début dans fichier projet
// dotnet ef migrations add "AddFeatureName" // ensuite dans fichier projet pour toute mise à jour de la BDD en terme de Models (To undo this action, use 'dotnet ef migrations remove')
// dotnet ef database update // à la fin pour créer le fichier de BDD dans fichier projet OU pour appliquer les migrations des mises à jour
// Ouvrir SQLite puis ouvrir le fichier de BDD crée à l'instant

// Pour exécuter
// 0- dotnet build // pour voir les erreurs
// 1- dotnet run
// 2- Aller sur http://localhost:5275/swagger/index.html (le numééro de port est indiqué après tous les dotnet run)
