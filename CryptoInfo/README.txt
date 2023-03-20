The following tasks were realized:

•	It must be a multi-page application with navigation.
•	The main page displays the top 10 currencies returned by the API.
•	Page with the ability to view detailed information about the currency: price, volume, price change, in which markets it can be purchased and at what price.
•	Possibility of searching for currency by name or code.
•	Usage of MVVM.

It will be a plus if the program implements additional functions (the more, the better):
•	Displaying quote charts for currencies (Japanese candlestick chart or some other).
•	Page in which you can convert one currency to another (we neglect the method and possible commission).
•	Light / dark theme support.
•	Support for multiple localizations.

Not implemented the ability to go to the currency page on the market.

-----------------------------------------------------------------------------
Below I will describe the interface and how to use it.

You can navigate through the menu on the left, clicking on the buttons (Top Crypto, More Info, Convert Currency, Candles) will open pages with different functionality.
Close closes the program.
Under the Close button, there is a field where you can select a localization.
At the very bottom of the menu, there is a switch between dark and light themes.

The Top Crypto page is the main page, displaying the top 10 cryptocurrencies and minimal information about them.

The More Info page contains more detailed information about the top 10 cryptocurrencies by default, at the top of the page there is a text field, this is a search,
you can enter the code or name of the cryptocurrency and press Enter, and the cryptocurrencies will be found.

The Convert Currency page, in the first ComboBox you can also find a cryptocurrency by code or name, after pressing Enter you can select one currency from the drop-down list.
Do the same with the second ComboBox, enter the amount of cryptocurrency you want to convert in the test field and click on the button to get the result.

The Candles page has a Japanese candlestick chart, and by default, when opened, it will display a Bitcoin chart, each candle is 4 hours long, and the entire chart shows a period of 30 days.
Such charts can be viewed for the top 10 currencies, at the top of the chart you can select the currency, candlestick interval, and period for the chart in the ComboBox,
and the chart will be plotted after clicking on the button.


CoinCapAri is used for all functions except Japanese candlesticks. 
For candlesticks, CoinApi is used (its biggest problem is that the key is limited to 100 requests per day, so you may need another key).