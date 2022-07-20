CREATE TABLE [dbo].[Agency]
(
	[LegalEntityId] bigint NOT NULL PRIMARY KEY,
	[IsGrantFunded] bit NOT NULL DEFAULT 0,
	[EffectiveFrom] DATETIME2 NULL,
	[EffectiveTo] DATETIME2 NULL,
	[RemovalReason] NVARCHAR(MAX) NULL,
	[CreatedDate] DATETIME2 NULL,
	[LastUpdatedDate] DATETIME2 NULL,
)
GO