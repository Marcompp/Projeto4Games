using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarcoDragon : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        //start sound;
        Renderer render = GetComponent<Renderer>();
        render.material.color = Color.green;
        }
}
