CREATE TABLE [dbo].[Agency]
(
	[LegalEntityId] bigint NOT NULL PRIMARY KEY,
	[IsGrantFunded] bit NOT NULL DEFAULT 0
)
GO