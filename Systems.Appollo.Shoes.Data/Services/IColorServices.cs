namespace Systems.Appollo.Shoes.Data.Services
{
    interface IColorServices
    {
        void InsertColor(string color);
        void UpdateColor(int colorId, string newColor);
        void DeleteColor(string colorId);
    }
}