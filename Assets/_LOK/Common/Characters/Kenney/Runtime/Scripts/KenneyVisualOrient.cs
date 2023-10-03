using System.Collections;
using System.Security.Cryptography;
using IIMEngine.Movements2D;
using UnityEngine;

namespace LOK.Common.Characters.Kenney
{
    public class KenneyVisualOrient : MonoBehaviour
    {
        #region DO NOT MODIFY
        #pragma warning disable 0414

        [Header("Entity Root")]
        [SerializeField] private GameObject _entityRoot;

        [Header("Orient")]
        [SerializeField] private Transform _orientRoot;

        [Header("Flip Effect")]
        [SerializeField] private float _flipDuration = 0.5f;

        private IMove2DOrientReader _orientReader;

        private float _startScaleX = 0f;

        private bool _isFlipping = false;
        
        #pragma warning restore 0414
        #endregion

        private void Awake()
        {
            _orientReader = _entityRoot.GetComponent<IMove2DOrientReader>();
            //Store _startScaleX using _orientRoot
            _startScaleX = _orientRoot.localScale.x;
        }

        private void OnEnable()
        {
            //Set orientRoot localScale using orientReader orientX
            _orientRoot.localScale = new Vector3(_orientReader.OrientX, _orientRoot.localScale.y, _orientRoot.localScale.z);
        }

        private void OnDisable()
        {
            //Reset FLipping State
            _orientRoot.localScale = new Vector3(_startScaleX, _orientRoot.localScale.y, _orientRoot.localScale.z);
            _isFlipping = false;
        }

        private void Update()
        {
            //Detect if kenney need to flip ScaleX (using orientReader and current scale.x)
            //Bonus : you can create a flip animation using _flipDuration
            if (_orientReader.OrientX != _orientRoot.localScale.x)
            {
                _isFlipping = true;//for the coroutine
                _orientRoot.localScale = new Vector3(-_orientRoot.localScale.x, _orientRoot.localScale.y, _orientRoot.localScale.z);
            }
        }
    }
}