using System;


public class GameEvents 
{
    public event Action OnEnemyKilledEvent;
    public void EnemyKilled()
    {
        OnEnemyKilledEvent?.Invoke();
    }

    public event Action OnPlayerKilledEvent;
    public void PlayerKilled()
    {
        OnPlayerKilledEvent?.Invoke();
    }

}
