using UnityEngine;
using UnityEngine.SceneManagement;

namespace SalvageCrew.Core
{
    [DefaultExecutionOrder(-10000)]
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private string firstSceneToLoad = "01_MainMenu";

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Debug.Log("[Bootstrap] Initialising services...");
            foreach (var s in GetComponentsInChildren<IService>(true))
            {
                s.Register();
                Debug.Log($"[Bootstrap] Registered {s.GetType().Name}");
            }
        }

        private void Start()
        {
            if (!string.IsNullOrEmpty(firstSceneToLoad))
            {
                SceneManager.LoadScene(firstSceneToLoad, LoadSceneMode.Additive);
            }
        }
    }

    public interface IService { void Register(); }
}
