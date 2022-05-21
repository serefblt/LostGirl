using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    MoveController _moveController;
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _hSpeed , _jSpeed;
    [SerializeField] bool _isHorizontalActive , _isFlipActive , _isJumpActive;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _playerSpriteRenderer;
    [SerializeField] Rigidbody2D _rb2D;

    public bool IsJumpAction => _rb2D.velocity != Vector2.zero;
    private void Awake()
    {
        _moveController = new MoveController();
    }
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Walk();
        Jump();
        Flip();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _isJumpActive = true;
        }
    }

    void Walk()
    {
        _moveController.Horizontal(_playerTransform, _hSpeed, _isHorizontalActive);
        _animator.SetFloat("__isWalk", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    void Flip()
    {
        _moveController.Flip(_playerSpriteRenderer, _isFlipActive);
    }

    void Jump()
    {
        if (_isJumpActive && !IsJumpAction)
        {
            _moveController.Jump(_rb2D, _jSpeed, _isJumpActive);
        }
        _isJumpActive = false;
     
    }
}
