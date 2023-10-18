namespace Infrastructure.Level
{
    public interface ILevelAction
    {
        void LevelStart();
        void PauseGame();
        void PlayGame();
    }
}