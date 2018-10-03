USE [master]
GO
/****** Object:  Database [RoomSecurity]    Script Date: 03.10.2018 18:07:54 ******/
CREATE DATABASE [RoomSecurity]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RoomSecurity', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\RoomSecurity.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RoomSecurity_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\RoomSecurity_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [RoomSecurity] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RoomSecurity].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RoomSecurity] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RoomSecurity] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RoomSecurity] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RoomSecurity] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RoomSecurity] SET ARITHABORT OFF 
GO
ALTER DATABASE [RoomSecurity] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [RoomSecurity] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RoomSecurity] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RoomSecurity] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RoomSecurity] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RoomSecurity] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RoomSecurity] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RoomSecurity] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RoomSecurity] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RoomSecurity] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RoomSecurity] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RoomSecurity] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RoomSecurity] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RoomSecurity] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RoomSecurity] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RoomSecurity] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [RoomSecurity] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RoomSecurity] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RoomSecurity] SET  MULTI_USER 
GO
ALTER DATABASE [RoomSecurity] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RoomSecurity] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RoomSecurity] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RoomSecurity] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RoomSecurity] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RoomSecurity] SET QUERY_STORE = OFF
GO
USE [RoomSecurity]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [RoomSecurity]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 03.10.2018 18:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlarmStatus]    Script Date: 03.10.2018 18:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlarmStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomId] [int] NOT NULL,
	[Time] [datetime2](0) NOT NULL,
	[BadgeId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Badges]    Script Date: 03.10.2018 18:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Badges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cameras]    Script Date: 03.10.2018 18:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cameras](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Monitors]    Script Date: 03.10.2018 18:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monitors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[UiId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PresenceRules]    Script Date: 03.10.2018 18:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PresenceRules](
	[RoomId] [int] NOT NULL,
	[BadgeId] [int] NOT NULL,
	[StartTime] [time](0) NULL,
	[EndTime] [time](0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 03.10.2018 18:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolesMonitors]    Script Date: 03.10.2018 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolesMonitors](
	[RoleId] [int] NOT NULL,
	[MonitorId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 03.10.2018 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[MonitorId] [int] NOT NULL,
	[UiId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 03.10.2018 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersRoles]    Script Date: 03.10.2018 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201808201244094_added Guid to Room', N'Security.DataLayer.Migrations.Configuration', 0x1F8B0800000000000400ED58DB6EE336107D2FD07F10F8D4025933979736907791DAC922689C047176DF6969EC10A5482D49A5F6B7ED433FA9BFD0A1AEB4E46B9C0D8AC52240608D38672E9CABFEFDFA4FF8619E88E019B4E14AF6C949EF98042023157339EB93CC4EDFFD463EBCFFF9A7F0324EE6C1E7EADC993B879CD2F4C993B5E939A5267A8284995EC223AD8C9ADA5EA412CA62454F8F8F7FA72727141082205610840F99B43C81FC011F074A4690DA8C89918A4198928E6FC6396A70CB1230298BA04FC610659ADB456FC82CBB610BD024B8109C19F74A4C49C0A4549659D4F3FC9381B1D54ACEC6291298785CA480E7A64C1828F53F6F8EEF6ACAF1A93385368C15549419AB923D014FCE4ADFD036FB8B3C4C6ADFA1F72ED1CB76E1ACCE3DD8270F4A2524680B3A1F08ED0EAD726ECFB11C05DD1747753460D0B8BFA36090099B69E84BC8AC66E228B8CF2682477FC2E251FD05B22F33217CFD50437CB74440D2BD562968BB788069A9F5754C02BACC47DB8C359BC753D8742DEDD929096E51389B08A8AFDFB37F6C95868F2041330BF13DB316B47418903BB023BD25EB63C6E3469E7B5A216E3384FB5F0160C862F69160C4E6372067F6A94FF02709AEF81CE28A52A27E921C931599ACCEB60A1929C9D1D2EDAEF16142DA44D1C6D8C264D37BC69663F9115B1B655D716DEC9B44C70D7B23419709E3E29B4BB967C6FCAD74FCCA8236A7033632CB38DE75A94415DAC3897B0373BB22413009CA1C31A5C065BB0AE43158AF861B12346A148DAF57D476BA99D965DC2AE6227957195A9BD434655A74E5AA7BD335ED3B1CB134459F7BEDBCA404E3A2970FDE8DF76F7249814123B3A2D7D5DAD69230FDD80C5A6F51346A9AE7962B3A13E66E7D10279D63DD0B5CE3DF4A9E7F47EDEAD378BD3AED7E2F474AABF3B6311A1F5EA15909D690DC42A8F5287B7C872D9FA598607A452D1B289125725D3DDCC45D753E1FA1A2ED8E52541D1FA3A0EC8EE075361FC62377B142DAF264FBBA68E7BE5A7DA27DF93B854691810786469EAEFB87C66AB66F131A5EE3F2413CF2EE584D6BF2A11AEAEE4865EFF1614AD2EE184D67F1611AEA1B875AA750B78FD4D2EB82DD2ACC615924B72F5F9DAA591C2101BAE899C779C55C180B491EABBDF11731101CED6D0E8C98E45330B698DA08EE3FA7ADFDEDFFB34B516362B1C342F5E66327771EDD3A58EEB9822C6F3199E45F32E039D894BBE1E0808D463E331D3D31FD4BC2E6BFFA482FDA5A72EB5F7167F93EAEAFB3281CE4F4F6327010D8D2C07F10527BA8DF036CBFC1BD3B1E6E1FCAD7CEE44591EC9378A250F142C1728ADF615C5F3BADAF822DE7FB170EF2DD3E1052FF535D3804C3670D84FB7027217205B601ADCE5CCBA9AAAE0F2DF235AA8EB4331D2C8BD1DF171A6B0E8B2CBE8EC0987C6DFBCC449687D204E26B7997D934B317C64032114B3B744837CBCFB795659DC3BBD43D99D73001D5E46802DCC93F322EE25AEFAB15456A0D840BBDB22EA056B8B622DC6C5123DD2AB92350E9BE21A4205D55798424150866EEE4983DC34B74C3F0BA81198B16553B5F0FB2FD2296DD1E0E399B69969812A3E1779F9FA9FBFEFCFE3F6A9A7C30B1160000, N'6.2.0-61023')
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201808201506380_renamed Room property', N'Security.DataLayer.Migrations.Configuration', 0x1F8B0800000000000400ED58DB6EE336107D2FD07F10F8D4025933979736907791DAC922689C0471B2EFB434768852A496A452FBDBF6A19FD45FE850575AF235CE0645510408AC11E7CC8573D5DFDFFE0A3FCD1311BC80365CC93E39E91D930064A4622E677D92D9E9875FC8A78F3FFE105EC6C93CF8529D3B73E790539A3E79B6363DA7D444CF9030D34B78A4955153DB8B544259ACE8E9F1F1AFF4E484024210C40A82F021939627903FE0E340C908529B313152310853D2F1CD38470D6E5902266511F4C918A24C73BBE80D9965376C019A04178233E35E8929099894CA328B7A9E3F19185BADE46C9C228189C7450A786ECA848152FFF3E6F8AEA61C9F3A5368C358414599B12AD913F0E4ACF40D6DB3BFCAC3A4F61D7AEF12BD6C17CEEADC837DF2A0544282B6A0F381D0EED02AE7F61CCB51D07D71544703068DFB3B0A0699B09986BE84CC6A268E82FB6C2278F43B2C1ED51F20FB3213C2D70F35C4774B0424DD6B9582B68B0798965A5FC724A0CB7CB4CD58B3793C854DD7D29E9D92E01685B38980FAFA3DFBC75669F80C1234B310DF336B414B8701B9033BD25BB29E7823ED73C6E315C23603B8FF1500062CE61E09466C7E0372669FFB047F92E08ACF21AE2825EA93E498AAC86475B655C848498E766E778C0F13D22686364616A69ADE33B21CCBFF91B551D615D7C6BE4B74DCB077127499302EBEBB947B66CC9F4AC76F2C68733A601BB38CE35D974A54A13D9CB83730B72B120493A0CC11530A5CB6AB401E83F52AB82141A346D1F67A4565A79B995DC6AD622E927795A1B5494D4BA6454FAE7A375DD3BCC3114B53F4B9D7CC4B4A302E3AF9E0C378FF1697141834322B3A5DAD6D2D09D38FCDA0F51645A3A6796EB9A23361EED60771D239D6BDC035FEADE4F977D4AE3E8DD7ABD3EEF772A4B4FA6E1BA3F1E1159A95600DC92D845A8FB2C377D8F2498A09A657D4B281125922D7D5C34DDC45DFF3F90BCAEE0845C5F1110ACAEE085E57F3613C72172BA42D2FB6AF8A76EEAAD523DA17BF535814D9776058E4A9BA7F58AC66FB3E61E1352D1FC423EF8ED5B4251FAAA1EE8E54F61D1FA624ED8ED174151FA6A1BE73A8758A74FB482DBD2ED6ADA21C960572FBDAD5A998C51112A08B5E789C57CB85B190E4B1DA1B7F1503C1D1DEE6C088493E05638B898DE0E673DADADCFE3D5B143526163BAC52EF3E7272E7D1AD43E59EEB87BFBF64927FCD80E75053EEC682037619F9C274F4CCF44F099BFFEC23BD6A5FC96D7FC36DE5BF71799D15E120A7B7D78083C09646FD8390DAE3FC1E60FB8DECDDC170FB38BE761A2F4A649FC413858A170A96F3FB0E83FADA397D156C39D9BF7284EF768190FA9FE8C221183E6B20DC073B09912BAF0D6875E65A4E55757D6891AF5175A49DE960598CFEBED058735864F17504C6E40BDB1726B23C9426105FCBBBCCA699BD3006928958DA9E43BA597EBEA72CEB1CDEA5EEC9BC8509A8264713E04EFE967111D77A5FAD28526B205CE8957501B5C28515E1668B1AE956C91D814AF70D2105E9AACA2324A940307327C7EC055EA31B86D70DCC58B4A89AF97A90ED17B1ECF670C8D94CB3C494180DBFFBEC4CDD77E78FFF001DD2922EA9160000, N'6.2.0-61023')
SET IDENTITY_INSERT [dbo].[AlarmStatus] ON 

INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2918, 1, CAST(N'2018-08-18T00:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2919, 2, CAST(N'2018-08-19T01:30:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2920, 3, CAST(N'2018-08-20T02:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2921, 4, CAST(N'2018-08-21T02:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2922, 1, CAST(N'2018-08-22T02:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2923, 2, CAST(N'2018-08-23T03:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2924, 3, CAST(N'2018-08-24T03:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2925, 4, CAST(N'2018-08-25T03:30:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2926, 1, CAST(N'2018-08-26T04:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2927, 2, CAST(N'2018-08-27T05:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2928, 3, CAST(N'2018-08-28T05:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2929, 4, CAST(N'2018-08-29T00:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2930, 1, CAST(N'2018-08-30T05:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2931, 2, CAST(N'2018-08-31T06:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2932, 3, CAST(N'2018-08-18T06:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2933, 4, CAST(N'2018-08-19T07:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2934, 1, CAST(N'2018-08-20T07:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2935, 2, CAST(N'2018-08-21T07:30:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2936, 3, CAST(N'2018-08-22T08:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2937, 4, CAST(N'2018-08-23T15:30:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2938, 1, CAST(N'2018-08-24T16:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2939, 2, CAST(N'2018-08-25T16:30:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2940, 3, CAST(N'2018-08-26T17:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2941, 4, CAST(N'2018-08-27T19:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (1, 1, CAST(N'2018-08-28T00:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (2, 2, CAST(N'2018-08-29T01:30:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (3, 3, CAST(N'2018-08-30T02:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (4, 4, CAST(N'2018-08-31T02:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (5, 1, CAST(N'2018-08-18T02:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (6, 2, CAST(N'2018-08-19T03:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (7, 3, CAST(N'2018-08-20T03:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (8, 4, CAST(N'2018-08-21T03:30:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (9, 1, CAST(N'2018-08-22T04:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (10, 2, CAST(N'2018-08-23T05:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (11, 3, CAST(N'2018-08-24T05:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (12, 4, CAST(N'2018-08-25T05:30:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (13, 1, CAST(N'2018-08-26T05:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (14, 2, CAST(N'2018-08-27T06:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (15, 3, CAST(N'2018-08-28T06:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (16, 4, CAST(N'2018-08-29T07:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (17, 1, CAST(N'2018-08-30T07:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (18, 2, CAST(N'2018-08-31T07:30:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (19, 3, CAST(N'2018-08-18T08:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (20, 4, CAST(N'2018-08-19T15:30:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (21, 1, CAST(N'2018-08-20T16:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (22, 2, CAST(N'2018-08-21T16:30:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (23, 3, CAST(N'2018-08-22T17:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (24, 4, CAST(N'2018-08-23T19:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (25, 1, CAST(N'2018-08-24T00:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (26, 2, CAST(N'2018-08-25T01:30:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (27, 3, CAST(N'2018-08-26T02:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (28, 4, CAST(N'2018-08-27T02:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (29, 1, CAST(N'2018-08-28T02:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (30, 2, CAST(N'2018-08-29T03:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (31, 3, CAST(N'2018-08-30T03:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (32, 4, CAST(N'2018-08-31T03:30:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (33, 1, CAST(N'2018-08-18T04:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (34, 2, CAST(N'2018-08-19T05:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (35, 3, CAST(N'2018-08-18T05:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (36, 4, CAST(N'2018-08-18T05:30:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (37, 1, CAST(N'2018-08-19T05:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (38, 2, CAST(N'2018-08-19T06:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (39, 3, CAST(N'2018-08-19T06:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (40, 4, CAST(N'2018-08-19T07:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (41, 1, CAST(N'2018-08-19T07:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (42, 2, CAST(N'2018-08-19T07:30:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (43, 3, CAST(N'2018-08-19T08:30:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (44, 4, CAST(N'2018-08-20T15:30:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (45, 1, CAST(N'2018-08-20T16:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (46, 2, CAST(N'2018-08-20T16:30:00.0000000' AS DateTime2), 4)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (47, 3, CAST(N'2018-08-20T17:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[AlarmStatus] ([Id], [RoomId], [Time], [BadgeId]) VALUES (48, 4, CAST(N'2018-08-20T19:00:00.0000000' AS DateTime2), 4)
SET IDENTITY_INSERT [dbo].[AlarmStatus] OFF
SET IDENTITY_INSERT [dbo].[Badges] ON 

INSERT [dbo].[Badges] ([Id], [Name]) VALUES (1, N'Visitor')
INSERT [dbo].[Badges] ([Id], [Name]) VALUES (2, N'Support')
INSERT [dbo].[Badges] ([Id], [Name]) VALUES (3, N'SecurityOfficer')
INSERT [dbo].[Badges] ([Id], [Name]) VALUES (4, N'NoBadge')
SET IDENTITY_INSERT [dbo].[Badges] OFF
SET IDENTITY_INSERT [dbo].[Cameras] ON 

INSERT [dbo].[Cameras] ([Id], [RoomId]) VALUES (1, 1)
INSERT [dbo].[Cameras] ([Id], [RoomId]) VALUES (2, 1)
INSERT [dbo].[Cameras] ([Id], [RoomId]) VALUES (3, 1)
INSERT [dbo].[Cameras] ([Id], [RoomId]) VALUES (4, 1)
INSERT [dbo].[Cameras] ([Id], [RoomId]) VALUES (5, 2)
INSERT [dbo].[Cameras] ([Id], [RoomId]) VALUES (6, 2)
INSERT [dbo].[Cameras] ([Id], [RoomId]) VALUES (7, 2)
INSERT [dbo].[Cameras] ([Id], [RoomId]) VALUES (8, 2)
INSERT [dbo].[Cameras] ([Id], [RoomId]) VALUES (9, 3)
INSERT [dbo].[Cameras] ([Id], [RoomId]) VALUES (10, 3)
INSERT [dbo].[Cameras] ([Id], [RoomId]) VALUES (11, 3)
INSERT [dbo].[Cameras] ([Id], [RoomId]) VALUES (12, 3)
INSERT [dbo].[Cameras] ([Id], [RoomId]) VALUES (13, 4)
INSERT [dbo].[Cameras] ([Id], [RoomId]) VALUES (14, 4)
INSERT [dbo].[Cameras] ([Id], [RoomId]) VALUES (15, 4)
INSERT [dbo].[Cameras] ([Id], [RoomId]) VALUES (16, 4)
SET IDENTITY_INSERT [dbo].[Cameras] OFF
SET IDENTITY_INSERT [dbo].[Monitors] ON 

INSERT [dbo].[Monitors] ([Id], [Name], [UiId]) VALUES (1, N'First floor', N'5e3267c8-f418-4815-bfbd-a8c86cbfa8dc')
INSERT [dbo].[Monitors] ([Id], [Name], [UiId]) VALUES (2, N'Second floor', N'bd2e73a6-b6bb-45d9-a0a2-2b574db8e7fc')
SET IDENTITY_INSERT [dbo].[Monitors] OFF
INSERT [dbo].[PresenceRules] ([RoomId], [BadgeId], [StartTime], [EndTime]) VALUES (1, 1, CAST(N'10:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[PresenceRules] ([RoomId], [BadgeId], [StartTime], [EndTime]) VALUES (1, 2, CAST(N'08:00:00' AS Time), CAST(N'20:00:00' AS Time))
INSERT [dbo].[PresenceRules] ([RoomId], [BadgeId], [StartTime], [EndTime]) VALUES (1, 3, CAST(N'00:00:00' AS Time), CAST(N'23:59:59' AS Time))
INSERT [dbo].[PresenceRules] ([RoomId], [BadgeId], [StartTime], [EndTime]) VALUES (1, 4, CAST(N'00:00:00' AS Time), CAST(N'00:00:00' AS Time))
INSERT [dbo].[PresenceRules] ([RoomId], [BadgeId], [StartTime], [EndTime]) VALUES (2, 1, CAST(N'10:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[PresenceRules] ([RoomId], [BadgeId], [StartTime], [EndTime]) VALUES (3, 1, CAST(N'10:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[PresenceRules] ([RoomId], [BadgeId], [StartTime], [EndTime]) VALUES (4, 1, CAST(N'10:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[PresenceRules] ([RoomId], [BadgeId], [StartTime], [EndTime]) VALUES (2, 2, CAST(N'08:00:00' AS Time), CAST(N'20:00:00' AS Time))
INSERT [dbo].[PresenceRules] ([RoomId], [BadgeId], [StartTime], [EndTime]) VALUES (3, 2, CAST(N'08:00:00' AS Time), CAST(N'20:00:00' AS Time))
INSERT [dbo].[PresenceRules] ([RoomId], [BadgeId], [StartTime], [EndTime]) VALUES (4, 2, CAST(N'08:00:00' AS Time), CAST(N'20:00:00' AS Time))
INSERT [dbo].[PresenceRules] ([RoomId], [BadgeId], [StartTime], [EndTime]) VALUES (2, 3, CAST(N'00:00:00' AS Time), CAST(N'23:59:59' AS Time))
INSERT [dbo].[PresenceRules] ([RoomId], [BadgeId], [StartTime], [EndTime]) VALUES (3, 3, CAST(N'00:00:00' AS Time), CAST(N'23:59:59' AS Time))
INSERT [dbo].[PresenceRules] ([RoomId], [BadgeId], [StartTime], [EndTime]) VALUES (4, 3, CAST(N'00:00:00' AS Time), CAST(N'23:59:59' AS Time))
INSERT [dbo].[PresenceRules] ([RoomId], [BadgeId], [StartTime], [EndTime]) VALUES (1, 4, CAST(N'00:00:00' AS Time), CAST(N'00:00:00' AS Time))
INSERT [dbo].[PresenceRules] ([RoomId], [BadgeId], [StartTime], [EndTime]) VALUES (1, 4, CAST(N'00:00:00' AS Time), CAST(N'00:00:00' AS Time))
INSERT [dbo].[PresenceRules] ([RoomId], [BadgeId], [StartTime], [EndTime]) VALUES (1, 4, CAST(N'00:00:00' AS Time), CAST(N'00:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Role]) VALUES (1, N'Chief               ')
INSERT [dbo].[Roles] ([Id], [Role]) VALUES (2, N'first floor chief   ')
INSERT [dbo].[Roles] ([Id], [Role]) VALUES (3, N'second floor chief  ')
SET IDENTITY_INSERT [dbo].[Roles] OFF
INSERT [dbo].[RolesMonitors] ([RoleId], [MonitorId]) VALUES (1, 1)
INSERT [dbo].[RolesMonitors] ([RoleId], [MonitorId]) VALUES (1, 2)
INSERT [dbo].[RolesMonitors] ([RoleId], [MonitorId]) VALUES (2, 2)
INSERT [dbo].[RolesMonitors] ([RoleId], [MonitorId]) VALUES (3, 3)
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([Id], [Name], [MonitorId], [UiId]) VALUES (1, N'Conference room', 1, N'73299ff6-4ea2-4dfc-b3dc-1943fa67c809')
INSERT [dbo].[Rooms] ([Id], [Name], [MonitorId], [UiId]) VALUES (2, N'Hall', 1, N'74341205-65f6-4ec3-99fe-74226b8f97c7')
INSERT [dbo].[Rooms] ([Id], [Name], [MonitorId], [UiId]) VALUES (3, N'Dinner room', 2, N'476ee2ba-d790-41af-98a4-8d4a4d288fba')
INSERT [dbo].[Rooms] ([Id], [Name], [MonitorId], [UiId]) VALUES (4, N'Armory room', 2, N'7f9ef98f-2d92-4c02-9d6f-2a81098fc671')
SET IDENTITY_INSERT [dbo].[Rooms] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (1, N'Ivan', N'Ivanov', N'ivanov@ukr.net', N'000102030405060708090A0B0C0D0E0F10111213')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (2, N'Petro', N'Petrov', N'petrov@ukr.net', N'000102030405060708090A0B0C0D0E0F10111213')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (3, N'Sidor', N'Sidorov', N'sidorov@ukr.net', N'000102030405060708090A0B0C0D0E0F10111213')
SET IDENTITY_INSERT [dbo].[Users] OFF
INSERT [dbo].[UsersRoles] ([UserId], [RoleId]) VALUES (1, 1)
INSERT [dbo].[UsersRoles] ([UserId], [RoleId]) VALUES (2, 2)
INSERT [dbo].[UsersRoles] ([UserId], [RoleId]) VALUES (3, 3)
ALTER TABLE [dbo].[Monitors] ADD  CONSTRAINT [DF_Monitors_UiId]  DEFAULT (newid()) FOR [UiId]
GO
ALTER TABLE [dbo].[Rooms] ADD  CONSTRAINT [DF__Rooms__UiId__73852659]  DEFAULT (newid()) FOR [UiId]
GO
/****** Object:  StoredProcedure [dbo].[sp_AlarmStatusByRoomUiId]    Script Date: 03.10.2018 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AlarmStatusByRoomUiId]
  @id uniqueidentifier
AS
   SELECT AlarmStatus.Time, Badges.Name FROM AlarmStatus 
 JOIN Badges on AlarmStatus.BadgeId = Badges.Id
 JOIN Rooms on Rooms.Id = AlarmStatus.RoomId
 WHERE RoomId = (SELECT Rooms.Id from Rooms where Rooms.UiId = @id)
GO
/****** Object:  StoredProcedure [dbo].[sp_GeMonitorTabs]    Script Date: 03.10.2018 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GeMonitorTabs]
AS
 SELECT UiId, Name FROM Monitors
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCamerasByRoomId]    Script Date: 03.10.2018 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetCamerasByRoomId]
  @roomId int
AS
  SELECT Id FROM Cameras WHERE RoomId = @roomId
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMonitorIdByUiId]    Script Date: 03.10.2018 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetMonitorIdByUiId]
  @uiId uniqueidentifier
AS
 Select Id from Monitors where UiId = @uiId
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMonitorTabsbyEmail]    Script Date: 03.10.2018 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetMonitorTabsbyEmail]  
    @email nvarchar(50) 
AS
Select Monitors.Name, Monitors.UiId from Monitors 
join RolesMonitors on  Monitors.Id = RolesMonitors.MonitorId
join UsersRoles on RolesMonitors.RoleId = UsersRoles.RoleId
join Users on UsersRoles.UserId = Users.Id
where Users.Email =  @email;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPresenceRulesByRoomId]    Script Date: 03.10.2018 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPresenceRulesByRoomId]
  @roomId int
AS
  SELECT BadgeId, StartTime, EndTime from PresenceRules WHERE RoomId=@roomId
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRoomIdByUiId]    Script Date: 03.10.2018 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetRoomIdByUiId]
  @UiId uniqueidentifier
AS
  Select Id from Rooms where UiId = @uiId
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRoomInfoById]    Script Date: 03.10.2018 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetRoomInfoById]
  @roomId int
AS
  Select Name, UiId from Rooms where Id = @roomId
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRoomsIdsbyMonitorId]    Script Date: 03.10.2018 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetRoomsIdsbyMonitorId]
  @monitorId int
AS
  Select Id from Rooms where MonitorId = @monitorId
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAlarmStatus]    Script Date: 03.10.2018 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertAlarmStatus]
  @roomId int,
  @statusTime DateTime2(0),
  @intruderId int
AS
  INSERT INTO AlarmStatus (RoomId, Time, BadgeId) VALUES (@roomId, @statusTime, @intruderId)
GO
/****** Object:  StoredProcedure [dbo].[sp_InserUser]    Script Date: 03.10.2018 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InserUser]
@firstName varchar(50)
           ,@lastName varchar(50)
           ,@email varchar(50)
           ,@password varchar(50)
		   AS
INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[LastName]
           ,[Email]
           ,[Password])
     VALUES
           (@firstName
           ,@lastName
           ,@email
           ,@password)
GO
/****** Object:  StoredProcedure [dbo].[sp_UserExistsByEmailAndPassword]    Script Date: 03.10.2018 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UserExistsByEmailAndPassword]
  @email varchar(50),
  @password varchar(50)
AS
  Select count(*) from Users Where Email=@email and Password=@password
GO
USE [master]
GO
ALTER DATABASE [RoomSecurity] SET  READ_WRITE 
GO
