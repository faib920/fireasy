/*
Navicat Oracle Data Transfer
Oracle Client Version : 11.1.0.6.0

Source Server         : oracle
Source Server Version : 110100
Source Host           : 127.0.0.1:1521
Source Schema         : NORTHWIND

Target Server Type    : ORACLE
Target Server Version : 110100
File Encoding         : 65001

Date: 2015-01-28 16:02:25
*/


-- ----------------------------
-- Table structure for CATEGORIES
-- ----------------------------
--DROP TABLE "CATEGORIES";
CREATE TABLE "CATEGORIES" (
"CATEGORYID" NUMBER(38) NOT NULL ,
"CATEGORYNAME" VARCHAR2(15 BYTE) NOT NULL ,
"DESCRIPTION" CLOB NULL ,
"PICTURE" BLOB NULL 
)
LOGGING
NOCOMPRESS
NOCACHE

;

-- ----------------------------
-- Records of CATEGORIES
-- ----------------------------
INSERT INTO "CATEGORIES" VALUES ('1', 'Beverages', 'Soft drinks, coffees, teas, beers, and ales', null);
INSERT INTO "CATEGORIES" VALUES ('2', 'Condiments', 'Sweet and savory sauces, relishes, spreads, and seasonings', null);
INSERT INTO "CATEGORIES" VALUES ('3', 'Confections', 'Desserts, candies, and sweet breads', null);
INSERT INTO "CATEGORIES" VALUES ('4', 'Dairy Products', 'Cheeses', null);
INSERT INTO "CATEGORIES" VALUES ('5', 'Grains/Cereals', 'Breads, crackers, pasta, and cereal', null);
INSERT INTO "CATEGORIES" VALUES ('6', 'Meat/Poultry', 'Prepared meats', null);
INSERT INTO "CATEGORIES" VALUES ('7', 'Produce', 'Dried fruit and bean curd', null);
INSERT INTO "CATEGORIES" VALUES ('8', 'Seafood', 'Seaweed and fish', null);

-- ----------------------------
-- Table structure for CUSTOMERCUSTOMERDEMO
-- ----------------------------
--DROP TABLE "CUSTOMERCUSTOMERDEMO";
CREATE TABLE "CUSTOMERCUSTOMERDEMO" (
"CUSTOMERID" CHAR(5 BYTE) NOT NULL ,
"CUSTOMERTYPEID" CHAR(10 BYTE) NOT NULL 
)
LOGGING
NOCOMPRESS
NOCACHE

;

-- ----------------------------
-- Records of CUSTOMERCUSTOMERDEMO
-- ----------------------------

-- ----------------------------
-- Table structure for CUSTOMERDEMOGRAPHICS
-- ----------------------------
--DROP TABLE "CUSTOMERDEMOGRAPHICS";
CREATE TABLE "CUSTOMERDEMOGRAPHICS" (
"CUSTOMERTYPEID" CHAR(10 BYTE) NOT NULL ,
"CUSTOMERDESC" CLOB NULL 
)
LOGGING
NOCOMPRESS
NOCACHE

;

-- ----------------------------
-- Records of CUSTOMERDEMOGRAPHICS
-- ----------------------------

-- ----------------------------
-- Table structure for CUSTOMERS
-- ----------------------------
--DROP TABLE "CUSTOMERS";
CREATE TABLE "CUSTOMERS" (
"CUSTOMERID" CHAR(5 BYTE) NOT NULL ,
"COMPANYNAME" VARCHAR2(40 BYTE) NOT NULL ,
"CONTACTNAME" VARCHAR2(30 BYTE) DEFAULT NULL  NULL ,
"CONTACTTITLE" VARCHAR2(30 BYTE) DEFAULT NULL  NULL ,
"ADDRESS" VARCHAR2(60 BYTE) DEFAULT NULL  NULL ,
"CITY" VARCHAR2(15 BYTE) DEFAULT NULL  NULL ,
"REGION" VARCHAR2(15 BYTE) DEFAULT NULL  NULL ,
"POSTALCODE" VARCHAR2(10 BYTE) DEFAULT NULL  NULL ,
"COUNTRY" VARCHAR2(15 BYTE) DEFAULT NULL  NULL ,
"PHONE" VARCHAR2(24 BYTE) DEFAULT NULL  NULL ,
"FAX" VARCHAR2(24 BYTE) DEFAULT NULL  NULL 
)
LOGGING
NOCOMPRESS
NOCACHE

;

