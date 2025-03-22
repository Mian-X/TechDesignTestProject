using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelection : MonoBehaviour
{
    private bool active = false;

    void Start()
    {
        int Id = PlayerPrefs.GetInt("LocaleKeyId", 0);
        ChangeLocale(Id);
    }

    public void ChangeLocale(int localeId)
    {
        if (active) return;
        StartCoroutine(SetLocale(localeId));
    }

    private IEnumerator SetLocale(int localeId)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeId];
        PlayerPrefs.SetInt("LocaleKeyId", localeId);
        active = false;
    }
}