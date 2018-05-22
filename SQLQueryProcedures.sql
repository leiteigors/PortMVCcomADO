--create procedure ExcluirPorId
--(
--@timeId int
--)
--as

--begin
--Delete From [dbo].[Table] where TimeId = @timeId
--end

create procedure ObterPorId
(
@timeId int
)
as

begin
Select * From [dbo].[Table] where TimeId = @timeId
end



--create procedure AtualizarTime
--(
--@timeId int,
--@Time nvarchar(50),
--@Estado char(2),
--@Cores varchar(50)
--)

--as

--begin
--Update [dbo].[Table] set Time = @Time, Estado = @Estado, Cores = @Cores where TimeId = @timeId
--end

--create procedure InserirTime
--(
--@Time nvarchar(50),
--@Estado char(2),
--@Cores varchar(50)
--)
--as
--begin
--Insert into [dbo].[Table] values (@Time, @Estado, @Cores) 
--end

create procedure ObterTimes
as
begin
Select * from [dbo].[Table] 
end