using System;
using YG;

namespace _DontGlow.Scripts.Localization
{
    public class LocalizationTextRecord : LocalizationText
    {
        private const string Format = "{0}: {1}";
        
        public override void Change()
        {
            var text = YandexGame.savesData.language switch
            {
                "ru" => TextLocalization.Ru,
                "tr" => TextLocalization.Tr,
                _ => TextLocalization.Eu
            };
            
            var ts = TimeSpan.FromSeconds(YandexGame.savesData.BestTimeInSec);
            var time = $"{ts.Minutes:00}:{ts.Seconds:00}";
            
            Set(string.Format(Format, text, time));
        }
    }
}