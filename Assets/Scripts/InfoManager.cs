using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    [SerializeField] private GameObject characterInfoView;
    [SerializeField] private TextMeshProUGUI cName;
    [SerializeField] private TextMeshProUGUI cStrokes;
    [SerializeField] private TextMeshProUGUI cDefinitions;

    public void ShowCharacterInfo(CharacterInfo info)
    {
        cName.text = info.Name;
        cStrokes.text =  $"{info.Strokes}";
        cDefinitions.text = info.Definitions;
        characterInfoView.SetActive(true);
    }

    public void HideCharacterInfo()
    {
        characterInfoView.SetActive(false);
    }
}
