CREATE DATABASE  IF NOT EXISTS `moviesdb`;
USE `moviesdb`;

DROP TABLE IF EXISTS `accounts`;
CREATE TABLE `accounts` (
                            `API_KEY` char(32) NOT NULL,
                            `plan` varchar(40) NOT NULL,
                            `monthlyCallsMade` int DEFAULT '0',
                            `renewalDate` datetime DEFAULT CURRENT_TIMESTAMP,
                            PRIMARY KEY (`API_KEY`)
);

DROP TABLE IF EXISTS `account_events`;
CREATE TABLE `account_events` (
                                  `API_KEY` char(32) NOT NULL,
                                  `plan` varchar(40) NOT NULL,
                                  `renewalDate` datetime NOT NULL,
                                  KEY `API_KEY` (`API_KEY`),
                                  CONSTRAINT `account_events_ibfk_1` FOREIGN KEY (`API_KEY`) REFERENCES `accounts` (`API_KEY`)
);

DROP TABLE IF EXISTS `names`;
CREATE TABLE `names` (
                         `nconst` char(11) NOT NULL,
                         `primaryName` varchar(255) NOT NULL,
                         `birthYear` char(4) NOT NULL,
                         `deathYear` varchar(4) DEFAULT NULL,
                         PRIMARY KEY (`nconst`)
);

LOCK TABLES `names` WRITE;
INSERT INTO `names` VALUES ('nm0000168','Samuel L. Jackson','1948',NULL),('nm0000204','Natalie Portman','1981',NULL),('nm0000332','Don Cheadle','1964',NULL),('nm0000375','Robert Downey Jr.','1965',NULL),('nm0000569','Gwyneth Paltrow','1972',NULL),('nm0000673','Marisa Tomei','1964',NULL),('nm0000982','Josh Brolin','1968',NULL),('nm0001497','Tobey Maguire','1975',NULL),('nm0004937','Jamie Foxx','1967',NULL),('nm0079273','Paul Bettany','1971',NULL),('nm0163988','Clark Gregg','1962',NULL),('nm0177896','Bradley Cooper','1975',NULL),('nm0252961','Idris Elba','1972',NULL),('nm0262635','Chris Evans','1981',NULL),('nm0269463','Jon Favreau','1966',NULL),('nm0424060','Scarlett Johansson','1984',NULL),('nm0488953','Brie Larson','1989',NULL),('nm0647634','Elizabeth Olsen','1989',NULL),('nm0695435','Chris Pratt','1979',NULL),('nm0719637','Jeremy Renner','1971',NULL),('nm0748620','Paul Rudd','1969',NULL),('nm0749263','Mark Ruffalo','1967',NULL),('nm0757855','Zoe Saldana','1978',NULL),('nm0885840','Emily VanCamp','1986',NULL),('nm0938950','Benedict Wong','1970',NULL),('nm1089991','Tom Hiddleston','1981',NULL),('nm1107001','Anthony Mackie','1978',NULL),('nm1130627','Cobie Smulders','1982',NULL),('nm1165110','Chris Hemsworth','1983',NULL),('nm1176985','Dave Bautista','1969',NULL),('nm1212722','Benedict Cumberbatch','1976',NULL),('nm1569276','Chadwick Boseman','1976','2020'),('nm1659221','Sebastian Stan','1982',NULL),('nm1940449','Andrew Garfield','1983',NULL),('nm2017943','Hayley Atwell','1982',NULL),('nm2394794','Karen Gillan','1987',NULL),('nm3918035','Zendaya','1996',NULL),('nm4043618','Tom Holland','1996',NULL),('nm4855517','Simu Liu','1989',NULL),('nm8188622','Jacob Batalon','1996',NULL);
UNLOCK TABLES;

DROP TABLE IF EXISTS `titles`;
CREATE TABLE `titles` (
    
                          `tconst` varchar(11) NOT NULL,
                          `primaryTitle` varchar(255) NOT NULL,
                          `originalTitle` varchar(255) NOT NULL,
                          `startYear` char(4) NOT NULL,
                          PRIMARY KEY (`tconst`)
);

