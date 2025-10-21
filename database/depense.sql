-- ============================================================
-- 📘 TABLES ET DONNÉES DE DÉPENSES (BDC LF 2025)
-- ============================================================

-- ========================================
-- 1️⃣ NATURE DES DÉPENSES
-- ========================================
CREATE TABLE NatureDepenses (
    idNatureDepenses SERIAL PRIMARY KEY,
    nom VARCHAR(250) NOT NULL
);

INSERT INTO NatureDepenses (nom) VALUES
('Intérêts de la dette'),
('Dépenses de solde et pensions'),
('Dépenses de fonctionnement (hors solde)'),
('Dépenses d’investissement');

-- ========================================
-- 2️⃣ DÉPENSES PAR NATURE ÉCONOMIQUE
-- (Tableau 7 : Ventilation des dépenses par rubrique)
-- ========================================
CREATE TABLE DepensesParNature (
    idDepensesParNature SERIAL PRIMARY KEY,
    annee INTEGER NOT NULL,
    montant NUMERIC(15,2) NOT NULL,
    idNatureDepenses INTEGER NOT NULL,
    CONSTRAINT fk_depenses_nature
        FOREIGN KEY(idNatureDepenses)
        REFERENCES NatureDepenses(idNatureDepenses)
        ON DELETE CASCADE
);

INSERT INTO DepensesParNature (annee, montant, idNatureDepenses) VALUES
(2024, 672.0, 1),      -- Intérêts de la dette
(2025, 756.5, 1),
(2024, 3814.5, 2),     -- Dépenses de solde et pensions
(2025, 3846.4, 2),
(2024, 3069.0, 3),     -- Fonctionnement hors solde
(2025, 2304.3, 3),
(2024, 4836.8, 4),     -- Dépenses d’investissement
(2025, 8537.2, 4);

-- ========================================
-- 3️⃣ DÉPENSES DE SOLDE ET PENSIONS
-- (Tableau 8)
-- ========================================
CREATE TABLE DepensesSoldePensions (
    idDepensesSolde SERIAL PRIMARY KEY,
    annee INTEGER NOT NULL,
    montant NUMERIC(15,2) NOT NULL,
    solde_pib NUMERIC(5,2),
    solde_recettes_fiscales NUMERIC(5,2),
    solde_depenses_totales NUMERIC(5,2)
);

INSERT INTO DepensesSoldePensions (annee, montant, solde_pib, solde_recettes_fiscales, solde_depenses_totales) VALUES
(2024, 3814.5, 4.8, 47.9, 29.9),
(2025, 3846.4, 4.3, 40.5, 23.6);

-- ========================================
-- 4️⃣ DÉPENSES DE FONCTIONNEMENT (HORS SOLDE)
-- (Tableau 9)
-- ========================================
CREATE TABLE DepensesFonctionnement (
    idDepensesFonctionnement SERIAL PRIMARY KEY,
    annee INTEGER NOT NULL,
    indemnites NUMERIC(15,2),
    biens_services NUMERIC(15,2),
    transferts NUMERIC(15,2),
    total NUMERIC(15,2)
);

INSERT INTO DepensesFonctionnement (annee, indemnites, biens_services, transferts, total) VALUES
(2024, 244.8, 573.2, 2251.0, 3069.0),
(2025, 244.8, 504.7, 1554.8, 2304.3);

-- ========================================
-- 5️⃣ DÉPENSES D’INVESTISSEMENT
-- (Figure 5)
-- ========================================
CREATE TABLE DepensesInvestissement (
    idDepensesInvestissement SERIAL PRIMARY KEY,
    annee INTEGER NOT NULL,
    financement_interne NUMERIC(15,2),
    financement_externe NUMERIC(15,2),
    total NUMERIC(15,2)
);

INSERT INTO DepensesInvestissement (annee, financement_interne, financement_externe, total) VALUES
(2024, 1254.8, 3265.6, 4520.4),
(2025, 2368.4, 5897.4, 8265.8);

-- ========================================
-- 6️⃣ DÉPENSES PAR ADMINISTRATION / MINISTÈRE
-- (Tableau 10)
-- ========================================
CREATE TABLE DepensesAdministratives (
    idDepensesAdministratives SERIAL PRIMARY KEY,
    annee INTEGER NOT NULL,
    institution VARCHAR(250) NOT NULL,
    montant NUMERIC(15,2) NOT NULL
);

