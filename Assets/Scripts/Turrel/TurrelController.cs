using System.Collections;
using UnityEngine;

public class TurrelController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Health _target;
    [SerializeField] private WeaponEffects _weaponEffects;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Health _health;

    [SerializeField] private GameObject _head;

    [Header("Aim")]
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _fireRate;
    [SerializeField] private int _damage;
    private bool _isActive = false;
    private bool _isShoting = false;


    [Header("Aim")]
    [SerializeField] private SoundType _soundType;
    [SerializeField] private string _shotSoundName;

    private void OnEnable()
    {
        _health.OnDieEvent += Destroy;
    }

    private void Update()
    {
        if (_target != null && _isActive == true) 
        {
            Aim();
            Shoting();
        }
    }

    public void ActivateTurret()
    {
        _isActive = true;
    }

    public void DeactivateTurret()
    {
        _isActive = false;
    }
 
    private void Aim()
    {
        Vector3 targetDirection = _target.transform.position - _head.transform.position;
        targetDirection.y = 0; 

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        _head.transform.rotation = Quaternion.RotateTowards(_head.transform.rotation, targetRotation, _rotateSpeed * Time.deltaTime);
    }

    private void Shoting()
    {
        if (_isShoting == true) 
        {
            return;     
        }

        _isShoting = true;
        _target.ApplyDamage(_damage);
        _weaponEffects.PlaySound(_soundType, _shotSoundName);
        _weaponEffects.PlayVFX();
        StartCoroutine(ShotCoroutine());
    }

    private void Destroy()
    {
        _health.OnDieEvent -= Destroy;
        GameEventController.Instance.GameEvents.EnemyKilled();
        _weaponEffects.PlaySound(_soundType, "Destroy");
        gameObject.SetActive(false);
    }

    private IEnumerator ShotCoroutine()
    {
        yield return new WaitForSeconds(_fireRate);
        _isShoting = false;

    }

}
