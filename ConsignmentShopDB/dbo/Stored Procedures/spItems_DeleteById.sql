CREATE PROCEDURE [dbo].[spItems_DeleteById]
	@Id int
AS
begin

set nocount on;

delete from Items where Id = @Id;

end
