-- Script d'insertion des données de Recettes Fiscales Intérieures
-- Loi de Finances 2025

-- Insertion des natures d'impôts
INSERT INTO NatureImpots (nom) VALUES
('Impôt sur les revenus'),
('Impôt sur les revenus Salariaux et Assimilés'),
('Impôt sur les revenus des Capitaux Mobiliers'),
('Impôt sur les plus-values Immobilières'),
('Impôt Synthétique'),
('Droit d''Enregistrement'),
('Taxe sur la Valeur Ajoutée (y compris Taxe sur les transactions Mobiles)'),
('Impôt sur les marchés Publics'),
('Droit d''Accise (y compris Taxe environnementale)'),
('Taxes sur les Assurances'),
('Droit de Timbres'),
('Autres');

-- Insertion des recettes intérieures pour LFR 2024

-- Impôt sur les revenus - LFR 2024
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (1, 2024, 1179.0);

-- Impôt sur les revenus Salariaux et Assimilés - LFR 2024
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (2, 2024, 848.2);

-- Impôt sur les revenus des Capitaux Mobiliers - LFR 2024
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (3, 2024, 78.2);

-- Impôt sur les plus-values Immobilières - LFR 2024
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (4, 2024, 14.0);

-- Impôt Synthétique - LFR 2024
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (5, 2024, 132.3);

-- Droit d'Enregistrement - LFR 2024
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (6, 2024, 49.0);

-- Taxe sur la Valeur Ajoutée - LFR 2024
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (7, 2024, 1400.2);

-- Impôt sur les marchés Publics - LFR 2024
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (8, 2024, 148.7);

-- Droit d'Accise - LFR 2024
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (9, 2024, 754.1);

-- Taxes sur les Assurances - LFR 2024
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (10, 2024, 17.2);

-- Droit de Timbres - LFR 2024
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (11, 2024, 14.1);

-- Autres - LFR 2024
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (12, 2024, 1.5);

-- =====================================================
-- Insertion des recettes intérieures pour LF 2025
-- =====================================================

-- Impôt sur les revenus - LF 2025
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (1, 2025, 1411.4);

-- Impôt sur les revenus Salariaux et Assimilés - LF 2025
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (2, 2025, 889.9);

-- Impôt sur les revenus des Capitaux Mobiliers - LF 2025
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (3, 2025, 93.7);

-- Impôt sur les plus-values Immobilières - LF 2025
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (4, 2025, 18.3);

-- Impôt Synthétique - LF 2025
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (5, 2025, 164.7);

-- Droit d'Enregistrement - LF 2025
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (6, 2025, 62.8);

-- Taxe sur la Valeur Ajoutée - LF 2025
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (7, 2025, 1742.2);

-- Impôt sur les marchés Publics - LF 2025
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (8, 2025, 250.0);

-- Droit d'Accise - LF 2025
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (9, 2025, 955.4);

-- Taxes sur les Assurances - LF 2025
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (10, 2025, 20.6);

-- Droit de Timbres - LF 2025
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (11, 2025, 16.8);

-- Autres - LF 2025
INSERT INTO RecettesInterieurs (idNatureImpots, annee, montant) 
VALUES (12, 2025, 2.7);

-- Vérification des totaux
-- TOTAL LFR 2024: 4 636,5 milliards d'Ariary
-- TOTAL LF 2025: 5 628,4 milliards d'Ariary

-- Requête de vérification pour LFR 2024
SELECT 'LFR 2024' as Periode, SUM(montant) as Total 
FROM RecettesInterieurs 
WHERE annee = 2024;

-- Requête de vérification pour LF 2025
SELECT 'LF 2025' as Periode, SUM(montant) as Total 
FROM RecettesInterieurs 
WHERE annee = 2025;

-- Affichage de toutes les recettes par nature d'impôt
SELECT 
    ni.nom,
    ri.annee,
    ri.montant
FROM RecettesInterieurs ri
INNER JOIN NatureImpots ni ON ri.idNatureImpots = ni.idNatureImpots
ORDER BY ri.annee, ni.idNatureImpots;
