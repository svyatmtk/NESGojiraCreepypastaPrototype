﻿/*
  Based on UnityEngine.UI/UI/Animation/CoroutineTween.cs
*/

using System.Collections;
using UnityEngine;

namespace BinaryCharm.UI.TextColorButtons.Impl
{
    internal class TweenRunner<T> where T : struct, ITweenValue
    {
        protected MonoBehaviour m_CoroutineContainer;
        protected IEnumerator m_Tween;

        private static IEnumerator Start(T tweenInfo) {
            if (!tweenInfo.ValidTarget())
                yield break;

            var elapsedTime = 0.0f;
            while (elapsedTime < tweenInfo.duration) {
                elapsedTime += Time.unscaledDeltaTime;
                var percentage = Mathf.Clamp01(elapsedTime / tweenInfo.duration);
                tweenInfo.TweenValue(percentage);
                yield return null;
            }
            tweenInfo.TweenValue(1.0f);
        }

        public void Init(MonoBehaviour coroutineContainer) {
            m_CoroutineContainer = coroutineContainer;
        }

        public void StartTween(T info) {
            if (m_CoroutineContainer == null) {
                Debug.LogWarning("Coroutine container not configured... did you forget to call Init?");
                return;
            }

            if (m_Tween != null) {
                m_CoroutineContainer.StopCoroutine(m_Tween);
                m_Tween = null;
            }

            if (!m_CoroutineContainer.gameObject.activeInHierarchy) {
                info.TweenValue(1.0f);
                return;
            }

            m_Tween = Start(info);
            m_CoroutineContainer.StartCoroutine(m_Tween);
        }
    }
}
