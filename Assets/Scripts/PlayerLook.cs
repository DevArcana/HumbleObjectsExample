using UnityEngine;

public class PlayerLook : MonoBehaviour
{
  private Camera _camera;

  private void Start()
  {
    _camera = Camera.main;
  }

  private void Update()
  {
    var dir = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
  }
}
