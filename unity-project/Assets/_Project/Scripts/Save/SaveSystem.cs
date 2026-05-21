using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SalvageCrew.Core;

namespace SalvageCrew.Save
{
    [Serializable]
    public class PersistentProfile
    {
        public int scrip;
        public int missionsCompleted;
        public List<string> ownedUpgradeIds = new();
        public float masterVolume = 1f;
        public float lookSensitivity = 0.12f;
        public bool subtitlesOn = true;
    }

    public class SaveSystem : MonoBehaviour, IService
    {
        public PersistentProfile Profile { get; private set; } = new();
        public void Register() => Services.Register(this);

        private string ProfilePath => Path.Combine(Application.persistentDataPath, "profile.json");

        private void Awake() => Load();

        public void Load()
        {
            Profile = File.Exists(ProfilePath)
                ? JsonUtility.FromJson<PersistentProfile>(File.ReadAllText(ProfilePath)) ?? new()
                : new();
        }
        public void Save()
        {
            File.WriteAllText(ProfilePath, JsonUtility.ToJson(Profile, true));
            Debug.Log($"[SaveSystem] Profile saved → {ProfilePath}");
        }

        public void AddScrip(int n) { Profile.scrip += n; Save(); }
        public void IncrementMission() { Profile.missionsCompleted++; Save(); }
        public bool OwnsUpgrade(string id) => Profile.ownedUpgradeIds.Contains(id);
        public void GrantUpgrade(string id) { if (!OwnsUpgrade(id)) { Profile.ownedUpgradeIds.Add(id); Save(); } }
    }
}
