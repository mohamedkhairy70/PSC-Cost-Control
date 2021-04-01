
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/31/2021 06:34:44
-- Generated from EDMX file: C:\Users\Mohamed Khairy\source\repos\PSC Cost Control\PSC Cost Control\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PSC_COST3];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Cost_Unified_Codes_Cost_Project_Codes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[_Cost_Project_Codes] DROP CONSTRAINT [FK__Cost_Unified_Codes_Cost_Project_Codes];
GO
IF OBJECT_ID(N'[dbo].[FK___Cost_Ind__Indir__6477ECF3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[_Cost_Indirect_Project_Code_Summerizing] DROP CONSTRAINT [FK___Cost_Ind__Indir__6477ECF3];
GO
IF OBJECT_ID(N'[dbo].[FK___Cost_Ind__Projc__6383C8BA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[_Cost_Indirect_Project_Code_Summerizing] DROP CONSTRAINT [FK___Cost_Ind__Projc__6383C8BA];
GO
IF OBJECT_ID(N'[dbo].[FK___Cost_Pro__Paren__66603565]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[_Cost_Project_Codes] DROP CONSTRAINT [FK___Cost_Pro__Paren__66603565];
GO
IF OBJECT_ID(N'[dbo].[FK___Cost_Uni__Paren__656C112C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[_Cost_Unified_Codes] DROP CONSTRAINT [FK___Cost_Uni__Paren__656C112C];
GO
IF OBJECT_ID(N'[dbo].[FK__Cost_Project_Codes_Items__Cost_Direct_Project_Codes_Summerizng]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[_Cost_Direct_Project_Codes_Summerizng] DROP CONSTRAINT [FK__Cost_Project_Codes_Items__Cost_Direct_Project_Codes_Summerizng];
GO
IF OBJECT_ID(N'[dbo].[FK_BOQ_Items__Cost_Project_Codes_Items]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[_Cost_Project_Codes_Items] DROP CONSTRAINT [FK_BOQ_Items__Cost_Project_Codes_Items];
GO
IF OBJECT_ID(N'[dbo].[FK_BOQ_Items_BOQ_Items3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BOQ_Items] DROP CONSTRAINT [FK_BOQ_Items_BOQ_Items3];
GO
IF OBJECT_ID(N'[dbo].[FK_BOQ_Items_BOQs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BOQ_Items] DROP CONSTRAINT [FK_BOQ_Items_BOQs];
GO
IF OBJECT_ID(N'[dbo].[FK_BOQ_Items_Units]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BOQ_Items] DROP CONSTRAINT [FK_BOQ_Items_Units];
GO
IF OBJECT_ID(N'[dbo].[FK_BOQs_Contracts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BOQs] DROP CONSTRAINT [FK_BOQs_Contracts];
GO
IF OBJECT_ID(N'[dbo].[FK_BREAK_DOWN_ITEM_TYPE_Cost_Direct_Project_Codes_Summerizng]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[_Cost_Direct_Project_Codes_Summerizng] DROP CONSTRAINT [FK_BREAK_DOWN_ITEM_TYPE_Cost_Direct_Project_Codes_Summerizng];
GO
IF OBJECT_ID(N'[dbo].[FK_Cost_Project_Codes__Cost_Project_Codes_Items]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[_Cost_Project_Codes_Items] DROP CONSTRAINT [FK_Cost_Project_Codes__Cost_Project_Codes_Items];
GO
IF OBJECT_ID(N'[dbo].[FK_IndirectCostItems_BOQs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IndirectCostItems] DROP CONSTRAINT [FK_IndirectCostItems_BOQs];
GO
IF OBJECT_ID(N'[dbo].[FK_IndirectCostItems_IndirectCostItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IndirectCostItems] DROP CONSTRAINT [FK_IndirectCostItems_IndirectCostItems];
GO
IF OBJECT_ID(N'[dbo].[FK_Item_Breakdowns_BOQ_Items]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Item_Breakdowns] DROP CONSTRAINT [FK_Item_Breakdowns_BOQ_Items];
GO
IF OBJECT_ID(N'[dbo].[FK_Item_Breakdowns_BreakdownItemType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Item_Breakdowns] DROP CONSTRAINT [FK_Item_Breakdowns_BreakdownItemType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[_Cost_Direct_Project_Codes_Summerizng]', 'U') IS NOT NULL
    DROP TABLE [dbo].[_Cost_Direct_Project_Codes_Summerizng];
GO
IF OBJECT_ID(N'[dbo].[_Cost_Indirect_Project_Code_Summerizing]', 'U') IS NOT NULL
    DROP TABLE [dbo].[_Cost_Indirect_Project_Code_Summerizing];
GO
IF OBJECT_ID(N'[dbo].[_Cost_Project_Code_Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[_Cost_Project_Code_Categories];
GO
IF OBJECT_ID(N'[dbo].[_Cost_Project_Codes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[_Cost_Project_Codes];
GO
IF OBJECT_ID(N'[dbo].[_Cost_Project_Codes_Items]', 'U') IS NOT NULL
    DROP TABLE [dbo].[_Cost_Project_Codes_Items];
GO
IF OBJECT_ID(N'[dbo].[_Cost_Unified_Code_Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[_Cost_Unified_Code_Category];
GO
IF OBJECT_ID(N'[dbo].[_Cost_Unified_Codes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[_Cost_Unified_Codes];
GO
IF OBJECT_ID(N'[dbo].[BOQ_Items]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BOQ_Items];
GO
IF OBJECT_ID(N'[dbo].[BOQs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BOQs];
GO
IF OBJECT_ID(N'[dbo].[BreakdownItemType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BreakdownItemType];
GO
IF OBJECT_ID(N'[dbo].[IndirectCostItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IndirectCostItems];
GO
IF OBJECT_ID(N'[dbo].[Item_Breakdowns]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Item_Breakdowns];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[Units]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Units];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C_Cost_Direct_Project_Codes_Summerizng'
CREATE TABLE [dbo].[C_Cost_Direct_Project_Codes_Summerizng] (
    [Project_Code_Id] int  NOT NULL,
    [Boq_Item_Id] int  NOT NULL,
    [Break_Down_Type_Id] smallint  NOT NULL,
    [Planned_Price] decimal(18,0)  NOT NULL,
    [Ref_Price] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'C_Cost_Indirect_Project_Code_Summerizing'
CREATE TABLE [dbo].[C_Cost_Indirect_Project_Code_Summerizing] (
    [Projcet_Code_Id] int  NOT NULL,
    [Indirect_Cost_Item_Id] int  NOT NULL,
    [Planned_Price] decimal(18,0)  NOT NULL,
    [Ref_Price] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'C_Cost_Project_Code_Categories'
CREATE TABLE [dbo].[C_Cost_Project_Code_Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(150)  NOT NULL
);
GO

-- Creating table 'C_Cost_Project_Codes'
CREATE TABLE [dbo].[C_Cost_Project_Codes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Unified_Code_Id] int  NULL,
    [Category_Id] int  NULL,
    [Project_Id] int  NULL,
    [Parent] int  NULL,
    [Code] nvarchar(max)  NULL
);
GO

-- Creating table 'C_Cost_Project_Codes_Items'
CREATE TABLE [dbo].[C_Cost_Project_Codes_Items] (
    [Project_Code_Id] int  NOT NULL,
    [Boq_Item_Id] int  NOT NULL
);
GO

-- Creating table 'C_Cost_Unified_Code_Category'
CREATE TABLE [dbo].[C_Cost_Unified_Code_Category] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(150)  NOT NULL
);
GO

-- Creating table 'C_Cost_Unified_Codes'
CREATE TABLE [dbo].[C_Cost_Unified_Codes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(150)  NOT NULL,
    [Category_Id] int  NULL,
    [Parent] int  NULL,
    [Code] nvarchar(max)  NULL
);
GO

-- Creating table 'BOQ_Items'
CREATE TABLE [dbo].[BOQ_Items] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BOQId] int  NOT NULL,
    [Unit] int  NULL,
    [Quantity] decimal(18,3)  NOT NULL,
    [BOQRef] nvarchar(50)  NULL,
    [PlanedUnitPrice] decimal(18,2)  NOT NULL,
    [ParentId] int  NULL,
    [HierarcyType] smallint  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [PlanedUnitPriceWithoutProfit] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'BOQs'
CREATE TABLE [dbo].[BOQs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Rev] smallint  NOT NULL,
    [RevDate] datetime  NOT NULL,
    [ContractId] int  NULL
);
GO

-- Creating table 'BreakdownItemType'
CREATE TABLE [dbo].[BreakdownItemType] (
    [Id] smallint  NOT NULL,
    [Name] nvarchar(150)  NOT NULL,
    [TranslateName] nvarchar(150)  NOT NULL
);
GO

-- Creating table 'IndirectCostItems'
CREATE TABLE [dbo].[IndirectCostItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BOQId] int  NOT NULL,
    [TotalPrice] decimal(18,2)  NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ParentId] int  NULL
);
GO

-- Creating table 'Item_Breakdowns'
CREATE TABLE [dbo].[Item_Breakdowns] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TotalPrice] decimal(12,3)  NOT NULL,
    [BOQ_Items_Id] int  NOT NULL,
    [TypeId] smallint  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [ContractId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Units'
CREATE TABLE [dbo].[Units] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Project_Code_Id], [Boq_Item_Id], [Break_Down_Type_Id] in table 'C_Cost_Direct_Project_Codes_Summerizng'
ALTER TABLE [dbo].[C_Cost_Direct_Project_Codes_Summerizng]
ADD CONSTRAINT [PK_C_Cost_Direct_Project_Codes_Summerizng]
    PRIMARY KEY CLUSTERED ([Project_Code_Id], [Boq_Item_Id], [Break_Down_Type_Id] ASC);
GO

-- Creating primary key on [Projcet_Code_Id], [Indirect_Cost_Item_Id] in table 'C_Cost_Indirect_Project_Code_Summerizing'
ALTER TABLE [dbo].[C_Cost_Indirect_Project_Code_Summerizing]
ADD CONSTRAINT [PK_C_Cost_Indirect_Project_Code_Summerizing]
    PRIMARY KEY CLUSTERED ([Projcet_Code_Id], [Indirect_Cost_Item_Id] ASC);
GO

-- Creating primary key on [Id] in table 'C_Cost_Project_Code_Categories'
ALTER TABLE [dbo].[C_Cost_Project_Code_Categories]
ADD CONSTRAINT [PK_C_Cost_Project_Code_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'C_Cost_Project_Codes'
ALTER TABLE [dbo].[C_Cost_Project_Codes]
ADD CONSTRAINT [PK_C_Cost_Project_Codes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Project_Code_Id], [Boq_Item_Id] in table 'C_Cost_Project_Codes_Items'
ALTER TABLE [dbo].[C_Cost_Project_Codes_Items]
ADD CONSTRAINT [PK_C_Cost_Project_Codes_Items]
    PRIMARY KEY CLUSTERED ([Project_Code_Id], [Boq_Item_Id] ASC);
GO

-- Creating primary key on [Id] in table 'C_Cost_Unified_Code_Category'
ALTER TABLE [dbo].[C_Cost_Unified_Code_Category]
ADD CONSTRAINT [PK_C_Cost_Unified_Code_Category]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'C_Cost_Unified_Codes'
ALTER TABLE [dbo].[C_Cost_Unified_Codes]
ADD CONSTRAINT [PK_C_Cost_Unified_Codes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BOQ_Items'
ALTER TABLE [dbo].[BOQ_Items]
ADD CONSTRAINT [PK_BOQ_Items]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BOQs'
ALTER TABLE [dbo].[BOQs]
ADD CONSTRAINT [PK_BOQs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BreakdownItemType'
ALTER TABLE [dbo].[BreakdownItemType]
ADD CONSTRAINT [PK_BreakdownItemType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IndirectCostItems'
ALTER TABLE [dbo].[IndirectCostItems]
ADD CONSTRAINT [PK_IndirectCostItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Item_Breakdowns'
ALTER TABLE [dbo].[Item_Breakdowns]
ADD CONSTRAINT [PK_Item_Breakdowns]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ContractId] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([ContractId] ASC);
GO

-- Creating primary key on [Id] in table 'Units'
ALTER TABLE [dbo].[Units]
ADD CONSTRAINT [PK_Units]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Project_Code_Id], [Boq_Item_Id] in table 'C_Cost_Direct_Project_Codes_Summerizng'
ALTER TABLE [dbo].[C_Cost_Direct_Project_Codes_Summerizng]
ADD CONSTRAINT [FK__Cost_Project_Codes_Items__Cost_Direct_Project_Codes_Summerizng]
    FOREIGN KEY ([Project_Code_Id], [Boq_Item_Id])
    REFERENCES [dbo].[C_Cost_Project_Codes_Items]
        ([Project_Code_Id], [Boq_Item_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Break_Down_Type_Id] in table 'C_Cost_Direct_Project_Codes_Summerizng'
ALTER TABLE [dbo].[C_Cost_Direct_Project_Codes_Summerizng]
ADD CONSTRAINT [FK_BREAK_DOWN_ITEM_TYPE_Cost_Direct_Project_Codes_Summerizng]
    FOREIGN KEY ([Break_Down_Type_Id])
    REFERENCES [dbo].[BreakdownItemType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BREAK_DOWN_ITEM_TYPE_Cost_Direct_Project_Codes_Summerizng'
CREATE INDEX [IX_FK_BREAK_DOWN_ITEM_TYPE_Cost_Direct_Project_Codes_Summerizng]
ON [dbo].[C_Cost_Direct_Project_Codes_Summerizng]
    ([Break_Down_Type_Id]);
GO

-- Creating foreign key on [Indirect_Cost_Item_Id] in table 'C_Cost_Indirect_Project_Code_Summerizing'
ALTER TABLE [dbo].[C_Cost_Indirect_Project_Code_Summerizing]
ADD CONSTRAINT [FK___Cost_Ind__Indir__6477ECF3]
    FOREIGN KEY ([Indirect_Cost_Item_Id])
    REFERENCES [dbo].[IndirectCostItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK___Cost_Ind__Indir__6477ECF3'
CREATE INDEX [IX_FK___Cost_Ind__Indir__6477ECF3]
ON [dbo].[C_Cost_Indirect_Project_Code_Summerizing]
    ([Indirect_Cost_Item_Id]);
GO

-- Creating foreign key on [Projcet_Code_Id] in table 'C_Cost_Indirect_Project_Code_Summerizing'
ALTER TABLE [dbo].[C_Cost_Indirect_Project_Code_Summerizing]
ADD CONSTRAINT [FK___Cost_Ind__Projc__6383C8BA]
    FOREIGN KEY ([Projcet_Code_Id])
    REFERENCES [dbo].[C_Cost_Project_Codes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Category_Id] in table 'C_Cost_Project_Codes'
ALTER TABLE [dbo].[C_Cost_Project_Codes]
ADD CONSTRAINT [FK_C_Cost_Project_Code_Categories__Cost_Project_Codes]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[C_Cost_Project_Code_Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_C_Cost_Project_Code_Categories__Cost_Project_Codes'
CREATE INDEX [IX_FK_C_Cost_Project_Code_Categories__Cost_Project_Codes]
ON [dbo].[C_Cost_Project_Codes]
    ([Category_Id]);
GO

-- Creating foreign key on [Unified_Code_Id] in table 'C_Cost_Project_Codes'
ALTER TABLE [dbo].[C_Cost_Project_Codes]
ADD CONSTRAINT [FK_C_Cost_Unified_Codes_Cost_Project_Codes]
    FOREIGN KEY ([Unified_Code_Id])
    REFERENCES [dbo].[C_Cost_Unified_Codes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_C_Cost_Unified_Codes_Cost_Project_Codes'
CREATE INDEX [IX_FK_C_Cost_Unified_Codes_Cost_Project_Codes]
ON [dbo].[C_Cost_Project_Codes]
    ([Unified_Code_Id]);
GO

-- Creating foreign key on [Parent] in table 'C_Cost_Project_Codes'
ALTER TABLE [dbo].[C_Cost_Project_Codes]
ADD CONSTRAINT [FK___Cost_Pro__Paren__66603565]
    FOREIGN KEY ([Parent])
    REFERENCES [dbo].[C_Cost_Project_Codes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK___Cost_Pro__Paren__66603565'
CREATE INDEX [IX_FK___Cost_Pro__Paren__66603565]
ON [dbo].[C_Cost_Project_Codes]
    ([Parent]);
GO

-- Creating foreign key on [Project_Code_Id] in table 'C_Cost_Project_Codes_Items'
ALTER TABLE [dbo].[C_Cost_Project_Codes_Items]
ADD CONSTRAINT [FK_Cost_Project_Codes__Cost_Project_Codes_Items]
    FOREIGN KEY ([Project_Code_Id])
    REFERENCES [dbo].[C_Cost_Project_Codes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Project_Id] in table 'C_Cost_Project_Codes'
ALTER TABLE [dbo].[C_Cost_Project_Codes]
ADD CONSTRAINT [FK_Projects__Cost_Project_Codes]
    FOREIGN KEY ([Project_Id])
    REFERENCES [dbo].[Projects]
        ([ContractId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Projects__Cost_Project_Codes'
CREATE INDEX [IX_FK_Projects__Cost_Project_Codes]
ON [dbo].[C_Cost_Project_Codes]
    ([Project_Id]);
GO

-- Creating foreign key on [Boq_Item_Id] in table 'C_Cost_Project_Codes_Items'
ALTER TABLE [dbo].[C_Cost_Project_Codes_Items]
ADD CONSTRAINT [FK_BOQ_Items__Cost_Project_Codes_Items]
    FOREIGN KEY ([Boq_Item_Id])
    REFERENCES [dbo].[BOQ_Items]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BOQ_Items__Cost_Project_Codes_Items'
CREATE INDEX [IX_FK_BOQ_Items__Cost_Project_Codes_Items]
ON [dbo].[C_Cost_Project_Codes_Items]
    ([Boq_Item_Id]);
GO

-- Creating foreign key on [Category_Id] in table 'C_Cost_Unified_Codes'
ALTER TABLE [dbo].[C_Cost_Unified_Codes]
ADD CONSTRAINT [FK_C_Cost_Unified_Code_Category_Cost_Unified_Codes]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[C_Cost_Unified_Code_Category]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_C_Cost_Unified_Code_Category_Cost_Unified_Codes'
CREATE INDEX [IX_FK_C_Cost_Unified_Code_Category_Cost_Unified_Codes]
ON [dbo].[C_Cost_Unified_Codes]
    ([Category_Id]);
GO

-- Creating foreign key on [Parent] in table 'C_Cost_Unified_Codes'
ALTER TABLE [dbo].[C_Cost_Unified_Codes]
ADD CONSTRAINT [FK___Cost_Uni__Paren__656C112C]
    FOREIGN KEY ([Parent])
    REFERENCES [dbo].[C_Cost_Unified_Codes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK___Cost_Uni__Paren__656C112C'
CREATE INDEX [IX_FK___Cost_Uni__Paren__656C112C]
ON [dbo].[C_Cost_Unified_Codes]
    ([Parent]);
GO

-- Creating foreign key on [ParentId] in table 'BOQ_Items'
ALTER TABLE [dbo].[BOQ_Items]
ADD CONSTRAINT [FK_BOQ_Items_BOQ_Items3]
    FOREIGN KEY ([ParentId])
    REFERENCES [dbo].[BOQ_Items]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BOQ_Items_BOQ_Items3'
CREATE INDEX [IX_FK_BOQ_Items_BOQ_Items3]
ON [dbo].[BOQ_Items]
    ([ParentId]);
GO

-- Creating foreign key on [BOQId] in table 'BOQ_Items'
ALTER TABLE [dbo].[BOQ_Items]
ADD CONSTRAINT [FK_BOQ_Items_BOQs]
    FOREIGN KEY ([BOQId])
    REFERENCES [dbo].[BOQs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BOQ_Items_BOQs'
CREATE INDEX [IX_FK_BOQ_Items_BOQs]
ON [dbo].[BOQ_Items]
    ([BOQId]);
GO

-- Creating foreign key on [Unit] in table 'BOQ_Items'
ALTER TABLE [dbo].[BOQ_Items]
ADD CONSTRAINT [FK_BOQ_Items_Units]
    FOREIGN KEY ([Unit])
    REFERENCES [dbo].[Units]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BOQ_Items_Units'
CREATE INDEX [IX_FK_BOQ_Items_Units]
ON [dbo].[BOQ_Items]
    ([Unit]);
GO

-- Creating foreign key on [BOQ_Items_Id] in table 'Item_Breakdowns'
ALTER TABLE [dbo].[Item_Breakdowns]
ADD CONSTRAINT [FK_Item_Breakdowns_BOQ_Items]
    FOREIGN KEY ([BOQ_Items_Id])
    REFERENCES [dbo].[BOQ_Items]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Item_Breakdowns_BOQ_Items'
CREATE INDEX [IX_FK_Item_Breakdowns_BOQ_Items]
ON [dbo].[Item_Breakdowns]
    ([BOQ_Items_Id]);
GO

-- Creating foreign key on [ContractId] in table 'BOQs'
ALTER TABLE [dbo].[BOQs]
ADD CONSTRAINT [FK_BOQs_Contracts]
    FOREIGN KEY ([ContractId])
    REFERENCES [dbo].[Projects]
        ([ContractId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BOQs_Contracts'
CREATE INDEX [IX_FK_BOQs_Contracts]
ON [dbo].[BOQs]
    ([ContractId]);
GO

-- Creating foreign key on [BOQId] in table 'IndirectCostItems'
ALTER TABLE [dbo].[IndirectCostItems]
ADD CONSTRAINT [FK_IndirectCostItems_BOQs]
    FOREIGN KEY ([BOQId])
    REFERENCES [dbo].[BOQs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IndirectCostItems_BOQs'
CREATE INDEX [IX_FK_IndirectCostItems_BOQs]
ON [dbo].[IndirectCostItems]
    ([BOQId]);
GO

-- Creating foreign key on [TypeId] in table 'Item_Breakdowns'
ALTER TABLE [dbo].[Item_Breakdowns]
ADD CONSTRAINT [FK_Item_Breakdowns_BreakdownItemType]
    FOREIGN KEY ([TypeId])
    REFERENCES [dbo].[BreakdownItemType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Item_Breakdowns_BreakdownItemType'
CREATE INDEX [IX_FK_Item_Breakdowns_BreakdownItemType]
ON [dbo].[Item_Breakdowns]
    ([TypeId]);
GO

-- Creating foreign key on [ParentId] in table 'IndirectCostItems'
ALTER TABLE [dbo].[IndirectCostItems]
ADD CONSTRAINT [FK_IndirectCostItems_IndirectCostItems]
    FOREIGN KEY ([ParentId])
    REFERENCES [dbo].[IndirectCostItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IndirectCostItems_IndirectCostItems'
CREATE INDEX [IX_FK_IndirectCostItems_IndirectCostItems]
ON [dbo].[IndirectCostItems]
    ([ParentId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------