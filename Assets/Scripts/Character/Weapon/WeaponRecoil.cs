using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [SerializeField] private Transform _recoilFollowPos;
    [SerializeField] private float _kickBackAmount = -1;
    [SerializeField] private float _kickBackSpeed = 10, _returnSpeed = 20;

    private float _currentRecoilPos, _finalRecoilPos;

    private void Update()
    {
        _currentRecoilPos = Mathf.Lerp(_currentRecoilPos, 0, _returnSpeed * Time.deltaTime);
        _finalRecoilPos = Mathf.Lerp(_finalRecoilPos, _currentRecoilPos, _kickBackSpeed * Time.deltaTime);
        _recoilFollowPos.localPosition = new Vector3(0, 0, _finalRecoilPos);
    }


    public void TriggerRecoil()
    {
        _currentRecoilPos += _kickBackAmount;
    }
}
