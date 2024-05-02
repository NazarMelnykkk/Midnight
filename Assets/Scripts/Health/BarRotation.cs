using System.Collections;
using UnityEngine;

public class BarRotation : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _objectToRotate;

    private Coroutine _rotateToCameraCoroutine;

    public void Awake()
    {
        if (_camera == null)
        {
            _camera = Camera.main;
        }
    }

    private void OnEnable()
    {
        if (_objectToRotate != null && _rotateToCameraCoroutine == null)
        {
            _rotateToCameraCoroutine = StartCoroutine(RotateToCamera());
        }
    }

    private void OnDisable()
    {
        if (_rotateToCameraCoroutine != null)
        {
            StopCoroutine(_rotateToCameraCoroutine); 
            _rotateToCameraCoroutine = null;
        }
    }

    private IEnumerator RotateToCamera()
    {
        while (true)
        {
            transform.rotation = Quaternion.LookRotation(_objectToRotate.transform.position - _camera.transform.position);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
