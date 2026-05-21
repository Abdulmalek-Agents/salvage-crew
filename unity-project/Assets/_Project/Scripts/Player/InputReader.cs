using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SalvageCrew.Player
{
    public class InputReader : MonoBehaviour
    {
        public Vector2 MoveInput { get; private set; }
        public Vector2 LookInput { get; private set; }
        public bool SprintHeld { get; private set; }
        public bool CrouchHeld { get; private set; }
        public bool PushToTalkHeld { get; private set; }

        public event Action OnInteractPressed;
        public event Action OnPickDropPressed;
        public event Action OnHelmetLightToggled;
        public event Action OnPingPressed;
        public event Action OnPausePressed;

        [SerializeField] private InputActionAsset actions;
        private InputAction _move, _look, _sprint, _crouch, _ptt, _interact, _pickdrop, _light, _ping, _pause;

        private void Awake()
        {
            if (actions == null) { Debug.LogError("[InputReader] No InputActionAsset assigned."); return; }
            var map = actions.FindActionMap("Player", true);
            _move = map.FindAction("Move");
            _look = map.FindAction("Look");
            _sprint = map.FindAction("Sprint");
            _crouch = map.FindAction("Crouch");
            _ptt = map.FindAction("PushToTalk");
            _interact = map.FindAction("Interact");
            _pickdrop = map.FindAction("PickDrop");
            _light = map.FindAction("HelmetLight");
            _ping = map.FindAction("Ping");
            _pause = map.FindAction("Pause");
        }

        private void OnEnable()
        {
            actions.Enable();
            _interact.performed += On_Interact;
            _pickdrop.performed += On_PickDrop;
            _light.performed += On_Light;
            _ping.performed += On_Ping;
            _pause.performed += On_Pause;
        }
        private void OnDisable()
        {
            _interact.performed -= On_Interact;
            _pickdrop.performed -= On_PickDrop;
            _light.performed -= On_Light;
            _ping.performed -= On_Ping;
            _pause.performed -= On_Pause;
            actions.Disable();
        }

        private void Update()
        {
            MoveInput = _move.ReadValue<Vector2>();
            LookInput = _look.ReadValue<Vector2>();
            SprintHeld = _sprint.IsPressed();
            CrouchHeld = _crouch.IsPressed();
            PushToTalkHeld = _ptt.IsPressed();
        }

        private void On_Interact(InputAction.CallbackContext _) => OnInteractPressed?.Invoke();
        private void On_PickDrop(InputAction.CallbackContext _) => OnPickDropPressed?.Invoke();
        private void On_Light(InputAction.CallbackContext _) => OnHelmetLightToggled?.Invoke();
        private void On_Ping(InputAction.CallbackContext _) => OnPingPressed?.Invoke();
        private void On_Pause(InputAction.CallbackContext _) => OnPausePressed?.Invoke();
    }
}
