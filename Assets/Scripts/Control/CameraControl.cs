using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float speedMoveCamera = 20f;
    public float procentMoveBorderSize = 10f;
    public float speedScrollCamera = 10f;
    public float sensitivity = 1f;
    public LayerMask hitLayers;

    public Vector2 minimumSizeMap = new Vector2(-100, -100);
    public Vector2 maximumSizeMap = new Vector2(100, 100);
    public int minY = 10;
    public int maxY = 60;

    private float _moveBorderSize = 10f;
    // private bool inRotate = false;
    private void Start()
    {
        _moveBorderSize = procentMoveBorderSize / 100 * Screen.height;
    }

    void Update()
    {
        Vector3 vector3 = transform.position;
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - _moveBorderSize)
        {
            vector3.z += speedMoveCamera * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= _moveBorderSize)
        {
            vector3.z -= speedMoveCamera * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - _moveBorderSize)
        {
            vector3.x += speedMoveCamera * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= _moveBorderSize)
        {
            vector3.x -= speedMoveCamera * Time.deltaTime;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        vector3.y -= scroll * speedScrollCamera;

        vector3.x = Mathf.Clamp(vector3.x, minimumSizeMap.x, maximumSizeMap.x);
        vector3.y = Mathf.Clamp(vector3.y, minY, maxY);
        vector3.z = Mathf.Clamp(vector3.z, minimumSizeMap.y, maximumSizeMap.y);

        transform.position = vector3;
    }
}