using UnityEngine;

public class TurrelActivator : MonoBehaviour
{
    [SerializeField] private TurrelController _controller;

    [SerializeField] private float _distanceToFire = 10;
    [SerializeField] private Transform _target;


    private void Update()
    {
        if (_target != null)
        {
            float distance = Vector3.Distance(transform.position, _target.position);

            if (distance <= _distanceToFire)
            {
                _controller.ActivateTurret();
            }
            else
            {
                _controller.DeactivateTurret();
            }
        }
    }
}
