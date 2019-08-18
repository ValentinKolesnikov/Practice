/*
Шаблон скрипта после развертывания							
--------------------------------------------------------------------------------------
 В данном файле содержатся инструкции SQL, которые будут добавлены в скрипт построения.		
 Используйте синтаксис SQLCMD для включения файла в скрипт после развертывания.			
 Пример:      :r .\myfile.sql								
 Используйте синтаксис SQLCMD для создания ссылки на переменную в скрипте после развертывания.		
 Пример:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\Scripts\FillData\FillBranch.sql
:r .\Scripts\FillData\FillClient.sql
:r .\Scripts\FillData\FillPosition.sql
:r .\Scripts\FillData\FillEmployee.sql
:r .\Scripts\FillData\FillServicesDirectory.sql
:r .\Scripts\FillData\FillBranchService.sql
:r .\Scripts\FillData\FillServicesHistory.sql


