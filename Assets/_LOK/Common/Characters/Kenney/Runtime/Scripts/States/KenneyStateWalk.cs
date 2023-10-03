using IIMEngine.Movements2D;
using UnityEngine;

namespace LOK.Common.Characters.Kenney
{
    public class KenneyStateWalk : AKenneyState
    {
        private IMove2DDirWriter _iMove2DDirWriterReference;
        private IMove2DOrientWriter _iMove2DOrientWriterReference;
        protected override void OnStateInit()
        {
            //Find Movable Interfaces inside StateMachine
            //You will need to :
            // - Check if movements are locked
            // - Read Move Dir
            // - Read Move SpeedMax
            // - Write Move Orient
            // - Write Move Speed
            _iMove2DDirWriterReference = StateMachine.GetComponent<IMove2DDirWriter>();
            _iMove2DOrientWriterReference = StateMachine.GetComponent<IMove2DOrientWriter>();
            //StateMachine.GetComponent<IMove2D>()
        }

        protected override void OnStateEnter(AKenneyState previousState)
        {
            //Force MoveSpeed to MoveSpeedMax
            //Force OrientDir to MoveDir
        }

        protected override void OnStateUpdate()
        {
            //Go to State Idle if Movements are locked

            //If there is no MoveDir
                //Go to StateDecelerate if MovementsData.StopDecelerationDuration > 0
                //Go to StateIdle otherwise

            //If MovementsData.TurnBackDecelerationDuration > 0 and the angle between MoveDir and OrientDir > MovementsData.TurnBackAngleThreshold
            //Go to StateTurnBackDecelerate

            //Force OrientDir to MoveDir
        }
    }
}