using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] private Health health;

    private void OnEnable()
    {
        health.OnDieEvent += Destroy;
    }

    private void Destroy()
    {
        health.OnDieEvent -= Destroy;
        gameObject.SetActive(false);
        GameEventController.Instance.GameEvents.PlayerKilled();
    }
}
