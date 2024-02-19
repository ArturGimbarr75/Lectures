SELECT p.Id, p.Name, p.Surname, ph.Country, ph.Phone
FROM Person p
JOIN Phone ph ON p.Id = ph.PersonId;

SELECT Id, PersonId, Balance
FROM BankAccount
WHERE Balance > 10000;

SELECT p.Id, p.Name, p.Surname, bc.Number, bc.Exp
FROM Person p
JOIN BankAccount ba ON p.Id = ba.PersonId
JOIN BankCard bc ON ba.Id = bc.AccountId
WHERE YEAR(bc.Exp) = YEAR(GETDATE()) + 1;

SELECT p.Id, p.Name, p.Surname, bc.Number, bc.Exp
FROM Person p
JOIN BankAccount ba ON p.Id = ba.PersonId
JOIN BankCard bc ON ba.Id = bc.AccountId

SELECT bc.Id, bc.Number, p.Name, p.Surname
FROM BankCard bc
JOIN BankAccount ba ON bc.AccountId = ba.Id
JOIN Person p ON ba.PersonId = p.Id;

