using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    private static TurnManager instance;
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private float timeBetweenTurns;

    private int activePlayerIndex;
    private bool waitingForNextTurn;
    private float turnDelay;

    private void Update()
    {
        if (waitingForNextTurn)
        {
            turnDelay += Time.deltaTime;
            if (turnDelay >= timeBetweenTurns)
            {
                turnDelay = 0;
                waitingForNextTurn = false;
                ChangeTurn();
            }
        }
    }

    public bool IsItPlayerTurn(int index)
    {
        if (waitingForNextTurn)
        {
            return false;
        }

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

    private void ChangeTurn()
    {
        if (activePlayerIndex == 1)
        {
            activePlayerIndex = 2;
            
            
        }

        else
        {
            activePlayerIndex = 1;
        }
    }
}
