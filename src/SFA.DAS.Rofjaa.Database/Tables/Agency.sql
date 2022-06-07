CREATE TABLE [dbo].[Agency]
(
	[LegalIdentityId] INT NOT NULL PRIMARY KEY,
	[IsGrantFunded] bit NOT NULL DEFAULT 0
)
GO