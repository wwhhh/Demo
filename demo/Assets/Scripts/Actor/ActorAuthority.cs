using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game
{

    public class ActorAuthority : Actor
    {

        private AssetLoader<GameObject> _assetLoader;

        protected override bool isActorAuthority() { return true; }

        #region Avatar

        protected override void InitAvatar()
        {
            LoadBody();
        }

        private void LoadBody()
        {
            _assetLoader = AssetLoaderManager.instance.LoadAsset<GameObject>("character/rpg-character");
            GameObject instance = Instantiate(_assetLoader.asset);
            instance.transform.parent = transform;

            if (playerTransform != null)
            {
                Object.Destroy(playerTransform.gameObject);
                playerTransform = null;
            }
            playerTransform = instance.transform;
        }

        protected override void PostInit()
        {
            base.PostInit();
            stateController.ChangeStateIdle();
        }

        #endregion

        #region Animation

        protected override void InitState()
        {
            stateController = gameObject.AddComponent<StateControllerAuthority>();
        }

        protected override void InitAnimatorMove()
        {
        }

        #endregion

        #region Skill

        #endregion

    }

}