namespace LoppiPoppi.Calculator.Data
{
    public interface IStorage
    {
        void SaveState(string data);
        string LoadState();
    }
}
