using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInformation", menuName = "ScriptableObjects/PlayerInformation", order = 1)]
public class PlayerInformation : ScriptableObject
{
    public long score = 0L;

    public int lives = 3;
}
