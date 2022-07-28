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

CREATE TRIGGER [dbo].[Trg_Agency_Update]
ON [dbo].[Agency]
AFTER UPDATE 
AS BEGIN
   UPDATE [dbo].[Agency]
   SET [LastUpdatedDate] = GETDATE()
   FROM INSERTED i
END
GO

ALTER TABLE [dbo].[Agency] ENABLE TRIGGER [Trg_Agency_Update]
GO