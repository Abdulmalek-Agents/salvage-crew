using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace SalvageCrew.UI
{
    /// <summary>
    /// Main menu / lobby UI. Two paths: Host (Solo) loads mission scene directly with no NetworkManager;
    /// Host (Coop) starts NetworkManager_Salvage. Wire the buttons in the Inspector.
    /// </summary>
    public class LobbyUI : MonoBehaviour
    {
        [SerializeField] private string lobbyScene = "02_Lobby";
        [SerializeField] private string missionScene = "Mission01_Meridian";
        [SerializeField] private TMP_Text statusLabel;

        public void OnHostSoloClicked()
        {
            statusLabel?.SetText("Starting solo lobby...");
            SceneManager.LoadScene(missionScene);
        }

        public void OnHostCoopClicked()
        {
            statusLabel?.SetText("Starting coop lobby...");
            Networking.NetworkManager_Salvage.Instance?.StartHostingCoop();
        }

        public void OnJoinClicked(string address)
        {
            statusLabel?.SetText("Joining...");
            Networking.NetworkManager_Salvage.Instance?.JoinCoop(address);
        }

        public void OnQuitClicked() => Application.Quit();
    }
}
