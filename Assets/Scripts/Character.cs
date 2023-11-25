using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterInfo characterInfo;
    
    public CharacterInfo CharacterInfo => characterInfo;

}
