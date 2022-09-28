using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
  public int playerIndex;

  public void SetPlayerTurn(int index)
  {
    playerIndex = index;
  }

  public bool IsPlayerTurn()
  {
    return TurnManager.GetInstance().IsItPlayerTurn(playerIndex);
  }
}
