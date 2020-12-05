CREATE PROCEDURE [dbo].[spStores_Update]
	@id int,
	@Name nvarchar(100),
	@StoreBank money,
	@StoreProfit money
AS
begin

	set nocount on;

	update Stores 
	set [Name] = @Name, StoreBank = @StoreBank, StoreProfit = @StoreProfit
	where Id = @Id;

end
