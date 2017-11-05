﻿using System;
using System.Reflection;

using SingleResponsibilityPrinciple.AdoNet;

namespace SingleResponsibilityPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            var tradeStream = "http://faculty.css.edu/tgibbons/trades4.txt";

            var logger = new ConsoleLogger();
            var tradeValidator = new SimpleTradeValidator(logger);
            var tradeDataProvider = new URLTradeDataProvider(tradeStream);
            var tradeMapper = new SimpleTradeMapper();
            var tradeParser = new SimpleTradeParser(tradeValidator, tradeMapper);
            var tradeStorage = new AdoNetTradeStorage(logger);

            var tradeProcessor = new TradeProcessor(tradeDataProvider, tradeParser, tradeStorage);
            tradeProcessor.ProcessTrades();

            Console.ReadKey();
        }
    }
}