INSERT INTO DepensesAdministratives (annee, institution, montant) VALUES
(2024, 'Présidence de la République', 177.1),
(2025, 'Présidence de la République', 224.7),
(2024, 'Sénat', 22.1),
(2025, 'Sénat', 21.3),
(2024, 'Assemblée Nationale', 87.4),
(2025, 'Assemblée Nationale', 85.9),
(2024, 'Haute Cour Constitutionnelle', 11.9),
(2025, 'Haute Cour Constitutionnelle', 9.3),
(2024, 'Primature', 278.3),
(2025, 'Primature', 339.9),
(2024, 'Conseil du Fampihavanana Malagasy', 6.7),
(2025, 'Conseil du Fampihavanana Malagasy', 6.3),
(2024, 'Commission Électorale Nationale Indépendante', 113.3),
(2025, 'Commission Électorale Nationale Indépendante', 16.4),
(2024, 'Ministère de la Défense Nationale', 557.0),
(2025, 'Ministère de la Défense Nationale', 543.2),
(2024, 'Ministère des Affaires Étrangères', 99.2),
(2025, 'Ministère des Affaires Étrangères', 104.7),
(2024, 'Ministère de la Justice', 199.6),
(2025, 'Ministère de la Justice', 219.8),
(2024, 'Ministère de l’Intérieur', 150.2),
(2025, 'Ministère de l’Intérieur', 134.7),
(2024, 'Ministère de l’Économie et des Finances', 2848.0),
(2025, 'Ministère de l’Économie et des Finances', 2332.7),
(2024, 'Ministère de la Sécurite Publique', 228.3),
(2025, 'Ministère de la Sécurite Publique', 229.2),
(2024, 'Ministère de l’Industrialisation et du Commerce', 113.2),
(2025, 'Ministère de l’Industrialisation et du Commerce', 119.6),
(2024, 'Ministère de la Décentralisation et de l’Aménagement du Territoire', 356.8),
(2025, 'Ministère de la Décentralisation et de l’Aménagement du Territoire', 568.1),
(2024, 'Ministère du Travail, de l’Emploi et de la Fonction Publique', 31.8),
(2025, 'Ministère du Travail, de l’Emploi et de la Fonction Publique', 33.7),
(2024, 'Ministère du Tourisme et de l’Artisanat', 19.2),
(2025, 'Ministère du Tourisme et de l’Artisanat', 43.9),
(2024, 'Ministère de l’Enseignement Supérieur et de la Recherche Scientifique', 284.2),
(2025, 'Ministère de l’Enseignement Supérieur et de la Recherche Scientifique', 285.6),
(2024, 'Ministère de l’Environnement et du Développement Durable', 94.4),
(2025, 'Ministère de l’Environnement et du Développement Durable', 188.8),
(2024, 'Ministère de l’Éducation Nationale', 1532.8),
(2025, 'Ministère de l’Éducation Nationale', 1562.0),
(2024, 'Ministère des Transports et de la Météorologie', 63.9),
(2025, 'Ministère des Transports et de la Météorologie', 216.3),
(2024, 'Ministère de la Santé Publique', 716.6),
(2025, 'Ministère de la Santé Publique', 921.0),
(2024, 'Ministère de la Communication et de la Culture', 38.4),
(2025, 'Ministère de la Communication et de la Culture', 32.1),
(2024, 'Ministère des Travaux Publics', 1217.3),
(2025, 'Ministère des Travaux Publics', 2327.5),
(2024, 'Ministère des Mines et des Ressources Strategiques', 18.3),
(2025, 'Ministère des Mines et des Ressources Strategiques', 18.1),
(2024, 'Ministère de l’Énergie et des Hydrocarbures', 407.9),
(2025, 'Ministère de l’Énergie et des Hydrocarbures', 1332.0),
(2024, 'Ministère de l’Eau, de l’Assainissement et de l’Hygiène', 306.1),
(2025, 'Ministère de l’Eau, de l’Assainissement et de l’Hygiène', 600.2),
(2024, 'Ministère de l’Agriculture et de l’Élevage', 469.8),
(2025, 'Ministère de l’Agriculture et de l’Élevage', 795.5),
(2024, 'Ministère de la Pêche et de l’Économie Bleue', 29.9),
(2025, 'Ministère de la Pêche et de l’Économie Bleue', 28.8),
(2024, 'Ministère de l’Enseignement Technique et de la Formation Professionnelle', 103.7),
(2025, 'Ministère de l’Enseignement Technique et de la Formation Professionnelle', 94.8),
(2024, 'Ministère de l’Artisanat et des Métiers', 2.5),
(2025, 'Ministère de l’Artisanat et des Métiers', 0.0),
(2024, 'Ministère du Développement Numérique, des Postes et des Télécommunications', 8.4),
(2025, 'Ministère du Développement Numérique, des Postes et des Télécommunications', 8.8),
(2024, 'Ministère de la Population et des Solidarités', 99.1),
(2025, 'Ministère de la Population et des Solidarités', 193.4),
(2024, 'Ministère de la Jeunesse et des Sports', 40.5),
(2025, 'Ministère de la Jeunesse et des Sports', 58.1),
(2024, 'Secretariat d’État en charge des Nouvelles Villes et de l’Habitat', 247.1),
(2025, 'Secretariat d’État en charge des Nouvelles Villes et de l’Habitat', 138.8),
(2024, 'Ministère délégué chargé de la Gendarmerie', 414.8),
(2025, 'Ministère délégué chargé de la Gendarmerie', 446.4),
(2024, 'Secrétariat d’État en charge de la Souveraineté Alimentaire', 0.0),
(2025, 'Secrétariat d’État en charge de la Souveraineté Alimentaire', 127.3),
(2024, 'Haut Conseil pour la Défense de la Démocratie et de l’État de Droit (HCDDED)', 2.1),
(2025, 'Haut Conseil pour la Défense de la Démocratie et de l’État de Droit (HCDDED)', 2.0),
(2024, 'Commission Nationale Indépendante des Droits de l’Homme (CNIDH)', 2.1),
(2025, 'Commission Nationale Indépendante des Droits de l’Homme (CNIDH)', 2.0),
(2024, 'Haute Cour de Justice', 3.7),
(2025, 'Haute Cour de Justice', 3.5);

-- ========================================
-- 7️⃣ DÉFICIT BUDGÉTAIRE ET FINANCEMENT
-- (Section IV)
-- ========================================
CREATE TABLE DeficitBudgetaire (
    idDeficit SERIAL PRIMARY KEY,
    annee INTEGER NOT NULL,
    depenses_totales NUMERIC(15,2),
    recettes_totales NUMERIC(15,2),
    deficit NUMERIC(15,2),
    financement_exterieur NUMERIC(15,2),
    financement_interieur NUMERIC(15,2)
);

INSERT INTO DeficitBudgetaire (annee, depenses_totales, recettes_totales, deficit, financement_exterieur, financement_interieur) VALUES
(2025, 16304.9, 12962.7, 3642.2, 3147.6, 494.6);