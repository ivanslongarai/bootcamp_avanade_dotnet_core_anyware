using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGamesCatalog.Sctipts
{
    public class Scripts
    {
		/* 
		  
		USE [GamesCatalog]
		GO

		SET ANSI_NULLS ON
		GO

		SET QUOTED_IDENTIFIER ON
		GO

		CREATE TABLE[dbo].[Games]
				(

		   [Id]       [uniqueidentifier] NOT NULL,
		   [Name]     [varchar](50)    NULL,
		   [Producer] [varchar](50)    NULL,
		   [Price]    [decimal](15, 2) NULL,

		 CONSTRAINT[PK_Games] PRIMARY KEY CLUSTERED

		(
		   [Id] ASC
		)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
		) ON[PRIMARY]

		GO
*/
    }
}
