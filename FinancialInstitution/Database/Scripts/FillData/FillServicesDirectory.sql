IF NOT EXISTS(SELECT * FROM [dbo].[ServicesDirectory])
		
	INSERT INTO [dbo].[ServicesDirectory]
		([Name])
	VALUES
		('Кредит'),
		('Регистрация депозитного счета'),
		('Денежный перевод'),
		('Обмен валюты'),
		('Оформление страховки')