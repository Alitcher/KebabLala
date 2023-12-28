public interface IProductState
{
    void SetSellPrice(MixtureNode mixtureNode);
    void UpdateNewPrice(MixtureNode mixtureNode);

    void UpdateLevel(int whichShelf, int currentLevel);

    string GetUpgradePrice(int whichShelf);
}