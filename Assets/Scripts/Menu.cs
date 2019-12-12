using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject canvas;
    private MovementInput player;
    private bool isPaused = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementInput>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canvas.SetActive(!canvas.activeSelf);
            Cursor.visible = canvas.activeSelf;
            Cursor.lockState = canvas.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
            isPaused = canvas.activeSelf;
        }
        if (isPaused) Time.timeScale = 0; 
        else
        Time.timeScale = 1;
    }
}

