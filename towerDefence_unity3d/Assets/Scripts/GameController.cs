using System;

public static class GameController
{
    public static Action StartGameEvent;
    public static Action StopGameEvent;
    public static Action VictoryEvent;
    public static Action LoseEvent;

    public static void StartGame()
    {
        StartGameEvent?.Invoke();
    }

    public static void Victory()
    {        
        VictoryEvent?.Invoke();
        StopGameEvent?.Invoke();
    }

    public static void Lose()
    {        
        LoseEvent?.Invoke();
        StopGameEvent?.Invoke();
    }
}
