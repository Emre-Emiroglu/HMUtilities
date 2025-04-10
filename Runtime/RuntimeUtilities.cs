using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeCatGames.HMUtilities.Runtime
{
    public static class RuntimeUtilities
    {
        #region Executes
        public static IEnumerator SetCanvasGroupAlpha(CanvasGroup canvasGroup, float targetValue, float duration = 1f)
        {
            float t = 0f;
            float startValue = canvasGroup.alpha;
            
            while (t < 1f)
            {
                t += Time.deltaTime / duration;
                
                canvasGroup.alpha = Mathf.Lerp(startValue, targetValue, t);
                
                yield return null;
            }
        }
        public static Vector3 WorldToScreenPointForUICamera(Vector3 worldPos, Camera gameCamera, Canvas screenCanvas)
        {
            Vector3 canvasPos;
            Vector3 screenPos = gameCamera.WorldToScreenPoint(worldPos);

            if (screenCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
                canvasPos = screenPos;
            else
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(screenCanvas.transform as RectTransform,
                    screenPos, screenCanvas.worldCamera, out var posRect2D);
                
                canvasPos = screenCanvas.transform.TransformPoint(posRect2D);
            }

            return canvasPos;
        }
        public static List<T> Shuffle<T>(List<T> ts)
        {
            List<T> newList = ts;
            int count = newList.Count;
            var last = count - 1;
            for (int i = 0; i < last; i++)
            {
                var r = Random.Range(i, count);
                (newList[r], newList[i]) = (newList[i], newList[r]);
            }
            return newList;
        }
        public static IList<int> BubbleSort(IList<int> ts)
        {
            IList<int> newList = ts;
            int count = newList.Count;
            for (int i = 0; i < count - 1; i++)
                for (int j = 0; j < count - 1; j++)
                    if (newList[j] > newList[j + 1])
                        (newList[j], newList[j + 1]) = (newList[j + 1], newList[j]);
            
            return newList;
        }
        public static Matrix4x4 IsoMatrix(Quaternion rotate) => Matrix4x4.Rotate(rotate);
        #endregion
    }
}