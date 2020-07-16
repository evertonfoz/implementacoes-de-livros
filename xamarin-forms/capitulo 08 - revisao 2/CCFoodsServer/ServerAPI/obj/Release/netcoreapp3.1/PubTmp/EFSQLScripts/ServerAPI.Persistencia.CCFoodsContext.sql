IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200713204230_InitialCreate')
BEGIN
    CREATE TABLE [ConfiguracoesDispositivos] (
        [ConfiguracaoDispositivoId] bigint NOT NULL IDENTITY,
        [EMail] nvarchar(max) NULL,
        CONSTRAINT [PK_ConfiguracoesDispositivos] PRIMARY KEY ([ConfiguracaoDispositivoId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200713204230_InitialCreate')
BEGIN
    CREATE TABLE [Garcons] (
        [GarcomId] nvarchar(450) NOT NULL,
        [Nome] nvarchar(max) NULL,
        [Sobrenome] nvarchar(max) NULL,
        [Foto] varbinary(max) NULL,
        [DispositivoId] bigint NULL,
        [EntityId] bigint NULL,
        [OperacaoSincronismo] int NOT NULL,
        CONSTRAINT [PK_Garcons] PRIMARY KEY ([GarcomId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200713204230_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200713204230_InitialCreate', N'3.1.5');
END;

GO

