USE [PTEdiIndonesia]
GO
/****** Object:  StoredProcedure [dbo].[usp_RiwayatPekerjaan_GetByBioId]    Script Date: 6/8/2024 2:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_RiwayatPekerjaan_GetByBioId] @biodataId int
as
begin
	select * from RiwayatPekerjaan where BiodataId = @biodataId
end