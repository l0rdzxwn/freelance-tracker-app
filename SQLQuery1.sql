SELECT * FROM dbo.Invoices AS i 
LEFT JOIN dbo.Clients AS c ON i.ClientID = c.ID;
