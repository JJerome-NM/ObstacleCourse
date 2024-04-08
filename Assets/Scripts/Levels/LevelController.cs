using UnityEngine;

namespace Levels
{
    public interface LevelController
    {
        public void EnableLevelPreviewCamera();

        public void DisableLevelPreviewCamera();

        public Vector3 GetSpawnPosition();

        public void PlayerIsDied(GameObject player);
    }
}