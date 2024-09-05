using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "New Troop", menuName = "ScriptableObjects/New Hero")]
public class Troop : ScriptableObject
{
    [Header("Troop Status")]
    public string troopName;
    public int life;
    public int damage;
    public int velocity;
    public int price;

    [Header("Troop Visuals")]
    public Sprite troopSprite;
    public AnimatorController animController;
}
