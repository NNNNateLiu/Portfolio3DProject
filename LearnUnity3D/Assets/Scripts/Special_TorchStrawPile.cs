using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_TorchStrawPile : MonoBehaviour
{
    public ParticleSystem fire1;
    public ParticleSystem fire2;
    public ParticleSystem fire3;

    public NPCBehavior npc1;
    public NPCBehavior npc2;
    
    public void additionalTriggerEvent()
    {
        fire1.Play();
        fire2.Play();
        fire3.Play();
        
        npc1.MovetoTarget();
        npc2.MovetoTarget();
    }
}
