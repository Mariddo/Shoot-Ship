using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBehavior : MonoBehaviour
{
    
    public bool destroyMe;
    // Start is called before the first frame update
    void Start()
    {
        destroyMe = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(destroyMe) {

            Destroy(gameObject);
        }
    }
}
