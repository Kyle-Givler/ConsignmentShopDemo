﻿CREATE PROCEDURE [dbo].[spItems_GetByVendorId]
	@OwnerId int
AS
begin

	set nocount on;

	select [Id], [Name], [Description], [Price], [Sold], [OwnerId], [PaymentDistributed] 
	from dbo.Items
	where OwnerId = @OwnerId;

end