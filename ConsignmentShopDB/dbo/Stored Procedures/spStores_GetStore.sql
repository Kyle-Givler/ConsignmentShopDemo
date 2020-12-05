CREATE PROCEDURE [dbo].[spStores_GetStore]
	@Id int
AS
begin

	set nocount on;

	select [Id], [Name], [StoreBank], [StoreProfit]
	from Stores
	where Id = @Id;

end