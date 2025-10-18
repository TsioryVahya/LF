-- ========================================
-- NATURE DES IMPOTS ET RECETTES INTERIEURES
-- ========================================
CREATE TABLE NatureImpots (
    idNatureImpots SERIAL PRIMARY KEY,
    nom VARCHAR(250) NOT NULL
);

CREATE TABLE RecettesInterieurs (
    idRecettesInterieurs SERIAL PRIMARY KEY,
    annee INTEGER NOT NULL,
    montant NUMERIC(15,2) NOT NULL,
    idNatureImpots INTEGER NOT NULL,
    CONSTRAINT fk_recettes_interieurs_nature 
        FOREIGN KEY(idNatureImpots) 
        REFERENCES NatureImpots(idNatureImpots)
        ON DELETE CASCADE
);

-- ========================================
-- NATURE DES DROITS ET TAXES ET RECETTES DOUANIERES
-- ========================================
CREATE TABLE NatureDroitsetTaxes (
    idNatureDroitsetTaxes SERIAL PRIMARY KEY,
    nom VARCHAR(250) NOT NULL
);

CREATE TABLE RecettesDouanieres (
    idRecettesDouanieres SERIAL PRIMARY KEY,
    annee INTEGER NOT NULL,
    montant NUMERIC(15,2) NOT NULL,
    idNatureDroitsetTaxes INTEGER NOT NULL,
    CONSTRAINT fk_recettes_douanieres_nature 
        FOREIGN KEY(idNatureDroitsetTaxes) 
        REFERENCES NatureDroitsetTaxes(idNatureDroitsetTaxes)
        ON DELETE CASCADE
);

-- ========================================
-- NATURE DES RECETTES NON FISCALES
-- ========================================
CREATE TABLE NatureRecettesNonFiscales (
    idNatureRecettesNonFiscales SERIAL PRIMARY KEY,
    nom VARCHAR(250) NOT NULL
);

CREATE TABLE RecettesNonFiscales (
    idRecettesNonFiscales SERIAL PRIMARY KEY,
    annee INTEGER NOT NULL,
    montant NUMERIC(15,2) NOT NULL,
    idNatureRecettesNonFiscales INTEGER NOT NULL,
    CONSTRAINT fk_recettes_non_fiscales_nature 
        FOREIGN KEY(idNatureRecettesNonFiscales) 
        REFERENCES NatureRecettesNonFiscales(idNatureRecettesNonFiscales)
        ON DELETE CASCADE
);

-- ========================================
-- NATURE DES DONS
-- ========================================
CREATE TABLE NatureDons (
    idNatureDons SERIAL PRIMARY KEY,
    nom VARCHAR(250) NOT NULL
);

CREATE TABLE Dons (
    idDons SERIAL PRIMARY KEY,
    annee INTEGER NOT NULL,
    montant NUMERIC(15,2) NOT NULL,
    idNatureDons INTEGER NOT NULL,
    CONSTRAINT fk_dons_nature 
        FOREIGN KEY(idNatureDons) 
        REFERENCES NatureDons(idNatureDons)
        ON DELETE CASCADE
);
