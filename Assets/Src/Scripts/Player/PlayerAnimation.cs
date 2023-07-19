using UnityEngine;

    public class PlayerAnimation 
    {
        private readonly Animator animator;
        private readonly Transform transform;

        public PlayerAnimation(Animator _animator, Transform _transform)
        {
            animator = _animator;
            transform = _transform;
        }

        public void WalkingAnimation(Vector2 MovementDirection)
        {
            animator.SetFloat("MovementX", MovementDirection.x);
            animator.SetFloat("MovementY", MovementDirection.y);
        }

        public void LastDirection(float last_HorizontalDirection, float last_VerticalDirection)
        {
            animator.SetFloat("LastHorizontalDirection", last_HorizontalDirection);
            animator.SetFloat("LastVerticalDirection", last_VerticalDirection);
        }
    }
