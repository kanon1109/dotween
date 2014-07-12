﻿// Author: Daniele Giardini - http://www.demigiant.com
// Created: 2014/07/10 19:17
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
// 

using DG.Tweening.Core;
using DG.Tweening.Plugins.Core;
using UnityEngine;

namespace DG.Tweening.Plugins.DefaultPlugins
{
    public class RectPlugin : ABSTweenPlugin<Rect, Rect, PlugRect.Options>
    {
        public override Rect ConvertT1toT2(PlugRect.Options options, Rect value)
        {
            return value;
        }

        public override Rect GetRelativeEndValue(PlugRect.Options options, Rect startValue, Rect changeValue)
        {
            startValue.x += changeValue.x;
            startValue.y += changeValue.y;
            startValue.width += changeValue.width;
            startValue.height += changeValue.height;
            return startValue;
        }

        public override Rect GetChangeValue(PlugRect.Options options, Rect startValue, Rect endValue)
        {
            endValue.x -= startValue.x;
            endValue.y -= startValue.y;
            endValue.width -= startValue.width;
            endValue.height -= startValue.height;
            return endValue;
        }

        public override Rect Evaluate(PlugRect.Options options, bool isRelative, MemberGetter<Rect> getter, float elapsed, Rect startValue, Rect changeValue, float duration, EaseFunction ease)
        {
            startValue.x = ease(elapsed, startValue.x, changeValue.x, duration, 0, 0);
            startValue.y = ease(elapsed, startValue.y, changeValue.y, duration, 0, 0);
            startValue.width = ease(elapsed, startValue.width, changeValue.width, duration, 0, 0);
            startValue.height = ease(elapsed, startValue.height, changeValue.height, duration, 0, 0);
            if (options.snapping) {
                startValue.x = Mathf.Round(startValue.x);
                startValue.y = Mathf.Round(startValue.y);
                startValue.width = Mathf.Round(startValue.width);
                startValue.height = Mathf.Round(startValue.height);
            }
            return startValue;
        }
    }
}