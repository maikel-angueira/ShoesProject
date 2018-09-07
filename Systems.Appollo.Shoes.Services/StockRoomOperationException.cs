using System;

namespace Systems.Appollo.Shoes.Services
{
    public class StockRoomOperationException: Exception
    {
        public StockRoomOperationException(string message) : base(message)
        {
        }
    }
}