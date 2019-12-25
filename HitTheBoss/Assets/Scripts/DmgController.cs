using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgController : MonoBehaviour
{

    public virtual void DMG(float dmg, float HP)
    {
        HP -= dmg;
    }

}
