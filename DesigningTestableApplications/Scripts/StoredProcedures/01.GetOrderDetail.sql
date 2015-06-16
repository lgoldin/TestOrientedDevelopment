/****** Object:  StoredProcedure [dbo].[GetOrderDetail]    Script Date: 16/06/2015 10:50:49 a.m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetOrderDetail]') AND type in (N'P', N'PC')) 
DROP PROCEDURE [dbo].[GetOrderDetail]
GO

/****** Object:  StoredProcedure [dbo].[GetOrderDetail]    Script Date: 16/06/2015 10:50:49 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOrderDetail] 
	@OrderId int
AS
BEGIN
	SELECT
		*
	FROM OrderDetail detail
	WHERE detail.Id = @OrderId
END

GO
