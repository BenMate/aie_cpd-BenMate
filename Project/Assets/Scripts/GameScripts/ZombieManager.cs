using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieManager : MonoBehaviour
{
    public static ZombieManager instance;

    public List<Transform> zombiePositions = new List<Transform>();


    
    void Awake()
    {
        //for aimbot
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    
    void Update()
    {
        
    }
}
