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
using System.Runtime.InteropServices;

namespace Gibbed
{
    public static partial class TegraSwizzle
    {
        private static bool Is64Bit()
        {
            return Marshal.SizeOf(IntPtr.Zero) == 8;
        }

        private static NativeDelegates Delegates;

        static TegraSwizzle()
        {
            if (Is64Bit() == false)
            {
                NativeDelegates delegates;
                delegates.SwizzleSurface = Native32.SwizzleSurface;
                delegates.DeswizzleSurface = Native32.DeswizzleSurface;
                delegates.SwizzledSurfaceSize = Native32.SwizzledSurfaceSize;
                delegates.DeswizzledSurfaceSize = Native32.DeswizzledSurfaceSize;
                delegates.SwizzleBlockLinear = Native32.SwizzleBlockLinear;
                delegates.DeswizzleBlockLinear = Native32.DeswizzleBlockLinear;
                delegates.SwizzledMipSize = Native32.SwizzledMipSize;
                delegates.DeswizzledMipSize = Native32.DeswizzledMipSize;
                delegates.BlockHeightMip0 = Native32.BlockHeightMip0;
                delegates.MipBlockHeight = Native32.MipBlockHeight;
                Delegates = delegates;
            }
            else
            {
                NativeDelegates delegates;
                delegates.SwizzleSurface = Native64.SwizzleSurface;
                delegates.DeswizzleSurface = Native64.DeswizzleSurface;
                delegates.SwizzledSurfaceSize = Native64.SwizzledSurfaceSize;
                delegates.DeswizzledSurfaceSize = Native64.DeswizzledSurfaceSize;
                delegates.SwizzleBlockLinear = Native64.SwizzleBlockLinear;
                delegates.DeswizzleBlockLinear = Native64.DeswizzleBlockLinear;
                delegates.SwizzledMipSize = Native64.SwizzledMipSize;
                delegates.DeswizzledMipSize = Native64.DeswizzledMipSize;
                delegates.BlockHeightMip0 = Native64.BlockHeightMip0;
                delegates.MipBlockHeight = Native64.MipBlockHeight;
                Delegates = delegates;

            }
        }

        public static void SwizzleSurface(
            uint width, uint height, uint depth,
            byte[] sourceBytes, int sourceOffset, int sourceCount,
            byte[] destinationBytes, int destinationOffset, int destinationCount,
            BlockDim blockDim,
            uint blockHeightMip0,
            uint bytesPerPixel,
            uint mipmapCount,
            uint arrayCount)
        {
            if (sourceBytes == null)
            {
                throw new ArgumentNullException(nameof(sourceBytes));
            }

            if (sourceOffset < 0 || sourceOffset >= sourceBytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(sourceOffset));
            }

            if (sourceCount <= 0 || sourceOffset + sourceCount > sourceBytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(sourceCount));
            }

            if (destinationBytes == null)
            {
                throw new ArgumentNullException(nameof(destinationBytes));
            }

