/* Copyright (c) 2024 Rick (rick 'at' gibbed 'dot' us)
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;
using static Gibbed.TegraSwizzle;

namespace Gibbed
{
    public static partial class TegraSwizzle
    {
        private static class NativeDelegate
        {
            public delegate void SwizzleSurface(
                uint width, uint height, uint depth,
                IntPtr source, IntPtr sourceLength,
                IntPtr destination, IntPtr destinationLength,
                BlockDim blockDim,
                uint blockHeightMip0,
                uint bytesPerPixel,
                uint mipmapCount,
                uint arrayCount);

            public delegate void DeswizzleSurface(
                uint width, uint height, uint depth,
                IntPtr source, IntPtr sourceLength,
                IntPtr destination, IntPtr destinationLength,
                BlockDim blockDim,
                uint blockHeightMip0,
                uint bytesPerPixel,
                uint mipmapCount,
                uint arrayCount);

            public delegate IntPtr SwizzledSurfaceSize(
                uint width, uint height, uint depth,
                BlockDim blockDim,
                uint blockHeightMip0,
                uint bytesPerPixel,
                uint mipmapCount,
                uint arrayCount);

            public delegate IntPtr DeswizzledSurfaceSize(
                uint width, uint height, uint depth,
                BlockDim blockDim,
                uint bytesPerPixel,
                uint mipmapCount,
                uint arrayCount);

            public delegate void SwizzleBlockLinear(
                uint width, uint height, uint depth,
                IntPtr source, IntPtr sourceLength,
                IntPtr destination, IntPtr destinationLength,
                uint blockHeight,
                uint bytesPerPixel);

            public delegate void DeswizzleBlockLinear(
                uint width, uint height, uint depth,
                IntPtr source, IntPtr sourceLength,
                IntPtr destination, IntPtr destinationLength,
                uint blockHeight,
                uint bytesPerPixel);

            public delegate IntPtr SwizzledMipSize(
                uint width, uint height, uint depth,
                uint blockHeight,
                uint bytesPerPixel);

            public delegate IntPtr DeswizzledMipSize(
                uint width, uint height, uint depth,
                uint bytesPerPixel);

            public delegate uint BlockHeightMip0(uint height);

            public delegate uint MipBlockHeight(uint mipHeight, uint blockHeightMip0);
        }
    }
}
