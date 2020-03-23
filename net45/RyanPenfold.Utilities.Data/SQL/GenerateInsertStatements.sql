-- Declare the variables
DECLARE @InsertStatementTemplate NVARCHAR(MAX);

-- Initialise the variables
--SET @InsertStatementTemplate = 'INSERT INTO [' + @TableName + '] (';
SET @InsertStatementTemplate = 'INSERT INTO [' + @SchemaName + '].[' + @TableName + '] (';

-- Build the first part of the INSERT statement template
SELECT
	@InsertStatementTemplate=COALESCE(@InsertStatementTemplate+'['+[syscolumns].[name]+'],','')
FROM 
	sysobjects 
	JOIN 
		syscolumns ON sysobjects.id = syscolumns.id
	JOIN 
		systypes ON syscolumns.xtype=systypes.xtype
	JOIN
		sysusers ON sysobjects.uid = sysusers.uid
WHERE 
	sysobjects.xtype = 'U'
	AND
	(syscolumns.[status] <> 128 OR @IdentityInsertEnabled = 1)
	AND
	[systypes].[name] <> 'sysname'
	AND
	[sysobjects].[name] = @TableName	
	AND
	[sysusers].[name] = @SchemaName
ORDER BY 
	 sysobjects.name
	,syscolumns.colid;

-- Trim the comma off the right-hand-side of the statement
SET @InsertStatementTemplate=left(@InsertStatementTemplate,LEN(@InsertStatementTemplate)-1)+')'; 

-- Append the text "VALUES" and a bracket
SET @InsertStatementTemplate=@InsertStatementTemplate+' VALUES (';

SELECT 
	@InsertStatementTemplate=COALESCE(@InsertStatementTemplate+ 
	CASE 
	WHEN [systypes].[name]='uniqueidentifier' THEN ''' + ISNULL('''''''' + REPLACE(CAST([' + syscolumns.[name] + '] AS NVARCHAR(MAX)), '''''''', '''''''''''') + '''''''', ''NULL'') + '''
	WHEN [systypes].[name]='varchar' THEN ''' + ISNULL('''''''' + REPLACE(CAST([' + syscolumns.[name] + '] AS NVARCHAR(MAX)), '''''''', '''''''''''') + '''''''', ''NULL'') + '''
	WHEN [systypes].[name]='char' THEN ''' + ISNULL('''''''' + REPLACE(CAST([' + syscolumns.[name] + '] AS NVARCHAR(MAX)), '''''''', '''''''''''') + '''''''', ''NULL'') + '''
	WHEN [systypes].[name]='nvarchar' THEN ''' + ISNULL(''N'''''' + REPLACE(CAST([' + syscolumns.[name] + '] AS NVARCHAR(MAX)), '''''''', '''''''''''') + '''''''', ''NULL'') + '''
	WHEN [systypes].[name]='nchar' THEN ''' + ISNULL('''''''' + REPLACE(CAST([' + syscolumns.[name] + '] AS NVARCHAR(MAX)), '''''''', '''''''''''') + '''''''', ''NULL'') + '''
	WHEN [systypes].[name]='text' THEN ''' + ISNULL('''''''' + REPLACE(CAST([' + syscolumns.[name] + '] AS NVARCHAR(MAX)), '''''''', '''''''''''') + '''''''', ''NULL'') + '''
	WHEN [systypes].[name]='ntext' THEN ''' + ISNULL('''''''' + REPLACE(CAST([' + syscolumns.[name] + '] AS NVARCHAR(MAX)), '''''''', '''''''''''') + '''''''', ''NULL'') + '''
	WHEN [systypes].[name]='datetime' THEN ''' + ISNULL('''''''' + REPLACE(CONVERT(NVARCHAR(MAX), [' + syscolumns.[name] + '], 126), '''''''', '''''''''''') + '''''''', ''NULL'') + '''
	WHEN [systypes].[name]='smalldatetime' THEN ''' + ISNULL('''''''' + REPLACE(CONVERT(NVARCHAR(MAX), [' + syscolumns.[name] + '], 126), '''''''', '''''''''''') + '''''''', ''NULL'') + '''
	WHEN [systypes].[name]='image' THEN ''' + ISNULL(MASTER.dbo.Fn_varbintohexstr([' + syscolumns.[name] + ']) + '''', ''NULL'') + '''
	WHEN [systypes].[name]='binary' THEN ''' + ISNULL(MASTER.dbo.Fn_varbintohexstr([' + syscolumns.[name] + ']) + '''', ''NULL'') + '''
	WHEN [systypes].[name]='varbinary' THEN ''' + ISNULL(MASTER.dbo.Fn_varbintohexstr([' + syscolumns.[name] + ']) + '''', ''NULL'') + '''
	ELSE ''' + ISNULL(REPLACE(CAST([' + syscolumns.[name] + '] AS NVARCHAR(MAX)), '''''''', ''''''''''''), ''NULL'') + '''
	END + ',','')
FROM 
	sysobjects 
	JOIN 
		syscolumns ON sysobjects.id = syscolumns.id
	JOIN 
		systypes ON syscolumns.xtype=systypes.xtype
	--JOIN
		--sysusers ON sysobjects.uid = sysusers.uid
WHERE 
	sysobjects.xtype = 'U'
	AND
	(syscolumns.[status] <> 128 OR @IdentityInsertEnabled = 1)
	AND
	[systypes].[name] <> 'sysname'
	AND
	[sysobjects].[name] = @TableName
	--AND
	--[sysusers].[name] = @SchemaName
	AND
	COLUMNPROPERTY(sysobjects.id, syscolumns.name, 'isIdentity') = 0
ORDER BY 
	 sysobjects.name
	,syscolumns.colid;

-- Trim the comma off the right-hand-side of the statement
SET @InsertStatementTemplate=LEFT(@InsertStatementTemplate,LEN(@InsertStatementTemplate)-1); 

-- Encase the INSERT statement template into a SELECT statement
SET @InsertStatementTemplate='SELECT '''+@InsertStatementTemplate+');'' AS [InsertStatement] FROM [' + @SchemaName + '].[' + @TableName + '];';
--SET @InsertStatementTemplate='SELECT '''+@InsertStatementTemplate+');'' AS [InsertStatement] FROM [' + @TableName + '];';

--SELECT @InsertStatementTemplate;

-- Run the query
EXEC sp_executesql @InsertStatementTemplate;
