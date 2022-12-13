using UnityEngine;

namespace LoppiPoppi.Calculator.Data
{
    public class Storage : IStorage
    {
        private const string UserStateKey = "USER_STATE_KEY";
        
        public void SaveState(string data) => PlayerPrefs.SetString(UserStateKey, data);

        public string LoadState() => PlayerPrefs.GetString(UserStateKey, string.Empty);
    }
}
