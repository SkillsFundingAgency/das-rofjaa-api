CREATE TABLE [dbo].[Agency]
(
	[LegalEntityId] INT NOT NULL PRIMARY KEY,
	[IsGrantFunded] bit NOT NULL DEFAULT 0
)
GO