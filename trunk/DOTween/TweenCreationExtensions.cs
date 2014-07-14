﻿// Author: Daniele Giardini - http://www.demigiant.com
// Created: 2014/05/05 16:36
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using UnityEngine;

namespace DG.Tweening
{
    public static class TweenCreationExtensions
    {
        // ===================================================================================
        // TWEENER + SEQUENCES ---------------------------------------------------------------

        public static T AutoKill<T>(this T t, bool autoKillOnCompletion = true) where T : Tween
        {
            if (t.creationLocked) return t;

            t.autoKill = autoKillOnCompletion;
            return t;
        }

        public static T Id<T>(this T t, UnityEngine.Object id) where T : Tween
        {
            if (t.creationLocked) return t;

            t.unityObjectId = id;
            return t;
        }
        public static T Id<T>(this T t, int id) where T : Tween
        {
            if (t.creationLocked) return t;

            t.id = id;
            return t;
        }
        public static T Id<T>(this T t, string id) where T : Tween
        {
            if (t.creationLocked) return t;

            t.stringId = id;
            return t;
        }

        public static T Loops<T>(this T t, int loops, LoopType loopType = LoopType.Restart) where T : Tween
        {
            if (t.creationLocked) return t;

            if (loops < -1) loops = -1;
            else if (loops == 0) loops = 1;
            t.loops = loops;
            t.loopType = loopType;
            t.fullDuration = loops > -1 ? t.duration * loops : Mathf.Infinity;
            return t;
        }

        public static T OnStart<T>(this T t, TweenCallback action) where T : Tween
        {
            if (t.creationLocked) return t;

            t.onStart = action;
            return t;
        }
        public static T OnStepComplete<T>(this T t, TweenCallback action) where T : Tween
        {
            if (t.creationLocked) return t;

            t.onStepComplete = action;
            return t;
        }
        public static T OnComplete<T>(this T t, TweenCallback action) where T : Tween
        {
            if (t.creationLocked) return t;

            t.onComplete = action;
            return t;
        }

        // ===================================================================================
        // TWEENERS --------------------------------------------------------------------------

        /// <summary>Has no effect on Sequences</summary>
        public static T Delay<T>(this T t, float delay) where T : Tween
        {
            if (t.creationLocked) return t;

            t.delay = delay;
            t.delayComplete = delay <= 0;
            return t;
        }

        /// <summary>Has no effect on Sequences</summary>
        public static T Relative<T>(this T t, bool isRelative = true) where T : Tween
        {
            if (t.creationLocked) return t;

            t.isRelative = isRelative;
            return t;
        }

        /// <summary>Has no effect on Sequences</summary>
        public static T Ease<T>(this T t, EaseType easeType) where T : Tween
        {
            if (t.creationLocked) return t;

            t.ease = Utils.GetEaseFuncByType(easeType);
            return t;
        }
        /// <summary>Has no effect on Sequences</summary>
        public static T Ease<T>(this T t, AnimationCurve animCurve) where T : Tween
        {
            if (t.creationLocked) return t;

            t.easeCurve = new EaseCurve(animCurve);
            t.ease = t.easeCurve.Evaluate;
            return t;
        }
    }
}