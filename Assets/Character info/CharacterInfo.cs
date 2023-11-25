using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character info")]

public class CharacterInfo : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private float strokes;
    [SerializeField] private new string definitions;
    
    public string Name => name;

    public float Strokes => strokes;

    public string Definitions => definitions;
    
}
