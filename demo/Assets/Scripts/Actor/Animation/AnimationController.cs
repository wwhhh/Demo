using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;
using System.Collections.Generic;

namespace Game
{

    public class AnimationController : MonoBehaviour
    {
        private Animator _animator;
        private PlayableGraph _playableGraph;
        private AnimationPlayableOutput _playableOutput;
        private ScriptPlayable<AnimationTransitionPlayable> _mixer;

        private string _root;

        struct PlayableInfo
        {
            public AssetLoader<AnimationClip> loader;
            public int input;
        }
        private Dictionary<string, PlayableInfo> _cachedAssetLoaders = new Dictionary<string, PlayableInfo>();

        void OnDestroy()
        {
            UnloadAssets();
            DestroyAnimGraph();
        }

        void Awake()
        {
            _root = "character/animations/clips/";
            _animator = GetComponentInChildren<Animator>();

            CreateAnimGraph();
        }

        void CreateAnimGraph()
        {
            _playableGraph = PlayableGraph.Create();
            _playableGraph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);

            _playableOutput = AnimationPlayableOutput.Create(_playableGraph, "Animation", _animator);
            _mixer = ScriptPlayable<AnimationTransitionPlayable>.Create(_playableGraph);
            _playableOutput.SetSourcePlayable(_mixer, 0);

            _playableGraph.Play();
        }

        private void UnloadAssets()
        {
            Dictionary<string, PlayableInfo>.Enumerator e = _cachedAssetLoaders.GetEnumerator();
            while (e.MoveNext())
            {
                AssetLoaderManager.UnloadAsset(e.Current.Value.loader);
            }
            _cachedAssetLoaders.Clear();
        }

        void DestroyAnimGraph()
        {
            if (_playableGraph.IsValid())
                _playableGraph.Destroy();
        }

        int GetAnimationClip(string name)
        {
            PlayableInfo info;
            if (!_cachedAssetLoaders.TryGetValue(name, out info))
            {
                info.loader = AssetLoaderManager.instance.LoadAsset<AnimationClip>(_root + name/* + ".anim"*/);
                if (!info.loader.asset)
                {
                    Debug.LogError(_root + name + ".anim not found");
                    return -1;
                }
                info.input = _mixer.GetBehaviour().AddClipPlayable(AnimationClipPlayable.Create(_playableGraph, info.loader.asset));
                _cachedAssetLoaders.Add(name, info);
            }
            return info.input;
        }

        #region 外部

        public void Play(string name, bool hasMove, float blendTime = 0.2f)
        {
            if (_animator == null)
            {
                return;
            }

            _animator.applyRootMotion = hasMove;

            int input = GetAnimationClip(name);
            _mixer.GetBehaviour().PlayClip(input, blendTime);
        }

        #endregion
    }

}