LOCK TABLES `titles` WRITE;
INSERT INTO `titles` VALUES ('tt0104952','My Cousin Vinny','My Cousin Vinny','1992'),('tt0110413','L??on: The Professional','L??on','1994'),('tt0110912','Pulp Fiction','Pulp Fiction','1994'),('tt0116191','Emma','Emma','1996'),('tt0117802','Swingers','Swingers','1996'),('tt0120148','Sliding Doors','Sliding Doors','1998'),('tt0120789','Pleasantville','Pleasantville','1998'),('tt0138097','Shakespeare in Love','Shakespeare in Love','1998'),('tt0145487','Spider-Man','Spider-Man','2002'),('tt0162346','Ghost World','Ghost World','2001'),('tt0185014','Wonder Boys','Wonder Boys','2000'),('tt0207201','What Women Want','What Women Want','2000'),('tt0247425','In the Bedroom','In the Bedroom','2001'),('tt0335266','Lost in Translation','Lost in Translation','2003'),('tt0350258','Ray','Ray','2004'),('tt0369339','Collateral','Collateral','2004'),('tt0369610','Jurassic World','Jurassic World','2015'),('tt0371746','Iron Man','Iron Man','2008'),('tt0375679','Crash','Crash','2004'),('tt0376541','Closer','Closer','2004'),('tt0395169','Hotel Rwanda','Hotel Rwanda','2004'),('tt0417148','Snakes on a Plane','Snakes on a Plane','2006'),('tt0434409','V for Vendetta','V for Vendetta','2005'),('tt0443489','Dreamgirls','Dreamgirls','2006'),('tt0458339','Captain America: The First Avenger','Captain America: The First Avenger','2011'),('tt0462128','The New Adventures of Old Christine','The New Adventures of Old Christine','2006'),('tt0477348','No Country for Old Men','No Country for Old Men','2007'),('tt0478970','Ant-Man','Ant-Man','2015'),('tt0480255','The Losers','The Losers','2010'),('tt0499549','Avatar','Avatar','2009'),('tt0758737','Brothers & Sisters','Brothers & Sisters','2006'),('tt0765010','Brothers','Brothers','2009'),('tt0796366','Star Trek','Star Trek','2009'),('tt0800369','Thor','Thor','2011'),('tt0840361','The Town','The Town','2010'),('tt0842926','The Kids Are All Right','The Kids Are All Right','2010'),('tt0848228','The Avengers','The Avengers','2012'),('tt0864761','The Duchess','The Duchess','2008'),('tt0887912','The Hurt Locker','The Hurt Locker','2008'),('tt0947798','Black Swan','Black Swan','2010'),('tt0948470','The Amazing Spider-Man','The Amazing Spider-Man','2012'),('tt0988045','Sherlock Holmes','Sherlock Holmes','2009'),('tt0988047','Traitor','Traitor','2008'),('tt1024715','Choke','Choke','2008'),('tt1045658','Silver Linings Playbook','Silver Linings Playbook','2012'),('tt10872600','Spider-Man: No Way Home','Spider-Man: No Way Home','2021'),('tt1100089','Foxcatcher','Foxcatcher','2014'),('tt1125849','The Wrestler','The Wrestler','2008'),('tt1155056','I Love You, Man','I Love You, Man','2009'),('tt1211837','Doctor Strange','Doctor Strange','2016'),('tt1266020','Parks and Recreation','Parks and Recreation','2009'),('tt1285016','The Social Network','The Social Network','2010'),('tt1300854','Iron Man 3','Iron Man Three','2013'),('tt1322269','August: Osage County','August: Osage County','2013'),('tt1365050','Beasts of No Nation','Beasts of No Nation','2015'),('tt1385826','The Adjustment Bureau','The Adjustment Bureau','2011'),('tt1408101','Star Trek Into Darkness','Star Trek Into Darkness','2013'),('tt1441326','Martha Marcy May Marlene','Martha Marcy May Marlene','2011'),('tt1485796','The Greatest Showman','The Greatest Showman','2017'),('tt1490017','The Lego Movie','The Lego Movie','2014'),('tt1517451','A Star Is Born','A Star Is Born','2018'),('tt1540133','The Guard','The Guard','2011'),('tt1649419','The Impossible','Lo imposible','2012'),('tt1659337','The Perks of Being a Wallflower','The Perks of Being a Wallflower','2012'),('tt1663662','Pacific Rim','Pacific Rim','2013'),('tt1702439','Safe Haven','Safe Haven','2013'),('tt1735898','Snow White and the Huntsman','Snow White and the Huntsman','2012'),('tt1791528','Inherent Vice','Inherent Vice','2014'),('tt1798709','Her','Her','2013'),('tt1800241','American Hustle','American Hustle','2013'),('tt1808339','Not Another Happy Ending','Not Another Happy Ending','2013'),('tt1825683','Black Panther','Black Panther','2018'),('tt1837642','Revenge','Revenge','2011'),('tt1843866','Captain America: The Winter Soldier','Captain America: The Winter Soldier','2014'),('tt1853728','Django Unchained','Django Unchained','2012'),('tt1856101','Blade Runner 2049','Blade Runner 2049','2017'),('tt1872181','The Amazing Spider-Man 2','The Amazing Spider-Man 2','2014'),('tt1895587','Spotlight','Spotlight','2015'),('tt1981115','Thor: The Dark World','Thor: The Dark World','2013'),('tt2015381','Guardians of the Galaxy','Guardians of the Galaxy','2014'),('tt2084970','The Imitation Game','The Imitation Game','2014'),('tt2119532','Hacksaw Ridge','Hacksaw Ridge','2016'),('tt2179136','American Sniper','American Sniper','2014'),('tt2250912','Spider-Man: Homecoming','Spider-Man: Homecoming','2017'),('tt2364582','Agents of S.H.I.E.L.D.','Agents of S.H.I.E.L.D.','2013'),('tt2370248','Short Term 12','Short Term 12','2013'),('tt2395427','Avengers: Age of Ultron','Avengers: Age of Ultron','2015'),('tt2798920','Annihilation','Annihilation','2018'),('tt2883512','Chef','Chef','2014'),('tt3170832','Room','Room','2015'),('tt3393786','Jack Reacher: Never Go Back','Jack Reacher: Never Go Back','2016'),('tt3460252','The Hateful Eight','The Hateful Eight','2015'),('tt3498820','Captain America: Civil War','Captain America: Civil War','2016'),('tt3501632','Thor: Ragnarok','Thor: Ragnarok','2017'),('tt3549044','Selfie','Selfie','2014'),('tt3659388','The Martian','The Martian','2015'),('tt3896198','Guardians of the Galaxy Vol. 2','Guardians of the Galaxy Vol. 2','2017'),('tt4154664','Captain Marvel','Captain Marvel','2019'),('tt4154756','Avengers: Infinity War','Avengers: Infinity War','2018'),('tt4154796','Avengers: Endgame','Avengers: Endgame','2019'),('tt4474750','Blood and Water','Blood and Water','2015'),('tt5052460','Taken','Taken','2017'),('tt5095030','Ant-Man and the Wasp','Ant-Man and the Wasp','2018'),('tt5362988','Wind River','Wind River','2017'),('tt5912064','Kim\'s Convenience','Kim\'s Convenience','2016'),('tt6320628','Spider-Man: Far from Home','Spider-Man: Far from Home','2019'),('tt9140560','WandaVision','WandaVision','2021'),('tt9376612','Shang-Chi and the Legend of the Ten Rings','Shang-Chi and the Legend of the Ten Rings','2021');
UNLOCK TABLES;

