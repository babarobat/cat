using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime
{
    public class HUDView : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _feedButton;
        [SerializeField] private Button _petButton;
        [SerializeField] private Button _kickButton;
        [SerializeField] private TMP_Text _moodIndicator;
        [SerializeField] private TMP_Text _feedbackDescription;

        private Action _playCallback;
        private Action _feedCallback;
        private Action _petCallback;
        private Action _kickCallback;

        public void Awake()
        {
            _playButton.onClick.AddListener(()=> _playCallback?.Invoke());
            _feedButton.onClick.AddListener(()=> _feedCallback?.Invoke());
            _petButton.onClick.AddListener(()=> _petCallback?.Invoke());
            _kickButton.onClick.AddListener(()=> _kickCallback?.Invoke());
            
            SetReactionLabel(string.Empty);
        }

        public void Connect(Action onPlayClick, Action onFeedClick, Action onPetClick, Action onKickClick)
        {
            _playCallback = onPlayClick;
            _feedCallback = onFeedClick;
            _petCallback = onPetClick;
            _kickCallback = onKickClick;
        }

        public void SetMoodLabel(string label) => _moodIndicator.SetText(label);

        public void SetReactionLabel(string label) => _feedbackDescription.SetText(label);

        public void CleanUp()
        {
            _playCallback = default;
            _feedCallback = default;
            _petCallback = default;
            _kickCallback = default;
        }
    }
}