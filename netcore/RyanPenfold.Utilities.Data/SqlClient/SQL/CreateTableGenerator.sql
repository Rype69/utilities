SELECT  'CREATE TABLE [' + ss.name + '].[' + so.name + '] (' + o.list + ')' + CASE WHEN tc.Constraint_Name IS NULL THEN ';' ELSE ' ALTER TABLE [' + ss.name + '].[' + so.name + '] ADD CONSTRAINT ' + tc.Constraint_Name  + ' PRIMARY KEY ' + ' (' + LEFT(j.List, LEN(j.List)-1) + ');' END AS [CreateTable]
FROM    sys.objects so
CROSS APPLY
    (SELECT 
        '  ['+column_name+'] ' + 
        data_type + CASE data_type
                WHEN 'decimal' THEN '(' + CAST(numeric_precision_radix AS VARCHAR) + ', ' + CAST(numeric_scale AS VARCHAR) + ')'
				WHEN 'geography' THEN ''
				WHEN 'geometry' THEN ''
				WHEN 'hierarchyid' THEN ''
				WHEN 'ntext' THEN ''
				WHEN 'image' THEN ''
				WHEN 'ntext' THEN ''
                WHEN 'sql_variant' THEN ''
                WHEN 'text' THEN ''
                WHEN 'xml' THEN ''
                ELSE COALESCE('('+CASE WHEN character_maximum_length = -1 THEN 'MAX' ELSE CAST(character_maximum_length AS VARCHAR) END +')','') END + ' ' +
        CASE WHEN exists ( 
        SELECT id FROM syscolumns
        WHERE OBJECT_NAME(id)=so.name
        AND name=column_name
        AND COLUMNPROPERTY(id,name,'IsIdentity') = 1 
        ) THEN
        'IDENTITY(' + 
        CAST(IDENT_SEED(so.name) AS VARCHAR) + ',' + 
        CAST(IDENT_INCR(so.name) AS VARCHAR) + ')'
        ELSE ''
        END + ' ' +
         (CASE WHEN IS_NULLABLE = 'No' THEN 'NOT ' ELSE '' END) + 'NULL ' + 
          CASE WHEN information_schema.columns.COLUMN_DEFAULT IS NOT NULL THEN 'DEFAULT '+ information_schema.columns.COLUMN_DEFAULT ELSE '' END + ', ' 

     FROM information_schema.columns WHERE table_name = so.name
     ORDER BY ordinal_position
    FOR XML PATH('')) o (list)
LEFT JOIN
    information_schema.table_constraints tc
ON  tc.Table_name = so.Name
AND tc.Constraint_Type  = 'PRIMARY KEY'
CROSS APPLY
    (SELECT '[' + Column_Name + '], '
     FROM       information_schema.key_column_usage kcu
     WHERE      kcu.Constraint_Name     = tc.Constraint_Name
     ORDER BY
        ORDINAL_POSITION
     FOR XML PATH('')) j (list)
	INNER JOIN sys.schemas ss ON so.schema_id = ss.schema_id
	WHERE [type] = 'U'
	AND so.name = @table
	AND ss.name = @schema;