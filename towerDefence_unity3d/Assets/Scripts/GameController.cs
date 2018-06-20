using UnityEngine;

public static class GameController
{
    public static System.Action StartGameEvent;
    public static System.Action StopGameEvent;

    public static void StartGame()
    {
        StartGameEvent?.Invoke();
    }

    public static void Victory()
    {
        StopGameEvent?.Invoke();
    }
}
