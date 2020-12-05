CREATE PROCEDURE [dbo].[spItems_GetAll]
AS
begin
	
	set nocount on;

	select [Id], [Name], [Description], [Price], [OwnerId], [PaymentDistributed]
	from dbo.Items;

end