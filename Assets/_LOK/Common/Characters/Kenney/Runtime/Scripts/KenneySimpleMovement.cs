using IIMEngine.Movements2D;
using UnityEngine;

namespace LOK.Common.Characters.Kenney
{
    public class KenneySimpleMovement : MonoBehaviour
    {
        #region DO NOT MODIFY
        #pragma warning disable 0414
        
        [Header("Movements")]
        [SerializeField] private KenneyMovementsData _movementsData;
        
        #pragma warning restore 0414
        #endregion

        private IMove2DLockedReader _iMove2DLockedReaderReference;
        private IMove2DDirReader _iMove2DDirReaderReference;
        private IMove2DOrientWriter _iMove2DOrientWriterReference;
        private IMove2DSpeedWriter _iMove2DSpeedWriterReference;

        private void Awake()
        {
            //Find Movable Interfaces (at the root of this gameObject)
            //You will need to :
            // - Check if movements are locked
            // - Read Move Dir
            // - Write Move Orient
            // - Write Move Speed
            _iMove2DLockedReaderReference = GetComponent<IMove2DLockedReader>();
            _iMove2DDirReaderReference = GetComponent<IMove2DDirReader>();
            _iMove2DOrientWriterReference = GetComponent<IMove2DOrientWriter>();
            _iMove2DSpeedWriterReference = GetComponent<IMove2DSpeedWriter>();
        }

        private void Update()
        {
            //If Movements are locked
            //Force MoveSpeed to 0

            //If there is MoveDir
                //Set MoveSpeed to MovementsData.SpeedMax
                //Set Move OrientDir to Movedir
            //Else
                //Set MoveSpeed to 0
            if (_iMove2DLockedReaderReference != null && 
                _iMove2DLockedReaderReference.AreMovementsLocked)
            {
                _iMove2DSpeedWriterReference.MoveSpeed = 0;
            } else if (_iMove2DDirReaderReference.MoveDir != Vector2.zero)
            {
                _iMove2DSpeedWriterReference.MoveSpeed = _movementsData.SpeedMax;
                _iMove2DOrientWriterReference.OrientDir = _iMove2DDirReaderReference.MoveDir;
            } else
            {
                _iMove2DSpeedWriterReference.MoveSpeed = 0f;
            }
        }
    }
}