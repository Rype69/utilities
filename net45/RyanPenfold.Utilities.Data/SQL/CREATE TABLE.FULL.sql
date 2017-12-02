/****** Object:  Table [{tableSchema}].[{tableName}]    Script Date: {date} {time} ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{tableSchema}].[{tableName}]') AND type in (N'U'))
DROP TABLE [{tableSchema}].[{tableName}]
GO

/****** Object:  Table [{tableSchema}].[{tableName}]    Script Date: {date} {time} ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{tableSchema}].[{tableName}]') AND type in (N'U'))
BEGIN
CREATE TABLE [{tableSchema}].[{tableName}](
{columns}
);
END
GO

SET ANSI_PADDING OFF
GO
