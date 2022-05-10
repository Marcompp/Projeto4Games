using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhino : MonoBehaviour
{
    float _baseSpeed = 10.0f;
    float _gravidade = 1f;
    private bool running = false;
    private Animator animator;
    CharacterController characterController;

    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        Invoke("StartRun",1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (running) {
            characterController.Move(transform.forward * _baseSpeed * Time.deltaTime);
        }
        else {
            if (!true){
                running = true;
                animator.SetBool("isRunning", true);
            }
        }
    }

    private void StartRun() {
        running = true;
                animator.SetBool("isRunning", true);
    }

    private void OnTriggerEnter(Collider col) {
        //start sound;
        if (col.gameObject.CompareTag("Player")) {
            gm.ChangeState(GameManager.GameState.GAMEOVER);
        }
    }


    
}