DROP TABLE IF EXISTS `ratings`;
CREATE TABLE `ratings` (
                           `tconst` varchar(11) DEFAULT NULL,
                           `averageRating` float NOT NULL,
                           UNIQUE KEY `tconst` (`tconst`),
                           CONSTRAINT `ratings_ibfk_1` FOREIGN KEY (`tconst`) REFERENCES `titles` (`tconst`)
);

LOCK TABLES `ratings` WRITE;
INSERT INTO `ratings` VALUES ('tt0104952',7.6),('tt0110413',8.5),('tt0110912',8.9),('tt0116191',6.6),('tt0117802',7.2),('tt0120148',6.7),('tt0120789',7.5),('tt0138097',7.1),('tt0145487',7.4),('tt0162346',7.3),('tt0185014',7.2),('tt0207201',6.4),('tt0247425',7.4),('tt0335266',7.7),('tt0350258',7.7),('tt0369339',7.5),('tt0369610',6.9),('tt0371746',7.9),('tt0375679',7.8),('tt0376541',7.2),('tt0395169',8.1),('tt0417148',5.5),('tt0434409',8.2),('tt0443489',6.5),('tt0458339',6.9),('tt0462128',7.1),('tt0477348',8.2),('tt0478970',7.3),('tt0480255',6.3),('tt0499549',7.8),('tt0758737',7.4),('tt0765010',7.1),('tt0796366',7.9),('tt0800369',7),('tt0840361',7.5),('tt0842926',7),('tt0848228',8),('tt0864761',6.9),('tt0887912',7.5),('tt0947798',8),('tt0948470',6.9),('tt0988045',7.6),('tt0988047',6.9),('tt1024715',6.4),('tt1045658',7.7),('tt10872600',8.3),('tt1100089',7),('tt1125849',7.9),('tt1155056',7),('tt1211837',7.5),('tt1266020',8.6),('tt1285016',7.8),('tt1300854',7.1),('tt1322269',7.2),('tt1365050',7.7),('tt1385826',7),('tt1408101',7.7),('tt1441326',6.8),('tt1485796',7.5),('tt1490017',7.7),('tt1517451',7.6),('tt1540133',7.3),('tt1649419',7.5),('tt1659337',8),('tt1663662',6.9),('tt1702439',6.6),('tt1735898',6.1),('tt1791528',6.6),('tt1798709',8),('tt1800241',7.2),('tt1808339',6.1),('tt1825683',7.3),('tt1837642',7.8),('tt1843866',7.8),('tt1853728',8.4),('tt1856101',8),('tt1872181',6.6),('tt1895587',8.1),('tt1981115',6.8),('tt2015381',8),('tt2084970',8),('tt2119532',8.1),('tt2179136',7.3),('tt2250912',7.4),('tt2364582',7.5),('tt2370248',7.9),('tt2395427',7.3),('tt2798920',6.8),('tt2883512',7.3),('tt3170832',8.1),('tt3393786',6.1),('tt3460252',7.8),('tt3498820',7.8),('tt3501632',7.9),('tt3549044',7.2),('tt3659388',8),('tt3896198',7.6),('tt4154664',6.8),('tt4154756',8.4),('tt4154796',8.4),('tt4474750',5.1),('tt5052460',6.5),('tt5095030',7),('tt5362988',7.7),('tt5912064',8.2),('tt6320628',7.4),('tt9140560',8),('tt9376612',7.4);
UNLOCK TABLES;

