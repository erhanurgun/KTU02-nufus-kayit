USE [lesson_user]
GO
/****** Object:  Table [dbo].[adres_bilgileri]    Script Date: 12/09/2021 22:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[adres_bilgileri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kisi_id] [int] NULL,
	[ulke] [nvarchar](50) NULL,
	[il] [nvarchar](50) NULL,
	[ilce] [nvarchar](50) NULL,
	[acik_adres] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[diger_bilgiler]    Script Date: 12/09/2021 22:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[diger_bilgiler](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kisi_id] [int] NULL,
	[veren_makam] [nvarchar](100) NULL,
	[verilis_tarihi] [timestamp] NULL,
	[gecerlilik_tarihi] [date] NULL,
	[olu_mu] [bit] NULL,
	[olum_tarihi] [date] NULL,
	[img_foto] [nvarchar](50) NULL,
	[img_imza] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ehliyet_bilgileri]    Script Date: 12/09/2021 22:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ehliyet_bilgileri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kisi_id] [int] NULL,
	[var_mi] [bit] NULL,
	[ehliyet_sinifi] [nchar](10) NULL,
	[verilis_tarihi] [date] NULL,
	[gecerlilik_tarihi] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[personeller]    Script Date: 12/09/2021 22:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personeller](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kayit_tarihi] [timestamp] NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[kullanici_adi] [nvarchar](50) NULL,
	[sifre] [nvarchar](50) NULL,
	[yetki] [bit] NULL,
	[durum] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sabika_bilgileri]    Script Date: 12/09/2021 22:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sabika_bilgileri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kisi_id] [int] NULL,
	[var_mi] [nvarchar](50) NULL,
	[sabika_detay] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[saglik_bilgileri]    Script Date: 12/09/2021 22:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[saglik_bilgileri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kisi_id] [int] NULL,
	[hes_kodu] [nvarchar](50) NULL,
	[kan_grubu] [nchar](10) NULL,
	[var_mi] [bit] NULL,
	[hastalik_detayi] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[temel_bilgiler]    Script Date: 12/09/2021 22:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[temel_bilgiler](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tc] [nvarchar](50) NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
	[anne_adi] [nvarchar](50) NULL,
	[baba_adi] [nvarchar](50) NULL,
	[dogum_tarihi] [date] NULL,
	[dogum_yeri] [nvarchar](50) NULL,
	[aile_sira_no] [int] NULL,
	[birey_sira_no] [int] NULL,
	[cilt_no] [int] NULL,
	[seri_no] [nvarchar](50) NULL,
	[uyrugu] [nvarchar](100) NULL,
	[medeni_hali] [int] NULL,
	[evlenme_tarihi] [date] NULL,
	[bosanma_tarihi] [date] NULL,
	[telefon] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[boy] [float] NULL,
	[kilo] [float] NULL,
	[cinsiyet] [int] NULL,
	[verilis_turu] [int] NULL
) ON [PRIMARY]
GO
