using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const string _HORIZONTAL_INPUT_AXIS_ = "Horizontal";

    [SerializeField] private GameObject _bulletPrefab;

    private float _movementSpeed = 7f;
    private float _shootDelay = 1f;
    private float _shootTimer = 0f;

    private void Update()
    {
        float movementInput = Input.GetAxis(_HORIZONTAL_INPUT_AXIS_); // TODO: change to input system

        this._shootTimer = Mathf.Clamp(this._shootTimer - Time.deltaTime, 0, this._shootDelay);
        if (this._shootTimer <= 0f && Input.GetKey(KeyCode.Space))
        {
            GameObject newBullet = GameObject.Instantiate(this._bulletPrefab, this.transform.position + (Vector3.up * .5f), Quaternion.identity); // TODO: change to object pooling
            this._shootTimer = this._shootDelay;
        }

        Vector3 positionBuffer = this.transform.position;
        positionBuffer.x = Mathf.Clamp(positionBuffer.x + movementInput * Time.deltaTime * this._movementSpeed, -8f, 8f);
        this.transform.position = positionBuffer;
    }
}
