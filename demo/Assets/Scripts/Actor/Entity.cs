using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    protected virtual bool isActor() { return false; }

    protected virtual bool isActorAuthority() { return false; }
    
}
