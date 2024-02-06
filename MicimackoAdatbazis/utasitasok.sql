CREATE TABLE  IF NOT EXISTS Szereplok
(SzereploAz INTEGER PRIMARY KEY AUTOINCREMENT,
Nev VARCHAR(30))
;
:

CREATE TABLE  IF NOT EXISTS Gyumolcsok
(GyumolcsAz INTEGER PRIMARY KEY AUTOINCREMENT,
Nev VARCHAR(30))
;
:

CREATE TABLE  IF NOT EXISTS SzereplokGyumolcsok
(SzereploAz INTEGER ,
GyumolcsAz INTEGER,
PRIMARY KEY(SzereploAz,GyumolcsAz),
FOREIGN KEY (SzereploAz) REFERENCES Szereplok(SzereploAz),
FOREIGN KEY (GyumolcsAz) REFERENCES Gyumolcsok(GyumolcsAz))
;
:
INSERT INTO Szereplok(Nev) VALUES ("Micimackó")
;
:

INSERT INTO Szereplok(Nev) VALUES ("Malacka")
;
:
