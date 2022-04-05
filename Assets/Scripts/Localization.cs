using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localization : MonoBehaviour
{
    public static Localization instance;
    public SystemLanguage language;
    Dictionary<(LocalizationKey, SystemLanguage), string> dict = new Dictionary<(LocalizationKey, SystemLanguage), string>()
    {
        {(LocalizationKey.NEXT, SystemLanguage.English), "Next"},
        {(LocalizationKey.NEXT, SystemLanguage.Portuguese), "Próximo"},
        {(LocalizationKey.RETRY, SystemLanguage.English), "Retry"},
        {(LocalizationKey.RETRY, SystemLanguage.Portuguese), "Reiniciar"},
        {(LocalizationKey.THROW, SystemLanguage.English), "Throw"},
        {(LocalizationKey.THROW, SystemLanguage.Portuguese), "Lançar"},
       // {(LocalizationKey.ATTEMPTS, SystemLanguage.English), "Attempts:"},
       // {(LocalizationKey.ATTEMPTS, SystemLanguage.Portuguese), "Tentativas:"},
        {(LocalizationKey.STAR1, SystemLanguage.English), "Thal'll Work!"},
        {(LocalizationKey.STAR1, SystemLanguage.Portuguese), "Boa Pontaria!"},
        {(LocalizationKey.STAR2, SystemLanguage.English), "Woods hit: "},
        {(LocalizationKey.STAR2, SystemLanguage.Portuguese), "Tábuas acertadas: "},
        {(LocalizationKey.STAR3, SystemLanguage.English), "Attempts: "},
        {(LocalizationKey.STAR3, SystemLanguage.Portuguese), "Tentativas: "},
        {(LocalizationKey.TTP, SystemLanguage.English), "Tap to Play"},
        {(LocalizationKey.TTP, SystemLanguage.Portuguese), "Toque para Jogar"},







    };


    void Awake()
    {
        instance = this;
        language = Application.systemLanguage;
    }


    public string GetLocalizedString(LocalizationKey key) => dict[(key,language)];
    
}
public enum LocalizationKey
{
    NEXT, RETRY, THROW, ATTEMPTS, STAR2, STAR3, STAR1, TTP
}
