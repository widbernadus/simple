# simple crud in ASP.Net 6 using Dapper to interact with database
<p>simple implementation of Dapper in .Net 6</p>
<p>NuGet Package requirements :</p>
<ul>
  <li>Dapper 2.1.15</li>
  <li>System.Data.SqlClient 6.0.16</li>
</ul>
<p>Creating Database</p>

<b>Book table<b>
```SQL
CREATE TABLE [dbo].[book](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [text] NULL,
	[author] [varchar](150) NULL,
	[publisher] [varchar](150) NULL,
	[year] [int] NULL,
	[ref_genre_id] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
```
<br>

<b>Genre reference table</b>
```SQL
CREATE TABLE [dbo].[ref_genre](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[genre] [varchar](50) NULL
) ON [PRIMARY]
```
<br>
<b>Manually seeding data</b>

```SQL
INSERT INTO ref_genre (genre) VALUES
('Fantasy'),('Science Fiction'), ('Adventure'),
('Romance'),('Horor'), ('Biography')
```
