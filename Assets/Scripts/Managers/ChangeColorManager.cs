using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class ChangeColorManager : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private SpriteRenderer _blocksSpriteRenderer;
    [SerializeField] private List<RuntimeAnimatorController> _playerIdleAnimation = new List<RuntimeAnimatorController>();

    private void Update()
    {
        ChangePlayerAnimation();
    }

    private void ChangePlayerAnimation()
    {
        int randAnimation = Random.Range(0, _playerIdleAnimation.Count);
        if(Input.GetKeyDown(KeyCode.Space))
            _playerAnimator.runtimeAnimatorController = _playerIdleAnimation[randAnimation];
    }
}
