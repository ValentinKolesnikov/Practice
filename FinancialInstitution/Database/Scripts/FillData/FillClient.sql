﻿IF NOT EXISTS(SELECT ID FROM [dbo].[Client])
	INSERT INTO [dbo].[Client] 
		([FirstName], [SecondName], [MiddleName], [BirthDay], [Address], [PassportSeriesAndNumber], [CardNumber])
	VALUES 
		('Иван', 'Иванов', 'Иванович','2000-03-03','Республика Беларусь, Минск, ул. Ленинская 19','КВ2947594','5846-1567-2637-2663'),
		('Сидр', 'Сидоров', 'Сидорович','1991-02-21','Россия, Москва, ул. Партизанская 12','КВ2326794',''),
		('Петр', 'Петров', 'Петрович','1985-12-17','Украина, Киев, ул. Строителей 1','КВ2954594','5846-7854-2637-2663')