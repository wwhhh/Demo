using UnityEngine;

namespace Game
{
    public class PhysicsController : MonoBehaviour
    {
        private Actor _actor;
        private CharacterController _character;
        public bool isMoving;
        public bool isJumping;
        public bool isLanding;

        private void Awake()
        {
            _character = gameObject.AddComponent<CharacterController>();
            _character.height = 2;
            _character.radius = 0.5f;
            _character.center = new Vector3(0, 1, 0);

            _actor = GetComponent<Actor>();

            isMoving = false;
            isJumping = false;
        }

        public bool IsGround()
        {
            return _character.isGrounded;
        }

        public Vector3 GetCenter()
        {
            return transform.position + _character.center;
        }

        private void Update()
        {
            MoveDelta();
        }

        private const float velocity = 4f;
        private const float gravity = -9.8f;

        private Vector3 _dir;
        private float vy;
        private void MoveDelta()
        {
            if (_character == null) return;

            float dt = Time.deltaTime;
            Vector3 delta = _dir * dt * velocity;
            // y方向单独计算重力
            if (isJumping)
            {
                vy += gravity * dt;
                delta.y += vy * dt;
            }

            // xz方向计算运动
            CollisionFlags flag = _character.Move(delta);
            if (flag != CollisionFlags.None)
            {
                isLanding = true;
                _character.SimpleMove(velocity * _dir);
            }

            if (IsGround())
            {
                isJumping = false;
                isLanding = true;
            }
        }

        public void Move(Vector3 force)
        {
            isMoving = true;
            _dir = force;
        }

        public void Jump()
        {
            isMoving = true;
            isJumping = true;
            isLanding = false;
            vy += velocity;
        }

        public void Stop()
        {
            isMoving = false;
            isLanding = false;
            _dir = Vector3.zero;
            vy = 0f;
        }

    }
}
