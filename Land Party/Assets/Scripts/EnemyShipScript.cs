using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipScript : MonoBehaviour
{
    [SerializeField] private int health = 15;
    // Start is called before the first frame update
    

    public void OnDamage()
    {
        health--;
    }
}
