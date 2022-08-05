CREATE TABLE [dbo].[Agency]
(
	[LegalEntityId] bigint NOT NULL,
	[IsGrantFunded] bit NOT NULL DEFAULT 0,
	[EffectiveFrom] DATETIME2,
	[EffectiveTo] DATETIME2 NULL,
	[RemovalReason] NVARCHAR(MAX) NULL,
	[CreatedDate] DATETIME2 DEFAULT GETDATE(),
	[LastUpdatedDate] DATETIME2 NULL,
	CONSTRAINT [PK_Agency] PRIMARY KEY ([LegalEntityId], [EffectiveFrom])
)
GO