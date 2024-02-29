USE TASKS;

CREATE TABLE Project(
    "ID" INTEGER NOT NULL,
    "Name" VARCHAR(255)
);   
            
INSERT INTO Project VALUES
(1, 'Izola'),
(2, 'RegistryCenter'),
(3, 'Kaunas');   
        
CREATE TABLE Department(
    Name VARCHAR(255) NOT NULL,
    ManagerPersonalCode VARCHAR(255)
); 

INSERT INTO Department VALUES
('Java', '48509141175'),
('Testing', '38804172782'),
('C#', '38904172782');        

CREATE TABLE Employee(
    PersonalCode CHAR(11) NOT NULL,
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    StartDate DATE,
    BirthDate DATE,
    Position VARCHAR(255),
    DepartmentName VARCHAR(255),
    ProjectID INTEGER
);              
         
INSERT INTO Employee VALUES
('38101122335', 'Petras', 'Petraitis', '2009-10-30', '1981-01-11', 'Tester', 'Testing', 1),
('38010101234', 'Jonas', 'Jonaitis', '2007-05-30', '1980-10-10', 'Developer', 'Java', 2),
('38103201435', 'Rimas', 'Plekaitis', '2009-10-30', '1981-03-20', 'Developer', 'Java', 3),
('48509141175', 'Zita', 'Lietuvaitė', '2012-06-15', '1985-09-14', 'ProjectManager', 'Java', 2),
('48410121275', 'Jurga', 'Jurgaityte', '2011-02-12', '1984-10-12', 'Developer', 'C#', 1),
('38807201234', 'Giedrius', 'Sabutis', '2009-01-21', '1988-07-20', 'Tester', 'Testing', 2),
('38807291234', 'Regimantas', 'Sabonis', '2013-01-21', '1988-07-29', 'Tester', 'Testing', 3),
('38609191234', 'Saulius', 'Sabonis', '2013-01-21', '1986-09-19', 'Tester', 'Testing', 3),
('38109197598', 'Justas', 'Sabonis', '2011-12-17', '1986-09-19', 'Tester', 'Testing', 1),
('38503142412', 'Jonas', 'Kalnas', '2009-05-11', '1985-03-24', 'Developer', 'Java', 1),
('39003142412', 'Stasys', 'Sakalas', '2009-05-11', '1990-03-24', 'Developer', 'Java', 3),
('37803142412', 'Povilas', 'Vakalas', '2012-11-11', '1978-03-14', 'Developer', 'C#', 2),
('38804172782', 'Deivydas', 'Piliukas', '2011-12-11', '1988-04-17', 'ProjectManager', 'Testing', 2),
('38904172782', 'Kestas', 'Liutas', '2012-12-11', '1989-04-17', 'ProjectManager', 'C#', 1),
('38901228523', 'temporary', 'actor', '2009-01-22', '1989-01-22', NULL, NULL, NULL);              
