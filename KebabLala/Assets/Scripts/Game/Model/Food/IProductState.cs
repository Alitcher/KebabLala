public interface IProductState
{
    void UpdateLevel(int whichShelf, int currentLevel);

    string GetUpgradePrice(int whichShelf);

    string GetCurrentPrice(int whichShelf);

    string GetNextPrice(int whichShelf);

    string LevelLog(int whichShelf);
}