namespace Systems.Appollo.Shoes.Data.Services
{
    public interface IColorServices
    {
        void InsertColor(string color);
        void UpdateColor(int colorId, string newColor);
        void DeleteColor(int colorId);
    }
}