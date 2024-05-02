using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class WeaponRaycastHandler : MonoBehaviour
{

    [Header("Ray")]
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _aimPos;//
    [SerializeField] private Transform _rayStartPoint;//
    [SerializeField] private float _aimSmoothSpeed = 20;

    private WeaponConfig _config;

    private void Update()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMask))
        {
            _aimPos.position = Vector3.Lerp(_aimPos.position, hit.point, _aimSmoothSpeed * Time.deltaTime);
        }
    }

    public void PerformRaycast(WeaponConfig config)
    {
        _config = config;

        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMask))
        {
            /*_aimPos.position = Vector3.Lerp(_aimPos.position, hit.point, _aimSmoothSpeed * Time.deltaTime);*/

            var direction = hit.point - _aimPos.position;
            var rayDirection = _config.UseSpread ? direction.normalized + CulculateSpread() : direction.normalized;
            var rayToFire = new Ray(_aimPos.position, rayDirection);

            if (Physics.Raycast(rayToFire, out RaycastHit fireHit, _config.FireDistance, _layerMask))
            {
                _aimPos.position = Vector3.Lerp(_aimPos.position, fireHit.point, _aimSmoothSpeed * Time.deltaTime);

                var hitCollider = fireHit.collider;
                if (hitCollider.TryGetComponent(out IDamageable damageable))
                {
                    damageable.ApplyDamage(_config.Damage);
                }
                else
                {
                    AttackIsNotTargetFound(fireHit);
                }
            }
        }
    }

    private Vector3 CulculateSpread()
    {
        return new Vector3
        {
            x = Random.Range(-_config.SpreadFactor, _config.SpreadFactor),
            y = Random.Range(-_config.SpreadFactor, _config.SpreadFactor),
            z = Random.Range(-_config.SpreadFactor, _config.SpreadFactor),
        };
    }

    private void AttackIsNotTargetFound(RaycastHit hit)
    {
        //var position = hit.transform.position;
       // var rotation = Quaternion.LookRotation(hit.normal);   

        //use sfx
        
    }

#if UNITY_EDITOR

    /*private void OnDrawGizmos()
    {
        //always draws
    }

    private void OnDrawGizmosSelected()
    {
        if (_config == null)
        {
            return;
        }

        var ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out var hitInfo, _config.FireDistance,_layerMask))
        {
            DrawRay(ray, hitInfo.point, hitInfo.distance, Color.red);
        }
        else
        {
            var hitPosition = ray.origin + ray.direction * _config.FireDistance;

            DrawRay(ray, hitInfo.point, hitInfo.distance, Color.green);
        }
    }

    private static void DrawRay(Ray ray, Vector3 point, float distance, Color color)
    {
        const float hitPointRadius = 0.15f;

        Debug.DrawRay(ray.origin, ray.direction * distance, color);

        Gizmos.color = color;
        Gizmos.DrawSphere(point, hitPointRadius);
    }*/

#endif
}
