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
(2024, 1262.5, 3574.3, 4836.8),
(2025, 2377.3, 6159.9, 8537.2);

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
(2024, 'Assemblée Nationale', 87.4),
(2025, 'Assemblée Nationale', 85.9),
(2024, 'Primature', 278.3),
(2025, 'Primature', 339.9),
(2024, 'Ministère de l’Économie et des Finances', 2848.0),
(2025, 'Ministère de l’Économie et des Finances', 2332.7),
(2024, 'Ministère des Travaux Publics', 1217.3),
(2025, 'Ministère des Travaux Publics', 2327.5),
(2024, 'Ministère de l’Agriculture et de l’Élevage', 469.8),
(2025, 'Ministère de l’Agriculture et de l’Élevage', 795.5),
(2024, 'Ministère de la Santé Publique', 716.6),
(2025, 'Ministère de la Santé Publique', 921.0),
(2024, 'Ministère de l’Éducation Nationale', 1532.8),
(2025, 'Ministère de l’Éducation Nationale', 1562.0);

-- (💡 tu peux compléter ici les autres ministères du tableau 10 selon ton besoin)

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
