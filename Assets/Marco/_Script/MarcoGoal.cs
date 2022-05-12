using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarcoGoal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dragon;
    public GameObject sword;
    
    GameManager gm;
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) {
        //start sound;
        Renderer render = GetComponent<Renderer>();
        //#render.material.color = Color.green;
        //Destroy(dragon);
        dragon.SetActive(false);
        sword.SetActive(false);
        }
}
