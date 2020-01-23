using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModeGroup : MonoBehaviour
{
    public static GameObject obj { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        obj = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
