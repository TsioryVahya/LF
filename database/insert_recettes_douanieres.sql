-- Script d'insertion des données de Recettes Douanières
-- Loi de Finances 2025

-- Insertion des natures de droits et taxes
INSERT INTO NatureDroitsetTaxes (nom) VALUES
('Droit de douane'),
('TVA à l''importation'),
('Taxe sur les produits pétroliers'),
('TVA sur les produits pétroliers'),
('Droit de navigation'),
('Autres');

-- Insertion des recettes douanières pour LFR 2024

-- Droit de douane - LFR 2024
INSERT INTO RecettesDouanieres (idNatureDroitsetTaxes, annee, montant) 
VALUES (1, 2024, 847.5);

-- TVA à l'importation - LFR 2024
INSERT INTO RecettesDouanieres (idNatureDroitsetTaxes, annee, montant) 
VALUES (2, 2024, 1768.3);

-- Taxe sur les produits pétroliers - LFR 2024
INSERT INTO RecettesDouanieres (idNatureDroitsetTaxes, annee, montant) 
VALUES (3, 2024, 308.0);

-- TVA sur les produits pétroliers - LFR 2024
INSERT INTO RecettesDouanieres (idNatureDroitsetTaxes, annee, montant) 
VALUES (4, 2024, 842.8);

-- Droit de navigation - LFR 2024
INSERT INTO RecettesDouanieres (idNatureDroitsetTaxes, annee, montant) 
VALUES (5, 2024, 1.2);

-- Autres - LFR 2024
INSERT INTO RecettesDouanieres (idNatureDroitsetTaxes, annee, montant) 
VALUES (6, 2024, 0.2);

-- =====================================================
-- Insertion des recettes douanières pour LF 2025
-- =====================================================

-- Droit de douane - LF 2025
INSERT INTO RecettesDouanieres (idNatureDroitsetTaxes, annee, montant) 
VALUES (1, 2025, 1010.7);

-- TVA à l'importation - LF 2025
INSERT INTO RecettesDouanieres (idNatureDroitsetTaxes, annee, montant) 
VALUES (2, 2025, 2148.3);

-- Taxe sur les produits pétroliers - LF 2025
INSERT INTO RecettesDouanieres (idNatureDroitsetTaxes, annee, montant) 
VALUES (3, 2025, 326.0);

-- TVA sur les produits pétroliers - LF 2025
INSERT INTO RecettesDouanieres (idNatureDroitsetTaxes, annee, montant) 
VALUES (4, 2025, 879.0);

-- Droit de navigation - LF 2025
INSERT INTO RecettesDouanieres (idNatureDroitsetTaxes, annee, montant) 
VALUES (5, 2025, 1.9);

-- Autres - LF 2025
INSERT INTO RecettesDouanieres (idNatureDroitsetTaxes, annee, montant) 
VALUES (6, 2025, 0.1);

-- Vérification des totaux
-- TOTAL LFR 2024: 3 768,0 milliards d'Ariary
-- TOTAL LF 2025: 4 366,0 milliards d'Ariary

-- Requête de vérification pour LFR 2024
SELECT 'LFR 2024' as Periode, SUM(montant) as Total 
FROM RecettesDouanieres 
WHERE annee = 2024;

-- Requête de vérification pour LF 2025
SELECT 'LF 2025' as Periode, SUM(montant) as Total 
FROM RecettesDouanieres 
WHERE annee = 2025;

-- Affichage de toutes les recettes par nature de droits et taxes
SELECT 
    ndt.nom,
    rd.annee,
    rd.montant
FROM RecettesDouanieres rd
INNER JOIN NatureDroitsetTaxes ndt ON rd.idNatureDroitsetTaxes = ndt.idNatureDroitsetTaxes
ORDER BY rd.annee, ndt.idNatureDroitsetTaxes;
