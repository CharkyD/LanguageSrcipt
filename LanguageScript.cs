using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageScript : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    private int languageValue;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("LocaleKeY"))
        {
            languageValue = PlayerPrefs.GetInt("LocaleKey", 0);
        }
        else
        {
            languageValue = 0;
            PlayerPrefs.SetInt("LocaleKey", languageValue);
        }

        dropdown.value = languageValue;
        UpdateDropdownOptions();
        ChangeLanguage();
    }

    public void ChangeLanguage()
    {
        languageValue = dropdown.value;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageValue];
        PlayerPrefs.SetInt("LocaleKey", languageValue);
        UpdateDropdownOptions();
    }

    private void UpdateDropdownOptions()
    {
        for(int i = 0; i< dropdown.options.Count; i++)
        {
            string localizedOption = LocalizationSettings.StringDatabase.GetLocalizedString($"D00{5 + i}");
            dropdown.options[i].text = localizedOption;
        }
        dropdown.RefreshShownValue();
    }
}
