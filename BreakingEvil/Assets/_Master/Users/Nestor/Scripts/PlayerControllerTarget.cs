using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTarget : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private GameObject spriteCanvas;
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private GameObject defeatPanel;


    private void OnTriggerEnter(Collider other)
    {
        health--;

        int gameObjectIndex = health / 2; // Calcula el índice del GameObject en base a la salud actual
        if (gameObjectIndex < gameObjects.Length)
        {
            GameObject targetObject = gameObjects[gameObjectIndex];
            targetObject.SetActive(true);
        }
        if(health == 0) { defeatPanel.SetActive(true); }
    }
}