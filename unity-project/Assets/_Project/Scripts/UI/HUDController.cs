using TMPro;
using UnityEngine;
using UnityEngine.UI;
using SalvageCrew.Core;

namespace SalvageCrew.UI
{
    public class HUDController : MonoBehaviour, IService
    {
        [SerializeField] private Image oxygenBar;
        [SerializeField] private TMP_Text oxygenLabel;
        [SerializeField] private TMP_Text crateProgressLabel;
        [SerializeField] private TMP_Text countdownLabel;
        [SerializeField] private TMP_Text interactPrompt;

        [Header("Channels")]
        [SerializeField] private FloatEventChannel onOxygenChanged;
        [SerializeField] private FloatEventChannel onContractProgress;
        [SerializeField] private FloatEventChannel onDepartureCountdown;

        public void Register() => Services.Register(this);

        private void OnEnable()
        {
            if (onOxygenChanged != null) onOxygenChanged.OnRaised += SetO2;
            if (onContractProgress != null) onContractProgress.OnRaised += SetProgress;
            if (onDepptureCountdownSafe() != null) onDepartureCountdown.OnRaised += SetCountdown;
        }
        private FloatEventChannel onDepptureCountdownSafe() => onDepartureCountdown;

        private void OnDisable()
        {
            if (onOxygenChanged != null) onOxygenChanged.OnRaised -= SetO2;
            if (onContractProgress != null) onContractProgress.OnRaised -= SetProgress;
            if (onDepartureCountdown != null) onDepartureCountdown.OnRaised -= SetCountdown;
        }

        private void SetO2(float pct)
        {
            if (oxygenBar) oxygenBar.fillAmount = pct;
            if (oxygenLabel) oxygenLabel.text = $"O₂ {Mathf.RoundToInt(pct * 100)}%";
        }
        private void SetProgress(float pct)
        {
            if (crateProgressLabel) crateProgressLabel.text = $"Crates {Mathf.RoundToInt(pct * 100)}%";
        }
        private void SetCountdown(float seconds)
        {
            if (!countdownLabel) return;
            int m = (int)(seconds / 60f), s = (int)(seconds % 60f);
            countdownLabel.text = $"T-{m:00}:{s:00}";
        }
        public void SetInteractPrompt(string p)
        {
            if (!interactPrompt) return;
            interactPrompt.gameObject.SetActive(!string.IsNullOrEmpty(p));
            interactPrompt.text = p ?? string.Empty;
        }
    }
}
