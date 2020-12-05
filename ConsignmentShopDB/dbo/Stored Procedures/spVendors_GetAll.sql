CREATE PROCEDURE [dbo].[spVendors_GetAll]
AS
begin

	set nocount on;

	select [Id], [FirstName], [LastName], [CommisionRate], [PaymentDue]
	from Vendors;

end
