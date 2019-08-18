IF NOT EXISTS(SELECT Name FROM [dbo].[Position])
	INSERT INTO [dbo].[Position]
		([Name], [Flag])
	VALUES 
		('Администратор',1),
		('Заместитель администатора',1),
		('Бухгалтер',0),
		('Старший кассир',1),
		('Кассир',0),
		('Главный операционный директор',1)
