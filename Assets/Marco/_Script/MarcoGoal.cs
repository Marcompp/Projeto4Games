using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarcoGoal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dragon;

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
        Destroy(dragon);
        }
}
