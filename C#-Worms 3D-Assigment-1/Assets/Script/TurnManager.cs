using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    private static TurnManager instance;
    //[SerializeField] private PlayerTurn playerOne;
    //[SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private float timeBetweenTurns;
    [SerializeField] private float turnDuration;

    private static int activePlayerIndex;
    private bool waitingForNextTurn;
    private float turnDelay;
    private float currentTurnTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            activePlayerIndex = 1;
           // playerOne.SetPlayerTurn(1);
           // playerTwo.SetPlayerTurn(2);
        }
    }

    private void Update()
    {
        if(waitingForNextTurn)
        {
            turnDelay += Time.deltaTime;
            if (turnDelay >= timeBetweenTurns)
            {
                turnDelay = 0;
                waitingForNextTurn = false;
                ChangeTurn();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            ChangeTurn();
        }
        /* currentTurnTime += Time.deltaTime;
         if (currentTurnTime >= turnDuration)
         {
             ChangeTurn();
             currentTurnTime = 0;
         } */
    }

    public bool IsItPlayerTurn(int index)
    {
        
        return index == activePlayerIndex;
    }

    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void TriggerChangeTurn()
    {
        waitingForNextTurn = true;
    }

    public static void ChangeTurn()
    {
        if (activePlayerIndex == 1)
        {
            activePlayerIndex = 2;
            
            Debug.Log("Has Changed Player" + activePlayerIndex);
        }
        else if (activePlayerIndex == 2)
        {
            activePlayerIndex = 1;
            
            Debug.Log("Has Changed Player" + activePlayerIndex);
        }
            
    }
}
