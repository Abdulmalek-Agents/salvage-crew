using UnityEngine;

namespace SalvageCrew.Player
{
    /// <summary>
    /// Local-only crew controller (movement + look + light). Networking layer
    /// is added by CrewNetworkBehaviour (Mirror) which talks to this via public methods.
    /// Keeping the local controller decoupled means we can run a fake "solo" lobby
    /// with no networking instantiated at all.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class CrewMember : MonoBehaviour
    {
        [Header("Refs")]
        [SerializeField] private InputReader input;
        [SerializeField] private Transform cameraPivot;
        [SerializeField] private Light helmetLight;

        [Header("Movement")]
        [SerializeField] private float walkSpeed = 3.2f;
        [SerializeField] private float sprintSpeed = 5.4f;
        [SerializeField] private float crouchSpeed = 1.6f;
        [SerializeField] private float gravity = -19.62f;
        [SerializeField] private float lookSensitivity = 0.12f;

        public float MoveSpeedMultiplier { get; set; } = 1f;
        public bool MagBootsEnabled { get; set; }

        private CharacterController _cc;
        private Vector3 _velocity;
        private float _pitch;
        public bool IsLocalAuthority { get; set; } = true;

        private void Awake() => _cc = GetComponent<CharacterController>();

        private void OnEnable()
        {
            if (input != null) input.OnHelmetLightToggled += ToggleLight;
        }
        private void OnDisable()
        {
            if (input != null) input.OnHelmetLightToggled -= ToggleLight;
        }

        private void Update()
        {
            if (!IsLocalAuthority || input == null) return;
            HandleLook();
            HandleMove();
        }

        private void HandleLook()
        {
            var l = input.LookInput;
            transform.Rotate(0f, l.x * lookSensitivity, 0f);
            _pitch = Mathf.Clamp(_pitch - l.y * lookSensitivity, -80f, 80f);
            if (cameraPivot != null) cameraPivot.localEulerAngles = new Vector3(_pitch, 0f, 0f);
        }

        private void HandleMove()
        {
            float speed = walkSpeed;
            if (input.CrouchHeld) speed = crouchSpeed;
            else if (input.SprintHeld) speed = sprintSpeed;
            speed *= MoveSpeedMultiplier;

            var i = input.MoveInput;
            var dir = transform.right * i.x + transform.forward * i.y;
            _cc.Move(dir * speed * Time.deltaTime);

            if (_cc.isGrounded && _velocity.y < 0f) _velocity.y = MagBootsEnabled ? -8f : -2f;
            _velocity.y += gravity * Time.deltaTime;
            _cc.Move(_velocity * Time.deltaTime);
        }

        private void ToggleLight()
        {
            if (helmetLight != null) helmetLight.enabled = !helmetLight.enabled;
        }

        public void ApplyKnockForce(Vector3 worldForce)
        {
            _velocity += worldForce * Time.deltaTime;
        }
    }
}
