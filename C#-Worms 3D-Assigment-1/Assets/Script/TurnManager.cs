using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    private static TurnManager instance;
    [SerializeField] public PlayerTurn playerOne;
    [SerializeField] public PlayerTurn playerTwo;
    [SerializeField] private float timeBetweenTurns;
    [SerializeField] private float turnDuration;

    [SerializeField] private Camera main1;
    [SerializeField] private Camera main2;
   
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

        
        currentTurnTime += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.L) || currentTurnTime >= turnDuration)
        {
            
                
                turnDelay += Time.deltaTime;
            if (turnDelay >= timeBetweenTurns)
            {
                
                ChangeTurn();
                currentTurnTime = 0;
                turnDelay = 0;
                
                if (activePlayerIndex == 1)
                {
                    main1.depth = 1;
                    main2.depth = 0;
                }
            
                else if (activePlayerIndex == 2)
                {
                    main1.depth = 0;
                    main2.depth = 1;
                }

            }
             
            
        } 
        
        
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
