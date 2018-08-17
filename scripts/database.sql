USE [RoomSecurity]
GO
/****** Object:  Table [dbo].[AlarmStatus]    Script Date: 8/17/2018 11:58:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlarmStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomName] [nvarchar](50) NOT NULL,
	[CurrentTime] [nvarchar](50) NOT NULL,
	[IntruderBadges] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Badges]    Script Date: 8/17/2018 11:58:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Badges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cameras]    Script Date: 8/17/2018 11:58:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cameras](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Monitors]    Script Date: 8/17/2018 11:58:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monitors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[UiId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Monitors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PresenceRules]    Script Date: 8/17/2018 11:58:48 AM ******/
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
/****** Object:  Table [dbo].[Rooms]    Script Date: 8/17/2018 11:58:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[MonitorId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/17/2018 11:58:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AlarmStatus] ON 

INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (2910, N'armory', N'10:00:00', N'NoBadge ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (1, N'Hall', N'00:30:00', N'Support ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (2, N'Hall', N'01:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (3, N'Hall', N'02:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (4, N'Conference room', N'02:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (5, N'Hall', N'02:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (6, N'Hall', N'03:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (7, N'Conference room', N'03:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (8, N'Hall', N'03:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (9, N'Hall', N'04:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (10, N'Hall', N'05:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (11, N'Conference room', N'05:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (12, N'Hall', N'05:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (13, N'Conference room', N'05:30:00', N'Support ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (14, N'Hall', N'06:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (15, N'Hall', N'06:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (16, N'Hall', N'07:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (17, N'Conference room', N'07:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (18, N'Conference room', N'07:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (19, N'Hall', N'08:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (20, N'Conference room', N'15:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (21, N'Conference room', N'16:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (22, N'Conference room', N'16:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (23, N'Hall', N'17:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (24, N'Hall', N'19:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (25, N'Conference room', N'19:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (26, N'Conference room', N'19:30:00', N'NoBadge ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (27, N'Hall', N'20:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (28, N'Conference room', N'21:30:00', N'NoBadge ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (29, N'Hall', N'22:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (30, N'Hall', N'22:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (31, N'Conference room', N'22:30:00', N'Support ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (32, N'Hall', N'00:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (33, N'Conference room', N'00:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (34, N'Hall', N'01:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (35, N'Conference room', N'01:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (36, N'Hall', N'02:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (37, N'Hall', N'02:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (38, N'Conference room', N'02:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (39, N'Conference room', N'03:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (40, N'Hall', N'03:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (41, N'Hall', N'04:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (42, N'Conference room', N'04:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (43, N'Conference room', N'05:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (44, N'Hall', N'06:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (45, N'Conference room', N'06:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (46, N'Conference room', N'07:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (47, N'Hall', N'09:00:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (48, N'Hall', N'09:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (49, N'Conference room', N'09:30:00', N'Visitor ')
INSERT [dbo].[AlarmStatus] ([Id], [RoomName], [CurrentTime], [IntruderBadges]) VALUES (50, N'Conference room', N'15:30:00', N'Visitor ')
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

INSERT [dbo].[Monitors] ([Id], [Name], [UiId]) VALUES (1, N'First floor', N'eb3f2762-493b-4a9e-ad69-85ed3fabe6c4')
INSERT [dbo].[Monitors] ([Id], [Name], [UiId]) VALUES (2, N'Second floor', N'0c2e65f2-6d49-4069-9689-383f8ce3e07d')
INSERT [dbo].[Monitors] ([Id], [Name], [UiId]) VALUES (3, N'Lobby', N'455f01ff-3cc2-4f15-bf5f-882b4bc869e5')
INSERT [dbo].[Monitors] ([Id], [Name], [UiId]) VALUES (4, N'Elevator', N'09a9bd11-4da4-485b-83cb-2d5e15738f63')
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
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([Id], [Name], [MonitorId]) VALUES (1, N'Conference room', 1)
INSERT [dbo].[Rooms] ([Id], [Name], [MonitorId]) VALUES (2, N'Hall', 1)
INSERT [dbo].[Rooms] ([Id], [Name], [MonitorId]) VALUES (3, N'Dinner room', 2)
INSERT [dbo].[Rooms] ([Id], [Name], [MonitorId]) VALUES (4, N'Armory room', 2)
SET IDENTITY_INSERT [dbo].[Rooms] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (1, N'Ivan', N'Ivanov', N'ivanov@ukr.net', N'1234')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Monitors] ADD  CONSTRAINT [DF_Monitors_UiId]  DEFAULT (newid()) FOR [UiId]
GO
ALTER TABLE [dbo].[Rooms] ADD  DEFAULT ((0)) FOR [MonitorId]
GO
