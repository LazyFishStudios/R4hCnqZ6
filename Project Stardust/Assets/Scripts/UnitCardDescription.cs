using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="UnitCard",menuName ="Cards/UnitCard",order =1)]
public class UnitCardDescription : ScriptableObject 
{
  public int Cost;
  public int Defence;
  public int Attack;
  public int Fuel;
  public string Description;
  public GameObject ModelPrefab;
  public Sprite Thumbnail;
}