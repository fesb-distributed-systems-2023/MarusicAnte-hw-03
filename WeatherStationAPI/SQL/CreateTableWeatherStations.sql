CREATE TABLE &quot;WeatherStations&quot; (

	&quot;ID&quot;	INTEGER NOT NULL UNIQUE,

	&quot;Name&quot;	TEXT,

	&quot;Location&quot;	TEXT,

	&quot;Temperature&quot;	INTEGER,

	&quot;Humidity&quot;	INTEGER,

	&quot;WindSpeed&quot;	INTEGER,

	PRIMARY KEY(&quot;ID&quot; AUTOINCREMENT)

);