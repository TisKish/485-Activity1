using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, ICopy
{
    public ICopy Copy()
    {
        return Instantiate(this);
    }
}
