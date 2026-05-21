using UnityEngine;
using SalvageCrew.Core;
using SalvageCrew.Data;

namespace SalvageCrew.Contracts
{
    /// <summary>
    /// Host-only contract driver. Counts crates delivered, manages departure timers,
    /// raises win / fail events.
    /// </summary>
    public class ContractManager : MonoBehaviour, IService
    {
        [SerializeField] private ContractData activeContract;
        [SerializeField] private VoidEventChannel onCrateDelivered;
        [SerializeField] private VoidEventChannel onContractComplete;
        [SerializeField] private VoidEventChannel onContractFailed;
        [SerializeField] private FloatEventChannel onContractProgress;
        [SerializeField] private FloatEventChannel onDepartureCountdown;

        public ContractData Contract => activeContract;
        public int CratesDelivered { get; private set; }
        public float TimeRemaining { get; private set; }

        public void Register() => Services.Register(this);

        private void OnEnable()
        {
            if (onCrateDelivered != null) onCrateDelivered.OnRaised += CrateDelivered;
        }
        private void OnDisable()
        {
            if (onCrateDelivered != null) onCrateDelivered.OnRaised -= CrateDelivered;
        }

        public void StartContract(ContractData c)
        {
            activeContract = c;
            CratesDelivered = 0;
            TimeRemaining = c != null ? c.departureWindowSec : 0f;
            Debug.Log($"[ContractManager] Started {c?.contractId}");
        }

        private void Update()
        {
            if (activeContract == null) return;
            TimeRemaining = Mathf.Max(0f, TimeRemaining - Time.deltaTime);
            onDepartureCountdown?.Raise(TimeRemaining);
            if (TimeRemaining <= 0f) FailContract("Departure window expired.");
        }

        private void CrateDelivered()
        {
            if (activeContract == null) return;
            CratesDelivered++;
            float p = (float)CratesDelivered / Mathf.Max(1, activeContract.requiredCrates);
            onContractProgress?.Raise(p);
            Debug.Log($"[ContractManager] Crates {CratesDelivered}/{activeContract.requiredCrates}");
            if (CratesDelivered >= activeContract.requiredCrates) CompleteContract();
        }

        public void CompleteContract()
        {
            onContractComplete?.Raise();
            int payout = Mathf.RoundToInt(activeContract.payoutScrip * (activeContract.difficulty != null ? activeContract.difficulty.scripMultiplier : 1f));
            Services.Get<Save.SaveSystem>()?.AddScrip(payout);
            Debug.Log($"[ContractManager] Complete! Payout {payout} scrip.");
        }

        public void FailContract(string reason)
        {
            onContractFailed?.Raise();
            Debug.Log($"[ContractManager] Failed: {reason}");
        }
    }
}
