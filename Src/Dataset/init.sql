CREATE TABLE superheroes (
    id SERIAL UNIQUE,
    name TEXT NOT NULL,
    description TEXT,
    place TEXT
);

COPY superheroes
FROM '/docker-entrypoint-initdb.d/superheroes.csv'
DELIMITER ','
CSV HEADER;