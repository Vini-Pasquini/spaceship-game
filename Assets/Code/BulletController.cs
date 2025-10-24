using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float _bulletSpeed = 5f;

    private void Start()
    {
        GameObject.Destroy(this.gameObject, 5f);
    }

    private void Update()
    {
        this.transform.position += Vector3.up * Time.deltaTime * this._bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject.Destroy(other.gameObject);
            GameObject.Destroy(this.gameObject);
            GameManager.Instance.AddScore();
        }
    }
}
