1.Use VS 2017 only to run the code.
2. make modifications in the web.config of actual and test application as follows:
	a) add the input file name and location at key CityInputSource
E.G:
    <add key="CityInputSource" value="C:\Users\DELL\Documents\citydetails.txt" />
	b) add the destination folder location at key CityOutputDest
E.G:
    <add key="CityOutputDest" value="C:\Users\DELL\Documents\WeatherApp\WeatherApp\WeatherApp\App_Data" />
	c)add logfile location at key Loglocation
E.G
    <add key="Loglocation" value="C:\Users\DELL\Documents\WeatherApp\WeatherApp\WeatherApp\App_Data\log.txt" />
	d) add the API key at key APIKey
E.G
    <add key="APIKey" value="aa69195559bd4f88d79f9aadeb77a8f6" />
