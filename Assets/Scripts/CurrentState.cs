using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurrentState
{
    public static StateEnum currentState = StateEnum.PuzzleInProgress;

    private static StateEnum returnPoint;

    public static void NextState()
    {
        currentState = currentState + 1;
    }

    //For menus etc to be able to easily set a state to return to
    public static void SetStateStart(StateEnum state)
    {
        returnPoint = currentState;
        currentState = state;
    }
    //when menus are closed, return to state before menu was opened
    public static void SetStateEnd()
    {
        currentState = returnPoint;
    }
    //sets a custom state.
    public static void SetCustomState(StateEnum state)
    {
        currentState = state;
    }
}