-- ----------------------------
-- Records of CUSTOMERS
-- ----------------------------
INSERT INTO "CUSTOMERS" VALUES ('ALFKI', 'Alfreds Futterkiste', 'Maria Anders', 'Sales Representative', 'Obere Str. 57', 'Berlin', null, '12209', 'Germany', '030-0074321', '030-0076545');
INSERT INTO "CUSTOMERS" VALUES ('ANATR', 'Ana Trujillo Emparedados y helados', 'Ana Trujillo', 'Owner', 'Avda. de la Constituci贸n 2222', 'M茅xico D.F.', null, '05021', 'Mexico', '(5) 555-4729', '(5) 555-3745');
INSERT INTO "CUSTOMERS" VALUES ('ANTON', 'Antonio Moreno Taquer铆a', 'Antonio Moreno', 'Owner', 'Mataderos  2312', 'M茅xico D.F.', null, '05023', 'Mexico', '(5) 555-3932', null);
INSERT INTO "CUSTOMERS" VALUES ('AROUT', 'Around the Horn', 'Thomas Hardy', 'Sales Representative', '120 Hanover Sq.', 'London', null, 'WA1 1DP', 'UK', '(171) 555-7788', '(171) 555-6750');
INSERT INTO "CUSTOMERS" VALUES ('BERGS', 'Berglunds snabbk枚p', 'Christina Berglund', 'Order Administrator', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden', '0921-12 34 65', '0921-12 34 67');
INSERT INTO "CUSTOMERS" VALUES ('BLAUS', 'Blauer See Delikatessen', 'Hanna Moos', 'Sales Representative', 'Forsterstr. 57', 'Mannheim', null, '68306', 'Germany', '0621-08460', '0621-08924');
INSERT INTO "CUSTOMERS" VALUES ('BLONP', 'Blondesddsl p猫re et fils', 'Fr茅d茅rique Citeaux', 'Marketing Manager', '24, place Kl茅ber', 'Strasbourg', null, '67000', 'France', '88.60.15.31', '88.60.15.32');
INSERT INTO "CUSTOMERS" VALUES ('BOLID', 'B贸lido Comidas preparadas', 'Mart铆n Sommer', 'Owner', 'C/ Araquil, 67', 'Madrid', null, '28023', 'Spain', '(91) 555 22 82', '(91) 555 91 99');
INSERT INTO "CUSTOMERS" VALUES ('BONAP', 'Bon app', 'Laurence Lebihan', 'Owner', '12, rue des Bouchers', 'Marseille', null, '13008', 'France', '91.24.45.40', '91.24.45.41');
INSERT INTO "CUSTOMERS" VALUES ('BOTTM', 'Bottom-Dollar Markets', 'Elizabeth Lincoln', 'Accounting Manager', '23 Tsawassen Blvd.', 'Tsawassen', 'BC', 'T2F 8M4', 'Canada', '(604) 555-4729', '(604) 555-3745');
INSERT INTO "CUSTOMERS" VALUES ('BSBEV', 'Bs Beverages', 'Victoria Ashworth', 'Sales Representative', 'Fauntleroy Circus', 'London', null, 'EC2 5NT', 'UK', '(171) 555-1212', null);
INSERT INTO "CUSTOMERS" VALUES ('CACTU', 'Cactus Comidas para llevar', 'Patricio Simpson', 'Sales Agent', 'Cerrito 333', 'Buenos Aires', null, '1010', 'Argentina', '(1) 135-5555', '(1) 135-4892');
INSERT INTO "CUSTOMERS" VALUES ('CENTC', 'Centro comercial Moctezuma', 'Francisco Chang', 'Marketing Manager', 'Sierras de Granada 9993', 'M茅xico D.F.', null, '05022', 'Mexico', '(5) 555-3392', '(5) 555-7293');
INSERT INTO "CUSTOMERS" VALUES ('CHOPS', 'Chop-suey Chinese', 'Yang Wang', 'Owner', 'Hauptstr. 29', 'Bern', null, '3012', 'Switzerland', '0452-076545', null);
INSERT INTO "CUSTOMERS" VALUES ('COMMI', 'Com茅rcio Mineiro', 'Pedro Afonso', 'Sales Associate', 'Av. dos Lus铆adas, 23', 'Sao Paulo', 'SP', '05432-043', 'Brazil', '(11) 555-7647', null);
INSERT INTO "CUSTOMERS" VALUES ('CONSH', 'Consolidated Holdings', 'Elizabeth Brown', 'Sales Representative', 'Berkeley Gardens 12  Brewery', 'London', null, 'WX1 6LT', 'UK', '(171) 555-2282', '(171) 555-9199');
INSERT INTO "CUSTOMERS" VALUES ('DRACD', 'Drachenblut Delikatessen', 'Sven Ottlieb', 'Order Administrator', 'Walserweg 21', 'Aachen', null, '52066', 'Germany', '0241-039123', '0241-059428');
INSERT INTO "CUSTOMERS" VALUES ('DUMON', 'Du monde entier', 'Janine Labrune', 'Owner', '67, rue des Cinquante Otages', 'Nantes', null, '44000', 'France', '40.67.88.88', '40.67.89.89');
INSERT INTO "CUSTOMERS" VALUES ('EASTC', 'Eastern Connection', 'Ann DevonXXXX', 'Sales Agent', '35 King George', 'London', null, 'WX3 6FW', 'UK', '(171) 555-0297', '(171) 555-3373');
INSERT INTO "CUSTOMERS" VALUES ('ERNSH', 'Ernst Handel', 'Roland Mendel', 'Sales Manager', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria', '7675-3425', '7675-3426');
INSERT INTO "CUSTOMERS" VALUES ('FAMIA', 'Familia Arquibaldo', 'Aria Cruz', 'Marketing Assistant', 'Rua Or贸s, 92', 'Sao Paulo', 'SP', '05442-030', 'Brazil', '(11) 555-9857', null);
INSERT INTO "CUSTOMERS" VALUES ('FISSA', 'FISSA Fabrica Inter. Salchichas S.A.', 'Diego Roel', 'Accounting Manager', 'C/ Moralzarzal, 86', 'Madrid', null, '28034', 'Spain', '(91) 555 94 44', '(91) 555 55 93');
INSERT INTO "CUSTOMERS" VALUES ('FOLIG', 'Folies gourmandes', 'Martine Ranc茅', 'Assistant Sales Agent', '184, chauss茅e de Tournai', 'Lille', null, '59000', 'France', '20.16.10.16', '20.16.10.17');
INSERT INTO "CUSTOMERS" VALUES ('FOLKO', 'Folk och f盲 HB', 'Maria Larsson', 'Owner', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden', '0695-34 67 21', null);
INSERT INTO "CUSTOMERS" VALUES ('FRANK', 'Frankenversand', 'Peter Franken', 'Marketing Manager', 'Berliner Platz 43', 'M眉nchen', null, '80805', 'Germany', '089-0877310', '089-0877451');
INSERT INTO "CUSTOMERS" VALUES ('FRANR', 'France restauration', 'Carine Schmitt', 'Marketing Manager', '54, rue Royale', 'Nantes', null, '44000', 'France', '40.32.21.21', '40.32.21.20');
INSERT INTO "CUSTOMERS" VALUES ('FRANS', 'Franchi S.p.A.', 'Paolo Accorti', 'Sales Representative', 'Via Monte Bianco 34', 'Torino', null, '10100', 'Italy', '011-4988260', '011-4988261');
INSERT INTO "CUSTOMERS" VALUES ('FURIB', 'Furia Bacalhau e Frutos do Mar', 'Lino Rodriguez', 'Sales Manager', 'Jardim das rosas n. 32', 'Lisboa', null, '1675', 'Portugal', '(1) 354-2534', '(1) 354-2535');
INSERT INTO "CUSTOMERS" VALUES ('GALED', 'Galer铆a del gastr贸nomo', 'Eduardo Saavedra', 'Marketing Manager', 'Rambla de Catalu帽a, 23', 'Barcelona', null, '08022', 'Spain', '(93) 203 4560', '(93) 203 4561');
INSERT INTO "CUSTOMERS" VALUES ('GODOS', 'Godos Cocina T铆pica', 'Jos茅 Pedro Freyre', 'Sales Manager', 'C/ Romero, 33', 'Sevilla', null, '41101', 'Spain', '(95) 555 82 82', null);
INSERT INTO "CUSTOMERS" VALUES ('GOURL', 'Gourmet Lanchonetes', 'Andr茅 Fonseca', 'Sales Associate', 'Av. Brasil, 442', 'Campinas', 'SP', '04876-786', 'Brazil', '(11) 555-9482', null);
INSERT INTO "CUSTOMERS" VALUES ('GREAL', 'Great Lakes Food Market', 'Howard Snyder', 'Marketing Manager', '2732 Baker Blvd.', 'Eugene', 'OR', '97403', 'USA', '(503) 555-7555', null);
INSERT INTO "CUSTOMERS" VALUES ('GROSR', 'GROSELLA-Restaurante', 'Manuel Pereira', 'Owner', '5陋 Ave. Los Palos Grandes', 'Caracas', 'DF', '1081', 'Venezuela', '(2) 283-2951', '(2) 283-3397');
INSERT INTO "CUSTOMERS" VALUES ('HANAR', 'Hanari Carnes', 'Mario Pontes', 'Accounting Manager', 'Rua do Pa莽o, 67', 'Rio de Janeiro', 'RJ', '05454-876', 'Brazil', '(21) 555-0091', '(21) 555-8765');
INSERT INTO "CUSTOMERS" VALUES ('HILAA', 'HILARION-Abastos', 'Carlos Hern谩ndez', 'Sales Representative', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela', '(5) 555-1340', '(5) 555-1948');
INSERT INTO "CUSTOMERS" VALUES ('HUNGC', 'Hungry Coyote Import Store', 'Yoshi Latimer', 'Sales Representative', 'City Center Plaza 516 Main St.', 'Elgin', 'OR', '97827', 'USA', '(503) 555-6874', '(503) 555-2376');
INSERT INTO "CUSTOMERS" VALUES ('HUNGO', 'Hungry Owl All-Night Grocers', 'Patricia McKenna', 'Sales Associate', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland', '2967 542', '2967 3333');
INSERT INTO "CUSTOMERS" VALUES ('ISLAT', 'Island Trading', 'Helen Bennett', 'Marketing Manager', 'Garden House Crowther Way', 'Cowes', 'Isle of Wight', 'PO31 7PJ', 'UK', '(198) 555-8888', null);
INSERT INTO "CUSTOMERS" VALUES ('KOENE', 'K枚niglich Essen', 'Philip Cramer', 'Sales Associate', 'Maubelstr. 90', 'Brandenburg', null, '14776', 'Germany', '0555-09876', null);
INSERT INTO "CUSTOMERS" VALUES ('LACOR', 'La corne dabondance', 'Daniel Tonini', 'Sales Representative', '67, avenue de lEurope', 'Versailles', null, '78000', 'France', '30.59.84.10', '30.59.85.11');
INSERT INTO "CUSTOMERS" VALUES ('LAMAI', 'La maison dAsie', 'Annette Roulet', 'Sales Manager', '1 rue Alsace-Lorraine', 'Toulouse', null, '31000', 'France', '61.77.61.10', '61.77.61.11');
INSERT INTO "CUSTOMERS" VALUES ('LAUGB', 'Laughing Bacchus Wine Cellars', 'Yoshi Tannamuri', 'Marketing Assistant', '1900 Oak St.', 'Vancouver', 'BC', 'V3F 2K1', 'Canada', '(604) 555-3392', '(604) 555-7293');
INSERT INTO "CUSTOMERS" VALUES ('LAZYK', 'Lazy K Kountry Store', 'John Steel', 'Marketing Manager', '12 Orchestra Terrace', 'Walla Walla', 'WA', '99362', 'USA', '(509) 555-7969', '(509) 555-6221');
INSERT INTO "CUSTOMERS" VALUES ('LEHMS', 'Lehmanns Marktstand', 'Renate Messner', 'Sales Representative', 'Magazinweg 7', 'Frankfurt a.M.', null, '60528', 'Germany', '069-0245984', '069-0245874');
INSERT INTO "CUSTOMERS" VALUES ('LETSS', 'Lets Stop N Shop', 'Jaime Yorres', 'Owner', '87 Polk St. Suite 5', 'San Francisco', 'CA', '94117', 'USA', '(415) 555-5938', null);
INSERT INTO "CUSTOMERS" VALUES ('LILAS', 'LILA-Supermercado', 'Carlos Gonz谩lez', 'Accounting Manager', 'Carrera 52 con Ave. Bol铆var #65-98 Llano Largo', 'Barquisimeto', 'Lara', '3508', 'Venezuela', '(9) 331-6954', '(9) 331-7256');
INSERT INTO "CUSTOMERS" VALUES ('LINOD', 'LINO-Delicateses', 'Felipe Izquierdo', 'Owner', 'Ave. 5 de Mayo Porlamar', 'I. de Margarita', 'Nueva Esparta', '4980', 'Venezuela', '(8) 34-56-12', '(8) 34-93-93');
INSERT INTO "CUSTOMERS" VALUES ('LONEP', 'Lonesome Pine Restaurant', 'Fran Wilson', 'Sales Manager', '89 Chiaroscuro Rd.', 'Portland', 'OR', '97219', 'USA', '(503) 555-9573', '(503) 555-9646');
INSERT INTO "CUSTOMERS" VALUES ('MAGAA', 'Magazzini Alimentari Riuniti', 'Giovanni Rovelli', 'Marketing Manager', 'Via Ludovico il Moro 22', 'Bergamo', null, '24100', 'Italy', '035-640230', '035-640231');
INSERT INTO "CUSTOMERS" VALUES ('MAISD', 'Maison Dewey', 'Catherine Dewey', 'Sales Agent', 'Rue Joseph-Bens 532', 'Bruxelles', null, 'B-1180', 'Belgium', '(02) 201 24 67', '(02) 201 24 68');
INSERT INTO "CUSTOMERS" VALUES ('MEREP', 'M猫re Paillarde', 'Jean Fresni猫re', 'Marketing Assistant', '43 rue St. Laurent', 'Montr茅al', 'Qu茅bec', 'H1J 1C3', 'Canada', '(514) 555-8054', '(514) 555-8055');
INSERT INTO "CUSTOMERS" VALUES ('MORGK', 'Morgenstern Gesundkost', 'Alexander Feuer', 'Marketing Assistant', 'Heerstr. 22', 'Leipzig', null, '04179', 'Germany', '0342-023176', null);
INSERT INTO "CUSTOMERS" VALUES ('NORTS', 'North/South', 'Simon Crowther', 'Sales Associate', 'South House 300 Queensbridge', 'London', null, 'SW7 1RZ', 'UK', '(171) 555-7733', '(171) 555-2530');
INSERT INTO "CUSTOMERS" VALUES ('OCEAN', 'Oc茅ano Atl谩ntico Ltda.', 'Yvonne Moncada', 'Sales Agent', 'Ing. Gustavo Moncada 8585 Piso 20-A', 'Buenos Aires', null, '1010', 'Argentina', '(1) 135-5333', '(1) 135-5535');
INSERT INTO "CUSTOMERS" VALUES ('OLDWO', 'Old World Delicatessen', 'Rene Phillips', 'Sales Representative', '2743 Bering St.', 'Anchorage', 'AK', '99508', 'USA', '(907) 555-7584', '(907) 555-2880');
INSERT INTO "CUSTOMERS" VALUES ('OTTIK', 'Ottilies K盲seladen', 'Henriette Pfalzheim', 'Owner', 'Mehrheimerstr. 369', 'K枚ln', null, '50739', 'Germany', '0221-0644327', '0221-0765721');
INSERT INTO "CUSTOMERS" VALUES ('PARIS', 'Paris sp茅cialit茅s', 'Marie Bertrand', 'Owner', '265, boulevard Charonne', 'Paris', null, '75012', 'France', '(1) 42.34.22.66', '(1) 42.34.22.77');
INSERT INTO "CUSTOMERS" VALUES ('PERIC', 'Pericles Comidas cl谩sicas', 'Guillermo Fern谩ndez', 'Sales Representative', 'Calle Dr. Jorge Cash 321', 'M茅xico D.F.', null, '05033', 'Mexico', '(5) 552-3745', '(5) 545-3745');
INSERT INTO "CUSTOMERS" VALUES ('PICCO', 'Piccolo und mehr', 'Georg Pipps', 'Sales Manager', 'Geislweg 14', 'Salzburg', null, '5020', 'Austria', '6562-9722', '6562-9723');
INSERT INTO "CUSTOMERS" VALUES ('PRINI', 'Princesa Isabel Vinhos', 'Isabel de Castro', 'Sales Representative', 'Estrada da sa煤de n. 58', 'Lisboa', null, '1756', 'Portugal', '(1) 356-5634', null);
INSERT INTO "CUSTOMERS" VALUES ('QUEDE', 'Que Del铆cia', 'Bernardo Batista', 'Accounting Manager', 'Rua da Panificadora, 12', 'Rio de Janeiro', 'RJ', '02389-673', 'Brazil', '(21) 555-4252', '(21) 555-4545');
INSERT INTO "CUSTOMERS" VALUES ('QUEEN', 'Queen Cozinha', 'L煤cia Carvalho', 'Marketing Assistant', 'Alameda dos Can脿rios, 891', 'Sao Paulo', 'SP', '05487-020', 'Brazil', '(11) 555-1189', null);
INSERT INTO "CUSTOMERS" VALUES ('QUICK', 'QUICK-Stop', 'Horst Kloss', 'Accounting Manager', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany', '0372-035188', null);
INSERT INTO "CUSTOMERS" VALUES ('RANCH', 'Rancho grande', 'Sergio Guti茅rrez', 'Sales Representative', 'Av. del Libertador 900', 'Buenos Aires', null, '1010', 'Argentina', '(1) 123-5555', '(1) 123-5556');
INSERT INTO "CUSTOMERS" VALUES ('RATTC', 'Rattlesnake Canyon Grocery', 'Paula Wilson', 'Assistant Sales Representative', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA', '(505) 555-5939', '(505) 555-3620');
INSERT INTO "CUSTOMERS" VALUES ('REGGC', 'Reggiani Caseifici', 'Maurizio Moroni', 'Sales Associate', 'Strada Provinciale 124', 'Reggio Emilia', null, '42100', 'Italy', '0522-556721', '0522-556722');
INSERT INTO "CUSTOMERS" VALUES ('RICAR', 'Ricardo Adocicados', 'Janete Limeira', 'Assistant Sales Agent', 'Av. Copacabana, 267', 'Rio de Janeiro', 'RJ', '02389-890', 'Brazil', '(21) 555-3412', null);
INSERT INTO "CUSTOMERS" VALUES ('RICSU', 'Richter Supermarkt', 'Michael Holz', 'Sales Manager', 'Grenzacherweg 237', 'Gen猫ve', null, '1203', 'Switzerland', '0897-034214', null);
INSERT INTO "CUSTOMERS" VALUES ('ROMEY', 'Romero y tomillo', 'Alejandra Camino', 'Accounting Manager', 'Gran V铆a, 1', 'Madrid', null, '28001', 'Spain', '(91) 745 6200', '(91) 745 6210');
INSERT INTO "CUSTOMERS" VALUES ('SANTG', 'Sant茅 Gourmet', 'Jonas Bergulfsen', 'Owner', 'Erling Skakkes gate 78', 'Stavern', null, '4110', 'Norway', '07-98 92 35', '07-98 92 47');
INSERT INTO "CUSTOMERS" VALUES ('SAVEA', 'Save-a-lot Markets', 'Jose Pavarotti', 'Sales Representative', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA', '(208) 555-8097', null);
INSERT INTO "CUSTOMERS" VALUES ('SEVES', 'Seven Seas Imports', 'Hari Kumar', 'Sales Manager', '90 Wadhurst Rd.', 'London', null, 'OX15 4NB', 'UK', '(171) 555-1717', '(171) 555-5646');
INSERT INTO "CUSTOMERS" VALUES ('SIMOB', 'Simons bistro', 'Jytte Petersen', 'Owner', 'Vinb忙ltet 34', 'Kobenhavn', null, '1734', 'Denmark', '31 12 34 56', '31 13 35 57');
INSERT INTO "CUSTOMERS" VALUES ('SPECD', 'Sp茅cialit茅s du monde', 'Dominique Perrier', 'Marketing Manager', '25, rue Lauriston', 'Paris', null, '75016', 'France', '(1) 47.55.60.10', '(1) 47.55.60.20');
INSERT INTO "CUSTOMERS" VALUES ('SPLIR', 'Split Rail Beer & Ale', 'Art Braunschweiger', 'Sales Manager', 'P.O. Box 555', 'Lander', 'WY', '82520', 'USA', '(307) 555-4680', '(307) 555-6525');
INSERT INTO "CUSTOMERS" VALUES ('SUPRD', 'Supr锚mes d茅lices', 'Pascale Cartrain', 'Accounting Manager', 'Boulevard Tirou, 255', 'Charleroi', null, 'B-6000', 'Belgium', '(071) 23 67 22 20', '(071) 23 67 22 21');
INSERT INTO "CUSTOMERS" VALUES ('THEBI', 'The Big Cheese', 'Liz Nixon', 'Marketing Manager', '89 Jefferson Way Suite 2', 'Portland', 'OR', '97201', 'USA', '(503) 555-3612', null);
INSERT INTO "CUSTOMERS" VALUES ('THECR', 'The Cracker Box', 'Liu Wong', 'Marketing Assistant', '55 Grizzly Peak Rd.', 'Butte', 'MT', '59801', 'USA', '(406) 555-5834', '(406) 555-8083');
INSERT INTO "CUSTOMERS" VALUES ('TOMSP', 'Toms Spezialit盲ten', 'Karin Josephs', 'Marketing Manager', 'Luisenstr. 48', 'M眉nster', null, '44087', 'Germany', '0251-031259', '0251-035695');
INSERT INTO "CUSTOMERS" VALUES ('TORTU', 'Tortuga Restaurante', 'Miguel Angel Paolino', 'Owner', 'Avda. Azteca 123', 'M茅xico D.F.', null, '05033', 'Mexico', '(5) 555-2933', null);
INSERT INTO "CUSTOMERS" VALUES ('TRADH', 'Tradi莽茫o Hipermercados', 'Anabela Domingues', 'Sales Representative', 'Av. In锚s de Castro, 414', 'Sao Paulo', 'SP', '05634-030', 'Brazil', '(11) 555-2167', '(11) 555-2168');
INSERT INTO "CUSTOMERS" VALUES ('TRAIH', 'Trails Head Gourmet Provisioners', 'Helvetius Nagy', 'Sales Associate', '722 DaVinci Blvd.', 'Kirkland', 'WA', '98034', 'USA', '(206) 555-8257', '(206) 555-2174');
INSERT INTO "CUSTOMERS" VALUES ('VAFFE', 'Vaffeljernet', 'Palle Ibsen', 'Sales Manager', 'Smagsloget 45', '脜rhus', null, '8200', 'Denmark', '86 21 32 43', '86 22 33 44');
INSERT INTO "CUSTOMERS" VALUES ('VICTE', 'Victuailles en stock', 'Mary Saveley', 'Sales Agent', '2, rue du Commerce', 'Lyon', null, '69004', 'France', '78.32.54.86', '78.32.54.87');
INSERT INTO "CUSTOMERS" VALUES ('VINET', 'Vins et alcools Chevalier', 'Paul Henriot', 'Accounting Manager', '59 rue de lAbbaye', 'Reims', null, '51100', 'France', '26.47.15.10', '26.47.15.11');
INSERT INTO "CUSTOMERS" VALUES ('WANDK', 'Die Wandernde Kuh', 'Rita M眉ller', 'Sales Representative', 'Adenauerallee 900', 'Stuttgart', null, '70563', 'Germany', '0711-020361', '0711-035428');
INSERT INTO "CUSTOMERS" VALUES ('WARTH', 'Wartian Herkku', 'Pirkko Koskitalo', 'Accounting Manager', 'Torikatu 38', 'Oulu', null, '90110', 'Finland', '981-443655', '981-443655');
INSERT INTO "CUSTOMERS" VALUES ('WELLI', 'Wellington Importadora', 'Paula Parente', 'Sales Manager', 'Rua do Mercado, 12', 'Resende', 'SP', '08737-363', 'Brazil', '(14) 555-8122', null);
INSERT INTO "CUSTOMERS" VALUES ('WHITC', 'White Clover Markets', 'Karl Jablonski', 'Owner', '305 - 14th Ave. S. Suite 3B', 'Seattle', 'WA', '98128', 'USA', '(206) 555-4112', '(206) 555-4115');
INSERT INTO "CUSTOMERS" VALUES ('WILMK', 'Wilman Kala', 'Matti Karttunen', 'Owner/Marketing Assistant', 'Keskuskatu 45', 'Helsinki', null, '21240', 'Finland', '90-224 8858', '90-224 8858');
INSERT INTO "CUSTOMERS" VALUES ('WOLZA', 'Wolski  Zajazd', 'Zbyszek Piestrzeniewicz', 'Owner', 'ul. Filtrowa 68', 'Warszawa', null, '01-012', 'Poland', '(26) 642-7012', '(26) 642-7012');

-- ----------------------------
-- Table structure for EMPLOYEES
-- ----------------------------
--DROP TABLE "EMPLOYEES";
CREATE TABLE "EMPLOYEES" (
"EMPLOYEEID" NUMBER(38) NOT NULL ,
"LASTNAME" VARCHAR2(20 BYTE) NOT NULL ,
"FIRSTNAME" VARCHAR2(10 BYTE) NOT NULL ,
"TITLE" VARCHAR2(30 BYTE) DEFAULT NULL  NULL ,
"TITLEOFCOURTESY" VARCHAR2(25 BYTE) DEFAULT NULL  NULL ,
"BIRTHDATE" DATE DEFAULT NULL  NULL ,
"HIREDATE" DATE DEFAULT NULL  NULL ,
"ADDRESS" VARCHAR2(60 BYTE) DEFAULT NULL  NULL ,
"CITY" VARCHAR2(15 BYTE) DEFAULT NULL  NULL ,
"REGION" VARCHAR2(15 BYTE) DEFAULT NULL  NULL ,
"POSTALCODE" VARCHAR2(10 BYTE) DEFAULT NULL  NULL ,
"COUNTRY" VARCHAR2(15 BYTE) DEFAULT NULL  NULL ,
"HOMEPHONE" VARCHAR2(24 BYTE) DEFAULT NULL  NULL ,
"EXTENSION" VARCHAR2(4 BYTE) DEFAULT NULL  NULL ,
"PHOTO" BLOB NULL ,
"NOTES" CLOB NULL ,
"REPORTSTO" NUMBER(38) DEFAULT NULL  NULL ,
"PHOTOPATH" VARCHAR2(255 BYTE) DEFAULT NULL  NULL 
)
LOGGING
NOCOMPRESS
NOCACHE

;

-- ----------------------------
-- Records of EMPLOYEES
-- ----------------------------
INSERT INTO "EMPLOYEES" VALUES ('1', 'Davolio', 'Nancy', 'Sales Representative', 'Ms.', TO_DATE('1948-12-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1992-05-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '507 - 20th Ave. E.\r\nApt. 2A', 'Seattle', 'WA', '98122', 'USA', '(206) 555-9857', '5467', null, 'Education includes a BA in psychology from Colorado State University in 1970.  She also completed \"The Art of the Cold Call.\"  Nancy is a member of Toastmasters International.', '2', 'http://accweb/emmployees/davolio.bmp');
INSERT INTO "EMPLOYEES" VALUES ('2', 'Fuller', 'Andrew', 'Vice President, Sales', 'Dr.', TO_DATE('1952-02-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1992-08-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '908 W. Capital Way', 'Tacoma', 'WA', '98401', 'USA', '(206) 555-9482', '3457', null, 'Andrew received his BTS commercial in 1974 and a Ph.D. in international marketing from the University of Dallas in 1981.  He is fluent in French and Italian and reads German.  He joined the company as a sales representative, was promoted to sales manager in January 1992 and to vice president of sales in March 1993.  Andrew is a member of the Sales Management Roundtable, the Seattle Chamber of Commerce, and the Pacific Rim Importers Association.', null, 'http://accweb/emmployees/fuller.bmp');
INSERT INTO "EMPLOYEES" VALUES ('3', 'Leverling', 'Janet', 'Sales Representative', 'Ms.', TO_DATE('1963-08-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1992-04-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '722 Moss Bay Blvd.', 'Kirkland', 'WA', '98033', 'USA', '(206) 555-3412', '3355', null, 'Janet has a BS degree in chemistry from Boston College (1984).  She has also completed a certificate program in food retailing management.  Janet was hired as a sales associate in 1991 and promoted to sales representative in February 1992.', '2', 'http://accweb/emmployees/leverling.bmp');
INSERT INTO "EMPLOYEES" VALUES ('4', 'Peacock', 'Margaret', 'Sales Representative', 'Mrs.', TO_DATE('1937-09-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1993-05-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '4110 Old Redmond Rd.', 'Redmond', 'WA', '98052', 'USA', '(206) 555-8122', '5176', null, 'Margaret holds a BA in English literature from Concordia College (1958) and an MA from the American Institute of Culinary Arts (1966).  She was assigned to the London office temporarily from July through November 1992.', '2', 'http://accweb/emmployees/peacock.bmp');
INSERT INTO "EMPLOYEES" VALUES ('5', 'Buchanan', 'Steven', 'Sales Manager', 'Mr.', TO_DATE('1955-03-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1993-10-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '14 Garrett Hill', 'London', null, 'SW1 8JR', 'UK', '(71) 555-4848', '3453', null, 'Steven Buchanan graduated from St. Andrews University, Scotland, with a BSC degree in 1976.  Upon joining the company as a sales representative in 1992, he spent 6 months in an orientation program at the Seattle office and then returned to his permanent post in London.  He was promoted to sales manager in March 1993.  Mr. Buchanan has completed the courses \"Successful Telemarketing\" and \"International Sales Management.\"  He is fluent in French.', '2', 'http://accweb/emmployees/buchanan.bmp');
INSERT INTO "EMPLOYEES" VALUES ('6', 'Suyama', 'Michael', 'Sales Representative', 'Mr.', TO_DATE('1963-07-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1993-10-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Coventry House\r\nMiner Rd.', 'London', null, 'EC2 7JR', 'UK', '(71) 555-7773', '428', null, 'Michael is a graduate of Sussex University (MA, economics, 1983) and the University of California at Los Angeles (MBA, marketing, 1986).  He has also taken the courses \"Multi-Cultural Selling\" and \"Time Management for the Sales Professional.\"  He is fluent in Japanese and can read and write French, Portuguese, and Spanish.', '5', 'http://accweb/emmployees/davolio.bmp');
INSERT INTO "EMPLOYEES" VALUES ('7', 'King', 'Robert', 'Sales Representative', 'Mr.', TO_DATE('1960-05-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1994-01-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Edgeham Hollow\r\nWinchester Way', 'London', null, 'RG1 9SP', 'UK', '(71) 555-5598', '465', null, 'Robert King served in the Peace Corps and traveled extensively before completing his degree in English at the University of Michigan in 1992, the year he joined the company.  After completing a course entitled \"Selling in Europe,\" he was transferred to the London office in March 1993.', '5', 'http://accweb/emmployees/davolio.bmp');
INSERT INTO "EMPLOYEES" VALUES ('8', 'Callahan', 'Laura', 'Inside Sales Coordinator', 'Ms.', TO_DATE('1958-01-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1994-03-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '4726 - 11th Ave. N.E.', 'Seattle', 'WA', '98105', 'USA', '(206) 555-1189', '2344', null, 'Laura received a BA in psychology from the University of Washington.  She has also completed a course in business French.  She reads and writes French.', '2', 'http://accweb/emmployees/davolio.bmp');
INSERT INTO "EMPLOYEES" VALUES ('9', 'Dodsworth', 'Anne', 'Sales Representative', 'Ms.', TO_DATE('1966-01-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1994-11-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '7 Houndstooth Rd.', 'London', null, 'WG2 7LT', 'UK', '(71) 555-4444', '452', null, 'Anne has a BA degree in English from St. Lawrence College.  She is fluent in French and German.', '5', 'http://accweb/emmployees/davolio.bmp');

-- ----------------------------
-- Table structure for EMPLOYEETERRITORIES
-- ----------------------------
--DROP TABLE "EMPLOYEETERRITORIES";
CREATE TABLE "EMPLOYEETERRITORIES" (
"EMPLOYEEID" NUMBER(38) NOT NULL ,
"TERRITORYID" VARCHAR2(20 BYTE) NOT NULL 
)
LOGGING
NOCOMPRESS
NOCACHE

;

-- ----------------------------
-- Records of EMPLOYEETERRITORIES
-- ----------------------------
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('1', '06897');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('1', '19713');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('2', '01581');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('2', '01730');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('2', '01833');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('2', '02116');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('2', '02139');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('2', '02184');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('2', '40222');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('3', '30346');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('3', '31406');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('3', '32859');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('3', '33607');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('4', '20852');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('4', '27403');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('4', '27511');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('5', '02903');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('5', '07960');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('5', '08837');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('5', '10019');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('5', '10038');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('5', '11747');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('5', '14450');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('6', '85014');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('6', '85251');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('6', '98004');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('6', '98052');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('6', '98104');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('7', '60179');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('7', '60601');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('7', '80202');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('7', '80909');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('7', '90405');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('7', '94025');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('7', '94105');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('7', '95008');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('7', '95054');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('7', '95060');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('8', '19428');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('8', '44122');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('8', '45839');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('8', '53404');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('9', '03049');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('9', '03801');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('9', '48075');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('9', '48084');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('9', '48304');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('9', '55113');
INSERT INTO "EMPLOYEETERRITORIES" VALUES ('9', '55439');

-- ----------------------------
-- Table structure for ORDER DETAILS
-- ----------------------------
--DROP TABLE "ORDER DETAILS";
CREATE TABLE "ORDER DETAILS" (
"ORDERID" NUMBER(38) NOT NULL ,
"PRODUCTID" NUMBER(38) NOT NULL ,
"UNITPRICE" NUMBER(19,4) NOT NULL ,
"QUANTITY" NUMBER(38) NOT NULL ,
"DISCOUNT" NUMBER(18) NOT NULL 
)
LOGGING
NOCOMPRESS
NOCACHE

;

-- ----------------------------
-- Records of ORDER DETAILS
-- ----------------------------
INSERT INTO "ORDER DETAILS" VALUES ('10372', '72', '27.80', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10373', '58', '10.60', '80', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10373', '71', '17.20', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10374', '31', '10', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10374', '58', '10.60', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10375', '14', '18.60', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10375', '54', '5.90', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10376', '31', '10', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10377', '28', '36.40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10377', '39', '14.40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10378', '71', '17.20', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10379', '41', '7.70', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10379', '63', '35.10', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10379', '65', '16.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10380', '30', '20.70', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10380', '53', '26.20', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10380', '60', '27.20', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10380', '70', '12', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10381', '74', '8', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10382', '5', '17', '32', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10382', '18', '50', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10382', '29', '99', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10382', '33', '2', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10382', '74', '8', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10383', '13', '4.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10383', '50', '13', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10383', '56', '30.40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10384', '20', '64.80', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10384', '60', '27.20', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10385', '7', '24', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10385', '60', '27.20', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10385', '68', '10', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10386', '24', '3.60', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10386', '34', '11.20', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10387', '24', '3.60', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10387', '28', '36.40', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10387', '59', '44', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10387', '71', '17.20', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10388', '45', '7.60', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10388', '52', '5.60', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10388', '53', '26.20', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10389', '10', '24.80', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10389', '55', '19.20', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10389', '62', '39.40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10389', '70', '12', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10390', '31', '10', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10390', '35', '14.40', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10390', '46', '9.60', '45', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10390', '72', '27.80', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10391', '13', '4.80', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10392', '69', '28.80', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10393', '2', '15.20', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10393', '14', '18.60', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10393', '25', '11.20', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10393', '26', '24.90', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10393', '31', '10', '32', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10394', '13', '4.80', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10394', '62', '39.40', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10395', '46', '9.60', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10395', '53', '26.20', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10395', '69', '28.80', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10396', '23', '7.20', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10396', '71', '17.20', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10396', '72', '27.80', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10397', '21', '8', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10397', '51', '42.40', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10398', '35', '14.40', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10398', '55', '19.20', '120', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10399', '68', '10', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10399', '71', '17.20', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10399', '76', '14.40', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10399', '77', '10.40', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10400', '29', '99', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10400', '35', '14.40', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10400', '49', '16', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10401', '30', '20.70', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10401', '56', '30.40', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10401', '65', '16.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10401', '71', '17.20', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10402', '23', '7.20', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10402', '63', '35.10', '65', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10403', '16', '13.90', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10403', '48', '10.20', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10404', '26', '24.90', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10404', '42', '11.20', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10404', '49', '16', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10405', '3', '8', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10406', '1', '14.40', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10406', '21', '8', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10406', '28', '36.40', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10406', '36', '15.20', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10406', '40', '14.70', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10407', '11', '16.80', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10407', '69', '28.80', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10407', '71', '17.20', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10408', '37', '20.80', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10408', '54', '5.90', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10408', '62', '39.40', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10409', '14', '18.60', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10409', '21', '8', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10410', '33', '2', '49', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10410', '59', '44', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10411', '41', '7.70', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10411', '44', '15.50', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10411', '59', '44', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10412', '14', '18.60', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10413', '1', '14.40', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10413', '62', '39.40', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10413', '76', '14.40', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10414', '19', '7.30', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10414', '33', '2', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10415', '17', '31.20', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10415', '33', '2', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10416', '19', '7.30', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10416', '53', '26.20', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10416', '57', '15.60', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10417', '38', '210.80', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10417', '46', '9.60', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10417', '68', '10', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10417', '77', '10.40', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10418', '2', '15.20', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10418', '47', '7.60', '55', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10418', '61', '22.80', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10418', '74', '8', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10419', '60', '27.20', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10419', '69', '28.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10420', '9', '77.60', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10420', '13', '4.80', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10420', '70', '12', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10420', '73', '12', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10421', '19', '7.30', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10421', '26', '24.90', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10421', '53', '26.20', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10421', '77', '10.40', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10422', '26', '24.90', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10423', '31', '10', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10423', '59', '44', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10424', '35', '14.40', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10424', '38', '210.80', '49', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10424', '68', '10', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10425', '55', '19.20', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10425', '76', '14.40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10426', '56', '30.40', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10426', '64', '26.60', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10427', '14', '18.60', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10428', '46', '9.60', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10429', '50', '13', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10429', '63', '35.10', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10430', '17', '31.20', '45', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10430', '21', '8', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10430', '56', '30.40', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10430', '59', '44', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10431', '17', '31.20', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10431', '40', '14.70', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10431', '47', '7.60', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10432', '26', '24.90', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10432', '54', '5.90', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10433', '56', '30.40', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10434', '11', '16.80', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10434', '76', '14.40', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10435', '2', '15.20', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10435', '22', '16.80', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10435', '72', '27.80', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10436', '46', '9.60', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10436', '56', '30.40', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10436', '64', '26.60', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10436', '75', '6.20', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10437', '53', '26.20', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10438', '19', '7.30', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10438', '34', '11.20', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10438', '57', '15.60', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10439', '12', '30.40', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10439', '16', '13.90', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10439', '64', '26.60', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10439', '74', '8', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10440', '2', '15.20', '45', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10440', '16', '13.90', '49', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10440', '29', '99', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10440', '61', '22.80', '90', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10441', '27', '35.10', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10442', '11', '16.80', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10442', '54', '5.90', '80', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10442', '66', '13.60', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10443', '11', '16.80', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10443', '28', '36.40', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10444', '17', '31.20', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10444', '26', '24.90', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10444', '35', '14.40', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10444', '41', '7.70', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10445', '39', '14.40', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10445', '54', '5.90', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10446', '19', '7.30', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10446', '24', '3.60', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10446', '31', '10', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10446', '52', '5.60', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10447', '19', '7.30', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10447', '65', '16.80', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10447', '71', '17.20', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10448', '26', '24.90', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10448', '40', '14.70', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10449', '10', '24.80', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10449', '52', '5.60', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10449', '62', '39.40', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10450', '10', '24.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10450', '54', '5.90', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10451', '55', '19.20', '120', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10451', '64', '26.60', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10451', '65', '16.80', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10451', '77', '10.40', '55', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10452', '28', '36.40', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10452', '44', '15.50', '100', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10453', '48', '10.20', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10453', '70', '12', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10454', '16', '13.90', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10454', '33', '2', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10454', '46', '9.60', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10455', '39', '14.40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10455', '53', '26.20', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10455', '61', '22.80', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10455', '71', '17.20', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10456', '21', '8', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10456', '49', '16', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10457', '59', '44', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10458', '26', '24.90', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10458', '28', '36.40', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10458', '43', '36.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10458', '56', '30.40', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10458', '71', '17.20', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10459', '7', '24', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10459', '46', '9.60', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10459', '72', '27.80', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10460', '68', '10', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10460', '75', '6.20', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10461', '21', '8', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10461', '30', '20.70', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10461', '55', '19.20', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10462', '13', '4.80', '1', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10462', '23', '7.20', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10463', '19', '7.30', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10463', '42', '11.20', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10464', '4', '17.60', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10464', '43', '36.80', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10464', '56', '30.40', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10464', '60', '27.20', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10465', '24', '3.60', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10465', '29', '99', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10465', '40', '14.70', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10465', '45', '7.60', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10465', '50', '13', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10466', '11', '16.80', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10466', '46', '9.60', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10467', '24', '3.60', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10467', '25', '11.20', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10468', '30', '20.70', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10468', '43', '36.80', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10469', '2', '15.20', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10469', '16', '13.90', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10469', '44', '15.50', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10470', '18', '50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10470', '23', '7.20', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10470', '64', '26.60', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10471', '7', '24', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10471', '56', '30.40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10472', '24', '3.60', '80', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10472', '51', '42.40', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10473', '33', '2', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10473', '71', '17.20', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10474', '14', '18.60', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10474', '28', '36.40', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10474', '40', '14.70', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10474', '75', '6.20', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10475', '31', '10', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10475', '66', '13.60', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10475', '76', '14.40', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10476', '55', '19.20', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10476', '70', '12', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10477', '1', '14.40', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10477', '21', '8', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10477', '39', '14.40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10478', '10', '24.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10479', '38', '210.80', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10479', '53', '26.20', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10479', '59', '44', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10479', '64', '26.60', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10480', '47', '7.60', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10480', '59', '44', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10481', '49', '16', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10481', '60', '27.20', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10482', '40', '14.70', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10483', '34', '11.20', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10483', '77', '10.40', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10484', '21', '8', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10484', '40', '14.70', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10484', '51', '42.40', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10485', '2', '15.20', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10485', '3', '8', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10485', '55', '19.20', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10485', '70', '12', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10486', '11', '16.80', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10486', '51', '42.40', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10486', '74', '8', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10487', '19', '7.30', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10487', '26', '24.90', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10487', '54', '5.90', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10488', '59', '44', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10488', '73', '12', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10489', '11', '16.80', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10489', '16', '13.90', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10490', '59', '44', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10490', '68', '10', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10490', '75', '6.20', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10491', '44', '15.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10491', '77', '10.40', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10492', '25', '11.20', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10492', '42', '11.20', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10493', '65', '16.80', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10493', '66', '13.60', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10493', '69', '28.80', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10494', '56', '30.40', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10495', '23', '7.20', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10495', '41', '7.70', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10495', '77', '10.40', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10496', '31', '10', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10497', '56', '30.40', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10497', '72', '27.80', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10497', '77', '10.40', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10498', '24', '4.50', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10498', '40', '18.40', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10498', '42', '14', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10499', '28', '45.60', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10499', '49', '20', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10500', '15', '15.50', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10500', '28', '45.60', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10501', '54', '7.45', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10756', '69', '36', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10757', '34', '14', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10757', '59', '55', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10757', '62', '49.30', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10757', '64', '33.25', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10758', '26', '31.23', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10758', '52', '7', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10758', '70', '15', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10759', '32', '32', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10760', '25', '14', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10760', '27', '43.90', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10760', '43', '46', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10761', '25', '14', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10761', '75', '7.75', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10762', '39', '18', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10762', '47', '9.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10762', '51', '53', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10762', '56', '38', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10763', '21', '10', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10763', '22', '21', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10763', '24', '4.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10764', '3', '10', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10764', '39', '18', '130', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10765', '65', '21.05', '80', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10766', '2', '19', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10766', '7', '30', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10766', '68', '12.50', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10767', '42', '14', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10768', '22', '21', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10768', '31', '12.50', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10768', '60', '34', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10768', '71', '21.50', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10769', '41', '9.65', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10769', '52', '7', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10769', '61', '28.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10769', '62', '49.30', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10770', '11', '21', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10771', '71', '21.50', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10772', '29', '123.79', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10772', '59', '55', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10773', '17', '39', '33', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10773', '31', '12.50', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10773', '75', '7.75', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10774', '31', '12.50', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10774', '66', '17', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10775', '10', '31', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10775', '67', '14', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10776', '31', '12.50', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10776', '42', '14', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10776', '45', '9.50', '27', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10776', '51', '53', '120', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10777', '42', '14', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10778', '41', '9.65', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10779', '16', '17.45', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10779', '62', '49.30', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10780', '70', '15', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10780', '77', '13', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10781', '54', '7.45', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10781', '56', '38', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10781', '74', '10', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10782', '31', '12.50', '1', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10783', '31', '12.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10783', '38', '263.50', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10784', '36', '19', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10784', '39', '18', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10784', '72', '34.80', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10785', '10', '31', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10785', '75', '7.75', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10786', '8', '40', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10786', '30', '25.89', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10786', '75', '7.75', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10787', '2', '19', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10787', '29', '123.79', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10788', '19', '9.20', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10788', '75', '7.75', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10789', '18', '62.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10789', '35', '18', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10789', '63', '43.90', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10789', '68', '12.50', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10790', '7', '30', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10790', '56', '38', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10791', '29', '123.79', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10791', '41', '9.65', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10792', '2', '19', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10792', '54', '7.45', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10792', '68', '12.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10793', '41', '9.65', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10793', '52', '7', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10794', '14', '23.25', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10794', '54', '7.45', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10795', '16', '17.45', '65', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10795', '17', '39', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10796', '26', '31.23', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10796', '44', '19.45', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10796', '64', '33.25', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10796', '69', '36', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10797', '11', '21', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10798', '62', '49.30', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10798', '72', '34.80', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10799', '13', '6', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10799', '24', '4.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10799', '59', '55', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10800', '11', '21', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10800', '51', '53', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10800', '54', '7.45', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10801', '17', '39', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10801', '29', '123.79', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10802', '30', '25.89', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10802', '51', '53', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10802', '55', '24', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10802', '62', '49.30', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10803', '19', '9.20', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10803', '25', '14', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10803', '59', '55', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10804', '10', '31', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10804', '28', '45.60', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10804', '49', '20', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10805', '34', '14', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10805', '38', '263.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10806', '2', '19', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10806', '65', '21.05', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10806', '74', '10', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10807', '40', '18.40', '1', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10808', '56', '38', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10808', '76', '18', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10809', '52', '7', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10810', '13', '6', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10810', '25', '14', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10810', '70', '15', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10811', '19', '9.20', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10811', '23', '9', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10811', '40', '18.40', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10812', '31', '12.50', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10812', '72', '34.80', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10812', '77', '13', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10813', '2', '19', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10813', '46', '12', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10814', '41', '9.65', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10814', '43', '46', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10814', '48', '12.75', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10814', '61', '28.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10815', '33', '2.50', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10816', '38', '263.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10816', '62', '49.30', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10817', '26', '31.23', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10817', '38', '263.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10817', '40', '18.40', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10817', '62', '49.30', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10818', '32', '32', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10818', '41', '9.65', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10819', '43', '46', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10819', '75', '7.75', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10820', '56', '38', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10821', '35', '18', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10821', '51', '53', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10822', '62', '49.30', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10822', '70', '15', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10823', '11', '21', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10823', '57', '19.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10823', '59', '55', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10823', '77', '13', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10824', '41', '9.65', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10824', '70', '15', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10825', '26', '31.23', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10825', '53', '32.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10826', '31', '12.50', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10826', '57', '19.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10827', '10', '31', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10827', '39', '18', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10828', '20', '81', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10828', '38', '263.50', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10829', '2', '19', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10829', '8', '40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10829', '13', '6', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10829', '60', '34', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10830', '6', '25', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10830', '39', '18', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10830', '60', '34', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10830', '68', '12.50', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10831', '19', '9.20', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10831', '35', '18', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10831', '38', '263.50', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10831', '43', '46', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10832', '13', '6', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10832', '25', '14', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10832', '44', '19.45', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10832', '64', '33.25', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10833', '7', '30', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10833', '31', '12.50', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10833', '53', '32.80', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10834', '29', '123.79', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10834', '30', '25.89', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10835', '59', '55', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10835', '77', '13', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10836', '22', '21', '52', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10836', '35', '18', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10836', '57', '19.50', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10836', '60', '34', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10836', '64', '33.25', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10837', '13', '6', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10837', '40', '18.40', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10837', '47', '9.50', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10837', '76', '18', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10838', '1', '18', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10838', '18', '62.50', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10838', '36', '19', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10839', '58', '13.25', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10839', '72', '34.80', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10840', '25', '14', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10840', '39', '18', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10841', '10', '31', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10841', '56', '38', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10841', '59', '55', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10841', '77', '13', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10842', '11', '21', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10842', '43', '46', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10842', '68', '12.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10842', '70', '15', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10843', '51', '53', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10844', '22', '21', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10845', '23', '9', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10845', '35', '18', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10845', '42', '14', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10845', '58', '13.25', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10845', '64', '33.25', '48', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10846', '4', '22', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10846', '70', '15', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10846', '74', '10', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10847', '1', '18', '80', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10847', '19', '9.20', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10847', '37', '26', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10847', '45', '9.50', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10847', '60', '34', '45', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10847', '71', '21.50', '55', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10848', '5', '21.35', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10848', '9', '97', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10849', '3', '10', '49', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10849', '26', '31.23', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10850', '25', '14', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10850', '33', '2.50', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10850', '70', '15', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10851', '2', '19', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10851', '25', '14', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10851', '57', '19.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10851', '59', '55', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10852', '2', '19', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10852', '17', '39', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10852', '62', '49.30', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10853', '18', '62.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10854', '10', '31', '100', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10854', '13', '6', '65', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10855', '16', '17.45', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10855', '31', '12.50', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10855', '56', '38', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10855', '65', '21.05', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10856', '2', '19', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10856', '42', '14', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10857', '3', '10', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10857', '26', '31.23', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10857', '29', '123.79', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10858', '7', '30', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10858', '27', '43.90', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10858', '70', '15', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10859', '24', '4.50', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10859', '54', '7.45', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10859', '64', '33.25', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10860', '51', '53', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10860', '76', '18', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10861', '17', '39', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10861', '18', '62.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10861', '21', '10', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10861', '33', '2.50', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10861', '62', '49.30', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10862', '11', '21', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10862', '52', '7', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10863', '1', '18', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10863', '58', '13.25', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10864', '35', '18', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10864', '67', '14', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10865', '38', '263.50', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10865', '39', '18', '80', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10866', '2', '19', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10866', '24', '4.50', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10866', '30', '25.89', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10867', '53', '32.80', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10868', '26', '31.23', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10868', '35', '18', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10868', '49', '20', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10869', '1', '18', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10869', '11', '21', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10869', '23', '9', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10869', '68', '12.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10870', '35', '18', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10870', '51', '53', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10871', '6', '25', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10871', '16', '17.45', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10871', '17', '39', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10872', '55', '24', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10872', '62', '49.30', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10872', '64', '33.25', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10872', '65', '21.05', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10873', '21', '10', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10873', '28', '45.60', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10874', '10', '31', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10875', '19', '9.20', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10875', '47', '9.50', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10875', '49', '20', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10876', '46', '12', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10876', '64', '33.25', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10877', '16', '17.45', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10877', '18', '62.50', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10878', '20', '81', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10879', '40', '18.40', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10879', '65', '21.05', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10879', '76', '18', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10880', '23', '9', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10880', '61', '28.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10880', '70', '15', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10881', '73', '15', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10882', '42', '14', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10882', '49', '20', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10882', '54', '7.45', '32', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10883', '24', '4.50', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10884', '21', '10', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10884', '56', '38', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10884', '65', '21.05', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10885', '2', '19', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10885', '24', '4.50', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10885', '70', '15', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10885', '77', '13', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10886', '10', '31', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10886', '31', '12.50', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10886', '77', '13', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10887', '25', '14', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10888', '2', '19', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10888', '68', '12.50', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10889', '11', '21', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10502', '45', '9.50', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10502', '53', '32.80', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10502', '67', '14', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10503', '14', '23.25', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10503', '65', '21.05', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10504', '2', '19', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10504', '21', '10', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10504', '53', '32.80', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10504', '61', '28.50', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10505', '62', '49.30', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10506', '25', '14', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10506', '70', '15', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10507', '43', '46', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10507', '48', '12.75', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10508', '13', '6', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10508', '39', '18', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10509', '28', '45.60', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10510', '29', '123.79', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10510', '75', '7.75', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10511', '4', '22', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10511', '7', '30', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10511', '8', '40', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10512', '24', '4.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10512', '46', '12', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10512', '47', '9.50', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10512', '60', '34', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10513', '21', '10', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10513', '32', '32', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10513', '61', '28.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10514', '20', '81', '39', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10514', '28', '45.60', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10514', '56', '38', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10514', '65', '21.05', '39', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10514', '75', '7.75', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10515', '9', '97', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10515', '16', '17.45', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10515', '27', '43.90', '120', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10515', '33', '2.50', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10515', '60', '34', '84', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10516', '18', '62.50', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10516', '41', '9.65', '80', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10516', '42', '14', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10517', '52', '7', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10517', '59', '55', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10517', '70', '15', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10518', '24', '4.50', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10518', '38', '263.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10518', '44', '19.45', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10519', '10', '31', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10519', '56', '38', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10519', '60', '34', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10520', '24', '4.50', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10520', '53', '32.80', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10521', '35', '18', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10521', '41', '9.65', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10521', '68', '12.50', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10522', '1', '18', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10522', '8', '40', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10522', '30', '25.89', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10522', '40', '18.40', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10523', '17', '39', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10523', '20', '81', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10523', '37', '26', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10523', '41', '9.65', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10524', '10', '31', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10524', '30', '25.89', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10524', '43', '46', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10524', '54', '7.45', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10525', '36', '19', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10525', '40', '18.40', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10526', '1', '18', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10526', '13', '6', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10526', '56', '38', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10527', '4', '22', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10527', '36', '19', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10528', '11', '21', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10528', '33', '2.50', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10528', '72', '34.80', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10529', '55', '24', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10529', '68', '12.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10529', '69', '36', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10530', '17', '39', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10530', '43', '46', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10530', '61', '28.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10530', '76', '18', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10531', '59', '55', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10532', '30', '25.89', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10532', '66', '17', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10533', '4', '22', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10533', '72', '34.80', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10533', '73', '15', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10534', '30', '25.89', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10534', '40', '18.40', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10534', '54', '7.45', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10535', '11', '21', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10535', '40', '18.40', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10535', '57', '19.50', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10535', '59', '55', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10536', '12', '38', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10536', '31', '12.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10536', '33', '2.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10536', '60', '34', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10537', '31', '12.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10537', '51', '53', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10537', '58', '13.25', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10537', '72', '34.80', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10537', '73', '15', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10538', '70', '15', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10538', '72', '34.80', '1', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10539', '13', '6', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10539', '21', '10', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10539', '33', '2.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10539', '49', '20', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10540', '3', '10', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10540', '26', '31.23', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10540', '38', '263.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10540', '68', '12.50', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10541', '24', '4.50', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10541', '38', '263.50', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10541', '65', '21.05', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10541', '71', '21.50', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10542', '11', '21', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10542', '54', '7.45', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10543', '12', '38', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10543', '23', '9', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10544', '28', '45.60', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10544', '67', '14', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10545', '11', '21', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10546', '7', '30', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10546', '35', '18', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10546', '62', '49.30', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10547', '32', '32', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10547', '36', '19', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10548', '34', '14', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10548', '41', '9.65', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10549', '31', '12.50', '55', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10549', '45', '9.50', '100', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10549', '51', '53', '48', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10550', '17', '39', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10550', '19', '9.20', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10550', '21', '10', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10550', '61', '28.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10551', '16', '17.45', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10551', '35', '18', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10551', '44', '19.45', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10552', '69', '36', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10552', '75', '7.75', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10553', '11', '21', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10553', '16', '17.45', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10553', '22', '21', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10553', '31', '12.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10553', '35', '18', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10554', '16', '17.45', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10554', '23', '9', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10554', '62', '49.30', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10554', '77', '13', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10555', '14', '23.25', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10555', '19', '9.20', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10555', '24', '4.50', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10555', '51', '53', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10555', '56', '38', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10556', '72', '34.80', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10557', '64', '33.25', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10557', '75', '7.75', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10558', '47', '9.50', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10558', '51', '53', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10558', '52', '7', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10558', '53', '32.80', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10558', '73', '15', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10559', '41', '9.65', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10559', '55', '24', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10560', '30', '25.89', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10560', '62', '49.30', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10561', '44', '19.45', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10561', '51', '53', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10562', '33', '2.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10562', '62', '49.30', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10563', '36', '19', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10563', '52', '7', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10564', '17', '39', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10564', '31', '12.50', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10564', '55', '24', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10565', '24', '4.50', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10565', '64', '33.25', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10566', '11', '21', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10566', '18', '62.50', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10566', '76', '18', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10567', '31', '12.50', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10567', '51', '53', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10567', '59', '55', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10568', '10', '31', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10569', '31', '12.50', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10569', '76', '18', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10570', '11', '21', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10570', '56', '38', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10571', '14', '23.25', '11', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10571', '42', '14', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10572', '16', '17.45', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10572', '32', '32', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10572', '40', '18.40', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10572', '75', '7.75', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10573', '17', '39', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10573', '34', '14', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10573', '53', '32.80', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10574', '33', '2.50', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10574', '40', '18.40', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10574', '62', '49.30', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10574', '64', '33.25', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10575', '59', '55', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10575', '63', '43.90', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10575', '72', '34.80', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10575', '76', '18', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10576', '1', '18', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10576', '31', '12.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10576', '44', '19.45', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10577', '39', '18', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10577', '75', '7.75', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10577', '77', '13', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10578', '35', '18', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10578', '57', '19.50', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10579', '15', '15.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10579', '75', '7.75', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10580', '14', '23.25', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10580', '41', '9.65', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10580', '65', '21.05', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10581', '75', '7.75', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10582', '57', '19.50', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10582', '76', '18', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10583', '29', '123.79', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10583', '60', '34', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10583', '69', '36', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10584', '31', '12.50', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10585', '47', '9.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10586', '52', '7', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10587', '26', '31.23', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10587', '35', '18', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10587', '77', '13', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10588', '18', '62.50', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10588', '42', '14', '100', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10589', '35', '18', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10590', '1', '18', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10590', '77', '13', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10591', '3', '10', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10591', '7', '30', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10591', '54', '7.45', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10592', '15', '15.50', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10592', '26', '31.23', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10593', '20', '81', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10593', '69', '36', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10593', '76', '18', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10594', '52', '7', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10594', '58', '13.25', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10595', '35', '18', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10595', '61', '28.50', '120', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10595', '69', '36', '65', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10596', '56', '38', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10596', '63', '43.90', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10596', '75', '7.75', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10597', '24', '4.50', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10597', '57', '19.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10597', '65', '21.05', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10598', '27', '43.90', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10598', '71', '21.50', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10599', '62', '49.30', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10600', '54', '7.45', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10600', '73', '15', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10601', '13', '6', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10601', '59', '55', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10602', '77', '13', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10603', '22', '21', '48', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10603', '49', '20', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10604', '48', '12.75', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10604', '76', '18', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10605', '16', '17.45', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10605', '59', '55', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10605', '60', '34', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10605', '71', '21.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10606', '4', '22', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10606', '55', '24', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10606', '62', '49.30', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10607', '7', '30', '45', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10607', '17', '39', '100', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10607', '33', '2.50', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10607', '40', '18.40', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10607', '72', '34.80', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10608', '56', '38', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10609', '1', '18', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10609', '10', '31', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10609', '21', '10', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10610', '36', '19', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10611', '1', '18', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10611', '2', '19', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10611', '60', '34', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10612', '10', '31', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10612', '36', '19', '55', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10612', '49', '20', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10612', '60', '34', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10612', '76', '18', '80', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10613', '13', '6', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10613', '75', '7.75', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10614', '11', '21', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10614', '21', '10', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10614', '39', '18', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10615', '55', '24', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10616', '38', '263.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10616', '56', '38', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10616', '70', '15', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10616', '71', '21.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10617', '59', '55', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10618', '6', '25', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10618', '56', '38', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10618', '68', '12.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10619', '21', '10', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10619', '22', '21', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10620', '24', '4.50', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10620', '52', '7', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10621', '19', '9.20', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10621', '23', '9', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10621', '70', '15', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10621', '71', '21.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10622', '2', '19', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10622', '68', '12.50', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10623', '14', '23.25', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10623', '19', '9.20', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10623', '21', '10', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10623', '24', '4.50', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10623', '35', '18', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10624', '28', '45.60', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10624', '29', '123.79', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10624', '44', '19.45', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10625', '14', '23.25', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10625', '42', '14', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10625', '60', '34', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10626', '53', '32.80', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10626', '60', '34', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10626', '71', '21.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10627', '62', '49.30', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10627', '73', '15', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10628', '1', '18', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10629', '29', '123.79', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10629', '64', '33.25', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10630', '55', '24', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10630', '76', '18', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10631', '75', '7.75', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10632', '2', '19', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10632', '33', '2.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10633', '12', '38', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10633', '13', '6', '13', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10633', '26', '31.23', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10633', '62', '49.30', '80', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10634', '7', '30', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10634', '18', '62.50', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10634', '51', '53', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10634', '75', '7.75', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10635', '4', '22', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10635', '5', '21.35', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10635', '22', '21', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10636', '4', '22', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10636', '58', '13.25', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10637', '11', '21', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10637', '50', '16.25', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10637', '56', '38', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10638', '45', '9.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10638', '65', '21.05', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10638', '72', '34.80', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10639', '18', '62.50', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10640', '69', '36', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10640', '70', '15', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10641', '2', '19', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10641', '40', '18.40', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10642', '21', '10', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10642', '61', '28.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10643', '28', '45.60', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10643', '39', '18', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10643', '46', '12', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10644', '18', '62.50', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10644', '43', '46', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10644', '46', '12', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10645', '18', '62.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10645', '36', '19', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10646', '1', '18', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10646', '10', '31', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10646', '71', '21.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10646', '77', '13', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10647', '19', '9.20', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10647', '39', '18', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10648', '22', '21', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10648', '24', '4.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10649', '28', '45.60', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10649', '72', '34.80', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10650', '30', '25.89', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10650', '53', '32.80', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10650', '54', '7.45', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10651', '19', '9.20', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10651', '22', '21', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10652', '30', '25.89', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10652', '42', '14', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10653', '16', '17.45', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10653', '60', '34', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10654', '4', '22', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10654', '39', '18', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10654', '54', '7.45', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10655', '41', '9.65', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10656', '14', '23.25', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10656', '44', '19.45', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10656', '47', '9.50', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10657', '15', '15.50', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10657', '41', '9.65', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10657', '46', '12', '45', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10657', '47', '9.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10657', '56', '38', '45', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10657', '60', '34', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10658', '21', '10', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10658', '40', '18.40', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10658', '60', '34', '55', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10658', '77', '13', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10659', '31', '12.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10659', '40', '18.40', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10659', '70', '15', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10660', '20', '81', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10661', '39', '18', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10661', '58', '13.25', '49', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10662', '68', '12.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10663', '40', '18.40', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10663', '42', '14', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10663', '51', '53', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10664', '10', '31', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10664', '56', '38', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10664', '65', '21.05', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10665', '51', '53', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10665', '59', '55', '1', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10665', '76', '18', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10666', '29', '123.79', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10666', '65', '21.05', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10667', '69', '36', '45', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10667', '71', '21.50', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10668', '31', '12.50', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10668', '55', '24', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10668', '64', '33.25', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10669', '36', '19', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10670', '23', '9', '32', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10670', '46', '12', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10670', '67', '14', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10670', '73', '15', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10670', '75', '7.75', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10671', '16', '17.45', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10671', '62', '49.30', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10671', '65', '21.05', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10672', '38', '263.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10672', '71', '21.50', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10673', '16', '17.45', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10673', '42', '14', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10673', '43', '46', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10674', '23', '9', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10675', '14', '23.25', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10675', '53', '32.80', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10675', '58', '13.25', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10676', '10', '31', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10676', '19', '9.20', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10676', '44', '19.45', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10677', '26', '31.23', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10677', '33', '2.50', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10678', '12', '38', '100', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10678', '33', '2.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10678', '41', '9.65', '120', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10678', '54', '7.45', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10679', '59', '55', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10680', '16', '17.45', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10680', '31', '12.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10680', '42', '14', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10681', '19', '9.20', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10681', '21', '10', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10681', '64', '33.25', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10682', '33', '2.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10682', '66', '17', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10682', '75', '7.75', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10683', '52', '7', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10684', '40', '18.40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10684', '47', '9.50', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10684', '60', '34', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10685', '10', '31', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10685', '41', '9.65', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10685', '47', '9.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10686', '17', '39', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10686', '26', '31.23', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10687', '9', '97', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10687', '29', '123.79', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10687', '36', '19', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10688', '10', '31', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10688', '28', '45.60', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10688', '34', '14', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10689', '1', '18', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10690', '56', '38', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10690', '77', '13', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10691', '1', '18', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10691', '29', '123.79', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10691', '43', '46', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10691', '44', '19.45', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10691', '62', '49.30', '48', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10692', '63', '43.90', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10693', '9', '97', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10693', '54', '7.45', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10693', '69', '36', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10693', '73', '15', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10694', '7', '30', '90', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10694', '59', '55', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10694', '70', '15', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10695', '8', '40', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10695', '12', '38', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10695', '24', '4.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10696', '17', '39', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10696', '46', '12', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10697', '19', '9.20', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10697', '35', '18', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10697', '58', '13.25', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10697', '70', '15', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10698', '11', '21', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10698', '17', '39', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10698', '29', '123.79', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10698', '65', '21.05', '65', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10698', '70', '15', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10699', '47', '9.50', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10700', '1', '18', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10700', '34', '14', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10700', '68', '12.50', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10700', '71', '21.50', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10701', '59', '55', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10701', '71', '21.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10701', '76', '18', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10702', '3', '10', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10702', '76', '18', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10703', '2', '19', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10703', '59', '55', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10703', '73', '15', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10704', '4', '22', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10704', '24', '4.50', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10704', '48', '12.75', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10705', '31', '12.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10705', '32', '32', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10706', '16', '17.45', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10706', '43', '46', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10706', '59', '55', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10707', '55', '24', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10707', '57', '19.50', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10707', '70', '15', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10708', '5', '21.35', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10708', '36', '19', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10709', '8', '40', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10709', '51', '53', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10709', '60', '34', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10710', '19', '9.20', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10710', '47', '9.50', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10711', '19', '9.20', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10711', '41', '9.65', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10711', '53', '32.80', '120', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10712', '53', '32.80', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10712', '56', '38', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10713', '10', '31', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10713', '26', '31.23', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10713', '45', '9.50', '110', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10713', '46', '12', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10714', '2', '19', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10714', '17', '39', '27', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10714', '47', '9.50', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10714', '56', '38', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10714', '58', '13.25', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10715', '10', '31', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10715', '71', '21.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10716', '21', '10', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10716', '51', '53', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10716', '61', '28.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10717', '21', '10', '32', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10717', '54', '7.45', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10717', '69', '36', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10718', '12', '38', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10718', '16', '17.45', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10718', '36', '19', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10718', '62', '49.30', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10719', '18', '62.50', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10719', '30', '25.89', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10719', '54', '7.45', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10720', '35', '18', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10720', '71', '21.50', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10721', '44', '19.45', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10722', '2', '19', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10722', '31', '12.50', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10722', '68', '12.50', '45', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10722', '75', '7.75', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10723', '26', '31.23', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10724', '10', '31', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10724', '61', '28.50', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10725', '41', '9.65', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10725', '52', '7', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10725', '55', '24', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10726', '4', '22', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10726', '11', '21', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10727', '17', '39', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10727', '56', '38', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10727', '59', '55', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10728', '30', '25.89', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10728', '40', '18.40', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10728', '55', '24', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10728', '60', '34', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10729', '1', '18', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10729', '21', '10', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10729', '50', '16.25', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10730', '16', '17.45', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10730', '31', '12.50', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10730', '65', '21.05', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10731', '21', '10', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10731', '51', '53', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10732', '76', '18', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10733', '14', '23.25', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10733', '28', '45.60', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10733', '52', '7', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10734', '6', '25', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10734', '30', '25.89', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10734', '76', '18', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10735', '61', '28.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10735', '77', '13', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10736', '65', '21.05', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10736', '75', '7.75', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10737', '13', '6', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10737', '41', '9.65', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10738', '16', '17.45', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10739', '36', '19', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10739', '52', '7', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10740', '28', '45.60', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10740', '35', '18', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10740', '45', '9.50', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10740', '56', '38', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10741', '2', '19', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10742', '3', '10', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10742', '60', '34', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10742', '72', '34.80', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10743', '46', '12', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10744', '40', '18.40', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10745', '18', '62.50', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10745', '44', '19.45', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10745', '59', '55', '45', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10745', '72', '34.80', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10746', '13', '6', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10746', '42', '14', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10746', '62', '49.30', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10746', '69', '36', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10747', '31', '12.50', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10747', '41', '9.65', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10747', '63', '43.90', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10747', '69', '36', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10748', '23', '9', '44', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10748', '40', '18.40', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10748', '56', '38', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10749', '56', '38', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10749', '59', '55', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10749', '76', '18', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10750', '14', '23.25', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10750', '45', '9.50', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10750', '59', '55', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10751', '26', '31.23', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10751', '30', '25.89', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10751', '50', '16.25', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10751', '73', '15', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10752', '1', '18', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10752', '69', '36', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10753', '45', '9.50', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10753', '74', '10', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10754', '40', '18.40', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10755', '47', '9.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10755', '56', '38', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10755', '57', '19.50', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10755', '69', '36', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10756', '18', '62.50', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10756', '36', '19', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10756', '68', '12.50', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10248', '11', '14', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10248', '42', '9.80', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10248', '72', '34.80', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10249', '14', '18.60', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10249', '51', '42.40', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10250', '41', '7.70', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10250', '51', '42.40', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10250', '65', '16.80', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10251', '22', '16.80', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10251', '57', '15.60', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10251', '65', '16.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10252', '20', '64.80', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10252', '33', '2', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10252', '60', '27.20', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10253', '31', '10', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10253', '39', '14.40', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10253', '49', '16', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10254', '24', '3.60', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10254', '55', '19.20', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10254', '74', '8', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10255', '2', '15.20', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10255', '16', '13.90', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10255', '36', '15.20', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10255', '59', '44', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10256', '53', '26.20', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10256', '77', '10.40', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10257', '27', '35.10', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10257', '39', '14.40', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10257', '77', '10.40', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10258', '2', '15.20', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10258', '5', '17', '65', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10258', '32', '25.60', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10259', '21', '8', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10259', '37', '20.80', '1', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10260', '41', '7.70', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10260', '57', '15.60', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10260', '62', '39.40', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10260', '70', '12', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10261', '21', '8', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10261', '35', '14.40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10262', '5', '17', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10262', '7', '24', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10262', '56', '30.40', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10263', '16', '13.90', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10263', '24', '3.60', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10263', '30', '20.70', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10263', '74', '8', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10264', '2', '15.20', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10264', '41', '7.70', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10265', '17', '31.20', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10265', '70', '12', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10266', '12', '30.40', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10267', '40', '14.70', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10267', '59', '44', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10267', '76', '14.40', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10268', '29', '99', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10268', '72', '27.80', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10269', '33', '2', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10269', '72', '27.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10270', '36', '15.20', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10270', '43', '36.80', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10271', '33', '2', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10272', '20', '64.80', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10272', '31', '10', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10272', '72', '27.80', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10273', '10', '24.80', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10273', '31', '10', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10273', '33', '2', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10273', '40', '14.70', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10273', '76', '14.40', '33', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10274', '71', '17.20', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10274', '72', '27.80', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10275', '24', '3.60', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10275', '59', '44', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10276', '10', '24.80', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10276', '13', '4.80', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10277', '28', '36.40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10277', '62', '39.40', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10278', '44', '15.50', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10278', '59', '44', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10278', '63', '35.10', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10278', '73', '12', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10279', '17', '31.20', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10280', '24', '3.60', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10280', '55', '19.20', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10280', '75', '6.20', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10281', '19', '7.30', '1', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10281', '24', '3.60', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10281', '35', '14.40', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10282', '30', '20.70', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10282', '57', '15.60', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10283', '15', '12.40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10283', '19', '7.30', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10283', '60', '27.20', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10283', '72', '27.80', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10284', '27', '35.10', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10284', '44', '15.50', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10284', '60', '27.20', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10284', '67', '11.20', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10285', '1', '14.40', '45', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10285', '40', '14.70', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10285', '53', '26.20', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10286', '35', '14.40', '100', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10286', '62', '39.40', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10287', '16', '13.90', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10287', '34', '11.20', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10287', '46', '9.60', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10288', '54', '5.90', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10288', '68', '10', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10289', '3', '8', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10289', '64', '26.60', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10290', '5', '17', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10290', '29', '99', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10290', '49', '16', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10290', '77', '10.40', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10291', '13', '4.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10291', '44', '15.50', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10291', '51', '42.40', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10292', '20', '64.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10293', '18', '50', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10293', '24', '3.60', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10293', '63', '35.10', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10293', '75', '6.20', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10294', '1', '14.40', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10294', '17', '31.20', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10294', '43', '36.80', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10294', '60', '27.20', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10294', '75', '6.20', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10295', '56', '30.40', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10296', '11', '16.80', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10296', '16', '13.90', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10296', '69', '28.80', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10297', '39', '14.40', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10297', '72', '27.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10298', '2', '15.20', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10298', '36', '15.20', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10298', '59', '44', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10298', '62', '39.40', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10299', '19', '7.30', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10299', '70', '12', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10300', '66', '13.60', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10300', '68', '10', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10301', '40', '14.70', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10301', '56', '30.40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10302', '17', '31.20', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10302', '28', '36.40', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10302', '43', '36.80', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10303', '40', '14.70', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10303', '65', '16.80', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10303', '68', '10', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10304', '49', '16', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10304', '59', '44', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10304', '71', '17.20', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10305', '18', '50', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10305', '29', '99', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10305', '39', '14.40', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10306', '30', '20.70', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10306', '53', '26.20', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10306', '54', '5.90', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10307', '62', '39.40', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10307', '68', '10', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10308', '69', '28.80', '1', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10308', '70', '12', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10309', '4', '17.60', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10309', '6', '20', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10309', '42', '11.20', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10309', '43', '36.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10309', '71', '17.20', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10310', '16', '13.90', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10310', '62', '39.40', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10311', '42', '11.20', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10311', '69', '28.80', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10312', '28', '36.40', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10312', '43', '36.80', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10312', '53', '26.20', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10312', '75', '6.20', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10313', '36', '15.20', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10314', '32', '25.60', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10314', '58', '10.60', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10314', '62', '39.40', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10315', '34', '11.20', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10315', '70', '12', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10316', '41', '7.70', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10316', '62', '39.40', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10317', '1', '14.40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10318', '41', '7.70', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10318', '76', '14.40', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10319', '17', '31.20', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10319', '28', '36.40', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10319', '76', '14.40', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10320', '71', '17.20', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10321', '35', '14.40', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10322', '52', '5.60', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10323', '15', '12.40', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10323', '25', '11.20', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10323', '39', '14.40', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10324', '16', '13.90', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10324', '35', '14.40', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10324', '46', '9.60', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10324', '59', '44', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10324', '63', '35.10', '80', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10325', '6', '20', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10325', '13', '4.80', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10325', '14', '18.60', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10325', '31', '10', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10325', '72', '27.80', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10326', '4', '17.60', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10326', '57', '15.60', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10326', '75', '6.20', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10327', '2', '15.20', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10327', '11', '16.80', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10327', '30', '20.70', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10327', '58', '10.60', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10328', '59', '44', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10328', '65', '16.80', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10328', '68', '10', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10329', '19', '7.30', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10329', '30', '20.70', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10329', '38', '210.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10329', '56', '30.40', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10330', '26', '24.90', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10330', '72', '27.80', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10331', '54', '5.90', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10332', '18', '50', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10332', '42', '11.20', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10332', '47', '7.60', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10333', '14', '18.60', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10333', '21', '8', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10333', '71', '17.20', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10334', '52', '5.60', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10334', '68', '10', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10335', '2', '15.20', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10335', '31', '10', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10335', '32', '25.60', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10335', '51', '42.40', '48', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10336', '4', '17.60', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10337', '23', '7.20', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10337', '26', '24.90', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10337', '36', '15.20', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10337', '37', '20.80', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10337', '72', '27.80', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10338', '17', '31.20', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10338', '30', '20.70', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10339', '4', '17.60', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10339', '17', '31.20', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10339', '62', '39.40', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10340', '18', '50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10340', '41', '7.70', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10340', '43', '36.80', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10341', '33', '2', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10341', '59', '44', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10342', '2', '15.20', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10342', '31', '10', '56', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10342', '36', '15.20', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10342', '55', '19.20', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10343', '64', '26.60', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10343', '68', '10', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10343', '76', '14.40', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10344', '4', '17.60', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10344', '8', '32', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10345', '8', '32', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10345', '19', '7.30', '80', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10345', '42', '11.20', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10346', '17', '31.20', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10346', '56', '30.40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10347', '25', '11.20', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10347', '39', '14.40', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10347', '40', '14.70', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10347', '75', '6.20', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10348', '1', '14.40', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10348', '23', '7.20', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10349', '54', '5.90', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10350', '50', '13', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10350', '69', '28.80', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10351', '38', '210.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10351', '41', '7.70', '13', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10351', '44', '15.50', '77', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10351', '65', '16.80', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10352', '24', '3.60', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10352', '54', '5.90', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10353', '11', '16.80', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10353', '38', '210.80', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10354', '1', '14.40', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10354', '29', '99', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10355', '24', '3.60', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10355', '57', '15.60', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10356', '31', '10', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10356', '55', '19.20', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10356', '69', '28.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10357', '10', '24.80', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10357', '26', '24.90', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10357', '60', '27.20', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10358', '24', '3.60', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10358', '34', '11.20', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10358', '36', '15.20', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10359', '16', '13.90', '56', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10359', '31', '10', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10359', '60', '27.20', '80', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10360', '28', '36.40', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10360', '29', '99', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10360', '38', '210.80', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10360', '49', '16', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10360', '54', '5.90', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10361', '39', '14.40', '54', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10361', '60', '27.20', '55', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10362', '25', '11.20', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10362', '51', '42.40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10362', '54', '5.90', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10363', '31', '10', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10363', '75', '6.20', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10363', '76', '14.40', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10364', '69', '28.80', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10364', '71', '17.20', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10365', '11', '16.80', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10366', '65', '16.80', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10366', '77', '10.40', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10367', '34', '11.20', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10367', '54', '5.90', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10367', '65', '16.80', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10367', '77', '10.40', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10368', '21', '8', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10368', '28', '36.40', '13', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10368', '57', '15.60', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10368', '64', '26.60', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10369', '29', '99', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10369', '56', '30.40', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10370', '1', '14.40', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10370', '64', '26.60', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10370', '74', '8', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10371', '36', '15.20', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10372', '20', '64.80', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10372', '38', '210.80', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10372', '60', '27.20', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10889', '38', '263.50', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10890', '17', '39', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10890', '34', '14', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10890', '41', '9.65', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10891', '30', '25.89', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10892', '59', '55', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10893', '8', '40', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10893', '24', '4.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10893', '29', '123.79', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10893', '30', '25.89', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10893', '36', '19', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10894', '13', '6', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10894', '69', '36', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10894', '75', '7.75', '120', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10895', '24', '4.50', '110', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10895', '39', '18', '45', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10895', '40', '18.40', '91', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10895', '60', '34', '100', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10896', '45', '9.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10896', '56', '38', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10897', '29', '123.79', '80', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10897', '30', '25.89', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10898', '13', '6', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10899', '39', '18', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10900', '70', '15', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10901', '41', '9.65', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10901', '71', '21.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10902', '55', '24', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10902', '62', '49.30', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10903', '13', '6', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10903', '65', '21.05', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10903', '68', '12.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10904', '58', '13.25', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10904', '62', '49.30', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10905', '1', '18', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10906', '61', '28.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10907', '75', '7.75', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10908', '7', '30', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10908', '52', '7', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10909', '7', '30', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10909', '16', '17.45', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10909', '41', '9.65', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10910', '19', '9.20', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10910', '49', '20', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10910', '61', '28.50', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10911', '1', '18', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10911', '17', '39', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10911', '67', '14', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10912', '11', '21', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10912', '29', '123.79', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10913', '4', '22', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10913', '33', '2.50', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10913', '58', '13.25', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10914', '71', '21.50', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10915', '17', '39', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10915', '33', '2.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10915', '54', '7.45', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10916', '16', '17.45', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10916', '32', '32', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10916', '57', '19.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10917', '30', '25.89', '1', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10917', '60', '34', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10918', '1', '18', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10918', '60', '34', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10919', '16', '17.45', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10919', '25', '14', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10919', '40', '18.40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10920', '50', '16.25', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10921', '35', '18', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10921', '63', '43.90', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10922', '17', '39', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10922', '24', '4.50', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10923', '42', '14', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10923', '43', '46', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10923', '67', '14', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10924', '10', '31', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10924', '28', '45.60', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10924', '75', '7.75', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10925', '36', '19', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10925', '52', '7', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10926', '11', '21', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10926', '13', '6', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10926', '19', '9.20', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10926', '72', '34.80', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10927', '20', '81', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10927', '52', '7', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10927', '76', '18', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10928', '47', '9.50', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10928', '76', '18', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10929', '21', '10', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10929', '75', '7.75', '49', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10929', '77', '13', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10930', '21', '10', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10930', '27', '43.90', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10930', '55', '24', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10930', '58', '13.25', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10931', '13', '6', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10931', '57', '19.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10932', '16', '17.45', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10932', '62', '49.30', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10932', '72', '34.80', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10932', '75', '7.75', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10933', '53', '32.80', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10933', '61', '28.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10934', '6', '25', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10935', '1', '18', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10935', '18', '62.50', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10935', '23', '9', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10936', '36', '19', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10937', '28', '45.60', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10937', '34', '14', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10938', '13', '6', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10938', '43', '46', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10938', '60', '34', '49', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10938', '71', '21.50', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10939', '2', '19', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10939', '67', '14', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10940', '7', '30', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10940', '13', '6', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10941', '31', '12.50', '44', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10941', '62', '49.30', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10941', '68', '12.50', '80', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10941', '72', '34.80', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10942', '49', '20', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10943', '13', '6', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10943', '22', '21', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10943', '46', '12', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10944', '11', '21', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10944', '44', '19.45', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10944', '56', '38', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10945', '13', '6', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10945', '31', '12.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10946', '10', '31', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10946', '24', '4.50', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10946', '77', '13', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10947', '59', '55', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10948', '50', '16.25', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10948', '51', '53', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10948', '55', '24', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10949', '6', '25', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10949', '10', '31', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10949', '17', '39', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10949', '62', '49.30', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10950', '4', '22', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10951', '33', '2.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10951', '41', '9.65', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10951', '75', '7.75', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10952', '6', '25', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10952', '28', '45.60', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10953', '20', '81', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10953', '31', '12.50', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10954', '16', '17.45', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10954', '31', '12.50', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10954', '45', '9.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10954', '60', '34', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10955', '75', '7.75', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10956', '21', '10', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10956', '47', '9.50', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10956', '51', '53', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10957', '30', '25.89', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10957', '35', '18', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10957', '64', '33.25', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10958', '5', '21.35', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10958', '7', '30', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10958', '72', '34.80', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10959', '75', '7.75', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10960', '24', '4.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10960', '41', '9.65', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10961', '52', '7', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10961', '76', '18', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10962', '7', '30', '45', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10962', '13', '6', '77', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10962', '53', '32.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10962', '69', '36', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10962', '76', '18', '44', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10963', '60', '34', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10964', '18', '62.50', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10964', '38', '263.50', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10964', '69', '36', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10965', '51', '53', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10966', '37', '26', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10966', '56', '38', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10966', '62', '49.30', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10967', '19', '9.20', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10967', '49', '20', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10968', '12', '38', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10968', '24', '4.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10968', '64', '33.25', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10969', '46', '12', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10970', '52', '7', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10971', '29', '123.79', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10972', '17', '39', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10972', '33', '2.50', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10973', '26', '31.23', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10973', '41', '9.65', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10973', '75', '7.75', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10974', '63', '43.90', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10975', '8', '40', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10975', '75', '7.75', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10976', '28', '45.60', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10977', '39', '18', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10977', '47', '9.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10977', '51', '53', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10977', '63', '43.90', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10978', '8', '40', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10978', '21', '10', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10978', '40', '18.40', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10978', '44', '19.45', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10979', '7', '30', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10979', '12', '38', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10979', '24', '4.50', '80', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10979', '27', '43.90', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10979', '31', '12.50', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10979', '63', '43.90', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10980', '75', '7.75', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10981', '38', '263.50', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10982', '7', '30', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10982', '43', '46', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10983', '13', '6', '84', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10983', '57', '19.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10984', '16', '17.45', '55', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10984', '24', '4.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10984', '36', '19', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10985', '16', '17.45', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10985', '18', '62.50', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10985', '32', '32', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10986', '11', '21', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10986', '20', '81', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10986', '76', '18', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10986', '77', '13', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10987', '7', '30', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10987', '43', '46', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10987', '72', '34.80', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10988', '7', '30', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10988', '62', '49.30', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10989', '6', '25', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10989', '11', '21', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10989', '41', '9.65', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10990', '21', '10', '65', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10990', '34', '14', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10990', '55', '24', '65', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10990', '61', '28.50', '66', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10991', '2', '19', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10991', '70', '15', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10991', '76', '18', '90', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10992', '72', '34.80', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10993', '29', '123.79', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10993', '41', '9.65', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10994', '59', '55', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10995', '51', '53', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10995', '60', '34', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10996', '42', '14', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10997', '32', '32', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10997', '46', '12', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10997', '52', '7', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10998', '24', '4.50', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10998', '61', '28.50', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10998', '74', '10', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10998', '75', '7.75', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10999', '41', '9.65', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10999', '51', '53', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('10999', '77', '13', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11000', '4', '22', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11000', '24', '4.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11000', '77', '13', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11001', '7', '30', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11001', '22', '21', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11001', '46', '12', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11001', '55', '24', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11002', '13', '6', '56', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11002', '35', '18', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11002', '42', '14', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11002', '55', '24', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11003', '1', '18', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11003', '40', '18.40', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11003', '52', '7', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11004', '26', '31.23', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11004', '76', '18', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11005', '1', '18', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11005', '59', '55', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11006', '1', '18', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11006', '29', '123.79', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11007', '8', '40', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11007', '29', '123.79', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11007', '42', '14', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11008', '28', '45.60', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11008', '34', '14', '90', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11008', '71', '21.50', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11009', '24', '4.50', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11009', '36', '19', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11009', '60', '34', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11010', '7', '30', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11010', '24', '4.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11011', '58', '13.25', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11011', '71', '21.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11012', '19', '9.20', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11012', '60', '34', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11012', '71', '21.50', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11013', '23', '9', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11013', '42', '14', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11013', '45', '9.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11013', '68', '12.50', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11014', '41', '9.65', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11015', '30', '25.89', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11015', '77', '13', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11016', '31', '12.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11016', '36', '19', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11017', '3', '10', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11017', '59', '55', '110', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11017', '70', '15', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11018', '12', '38', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11018', '18', '62.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11018', '56', '38', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11019', '46', '12', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11019', '49', '20', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11020', '10', '31', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11021', '2', '19', '11', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11021', '20', '81', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11021', '26', '31.23', '63', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11021', '51', '53', '44', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11021', '72', '34.80', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11022', '19', '9.20', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11022', '69', '36', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11023', '7', '30', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11023', '43', '46', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11024', '26', '31.23', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11024', '33', '2.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11024', '65', '21.05', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11024', '71', '21.50', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11025', '1', '18', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11025', '13', '6', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11026', '18', '62.50', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11026', '51', '53', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11027', '24', '4.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11027', '62', '49.30', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11028', '55', '24', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11028', '59', '55', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11029', '56', '38', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11029', '63', '43.90', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11030', '2', '19', '100', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11030', '5', '21.35', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11030', '29', '123.79', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11030', '59', '55', '100', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11031', '1', '18', '45', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11031', '13', '6', '80', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11031', '24', '4.50', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11031', '64', '33.25', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11031', '71', '21.50', '16', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11032', '36', '19', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11032', '38', '263.50', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11032', '59', '55', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11033', '53', '32.80', '70', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11033', '69', '36', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11034', '21', '10', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11034', '44', '19.45', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11034', '61', '28.50', '6', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11035', '1', '18', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11035', '35', '18', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11035', '42', '14', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11035', '54', '7.45', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11036', '13', '6', '7', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11036', '59', '55', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11037', '70', '15', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11038', '40', '18.40', '5', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11038', '52', '7', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11038', '71', '21.50', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11039', '28', '45.60', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11039', '35', '18', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11039', '49', '20', '60', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11039', '57', '19.50', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11040', '21', '10', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11041', '2', '19', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11041', '63', '43.90', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11042', '44', '19.45', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11042', '61', '28.50', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11043', '11', '21', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11044', '62', '49.30', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11045', '33', '2.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11045', '51', '53', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11046', '12', '38', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11046', '32', '32', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11046', '35', '18', '18', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11047', '1', '18', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11047', '5', '21.35', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11048', '68', '12.50', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11049', '2', '19', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11049', '12', '38', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11050', '76', '18', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11051', '24', '4.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11052', '43', '46', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11052', '61', '28.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11053', '18', '62.50', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11053', '32', '32', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11053', '64', '33.25', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11054', '33', '2.50', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11054', '67', '14', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11055', '24', '4.50', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11055', '25', '14', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11055', '51', '53', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11055', '57', '19.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11056', '7', '30', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11056', '55', '24', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11056', '60', '34', '50', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11057', '70', '15', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11058', '21', '10', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11058', '60', '34', '21', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11058', '61', '28.50', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11059', '13', '6', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11059', '17', '39', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11059', '60', '34', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11060', '60', '34', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11060', '77', '13', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11061', '60', '34', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11062', '53', '32.80', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11062', '70', '15', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11063', '34', '14', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11063', '40', '18.40', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11063', '41', '9.65', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11064', '17', '39', '77', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11064', '41', '9.65', '12', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11064', '53', '32.80', '25', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11064', '55', '24', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11064', '68', '12.50', '55', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11065', '30', '25.89', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11065', '54', '7.45', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11066', '16', '17.45', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11066', '19', '9.20', '42', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11066', '34', '14', '35', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11067', '41', '9.65', '9', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11068', '28', '45.60', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11068', '43', '46', '36', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11068', '77', '13', '28', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11069', '39', '18', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11070', '1', '18', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11070', '2', '19', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11070', '16', '17.45', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11070', '31', '12.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11071', '7', '30', '15', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11071', '13', '6', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11072', '2', '19', '8', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11072', '41', '9.65', '40', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11072', '50', '16.25', '22', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11072', '64', '33.25', '130', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11073', '11', '21', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11073', '24', '4.50', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11074', '16', '17.45', '14', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11075', '2', '19', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11075', '46', '12', '30', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11075', '76', '18', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11076', '6', '25', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11076', '14', '23.25', '20', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11076', '19', '9.20', '10', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '2', '19', '24', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '3', '10', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '4', '22', '1', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '6', '25', '1', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '7', '30', '1', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '8', '40', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '10', '31', '1', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '12', '38', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '13', '6', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '14', '23.25', '1', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '16', '17.45', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '20', '81', '1', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '23', '9', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '32', '32', '1', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '39', '18', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '41', '9.65', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '46', '12', '3', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '52', '7', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '55', '24', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '60', '34', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '64', '33.25', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '66', '17', '1', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '73', '15', '2', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '75', '7.75', '4', '0');
INSERT INTO "ORDER DETAILS" VALUES ('11077', '77', '13', '2', '0');

-- ----------------------------
-- Table structure for ORDERS
-- ----------------------------
--DROP TABLE "ORDERS";
CREATE TABLE "ORDERS" (
"ORDERID" NUMBER(38) NOT NULL ,
"CUSTOMERID" CHAR(5 BYTE) DEFAULT NULL  NULL ,
"EMPLOYEEID" NUMBER(38) DEFAULT NULL  NULL ,
"ORDERDATE" DATE DEFAULT NULL  NULL ,
"REQUIREDDATE" DATE DEFAULT NULL  NULL ,
"SHIPPEDDATE" DATE DEFAULT NULL  NULL ,
"SHIPVIA" NUMBER(38) DEFAULT NULL  NULL ,
"FREIGHT" NUMBER(19,4) DEFAULT NULL  NULL ,
"SHIPNAME" VARCHAR2(40 BYTE) DEFAULT NULL  NULL ,
"SHIPADDRESS" VARCHAR2(60 BYTE) DEFAULT NULL  NULL ,
"SHIPCITY" VARCHAR2(15 BYTE) DEFAULT NULL  NULL ,
"SHIPREGION" VARCHAR2(15 BYTE) DEFAULT NULL  NULL ,
"SHIPPOSTALCODE" VARCHAR2(10 BYTE) DEFAULT NULL  NULL ,
"SHIPCOUNTRY" VARCHAR2(15 BYTE) DEFAULT NULL  NULL 
)
LOGGING
NOCOMPRESS
NOCACHE

;

-- ----------------------------
-- Records of ORDERS
-- ----------------------------
INSERT INTO "ORDERS" VALUES ('10311', 'DUMON', '1', TO_DATE('1996-09-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '24.69', 'Du monde entier', '67, rue des Cinquante Otages', 'Nantes', null, '44000', 'France');
INSERT INTO "ORDERS" VALUES ('10312', 'WANDK', '2', TO_DATE('1996-09-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '40.26', 'Die Wandernde Kuh', 'Adenauerallee 900', 'Stuttgart', null, '70563', 'Germany');
INSERT INTO "ORDERS" VALUES ('10313', 'QUICK', '2', TO_DATE('1996-09-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '1.96', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10314', 'RATTC', '1', TO_DATE('1996-09-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '74.16', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');
INSERT INTO "ORDERS" VALUES ('10315', 'ISLAT', '4', TO_DATE('1996-09-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '41.76', 'Island Trading', 'Garden House Crowther Way', 'Cowes', 'Isle of Wight', 'PO31 7PJ', 'UK');
INSERT INTO "ORDERS" VALUES ('10316', 'RATTC', '1', TO_DATE('1996-09-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '150.15', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');
INSERT INTO "ORDERS" VALUES ('10317', 'LONEP', '6', TO_DATE('1996-09-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '12.69', 'Lonesome Pine Restaurant', '89 Chiaroscuro Rd.', 'Portland', 'OR', '97219', 'USA');
INSERT INTO "ORDERS" VALUES ('10318', 'ISLAT', '8', TO_DATE('1996-10-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '4.73', 'Island Trading', 'Garden House Crowther Way', 'Cowes', 'Isle of Wight', 'PO31 7PJ', 'UK');
INSERT INTO "ORDERS" VALUES ('10319', 'TORTU', '7', TO_DATE('1996-10-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '64.50', 'Tortuga Restaurante', 'Avda. Azteca 123', 'M茅xico D.F.', null, '05033', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10320', 'WARTH', '5', TO_DATE('1996-10-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '34.57', 'Wartian Herkku', 'Torikatu 38', 'Oulu', null, '90110', 'Finland');
INSERT INTO "ORDERS" VALUES ('10321', 'ISLAT', '3', TO_DATE('1996-10-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '3.43', 'Island Trading', 'Garden House Crowther Way', 'Cowes', 'Isle of Wight', 'PO31 7PJ', 'UK');
INSERT INTO "ORDERS" VALUES ('10322', 'PERIC', '7', TO_DATE('1996-10-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '0.40', 'Pericles Comidas cl谩sicas', 'Calle Dr. Jorge Cash 321', 'M茅xico D.F.', null, '05033', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10323', 'KOENE', '4', TO_DATE('1996-10-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '4.88', 'K枚niglich Essen', 'Maubelstr. 90', 'Brandenburg', null, '14776', 'Germany');
INSERT INTO "ORDERS" VALUES ('10324', 'SAVEA', '9', TO_DATE('1996-10-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '214.27', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10325', 'KOENE', '1', TO_DATE('1996-10-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '64.86', 'K枚niglich Essen', 'Maubelstr. 90', 'Brandenburg', null, '14776', 'Germany');
INSERT INTO "ORDERS" VALUES ('10326', 'BOLID', '4', TO_DATE('1996-10-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '77.92', 'B贸lido Comidas preparadas', 'C/ Araquil, 67', 'Madrid', null, '28023', 'Spain');
INSERT INTO "ORDERS" VALUES ('10327', 'FOLKO', '2', TO_DATE('1996-10-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '63.36', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10328', 'FURIB', '4', TO_DATE('1996-10-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '87.03', 'Furia Bacalhau e Frutos do Mar', 'Jardim das rosas n. 32', 'Lisboa', null, '1675', 'Portugal');
INSERT INTO "ORDERS" VALUES ('10329', 'SPLIR', '4', TO_DATE('1996-10-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '191.67', 'Split Rail Beer 1', 'P.O. Box 555', 'Lander', 'WY', '82520', 'USA');
INSERT INTO "ORDERS" VALUES ('10330', 'LILAS', '3', TO_DATE('1996-10-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '12.75', 'LILA-Supermercado', 'Carrera 52 con Ave. Bol铆var #65-98 Llano Largo', 'Barquisimeto', 'Lara', '3508', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10331', 'BONAP', '9', TO_DATE('1996-10-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '10.19', 'Bon app', '12, rue des Bouchers', 'Marseille', null, '13008', 'France');
INSERT INTO "ORDERS" VALUES ('10332', 'MEREP', '3', TO_DATE('1996-10-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '52.84', 'M猫re Paillarde', '43 rue St. Laurent', 'Montr茅al', 'Qu茅bec', 'H1J 1C3', 'Canada');
INSERT INTO "ORDERS" VALUES ('10333', 'WARTH', '5', TO_DATE('1996-10-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '0.59', 'Wartian Herkku', 'Torikatu 38', 'Oulu', null, '90110', 'Finland');
INSERT INTO "ORDERS" VALUES ('10334', 'VICTE', '8', TO_DATE('1996-10-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '8.56', 'Victuailles en stock', '2, rue du Commerce', 'Lyon', null, '69004', 'France');
INSERT INTO "ORDERS" VALUES ('10335', 'HUNGO', '7', TO_DATE('1996-10-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '42.11', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10336', 'PRINI', '7', TO_DATE('1996-10-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '15.51', 'Princesa Isabel Vinhos', 'Estrada da sa煤de n. 58', 'Lisboa', null, '1756', 'Portugal');
INSERT INTO "ORDERS" VALUES ('10337', 'FRANK', '4', TO_DATE('1996-10-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '108.26', 'Frankenversand', 'Berliner Platz 43', 'M眉nchen', null, '80805', 'Germany');
INSERT INTO "ORDERS" VALUES ('10338', 'OLDWO', '4', TO_DATE('1996-10-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '84.21', 'Old World Delicatessen', '2743 Bering St.', 'Anchorage', 'AK', '99508', 'USA');
INSERT INTO "ORDERS" VALUES ('10339', 'MEREP', '2', TO_DATE('1996-10-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '15.66', 'M猫re Paillarde', '43 rue St. Laurent', 'Montr茅al', 'Qu茅bec', 'H1J 1C3', 'Canada');
INSERT INTO "ORDERS" VALUES ('10340', 'BONAP', '1', TO_DATE('1996-10-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '166.31', 'Bon app', '12, rue des Bouchers', 'Marseille', null, '13008', 'France');
INSERT INTO "ORDERS" VALUES ('10341', 'SIMOB', '7', TO_DATE('1996-10-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '26.78', 'Simons bistro', 'Vinb忙ltet 34', 'Kobenhavn', null, '1734', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10342', 'FRANK', '4', TO_DATE('1996-10-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '54.83', 'Frankenversand', 'Berliner Platz 43', 'M眉nchen', null, '80805', 'Germany');
INSERT INTO "ORDERS" VALUES ('10343', 'LEHMS', '4', TO_DATE('1996-10-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '110.37', 'Lehmanns Marktstand', 'Magazinweg 7', 'Frankfurt a.M.', null, '60528', 'Germany');
INSERT INTO "ORDERS" VALUES ('10344', 'WHITC', '4', TO_DATE('1996-11-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '23.29', 'White Clover Markets', '1029 - 12th Ave. S.', 'Seattle', 'WA', '98124', 'USA');
INSERT INTO "ORDERS" VALUES ('10345', 'QUICK', '2', TO_DATE('1996-11-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '249.06', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10346', 'RATTC', '3', TO_DATE('1996-11-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '142.08', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');
INSERT INTO "ORDERS" VALUES ('10347', 'FAMIA', '4', TO_DATE('1996-11-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '3.10', 'Familia Arquibaldo', 'Rua Or贸s, 92', 'Sao Paulo', 'SP', '05442-030', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10348', 'WANDK', '4', TO_DATE('1996-11-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '0.78', 'Die Wandernde Kuh', 'Adenauerallee 900', 'Stuttgart', null, '70563', 'Germany');
INSERT INTO "ORDERS" VALUES ('10349', 'SPLIR', '7', TO_DATE('1996-11-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '8.63', 'Split Rail Beer 1', 'P.O. Box 555', 'Lander', 'WY', '82520', 'USA');
INSERT INTO "ORDERS" VALUES ('10350', 'LAMAI', '6', TO_DATE('1996-11-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '64.19', 'La maison dAsie', '1 rue Alsace-Lorraine', 'Toulouse', null, '31000', 'France');
INSERT INTO "ORDERS" VALUES ('10351', 'ERNSH', '1', TO_DATE('1996-11-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '162.33', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10352', 'FURIB', '3', TO_DATE('1996-11-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '1.30', 'Furia Bacalhau e Frutos do Mar', 'Jardim das rosas n. 32', 'Lisboa', null, '1675', 'Portugal');
INSERT INTO "ORDERS" VALUES ('10353', 'PICCO', '7', TO_DATE('1996-11-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '360.63', 'Piccolo und mehr', 'Geislweg 14', 'Salzburg', null, '5020', 'Austria');
INSERT INTO "ORDERS" VALUES ('10354', 'PERIC', '8', TO_DATE('1996-11-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '53.80', 'Pericles Comidas cl谩sicas', 'Calle Dr. Jorge Cash 321', 'M茅xico D.F.', null, '05033', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10355', 'AROUT', '6', TO_DATE('1996-11-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '41.95', 'Around the Horn', 'Brook Farm Stratford St. Mary', 'Colchester', 'Essex', 'CO7 6JX', 'UK');
INSERT INTO "ORDERS" VALUES ('10356', 'WANDK', '6', TO_DATE('1996-11-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '36.71', 'Die Wandernde Kuh', 'Adenauerallee 900', 'Stuttgart', null, '70563', 'Germany');
INSERT INTO "ORDERS" VALUES ('10357', 'LILAS', '1', TO_DATE('1996-11-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '34.88', 'LILA-Supermercado', 'Carrera 52 con Ave. Bol铆var #65-98 Llano Largo', 'Barquisimeto', 'Lara', '3508', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10358', 'LAMAI', '5', TO_DATE('1996-11-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '19.64', 'La maison dAsie', '1 rue Alsace-Lorraine', 'Toulouse', null, '31000', 'France');
INSERT INTO "ORDERS" VALUES ('10359', 'SEVES', '5', TO_DATE('1996-11-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '288.43', 'Seven Seas Imports', '90 Wadhurst Rd.', 'London', null, 'OX15 4NB', 'UK');
INSERT INTO "ORDERS" VALUES ('10360', 'BLONP', '4', TO_DATE('1996-11-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '131.70', 'Blondel p猫re et fils', '24, place Kl茅ber', 'Strasbourg', null, '67000', 'France');
INSERT INTO "ORDERS" VALUES ('10361', 'QUICK', '1', TO_DATE('1996-11-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '183.17', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10362', 'BONAP', '3', TO_DATE('1996-11-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-11-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '96.04', 'Bon app', '12, rue des Bouchers', 'Marseille', null, '13008', 'France');
INSERT INTO "ORDERS" VALUES ('10363', 'DRACD', '4', TO_DATE('1996-11-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '30.54', 'Drachenblut Delikatessen', 'Walserweg 21', 'Aachen', null, '52066', 'Germany');
INSERT INTO "ORDERS" VALUES ('10364', 'EASTC', '1', TO_DATE('1996-11-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '71.97', 'Eastern Connection', '35 King George', 'London', null, 'WX3 6FW', 'UK');
INSERT INTO "ORDERS" VALUES ('10365', 'ANTON', '3', TO_DATE('1996-11-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '22', 'Antonio Moreno Taquer铆a', 'Mataderos  2312', 'M茅xico D.F.', null, '05023', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10366', 'GALED', '8', TO_DATE('1996-11-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '10.14', 'Galer铆a del gastron贸mo', 'Rambla de Catalu帽a, 23', 'Barcelona', null, '8022', 'Spain');
INSERT INTO "ORDERS" VALUES ('10367', 'VAFFE', '7', TO_DATE('1996-11-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '13.55', 'Vaffeljernet', 'Smagsloget 45', '脜rhus', null, '8200', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10368', 'ERNSH', '2', TO_DATE('1996-11-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '101.95', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10369', 'SPLIR', '8', TO_DATE('1996-12-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '195.68', 'Split Rail Beer 1', 'P.O. Box 555', 'Lander', 'WY', '82520', 'USA');
INSERT INTO "ORDERS" VALUES ('10370', 'CHOPS', '6', TO_DATE('1996-12-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '1.17', 'Chop-suey Chinese', 'Hauptstr. 31', 'Bern', null, '3012', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('10371', 'LAMAI', '1', TO_DATE('1996-12-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '0.45', 'La maison dAsie', '1 rue Alsace-Lorraine', 'Toulouse', null, '31000', 'France');
INSERT INTO "ORDERS" VALUES ('10372', 'QUEEN', '5', TO_DATE('1996-12-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '890.78', 'Queen Cozinha', 'Alameda dos Can脿rios, 891', 'Sao Paulo', 'SP', '05487-020', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10373', 'HUNGO', '4', TO_DATE('1996-12-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '124.12', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10374', 'WOLZA', '1', TO_DATE('1996-12-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '3.94', 'Wolski Zajazd', 'ul. Filtrowa 68', 'Warszawa', null, '01-012', 'Poland');
INSERT INTO "ORDERS" VALUES ('10375', 'HUNGC', '3', TO_DATE('1996-12-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '20.12', 'Hungry Coyote Import Store', 'City Center Plaza 516 Main St.', 'Elgin', 'OR', '97827', 'USA');
INSERT INTO "ORDERS" VALUES ('10502', 'PERIC', '2', TO_DATE('1997-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '69.32', 'Pericles Comidas cl谩sicas', 'Calle Dr. Jorge Cash 321', 'M茅xico D.F.', null, '05033', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10503', 'HUNGO', '6', TO_DATE('1997-04-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '16.74', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10504', 'WHITC', '4', TO_DATE('1997-04-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '59.13', 'White Clover Markets', '1029 - 12th Ave. S.', 'Seattle', 'WA', '98124', 'USA');
INSERT INTO "ORDERS" VALUES ('10505', 'MEREP', '3', TO_DATE('1997-04-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '7.13', 'M猫re Paillarde', '43 rue St. Laurent', 'Montr茅al', 'Qu茅bec', 'H1J 1C3', 'Canada');
INSERT INTO "ORDERS" VALUES ('10506', 'KOENE', '9', TO_DATE('1997-04-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '21.19', 'K枚niglich Essen', 'Maubelstr. 90', 'Brandenburg', null, '14776', 'Germany');
INSERT INTO "ORDERS" VALUES ('10507', 'ANTON', '7', TO_DATE('1997-04-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '47.45', 'Antonio Moreno Taquer铆a', 'Mataderos  2312', 'M茅xico D.F.', null, '05023', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10508', 'OTTIK', '1', TO_DATE('1997-04-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '4.99', 'Ottilies K盲seladen', 'Mehrheimerstr. 369', 'K枚ln', null, '50739', 'Germany');
INSERT INTO "ORDERS" VALUES ('10509', 'BLAUS', '4', TO_DATE('1997-04-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '0.15', 'Blauer See Delikatessen', 'Forsterstr. 57', 'Mannheim', null, '68306', 'Germany');
INSERT INTO "ORDERS" VALUES ('10510', 'SAVEA', '6', TO_DATE('1997-04-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '367.63', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10511', 'BONAP', '4', TO_DATE('1997-04-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '350.64', 'Bon app', '12, rue des Bouchers', 'Marseille', null, '13008', 'France');
INSERT INTO "ORDERS" VALUES ('10512', 'FAMIA', '7', TO_DATE('1997-04-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '3.53', 'Familia Arquibaldo', 'Rua Or贸s, 92', 'Sao Paulo', 'SP', '05442-030', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10513', 'WANDK', '7', TO_DATE('1997-04-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '105.65', 'Die Wandernde Kuh', 'Adenauerallee 900', 'Stuttgart', null, '70563', 'Germany');
INSERT INTO "ORDERS" VALUES ('10514', 'ERNSH', '3', TO_DATE('1997-04-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '789.95', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10515', 'QUICK', '2', TO_DATE('1997-04-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '204.47', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10516', 'HUNGO', '2', TO_DATE('1997-04-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '62.78', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10517', 'NORTS', '3', TO_DATE('1997-04-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '32.07', 'North/South', 'South House 300 Queensbridge', 'London', null, 'SW7 1RZ', 'UK');
INSERT INTO "ORDERS" VALUES ('10518', 'TORTU', '4', TO_DATE('1997-04-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '218.15', 'Tortuga Restaurante', 'Avda. Azteca 123', 'M茅xico D.F.', null, '05033', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10519', 'CHOPS', '6', TO_DATE('1997-04-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '91.76', 'Chop-suey Chinese', 'Hauptstr. 31', 'Bern', null, '3012', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('10520', 'SANTG', '7', TO_DATE('1997-04-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '13.37', 'Sant茅 Gourmet', 'Erling Skakkes gate 78', 'Stavern', null, '4110', 'Norway');
INSERT INTO "ORDERS" VALUES ('10521', 'CACTU', '8', TO_DATE('1997-04-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '17.22', 'Cactus Comidas para llevar', 'Cerrito 333', 'Buenos Aires', null, '1010', 'Argentina');
INSERT INTO "ORDERS" VALUES ('10522', 'LEHMS', '4', TO_DATE('1997-04-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '45.33', 'Lehmanns Marktstand', 'Magazinweg 7', 'Frankfurt a.M.', null, '60528', 'Germany');
INSERT INTO "ORDERS" VALUES ('10523', 'SEVES', '7', TO_DATE('1997-05-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '77.63', 'Seven Seas Imports', '90 Wadhurst Rd.', 'London', null, 'OX15 4NB', 'UK');
INSERT INTO "ORDERS" VALUES ('10524', 'BERGS', '1', TO_DATE('1997-05-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '244.79', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10525', 'BONAP', '1', TO_DATE('1997-05-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '11.06', 'Bon app', '12, rue des Bouchers', 'Marseille', null, '13008', 'France');
INSERT INTO "ORDERS" VALUES ('10526', 'WARTH', '4', TO_DATE('1997-05-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '58.59', 'Wartian Herkku', 'Torikatu 38', 'Oulu', null, '90110', 'Finland');
INSERT INTO "ORDERS" VALUES ('10527', 'QUICK', '7', TO_DATE('1997-05-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '41.90', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10528', 'GREAL', '6', TO_DATE('1997-05-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '3.35', 'Great Lakes Food Market', '2732 Baker Blvd.', 'Eugene', 'OR', '97403', 'USA');
INSERT INTO "ORDERS" VALUES ('10529', 'MAISD', '5', TO_DATE('1997-05-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '66.69', 'Maison Dewey', 'Rue Joseph-Bens 532', 'Bruxelles', null, 'B-1180', 'Belgium');
INSERT INTO "ORDERS" VALUES ('10530', 'PICCO', '3', TO_DATE('1997-05-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '339.22', 'Piccolo und mehr', 'Geislweg 14', 'Salzburg', null, '5020', 'Austria');
INSERT INTO "ORDERS" VALUES ('10531', 'OCEAN', '7', TO_DATE('1997-05-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '8.12', 'Oc茅ano Atl谩ntico Ltda.', 'Ing. Gustavo Moncada 8585 Piso 20-A', 'Buenos Aires', null, '1010', 'Argentina');
INSERT INTO "ORDERS" VALUES ('10532', 'EASTC', '7', TO_DATE('1997-05-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '74.46', 'Eastern Connection', '35 King George', 'London', null, 'WX3 6FW', 'UK');
INSERT INTO "ORDERS" VALUES ('10533', 'FOLKO', '8', TO_DATE('1997-05-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '188.04', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10534', 'LEHMS', '8', TO_DATE('1997-05-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '27.94', 'Lehmanns Marktstand', 'Magazinweg 7', 'Frankfurt a.M.', null, '60528', 'Germany');
INSERT INTO "ORDERS" VALUES ('10535', 'ANTON', '4', TO_DATE('1997-05-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '15.64', 'Antonio Moreno Taquer铆a', 'Mataderos  2312', 'M茅xico D.F.', null, '05023', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10536', 'LEHMS', '3', TO_DATE('1997-05-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '58.88', 'Lehmanns Marktstand', 'Magazinweg 7', 'Frankfurt a.M.', null, '60528', 'Germany');
INSERT INTO "ORDERS" VALUES ('10537', 'RICSU', '1', TO_DATE('1997-05-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '78.85', 'Richter Supermarkt', 'Starenweg 5', 'Gen猫ve', null, '1204', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('10538', 'BSBEV', '9', TO_DATE('1997-05-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '4.87', 'Bs Beverages', 'Fauntleroy Circus', 'London', null, 'EC2 5NT', 'UK');
INSERT INTO "ORDERS" VALUES ('10539', 'BSBEV', '6', TO_DATE('1997-05-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '12.36', 'Bs Beverages', 'Fauntleroy Circus', 'London', null, 'EC2 5NT', 'UK');
INSERT INTO "ORDERS" VALUES ('10540', 'QUICK', '3', TO_DATE('1997-05-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '1007.64', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10541', 'HANAR', '2', TO_DATE('1997-05-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '68.65', 'Hanari Carnes', 'Rua do Pa莽o, 67', 'Rio de Janeiro', 'RJ', '05454-876', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10542', 'KOENE', '1', TO_DATE('1997-05-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '10.95', 'K枚niglich Essen', 'Maubelstr. 90', 'Brandenburg', null, '14776', 'Germany');
INSERT INTO "ORDERS" VALUES ('10543', 'LILAS', '8', TO_DATE('1997-05-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '48.17', 'LILA-Supermercado', 'Carrera 52 con Ave. Bol铆var #65-98 Llano Largo', 'Barquisimeto', 'Lara', '3508', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10544', 'LONEP', '4', TO_DATE('1997-05-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '24.91', 'Lonesome Pine Restaurant', '89 Chiaroscuro Rd.', 'Portland', 'OR', '97219', 'USA');
INSERT INTO "ORDERS" VALUES ('10545', 'LAZYK', '8', TO_DATE('1997-05-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '11.92', 'Lazy K Kountry Store', '12 Orchestra Terrace', 'Walla Walla', 'WA', '99362', 'USA');
INSERT INTO "ORDERS" VALUES ('10546', 'VICTE', '1', TO_DATE('1997-05-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '194.72', 'Victuailles en stock', '2, rue du Commerce', 'Lyon', null, '69004', 'France');
INSERT INTO "ORDERS" VALUES ('10547', 'SEVES', '3', TO_DATE('1997-05-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '178.43', 'Seven Seas Imports', '90 Wadhurst Rd.', 'London', null, 'OX15 4NB', 'UK');
INSERT INTO "ORDERS" VALUES ('10548', 'TOMSP', '3', TO_DATE('1997-05-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '1.43', 'Toms Spezialit盲ten', 'Luisenstr. 48', 'M眉nster', null, '44087', 'Germany');
INSERT INTO "ORDERS" VALUES ('10549', 'QUICK', '5', TO_DATE('1997-05-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '171.24', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10550', 'GODOS', '7', TO_DATE('1997-05-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '4.32', 'Godos Cocina T铆pica', 'C/ Romero, 33', 'Sevilla', null, '41101', 'Spain');
INSERT INTO "ORDERS" VALUES ('10551', 'FURIB', '4', TO_DATE('1997-05-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '72.95', 'Furia Bacalhau e Frutos do Mar', 'Jardim das rosas n. 32', 'Lisboa', null, '1675', 'Portugal');
INSERT INTO "ORDERS" VALUES ('10552', 'HILAA', '2', TO_DATE('1997-05-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '83.22', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10553', 'WARTH', '2', TO_DATE('1997-05-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '149.49', 'Wartian Herkku', 'Torikatu 38', 'Oulu', null, '90110', 'Finland');
INSERT INTO "ORDERS" VALUES ('10554', 'OTTIK', '4', TO_DATE('1997-05-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '120.97', 'Ottilies K盲seladen', 'Mehrheimerstr. 369', 'K枚ln', null, '50739', 'Germany');
INSERT INTO "ORDERS" VALUES ('10555', 'SAVEA', '6', TO_DATE('1997-06-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '252.49', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10556', 'SIMOB', '2', TO_DATE('1997-06-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '9.80', 'Simons bistro', 'Vinb忙ltet 34', 'Kobenhavn', null, '1734', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10557', 'LEHMS', '9', TO_DATE('1997-06-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '96.72', 'Lehmanns Marktstand', 'Magazinweg 7', 'Frankfurt a.M.', null, '60528', 'Germany');
INSERT INTO "ORDERS" VALUES ('10558', 'AROUT', '1', TO_DATE('1997-06-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '72.97', 'Around the Horn', 'Brook Farm Stratford St. Mary', 'Colchester', 'Essex', 'CO7 6JX', 'UK');
INSERT INTO "ORDERS" VALUES ('10559', 'BLONP', '6', TO_DATE('1997-06-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '8.05', 'Blondel p猫re et fils', '24, place Kl茅ber', 'Strasbourg', null, '67000', 'France');
INSERT INTO "ORDERS" VALUES ('10560', 'FRANK', '8', TO_DATE('1997-06-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '36.65', 'Frankenversand', 'Berliner Platz 43', 'M眉nchen', null, '80805', 'Germany');
INSERT INTO "ORDERS" VALUES ('10561', 'FOLKO', '2', TO_DATE('1997-06-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '242.21', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10562', 'REGGC', '1', TO_DATE('1997-06-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '22.95', 'Reggiani Caseifici', 'Strada Provinciale 124', 'Reggio Emilia', null, '42100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10563', 'RICAR', '2', TO_DATE('1997-06-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '60.43', 'Ricardo Adocicados', 'Av. Copacabana, 267', 'Rio de Janeiro', 'RJ', '02389-890', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10564', 'RATTC', '4', TO_DATE('1997-06-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '13.75', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');
INSERT INTO "ORDERS" VALUES ('10376', 'MEREP', '1', TO_DATE('1996-12-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '20.39', 'M猫re Paillarde', '43 rue St. Laurent', 'Montr茅al', 'Qu茅bec', 'H1J 1C3', 'Canada');
INSERT INTO "ORDERS" VALUES ('10377', 'SEVES', '1', TO_DATE('1996-12-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '22.21', 'Seven Seas Imports', '90 Wadhurst Rd.', 'London', null, 'OX15 4NB', 'UK');
INSERT INTO "ORDERS" VALUES ('10378', 'FOLKO', '5', TO_DATE('1996-12-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '5.44', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10379', 'QUEDE', '2', TO_DATE('1996-12-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '45.03', 'Que Del铆cia', 'Rua da Panificadora, 12', 'Rio de Janeiro', 'RJ', '02389-673', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10380', 'HUNGO', '8', TO_DATE('1996-12-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '35.03', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10381', 'LILAS', '3', TO_DATE('1996-12-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '7.99', 'LILA-Supermercado', 'Carrera 52 con Ave. Bol铆var #65-98 Llano Largo', 'Barquisimeto', 'Lara', '3508', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10382', 'ERNSH', '4', TO_DATE('1996-12-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '94.77', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10383', 'AROUT', '8', TO_DATE('1996-12-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '34.24', 'Around the Horn', 'Brook Farm Stratford St. Mary', 'Colchester', 'Essex', 'CO7 6JX', 'UK');
INSERT INTO "ORDERS" VALUES ('10384', 'BERGS', '3', TO_DATE('1996-12-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '168.64', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10385', 'SPLIR', '1', TO_DATE('1996-12-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '30.96', 'Split Rail Beer 1', 'P.O. Box 555', 'Lander', 'WY', '82520', 'USA');
INSERT INTO "ORDERS" VALUES ('10386', 'FAMIA', '9', TO_DATE('1996-12-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '13.99', 'Familia Arquibaldo', 'Rua Or贸s, 92', 'Sao Paulo', 'SP', '05442-030', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10387', 'SANTG', '1', TO_DATE('1996-12-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '93.63', 'Sant茅 Gourmet', 'Erling Skakkes gate 78', 'Stavern', null, '4110', 'Norway');
INSERT INTO "ORDERS" VALUES ('10388', 'SEVES', '2', TO_DATE('1996-12-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '34.86', 'Seven Seas Imports', '90 Wadhurst Rd.', 'London', null, 'OX15 4NB', 'UK');
INSERT INTO "ORDERS" VALUES ('10389', 'BOTTM', '4', TO_DATE('1996-12-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '47.42', 'Bottom-Dollar Markets', '23 Tsawassen Blvd.', 'Tsawassen', 'BC', 'T2F 8M4', 'Canada');
INSERT INTO "ORDERS" VALUES ('10390', 'ERNSH', '6', TO_DATE('1996-12-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '126.38', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10391', 'DRACD', '3', TO_DATE('1996-12-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-12-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '5.45', 'Drachenblut Delikatessen', 'Walserweg 21', 'Aachen', null, '52066', 'Germany');
INSERT INTO "ORDERS" VALUES ('10392', 'PICCO', '2', TO_DATE('1996-12-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '122.46', 'Piccolo und mehr', 'Geislweg 14', 'Salzburg', null, '5020', 'Austria');
INSERT INTO "ORDERS" VALUES ('10393', 'SAVEA', '1', TO_DATE('1996-12-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '126.56', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10394', 'HUNGC', '1', TO_DATE('1996-12-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '30.34', 'Hungry Coyote Import Store', 'City Center Plaza 516 Main St.', 'Elgin', 'OR', '97827', 'USA');
INSERT INTO "ORDERS" VALUES ('10395', 'HILAA', '6', TO_DATE('1996-12-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '184.41', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10396', 'FRANK', '1', TO_DATE('1996-12-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '135.35', 'Frankenversand', 'Berliner Platz 43', 'M眉nchen', null, '80805', 'Germany');
INSERT INTO "ORDERS" VALUES ('10397', 'PRINI', '5', TO_DATE('1996-12-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '60.26', 'Princesa Isabel Vinhos', 'Estrada da sa煤de n. 58', 'Lisboa', null, '1756', 'Portugal');
INSERT INTO "ORDERS" VALUES ('10398', 'SAVEA', '2', TO_DATE('1996-12-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '89.16', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10399', 'VAFFE', '8', TO_DATE('1996-12-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '27.36', 'Vaffeljernet', 'Smagsloget 45', '脜rhus', null, '8200', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10400', 'EASTC', '1', TO_DATE('1997-01-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '83.93', 'Eastern Connection', '35 King George', 'London', null, 'WX3 6FW', 'UK');
INSERT INTO "ORDERS" VALUES ('10401', 'RATTC', '1', TO_DATE('1997-01-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '12.51', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');
INSERT INTO "ORDERS" VALUES ('10402', 'ERNSH', '8', TO_DATE('1997-01-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '67.88', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10403', 'ERNSH', '4', TO_DATE('1997-01-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '73.79', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10404', 'MAGAA', '2', TO_DATE('1997-01-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '155.97', 'Magazzini Alimentari Riuniti', 'Via Ludovico il Moro 22', 'Bergamo', null, '24100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10405', 'LINOD', '1', TO_DATE('1997-01-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '34.82', 'LINO-Delicateses', 'Ave. 5 de Mayo Porlamar', 'I. de Margarita', 'Nueva Esparta', '4980', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10406', 'QUEEN', '7', TO_DATE('1997-01-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '108.04', 'Queen Cozinha', 'Alameda dos Can脿rios, 891', 'Sao Paulo', 'SP', '05487-020', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10407', 'OTTIK', '2', TO_DATE('1997-01-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '91.48', 'Ottilies K盲seladen', 'Mehrheimerstr. 369', 'K枚ln', null, '50739', 'Germany');
INSERT INTO "ORDERS" VALUES ('10408', 'FOLIG', '8', TO_DATE('1997-01-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '11.26', 'Folies gourmandes', '184, chauss茅e de Tournai', 'Lille', null, '59000', 'France');
INSERT INTO "ORDERS" VALUES ('10409', 'OCEAN', '3', TO_DATE('1997-01-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '29.83', 'Oc茅ano Atl谩ntico Ltda.', 'Ing. Gustavo Moncada 8585 Piso 20-A', 'Buenos Aires', null, '1010', 'Argentina');
INSERT INTO "ORDERS" VALUES ('10410', 'BOTTM', '3', TO_DATE('1997-01-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '2.40', 'Bottom-Dollar Markets', '23 Tsawassen Blvd.', 'Tsawassen', 'BC', 'T2F 8M4', 'Canada');
INSERT INTO "ORDERS" VALUES ('10411', 'BOTTM', '9', TO_DATE('1997-01-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '23.65', 'Bottom-Dollar Markets', '23 Tsawassen Blvd.', 'Tsawassen', 'BC', 'T2F 8M4', 'Canada');
INSERT INTO "ORDERS" VALUES ('10412', 'WARTH', '8', TO_DATE('1997-01-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '3.77', 'Wartian Herkku', 'Torikatu 38', 'Oulu', null, '90110', 'Finland');
INSERT INTO "ORDERS" VALUES ('10413', 'LAMAI', '3', TO_DATE('1997-01-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '95.66', 'La maison dAsie', '1 rue Alsace-Lorraine', 'Toulouse', null, '31000', 'France');
INSERT INTO "ORDERS" VALUES ('10414', 'FAMIA', '2', TO_DATE('1997-01-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '21.48', 'Familia Arquibaldo', 'Rua Or贸s, 92', 'Sao Paulo', 'SP', '05442-030', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10415', 'HUNGC', '3', TO_DATE('1997-01-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '0.20', 'Hungry Coyote Import Store', 'City Center Plaza 516 Main St.', 'Elgin', 'OR', '97827', 'USA');
INSERT INTO "ORDERS" VALUES ('10416', 'WARTH', '8', TO_DATE('1997-01-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '22.72', 'Wartian Herkku', 'Torikatu 38', 'Oulu', null, '90110', 'Finland');
INSERT INTO "ORDERS" VALUES ('10417', 'SIMOB', '4', TO_DATE('1997-01-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '70.29', 'Simons bistro', 'Vinb忙ltet 34', 'Kobenhavn', null, '1734', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10418', 'QUICK', '4', TO_DATE('1997-01-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '17.55', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10419', 'RICSU', '4', TO_DATE('1997-01-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '137.35', 'Richter Supermarkt', 'Starenweg 5', 'Gen猫ve', null, '1204', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('10420', 'WELLI', '3', TO_DATE('1997-01-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '44.12', 'Wellington Importadora', 'Rua do Mercado, 12', 'Resende', 'SP', '08737-363', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10421', 'QUEDE', '8', TO_DATE('1997-01-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '99.23', 'Que Del铆cia', 'Rua da Panificadora, 12', 'Rio de Janeiro', 'RJ', '02389-673', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10422', 'FRANS', '2', TO_DATE('1997-01-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '3.02', 'Franchi S.p.A.', 'Via Monte Bianco 34', 'Torino', null, '10100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10423', 'GOURL', '6', TO_DATE('1997-01-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '24.50', 'Gourmet Lanchonetes', 'Av. Brasil, 442', 'Campinas', 'SP', '04876-786', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10424', 'MEREP', '7', TO_DATE('1997-01-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-01-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '370.61', 'M猫re Paillarde', '43 rue St. Laurent', 'Montr茅al', 'Qu茅bec', 'H1J 1C3', 'Canada');
INSERT INTO "ORDERS" VALUES ('10425', 'LAMAI', '6', TO_DATE('1997-01-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '7.93', 'La maison dAsie', '1 rue Alsace-Lorraine', 'Toulouse', null, '31000', 'France');
INSERT INTO "ORDERS" VALUES ('10426', 'GALED', '4', TO_DATE('1997-01-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '18.69', 'Galer铆a del gastron贸mo', 'Rambla de Catalu帽a, 23', 'Barcelona', null, '8022', 'Spain');
INSERT INTO "ORDERS" VALUES ('10427', 'PICCO', '4', TO_DATE('1997-01-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '31.29', 'Piccolo und mehr', 'Geislweg 14', 'Salzburg', null, '5020', 'Austria');
INSERT INTO "ORDERS" VALUES ('10428', 'REGGC', '7', TO_DATE('1997-01-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '11.09', 'Reggiani Caseifici', 'Strada Provinciale 124', 'Reggio Emilia', null, '42100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10429', 'HUNGO', '3', TO_DATE('1997-01-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '56.63', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10430', 'ERNSH', '4', TO_DATE('1997-01-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '458.78', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10431', 'BOTTM', '4', TO_DATE('1997-01-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '44.17', 'Bottom-Dollar Markets', '23 Tsawassen Blvd.', 'Tsawassen', 'BC', 'T2F 8M4', 'Canada');
INSERT INTO "ORDERS" VALUES ('10432', 'SPLIR', '3', TO_DATE('1997-01-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '4.34', 'Split Rail Beer 1', 'P.O. Box 555', 'Lander', 'WY', '82520', 'USA');
INSERT INTO "ORDERS" VALUES ('10433', 'PRINI', '3', TO_DATE('1997-02-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '73.83', 'Princesa Isabel Vinhos', 'Estrada da sa煤de n. 58', 'Lisboa', null, '1756', 'Portugal');
INSERT INTO "ORDERS" VALUES ('10434', 'FOLKO', '3', TO_DATE('1997-02-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '17.92', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10435', 'CONSH', '8', TO_DATE('1997-02-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '9.21', 'Consolidated Holdings', 'Berkeley Gardens 12  Brewery', 'London', null, 'WX1 6LT', 'UK');
INSERT INTO "ORDERS" VALUES ('10436', 'BLONP', '3', TO_DATE('1997-02-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '156.66', 'Blondel p猫re et fils', '24, place Kl茅ber', 'Strasbourg', null, '67000', 'France');
INSERT INTO "ORDERS" VALUES ('10437', 'WARTH', '8', TO_DATE('1997-02-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '19.97', 'Wartian Herkku', 'Torikatu 38', 'Oulu', null, '90110', 'Finland');
INSERT INTO "ORDERS" VALUES ('10438', 'TOMSP', '3', TO_DATE('1997-02-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '8.24', 'Toms Spezialit盲ten', 'Luisenstr. 48', 'M眉nster', null, '44087', 'Germany');
INSERT INTO "ORDERS" VALUES ('10439', 'MEREP', '6', TO_DATE('1997-02-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '4.07', 'M猫re Paillarde', '43 rue St. Laurent', 'Montr茅al', 'Qu茅bec', 'H1J 1C3', 'Canada');
INSERT INTO "ORDERS" VALUES ('10440', 'SAVEA', '4', TO_DATE('1997-02-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '86.53', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10441', 'OLDWO', '3', TO_DATE('1997-02-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '73.02', 'Old World Delicatessen', '2743 Bering St.', 'Anchorage', 'AK', '99508', 'USA');
INSERT INTO "ORDERS" VALUES ('10442', 'ERNSH', '3', TO_DATE('1997-02-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '47.94', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10443', 'REGGC', '8', TO_DATE('1997-02-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '13.95', 'Reggiani Caseifici', 'Strada Provinciale 124', 'Reggio Emilia', null, '42100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10444', 'BERGS', '3', TO_DATE('1997-02-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '3.50', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10445', 'BERGS', '3', TO_DATE('1997-02-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '9.30', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10446', 'TOMSP', '6', TO_DATE('1997-02-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '14.68', 'Toms Spezialit盲ten', 'Luisenstr. 48', 'M眉nster', null, '44087', 'Germany');
INSERT INTO "ORDERS" VALUES ('10447', 'RICAR', '4', TO_DATE('1997-02-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '68.66', 'Ricardo Adocicados', 'Av. Copacabana, 267', 'Rio de Janeiro', 'RJ', '02389-890', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10448', 'RANCH', '4', TO_DATE('1997-02-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '38.82', 'Rancho grande', 'Av. del Libertador 900', 'Buenos Aires', null, '1010', 'Argentina');
INSERT INTO "ORDERS" VALUES ('10449', 'BLONP', '3', TO_DATE('1997-02-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '53.30', 'Blondel p猫re et fils', '24, place Kl茅ber', 'Strasbourg', null, '67000', 'France');
INSERT INTO "ORDERS" VALUES ('10450', 'VICTE', '8', TO_DATE('1997-02-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '7.23', 'Victuailles en stock', '2, rue du Commerce', 'Lyon', null, '69004', 'France');
INSERT INTO "ORDERS" VALUES ('10451', 'QUICK', '4', TO_DATE('1997-02-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '189.09', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10452', 'SAVEA', '8', TO_DATE('1997-02-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '140.26', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10453', 'AROUT', '1', TO_DATE('1997-02-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '25.36', 'Around the Horn', 'Brook Farm Stratford St. Mary', 'Colchester', 'Essex', 'CO7 6JX', 'UK');
INSERT INTO "ORDERS" VALUES ('10454', 'LAMAI', '4', TO_DATE('1997-02-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '2.74', 'La maison dAsie', '1 rue Alsace-Lorraine', 'Toulouse', null, '31000', 'France');
INSERT INTO "ORDERS" VALUES ('10455', 'WARTH', '8', TO_DATE('1997-02-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '180.45', 'Wartian Herkku', 'Torikatu 38', 'Oulu', null, '90110', 'Finland');
INSERT INTO "ORDERS" VALUES ('10456', 'KOENE', '8', TO_DATE('1997-02-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '8.12', 'K枚niglich Essen', 'Maubelstr. 90', 'Brandenburg', null, '14776', 'Germany');
INSERT INTO "ORDERS" VALUES ('10457', 'KOENE', '2', TO_DATE('1997-02-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '11.57', 'K枚niglich Essen', 'Maubelstr. 90', 'Brandenburg', null, '14776', 'Germany');
INSERT INTO "ORDERS" VALUES ('10458', 'SUPRD', '7', TO_DATE('1997-02-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '147.06', 'Supr锚mes d茅lices', 'Boulevard Tirou, 255', 'Charleroi', null, 'B-6000', 'Belgium');
INSERT INTO "ORDERS" VALUES ('10459', 'VICTE', '4', TO_DATE('1997-02-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-02-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '25.09', 'Victuailles en stock', '2, rue du Commerce', 'Lyon', null, '69004', 'France');
INSERT INTO "ORDERS" VALUES ('10460', 'FOLKO', '8', TO_DATE('1997-02-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '16.27', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10461', 'LILAS', '1', TO_DATE('1997-02-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '148.61', 'LILA-Supermercado', 'Carrera 52 con Ave. Bol铆var #65-98 Llano Largo', 'Barquisimeto', 'Lara', '3508', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10462', 'CONSH', '2', TO_DATE('1997-03-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '6.17', 'Consolidated Holdings', 'Berkeley Gardens 12  Brewery', 'London', null, 'WX1 6LT', 'UK');
INSERT INTO "ORDERS" VALUES ('10463', 'SUPRD', '5', TO_DATE('1997-03-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '14.78', 'Supr锚mes d茅lices', 'Boulevard Tirou, 255', 'Charleroi', null, 'B-6000', 'Belgium');
INSERT INTO "ORDERS" VALUES ('10464', 'FURIB', '4', TO_DATE('1997-03-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '89', 'Furia Bacalhau e Frutos do Mar', 'Jardim das rosas n. 32', 'Lisboa', null, '1675', 'Portugal');
INSERT INTO "ORDERS" VALUES ('10465', 'VAFFE', '1', TO_DATE('1997-03-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '145.04', 'Vaffeljernet', 'Smagsloget 45', '脜rhus', null, '8200', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10466', 'COMMI', '4', TO_DATE('1997-03-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '11.93', 'Com茅rcio Mineiro', 'Av. dos Lus铆adas, 23', 'Sao Paulo', 'SP', '05432-043', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10467', 'MAGAA', '8', TO_DATE('1997-03-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '4.93', 'Magazzini Alimentari Riuniti', 'Via Ludovico il Moro 22', 'Bergamo', null, '24100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10468', 'KOENE', '3', TO_DATE('1997-03-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '44.12', 'K枚niglich Essen', 'Maubelstr. 90', 'Brandenburg', null, '14776', 'Germany');
INSERT INTO "ORDERS" VALUES ('10469', 'WHITC', '1', TO_DATE('1997-03-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '60.18', 'White Clover Markets', '1029 - 12th Ave. S.', 'Seattle', 'WA', '98124', 'USA');
INSERT INTO "ORDERS" VALUES ('10470', 'BONAP', '4', TO_DATE('1997-03-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '64.56', 'Bon app', '12, rue des Bouchers', 'Marseille', null, '13008', 'France');
INSERT INTO "ORDERS" VALUES ('10471', 'BSBEV', '2', TO_DATE('1997-03-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '45.59', 'Bs Beverages', 'Fauntleroy Circus', 'London', null, 'EC2 5NT', 'UK');
INSERT INTO "ORDERS" VALUES ('10472', 'SEVES', '8', TO_DATE('1997-03-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '4.20', 'Seven Seas Imports', '90 Wadhurst Rd.', 'London', null, 'OX15 4NB', 'UK');
INSERT INTO "ORDERS" VALUES ('10473', 'ISLAT', '1', TO_DATE('1997-03-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '16.37', 'Island Trading', 'Garden House Crowther Way', 'Cowes', 'Isle of Wight', 'PO31 7PJ', 'UK');
INSERT INTO "ORDERS" VALUES ('10474', 'PERIC', '5', TO_DATE('1997-03-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '83.49', 'Pericles Comidas cl谩sicas', 'Calle Dr. Jorge Cash 321', 'M茅xico D.F.', null, '05033', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10475', 'SUPRD', '9', TO_DATE('1997-03-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '68.52', 'Supr锚mes d茅lices', 'Boulevard Tirou, 255', 'Charleroi', null, 'B-6000', 'Belgium');
INSERT INTO "ORDERS" VALUES ('10476', 'HILAA', '8', TO_DATE('1997-03-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '4.41', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10477', 'PRINI', '5', TO_DATE('1997-03-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '13.02', 'Princesa Isabel Vinhos', 'Estrada da sa煤de n. 58', 'Lisboa', null, '1756', 'Portugal');
INSERT INTO "ORDERS" VALUES ('10478', 'VICTE', '2', TO_DATE('1997-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '4.81', 'Victuailles en stock', '2, rue du Commerce', 'Lyon', null, '69004', 'France');
INSERT INTO "ORDERS" VALUES ('10479', 'RATTC', '3', TO_DATE('1997-03-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '708.95', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');
INSERT INTO "ORDERS" VALUES ('10480', 'FOLIG', '6', TO_DATE('1997-03-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '1.35', 'Folies gourmandes', '184, chauss茅e de Tournai', 'Lille', null, '59000', 'France');
INSERT INTO "ORDERS" VALUES ('10481', 'RICAR', '8', TO_DATE('1997-03-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '64.33', 'Ricardo Adocicados', 'Av. Copacabana, 267', 'Rio de Janeiro', 'RJ', '02389-890', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10482', 'LAZYK', '1', TO_DATE('1997-03-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '7.48', 'Lazy K Kountry Store', '12 Orchestra Terrace', 'Walla Walla', 'WA', '99362', 'USA');
INSERT INTO "ORDERS" VALUES ('10483', 'WHITC', '7', TO_DATE('1997-03-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '15.28', 'White Clover Markets', '1029 - 12th Ave. S.', 'Seattle', 'WA', '98124', 'USA');
INSERT INTO "ORDERS" VALUES ('10484', 'BSBEV', '3', TO_DATE('1997-03-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '6.88', 'Bs Beverages', 'Fauntleroy Circus', 'London', null, 'EC2 5NT', 'UK');
INSERT INTO "ORDERS" VALUES ('10485', 'LINOD', '4', TO_DATE('1997-03-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '64.45', 'LINO-Delicateses', 'Ave. 5 de Mayo Porlamar', 'I. de Margarita', 'Nueva Esparta', '4980', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10486', 'HILAA', '1', TO_DATE('1997-03-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '30.53', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10487', 'QUEEN', '2', TO_DATE('1997-03-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-03-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '71.07', 'Queen Cozinha', 'Alameda dos Can脿rios, 891', 'Sao Paulo', 'SP', '05487-020', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10488', 'FRANK', '8', TO_DATE('1997-03-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '4.93', 'Frankenversand', 'Berliner Platz 43', 'M眉nchen', null, '80805', 'Germany');
INSERT INTO "ORDERS" VALUES ('10489', 'PICCO', '6', TO_DATE('1997-03-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '5.29', 'Piccolo und mehr', 'Geislweg 14', 'Salzburg', null, '5020', 'Austria');
INSERT INTO "ORDERS" VALUES ('10490', 'HILAA', '7', TO_DATE('1997-03-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '210.19', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10491', 'FURIB', '8', TO_DATE('1997-03-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '16.96', 'Furia Bacalhau e Frutos do Mar', 'Jardim das rosas n. 32', 'Lisboa', null, '1675', 'Portugal');
INSERT INTO "ORDERS" VALUES ('10492', 'BOTTM', '3', TO_DATE('1997-04-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '62.89', 'Bottom-Dollar Markets', '23 Tsawassen Blvd.', 'Tsawassen', 'BC', 'T2F 8M4', 'Canada');
INSERT INTO "ORDERS" VALUES ('10493', 'LAMAI', '4', TO_DATE('1997-04-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '10.64', 'La maison dAsie', '1 rue Alsace-Lorraine', 'Toulouse', null, '31000', 'France');
INSERT INTO "ORDERS" VALUES ('10494', 'COMMI', '4', TO_DATE('1997-04-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '65.99', 'Com茅rcio Mineiro', 'Av. dos Lus铆adas, 23', 'Sao Paulo', 'SP', '05432-043', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10495', 'LAUGB', '3', TO_DATE('1997-04-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '4.65', 'Laughing Bacchus Wine Cellars', '2319 Elm St.', 'Vancouver', 'BC', 'V3F 2K1', 'Canada');
INSERT INTO "ORDERS" VALUES ('10496', 'TRADH', '7', TO_DATE('1997-04-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '46.77', 'Tradi莽ao Hipermercados', 'Av. In锚s de Castro, 414', 'Sao Paulo', 'SP', '05634-030', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10497', 'LEHMS', '7', TO_DATE('1997-04-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '36.21', 'Lehmanns Marktstand', 'Magazinweg 7', 'Frankfurt a.M.', null, '60528', 'Germany');
INSERT INTO "ORDERS" VALUES ('10498', 'HILAA', '8', TO_DATE('1997-04-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '29.75', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10499', 'LILAS', '4', TO_DATE('1997-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '102.02', 'LILA-Supermercado', 'Carrera 52 con Ave. Bol铆var #65-98 Llano Largo', 'Barquisimeto', 'Lara', '3508', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10500', 'LAMAI', '6', TO_DATE('1997-04-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '42.68', 'La maison dAsie', '1 rue Alsace-Lorraine', 'Toulouse', null, '31000', 'France');
INSERT INTO "ORDERS" VALUES ('10501', 'BLAUS', '9', TO_DATE('1997-04-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-05-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-04-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '8.85', 'Blauer See Delikatessen', 'Forsterstr. 57', 'Mannheim', null, '68306', 'Germany');
INSERT INTO "ORDERS" VALUES ('10248', 'VINET', '5', TO_DATE('1996-07-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '32.38', 'Vins et alcools Chevalier', '59 rue de lAbbaye', 'Reims', null, '51100', 'France');
INSERT INTO "ORDERS" VALUES ('10249', 'TOMSP', '6', TO_DATE('1996-07-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '11.61', 'Toms Spezialit盲ten', 'Luisenstr. 48', 'M眉nster', null, '44087', 'Germany');
INSERT INTO "ORDERS" VALUES ('10250', 'HANAR', '4', TO_DATE('1996-07-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '65.83', 'Hanari Carnes', 'Rua do Pa莽o, 67', 'Rio de Janeiro', 'RJ', '05454-876', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10251', 'VICTE', '3', TO_DATE('1996-07-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '41.34', 'Victuailles en stock', '2, rue du Commerce', 'Lyon', null, '69004', 'France');
INSERT INTO "ORDERS" VALUES ('10252', 'SUPRD', '4', TO_DATE('1996-07-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '51.30', 'Supr锚mes d茅lices', 'Boulevard Tirou, 255', 'Charleroi', null, 'B-6000', 'Belgium');
INSERT INTO "ORDERS" VALUES ('10253', 'HANAR', '3', TO_DATE('1996-07-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '58.17', 'Hanari Carnes', 'Rua do Pa莽o, 67', 'Rio de Janeiro', 'RJ', '05454-876', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10254', 'CHOPS', '5', TO_DATE('1996-07-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '22.98', 'Chop-suey Chinese', 'Hauptstr. 31', 'Bern', null, '3012', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('10255', 'RICSU', '9', TO_DATE('1996-07-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '148.33', 'Richter Supermarkt', 'Starenweg 5', 'Gen猫ve', null, '1204', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('10256', 'WELLI', '3', TO_DATE('1996-07-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '13.97', 'Wellington Importadora', 'Rua do Mercado, 12', 'Resende', 'SP', '08737-363', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10257', 'HILAA', '4', TO_DATE('1996-07-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '81.91', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10258', 'ERNSH', '1', TO_DATE('1996-07-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '140.51', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10259', 'CENTC', '4', TO_DATE('1996-07-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '3.25', 'Centro comercial Moctezuma', 'Sierras de Granada 9993', 'M茅xico D.F.', null, '05022', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10260', 'OTTIK', '4', TO_DATE('1996-07-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '55.09', 'Ottilies K盲seladen', 'Mehrheimerstr. 369', 'K枚ln', null, '50739', 'Germany');
INSERT INTO "ORDERS" VALUES ('10261', 'QUEDE', '4', TO_DATE('1996-07-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '3.05', 'Que Del铆cia', 'Rua da Panificadora, 12', 'Rio de Janeiro', 'RJ', '02389-673', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10262', 'RATTC', '8', TO_DATE('1996-07-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '48.29', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');
INSERT INTO "ORDERS" VALUES ('10263', 'ERNSH', '9', TO_DATE('1996-07-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '146.06', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10264', 'FOLKO', '6', TO_DATE('1996-07-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '3.67', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10265', 'BLONP', '2', TO_DATE('1996-07-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '55.28', 'Blondel p猫re et fils', '24, place Kl茅ber', 'Strasbourg', null, '67000', 'France');
INSERT INTO "ORDERS" VALUES ('10266', 'WARTH', '3', TO_DATE('1996-07-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-07-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '25.73', 'Wartian Herkku', 'Torikatu 38', 'Oulu', null, '90110', 'Finland');
INSERT INTO "ORDERS" VALUES ('10267', 'FRANK', '4', TO_DATE('1996-07-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '208.58', 'Frankenversand', 'Berliner Platz 43', 'M眉nchen', null, '80805', 'Germany');
INSERT INTO "ORDERS" VALUES ('10268', 'GROSR', '8', TO_DATE('1996-07-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '66.29', 'GROSELLA-Restaurante', '5陋 Ave. Los Palos Grandes', 'Caracas', 'DF', '1081', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10269', 'WHITC', '5', TO_DATE('1996-07-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '4.56', 'White Clover Markets', '1029 - 12th Ave. S.', 'Seattle', 'WA', '98124', 'USA');
INSERT INTO "ORDERS" VALUES ('10270', 'WARTH', '1', TO_DATE('1996-08-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '136.54', 'Wartian Herkku', 'Torikatu 38', 'Oulu', null, '90110', 'Finland');
INSERT INTO "ORDERS" VALUES ('10271', 'SPLIR', '6', TO_DATE('1996-08-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '4.54', 'Split Rail Beer 1', 'P.O. Box 555', 'Lander', 'WY', '82520', 'USA');
INSERT INTO "ORDERS" VALUES ('10272', 'RATTC', '6', TO_DATE('1996-08-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '98.03', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');
INSERT INTO "ORDERS" VALUES ('10273', 'QUICK', '3', TO_DATE('1996-08-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '76.07', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10274', 'VINET', '6', TO_DATE('1996-08-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '6.01', 'Vins et alcools Chevalier', '59 rue de lAbbaye', 'Reims', null, '51100', 'France');
INSERT INTO "ORDERS" VALUES ('10275', 'MAGAA', '1', TO_DATE('1996-08-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '26.93', 'Magazzini Alimentari Riuniti', 'Via Ludovico il Moro 22', 'Bergamo', null, '24100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10276', 'TORTU', '8', TO_DATE('1996-08-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '13.84', 'Tortuga Restaurante', 'Avda. Azteca 123', 'M茅xico D.F.', null, '05033', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10277', 'MORGK', '2', TO_DATE('1996-08-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '125.77', 'Morgenstern Gesundkost', 'Heerstr. 22', 'Leipzig', null, '04179', 'Germany');
INSERT INTO "ORDERS" VALUES ('10278', 'BERGS', '8', TO_DATE('1996-08-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '92.69', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10279', 'LEHMS', '8', TO_DATE('1996-08-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '25.83', 'Lehmanns Marktstand', 'Magazinweg 7', 'Frankfurt a.M.', null, '60528', 'Germany');
INSERT INTO "ORDERS" VALUES ('10280', 'BERGS', '2', TO_DATE('1996-08-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '8.98', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10281', 'ROMEY', '4', TO_DATE('1996-08-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '2.94', 'Romero y tomillo', 'Gran V铆a, 1', 'Madrid', null, '28001', 'Spain');
INSERT INTO "ORDERS" VALUES ('10282', 'ROMEY', '4', TO_DATE('1996-08-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '12.69', 'Romero y tomillo', 'Gran V铆a, 1', 'Madrid', null, '28001', 'Spain');
INSERT INTO "ORDERS" VALUES ('10283', 'LILAS', '3', TO_DATE('1996-08-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '84.81', 'LILA-Supermercado', 'Carrera 52 con Ave. Bol铆var #65-98 Llano Largo', 'Barquisimeto', 'Lara', '3508', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10284', 'LEHMS', '4', TO_DATE('1996-08-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '76.56', 'Lehmanns Marktstand', 'Magazinweg 7', 'Frankfurt a.M.', null, '60528', 'Germany');
INSERT INTO "ORDERS" VALUES ('10285', 'QUICK', '1', TO_DATE('1996-08-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '76.83', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10286', 'QUICK', '8', TO_DATE('1996-08-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '229.24', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10287', 'RICAR', '8', TO_DATE('1996-08-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '12.76', 'Ricardo Adocicados', 'Av. Copacabana, 267', 'Rio de Janeiro', 'RJ', '02389-890', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10288', 'REGGC', '4', TO_DATE('1996-08-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '7.45', 'Reggiani Caseifici', 'Strada Provinciale 124', 'Reggio Emilia', null, '42100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10289', 'BSBEV', '7', TO_DATE('1996-08-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-08-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '22.77', 'Bs Beverages', 'Fauntleroy Circus', 'London', null, 'EC2 5NT', 'UK');
INSERT INTO "ORDERS" VALUES ('10290', 'COMMI', '8', TO_DATE('1996-08-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '79.70', 'Com茅rcio Mineiro', 'Av. dos Lus铆adas, 23', 'Sao Paulo', 'SP', '05432-043', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10291', 'QUEDE', '6', TO_DATE('1996-08-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '6.40', 'Que Del铆cia', 'Rua da Panificadora, 12', 'Rio de Janeiro', 'RJ', '02389-673', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10292', 'TRADH', '1', TO_DATE('1996-08-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '1.35', 'Tradi莽ao Hipermercados', 'Av. In锚s de Castro, 414', 'Sao Paulo', 'SP', '05634-030', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10293', 'TORTU', '1', TO_DATE('1996-08-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '21.18', 'Tortuga Restaurante', 'Avda. Azteca 123', 'M茅xico D.F.', null, '05033', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10294', 'RATTC', '4', TO_DATE('1996-08-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '147.26', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');
INSERT INTO "ORDERS" VALUES ('10295', 'VINET', '2', TO_DATE('1996-09-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '1.15', 'Vins et alcools Chevalier', '59 rue de lAbbaye', 'Reims', null, '51100', 'France');
INSERT INTO "ORDERS" VALUES ('10296', 'LILAS', '6', TO_DATE('1996-09-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '0.12', 'LILA-Supermercado', 'Carrera 52 con Ave. Bol铆var #65-98 Llano Largo', 'Barquisimeto', 'Lara', '3508', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10297', 'BLONP', '5', TO_DATE('1996-09-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '5.74', 'Blondel p猫re et fils', '24, place Kl茅ber', 'Strasbourg', null, '67000', 'France');
INSERT INTO "ORDERS" VALUES ('10298', 'HUNGO', '6', TO_DATE('1996-09-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '168.22', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10299', 'RICAR', '4', TO_DATE('1996-09-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '29.76', 'Ricardo Adocicados', 'Av. Copacabana, 267', 'Rio de Janeiro', 'RJ', '02389-890', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10300', 'MAGAA', '2', TO_DATE('1996-09-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '17.68', 'Magazzini Alimentari Riuniti', 'Via Ludovico il Moro 22', 'Bergamo', null, '24100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10301', 'WANDK', '8', TO_DATE('1996-09-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '45.08', 'Die Wandernde Kuh', 'Adenauerallee 900', 'Stuttgart', null, '70563', 'Germany');
INSERT INTO "ORDERS" VALUES ('10302', 'SUPRD', '4', TO_DATE('1996-09-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '6.27', 'Supr锚mes d茅lices', 'Boulevard Tirou, 255', 'Charleroi', null, 'B-6000', 'Belgium');
INSERT INTO "ORDERS" VALUES ('10303', 'GODOS', '7', TO_DATE('1996-09-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '107.83', 'Godos Cocina T铆pica', 'C/ Romero, 33', 'Sevilla', null, '41101', 'Spain');
INSERT INTO "ORDERS" VALUES ('10304', 'TORTU', '1', TO_DATE('1996-09-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '63.79', 'Tortuga Restaurante', 'Avda. Azteca 123', 'M茅xico D.F.', null, '05033', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10305', 'OLDWO', '8', TO_DATE('1996-09-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '257.62', 'Old World Delicatessen', '2743 Bering St.', 'Anchorage', 'AK', '99508', 'USA');
INSERT INTO "ORDERS" VALUES ('10306', 'ROMEY', '1', TO_DATE('1996-09-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '7.56', 'Romero y tomillo', 'Gran V铆a, 1', 'Madrid', null, '28001', 'Spain');
INSERT INTO "ORDERS" VALUES ('10307', 'LONEP', '2', TO_DATE('1996-09-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '0.56', 'Lonesome Pine Restaurant', '89 Chiaroscuro Rd.', 'Portland', 'OR', '97219', 'USA');
INSERT INTO "ORDERS" VALUES ('10308', 'ANATR', '7', TO_DATE('1996-09-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '1.61', 'Ana Trujillo Emparedados y helados', 'Avda. de la Constituci贸n 2222', 'M茅xico D.F.', null, '05021', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10309', 'HUNGO', '3', TO_DATE('1996-09-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '47.30', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10310', 'THEBI', '8', TO_DATE('1996-09-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-10-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1996-09-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '17.52', 'The Big Cheese', '89 Jefferson Way Suite 2', 'Portland', 'OR', '97201', 'USA');
INSERT INTO "ORDERS" VALUES ('10757', 'SAVEA', '6', TO_DATE('1997-11-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '8.19', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10758', 'RICSU', '3', TO_DATE('1997-11-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '138.17', 'Richter Supermarkt', 'Starenweg 5', 'Gen猫ve', null, '1204', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('10759', 'ANATR', '3', TO_DATE('1997-11-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '11.99', 'Ana Trujillo Emparedados y helados', 'Avda. de la Constituci贸n 2222', 'M茅xico D.F.', null, '05021', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10760', 'MAISD', '4', TO_DATE('1997-12-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '155.64', 'Maison Dewey', 'Rue Joseph-Bens 532', 'Bruxelles', null, 'B-1180', 'Belgium');
INSERT INTO "ORDERS" VALUES ('10761', 'RATTC', '5', TO_DATE('1997-12-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '18.66', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');
INSERT INTO "ORDERS" VALUES ('10762', 'FOLKO', '3', TO_DATE('1997-12-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '328.74', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10763', 'FOLIG', '3', TO_DATE('1997-12-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '37.35', 'Folies gourmandes', '184, chauss茅e de Tournai', 'Lille', null, '59000', 'France');
INSERT INTO "ORDERS" VALUES ('10764', 'ERNSH', '6', TO_DATE('1997-12-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '145.45', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10765', 'QUICK', '3', TO_DATE('1997-12-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '42.74', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10766', 'OTTIK', '4', TO_DATE('1997-12-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '157.55', 'Ottilies K盲seladen', 'Mehrheimerstr. 369', 'K枚ln', null, '50739', 'Germany');
INSERT INTO "ORDERS" VALUES ('10767', 'SUPRD', '4', TO_DATE('1997-12-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '1.59', 'Supr锚mes d茅lices', 'Boulevard Tirou, 255', 'Charleroi', null, 'B-6000', 'Belgium');
INSERT INTO "ORDERS" VALUES ('10768', 'AROUT', '3', TO_DATE('1997-12-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '146.32', 'Around the Horn', 'Brook Farm Stratford St. Mary', 'Colchester', 'Essex', 'CO7 6JX', 'UK');
INSERT INTO "ORDERS" VALUES ('10769', 'VAFFE', '3', TO_DATE('1997-12-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '65.06', 'Vaffeljernet', 'Smagsloget 45', '脜rhus', null, '8200', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10770', 'HANAR', '8', TO_DATE('1997-12-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '5.32', 'Hanari Carnes', 'Rua do Pa莽o, 67', 'Rio de Janeiro', 'RJ', '05454-876', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10771', 'ERNSH', '9', TO_DATE('1997-12-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '11.19', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10772', 'LEHMS', '3', TO_DATE('1997-12-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '91.28', 'Lehmanns Marktstand', 'Magazinweg 7', 'Frankfurt a.M.', null, '60528', 'Germany');
INSERT INTO "ORDERS" VALUES ('10773', 'ERNSH', '1', TO_DATE('1997-12-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '96.43', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10774', 'FOLKO', '4', TO_DATE('1997-12-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '48.20', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10775', 'THECR', '7', TO_DATE('1997-12-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '20.25', 'The Cracker Box', '55 Grizzly Peak Rd.', 'Butte', 'MT', '59801', 'USA');
INSERT INTO "ORDERS" VALUES ('10776', 'ERNSH', '1', TO_DATE('1997-12-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '351.53', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10777', 'GOURL', '7', TO_DATE('1997-12-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '3.01', 'Gourmet Lanchonetes', 'Av. Brasil, 442', 'Campinas', 'SP', '04876-786', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10778', 'BERGS', '3', TO_DATE('1997-12-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '6.79', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10779', 'MORGK', '3', TO_DATE('1997-12-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '58.13', 'Morgenstern Gesundkost', 'Heerstr. 22', 'Leipzig', null, '04179', 'Germany');
INSERT INTO "ORDERS" VALUES ('10780', 'LILAS', '2', TO_DATE('1997-12-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '42.13', 'LILA-Supermercado', 'Carrera 52 con Ave. Bol铆var #65-98 Llano Largo', 'Barquisimeto', 'Lara', '3508', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10781', 'WARTH', '2', TO_DATE('1997-12-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '73.16', 'Wartian Herkku', 'Torikatu 38', 'Oulu', null, '90110', 'Finland');
INSERT INTO "ORDERS" VALUES ('10782', 'CACTU', '9', TO_DATE('1997-12-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '1.10', 'Cactus Comidas para llevar', 'Cerrito 333', 'Buenos Aires', null, '1010', 'Argentina');
INSERT INTO "ORDERS" VALUES ('10783', 'HANAR', '4', TO_DATE('1997-12-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '124.98', 'Hanari Carnes', 'Rua do Pa莽o, 67', 'Rio de Janeiro', 'RJ', '05454-876', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10784', 'MAGAA', '4', TO_DATE('1997-12-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '70.09', 'Magazzini Alimentari Riuniti', 'Via Ludovico il Moro 22', 'Bergamo', null, '24100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10785', 'GROSR', '1', TO_DATE('1997-12-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '1.51', 'GROSELLA-Restaurante', '5陋 Ave. Los Palos Grandes', 'Caracas', 'DF', '1081', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10786', 'QUEEN', '8', TO_DATE('1997-12-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '110.87', 'Queen Cozinha', 'Alameda dos Can脿rios, 891', 'Sao Paulo', 'SP', '05487-020', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10787', 'LAMAI', '2', TO_DATE('1997-12-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '249.93', 'La maison dAsie', '1 rue Alsace-Lorraine', 'Toulouse', null, '31000', 'France');
INSERT INTO "ORDERS" VALUES ('10788', 'QUICK', '1', TO_DATE('1997-12-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '42.70', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10789', 'FOLIG', '1', TO_DATE('1997-12-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '100.60', 'Folies gourmandes', '184, chauss茅e de Tournai', 'Lille', null, '59000', 'France');
INSERT INTO "ORDERS" VALUES ('10790', 'GOURL', '6', TO_DATE('1997-12-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '28.23', 'Gourmet Lanchonetes', 'Av. Brasil, 442', 'Campinas', 'SP', '04876-786', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10791', 'FRANK', '6', TO_DATE('1997-12-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '16.85', 'Frankenversand', 'Berliner Platz 43', 'M眉nchen', null, '80805', 'Germany');
INSERT INTO "ORDERS" VALUES ('10792', 'WOLZA', '1', TO_DATE('1997-12-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '23.79', 'Wolski Zajazd', 'ul. Filtrowa 68', 'Warszawa', null, '01-012', 'Poland');
INSERT INTO "ORDERS" VALUES ('10793', 'AROUT', '3', TO_DATE('1997-12-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '4.52', 'Around the Horn', 'Brook Farm Stratford St. Mary', 'Colchester', 'Essex', 'CO7 6JX', 'UK');
INSERT INTO "ORDERS" VALUES ('10794', 'QUEDE', '6', TO_DATE('1997-12-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '21.49', 'Que Del铆cia', 'Rua da Panificadora, 12', 'Rio de Janeiro', 'RJ', '02389-673', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10795', 'ERNSH', '8', TO_DATE('1997-12-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '126.66', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10796', 'HILAA', '3', TO_DATE('1997-12-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '26.52', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10797', 'DRACD', '7', TO_DATE('1997-12-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '33.35', 'Drachenblut Delikatessen', 'Walserweg 21', 'Aachen', null, '52066', 'Germany');
INSERT INTO "ORDERS" VALUES ('10798', 'ISLAT', '2', TO_DATE('1997-12-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '2.33', 'Island Trading', 'Garden House Crowther Way', 'Cowes', 'Isle of Wight', 'PO31 7PJ', 'UK');
INSERT INTO "ORDERS" VALUES ('10799', 'KOENE', '9', TO_DATE('1997-12-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '30.76', 'K枚niglich Essen', 'Maubelstr. 90', 'Brandenburg', null, '14776', 'Germany');
INSERT INTO "ORDERS" VALUES ('10800', 'SEVES', '1', TO_DATE('1997-12-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '137.44', 'Seven Seas Imports', '90 Wadhurst Rd.', 'London', null, 'OX15 4NB', 'UK');
INSERT INTO "ORDERS" VALUES ('10801', 'BOLID', '4', TO_DATE('1997-12-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '97.09', 'B贸lido Comidas preparadas', 'C/ Araquil, 67', 'Madrid', null, '28023', 'Spain');
INSERT INTO "ORDERS" VALUES ('10802', 'SIMOB', '4', TO_DATE('1997-12-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '257.26', 'Simons bistro', 'Vinb忙ltet 34', 'Kobenhavn', null, '1734', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10803', 'WELLI', '4', TO_DATE('1997-12-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '55.23', 'Wellington Importadora', 'Rua do Mercado, 12', 'Resende', 'SP', '08737-363', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10804', 'SEVES', '6', TO_DATE('1997-12-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '27.33', 'Seven Seas Imports', '90 Wadhurst Rd.', 'London', null, 'OX15 4NB', 'UK');
INSERT INTO "ORDERS" VALUES ('10805', 'THEBI', '2', TO_DATE('1997-12-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '237.34', 'The Big Cheese', '89 Jefferson Way Suite 2', 'Portland', 'OR', '97201', 'USA');
INSERT INTO "ORDERS" VALUES ('10806', 'VICTE', '3', TO_DATE('1997-12-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '22.11', 'Victuailles en stock', '2, rue du Commerce', 'Lyon', null, '69004', 'France');
INSERT INTO "ORDERS" VALUES ('10807', 'FRANS', '4', TO_DATE('1997-12-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '1.36', 'Franchi S.p.A.', 'Via Monte Bianco 34', 'Torino', null, '10100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10808', 'OLDWO', '2', TO_DATE('1998-01-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '45.53', 'Old World Delicatessen', '2743 Bering St.', 'Anchorage', 'AK', '99508', 'USA');
INSERT INTO "ORDERS" VALUES ('10809', 'WELLI', '7', TO_DATE('1998-01-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '4.87', 'Wellington Importadora', 'Rua do Mercado, 12', 'Resende', 'SP', '08737-363', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10810', 'LAUGB', '2', TO_DATE('1998-01-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '4.33', 'Laughing Bacchus Wine Cellars', '2319 Elm St.', 'Vancouver', 'BC', 'V3F 2K1', 'Canada');
INSERT INTO "ORDERS" VALUES ('10811', 'LINOD', '8', TO_DATE('1998-01-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '31.22', 'LINO-Delicateses', 'Ave. 5 de Mayo Porlamar', 'I. de Margarita', 'Nueva Esparta', '4980', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10812', 'REGGC', '5', TO_DATE('1998-01-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '59.78', 'Reggiani Caseifici', 'Strada Provinciale 124', 'Reggio Emilia', null, '42100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10813', 'RICAR', '1', TO_DATE('1998-01-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '47.38', 'Ricardo Adocicados', 'Av. Copacabana, 267', 'Rio de Janeiro', 'RJ', '02389-890', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10814', 'VICTE', '3', TO_DATE('1998-01-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '130.94', 'Victuailles en stock', '2, rue du Commerce', 'Lyon', null, '69004', 'France');
INSERT INTO "ORDERS" VALUES ('10815', 'SAVEA', '2', TO_DATE('1998-01-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '14.62', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10816', 'GREAL', '4', TO_DATE('1998-01-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '719.78', 'Great Lakes Food Market', '2732 Baker Blvd.', 'Eugene', 'OR', '97403', 'USA');
INSERT INTO "ORDERS" VALUES ('10817', 'KOENE', '3', TO_DATE('1998-01-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '306.07', 'K枚niglich Essen', 'Maubelstr. 90', 'Brandenburg', null, '14776', 'Germany');
INSERT INTO "ORDERS" VALUES ('10818', 'MAGAA', '7', TO_DATE('1998-01-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '65.48', 'Magazzini Alimentari Riuniti', 'Via Ludovico il Moro 22', 'Bergamo', null, '24100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10819', 'CACTU', '2', TO_DATE('1998-01-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '19.76', 'Cactus Comidas para llevar', 'Cerrito 333', 'Buenos Aires', null, '1010', 'Argentina');
INSERT INTO "ORDERS" VALUES ('10820', 'RATTC', '3', TO_DATE('1998-01-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '37.52', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');
INSERT INTO "ORDERS" VALUES ('10821', 'SPLIR', '1', TO_DATE('1998-01-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '36.68', 'Split Rail Beer 1', 'P.O. Box 555', 'Lander', 'WY', '82520', 'USA');
INSERT INTO "ORDERS" VALUES ('11011', 'ALFKI', '3', TO_DATE('1998-04-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '1.21', 'Alfreds Futterkiste', 'Obere Str. 57', 'Berlin', null, '12209', 'Germany');
INSERT INTO "ORDERS" VALUES ('11012', 'FRANK', '1', TO_DATE('1998-04-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '242.95', 'Frankenversand', 'Berliner Platz 43', 'M眉nchen', null, '80805', 'Germany');
INSERT INTO "ORDERS" VALUES ('11013', 'ROMEY', '2', TO_DATE('1998-04-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '32.99', 'Romero y tomillo', 'Gran V铆a, 1', 'Madrid', null, '28001', 'Spain');
INSERT INTO "ORDERS" VALUES ('11014', 'LINOD', '2', TO_DATE('1998-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '23.60', 'LINO-Delicateses', 'Ave. 5 de Mayo Porlamar', 'I. de Margarita', 'Nueva Esparta', '4980', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('11015', 'SANTG', '2', TO_DATE('1998-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '4.62', 'Sant茅 Gourmet', 'Erling Skakkes gate 78', 'Stavern', null, '4110', 'Norway');
INSERT INTO "ORDERS" VALUES ('11016', 'AROUT', '9', TO_DATE('1998-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '33.80', 'Around the Horn', 'Brook Farm Stratford St. Mary', 'Colchester', 'Essex', 'CO7 6JX', 'UK');
INSERT INTO "ORDERS" VALUES ('11017', 'ERNSH', '9', TO_DATE('1998-04-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '754.26', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('11018', 'LONEP', '4', TO_DATE('1998-04-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '11.65', 'Lonesome Pine Restaurant', '89 Chiaroscuro Rd.', 'Portland', 'OR', '97219', 'USA');
INSERT INTO "ORDERS" VALUES ('11019', 'RANCH', '6', TO_DATE('1998-04-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '3', '3.17', 'Rancho grande', 'Av. del Libertador 900', 'Buenos Aires', null, '1010', 'Argentina');
INSERT INTO "ORDERS" VALUES ('11020', 'OTTIK', '2', TO_DATE('1998-04-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '43.30', 'Ottilies K盲seladen', 'Mehrheimerstr. 369', 'K枚ln', null, '50739', 'Germany');
INSERT INTO "ORDERS" VALUES ('11021', 'QUICK', '3', TO_DATE('1998-04-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '297.18', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('11022', 'HANAR', '9', TO_DATE('1998-04-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '6.27', 'Hanari Carnes', 'Rua do Pa莽o, 67', 'Rio de Janeiro', 'RJ', '05454-876', 'Brazil');
INSERT INTO "ORDERS" VALUES ('11023', 'BSBEV', '1', TO_DATE('1998-04-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '123.83', 'Bs Beverages', 'Fauntleroy Circus', 'London', null, 'EC2 5NT', 'UK');
INSERT INTO "ORDERS" VALUES ('11024', 'EASTC', '4', TO_DATE('1998-04-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '74.36', 'Eastern Connection', '35 King George', 'London', null, 'WX3 6FW', 'UK');
INSERT INTO "ORDERS" VALUES ('11025', 'WARTH', '6', TO_DATE('1998-04-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '29.17', 'Wartian Herkku', 'Torikatu 38', 'Oulu', null, '90110', 'Finland');
INSERT INTO "ORDERS" VALUES ('11026', 'FRANS', '4', TO_DATE('1998-04-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '47.09', 'Franchi S.p.A.', 'Via Monte Bianco 34', 'Torino', null, '10100', 'Italy');
INSERT INTO "ORDERS" VALUES ('11027', 'BOTTM', '1', TO_DATE('1998-04-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '52.52', 'Bottom-Dollar Markets', '23 Tsawassen Blvd.', 'Tsawassen', 'BC', 'T2F 8M4', 'Canada');
INSERT INTO "ORDERS" VALUES ('11028', 'KOENE', '2', TO_DATE('1998-04-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '29.59', 'K枚niglich Essen', 'Maubelstr. 90', 'Brandenburg', null, '14776', 'Germany');
INSERT INTO "ORDERS" VALUES ('11029', 'CHOPS', '4', TO_DATE('1998-04-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '47.84', 'Chop-suey Chinese', 'Hauptstr. 31', 'Bern', null, '3012', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('11030', 'SAVEA', '7', TO_DATE('1998-04-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '830.75', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('11031', 'SAVEA', '6', TO_DATE('1998-04-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '227.22', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('11032', 'WHITC', '2', TO_DATE('1998-04-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '606.19', 'White Clover Markets', '1029 - 12th Ave. S.', 'Seattle', 'WA', '98124', 'USA');
INSERT INTO "ORDERS" VALUES ('11033', 'RICSU', '7', TO_DATE('1998-04-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '84.74', 'Richter Supermarkt', 'Starenweg 5', 'Gen猫ve', null, '1204', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('11034', 'OLDWO', '8', TO_DATE('1998-04-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-06-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '40.32', 'Old World Delicatessen', '2743 Bering St.', 'Anchorage', 'AK', '99508', 'USA');
INSERT INTO "ORDERS" VALUES ('11035', 'SUPRD', '2', TO_DATE('1998-04-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '0.17', 'Supr锚mes d茅lices', 'Boulevard Tirou, 255', 'Charleroi', null, 'B-6000', 'Belgium');
INSERT INTO "ORDERS" VALUES ('11036', 'DRACD', '8', TO_DATE('1998-04-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '149.47', 'Drachenblut Delikatessen', 'Walserweg 21', 'Aachen', null, '52066', 'Germany');
INSERT INTO "ORDERS" VALUES ('11037', 'GODOS', '7', TO_DATE('1998-04-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '3.20', 'Godos Cocina T铆pica', 'C/ Romero, 33', 'Sevilla', null, '41101', 'Spain');
INSERT INTO "ORDERS" VALUES ('11038', 'SUPRD', '1', TO_DATE('1998-04-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '29.59', 'Supr锚mes d茅lices', 'Boulevard Tirou, 255', 'Charleroi', null, 'B-6000', 'Belgium');
INSERT INTO "ORDERS" VALUES ('11039', 'LINOD', '1', TO_DATE('1998-04-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '2', '65', 'LINO-Delicateses', 'Ave. 5 de Mayo Porlamar', 'I. de Margarita', 'Nueva Esparta', '4980', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('11040', 'GREAL', '4', TO_DATE('1998-04-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '3', '18.84', 'Great Lakes Food Market', '2732 Baker Blvd.', 'Eugene', 'OR', '97403', 'USA');
INSERT INTO "ORDERS" VALUES ('11041', 'CHOPS', '3', TO_DATE('1998-04-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '48.22', 'Chop-suey Chinese', 'Hauptstr. 31', 'Bern', null, '3012', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('11042', 'COMMI', '2', TO_DATE('1998-04-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '29.99', 'Com茅rcio Mineiro', 'Av. dos Lus铆adas, 23', 'Sao Paulo', 'SP', '05432-043', 'Brazil');
INSERT INTO "ORDERS" VALUES ('11043', 'SPECD', '5', TO_DATE('1998-04-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '8.80', 'Sp茅cialit茅s du monde', '25, rue Lauriston', 'Paris', null, '75016', 'France');
INSERT INTO "ORDERS" VALUES ('11044', 'WOLZA', '4', TO_DATE('1998-04-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '8.72', 'Wolski Zajazd', 'ul. Filtrowa 68', 'Warszawa', null, '01-012', 'Poland');
INSERT INTO "ORDERS" VALUES ('11045', 'BOTTM', '6', TO_DATE('1998-04-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '2', '70.58', 'Bottom-Dollar Markets', '23 Tsawassen Blvd.', 'Tsawassen', 'BC', 'T2F 8M4', 'Canada');
INSERT INTO "ORDERS" VALUES ('11046', 'WANDK', '8', TO_DATE('1998-04-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '71.64', 'Die Wandernde Kuh', 'Adenauerallee 900', 'Stuttgart', null, '70563', 'Germany');
INSERT INTO "ORDERS" VALUES ('11047', 'EASTC', '7', TO_DATE('1998-04-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '46.62', 'Eastern Connection', '35 King George', 'London', null, 'WX3 6FW', 'UK');
INSERT INTO "ORDERS" VALUES ('11048', 'BOTTM', '7', TO_DATE('1998-04-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '24.12', 'Bottom-Dollar Markets', '23 Tsawassen Blvd.', 'Tsawassen', 'BC', 'T2F 8M4', 'Canada');
INSERT INTO "ORDERS" VALUES ('11049', 'GOURL', '3', TO_DATE('1998-04-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '8.34', 'Gourmet Lanchonetes', 'Av. Brasil, 442', 'Campinas', 'SP', '04876-786', 'Brazil');
INSERT INTO "ORDERS" VALUES ('11050', 'FOLKO', '8', TO_DATE('1998-04-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '59.41', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('11051', 'LAMAI', '7', TO_DATE('1998-04-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '3', '2.79', 'La maison dAsie', '1 rue Alsace-Lorraine', 'Toulouse', null, '31000', 'France');
INSERT INTO "ORDERS" VALUES ('11052', 'HANAR', '3', TO_DATE('1998-04-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '67.26', 'Hanari Carnes', 'Rua do Pa莽o, 67', 'Rio de Janeiro', 'RJ', '05454-876', 'Brazil');
INSERT INTO "ORDERS" VALUES ('11053', 'PICCO', '2', TO_DATE('1998-04-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '53.05', 'Piccolo und mehr', 'Geislweg 14', 'Salzburg', null, '5020', 'Austria');
INSERT INTO "ORDERS" VALUES ('11054', 'CACTU', '8', TO_DATE('1998-04-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '1', '0.33', 'Cactus Comidas para llevar', 'Cerrito 333', 'Buenos Aires', null, '1010', 'Argentina');
INSERT INTO "ORDERS" VALUES ('11055', 'HILAA', '7', TO_DATE('1998-04-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '120.92', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('11056', 'EASTC', '8', TO_DATE('1998-04-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '278.96', 'Eastern Connection', '35 King George', 'London', null, 'WX3 6FW', 'UK');
INSERT INTO "ORDERS" VALUES ('11057', 'NORTS', '3', TO_DATE('1998-04-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '4.13', 'North/South', 'South House 300 Queensbridge', 'London', null, 'SW7 1RZ', 'UK');
INSERT INTO "ORDERS" VALUES ('11058', 'BLAUS', '9', TO_DATE('1998-04-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '3', '31.14', 'Blauer See Delikatessen', 'Forsterstr. 57', 'Mannheim', null, '68306', 'Germany');
INSERT INTO "ORDERS" VALUES ('11059', 'RICAR', '2', TO_DATE('1998-04-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-06-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '2', '85.80', 'Ricardo Adocicados', 'Av. Copacabana, 267', 'Rio de Janeiro', 'RJ', '02389-890', 'Brazil');
INSERT INTO "ORDERS" VALUES ('11060', 'FRANS', '2', TO_DATE('1998-04-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '10.98', 'Franchi S.p.A.', 'Via Monte Bianco 34', 'Torino', null, '10100', 'Italy');
INSERT INTO "ORDERS" VALUES ('11061', 'GREAL', '4', TO_DATE('1998-04-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-06-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '3', '14.01', 'Great Lakes Food Market', '2732 Baker Blvd.', 'Eugene', 'OR', '97403', 'USA');
INSERT INTO "ORDERS" VALUES ('11062', 'REGGC', '4', TO_DATE('1998-04-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '2', '29.93', 'Reggiani Caseifici', 'Strada Provinciale 124', 'Reggio Emilia', null, '42100', 'Italy');
INSERT INTO "ORDERS" VALUES ('11063', 'HUNGO', '3', TO_DATE('1998-04-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '81.73', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('11064', 'SAVEA', '1', TO_DATE('1998-05-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '30.09', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('11065', 'LILAS', '8', TO_DATE('1998-05-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '1', '12.91', 'LILA-Supermercado', 'Carrera 52 con Ave. Bol铆var #65-98 Llano Largo', 'Barquisimeto', 'Lara', '3508', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('11066', 'WHITC', '7', TO_DATE('1998-05-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '44.72', 'White Clover Markets', '1029 - 12th Ave. S.', 'Seattle', 'WA', '98124', 'USA');
INSERT INTO "ORDERS" VALUES ('11067', 'DRACD', '1', TO_DATE('1998-05-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '7.98', 'Drachenblut Delikatessen', 'Walserweg 21', 'Aachen', null, '52066', 'Germany');
INSERT INTO "ORDERS" VALUES ('11068', 'QUEEN', '8', TO_DATE('1998-05-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-06-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '2', '81.75', 'Queen Cozinha', 'Alameda dos Can脿rios, 891', 'Sao Paulo', 'SP', '05487-020', 'Brazil');
INSERT INTO "ORDERS" VALUES ('11069', 'TORTU', '1', TO_DATE('1998-05-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-06-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '15.67', 'Tortuga Restaurante', 'Avda. Azteca 123', 'M茅xico D.F.', null, '05033', 'Mexico');
INSERT INTO "ORDERS" VALUES ('11070', 'LEHMS', '2', TO_DATE('1998-05-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-06-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '1', '136', 'Lehmanns Marktstand', 'Magazinweg 7', 'Frankfurt a.M.', null, '60528', 'Germany');
INSERT INTO "ORDERS" VALUES ('11071', 'LILAS', '1', TO_DATE('1998-05-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-06-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '1', '0.93', 'LILA-Supermercado', 'Carrera 52 con Ave. Bol铆var #65-98 Llano Largo', 'Barquisimeto', 'Lara', '3508', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('11072', 'ERNSH', '4', TO_DATE('1998-05-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-06-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '2', '258.64', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('11073', 'PERIC', '2', TO_DATE('1998-05-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-06-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '2', '24.95', 'Pericles Comidas cl谩sicas', 'Calle Dr. Jorge Cash 321', 'M茅xico D.F.', null, '05033', 'Mexico');
INSERT INTO "ORDERS" VALUES ('11074', 'SIMOB', '7', TO_DATE('1998-05-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-06-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '2', '18.44', 'Simons bistro', 'Vinb忙ltet 34', 'Kobenhavn', null, '1734', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10822', 'TRAIH', '6', TO_DATE('1998-01-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '7', 'Trails Head Gourmet Provisioners', '722 DaVinci Blvd.', 'Kirkland', 'WA', '98034', 'USA');
INSERT INTO "ORDERS" VALUES ('10823', 'LILAS', '5', TO_DATE('1998-01-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '163.97', 'LILA-Supermercado', 'Carrera 52 con Ave. Bol铆var #65-98 Llano Largo', 'Barquisimeto', 'Lara', '3508', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10824', 'FOLKO', '8', TO_DATE('1998-01-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '1.23', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10825', 'DRACD', '1', TO_DATE('1998-01-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '79.25', 'Drachenblut Delikatessen', 'Walserweg 21', 'Aachen', null, '52066', 'Germany');
INSERT INTO "ORDERS" VALUES ('10826', 'BLONP', '6', TO_DATE('1998-01-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '7.09', 'Blondel p猫re et fils', '24, place Kl茅ber', 'Strasbourg', null, '67000', 'France');
INSERT INTO "ORDERS" VALUES ('10827', 'BONAP', '1', TO_DATE('1998-01-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '63.54', 'Bon app', '12, rue des Bouchers', 'Marseille', null, '13008', 'France');
INSERT INTO "ORDERS" VALUES ('10828', 'RANCH', '9', TO_DATE('1998-01-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '90.85', 'Rancho grande', 'Av. del Libertador 900', 'Buenos Aires', null, '1010', 'Argentina');
INSERT INTO "ORDERS" VALUES ('10829', 'ISLAT', '9', TO_DATE('1998-01-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '154.72', 'Island Trading', 'Garden House Crowther Way', 'Cowes', 'Isle of Wight', 'PO31 7PJ', 'UK');
INSERT INTO "ORDERS" VALUES ('10830', 'TRADH', '4', TO_DATE('1998-01-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '81.83', 'Tradi莽ao Hipermercados', 'Av. In锚s de Castro, 414', 'Sao Paulo', 'SP', '05634-030', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10831', 'SANTG', '3', TO_DATE('1998-01-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '72.19', 'Sant茅 Gourmet', 'Erling Skakkes gate 78', 'Stavern', null, '4110', 'Norway');
INSERT INTO "ORDERS" VALUES ('10832', 'LAMAI', '2', TO_DATE('1998-01-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '43.26', 'La maison dAsie', '1 rue Alsace-Lorraine', 'Toulouse', null, '31000', 'France');
INSERT INTO "ORDERS" VALUES ('10833', 'OTTIK', '6', TO_DATE('1998-01-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '71.49', 'Ottilies K盲seladen', 'Mehrheimerstr. 369', 'K枚ln', null, '50739', 'Germany');
INSERT INTO "ORDERS" VALUES ('10834', 'TRADH', '1', TO_DATE('1998-01-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '29.78', 'Tradi莽ao Hipermercados', 'Av. In锚s de Castro, 414', 'Sao Paulo', 'SP', '05634-030', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10835', 'ALFKI', '1', TO_DATE('1998-01-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '69.53', 'Alfreds Futterkiste', 'Obere Str. 57', 'Berlin', null, '12209', 'Germany');
INSERT INTO "ORDERS" VALUES ('10836', 'ERNSH', '7', TO_DATE('1998-01-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '411.88', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10837', 'BERGS', '9', TO_DATE('1998-01-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '13.32', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10838', 'LINOD', '3', TO_DATE('1998-01-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '59.28', 'LINO-Delicateses', 'Ave. 5 de Mayo Porlamar', 'I. de Margarita', 'Nueva Esparta', '4980', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10839', 'TRADH', '3', TO_DATE('1998-01-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '35.43', 'Tradi莽ao Hipermercados', 'Av. In锚s de Castro, 414', 'Sao Paulo', 'SP', '05634-030', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10840', 'LINOD', '4', TO_DATE('1998-01-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '2.71', 'LINO-Delicateses', 'Ave. 5 de Mayo Porlamar', 'I. de Margarita', 'Nueva Esparta', '4980', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10841', 'SUPRD', '5', TO_DATE('1998-01-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '424.30', 'Supr锚mes d茅lices', 'Boulevard Tirou, 255', 'Charleroi', null, 'B-6000', 'Belgium');
INSERT INTO "ORDERS" VALUES ('10842', 'TORTU', '1', TO_DATE('1998-01-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '54.42', 'Tortuga Restaurante', 'Avda. Azteca 123', 'M茅xico D.F.', null, '05033', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10843', 'VICTE', '4', TO_DATE('1998-01-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '9.26', 'Victuailles en stock', '2, rue du Commerce', 'Lyon', null, '69004', 'France');
INSERT INTO "ORDERS" VALUES ('10844', 'PICCO', '8', TO_DATE('1998-01-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '25.22', 'Piccolo und mehr', 'Geislweg 14', 'Salzburg', null, '5020', 'Austria');
INSERT INTO "ORDERS" VALUES ('10845', 'QUICK', '8', TO_DATE('1998-01-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '212.98', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10846', 'SUPRD', '2', TO_DATE('1998-01-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '56.46', 'Supr锚mes d茅lices', 'Boulevard Tirou, 255', 'Charleroi', null, 'B-6000', 'Belgium');
INSERT INTO "ORDERS" VALUES ('10847', 'SAVEA', '4', TO_DATE('1998-01-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '487.57', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10848', 'CONSH', '7', TO_DATE('1998-01-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '38.24', 'Consolidated Holdings', 'Berkeley Gardens 12  Brewery', 'London', null, 'WX1 6LT', 'UK');
INSERT INTO "ORDERS" VALUES ('10849', 'KOENE', '9', TO_DATE('1998-01-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '0.56', 'K枚niglich Essen', 'Maubelstr. 90', 'Brandenburg', null, '14776', 'Germany');
INSERT INTO "ORDERS" VALUES ('10850', 'VICTE', '1', TO_DATE('1998-01-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '49.19', 'Victuailles en stock', '2, rue du Commerce', 'Lyon', null, '69004', 'France');
INSERT INTO "ORDERS" VALUES ('10851', 'RICAR', '5', TO_DATE('1998-01-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '160.55', 'Ricardo Adocicados', 'Av. Copacabana, 267', 'Rio de Janeiro', 'RJ', '02389-890', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10852', 'RATTC', '8', TO_DATE('1998-01-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-01-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '174.05', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');
INSERT INTO "ORDERS" VALUES ('10853', 'BLAUS', '9', TO_DATE('1998-01-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '53.83', 'Blauer See Delikatessen', 'Forsterstr. 57', 'Mannheim', null, '68306', 'Germany');
INSERT INTO "ORDERS" VALUES ('10854', 'ERNSH', '3', TO_DATE('1998-01-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '100.22', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10855', 'OLDWO', '3', TO_DATE('1998-01-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '170.97', 'Old World Delicatessen', '2743 Bering St.', 'Anchorage', 'AK', '99508', 'USA');
INSERT INTO "ORDERS" VALUES ('10856', 'ANTON', '3', TO_DATE('1998-01-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '58.43', 'Antonio Moreno Taquer铆a', 'Mataderos  2312', 'M茅xico D.F.', null, '05023', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10857', 'BERGS', '8', TO_DATE('1998-01-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '188.85', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10858', 'LACOR', '2', TO_DATE('1998-01-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '52.51', 'La corne dabondance', '67, avenue de lEurope', 'Versailles', null, '78000', 'France');
INSERT INTO "ORDERS" VALUES ('10859', 'FRANK', '1', TO_DATE('1998-01-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '76.10', 'Frankenversand', 'Berliner Platz 43', 'M眉nchen', null, '80805', 'Germany');
INSERT INTO "ORDERS" VALUES ('10860', 'FRANR', '3', TO_DATE('1998-01-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '19.26', 'France restauration', '54, rue Royale', 'Nantes', null, '44000', 'France');
INSERT INTO "ORDERS" VALUES ('10861', 'WHITC', '4', TO_DATE('1998-01-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '14.93', 'White Clover Markets', '1029 - 12th Ave. S.', 'Seattle', 'WA', '98124', 'USA');
INSERT INTO "ORDERS" VALUES ('10862', 'LEHMS', '8', TO_DATE('1998-01-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '53.23', 'Lehmanns Marktstand', 'Magazinweg 7', 'Frankfurt a.M.', null, '60528', 'Germany');
INSERT INTO "ORDERS" VALUES ('10863', 'HILAA', '4', TO_DATE('1998-02-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '30.26', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10864', 'AROUT', '4', TO_DATE('1998-02-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '3.04', 'Around the Horn', 'Brook Farm Stratford St. Mary', 'Colchester', 'Essex', 'CO7 6JX', 'UK');
INSERT INTO "ORDERS" VALUES ('10865', 'QUICK', '2', TO_DATE('1998-02-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '348.14', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10866', 'BERGS', '5', TO_DATE('1998-02-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '109.11', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10867', 'LONEP', '6', TO_DATE('1998-02-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '1.93', 'Lonesome Pine Restaurant', '89 Chiaroscuro Rd.', 'Portland', 'OR', '97219', 'USA');
INSERT INTO "ORDERS" VALUES ('10868', 'QUEEN', '7', TO_DATE('1998-02-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '191.27', 'Queen Cozinha', 'Alameda dos Can脿rios, 891', 'Sao Paulo', 'SP', '05487-020', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10869', 'SEVES', '5', TO_DATE('1998-02-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '143.28', 'Seven Seas Imports', '90 Wadhurst Rd.', 'London', null, 'OX15 4NB', 'UK');
INSERT INTO "ORDERS" VALUES ('10870', 'WOLZA', '5', TO_DATE('1998-02-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '12.04', 'Wolski Zajazd', 'ul. Filtrowa 68', 'Warszawa', null, '01-012', 'Poland');
INSERT INTO "ORDERS" VALUES ('10871', 'BONAP', '9', TO_DATE('1998-02-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '112.27', 'Bon app', '12, rue des Bouchers', 'Marseille', null, '13008', 'France');
INSERT INTO "ORDERS" VALUES ('10872', 'GODOS', '5', TO_DATE('1998-02-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '175.32', 'Godos Cocina T铆pica', 'C/ Romero, 33', 'Sevilla', null, '41101', 'Spain');
INSERT INTO "ORDERS" VALUES ('10873', 'WILMK', '4', TO_DATE('1998-02-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '0.82', 'Wilman Kala', 'Keskuskatu 45', 'Helsinki', null, '21240', 'Finland');
INSERT INTO "ORDERS" VALUES ('10874', 'GODOS', '5', TO_DATE('1998-02-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '19.58', 'Godos Cocina T铆pica', 'C/ Romero, 33', 'Sevilla', null, '41101', 'Spain');
INSERT INTO "ORDERS" VALUES ('10875', 'BERGS', '4', TO_DATE('1998-02-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '32.37', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10876', 'BONAP', '7', TO_DATE('1998-02-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '60.42', 'Bon app', '12, rue des Bouchers', 'Marseille', null, '13008', 'France');
INSERT INTO "ORDERS" VALUES ('10877', 'RICAR', '1', TO_DATE('1998-02-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '38.06', 'Ricardo Adocicados', 'Av. Copacabana, 267', 'Rio de Janeiro', 'RJ', '02389-890', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10878', 'QUICK', '4', TO_DATE('1998-02-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '46.69', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10879', 'WILMK', '3', TO_DATE('1998-02-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '8.50', 'Wilman Kala', 'Keskuskatu 45', 'Helsinki', null, '21240', 'Finland');
INSERT INTO "ORDERS" VALUES ('10880', 'FOLKO', '7', TO_DATE('1998-02-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '88.01', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10881', 'CACTU', '4', TO_DATE('1998-02-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '2.84', 'Cactus Comidas para llevar', 'Cerrito 333', 'Buenos Aires', null, '1010', 'Argentina');
INSERT INTO "ORDERS" VALUES ('10882', 'SAVEA', '4', TO_DATE('1998-02-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '23.10', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10883', 'LONEP', '8', TO_DATE('1998-02-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '0.53', 'Lonesome Pine Restaurant', '89 Chiaroscuro Rd.', 'Portland', 'OR', '97219', 'USA');
INSERT INTO "ORDERS" VALUES ('10884', 'LETSS', '4', TO_DATE('1998-02-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '90.97', 'Lets Stop N Shop', '87 Polk St. Suite 5', 'San Francisco', 'CA', '94117', 'USA');
INSERT INTO "ORDERS" VALUES ('10885', 'SUPRD', '6', TO_DATE('1998-02-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '5.64', 'Supr锚mes d茅lices', 'Boulevard Tirou, 255', 'Charleroi', null, 'B-6000', 'Belgium');
INSERT INTO "ORDERS" VALUES ('10886', 'HANAR', '1', TO_DATE('1998-02-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '4.99', 'Hanari Carnes', 'Rua do Pa莽o, 67', 'Rio de Janeiro', 'RJ', '05454-876', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10887', 'GALED', '8', TO_DATE('1998-02-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '1.25', 'Galer铆a del gastron贸mo', 'Rambla de Catalu帽a, 23', 'Barcelona', null, '8022', 'Spain');
INSERT INTO "ORDERS" VALUES ('10888', 'GODOS', '1', TO_DATE('1998-02-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '51.87', 'Godos Cocina T铆pica', 'C/ Romero, 33', 'Sevilla', null, '41101', 'Spain');
INSERT INTO "ORDERS" VALUES ('10889', 'RATTC', '9', TO_DATE('1998-02-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '280.61', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');
INSERT INTO "ORDERS" VALUES ('10890', 'DUMON', '7', TO_DATE('1998-02-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '32.76', 'Du monde entier', '67, rue des Cinquante Otages', 'Nantes', null, '44000', 'France');
INSERT INTO "ORDERS" VALUES ('10891', 'LEHMS', '7', TO_DATE('1998-02-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '20.37', 'Lehmanns Marktstand', 'Magazinweg 7', 'Frankfurt a.M.', null, '60528', 'Germany');
INSERT INTO "ORDERS" VALUES ('10892', 'MAISD', '4', TO_DATE('1998-02-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '120.27', 'Maison Dewey', 'Rue Joseph-Bens 532', 'Bruxelles', null, 'B-1180', 'Belgium');
INSERT INTO "ORDERS" VALUES ('10893', 'KOENE', '9', TO_DATE('1998-02-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '77.78', 'K枚niglich Essen', 'Maubelstr. 90', 'Brandenburg', null, '14776', 'Germany');
INSERT INTO "ORDERS" VALUES ('10894', 'SAVEA', '1', TO_DATE('1998-02-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '116.13', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10895', 'ERNSH', '3', TO_DATE('1998-02-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '162.75', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10896', 'MAISD', '7', TO_DATE('1998-02-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '32.45', 'Maison Dewey', 'Rue Joseph-Bens 532', 'Bruxelles', null, 'B-1180', 'Belgium');
INSERT INTO "ORDERS" VALUES ('10897', 'HUNGO', '3', TO_DATE('1998-02-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '603.54', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10898', 'OCEAN', '4', TO_DATE('1998-02-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '1.27', 'Oc茅ano Atl谩ntico Ltda.', 'Ing. Gustavo Moncada 8585 Piso 20-A', 'Buenos Aires', null, '1010', 'Argentina');
INSERT INTO "ORDERS" VALUES ('10899', 'LILAS', '5', TO_DATE('1998-02-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '1.21', 'LILA-Supermercado', 'Carrera 52 con Ave. Bol铆var #65-98 Llano Largo', 'Barquisimeto', 'Lara', '3508', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10900', 'WELLI', '1', TO_DATE('1998-02-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '1.66', 'Wellington Importadora', 'Rua do Mercado, 12', 'Resende', 'SP', '08737-363', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10901', 'HILAA', '4', TO_DATE('1998-02-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '62.09', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10902', 'FOLKO', '1', TO_DATE('1998-02-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '44.15', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10903', 'HANAR', '3', TO_DATE('1998-02-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '36.71', 'Hanari Carnes', 'Rua do Pa莽o, 67', 'Rio de Janeiro', 'RJ', '05454-876', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10904', 'WHITC', '3', TO_DATE('1998-02-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '162.95', 'White Clover Markets', '1029 - 12th Ave. S.', 'Seattle', 'WA', '98124', 'USA');
INSERT INTO "ORDERS" VALUES ('10905', 'WELLI', '9', TO_DATE('1998-02-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '13.72', 'Wellington Importadora', 'Rua do Mercado, 12', 'Resende', 'SP', '08737-363', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10906', 'WOLZA', '4', TO_DATE('1998-02-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '26.29', 'Wolski Zajazd', 'ul. Filtrowa 68', 'Warszawa', null, '01-012', 'Poland');
INSERT INTO "ORDERS" VALUES ('10907', 'SPECD', '6', TO_DATE('1998-02-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-02-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '9.19', 'Sp茅cialit茅s du monde', '25, rue Lauriston', 'Paris', null, '75016', 'France');
INSERT INTO "ORDERS" VALUES ('10908', 'REGGC', '4', TO_DATE('1998-02-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '32.96', 'Reggiani Caseifici', 'Strada Provinciale 124', 'Reggio Emilia', null, '42100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10909', 'SANTG', '1', TO_DATE('1998-02-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '53.05', 'Sant茅 Gourmet', 'Erling Skakkes gate 78', 'Stavern', null, '4110', 'Norway');
INSERT INTO "ORDERS" VALUES ('10910', 'WILMK', '1', TO_DATE('1998-02-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '38.11', 'Wilman Kala', 'Keskuskatu 45', 'Helsinki', null, '21240', 'Finland');
INSERT INTO "ORDERS" VALUES ('10911', 'GODOS', '3', TO_DATE('1998-02-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '38.19', 'Godos Cocina T铆pica', 'C/ Romero, 33', 'Sevilla', null, '41101', 'Spain');
INSERT INTO "ORDERS" VALUES ('10912', 'HUNGO', '2', TO_DATE('1998-02-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '580.91', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10913', 'QUEEN', '4', TO_DATE('1998-02-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '33.05', 'Queen Cozinha', 'Alameda dos Can脿rios, 891', 'Sao Paulo', 'SP', '05487-020', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10914', 'QUEEN', '6', TO_DATE('1998-02-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '21.19', 'Queen Cozinha', 'Alameda dos Can脿rios, 891', 'Sao Paulo', 'SP', '05487-020', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10915', 'TORTU', '2', TO_DATE('1998-02-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '3.51', 'Tortuga Restaurante', 'Avda. Azteca 123', 'M茅xico D.F.', null, '05033', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10916', 'RANCH', '1', TO_DATE('1998-02-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '63.77', 'Rancho grande', 'Av. del Libertador 900', 'Buenos Aires', null, '1010', 'Argentina');
INSERT INTO "ORDERS" VALUES ('10917', 'ROMEY', '4', TO_DATE('1998-03-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '8.29', 'Romero y tomillo', 'Gran V铆a, 1', 'Madrid', null, '28001', 'Spain');
INSERT INTO "ORDERS" VALUES ('10918', 'BOTTM', '3', TO_DATE('1998-03-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '48.83', 'Bottom-Dollar Markets', '23 Tsawassen Blvd.', 'Tsawassen', 'BC', 'T2F 8M4', 'Canada');
INSERT INTO "ORDERS" VALUES ('10919', 'LINOD', '2', TO_DATE('1998-03-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '19.80', 'LINO-Delicateses', 'Ave. 5 de Mayo Porlamar', 'I. de Margarita', 'Nueva Esparta', '4980', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10920', 'AROUT', '4', TO_DATE('1998-03-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '29.61', 'Around the Horn', 'Brook Farm Stratford St. Mary', 'Colchester', 'Essex', 'CO7 6JX', 'UK');
INSERT INTO "ORDERS" VALUES ('10921', 'VAFFE', '1', TO_DATE('1998-03-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '176.48', 'Vaffeljernet', 'Smagsloget 45', '脜rhus', null, '8200', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10922', 'HANAR', '5', TO_DATE('1998-03-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '62.74', 'Hanari Carnes', 'Rua do Pa莽o, 67', 'Rio de Janeiro', 'RJ', '05454-876', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10923', 'LAMAI', '7', TO_DATE('1998-03-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '68.26', 'La maison dAsie', '1 rue Alsace-Lorraine', 'Toulouse', null, '31000', 'France');
INSERT INTO "ORDERS" VALUES ('10924', 'BERGS', '3', TO_DATE('1998-03-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '151.52', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10925', 'HANAR', '3', TO_DATE('1998-03-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '2.27', 'Hanari Carnes', 'Rua do Pa莽o, 67', 'Rio de Janeiro', 'RJ', '05454-876', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10926', 'ANATR', '4', TO_DATE('1998-03-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '39.92', 'Ana Trujillo Emparedados y helados', 'Avda. de la Constituci贸n 2222', 'M茅xico D.F.', null, '05021', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10927', 'LACOR', '4', TO_DATE('1998-03-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '19.79', 'La corne dabondance', '67, avenue de lEurope', 'Versailles', null, '78000', 'France');
INSERT INTO "ORDERS" VALUES ('10928', 'GALED', '1', TO_DATE('1998-03-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '1.36', 'Galer铆a del gastron贸mo', 'Rambla de Catalu帽a, 23', 'Barcelona', null, '8022', 'Spain');
INSERT INTO "ORDERS" VALUES ('10929', 'FRANK', '6', TO_DATE('1998-03-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '33.93', 'Frankenversand', 'Berliner Platz 43', 'M眉nchen', null, '80805', 'Germany');
INSERT INTO "ORDERS" VALUES ('10930', 'SUPRD', '4', TO_DATE('1998-03-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '15.55', 'Supr锚mes d茅lices', 'Boulevard Tirou, 255', 'Charleroi', null, 'B-6000', 'Belgium');
INSERT INTO "ORDERS" VALUES ('10931', 'RICSU', '4', TO_DATE('1998-03-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '13.60', 'Richter Supermarkt', 'Starenweg 5', 'Gen猫ve', null, '1204', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('10932', 'BONAP', '8', TO_DATE('1998-03-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '134.64', 'Bon app', '12, rue des Bouchers', 'Marseille', null, '13008', 'France');
INSERT INTO "ORDERS" VALUES ('10933', 'ISLAT', '6', TO_DATE('1998-03-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '54.15', 'Island Trading', 'Garden House Crowther Way', 'Cowes', 'Isle of Wight', 'PO31 7PJ', 'UK');
INSERT INTO "ORDERS" VALUES ('10934', 'LEHMS', '3', TO_DATE('1998-03-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '32.01', 'Lehmanns Marktstand', 'Magazinweg 7', 'Frankfurt a.M.', null, '60528', 'Germany');
INSERT INTO "ORDERS" VALUES ('10935', 'WELLI', '4', TO_DATE('1998-03-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '47.59', 'Wellington Importadora', 'Rua do Mercado, 12', 'Resende', 'SP', '08737-363', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10936', 'GREAL', '3', TO_DATE('1998-03-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '33.68', 'Great Lakes Food Market', '2732 Baker Blvd.', 'Eugene', 'OR', '97403', 'USA');
INSERT INTO "ORDERS" VALUES ('10937', 'CACTU', '7', TO_DATE('1998-03-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '31.51', 'Cactus Comidas para llevar', 'Cerrito 333', 'Buenos Aires', null, '1010', 'Argentina');
INSERT INTO "ORDERS" VALUES ('10938', 'QUICK', '3', TO_DATE('1998-03-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '31.89', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10939', 'MAGAA', '2', TO_DATE('1998-03-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '76.33', 'Magazzini Alimentari Riuniti', 'Via Ludovico il Moro 22', 'Bergamo', null, '24100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10940', 'BONAP', '8', TO_DATE('1998-03-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '19.77', 'Bon app', '12, rue des Bouchers', 'Marseille', null, '13008', 'France');
INSERT INTO "ORDERS" VALUES ('10941', 'SAVEA', '7', TO_DATE('1998-03-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '400.81', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10942', 'REGGC', '9', TO_DATE('1998-03-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '17.95', 'Reggiani Caseifici', 'Strada Provinciale 124', 'Reggio Emilia', null, '42100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10943', 'BSBEV', '4', TO_DATE('1998-03-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '2.17', 'Bs Beverages', 'Fauntleroy Circus', 'London', null, 'EC2 5NT', 'UK');
INSERT INTO "ORDERS" VALUES ('10944', 'BOTTM', '6', TO_DATE('1998-03-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '52.92', 'Bottom-Dollar Markets', '23 Tsawassen Blvd.', 'Tsawassen', 'BC', 'T2F 8M4', 'Canada');
INSERT INTO "ORDERS" VALUES ('10945', 'MORGK', '4', TO_DATE('1998-03-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '10.22', 'Morgenstern Gesundkost', 'Heerstr. 22', 'Leipzig', null, '04179', 'Germany');
INSERT INTO "ORDERS" VALUES ('10946', 'VAFFE', '1', TO_DATE('1998-03-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '27.20', 'Vaffeljernet', 'Smagsloget 45', '脜rhus', null, '8200', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10947', 'BSBEV', '3', TO_DATE('1998-03-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '3.26', 'Bs Beverages', 'Fauntleroy Circus', 'London', null, 'EC2 5NT', 'UK');
INSERT INTO "ORDERS" VALUES ('10948', 'GODOS', '3', TO_DATE('1998-03-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '23.39', 'Godos Cocina T铆pica', 'C/ Romero, 33', 'Sevilla', null, '41101', 'Spain');
INSERT INTO "ORDERS" VALUES ('10949', 'BOTTM', '2', TO_DATE('1998-03-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '74.44', 'Bottom-Dollar Markets', '23 Tsawassen Blvd.', 'Tsawassen', 'BC', 'T2F 8M4', 'Canada');
INSERT INTO "ORDERS" VALUES ('10950', 'MAGAA', '1', TO_DATE('1998-03-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '2.50', 'Magazzini Alimentari Riuniti', 'Via Ludovico il Moro 22', 'Bergamo', null, '24100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10951', 'RICSU', '9', TO_DATE('1998-03-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '30.85', 'Richter Supermarkt', 'Starenweg 5', 'Gen猫ve', null, '1204', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('10952', 'ALFKI', '1', TO_DATE('1998-03-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '40.42', 'Alfreds Futterkiste', 'Obere Str. 57', 'Berlin', null, '12209', 'Germany');
INSERT INTO "ORDERS" VALUES ('10953', 'AROUT', '9', TO_DATE('1998-03-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '23.72', 'Around the Horn', 'Brook Farm Stratford St. Mary', 'Colchester', 'Essex', 'CO7 6JX', 'UK');
INSERT INTO "ORDERS" VALUES ('10954', 'LINOD', '5', TO_DATE('1998-03-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '27.91', 'LINO-Delicateses', 'Ave. 5 de Mayo Porlamar', 'I. de Margarita', 'Nueva Esparta', '4980', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10955', 'FOLKO', '8', TO_DATE('1998-03-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '3.26', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10956', 'BLAUS', '6', TO_DATE('1998-03-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '44.65', 'Blauer See Delikatessen', 'Forsterstr. 57', 'Mannheim', null, '68306', 'Germany');
INSERT INTO "ORDERS" VALUES ('10957', 'HILAA', '8', TO_DATE('1998-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '105.36', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10958', 'OCEAN', '7', TO_DATE('1998-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '49.56', 'Oc茅ano Atl谩ntico Ltda.', 'Ing. Gustavo Moncada 8585 Piso 20-A', 'Buenos Aires', null, '1010', 'Argentina');
INSERT INTO "ORDERS" VALUES ('10959', 'GOURL', '6', TO_DATE('1998-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '4.98', 'Gourmet Lanchonetes', 'Av. Brasil, 442', 'Campinas', 'SP', '04876-786', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10960', 'HILAA', '3', TO_DATE('1998-03-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '2.08', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10961', 'QUEEN', '8', TO_DATE('1998-03-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '104.47', 'Queen Cozinha', 'Alameda dos Can脿rios, 891', 'Sao Paulo', 'SP', '05487-020', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10962', 'QUICK', '8', TO_DATE('1998-03-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '275.79', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10963', 'FURIB', '9', TO_DATE('1998-03-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '2.70', 'Furia Bacalhau e Frutos do Mar', 'Jardim das rosas n. 32', 'Lisboa', null, '1675', 'Portugal');
INSERT INTO "ORDERS" VALUES ('10964', 'SPECD', '3', TO_DATE('1998-03-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '87.38', 'Sp茅cialit茅s du monde', '25, rue Lauriston', 'Paris', null, '75016', 'France');
INSERT INTO "ORDERS" VALUES ('10965', 'OLDWO', '6', TO_DATE('1998-03-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '144.38', 'Old World Delicatessen', '2743 Bering St.', 'Anchorage', 'AK', '99508', 'USA');
INSERT INTO "ORDERS" VALUES ('10966', 'CHOPS', '4', TO_DATE('1998-03-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '27.19', 'Chop-suey Chinese', 'Hauptstr. 31', 'Bern', null, '3012', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('10967', 'TOMSP', '2', TO_DATE('1998-03-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '62.22', 'Toms Spezialit盲ten', 'Luisenstr. 48', 'M眉nster', null, '44087', 'Germany');
INSERT INTO "ORDERS" VALUES ('10968', 'ERNSH', '1', TO_DATE('1998-03-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '74.60', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10969', 'COMMI', '1', TO_DATE('1998-03-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '0.21', 'Com茅rcio Mineiro', 'Av. dos Lus铆adas, 23', 'Sao Paulo', 'SP', '05432-043', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10970', 'BOLID', '9', TO_DATE('1998-03-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '16.16', 'B贸lido Comidas preparadas', 'C/ Araquil, 67', 'Madrid', null, '28023', 'Spain');
INSERT INTO "ORDERS" VALUES ('10971', 'FRANR', '2', TO_DATE('1998-03-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '121.82', 'France restauration', '54, rue Royale', 'Nantes', null, '44000', 'France');
INSERT INTO "ORDERS" VALUES ('10972', 'LACOR', '4', TO_DATE('1998-03-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '0.02', 'La corne dabondance', '67, avenue de lEurope', 'Versailles', null, '78000', 'France');
INSERT INTO "ORDERS" VALUES ('10973', 'LACOR', '6', TO_DATE('1998-03-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '15.17', 'La corne dabondance', '67, avenue de lEurope', 'Versailles', null, '78000', 'France');
INSERT INTO "ORDERS" VALUES ('10974', 'SPLIR', '3', TO_DATE('1998-03-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '12.96', 'Split Rail Beer 1', 'P.O. Box 555', 'Lander', 'WY', '82520', 'USA');
INSERT INTO "ORDERS" VALUES ('10975', 'BOTTM', '1', TO_DATE('1998-03-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '32.27', 'Bottom-Dollar Markets', '23 Tsawassen Blvd.', 'Tsawassen', 'BC', 'T2F 8M4', 'Canada');
INSERT INTO "ORDERS" VALUES ('10976', 'HILAA', '1', TO_DATE('1998-03-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '37.97', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10977', 'FOLKO', '8', TO_DATE('1998-03-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '208.50', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10978', 'MAISD', '9', TO_DATE('1998-03-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '32.82', 'Maison Dewey', 'Rue Joseph-Bens 532', 'Bruxelles', null, 'B-1180', 'Belgium');
INSERT INTO "ORDERS" VALUES ('10979', 'ERNSH', '8', TO_DATE('1998-03-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-03-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '353.07', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10980', 'FOLKO', '4', TO_DATE('1998-03-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '1.26', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10981', 'HANAR', '1', TO_DATE('1998-03-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '193.37', 'Hanari Carnes', 'Rua do Pa莽o, 67', 'Rio de Janeiro', 'RJ', '05454-876', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10982', 'BOTTM', '2', TO_DATE('1998-03-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '14.01', 'Bottom-Dollar Markets', '23 Tsawassen Blvd.', 'Tsawassen', 'BC', 'T2F 8M4', 'Canada');
INSERT INTO "ORDERS" VALUES ('10983', 'SAVEA', '2', TO_DATE('1998-03-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '657.54', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10984', 'SAVEA', '1', TO_DATE('1998-03-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '211.22', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10985', 'HUNGO', '2', TO_DATE('1998-03-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '91.51', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10986', 'OCEAN', '8', TO_DATE('1998-03-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '217.86', 'Oc茅ano Atl谩ntico Ltda.', 'Ing. Gustavo Moncada 8585 Piso 20-A', 'Buenos Aires', null, '1010', 'Argentina');
INSERT INTO "ORDERS" VALUES ('10987', 'EASTC', '8', TO_DATE('1998-03-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '185.48', 'Eastern Connection', '35 King George', 'London', null, 'WX3 6FW', 'UK');
INSERT INTO "ORDERS" VALUES ('10988', 'RATTC', '3', TO_DATE('1998-03-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '61.14', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');
INSERT INTO "ORDERS" VALUES ('10989', 'QUEDE', '2', TO_DATE('1998-03-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '34.76', 'Que Del铆cia', 'Rua da Panificadora, 12', 'Rio de Janeiro', 'RJ', '02389-673', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10990', 'ERNSH', '2', TO_DATE('1998-04-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '117.61', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10991', 'QUICK', '1', TO_DATE('1998-04-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '38.51', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10992', 'THEBI', '1', TO_DATE('1998-04-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '4.27', 'The Big Cheese', '89 Jefferson Way Suite 2', 'Portland', 'OR', '97201', 'USA');
INSERT INTO "ORDERS" VALUES ('10993', 'FOLKO', '7', TO_DATE('1998-04-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '8.81', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10994', 'VAFFE', '2', TO_DATE('1998-04-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '65.53', 'Vaffeljernet', 'Smagsloget 45', '脜rhus', null, '8200', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10995', 'PERIC', '1', TO_DATE('1998-04-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '46', 'Pericles Comidas cl谩sicas', 'Calle Dr. Jorge Cash 321', 'M茅xico D.F.', null, '05033', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10996', 'QUICK', '4', TO_DATE('1998-04-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '1.12', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10997', 'LILAS', '8', TO_DATE('1998-04-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '73.91', 'LILA-Supermercado', 'Carrera 52 con Ave. Bol铆var #65-98 Llano Largo', 'Barquisimeto', 'Lara', '3508', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10998', 'WOLZA', '8', TO_DATE('1998-04-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '20.31', 'Wolski Zajazd', 'ul. Filtrowa 68', 'Warszawa', null, '01-012', 'Poland');
INSERT INTO "ORDERS" VALUES ('10999', 'OTTIK', '6', TO_DATE('1998-04-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '96.35', 'Ottilies K盲seladen', 'Mehrheimerstr. 369', 'K枚ln', null, '50739', 'Germany');
INSERT INTO "ORDERS" VALUES ('11000', 'RATTC', '2', TO_DATE('1998-04-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '55.12', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');
INSERT INTO "ORDERS" VALUES ('11001', 'FOLKO', '2', TO_DATE('1998-04-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '197.30', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('11002', 'SAVEA', '4', TO_DATE('1998-04-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '141.16', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('11003', 'THECR', '3', TO_DATE('1998-04-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '14.91', 'The Cracker Box', '55 Grizzly Peak Rd.', 'Butte', 'MT', '59801', 'USA');
INSERT INTO "ORDERS" VALUES ('11004', 'MAISD', '3', TO_DATE('1998-04-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '44.84', 'Maison Dewey', 'Rue Joseph-Bens 532', 'Bruxelles', null, 'B-1180', 'Belgium');
INSERT INTO "ORDERS" VALUES ('11005', 'WILMK', '2', TO_DATE('1998-04-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '0.75', 'Wilman Kala', 'Keskuskatu 45', 'Helsinki', null, '21240', 'Finland');
INSERT INTO "ORDERS" VALUES ('11006', 'GREAL', '3', TO_DATE('1998-04-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '25.19', 'Great Lakes Food Market', '2732 Baker Blvd.', 'Eugene', 'OR', '97403', 'USA');
INSERT INTO "ORDERS" VALUES ('11007', 'PRINI', '8', TO_DATE('1998-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '202.24', 'Princesa Isabel Vinhos', 'Estrada da sa煤de n. 58', 'Lisboa', null, '1756', 'Portugal');
INSERT INTO "ORDERS" VALUES ('11008', 'ERNSH', '7', TO_DATE('1998-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '3', '79.46', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('11009', 'GODOS', '2', TO_DATE('1998-04-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '59.11', 'Godos Cocina T铆pica', 'C/ Romero, 33', 'Sevilla', null, '41101', 'Spain');
INSERT INTO "ORDERS" VALUES ('11010', 'REGGC', '2', TO_DATE('1998-04-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-05-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-04-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '28.71', 'Reggiani Caseifici', 'Strada Provinciale 124', 'Reggio Emilia', null, '42100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10565', 'MEREP', '8', TO_DATE('1997-06-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '7.15', 'M猫re Paillarde', '43 rue St. Laurent', 'Montr茅al', 'Qu茅bec', 'H1J 1C3', 'Canada');
INSERT INTO "ORDERS" VALUES ('10566', 'BLONP', '9', TO_DATE('1997-06-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '88.40', 'Blondel p猫re et fils', '24, place Kl茅ber', 'Strasbourg', null, '67000', 'France');
INSERT INTO "ORDERS" VALUES ('10567', 'HUNGO', '1', TO_DATE('1997-06-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '33.97', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10568', 'GALED', '3', TO_DATE('1997-06-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '6.54', 'Galer铆a del gastron贸mo', 'Rambla de Catalu帽a, 23', 'Barcelona', null, '8022', 'Spain');
INSERT INTO "ORDERS" VALUES ('10569', 'RATTC', '5', TO_DATE('1997-06-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '58.98', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');
INSERT INTO "ORDERS" VALUES ('10570', 'MEREP', '3', TO_DATE('1997-06-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '188.99', 'M猫re Paillarde', '43 rue St. Laurent', 'Montr茅al', 'Qu茅bec', 'H1J 1C3', 'Canada');
INSERT INTO "ORDERS" VALUES ('10571', 'ERNSH', '8', TO_DATE('1997-06-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '26.06', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10572', 'BERGS', '3', TO_DATE('1997-06-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '116.43', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10573', 'ANTON', '7', TO_DATE('1997-06-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '84.84', 'Antonio Moreno Taquer铆a', 'Mataderos  2312', 'M茅xico D.F.', null, '05023', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10574', 'TRAIH', '4', TO_DATE('1997-06-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '37.60', 'Trails Head Gourmet Provisioners', '722 DaVinci Blvd.', 'Kirkland', 'WA', '98034', 'USA');
INSERT INTO "ORDERS" VALUES ('10575', 'MORGK', '5', TO_DATE('1997-06-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '127.34', 'Morgenstern Gesundkost', 'Heerstr. 22', 'Leipzig', null, '04179', 'Germany');
INSERT INTO "ORDERS" VALUES ('10576', 'TORTU', '3', TO_DATE('1997-06-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '18.56', 'Tortuga Restaurante', 'Avda. Azteca 123', 'M茅xico D.F.', null, '05033', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10577', 'TRAIH', '9', TO_DATE('1997-06-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-06-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '25.41', 'Trails Head Gourmet Provisioners', '722 DaVinci Blvd.', 'Kirkland', 'WA', '98034', 'USA');
INSERT INTO "ORDERS" VALUES ('10578', 'BSBEV', '4', TO_DATE('1997-06-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '29.60', 'Bs Beverages', 'Fauntleroy Circus', 'London', null, 'EC2 5NT', 'UK');
INSERT INTO "ORDERS" VALUES ('10579', 'LETSS', '1', TO_DATE('1997-06-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '13.73', 'Lets Stop N Shop', '87 Polk St. Suite 5', 'San Francisco', 'CA', '94117', 'USA');
INSERT INTO "ORDERS" VALUES ('10580', 'OTTIK', '4', TO_DATE('1997-06-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '75.89', 'Ottilies K盲seladen', 'Mehrheimerstr. 369', 'K枚ln', null, '50739', 'Germany');
INSERT INTO "ORDERS" VALUES ('10581', 'FAMIA', '3', TO_DATE('1997-06-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '3.01', 'Familia Arquibaldo', 'Rua Or贸s, 92', 'Sao Paulo', 'SP', '05442-030', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10582', 'BLAUS', '3', TO_DATE('1997-06-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '27.71', 'Blauer See Delikatessen', 'Forsterstr. 57', 'Mannheim', null, '68306', 'Germany');
INSERT INTO "ORDERS" VALUES ('10583', 'WARTH', '2', TO_DATE('1997-06-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '7.28', 'Wartian Herkku', 'Torikatu 38', 'Oulu', null, '90110', 'Finland');
INSERT INTO "ORDERS" VALUES ('10584', 'BLONP', '4', TO_DATE('1997-06-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '59.14', 'Blondel p猫re et fils', '24, place Kl茅ber', 'Strasbourg', null, '67000', 'France');
INSERT INTO "ORDERS" VALUES ('10585', 'WELLI', '7', TO_DATE('1997-07-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '13.41', 'Wellington Importadora', 'Rua do Mercado, 12', 'Resende', 'SP', '08737-363', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10586', 'REGGC', '9', TO_DATE('1997-07-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '0.48', 'Reggiani Caseifici', 'Strada Provinciale 124', 'Reggio Emilia', null, '42100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10587', 'QUEDE', '1', TO_DATE('1997-07-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '62.52', 'Que Del铆cia', 'Rua da Panificadora, 12', 'Rio de Janeiro', 'RJ', '02389-673', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10588', 'QUICK', '2', TO_DATE('1997-07-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '194.67', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10589', 'GREAL', '8', TO_DATE('1997-07-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '4.42', 'Great Lakes Food Market', '2732 Baker Blvd.', 'Eugene', 'OR', '97403', 'USA');
INSERT INTO "ORDERS" VALUES ('10590', 'MEREP', '4', TO_DATE('1997-07-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '44.77', 'M猫re Paillarde', '43 rue St. Laurent', 'Montr茅al', 'Qu茅bec', 'H1J 1C3', 'Canada');
INSERT INTO "ORDERS" VALUES ('10591', 'VAFFE', '1', TO_DATE('1997-07-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '55.92', 'Vaffeljernet', 'Smagsloget 45', '脜rhus', null, '8200', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10592', 'LEHMS', '3', TO_DATE('1997-07-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '32.10', 'Lehmanns Marktstand', 'Magazinweg 7', 'Frankfurt a.M.', null, '60528', 'Germany');
INSERT INTO "ORDERS" VALUES ('10593', 'LEHMS', '7', TO_DATE('1997-07-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '174.20', 'Lehmanns Marktstand', 'Magazinweg 7', 'Frankfurt a.M.', null, '60528', 'Germany');
INSERT INTO "ORDERS" VALUES ('10594', 'OLDWO', '3', TO_DATE('1997-07-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '5.24', 'Old World Delicatessen', '2743 Bering St.', 'Anchorage', 'AK', '99508', 'USA');
INSERT INTO "ORDERS" VALUES ('10595', 'ERNSH', '2', TO_DATE('1997-07-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '96.78', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10596', 'WHITC', '8', TO_DATE('1997-07-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '16.34', 'White Clover Markets', '1029 - 12th Ave. S.', 'Seattle', 'WA', '98124', 'USA');
INSERT INTO "ORDERS" VALUES ('10597', 'PICCO', '7', TO_DATE('1997-07-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '35.12', 'Piccolo und mehr', 'Geislweg 14', 'Salzburg', null, '5020', 'Austria');
INSERT INTO "ORDERS" VALUES ('10598', 'RATTC', '1', TO_DATE('1997-07-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '44.42', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');
INSERT INTO "ORDERS" VALUES ('10599', 'BSBEV', '6', TO_DATE('1997-07-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '29.98', 'Bs Beverages', 'Fauntleroy Circus', 'London', null, 'EC2 5NT', 'UK');
INSERT INTO "ORDERS" VALUES ('10600', 'HUNGC', '4', TO_DATE('1997-07-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '45.13', 'Hungry Coyote Import Store', 'City Center Plaza 516 Main St.', 'Elgin', 'OR', '97827', 'USA');
INSERT INTO "ORDERS" VALUES ('10601', 'HILAA', '7', TO_DATE('1997-07-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '58.30', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10602', 'VAFFE', '8', TO_DATE('1997-07-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '2.92', 'Vaffeljernet', 'Smagsloget 45', '脜rhus', null, '8200', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10603', 'SAVEA', '8', TO_DATE('1997-07-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '48.77', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10604', 'FURIB', '1', TO_DATE('1997-07-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '7.46', 'Furia Bacalhau e Frutos do Mar', 'Jardim das rosas n. 32', 'Lisboa', null, '1675', 'Portugal');
INSERT INTO "ORDERS" VALUES ('10605', 'MEREP', '1', TO_DATE('1997-07-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '379.13', 'M猫re Paillarde', '43 rue St. Laurent', 'Montr茅al', 'Qu茅bec', 'H1J 1C3', 'Canada');
INSERT INTO "ORDERS" VALUES ('10606', 'TRADH', '4', TO_DATE('1997-07-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '79.40', 'Tradi莽ao Hipermercados', 'Av. In锚s de Castro, 414', 'Sao Paulo', 'SP', '05634-030', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10607', 'SAVEA', '5', TO_DATE('1997-07-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '200.24', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10608', 'TOMSP', '4', TO_DATE('1997-07-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '27.79', 'Toms Spezialit盲ten', 'Luisenstr. 48', 'M眉nster', null, '44087', 'Germany');
INSERT INTO "ORDERS" VALUES ('10609', 'DUMON', '7', TO_DATE('1997-07-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-07-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '1.85', 'Du monde entier', '67, rue des Cinquante Otages', 'Nantes', null, '44000', 'France');
INSERT INTO "ORDERS" VALUES ('10610', 'LAMAI', '8', TO_DATE('1997-07-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '26.78', 'La maison dAsie', '1 rue Alsace-Lorraine', 'Toulouse', null, '31000', 'France');
INSERT INTO "ORDERS" VALUES ('10611', 'WOLZA', '6', TO_DATE('1997-07-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '80.65', 'Wolski Zajazd', 'ul. Filtrowa 68', 'Warszawa', null, '01-012', 'Poland');
INSERT INTO "ORDERS" VALUES ('10612', 'SAVEA', '1', TO_DATE('1997-07-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '544.08', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10613', 'HILAA', '4', TO_DATE('1997-07-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '8.11', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10614', 'BLAUS', '8', TO_DATE('1997-07-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '1.93', 'Blauer See Delikatessen', 'Forsterstr. 57', 'Mannheim', null, '68306', 'Germany');
INSERT INTO "ORDERS" VALUES ('10615', 'WILMK', '2', TO_DATE('1997-07-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '0.75', 'Wilman Kala', 'Keskuskatu 45', 'Helsinki', null, '21240', 'Finland');
INSERT INTO "ORDERS" VALUES ('10616', 'GREAL', '1', TO_DATE('1997-07-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '116.53', 'Great Lakes Food Market', '2732 Baker Blvd.', 'Eugene', 'OR', '97403', 'USA');
INSERT INTO "ORDERS" VALUES ('10617', 'GREAL', '4', TO_DATE('1997-07-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '18.53', 'Great Lakes Food Market', '2732 Baker Blvd.', 'Eugene', 'OR', '97403', 'USA');
INSERT INTO "ORDERS" VALUES ('10618', 'MEREP', '1', TO_DATE('1997-08-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '154.68', 'M猫re Paillarde', '43 rue St. Laurent', 'Montr茅al', 'Qu茅bec', 'H1J 1C3', 'Canada');
INSERT INTO "ORDERS" VALUES ('10619', 'MEREP', '3', TO_DATE('1997-08-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '91.05', 'M猫re Paillarde', '43 rue St. Laurent', 'Montr茅al', 'Qu茅bec', 'H1J 1C3', 'Canada');
INSERT INTO "ORDERS" VALUES ('10620', 'LAUGB', '2', TO_DATE('1997-08-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '0.94', 'Laughing Bacchus Wine Cellars', '2319 Elm St.', 'Vancouver', 'BC', 'V3F 2K1', 'Canada');
INSERT INTO "ORDERS" VALUES ('10621', 'ISLAT', '4', TO_DATE('1997-08-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '23.73', 'Island Trading', 'Garden House Crowther Way', 'Cowes', 'Isle of Wight', 'PO31 7PJ', 'UK');
INSERT INTO "ORDERS" VALUES ('10622', 'RICAR', '4', TO_DATE('1997-08-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '50.97', 'Ricardo Adocicados', 'Av. Copacabana, 267', 'Rio de Janeiro', 'RJ', '02389-890', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10623', 'FRANK', '8', TO_DATE('1997-08-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '97.18', 'Frankenversand', 'Berliner Platz 43', 'M眉nchen', null, '80805', 'Germany');
INSERT INTO "ORDERS" VALUES ('10624', 'THECR', '4', TO_DATE('1997-08-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '94.80', 'The Cracker Box', '55 Grizzly Peak Rd.', 'Butte', 'MT', '59801', 'USA');
INSERT INTO "ORDERS" VALUES ('10625', 'ANATR', '3', TO_DATE('1997-08-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '43.90', 'Ana Trujillo Emparedados y helados', 'Avda. de la Constituci贸n 2222', 'M茅xico D.F.', null, '05021', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10626', 'BERGS', '1', TO_DATE('1997-08-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '138.69', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10627', 'SAVEA', '8', TO_DATE('1997-08-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '107.46', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10628', 'BLONP', '4', TO_DATE('1997-08-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '30.36', 'Blondel p猫re et fils', '24, place Kl茅ber', 'Strasbourg', null, '67000', 'France');
INSERT INTO "ORDERS" VALUES ('10629', 'GODOS', '4', TO_DATE('1997-08-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '85.46', 'Godos Cocina T铆pica', 'C/ Romero, 33', 'Sevilla', null, '41101', 'Spain');
INSERT INTO "ORDERS" VALUES ('10630', 'KOENE', '1', TO_DATE('1997-08-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '32.35', 'K枚niglich Essen', 'Maubelstr. 90', 'Brandenburg', null, '14776', 'Germany');
INSERT INTO "ORDERS" VALUES ('10631', 'LAMAI', '8', TO_DATE('1997-08-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '0.87', 'La maison dAsie', '1 rue Alsace-Lorraine', 'Toulouse', null, '31000', 'France');
INSERT INTO "ORDERS" VALUES ('10632', 'WANDK', '8', TO_DATE('1997-08-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '41.38', 'Die Wandernde Kuh', 'Adenauerallee 900', 'Stuttgart', null, '70563', 'Germany');
INSERT INTO "ORDERS" VALUES ('10633', 'ERNSH', '7', TO_DATE('1997-08-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '477.90', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10634', 'FOLIG', '4', TO_DATE('1997-08-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '487.38', 'Folies gourmandes', '184, chauss茅e de Tournai', 'Lille', null, '59000', 'France');
INSERT INTO "ORDERS" VALUES ('10635', 'MAGAA', '8', TO_DATE('1997-08-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '47.46', 'Magazzini Alimentari Riuniti', 'Via Ludovico il Moro 22', 'Bergamo', null, '24100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10636', 'WARTH', '4', TO_DATE('1997-08-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '1.15', 'Wartian Herkku', 'Torikatu 38', 'Oulu', null, '90110', 'Finland');
INSERT INTO "ORDERS" VALUES ('10637', 'QUEEN', '6', TO_DATE('1997-08-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '201.29', 'Queen Cozinha', 'Alameda dos Can脿rios, 891', 'Sao Paulo', 'SP', '05487-020', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10638', 'LINOD', '3', TO_DATE('1997-08-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '158.44', 'LINO-Delicateses', 'Ave. 5 de Mayo Porlamar', 'I. de Margarita', 'Nueva Esparta', '4980', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10639', 'SANTG', '7', TO_DATE('1997-08-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '38.64', 'Sant茅 Gourmet', 'Erling Skakkes gate 78', 'Stavern', null, '4110', 'Norway');
INSERT INTO "ORDERS" VALUES ('10640', 'WANDK', '4', TO_DATE('1997-08-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '23.55', 'Die Wandernde Kuh', 'Adenauerallee 900', 'Stuttgart', null, '70563', 'Germany');
INSERT INTO "ORDERS" VALUES ('10641', 'HILAA', '4', TO_DATE('1997-08-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '179.61', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10642', 'SIMOB', '7', TO_DATE('1997-08-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '41.89', 'Simons bistro', 'Vinb忙ltet 34', 'Kobenhavn', null, '1734', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10643', 'ALFKI', '6', TO_DATE('1997-08-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '29.46', 'Alfreds Futterkiste', 'Obere Str. 57', 'Berlin', null, '12209', 'Germany');
INSERT INTO "ORDERS" VALUES ('10644', 'WELLI', '3', TO_DATE('1997-08-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '0.14', 'Wellington Importadora', 'Rua do Mercado, 12', 'Resende', 'SP', '08737-363', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10645', 'HANAR', '4', TO_DATE('1997-08-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '12.41', 'Hanari Carnes', 'Rua do Pa莽o, 67', 'Rio de Janeiro', 'RJ', '05454-876', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10646', 'HUNGO', '9', TO_DATE('1997-08-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '142.33', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10647', 'QUEDE', '4', TO_DATE('1997-08-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '45.54', 'Que Del铆cia', 'Rua da Panificadora, 12', 'Rio de Janeiro', 'RJ', '02389-673', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10648', 'RICAR', '5', TO_DATE('1997-08-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '14.25', 'Ricardo Adocicados', 'Av. Copacabana, 267', 'Rio de Janeiro', 'RJ', '02389-890', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10649', 'MAISD', '5', TO_DATE('1997-08-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-08-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '6.20', 'Maison Dewey', 'Rue Joseph-Bens 532', 'Bruxelles', null, 'B-1180', 'Belgium');
INSERT INTO "ORDERS" VALUES ('10650', 'FAMIA', '5', TO_DATE('1997-08-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '176.81', 'Familia Arquibaldo', 'Rua Or贸s, 92', 'Sao Paulo', 'SP', '05442-030', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10651', 'WANDK', '8', TO_DATE('1997-09-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '20.60', 'Die Wandernde Kuh', 'Adenauerallee 900', 'Stuttgart', null, '70563', 'Germany');
INSERT INTO "ORDERS" VALUES ('10652', 'GOURL', '4', TO_DATE('1997-09-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '7.14', 'Gourmet Lanchonetes', 'Av. Brasil, 442', 'Campinas', 'SP', '04876-786', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10653', 'FRANK', '1', TO_DATE('1997-09-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '93.25', 'Frankenversand', 'Berliner Platz 43', 'M眉nchen', null, '80805', 'Germany');
INSERT INTO "ORDERS" VALUES ('10654', 'BERGS', '5', TO_DATE('1997-09-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '55.26', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10655', 'REGGC', '1', TO_DATE('1997-09-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '4.41', 'Reggiani Caseifici', 'Strada Provinciale 124', 'Reggio Emilia', null, '42100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10656', 'GREAL', '6', TO_DATE('1997-09-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '57.15', 'Great Lakes Food Market', '2732 Baker Blvd.', 'Eugene', 'OR', '97403', 'USA');
INSERT INTO "ORDERS" VALUES ('10657', 'SAVEA', '2', TO_DATE('1997-09-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '352.69', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10658', 'QUICK', '4', TO_DATE('1997-09-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '364.15', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10659', 'QUEEN', '7', TO_DATE('1997-09-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '105.81', 'Queen Cozinha', 'Alameda dos Can脿rios, 891', 'Sao Paulo', 'SP', '05487-020', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10660', 'HUNGC', '8', TO_DATE('1997-09-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '111.29', 'Hungry Coyote Import Store', 'City Center Plaza 516 Main St.', 'Elgin', 'OR', '97827', 'USA');
INSERT INTO "ORDERS" VALUES ('10661', 'HUNGO', '7', TO_DATE('1997-09-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '17.55', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10662', 'LONEP', '3', TO_DATE('1997-09-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '1.28', 'Lonesome Pine Restaurant', '89 Chiaroscuro Rd.', 'Portland', 'OR', '97219', 'USA');
INSERT INTO "ORDERS" VALUES ('10663', 'BONAP', '2', TO_DATE('1997-09-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '113.15', 'Bon app', '12, rue des Bouchers', 'Marseille', null, '13008', 'France');
INSERT INTO "ORDERS" VALUES ('10664', 'FURIB', '1', TO_DATE('1997-09-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '1.27', 'Furia Bacalhau e Frutos do Mar', 'Jardim das rosas n. 32', 'Lisboa', null, '1675', 'Portugal');
INSERT INTO "ORDERS" VALUES ('10665', 'LONEP', '1', TO_DATE('1997-09-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '26.31', 'Lonesome Pine Restaurant', '89 Chiaroscuro Rd.', 'Portland', 'OR', '97219', 'USA');
INSERT INTO "ORDERS" VALUES ('10666', 'RICSU', '7', TO_DATE('1997-09-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '232.42', 'Richter Supermarkt', 'Starenweg 5', 'Gen猫ve', null, '1204', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('10667', 'ERNSH', '7', TO_DATE('1997-09-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '78.09', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10668', 'WANDK', '1', TO_DATE('1997-09-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '47.22', 'Die Wandernde Kuh', 'Adenauerallee 900', 'Stuttgart', null, '70563', 'Germany');
INSERT INTO "ORDERS" VALUES ('10669', 'SIMOB', '2', TO_DATE('1997-09-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '24.39', 'Simons bistro', 'Vinb忙ltet 34', 'Kobenhavn', null, '1734', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10670', 'FRANK', '4', TO_DATE('1997-09-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '203.48', 'Frankenversand', 'Berliner Platz 43', 'M眉nchen', null, '80805', 'Germany');
INSERT INTO "ORDERS" VALUES ('10671', 'FRANR', '1', TO_DATE('1997-09-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '30.34', 'France restauration', '54, rue Royale', 'Nantes', null, '44000', 'France');
INSERT INTO "ORDERS" VALUES ('10672', 'BERGS', '9', TO_DATE('1997-09-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '95.75', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10673', 'WILMK', '2', TO_DATE('1997-09-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '22.76', 'Wilman Kala', 'Keskuskatu 45', 'Helsinki', null, '21240', 'Finland');
INSERT INTO "ORDERS" VALUES ('10674', 'ISLAT', '4', TO_DATE('1997-09-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '0.90', 'Island Trading', 'Garden House Crowther Way', 'Cowes', 'Isle of Wight', 'PO31 7PJ', 'UK');
INSERT INTO "ORDERS" VALUES ('10675', 'FRANK', '5', TO_DATE('1997-09-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '31.85', 'Frankenversand', 'Berliner Platz 43', 'M眉nchen', null, '80805', 'Germany');
INSERT INTO "ORDERS" VALUES ('10676', 'TORTU', '2', TO_DATE('1997-09-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '2.01', 'Tortuga Restaurante', 'Avda. Azteca 123', 'M茅xico D.F.', null, '05033', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10677', 'ANTON', '1', TO_DATE('1997-09-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '4.03', 'Antonio Moreno Taquer铆a', 'Mataderos  2312', 'M茅xico D.F.', null, '05023', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10678', 'SAVEA', '7', TO_DATE('1997-09-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '388.98', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10679', 'BLONP', '8', TO_DATE('1997-09-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '27.94', 'Blondel p猫re et fils', '24, place Kl茅ber', 'Strasbourg', null, '67000', 'France');
INSERT INTO "ORDERS" VALUES ('10680', 'OLDWO', '1', TO_DATE('1997-09-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '26.61', 'Old World Delicatessen', '2743 Bering St.', 'Anchorage', 'AK', '99508', 'USA');
INSERT INTO "ORDERS" VALUES ('10681', 'GREAL', '3', TO_DATE('1997-09-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '76.13', 'Great Lakes Food Market', '2732 Baker Blvd.', 'Eugene', 'OR', '97403', 'USA');
INSERT INTO "ORDERS" VALUES ('10682', 'ANTON', '3', TO_DATE('1997-09-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '36.13', 'Antonio Moreno Taquer铆a', 'Mataderos  2312', 'M茅xico D.F.', null, '05023', 'Mexico');
INSERT INTO "ORDERS" VALUES ('10683', 'DUMON', '2', TO_DATE('1997-09-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '4.40', 'Du monde entier', '67, rue des Cinquante Otages', 'Nantes', null, '44000', 'France');
INSERT INTO "ORDERS" VALUES ('10684', 'OTTIK', '3', TO_DATE('1997-09-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-09-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '145.63', 'Ottilies K盲seladen', 'Mehrheimerstr. 369', 'K枚ln', null, '50739', 'Germany');
INSERT INTO "ORDERS" VALUES ('10685', 'GOURL', '4', TO_DATE('1997-09-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '33.75', 'Gourmet Lanchonetes', 'Av. Brasil, 442', 'Campinas', 'SP', '04876-786', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10686', 'PICCO', '2', TO_DATE('1997-09-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '96.50', 'Piccolo und mehr', 'Geislweg 14', 'Salzburg', null, '5020', 'Austria');
INSERT INTO "ORDERS" VALUES ('10687', 'HUNGO', '9', TO_DATE('1997-09-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '296.43', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10688', 'VAFFE', '4', TO_DATE('1997-10-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '299.09', 'Vaffeljernet', 'Smagsloget 45', '脜rhus', null, '8200', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10689', 'BERGS', '1', TO_DATE('1997-10-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '13.42', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10690', 'HANAR', '1', TO_DATE('1997-10-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '15.80', 'Hanari Carnes', 'Rua do Pa莽o, 67', 'Rio de Janeiro', 'RJ', '05454-876', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10691', 'QUICK', '2', TO_DATE('1997-10-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '810.05', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10692', 'ALFKI', '4', TO_DATE('1997-10-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '61.02', 'Alfreds Futterkiste', 'Obere Str. 57', 'Berlin', null, '12209', 'Germany');
INSERT INTO "ORDERS" VALUES ('10693', 'WHITC', '3', TO_DATE('1997-10-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '139.34', 'White Clover Markets', '1029 - 12th Ave. S.', 'Seattle', 'WA', '98124', 'USA');
INSERT INTO "ORDERS" VALUES ('10694', 'QUICK', '8', TO_DATE('1997-10-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '398.36', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10695', 'WILMK', '7', TO_DATE('1997-10-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '16.72', 'Wilman Kala', 'Keskuskatu 45', 'Helsinki', null, '21240', 'Finland');
INSERT INTO "ORDERS" VALUES ('10696', 'WHITC', '8', TO_DATE('1997-10-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '102.55', 'White Clover Markets', '1029 - 12th Ave. S.', 'Seattle', 'WA', '98124', 'USA');
INSERT INTO "ORDERS" VALUES ('10697', 'LINOD', '3', TO_DATE('1997-10-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '45.52', 'LINO-Delicateses', 'Ave. 5 de Mayo Porlamar', 'I. de Margarita', 'Nueva Esparta', '4980', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10698', 'ERNSH', '4', TO_DATE('1997-10-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '272.47', 'Ernst Handel', 'Kirchgasse 6', 'Graz', null, '8010', 'Austria');
INSERT INTO "ORDERS" VALUES ('10699', 'MORGK', '3', TO_DATE('1997-10-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '0.58', 'Morgenstern Gesundkost', 'Heerstr. 22', 'Leipzig', null, '04179', 'Germany');
INSERT INTO "ORDERS" VALUES ('10700', 'SAVEA', '3', TO_DATE('1997-10-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '65.10', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10701', 'HUNGO', '6', TO_DATE('1997-10-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '220.31', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10702', 'ALFKI', '4', TO_DATE('1997-10-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '23.94', 'Alfreds Futterkiste', 'Obere Str. 57', 'Berlin', null, '12209', 'Germany');
INSERT INTO "ORDERS" VALUES ('10703', 'FOLKO', '6', TO_DATE('1997-10-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '152.30', 'Folk och f盲 HB', '脜kergatan 24', 'Br盲cke', null, 'S-844 67', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10704', 'QUEEN', '6', TO_DATE('1997-10-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '4.78', 'Queen Cozinha', 'Alameda dos Can脿rios, 891', 'Sao Paulo', 'SP', '05487-020', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10705', 'HILAA', '9', TO_DATE('1997-10-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '3.52', 'HILARION-Abastos', 'Carrera 22 con Ave. Carlos Soublette #8-35', 'San Crist贸bal', 'T谩chira', '5022', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10706', 'OLDWO', '8', TO_DATE('1997-10-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '135.63', 'Old World Delicatessen', '2743 Bering St.', 'Anchorage', 'AK', '99508', 'USA');
INSERT INTO "ORDERS" VALUES ('10707', 'AROUT', '4', TO_DATE('1997-10-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '21.74', 'Around the Horn', 'Brook Farm Stratford St. Mary', 'Colchester', 'Essex', 'CO7 6JX', 'UK');
INSERT INTO "ORDERS" VALUES ('10708', 'THEBI', '6', TO_DATE('1997-10-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '2.96', 'The Big Cheese', '89 Jefferson Way Suite 2', 'Portland', 'OR', '97201', 'USA');
INSERT INTO "ORDERS" VALUES ('10709', 'GOURL', '1', TO_DATE('1997-10-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '210.80', 'Gourmet Lanchonetes', 'Av. Brasil, 442', 'Campinas', 'SP', '04876-786', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10710', 'FRANS', '1', TO_DATE('1997-10-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '4.98', 'Franchi S.p.A.', 'Via Monte Bianco 34', 'Torino', null, '10100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10711', 'SAVEA', '5', TO_DATE('1997-10-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '52.41', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10712', 'HUNGO', '3', TO_DATE('1997-10-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '89.93', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10713', 'SAVEA', '1', TO_DATE('1997-10-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '167.05', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10714', 'SAVEA', '5', TO_DATE('1997-10-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '24.49', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10715', 'BONAP', '3', TO_DATE('1997-10-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '63.20', 'Bon app', '12, rue des Bouchers', 'Marseille', null, '13008', 'France');
INSERT INTO "ORDERS" VALUES ('10716', 'RANCH', '4', TO_DATE('1997-10-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '22.57', 'Rancho grande', 'Av. del Libertador 900', 'Buenos Aires', null, '1010', 'Argentina');
INSERT INTO "ORDERS" VALUES ('10717', 'FRANK', '1', TO_DATE('1997-10-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '59.25', 'Frankenversand', 'Berliner Platz 43', 'M眉nchen', null, '80805', 'Germany');
INSERT INTO "ORDERS" VALUES ('10718', 'KOENE', '1', TO_DATE('1997-10-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '170.88', 'K枚niglich Essen', 'Maubelstr. 90', 'Brandenburg', null, '14776', 'Germany');
INSERT INTO "ORDERS" VALUES ('10719', 'LETSS', '8', TO_DATE('1997-10-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '51.44', 'Lets Stop N Shop', '87 Polk St. Suite 5', 'San Francisco', 'CA', '94117', 'USA');
INSERT INTO "ORDERS" VALUES ('10720', 'QUEDE', '8', TO_DATE('1997-10-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '9.53', 'Que Del铆cia', 'Rua da Panificadora, 12', 'Rio de Janeiro', 'RJ', '02389-673', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10721', 'QUICK', '5', TO_DATE('1997-10-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-10-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '48.92', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10722', 'SAVEA', '8', TO_DATE('1997-10-29 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '74.58', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10723', 'WHITC', '3', TO_DATE('1997-10-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '21.72', 'White Clover Markets', '1029 - 12th Ave. S.', 'Seattle', 'WA', '98124', 'USA');
INSERT INTO "ORDERS" VALUES ('10724', 'MEREP', '8', TO_DATE('1997-10-30 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '57.75', 'M猫re Paillarde', '43 rue St. Laurent', 'Montr茅al', 'Qu茅bec', 'H1J 1C3', 'Canada');
INSERT INTO "ORDERS" VALUES ('10725', 'FAMIA', '4', TO_DATE('1997-10-31 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '10.83', 'Familia Arquibaldo', 'Rua Or贸s, 92', 'Sao Paulo', 'SP', '05442-030', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10726', 'EASTC', '4', TO_DATE('1997-11-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '16.56', 'Eastern Connection', '35 King George', 'London', null, 'WX3 6FW', 'UK');
INSERT INTO "ORDERS" VALUES ('10727', 'REGGC', '2', TO_DATE('1997-11-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-01 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '89.90', 'Reggiani Caseifici', 'Strada Provinciale 124', 'Reggio Emilia', null, '42100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10728', 'QUEEN', '4', TO_DATE('1997-11-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '58.33', 'Queen Cozinha', 'Alameda dos Can脿rios, 891', 'Sao Paulo', 'SP', '05487-020', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10729', 'LINOD', '8', TO_DATE('1997-11-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '141.06', 'LINO-Delicateses', 'Ave. 5 de Mayo Porlamar', 'I. de Margarita', 'Nueva Esparta', '4980', 'Venezuela');
INSERT INTO "ORDERS" VALUES ('10730', 'BONAP', '5', TO_DATE('1997-11-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '20.12', 'Bon app', '12, rue des Bouchers', 'Marseille', null, '13008', 'France');
INSERT INTO "ORDERS" VALUES ('10731', 'CHOPS', '7', TO_DATE('1997-11-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '96.65', 'Chop-suey Chinese', 'Hauptstr. 31', 'Bern', null, '3012', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('10732', 'BONAP', '3', TO_DATE('1997-11-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-04 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '16.97', 'Bon app', '12, rue des Bouchers', 'Marseille', null, '13008', 'France');
INSERT INTO "ORDERS" VALUES ('10733', 'BERGS', '1', TO_DATE('1997-11-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '110.11', 'Berglunds snabbk枚p', 'Berguvsv盲gen  8', 'Lule氓', null, 'S-958 22', 'Sweden');
INSERT INTO "ORDERS" VALUES ('10734', 'GOURL', '2', TO_DATE('1997-11-07 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-05 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '1.63', 'Gourmet Lanchonetes', 'Av. Brasil, 442', 'Campinas', 'SP', '04876-786', 'Brazil');
INSERT INTO "ORDERS" VALUES ('10735', 'LETSS', '6', TO_DATE('1997-11-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-08 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '45.97', 'Lets Stop N Shop', '87 Polk St. Suite 5', 'San Francisco', 'CA', '94117', 'USA');
INSERT INTO "ORDERS" VALUES ('10736', 'HUNGO', '9', TO_DATE('1997-11-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '44.10', 'Hungry Owl All-Night Grocers', '8 Johnstown Road', 'Cork', 'Co. Cork', null, 'Ireland');
INSERT INTO "ORDERS" VALUES ('10737', 'VINET', '2', TO_DATE('1997-11-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-09 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '7.79', 'Vins et alcools Chevalier', '59 rue de lAbbaye', 'Reims', null, '51100', 'France');
INSERT INTO "ORDERS" VALUES ('10738', 'SPECD', '2', TO_DATE('1997-11-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '2.91', 'Sp茅cialit茅s du monde', '25, rue Lauriston', 'Paris', null, '75016', 'France');
INSERT INTO "ORDERS" VALUES ('10739', 'VINET', '3', TO_DATE('1997-11-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-10 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '11.08', 'Vins et alcools Chevalier', '59 rue de lAbbaye', 'Reims', null, '51100', 'France');
INSERT INTO "ORDERS" VALUES ('10740', 'WHITC', '4', TO_DATE('1997-11-13 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-11 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '81.88', 'White Clover Markets', '1029 - 12th Ave. S.', 'Seattle', 'WA', '98124', 'USA');
INSERT INTO "ORDERS" VALUES ('10741', 'AROUT', '4', TO_DATE('1997-11-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '10.96', 'Around the Horn', 'Brook Farm Stratford St. Mary', 'Colchester', 'Essex', 'CO7 6JX', 'UK');
INSERT INTO "ORDERS" VALUES ('10742', 'BOTTM', '3', TO_DATE('1997-11-14 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-12 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '243.73', 'Bottom-Dollar Markets', '23 Tsawassen Blvd.', 'Tsawassen', 'BC', 'T2F 8M4', 'Canada');
INSERT INTO "ORDERS" VALUES ('10743', 'AROUT', '1', TO_DATE('1997-11-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '23.72', 'Around the Horn', 'Brook Farm Stratford St. Mary', 'Colchester', 'Essex', 'CO7 6JX', 'UK');
INSERT INTO "ORDERS" VALUES ('10744', 'VAFFE', '6', TO_DATE('1997-11-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-15 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '69.19', 'Vaffeljernet', 'Smagsloget 45', '脜rhus', null, '8200', 'Denmark');
INSERT INTO "ORDERS" VALUES ('10745', 'QUICK', '9', TO_DATE('1997-11-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-16 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '3.52', 'QUICK-Stop', 'Taucherstra脽e 10', 'Cunewalde', null, '01307', 'Germany');
INSERT INTO "ORDERS" VALUES ('10746', 'CHOPS', '1', TO_DATE('1997-11-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '31.43', 'Chop-suey Chinese', 'Hauptstr. 31', 'Bern', null, '3012', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('10747', 'PICCO', '6', TO_DATE('1997-11-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-17 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '117.33', 'Piccolo und mehr', 'Geislweg 14', 'Salzburg', null, '5020', 'Austria');
INSERT INTO "ORDERS" VALUES ('10748', 'SAVEA', '3', TO_DATE('1997-11-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '232.55', 'Save-a-lot Markets', '187 Suffolk Ln.', 'Boise', 'ID', '83720', 'USA');
INSERT INTO "ORDERS" VALUES ('10749', 'ISLAT', '4', TO_DATE('1997-11-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '61.53', 'Island Trading', 'Garden House Crowther Way', 'Cowes', 'Isle of Wight', 'PO31 7PJ', 'UK');
INSERT INTO "ORDERS" VALUES ('10750', 'WARTH', '9', TO_DATE('1997-11-21 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '79.30', 'Wartian Herkku', 'Torikatu 38', 'Oulu', null, '90110', 'Finland');
INSERT INTO "ORDERS" VALUES ('10751', 'RICSU', '3', TO_DATE('1997-11-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '130.79', 'Richter Supermarkt', 'Starenweg 5', 'Gen猫ve', null, '1204', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('10752', 'NORTS', '2', TO_DATE('1997-11-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-22 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '1.39', 'North/South', 'South House 300 Queensbridge', 'London', null, 'SW7 1RZ', 'UK');
INSERT INTO "ORDERS" VALUES ('10753', 'FRANS', '3', TO_DATE('1997-11-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '7.70', 'Franchi S.p.A.', 'Via Monte Bianco 34', 'Torino', null, '10100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10754', 'MAGAA', '6', TO_DATE('1997-11-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-23 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '3', '2.38', 'Magazzini Alimentari Riuniti', 'Via Ludovico il Moro 22', 'Bergamo', null, '24100', 'Italy');
INSERT INTO "ORDERS" VALUES ('10755', 'BONAP', '4', TO_DATE('1997-11-26 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-24 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-11-28 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '16.71', 'Bon app', '12, rue des Bouchers', 'Marseille', null, '13008', 'France');
INSERT INTO "ORDERS" VALUES ('10756', 'SPLIR', '8', TO_DATE('1997-11-27 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-25 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1997-12-02 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '2', '73.21', 'Split Rail Beer 1', 'P.O. Box 555', 'Lander', 'WY', '82520', 'USA');
INSERT INTO "ORDERS" VALUES ('11075', 'RICSU', '8', TO_DATE('1998-05-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-06-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '2', '6.19', 'Richter Supermarkt', 'Starenweg 5', 'Gen猫ve', null, '1204', 'Switzerland');
INSERT INTO "ORDERS" VALUES ('11076', 'BONAP', '4', TO_DATE('1998-05-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-06-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '2', '38.28', 'Bon app', '12, rue des Bouchers', 'Marseille', null, '13008', 'France');
INSERT INTO "ORDERS" VALUES ('11077', 'RATTC', '1', TO_DATE('1998-05-06 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('1998-06-03 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), null, '2', '8.53', 'Rattlesnake Canyon Grocery', '2817 Milton Dr.', 'Albuquerque', 'NM', '87110', 'USA');

-- ----------------------------
-- Table structure for PRODUCTS
-- ----------------------------
--DROP TABLE "PRODUCTS";
CREATE TABLE "PRODUCTS" (
"PRODUCTID" NUMBER(38) NOT NULL ,
"PRODUCTNAME" VARCHAR2(40 BYTE) NOT NULL ,
"SUPPLIERID" NUMBER(38) DEFAULT NULL  NULL ,
"CATEGORYID" NUMBER(38) DEFAULT NULL  NULL ,
"QUANTITYPERUNIT" VARCHAR2(20 BYTE) DEFAULT NULL  NULL ,
"UNITPRICE" NUMBER(19,4) DEFAULT NULL  NULL ,
"UNITSINSTOCK" NUMBER(38) DEFAULT NULL  NULL ,
"UNITSONORDER" NUMBER(38) DEFAULT NULL  NULL ,
"REORDERLEVEL" NUMBER(38) DEFAULT NULL  NULL ,
"DISCONTINUED" NUMBER(38) NOT NULL 
)
LOGGING
NOCOMPRESS
NOCACHE

;

-- ----------------------------
-- Records of PRODUCTS
-- ----------------------------
INSERT INTO "PRODUCTS" VALUES ('1', 'Chai', '1', '1', '10 boxes x 20 bags', '18', '39', '0', '10', '0');
INSERT INTO "PRODUCTS" VALUES ('2', 'Chang', '1', '1', '24 - 12 oz bottles', '19', '17', '40', '25', '0');
INSERT INTO "PRODUCTS" VALUES ('3', 'Aniseed Syrup', '1', '2', '12 - 550 ml bottles', '10', '13', '70', '25', '0');
INSERT INTO "PRODUCTS" VALUES ('4', 'Chef Antons Cajun Seasoning', '2', '2', '48 - 6 oz jars', '22', '53', '0', '0', '0');
INSERT INTO "PRODUCTS" VALUES ('5', 'Chef Antons Gumbo Mix', '2', '2', '36 boxes', '21.35', '0', '0', '0', '1');
INSERT INTO "PRODUCTS" VALUES ('6', 'Grandmas Boysenberry Spread', '3', '2', '12 - 8 oz jars', '25', '120', '0', '25', '0');
INSERT INTO "PRODUCTS" VALUES ('7', 'Uncle Bobs Organic Dried Pears', '3', '7', '12 - 1 lb pkgs.', '30', '15', '0', '10', '0');
INSERT INTO "PRODUCTS" VALUES ('8', 'Northwoods Cranberry Sauce', '3', '2', '12 - 12 oz jars', '40', '6', '0', '0', '0');
INSERT INTO "PRODUCTS" VALUES ('9', 'Mishi Kobe Niku', '4', '6', '18 - 500 g pkgs.', '97', '29', '0', '0', '1');
INSERT INTO "PRODUCTS" VALUES ('10', 'Ikura', '4', '8', '12 - 200 ml jars', '31', '31', '0', '0', '0');
INSERT INTO "PRODUCTS" VALUES ('11', 'Queso Cabrales', '5', '4', '1 kg pkg.', '21', '22', '30', '30', '0');
INSERT INTO "PRODUCTS" VALUES ('12', 'Queso Manchego La Pastora', '5', '4', '10 - 500 g pkgs.', '38', '86', '0', '0', '0');
INSERT INTO "PRODUCTS" VALUES ('13', 'Konbu', '6', '8', '2 kg box', '6', '24', '0', '5', '0');
INSERT INTO "PRODUCTS" VALUES ('14', 'Tofu', '6', '7', '40 - 100 g pkgs.', '23.25', '35', '0', '0', '0');
INSERT INTO "PRODUCTS" VALUES ('15', 'Genen Shouyu', '6', '2', '24 - 250 ml bottles', '15.50', '39', '0', '5', '0');
INSERT INTO "PRODUCTS" VALUES ('16', 'Pavlova', '7', '3', '32 - 500 g boxes', '17.45', '29', '0', '10', '0');
INSERT INTO "PRODUCTS" VALUES ('17', 'Alice Mutton', '7', '6', '20 - 1 kg tins', '39', '0', '0', '0', '1');
INSERT INTO "PRODUCTS" VALUES ('18', 'Carnarvon Tigers', '7', '8', '16 kg pkg.', '62.50', '42', '0', '0', '0');
INSERT INTO "PRODUCTS" VALUES ('19', 'Teatime Chocolate Biscuits', '8', '3', '10 boxes x 12 pieces', '9.20', '25', '0', '5', '0');
INSERT INTO "PRODUCTS" VALUES ('20', 'Sir Rodneys Marmalade', '8', '3', '30 gift boxes', '81', '40', '0', '0', '0');
INSERT INTO "PRODUCTS" VALUES ('21', 'Sir Rodneys Scones', '8', '3', '24 pkgs. x 4 pieces', '10', '3', '40', '5', '0');
INSERT INTO "PRODUCTS" VALUES ('22', 'Gustafs Kn盲ckebr枚d', '9', '5', '24 - 500 g pkgs.', '21', '104', '0', '25', '0');
INSERT INTO "PRODUCTS" VALUES ('23', 'Tunnbr枚d', '9', '5', '12 - 250 g pkgs.', '9', '61', '0', '25', '0');
INSERT INTO "PRODUCTS" VALUES ('24', 'Guaran谩 Fant谩stica', '10', '1', '12 - 355 ml cans', '4.50', '20', '0', '0', '1');
INSERT INTO "PRODUCTS" VALUES ('25', 'NuNuCa Nu脽-Nougat-Creme', '11', '3', '20 - 450 g glasses', '14', '76', '0', '30', '0');
INSERT INTO "PRODUCTS" VALUES ('26', 'Gumb盲r Gummib盲rchen', '11', '3', '100 - 250 g bags', '31.23', '15', '0', '0', '0');
INSERT INTO "PRODUCTS" VALUES ('27', 'Schoggi Schokolade', '11', '3', '100 - 100 g pieces', '43.90', '49', '0', '30', '0');
INSERT INTO "PRODUCTS" VALUES ('28', 'R枚ssle Sauerkraut', '12', '7', '25 - 825 g cans', '45.60', '26', '0', '0', '1');
INSERT INTO "PRODUCTS" VALUES ('29', 'Th眉ringer Rostbratwurst', '12', '6', '50 bags x 30 sausgs.', '123.79', '0', '0', '0', '1');
INSERT INTO "PRODUCTS" VALUES ('30', 'Nord-Ost Matjeshering', '13', '8', '10 - 200 g glasses', '25.89', '10', '0', '15', '0');
INSERT INTO "PRODUCTS" VALUES ('31', 'Gorgonzola Telino', '14', '4', '12 - 100 g pkgs', '12.50', '0', '70', '20', '0');
INSERT INTO "PRODUCTS" VALUES ('32', 'Mascarpone Fabioli', '14', '4', '24 - 200 g pkgs.', '32', '9', '40', '25', '0');
INSERT INTO "PRODUCTS" VALUES ('33', 'Geitost', '15', '4', '500 g', '2.50', '112', '0', '20', '0');
INSERT INTO "PRODUCTS" VALUES ('34', 'Sasquatch Ale', '16', '1', '24 - 12 oz bottles', '14', '111', '0', '15', '0');
INSERT INTO "PRODUCTS" VALUES ('35', 'Steeleye Stout', '16', '1', '24 - 12 oz bottles', '18', '20', '0', '15', '0');
INSERT INTO "PRODUCTS" VALUES ('36', 'Inlagd Sill', '17', '8', '24 - 250 g  jars', '19', '112', '0', '20', '0');
INSERT INTO "PRODUCTS" VALUES ('37', 'Gravad lax', '17', '8', '12 - 500 g pkgs.', '26', '11', '50', '25', '0');
INSERT INTO "PRODUCTS" VALUES ('38', 'C么te de Blaye', '18', '1', '12 - 75 cl bottles', '263.50', '17', '0', '15', '0');
INSERT INTO "PRODUCTS" VALUES ('39', 'Chartreuse verte', '18', '1', '750 cc per bottle', '18', '69', '0', '5', '0');
INSERT INTO "PRODUCTS" VALUES ('40', 'Boston Crab Meat', '19', '8', '24 - 4 oz tins', '18.40', '123', '0', '30', '0');
INSERT INTO "PRODUCTS" VALUES ('41', 'Jacks New England Clam Chowder', '19', '8', '12 - 12 oz cans', '9.65', '85', '0', '10', '0');
INSERT INTO "PRODUCTS" VALUES ('42', 'Singaporean Hokkien Fried Mee', '20', '5', '32 - 1 kg pkgs.', '14', '26', '0', '0', '1');
INSERT INTO "PRODUCTS" VALUES ('43', 'Ipoh Coffee', '20', '1', '16 - 500 g tins', '46', '17', '10', '25', '0');
INSERT INTO "PRODUCTS" VALUES ('44', 'Gula Malacca', '20', '2', '20 - 2 kg bags', '19.45', '27', '0', '15', '0');
INSERT INTO "PRODUCTS" VALUES ('45', 'Rogede sild', '21', '8', '1k pkg.', '9.50', '5', '70', '15', '0');
INSERT INTO "PRODUCTS" VALUES ('46', 'Spegesild', '21', '8', '4 - 450 g glasses', '12', '95', '0', '0', '0');
INSERT INTO "PRODUCTS" VALUES ('47', 'Zaanse koeken', '22', '3', '10 - 4 oz boxes', '9.50', '36', '0', '0', '0');
INSERT INTO "PRODUCTS" VALUES ('48', 'Chocolade', '22', '3', '10 pkgs.', '12.75', '15', '70', '25', '0');
INSERT INTO "PRODUCTS" VALUES ('49', 'Maxilaku', '23', '3', '24 - 50 g pkgs.', '20', '10', '60', '15', '0');
INSERT INTO "PRODUCTS" VALUES ('50', 'Valkoinen suklaa', '23', '3', '12 - 100 g bars', '16.25', '65', '0', '30', '0');
INSERT INTO "PRODUCTS" VALUES ('51', 'Manjimup Dried Apples', '24', '7', '50 - 300 g pkgs.', '53', '20', '0', '10', '0');
INSERT INTO "PRODUCTS" VALUES ('52', 'Filo Mix', '24', '5', '16 - 2 kg boxes', '7', '38', '0', '25', '0');
INSERT INTO "PRODUCTS" VALUES ('53', 'Perth Pasties', '24', '6', '48 pieces', '32.80', '0', '0', '0', '1');
INSERT INTO "PRODUCTS" VALUES ('54', 'Tourti猫re', '25', '6', '16 pies', '7.45', '21', '0', '10', '0');
INSERT INTO "PRODUCTS" VALUES ('55', 'P芒t茅 chinois', '25', '6', '24 boxes x 2 pies', '24', '115', '0', '20', '0');
INSERT INTO "PRODUCTS" VALUES ('56', 'Gnocchi di nonna Alice', '26', '5', '24 - 250 g pkgs.', '38', '21', '10', '30', '0');
INSERT INTO "PRODUCTS" VALUES ('57', 'Ravioli Angelo', '26', '5', '24 - 250 g pkgs.', '19.50', '36', '0', '20', '0');
INSERT INTO "PRODUCTS" VALUES ('58', 'Escargots de Bourgogne', '27', '8', '24 pieces', '13.25', '62', '0', '20', '0');
INSERT INTO "PRODUCTS" VALUES ('59', 'Raclette Courdavault', '28', '4', '5 kg pkg.', '55', '79', '0', '0', '0');
INSERT INTO "PRODUCTS" VALUES ('60', 'Camembert Pierrot', '28', '4', '15 - 300 g rounds', '34', '19', '0', '0', '0');
INSERT INTO "PRODUCTS" VALUES ('61', 'Sirop d茅rable', '29', '2', '24 - 500 ml bottles', '28.50', '113', '0', '25', '0');
INSERT INTO "PRODUCTS" VALUES ('62', 'Tarte au sucre', '29', '3', '48 pies', '49.30', '17', '0', '0', '0');
INSERT INTO "PRODUCTS" VALUES ('63', 'Vegie-spread', '7', '2', '15 - 625 g jars', '43.90', '24', '0', '5', '0');
INSERT INTO "PRODUCTS" VALUES ('64', 'Wimmers gute Semmelkn枚del', '12', '5', '20 bags x 4 pieces', '33.25', '22', '80', '30', '0');
INSERT INTO "PRODUCTS" VALUES ('65', 'Louisiana Fiery Hot Pepper Sauce', '2', '2', '32 - 8 oz bottles', '21.05', '76', '0', '0', '0');
INSERT INTO "PRODUCTS" VALUES ('66', 'Louisiana Hot Spiced Okra', '2', '2', '24 - 8 oz jars', '17', '4', '100', '20', '0');
INSERT INTO "PRODUCTS" VALUES ('67', 'Laughing Lumberjack Lager', '16', '1', '24 - 12 oz bottles', '14', '52', '0', '10', '0');
INSERT INTO "PRODUCTS" VALUES ('68', 'Scottish Longbreads', '8', '3', '10 boxes x 8 pieces', '12.50', '6', '10', '15', '0');
INSERT INTO "PRODUCTS" VALUES ('69', 'Gudbrandsdalsost', '15', '4', '10 kg pkg.', '36', '26', '0', '15', '0');
INSERT INTO "PRODUCTS" VALUES ('70', 'Outback Lager', '7', '1', '24 - 355 ml bottles', '15', '15', '10', '30', '0');
INSERT INTO "PRODUCTS" VALUES ('71', 'Flotemysost', '15', '4', '10 - 500 g pkgs.', '21.50', '26', '0', '0', '0');
INSERT INTO "PRODUCTS" VALUES ('72', 'Mozzarella di Giovanni', '14', '4', '24 - 200 g pkgs.', '34.80', '14', '0', '0', '0');
INSERT INTO "PRODUCTS" VALUES ('73', 'R枚d Kaviar', '17', '8', '24 - 150 g jars', '15', '101', '0', '5', '0');
INSERT INTO "PRODUCTS" VALUES ('74', 'Longlife Tofu', '4', '7', '5 kg pkg.', '10', '4', '20', '5', '0');
INSERT INTO "PRODUCTS" VALUES ('75', 'Rh枚nbr盲u Klosterbier', '12', '1', '24 - 0.5 l bottles', '7.75', '125', '0', '25', '0');
INSERT INTO "PRODUCTS" VALUES ('76', 'Lakkalik枚枚ri', '23', '1', '500 ml', '18', '57', '0', '20', '0');
INSERT INTO "PRODUCTS" VALUES ('77', 'Original Frankfurter gr眉ne So脽e', '12', '2', '12 boxes', '13', '32', '0', '15', '0');

-- ----------------------------
-- Table structure for REGION
-- ----------------------------
--DROP TABLE "REGION";
CREATE TABLE "REGION" (
"REGIONID" NUMBER(38) NOT NULL ,
"REGIONDESCRIPTION" CHAR(50 BYTE) NOT NULL 
)
LOGGING
NOCOMPRESS
NOCACHE

;

-- ----------------------------
-- Records of REGION
-- ----------------------------
INSERT INTO "REGION" VALUES ('1', 'Eastern                                           ');
INSERT INTO "REGION" VALUES ('2', 'Western                                           ');
INSERT INTO "REGION" VALUES ('3', 'Northern                                          ');
INSERT INTO "REGION" VALUES ('4', 'Southern                                          ');

-- ----------------------------
-- Table structure for SHIPPERS
-- ----------------------------
--DROP TABLE "SHIPPERS";
CREATE TABLE "SHIPPERS" (
"SHIPPERID" NUMBER(38) NOT NULL ,
"COMPANYNAME" VARCHAR2(40 BYTE) NOT NULL ,
"PHONE" VARCHAR2(24 BYTE) DEFAULT NULL  NULL 
)
LOGGING
NOCOMPRESS
NOCACHE

;

-- ----------------------------
-- Records of SHIPPERS
-- ----------------------------
INSERT INTO "SHIPPERS" VALUES ('1', 'Speedy Express', '(503) 555-9831');
INSERT INTO "SHIPPERS" VALUES ('2', 'United Package', '(503) 555-3199');
INSERT INTO "SHIPPERS" VALUES ('3', 'Federal Shipping', '(503) 555-9931');

-- ----------------------------
-- Table structure for SUPPLIERS
-- ----------------------------
--DROP TABLE "SUPPLIERS";
CREATE TABLE "SUPPLIERS" (
"SUPPLIERID" NUMBER(38) NOT NULL ,
"COMPANYNAME" VARCHAR2(40 BYTE) NOT NULL ,
"CONTACTNAME" VARCHAR2(30 BYTE) DEFAULT NULL  NULL ,
"CONTACTTITLE" VARCHAR2(30 BYTE) DEFAULT NULL  NULL ,
"ADDRESS" VARCHAR2(60 BYTE) DEFAULT NULL  NULL ,
"CITY" VARCHAR2(15 BYTE) DEFAULT NULL  NULL ,
"REGION" VARCHAR2(15 BYTE) DEFAULT NULL  NULL ,
"POSTALCODE" VARCHAR2(10 BYTE) DEFAULT NULL  NULL ,
"COUNTRY" VARCHAR2(15 BYTE) DEFAULT NULL  NULL ,
"PHONE" VARCHAR2(24 BYTE) DEFAULT NULL  NULL ,
"FAX" VARCHAR2(24 BYTE) DEFAULT NULL  NULL ,
"HOMEPAGE" CLOB NULL 
)
LOGGING
NOCOMPRESS
NOCACHE

;

-- ----------------------------
-- Records of SUPPLIERS
-- ----------------------------
INSERT INTO "SUPPLIERS" VALUES ('1', 'Exotic Liquids', 'Charlotte Cooper', 'Purchasing Manager', '49 Gilbert St.', 'London', null, 'EC1 4SD', 'UK', '(171) 555-2222', null, null);
INSERT INTO "SUPPLIERS" VALUES ('2', 'New Orleans Cajun Delights', 'Shelley Burke', 'Order Administrator', 'P.O. Box 78934', 'New Orleans', 'LA', '70117', 'USA', '(100) 555-4822', null, '#CAJUN.HTM#');
INSERT INTO "SUPPLIERS" VALUES ('3', 'Grandma Kellys Homestead', 'Regina Murphy', 'Sales Representative', '707 Oxford Rd.', 'Ann Arbor', 'MI', '48104', 'USA', '(313) 555-5735', '(313) 555-3349', null);
INSERT INTO "SUPPLIERS" VALUES ('4', 'Tokyo Traders', 'Yoshi Nagase', 'Marketing Manager', '9-8 Sekimai Musashino-shi', 'Tokyo', null, '100', 'Japan', '(03) 3555-5011', null, null);
INSERT INTO "SUPPLIERS" VALUES ('5', 'Cooperativa de Quesos Las Cabras', 'Antonio del Valle Saavedra', 'Export Administrator', 'Calle del Rosal 4', 'Oviedo', 'Asturias', '33007', 'Spain', '(98) 598 76 54', null, null);
INSERT INTO "SUPPLIERS" VALUES ('6', 'Mayumis', 'Mayumi Ohno', 'Marketing Representative', '92 Setsuko Chuo-ku', 'Osaka', null, '545', 'Japan', '(06) 431-7877', null, 'Mayumis (on the World Wide Web)#http://www.microsoft.com/accessdev/sampleapps/mayumi.htm#');
INSERT INTO "SUPPLIERS" VALUES ('7', 'Pavlova, Ltd.', 'Ian Devling', 'Marketing Manager', '74 Rose St. Moonie Ponds', 'Melbourne', 'Victoria', '3058', 'Australia', '(03) 444-2343', '(03) 444-6588', null);
INSERT INTO "SUPPLIERS" VALUES ('8', 'Specialty Biscuits, Ltd.', 'Peter Wilson', 'Sales Representative', '29 Kings Way', 'Manchester', null, 'M14 GSD', 'UK', '(161) 555-4448', null, null);
INSERT INTO "SUPPLIERS" VALUES ('9', 'PB Kn盲ckebr枚d AB', 'Lars Peterson', 'Sales Agent', 'Kaloadagatan 13', 'G枚teborg', null, 'S-345 67', 'Sweden', '031-987 65 43', '031-987 65 91', null);
INSERT INTO "SUPPLIERS" VALUES ('10', 'Refrescos Americanas LTDA', 'Carlos Diaz', 'Marketing Manager', 'Av. das Americanas 12.890', 'Sao Paulo', null, '5442', 'Brazil', '(11) 555 4640', null, null);
INSERT INTO "SUPPLIERS" VALUES ('11', 'Heli S眉脽waren GmbH & Co. KG', 'Petra Winkler', 'Sales Manager', 'Tiergartenstra脽e 5', 'Berlin', null, '10785', 'Germany', '(010) 9984510', null, null);
INSERT INTO "SUPPLIERS" VALUES ('12', 'Plutzer Lebensmittelgro脽m盲rkte AG', 'Martin Bein', 'International Marketing Mgr.', 'Bogenallee 51', 'Frankfurt', null, '60439', 'Germany', '(069) 992755', null, 'Plutzer (on the World Wide Web)#http://www.microsoft.com/accessdev/sampleapps/plutzer.htm#');
INSERT INTO "SUPPLIERS" VALUES ('13', 'Nord-Ost-Fisch Handelsgesellschaft mbH', 'Sven Petersen', 'Coordinator Foreign Markets', 'Frahmredder 112a', 'Cuxhaven', null, '27478', 'Germany', '(04721) 8713', '(04721) 8714', null);
INSERT INTO "SUPPLIERS" VALUES ('14', 'Formaggi Fortini s.r.l.', 'Elio Rossi', 'Sales Representative', 'Viale Dante, 75', 'Ravenna', null, '48100', 'Italy', '(0544) 60323', '(0544) 60603', '#FORMAGGI.HTM#');
INSERT INTO "SUPPLIERS" VALUES ('15', 'Norske Meierier', 'Beate Vileid', 'Marketing Manager', 'Hatlevegen 5', 'Sandvika', null, '1320', 'Norway', '(0)2-953010', null, null);
INSERT INTO "SUPPLIERS" VALUES ('16', 'Bigfoot Breweries', 'Cheryl Saylor', 'Regional Account Rep.', '3400 - 8th Avenue Suite 210', 'Bend', 'OR', '97101', 'USA', '(503) 555-9931', null, null);
INSERT INTO "SUPPLIERS" VALUES ('17', 'Svensk Sj枚f枚da AB', 'Michael Bj枚rn', 'Sales Representative', 'Brovallav盲gen 231', 'Stockholm', null, 'S-123 45', 'Sweden', '08-123 45 67', null, null);
INSERT INTO "SUPPLIERS" VALUES ('18', 'Aux joyeux eccl茅siastiques', 'Guyl猫ne Nodier', 'Sales Manager', '203, Rue des Francs-Bourgeois', 'Paris', null, '75004', 'France', '(1) 03.83.00.68', '(1) 03.83.00.62', null);
INSERT INTO "SUPPLIERS" VALUES ('19', 'New England Seafood Cannery', 'Robb Merchant', 'Wholesale Account Agent', 'Order Processing Dept. 2100 Paul Revere Blvd.', 'Boston', 'MA', '02134', 'USA', '(617) 555-3267', '(617) 555-3389', null);
INSERT INTO "SUPPLIERS" VALUES ('20', 'Leka Trading', 'Chandra Leka', 'Owner', '471 Serangoon Loop, Suite #402', 'Singapore', null, '0512', 'Singapore', '555-8787', null, null);
INSERT INTO "SUPPLIERS" VALUES ('21', 'Lyngbysild', 'Niels Petersen', 'Sales Manager', 'Lyngbysild Fiskebakken 10', 'Lyngby', null, '2800', 'Denmark', '43844108', '43844115', null);
INSERT INTO "SUPPLIERS" VALUES ('22', 'Zaanse Snoepfabriek', 'Dirk Luchte', 'Accounting Manager', 'Verkoop Rijnweg 22', 'Zaandam', null, '9999 ZZ', 'Netherlands', '(12345) 1212', '(12345) 1210', null);
INSERT INTO "SUPPLIERS" VALUES ('23', 'Karkki Oy', 'Anne Heikkonen', 'Product Manager', 'Valtakatu 12', 'Lappeenranta', null, '53120', 'Finland', '(953) 10956', null, null);
INSERT INTO "SUPPLIERS" VALUES ('24', 'Gday, Mate', 'Wendy Mackenzie', 'Sales Representative', '170 Prince Edward Parade Hunters Hill', 'Sydney', 'NSW', '2042', 'Australia', '(02) 555-5914', '(02) 555-4873', 'Gday Mate (on the World Wide Web)#http://www.microsoft.com/accessdev/sampleapps/gdaymate.htm#');
INSERT INTO "SUPPLIERS" VALUES ('25', 'Ma Maison', 'Jean-Guy Lauzon', 'Marketing Manager', '2960 Rue St. Laurent', 'Montr茅al', 'Qu茅bec', 'H1J 1C3', 'Canada', '(514) 555-9022', null, null);
INSERT INTO "SUPPLIERS" VALUES ('26', 'Pasta Buttini s.r.l.', 'Giovanni Giudici', 'Order Administrator', 'Via dei Gelsomini, 153', 'Salerno', null, '84100', 'Italy', '(089) 6547665', '(089) 6547667', null);
INSERT INTO "SUPPLIERS" VALUES ('27', 'Escargots Nouveaux', 'Marie Delamare', 'Sales Manager', '22, rue H. Voiron', 'Montceau', null, '71300', 'France', '85.57.00.07', null, null);
INSERT INTO "SUPPLIERS" VALUES ('28', 'Gai p芒turage', 'Eliane Noz', 'Sales Representative', 'Bat. B 3, rue des Alpes', 'Annecy', null, '74000', 'France', '38.76.98.06', '38.76.98.58', null);
INSERT INTO "SUPPLIERS" VALUES ('29', 'For锚ts d茅rables', 'Chantal Goulet', 'Accounting Manager', '148 rue Chasseur', 'Ste-Hyacinthe', 'Qu茅bec', 'J2S 7S8', 'Canada', '(514) 555-2955', '(514) 555-2921', null);

-- ----------------------------
-- Table structure for TERRITORIES
-- ----------------------------
--DROP TABLE "TERRITORIES";
CREATE TABLE "TERRITORIES" (
"TERRITORYID" VARCHAR2(20 BYTE) NOT NULL ,
"TERRITORYDESCRIPTION" CHAR(50 BYTE) NOT NULL ,
"REGIONID" NUMBER(38) NOT NULL 
)
LOGGING
NOCOMPRESS
NOCACHE

;

-- ----------------------------
-- Records of TERRITORIES
-- ----------------------------
INSERT INTO "TERRITORIES" VALUES ('01581', 'Westboro                                          ', '1');
INSERT INTO "TERRITORIES" VALUES ('01730', 'Bedford                                           ', '1');
INSERT INTO "TERRITORIES" VALUES ('01833', 'Georgetow                                         ', '1');
INSERT INTO "TERRITORIES" VALUES ('02116', 'Boston                                            ', '1');
INSERT INTO "TERRITORIES" VALUES ('02139', 'Cambridge                                         ', '1');
INSERT INTO "TERRITORIES" VALUES ('02184', 'Braintree                                         ', '1');
INSERT INTO "TERRITORIES" VALUES ('02903', 'Providence                                        ', '1');
INSERT INTO "TERRITORIES" VALUES ('03049', 'Hollis                                            ', '3');
INSERT INTO "TERRITORIES" VALUES ('03801', 'Portsmouth                                        ', '3');
INSERT INTO "TERRITORIES" VALUES ('06897', 'Wilton                                            ', '1');
INSERT INTO "TERRITORIES" VALUES ('07960', 'Morristown                                        ', '1');
INSERT INTO "TERRITORIES" VALUES ('08837', 'Edison                                            ', '1');
INSERT INTO "TERRITORIES" VALUES ('10019', 'New York                                          ', '1');
INSERT INTO "TERRITORIES" VALUES ('10038', 'New York                                          ', '1');
INSERT INTO "TERRITORIES" VALUES ('11747', 'Mellvile                                          ', '1');
INSERT INTO "TERRITORIES" VALUES ('14450', 'Fairport                                          ', '1');
INSERT INTO "TERRITORIES" VALUES ('19428', 'Philadelphia                                      ', '3');
INSERT INTO "TERRITORIES" VALUES ('19713', 'Neward                                            ', '1');
INSERT INTO "TERRITORIES" VALUES ('20852', 'Rockville                                         ', '1');
INSERT INTO "TERRITORIES" VALUES ('27403', 'Greensboro                                        ', '1');
INSERT INTO "TERRITORIES" VALUES ('27511', 'Cary                                              ', '1');
INSERT INTO "TERRITORIES" VALUES ('29202', 'Columbia                                          ', '4');
INSERT INTO "TERRITORIES" VALUES ('30346', 'Atlanta                                           ', '4');
INSERT INTO "TERRITORIES" VALUES ('31406', 'Savannah                                          ', '4');
INSERT INTO "TERRITORIES" VALUES ('32859', 'Orlando                                           ', '4');
INSERT INTO "TERRITORIES" VALUES ('33607', 'Tampa                                             ', '4');
INSERT INTO "TERRITORIES" VALUES ('40222', 'Louisville                                        ', '1');
INSERT INTO "TERRITORIES" VALUES ('44122', 'Beachwood                                         ', '3');
INSERT INTO "TERRITORIES" VALUES ('45839', 'Findlay                                           ', '3');
INSERT INTO "TERRITORIES" VALUES ('48075', 'Southfield                                        ', '3');
INSERT INTO "TERRITORIES" VALUES ('48084', 'Troy                                              ', '3');
INSERT INTO "TERRITORIES" VALUES ('48304', 'Bloomfield Hills                                  ', '3');
INSERT INTO "TERRITORIES" VALUES ('53404', 'Racine                                            ', '3');
INSERT INTO "TERRITORIES" VALUES ('55113', 'Roseville                                         ', '3');
INSERT INTO "TERRITORIES" VALUES ('55439', 'Minneapolis                                       ', '3');
INSERT INTO "TERRITORIES" VALUES ('60179', 'Hoffman Estates                                   ', '2');
INSERT INTO "TERRITORIES" VALUES ('60601', 'Chicago                                           ', '2');
INSERT INTO "TERRITORIES" VALUES ('72716', 'Bentonville                                       ', '4');
INSERT INTO "TERRITORIES" VALUES ('75234', 'Dallas                                            ', '4');
INSERT INTO "TERRITORIES" VALUES ('78759', 'Austin                                            ', '4');
INSERT INTO "TERRITORIES" VALUES ('80202', 'Denver                                            ', '2');
INSERT INTO "TERRITORIES" VALUES ('80909', 'Colorado Springs                                  ', '2');
INSERT INTO "TERRITORIES" VALUES ('85014', 'Phoenix                                           ', '2');
INSERT INTO "TERRITORIES" VALUES ('85251', 'Scottsdale                                        ', '2');
INSERT INTO "TERRITORIES" VALUES ('90405', 'Santa Monica                                      ', '2');
INSERT INTO "TERRITORIES" VALUES ('94025', 'Menlo Park                                        ', '2');
INSERT INTO "TERRITORIES" VALUES ('94105', 'San Francisco                                     ', '2');
INSERT INTO "TERRITORIES" VALUES ('95008', 'Campbell                                          ', '2');
INSERT INTO "TERRITORIES" VALUES ('95054', 'Santa Clara                                       ', '2');
INSERT INTO "TERRITORIES" VALUES ('95060', 'Santa Cruz                                        ', '2');
INSERT INTO "TERRITORIES" VALUES ('98004', 'Bellevue                                          ', '2');
INSERT INTO "TERRITORIES" VALUES ('98052', 'Redmond                                           ', '2');
INSERT INTO "TERRITORIES" VALUES ('98104', 'Seattle                                           ', '2');

-- ----------------------------
-- Table structure for TESTTABLE1
-- ----------------------------
--DROP TABLE "TESTTABLE1";
CREATE TABLE "TESTTABLE1" (
"ID" NUMBER(38) NOT NULL ,
"VALUE1" VARCHAR2(10 BYTE) DEFAULT NULL  NULL 
)
LOGGING
NOCOMPRESS
NOCACHE

;

-- ----------------------------
-- Records of TESTTABLE1
-- ----------------------------

-- ----------------------------
-- Table structure for TESTTABLE2
-- ----------------------------
--DROP TABLE "TESTTABLE2";
CREATE TABLE "TESTTABLE2" (
"ID" NUMBER(38) NOT NULL ,
"VALUE2" VARCHAR2(10 BYTE) DEFAULT NULL  NULL 
)
LOGGING
NOCOMPRESS
NOCACHE

;

-- ----------------------------
-- Records of TESTTABLE2
-- ----------------------------

-- ----------------------------
-- Table structure for TESTTABLE3
-- ----------------------------
--DROP TABLE "TESTTABLE3";
CREATE TABLE "TESTTABLE3" (
"ID" NUMBER(38) NOT NULL ,
"VALUE3" VARCHAR2(10 BYTE) DEFAULT NULL  NULL 
)
LOGGING
NOCOMPRESS
NOCACHE

;

-- ----------------------------
-- Records of TESTTABLE3
-- ----------------------------

-- ----------------------------
-- Indexes structure for table CATEGORIES
-- ----------------------------

-- ----------------------------
-- Checks structure for table CATEGORIES
-- ----------------------------
ALTER TABLE "CATEGORIES" ADD CHECK ("CATEGORYID" IS NOT NULL);
ALTER TABLE "CATEGORIES" ADD CHECK ("CATEGORYNAME" IS NOT NULL);

-- ----------------------------
-- Primary Key structure for table CATEGORIES
-- ----------------------------
ALTER TABLE "CATEGORIES" ADD PRIMARY KEY ("CATEGORYID");

-- ----------------------------
-- Indexes structure for table CUSTOMERCUSTOMERDEMO
-- ----------------------------

-- ----------------------------
-- Checks structure for table CUSTOMERCUSTOMERDEMO
-- ----------------------------
ALTER TABLE "CUSTOMERCUSTOMERDEMO" ADD CHECK ("CUSTOMERID" IS NOT NULL);
ALTER TABLE "CUSTOMERCUSTOMERDEMO" ADD CHECK ("CUSTOMERTYPEID" IS NOT NULL);

-- ----------------------------
-- Primary Key structure for table CUSTOMERCUSTOMERDEMO
-- ----------------------------
ALTER TABLE "CUSTOMERCUSTOMERDEMO" ADD PRIMARY KEY ("CUSTOMERID", "CUSTOMERTYPEID");

-- ----------------------------
-- Indexes structure for table CUSTOMERDEMOGRAPHICS
-- ----------------------------

-- ----------------------------
-- Checks structure for table CUSTOMERDEMOGRAPHICS
-- ----------------------------
ALTER TABLE "CUSTOMERDEMOGRAPHICS" ADD CHECK ("CUSTOMERTYPEID" IS NOT NULL);

-- ----------------------------
-- Primary Key structure for table CUSTOMERDEMOGRAPHICS
-- ----------------------------
ALTER TABLE "CUSTOMERDEMOGRAPHICS" ADD PRIMARY KEY ("CUSTOMERTYPEID");

-- ----------------------------
-- Indexes structure for table CUSTOMERS
-- ----------------------------

-- ----------------------------
-- Checks structure for table CUSTOMERS
-- ----------------------------
ALTER TABLE "CUSTOMERS" ADD CHECK ("CUSTOMERID" IS NOT NULL);
ALTER TABLE "CUSTOMERS" ADD CHECK ("COMPANYNAME" IS NOT NULL);

-- ----------------------------
-- Primary Key structure for table CUSTOMERS
-- ----------------------------
ALTER TABLE "CUSTOMERS" ADD PRIMARY KEY ("CUSTOMERID");

-- ----------------------------
-- Indexes structure for table EMPLOYEES
-- ----------------------------

-- ----------------------------
-- Checks structure for table EMPLOYEES
-- ----------------------------
ALTER TABLE "EMPLOYEES" ADD CHECK ("EMPLOYEEID" IS NOT NULL);
ALTER TABLE "EMPLOYEES" ADD CHECK ("LASTNAME" IS NOT NULL);
ALTER TABLE "EMPLOYEES" ADD CHECK ("FIRSTNAME" IS NOT NULL);

-- ----------------------------
-- Primary Key structure for table EMPLOYEES
-- ----------------------------
ALTER TABLE "EMPLOYEES" ADD PRIMARY KEY ("EMPLOYEEID");

-- ----------------------------
-- Indexes structure for table EMPLOYEETERRITORIES
-- ----------------------------

-- ----------------------------
-- Checks structure for table EMPLOYEETERRITORIES
-- ----------------------------
ALTER TABLE "EMPLOYEETERRITORIES" ADD CHECK ("EMPLOYEEID" IS NOT NULL);
ALTER TABLE "EMPLOYEETERRITORIES" ADD CHECK ("TERRITORYID" IS NOT NULL);

-- ----------------------------
-- Primary Key structure for table EMPLOYEETERRITORIES
-- ----------------------------
ALTER TABLE "EMPLOYEETERRITORIES" ADD PRIMARY KEY ("EMPLOYEEID", "TERRITORYID");

-- ----------------------------
-- Indexes structure for table ORDER DETAILS
-- ----------------------------

-- ----------------------------
-- Checks structure for table ORDER DETAILS
-- ----------------------------
ALTER TABLE "ORDER DETAILS" ADD CHECK ("ORDERID" IS NOT NULL);
ALTER TABLE "ORDER DETAILS" ADD CHECK ("PRODUCTID" IS NOT NULL);
ALTER TABLE "ORDER DETAILS" ADD CHECK ("UNITPRICE" IS NOT NULL);
ALTER TABLE "ORDER DETAILS" ADD CHECK ("QUANTITY" IS NOT NULL);
ALTER TABLE "ORDER DETAILS" ADD CHECK ("DISCOUNT" IS NOT NULL);

-- ----------------------------
-- Primary Key structure for table ORDER DETAILS
-- ----------------------------
ALTER TABLE "ORDER DETAILS" ADD PRIMARY KEY ("ORDERID", "PRODUCTID");

-- ----------------------------
-- Indexes structure for table ORDERS
-- ----------------------------

-- ----------------------------
-- Checks structure for table ORDERS
-- ----------------------------
ALTER TABLE "ORDERS" ADD CHECK ("ORDERID" IS NOT NULL);

-- ----------------------------
-- Primary Key structure for table ORDERS
-- ----------------------------
ALTER TABLE "ORDERS" ADD PRIMARY KEY ("ORDERID");

-- ----------------------------
-- Indexes structure for table PRODUCTS
-- ----------------------------

-- ----------------------------
-- Checks structure for table PRODUCTS
-- ----------------------------
ALTER TABLE "PRODUCTS" ADD CHECK ("PRODUCTID" IS NOT NULL);
ALTER TABLE "PRODUCTS" ADD CHECK ("PRODUCTNAME" IS NOT NULL);
ALTER TABLE "PRODUCTS" ADD CHECK ("DISCONTINUED" IS NOT NULL);

-- ----------------------------
-- Primary Key structure for table PRODUCTS
-- ----------------------------
ALTER TABLE "PRODUCTS" ADD PRIMARY KEY ("PRODUCTID");

-- ----------------------------
-- Indexes structure for table REGION
-- ----------------------------

-- ----------------------------
-- Checks structure for table REGION
-- ----------------------------
ALTER TABLE "REGION" ADD CHECK ("REGIONID" IS NOT NULL);
ALTER TABLE "REGION" ADD CHECK ("REGIONDESCRIPTION" IS NOT NULL);

-- ----------------------------
-- Primary Key structure for table REGION
-- ----------------------------
ALTER TABLE "REGION" ADD PRIMARY KEY ("REGIONID");

-- ----------------------------
-- Indexes structure for table SHIPPERS
-- ----------------------------

-- ----------------------------
-- Checks structure for table SHIPPERS
-- ----------------------------
ALTER TABLE "SHIPPERS" ADD CHECK ("SHIPPERID" IS NOT NULL);
ALTER TABLE "SHIPPERS" ADD CHECK ("COMPANYNAME" IS NOT NULL);

-- ----------------------------
-- Primary Key structure for table SHIPPERS
-- ----------------------------
ALTER TABLE "SHIPPERS" ADD PRIMARY KEY ("SHIPPERID");

-- ----------------------------
-- Indexes structure for table SUPPLIERS
-- ----------------------------

-- ----------------------------
-- Checks structure for table SUPPLIERS
-- ----------------------------
ALTER TABLE "SUPPLIERS" ADD CHECK ("SUPPLIERID" IS NOT NULL);
ALTER TABLE "SUPPLIERS" ADD CHECK ("COMPANYNAME" IS NOT NULL);

-- ----------------------------
-- Primary Key structure for table SUPPLIERS
-- ----------------------------
ALTER TABLE "SUPPLIERS" ADD PRIMARY KEY ("SUPPLIERID");

-- ----------------------------
-- Indexes structure for table TERRITORIES
-- ----------------------------

-- ----------------------------
-- Checks structure for table TERRITORIES
-- ----------------------------
ALTER TABLE "TERRITORIES" ADD CHECK ("TERRITORYID" IS NOT NULL);
ALTER TABLE "TERRITORIES" ADD CHECK ("TERRITORYDESCRIPTION" IS NOT NULL);
ALTER TABLE "TERRITORIES" ADD CHECK ("REGIONID" IS NOT NULL);

-- ----------------------------
-- Primary Key structure for table TERRITORIES
-- ----------------------------
ALTER TABLE "TERRITORIES" ADD PRIMARY KEY ("TERRITORYID");

-- ----------------------------
-- Indexes structure for table TESTTABLE1
-- ----------------------------

-- ----------------------------
-- Checks structure for table TESTTABLE1
-- ----------------------------
ALTER TABLE "TESTTABLE1" ADD CHECK ("ID" IS NOT NULL);

-- ----------------------------
-- Primary Key structure for table TESTTABLE1
-- ----------------------------
ALTER TABLE "TESTTABLE1" ADD PRIMARY KEY ("ID");

-- ----------------------------
-- Indexes structure for table TESTTABLE2
-- ----------------------------

-- ----------------------------
-- Checks structure for table TESTTABLE2
-- ----------------------------
ALTER TABLE "TESTTABLE2" ADD CHECK ("ID" IS NOT NULL);

-- ----------------------------
-- Primary Key structure for table TESTTABLE2
-- ----------------------------
ALTER TABLE "TESTTABLE2" ADD PRIMARY KEY ("ID");

-- ----------------------------
-- Indexes structure for table TESTTABLE3
-- ----------------------------

-- ----------------------------
-- Checks structure for table TESTTABLE3
-- ----------------------------
ALTER TABLE "TESTTABLE3" ADD CHECK ("ID" IS NOT NULL);

-- ----------------------------
-- Primary Key structure for table TESTTABLE3
-- ----------------------------
ALTER TABLE "TESTTABLE3" ADD PRIMARY KEY ("ID");
