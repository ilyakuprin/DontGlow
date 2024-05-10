namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public float BestTimeInSec;
        public float ValueSliderEffects = 1f;
        public float ValueSliderMusic = 1f;
    }
}
