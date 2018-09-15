using System;

namespace Systems.Appollo.Shoes.Services.Data
{
    public class StockRoomOperationException: Exception
    {
        public StockRoomOperationException(string message) : base(message)
        {
        }
    }
}