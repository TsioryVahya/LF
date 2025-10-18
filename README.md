# Loi de Finances 2025 - République de Madagascar

Application web moderne de gestion et de suivi des recettes budgétaires de l'État malgache.

## 🎨 Design

### Palette de Couleurs Gouvernementales
- **Primary**: `#1b8895` - Bleu-vert principal
- **Secondary**: `#82d4d9` - Bleu clair secondaire  
- **Accent**: `#c8e785` - Vert citron pour les accents
- **Blanc**: Fond et cartes

### Technologies Frontend
- **TailwindCSS** - Framework CSS utility-first
- **Font**: Inter (Google Fonts)
- **Icons**: Heroicons SVG

## 🛠️ Technologies Backend

- **Framework**: ASP.NET Core 9.0 (MVC)
- **Langage**: C# 
- **Base de données**: PostgreSQL
- **ORM**: Entity Framework Core avec Npgsql

## 📊 Structure de la Base de Données

### Tables Principales

1. **NatureImpots** / **RecettesInterieurs**
   - Gestion des impôts et taxes intérieurs

2. **NatureDroitsetTaxes** / **RecettesDouanieres**
   - Gestion des droits et taxes douanières

3. **NatureRecettesNonFiscales** / **RecettesNonFiscales**
   - Gestion des recettes non fiscales

4. **NatureDons** / **Dons**
   - Gestion des dons et subventions

## 🚀 Installation et Configuration

### Prérequis
- .NET 9.0 SDK
- PostgreSQL 12+
- Un éditeur de code (Visual Studio, VS Code, Rider)

### Étapes d'Installation

1. **Cloner le repository**
   ```bash
   git clone <repository-url>
   cd LF
   ```

2. **Créer la base de données PostgreSQL**
   ```sql
   CREATE DATABASE LF;
   ```

3. **Exécuter le script SQL**
   ```bash
   psql -U postgres -d LF -f database/base.sql
   ```

4. **Configurer la chaîne de connexion**
   
   Modifier `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=LF;Username=votre_user;Password=votre_password"
     }
   }
   ```

5. **Restaurer les packages NuGet**
   ```bash
   dotnet restore
   ```

6. **Compiler le projet**
   ```bash
   dotnet build
   ```

7. **Lancer l'application**
   ```bash
   dotnet run
   ```

8. **Accéder à l'application**
   
   Ouvrir votre navigateur: `http://localhost:5111`

## 📁 Structure du Projet

```
LF/
├── Controllers/          # Contrôleurs MVC
├── Models/              # Modèles de données (Entities)
├── Views/               # Vues Razor
│   ├── Home/           # Vues de la page d'accueil
│   └── Shared/         # Layout et composants partagés
├── Data/               # DbContext et configuration EF Core
├── database/           # Scripts SQL
│   └── base.sql       # Schéma de base de données
├── wwwroot/           # Fichiers statiques
├── appsettings.json   # Configuration de l'application
└── Program.cs         # Point d'entrée de l'application
```

## 🔧 Configuration de la Base de Données

La connexion PostgreSQL est configurée dans `Program.cs`:

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
```

## 🎯 Fonctionnalités

- ✅ Page d'accueil moderne avec design gouvernemental
- ✅ Navigation sticky responsive
- ✅ 4 catégories de recettes avec cartes interactives
- ✅ Connexion PostgreSQL configurée
- ✅ Modèles Entity Framework complets
- ✅ Design 100% responsive (mobile, tablet, desktop)
- ✅ Animations et transitions fluides

## 📝 Packages NuGet Utilisés

- `Npgsql.EntityFrameworkCore.PostgreSQL` (9.0.0)
- `Microsoft.EntityFrameworkCore.Design` (9.0.0)

## 🌐 URLs de l'Application

- **Accueil**: `/`
- **Recettes Intérieures**: `/Home/RecettesInterieures`
- **Recettes Douanières**: `/Home/RecettesDouanieres`
- **Recettes Non Fiscales**: `/Home/RecettesNonFiscales`
- **Dons**: `/Home/Dons`

## 🔐 Sécurité

- Utilisation de paramètres préparés avec Entity Framework
- Protection CSRF intégrée dans ASP.NET Core
- HTTPS configuré pour la production

## 📱 Responsive Design

L'application s'adapte automatiquement à toutes les tailles d'écran:
- **Mobile**: < 768px
- **Tablet**: 768px - 1024px
- **Desktop**: > 1024px

## 🤝 Contribution

Pour contribuer au projet:
1. Fork le repository
2. Créer une branche (`git checkout -b feature/AmazingFeature`)
3. Commit les changements (`git commit -m 'Add AmazingFeature'`)
4. Push vers la branche (`git push origin feature/AmazingFeature`)
5. Ouvrir une Pull Request

## 📄 Licence

Ce projet est développé pour le Ministère de l'Économie et des Finances de la République de Madagascar.

## 👥 Contact

Ministère de l'Économie et des Finances  
Antananarivo, Madagascar

---

**Version**: 1.0.0  
**Dernière mise à jour**: 2025
