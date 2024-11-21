using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Language
{
    public string lang;
    public string title;
    public string play;
    public string options;
    public string quit;
    public string credits;
}

public class LanguageData
{
    public Language[] languages;
}

public class Reader : MonoBehaviour
{
    public TextAsset jsonFile;
    public string currentLanguage;
    public LanguageData languageData;
    
    public Text titleText;
    public Text playText;
    public Text optionsText;
    public Text quitText;
    public Text creditsText;

    private void Start()
    {
        languageData = JsonUtility.FromJson<LanguageData>(jsonFile.text);
        SetLanguage(currentLanguage);
    }
    
    public void SetLanguage(string newlanguage)
    {
        currentLanguage = newlanguage;
        foreach (Language language in languageData.languages)
        {
            if (language.lang.ToLower() == newlanguage.ToLower())
            {
                titleText.text = language.title;
                playText.text = language.play;
                optionsText.text = language.options;
                quitText.text = language.quit;
                creditsText.text = language.credits;
                return;
            }
        }
    }
    
    public void ToggleLanguage()
    {
        if (currentLanguage.ToLower() == "en")
        {
            SetLanguage("fr");
        }
        else if (currentLanguage.ToLower() == "fr")
        {
            SetLanguage("en");
        }
    }
}