            if (destinationOffset < 0 || destinationOffset >= destinationBytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(destinationOffset));
            }

            if (destinationCount <= 0 || destinationOffset + destinationCount > destinationBytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(destinationCount));
            }

            var sourceHandle = GCHandle.Alloc(sourceBytes, GCHandleType.Pinned);
            var sourceAddress = sourceHandle.AddrOfPinnedObject() + sourceOffset;
            var destinationHandle = GCHandle.Alloc(destinationBytes, GCHandleType.Pinned);
            var destinationAddress = destinationHandle.AddrOfPinnedObject() + destinationOffset;
            try
            {
                Delegates.SwizzleSurface(
                    width, height, depth,
                    sourceAddress, new(sourceCount),
                    destinationAddress, new(destinationCount),
                    blockDim,
                    blockHeightMip0,
                    bytesPerPixel,
                    mipmapCount,
                    arrayCount);
            }
            finally
            {
                destinationHandle.Free();
                sourceHandle.Free();
            }
        }

        public static void DeswizzleSurface(
            uint width, uint height, uint depth,
            byte[] sourceBytes, int sourceOffset, int sourceCount,
            byte[] destinationBytes, int destinationOffset, int destinationCount,
            BlockDim blockDim,
            uint blockHeightMip0,
            uint bytesPerPixel,
            uint mipmapCount,
            uint arrayCount)
        {
            if (sourceBytes == null)
            {
                throw new ArgumentNullException(nameof(sourceBytes));
            }

            if (sourceOffset < 0 || sourceOffset >= sourceBytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(sourceOffset));
            }

            if (sourceCount <= 0 || sourceOffset + sourceCount > sourceBytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(sourceCount));
            }

            if (destinationBytes == null)
            {
                throw new ArgumentNullException(nameof(destinationBytes));
            }

            if (destinationOffset < 0 || destinationOffset >= destinationBytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(destinationOffset));
            }

            if (destinationCount <= 0 || destinationOffset + destinationCount > destinationBytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(destinationCount));
            }

            var sourceHandle = GCHandle.Alloc(sourceBytes, GCHandleType.Pinned);
            var sourceAddress = sourceHandle.AddrOfPinnedObject() + sourceOffset;
            var destinationHandle = GCHandle.Alloc(destinationBytes, GCHandleType.Pinned);
            var destinationAddress = destinationHandle.AddrOfPinnedObject() + destinationOffset;
            try
            {
                Delegates.DeswizzleSurface(
                    width, height, depth,
                    sourceAddress, new(sourceCount),
                    destinationAddress, new(destinationCount),
                    blockDim,
                    blockHeightMip0,
                    bytesPerPixel,
                    mipmapCount,
                    arrayCount);
            }
            finally
            {
                destinationHandle.Free();
                sourceHandle.Free();
            }
        }

        public static long SwizzledSurfaceSize(
            uint width, uint height, uint depth,
            BlockDim blockDim,
            uint blockHeightMip0,
            uint bytesPerPixel,
            uint mipmapCount,
            uint arrayCount)
        {
            return Delegates.SwizzledSurfaceSize(
                width, height, depth,
                blockDim,
                blockHeightMip0,
                bytesPerPixel,
                mipmapCount,
                arrayCount).ToInt64();
        }

        public static long DeswizzledSurfaceSize(
            uint width, uint height, uint depth,
            BlockDim blockDim,
            uint bytesPerPixel,
            uint mipmapCount,
            uint arrayCount)
        {
            return Delegates.DeswizzledSurfaceSize(
                width, height, depth,
                blockDim,
                bytesPerPixel,
                mipmapCount,
                arrayCount).ToInt64();
        }

        public static void SwizzleBlockLinear(
            uint width, uint height, uint depth,
            byte[] sourceBytes, int sourceOffset, int sourceCount,
            byte[] destinationBytes, int destinationOffset, int destinationCount,
            uint blockHeight,
            uint bytesPerPixel)
        {
            if (sourceBytes == null)
            {
                throw new ArgumentNullException(nameof(sourceBytes));
            }

            if (sourceOffset < 0 || sourceOffset >= sourceBytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(sourceOffset));
            }

            if (sourceCount <= 0 || sourceOffset + sourceCount > sourceBytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(sourceCount));
            }

            if (destinationBytes == null)
            {
                throw new ArgumentNullException(nameof(destinationBytes));
            }

            if (destinationOffset < 0 || destinationOffset >= destinationBytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(destinationOffset));
            }

            if (destinationCount <= 0 || destinationOffset + destinationCount > destinationBytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(destinationCount));
            }

            var sourceHandle = GCHandle.Alloc(sourceBytes, GCHandleType.Pinned);
            var sourceAddress = sourceHandle.AddrOfPinnedObject() + sourceOffset;
            var destinationHandle = GCHandle.Alloc(destinationBytes, GCHandleType.Pinned);
            var destinationAddress = destinationHandle.AddrOfPinnedObject() + destinationOffset;
            try
            {
                Delegates.SwizzleBlockLinear(
                    width, height, depth,
                    sourceAddress, new(sourceCount),
                    destinationAddress, new(destinationCount),
                    blockHeight,
                    bytesPerPixel);
            }
            finally
            {
                destinationHandle.Free();
                sourceHandle.Free();
            }
        }

        public static void DeswizzleBlockLinear(
            uint width, uint height, uint depth,
            byte[] sourceBytes, int sourceOffset, int sourceCount,
            byte[] destinationBytes, int destinationOffset, int destinationCount,
            uint blockHeight,
            uint bytesPerPixel)
        {
            if (sourceBytes == null)
            {
                throw new ArgumentNullException(nameof(sourceBytes));
            }

            if (sourceOffset < 0 || sourceOffset >= sourceBytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(sourceOffset));
            }

            if (sourceCount <= 0 || sourceOffset + sourceCount > sourceBytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(sourceCount));
            }

            if (destinationBytes == null)
            {
                throw new ArgumentNullException(nameof(destinationBytes));
            }

            if (destinationOffset < 0 || destinationOffset >= destinationBytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(destinationOffset));
            }

            if (destinationCount <= 0 || destinationOffset + destinationCount > destinationBytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(destinationCount));
            }

            var sourceHandle = GCHandle.Alloc(sourceBytes, GCHandleType.Pinned);
            var sourceAddress = sourceHandle.AddrOfPinnedObject() + sourceOffset;
            var destinationHandle = GCHandle.Alloc(destinationBytes, GCHandleType.Pinned);
            var destinationAddress = destinationHandle.AddrOfPinnedObject() + destinationOffset;
            try
            {
                Delegates.DeswizzleBlockLinear(
                    width, height, depth,
                    sourceAddress, new(sourceCount),
                    destinationAddress, new(destinationCount),
                    blockHeight,
                    bytesPerPixel);
            }
            finally
            {
                destinationHandle.Free();
                sourceHandle.Free();
            }
        }

        public static long SwizzledMipSize(
            uint width, uint height, uint depth,
            uint blockHeight,
            uint bytesPerPixel)
        {
            return Delegates.SwizzledMipSize(
                width, height, depth,
                blockHeight,
                bytesPerPixel).ToInt64();
        }

        public static long DeswizzledMipSize(
            uint width, uint height, uint depth,
            uint bytesPerPixel)
        {
            return Delegates.DeswizzledMipSize(
                width, height, depth,
                bytesPerPixel).ToInt64();
        }

        public static uint BlockHeightMip0(uint height)
        {
            return Delegates.BlockHeightMip0(height);
        }

        public static uint MipBlockHeight(uint mipHeight, uint blockHeightMip0)
        {
            return Delegates.MipBlockHeight(mipHeight, blockHeightMip0);
        }
    }
}
