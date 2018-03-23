
namespace Insomnia.Controllers
{
    using ExchangeSharp;

    public static class ExchangeController
    {
        public static string GetPrice(string symbol, ExchangeAPI exchangeAPI)
        {
            var ticker = exchangeAPI.GetTicker(exchangeAPI.NormalizeSymbol(symbol));
            return ticker.Last.ToString();
        }

        public static string LimitBuy(string symbol, decimal amount, decimal price)
        {
            return MarketBuy(symbol, amount, price, new ExchangeBinanceAPI());
        }

        public static string LimitBuy(string symbol, decimal amount, decimal price, ExchangeAPI exchange)
        {
            var order = CreateOrder(true, amount, OrderType.Limit, price, symbol);
            var result = PlaceOrder(exchange, order);

            return result.ToString();
        }

        public static string MarketBuy(string symbol, decimal amount, decimal price)
        {
            return MarketBuy(symbol, amount, price, new ExchangeBinanceAPI());
        }

        public static string MarketBuy(string symbol, decimal amount, decimal price, ExchangeAPI exchange)
        {
            var order = CreateOrder(true, amount, OrderType.Market, price, symbol);
            var result = PlaceOrder(exchange, order);

            return result.ToString();
        }

        public static string LimitSell(string symbol, decimal amount, decimal price)
        {
            return MarketSell(symbol, amount, price, new ExchangeBinanceAPI());
        }

        public static string LimitSell(string symbol, decimal amount, decimal price, ExchangeAPI exchange)
        {
            var order = CreateOrder(false, amount, OrderType.Limit, price, symbol);
            var result = PlaceOrder(new ExchangeBinanceAPI(), order);

            return result.ToString();
        }

        public static string MarketSell(string symbol, decimal amount, decimal price)
        {
            return MarketSell(symbol, amount, price, new ExchangeBinanceAPI());
        }

        public static string MarketSell(string symbol, decimal amount, decimal price, ExchangeAPI exchange)
        {
            var order = CreateOrder(false, amount, OrderType.Market, price, symbol);
            var result = PlaceOrder(new ExchangeBinanceAPI(), order);

            return result.ToString();
        }

        private static ExchangeOrderRequest CreateOrder(bool isBuy, decimal amount, OrderType orderType, decimal price, string symbol)
        {
            return new ExchangeOrderRequest()
            {
                IsBuy = false,
                Amount = amount,
                OrderType = orderType,
                Price = price,
                Symbol = symbol
            };
        }

        private static ExchangeOrderResult PlaceOrder(ExchangeAPI exchangeAPI, ExchangeOrderRequest exchangeOrderRequest)
        {
            // TODO: Wrap this in try/catch
            //try
            //{
            return exchangeAPI.PlaceOrder(exchangeOrderRequest);
            //}
            //    catch(Exception)
            //    {}
        }

    }
}