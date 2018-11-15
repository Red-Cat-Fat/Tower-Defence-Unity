using UnityEngine;
using UnityEngine.AI;

public class MoveToPoint : MonoBehaviour {
    public float timeFlyToEndPoint = 1f;
    public Vector3 moveEnd;

    private Vector3 _moveStart;
    private Rigidbody _rigidbody;
    private float _lifeTime = 0;
    private bool _moved = false;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if(_rigidbody == null)
        {
            Debug.LogError("Rigidbody is null");
        }
    }

    public void FixedUpdate()
    {
        _lifeTime += Time.fixedDeltaTime;
        if (_moved && _moveStart!=null && moveEnd!=null)
        {
            _rigidbody.transform.position = Vector3.Lerp(_moveStart, moveEnd, _lifeTime /* timeFlyToEndPoint*/);
            if (_lifeTime > timeFlyToEndPoint)
            {
                _moved = false;
            }
        }
    }

    public void MoveTo(Vector3 moveEnd)
    {
        _lifeTime = 0;
        this.moveEnd = moveEnd;
        _moveStart = this.transform.localPosition;
        _moved = true;
    }
}
