using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] public float number;
    [SerializeField] private GameObject _bulletPrefab;
    public Transform ObjectToShoot;
    [SerializeField] float _timeWaitShooting;

    void Start() {
           StartCoroutine(_shootingWorker());
    }
    IEnumerator _shootingWorker()
    {
        bool isWork = enabled;
        while (isWork){
            var _vector3direction = (ObjectToShoot.position - transform.position).normalized;
            var NewBullet = Instantiate(_bulletPrefab, transform.position + _vector3direction, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().transform.up = _vector3direction;
            NewBullet.GetComponent<Rigidbody>().velocity = _vector3direction * number;

            yield return new WaitForSeconds(_timeWaitShooting);
         }
    }
    public void Update(){

    }
}