using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _target;

    private Vector3 pivot = new Vector3(0, 2, -5);
    private float speed = 5f;

    void Start()
    {
        _camera.transform.position = _target.transform.position + pivot;
    }

    void FixedUpdate()
    {
        Moveto(_camera, _target, pivot, speed);
    }

    private void Moveto(GameObject cam, GameObject target, Vector3 pivot,float speed)
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, target.transform.position + pivot, speed * Time.fixedDeltaTime);
    }
}
