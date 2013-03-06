namespace FgsfdsGame.Model
{
    public class GameDataSource
    {
        public GameScreen GetScreen()
        {
            return GameManager.Instance.Screen;
        }

        public PlayerStats GetStats()
        {
            return GameManager.Instance.Stats;
        }
    }
}