DROP TABLE IF EXISTS `works`;
CREATE TABLE `works` (
                         `nconst` char(11) NOT NULL,
                         `tconst` varchar(11) NOT NULL,
                         KEY `tconst` (`tconst`),
                         KEY `workIndex` (`nconst`,`tconst`),
                         CONSTRAINT `works_ibfk_1` FOREIGN KEY (`nconst`) REFERENCES `names` (`nconst`) ON DELETE CASCADE ON UPDATE CASCADE,
                         CONSTRAINT `works_ibfk_2` FOREIGN KEY (`tconst`) REFERENCES `titles` (`tconst`) ON DELETE CASCADE ON UPDATE CASCADE
);

LOCK TABLES `works` WRITE;
INSERT INTO `works` VALUES ('nm0000168','tt0110912'),('nm0000168','tt0417148'),('nm0000168','tt3460252'),('nm0000168','tt4154664'),('nm0000204','tt0110413'),('nm0000204','tt0376541'),('nm0000204','tt0434409'),('nm0000204','tt0947798'),('nm0000332','tt0375679'),('nm0000332','tt0395169'),('nm0000332','tt0988047'),('nm0000332','tt1540133'),('nm0000375','tt0371746'),('nm0000375','tt0988045'),('nm0000375','tt1300854'),('nm0000375','tt4154796'),('nm0000569','tt0116191'),('nm0000569','tt0120148'),('nm0000569','tt0138097'),('nm0000569','tt1300854'),('nm0000673','tt0104952'),('nm0000673','tt0207201'),('nm0000673','tt0247425'),('nm0000673','tt1125849'),('nm0000982','tt0477348'),('nm0000982','tt1791528'),('nm0000982','tt4154756'),('nm0000982','tt4154796'),('nm0001497','tt0120789'),('nm0001497','tt0145487'),('nm0001497','tt0185014'),('nm0001497','tt0765010'),('nm0004937','tt0350258'),('nm0004937','tt0369339'),('nm0004937','tt0443489'),('nm0004937','tt1853728'),('nm0079273','tt9140560'),('nm0163988','tt0462128'),('nm0163988','tt0848228'),('nm0163988','tt1024715'),('nm0163988','tt2364582'),('nm0177896','tt1045658'),('nm0177896','tt1517451'),('nm0177896','tt1800241'),('nm0177896','tt2179136'),('nm0252961','tt0480255'),('nm0252961','tt1365050'),('nm0252961','tt1663662'),('nm0252961','tt3501632'),('nm0262635','tt0458339'),('nm0262635','tt0848228'),('nm0262635','tt2395427'),('nm0262635','tt3498820'),('nm0269463','tt0117802'),('nm0269463','tt0371746'),('nm0269463','tt2883512'),('nm0269463','tt4154796'),('nm0424060','tt0162346'),('nm0424060','tt0335266'),('nm0424060','tt0848228'),('nm0424060','tt1798709'),('nm0488953','tt2370248'),('nm0488953','tt3170832'),('nm0488953','tt4154664'),('nm0488953','tt4154796'),('nm0647634','tt1441326'),('nm0647634','tt2395427'),('nm0647634','tt4154756'),('nm0647634','tt5362988'),('nm0695435','tt0369610'),('nm0695435','tt1266020'),('nm0695435','tt1490017'),('nm0695435','tt2015381'),('nm0719637','tt0840361'),('nm0719637','tt0848228'),('nm0719637','tt0887912'),('nm0719637','tt5362988'),('nm0748620','tt0478970'),('nm0748620','tt1155056'),('nm0748620','tt1659337'),('nm0748620','tt5095030'),('nm0749263','tt0842926'),('nm0749263','tt0848228'),('nm0749263','tt1100089'),('nm0749263','tt1895587'),('nm0757855','tt0499549'),('nm0757855','tt0796366'),('nm0757855','tt2015381'),('nm0757855','tt3896198'),('nm0885840','tt0758737'),('nm0885840','tt1837642'),('nm0885840','tt1843866'),('nm0885840','tt3498820'),('nm0938950','tt1211837'),('nm0938950','tt2798920'),('nm0938950','tt3659388'),('nm0938950','tt4154756'),('nm1089991','tt0800369'),('nm1089991','tt0848228'),('nm1089991','tt1981115'),('nm1089991','tt3501632'),('nm1107001','tt0887912'),('nm1107001','tt1385826'),('nm1107001','tt1843866'),('nm1107001','tt3498820'),('nm1130627','tt0848228'),('nm1130627','tt1702439'),('nm1130627','tt2395427'),('nm1130627','tt3393786'),('nm1165110','tt0800369'),('nm1165110','tt0848228'),('nm1165110','tt1735898'),('nm1165110','tt3501632'),('nm1176985','tt1856101'),('nm1176985','tt2015381'),('nm1176985','tt3896198'),('nm1176985','tt4154756'),('nm1212722','tt1211837'),('nm1212722','tt1322269'),('nm1212722','tt1408101'),('nm1212722','tt2084970'),('nm1569276','tt1825683'),('nm1569276','tt3498820'),('nm1569276','tt4154756'),('nm1569276','tt4154796'),('nm1659221','tt0458339'),('nm1659221','tt1843866'),('nm1659221','tt3498820'),('nm1659221','tt4154796'),('nm1940449','tt0948470'),('nm1940449','tt1285016'),('nm1940449','tt1872181'),('nm1940449','tt2119532'),('nm2017943','tt0458339'),('nm2017943','tt0478970'),('nm2017943','tt0864761'),('nm2017943','tt1843866'),('nm2394794','tt1808339'),('nm2394794','tt2015381'),('nm2394794','tt3549044'),('nm2394794','tt4154796'),('nm3918035','tt10872600'),('nm3918035','tt1485796'),('nm3918035','tt2250912'),('nm3918035','tt6320628'),('nm4043618','tt10872600'),('nm4043618','tt1649419'),('nm4043618','tt2250912'),('nm4043618','tt3498820'),('nm4043618','tt6320628'),('nm4855517','tt4474750'),('nm4855517','tt5052460'),('nm4855517','tt5912064'),('nm4855517','tt9376612'),('nm8188622','tt10872600'),('nm8188622','tt2250912'),('nm8188622','tt4154756'),('nm8188622','tt6320628');
UNLOCK TABLES;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetCastsByTconst`(
    IN tconst CHAR(11)
)
BEGIN
    SELECT names.nconst, names.primaryName
    FROM works
    JOIN names ON names.nconst = works.nconst
    WHERE works.tconst = tconst;
END ;;
DELIMITER ;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetWorksByNconst`(    
    IN nconst CHAR(11) 
)
BEGIN 
    SELECT t.tconst, t.primaryTitle, t.originalTitle, t.startYear 
    FROM titles AS t 
    JOIN works AS w ON w.tconst = t.tconst 
    WHERE w.nconst = nconst; 
END ;;
DELIMITER ;