using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _playerRB2D;

    [SerializeField] private float _groundCheckDistance;
    [SerializeField] private LayerMask _groundMask;

    [SerializeField] private SpriteRenderer _playerSpriteRenderer;
    [SerializeField] private SpriteRenderer _shadowSpriteRenderer;

    private bool _isGrounded;


    private void Update()
    {
        Move();
        Jump();
    }
    private void Move()
    {
        float _moveDirection = Input.GetAxis("Horizontal");
        if(!_isGrounded)
            _playerRB2D.velocity = new Vector2(_moveDirection *_moveSpeed, _playerRB2D.velocity.y);
        Sprits(_moveDirection);
    }

    private void Jump()
    {
        _isGrounded = Physics2D.Raycast(_playerRB2D.position, Vector2.down, _groundCheckDistance, _groundMask);
        Debug.DrawLine(_playerRB2D.position, _playerRB2D.position + Vector2.down * _groundCheckDistance, Color.green);
        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            _playerRB2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void Sprits(float direction)
    {
        if (_isGrounded)
            _shadowSpriteRenderer.enabled = true;
        else
            _shadowSpriteRenderer.enabled = false;

        if (direction > 0)
            _playerSpriteRenderer.flipX = true;
        else if (direction < 0)
            _playerSpriteRenderer.flipX = false;
    }
}
