CREATE TABLE [dbo].[Agency]
(
	[Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[LegalEntityId] bigint NOT NULL,
	[IsGrantFunded] bit NOT NULL DEFAULT 0,
	[EffectiveFrom] DATETIME2,
	[EffectiveTo] DATETIME2 NULL,
	[RemovalReason] NVARCHAR(MAX) NULL,
	[CreatedDate] DATETIME2 DEFAULT GETDATE(),
	[LastUpdatedDate] DATETIME2 NULL,
)
GO