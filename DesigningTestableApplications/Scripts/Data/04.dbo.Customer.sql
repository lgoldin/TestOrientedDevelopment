SET IDENTITY_INSERT [dbo].[Customer] ON
INSERT INTO [dbo].[Customer] ([Id], [FirstName],[LastName],[Email],[Address],[Phone],[Active]) VALUES (1, 'John', 'Doe', 'jdoe@baufest.com', 'Roosevelt 1655', '4855-5572', 1)
INSERT INTO [dbo].[Customer] ([Id], [FirstName],[LastName],[Email],[Address],[Phone],[Active]) VALUES (2, 'Mary', 'Jane', 'mjane@baufest.com', 'Calle Falsa 123', '4962-3699', 1)
SET IDENTITY_INSERT [dbo].[Customer] OFF