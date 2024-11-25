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
        private sealed class Native64
        {
#pragma warning disable IDE1006 // Naming Styles
            private const string DllName = "tegra_swizzle64";
            private const CallingConvention CC = CallingConvention.Cdecl;
#pragma warning restore IDE1006 // Naming Styles

            [DllImport(DllName, EntryPoint = "swizzle_surface", CallingConvention = CC)]
            public static extern void SwizzleSurface(
                uint width, uint height, uint depth,
                IntPtr source, IntPtr sourceLength,
                IntPtr destination, IntPtr destinationLength,
                BlockDim blockDim,
                uint blockHeightMip0,
                uint bytesPerPixel,
                uint mipmapCount,
                uint arrayCount);

            [DllImport(DllName, EntryPoint = "deswizzle_surface", CallingConvention = CC)]
            public static extern void DeswizzleSurface(
                uint width, uint height, uint depth,
                IntPtr source, IntPtr sourceLength,
                IntPtr destination, IntPtr destinationLength,
                BlockDim blockDim,
                uint blockHeightMip0,
                uint bytesPerPixel,
                uint mipmapCount,
                uint arrayCount);

            [DllImport(DllName, EntryPoint = "swizzled_surface_size", CallingConvention = CC)]
            public static extern IntPtr SwizzledSurfaceSize(
                uint width, uint height, uint depth,
                BlockDim blockDim,
                uint blockHeightMip0,
                uint bytesPerPixel,
                uint mipmapCount,
                uint arrayCount);

            [DllImport(DllName, EntryPoint = "deswizzled_surface_size", CallingConvention = CC)]
            public static extern IntPtr DeswizzledSurfaceSize(
                uint width, uint height, uint depth,
                BlockDim blockDim,
                uint bytesPerPixel,
                uint mipmapCount,
                uint arrayCount);

            [DllImport(DllName, EntryPoint = "swizzle_block_linear", CallingConvention = CC)]
            public static extern void SwizzleBlockLinear(
                uint width, uint height, uint depth,
                IntPtr source, IntPtr sourceLength,
                IntPtr destination, IntPtr destinationLength,
                uint blockHeight,
                uint bytesPerPixel);

            [DllImport(DllName, EntryPoint = "deswizzle_block_linear", CallingConvention = CC)]
            public static extern void DeswizzleBlockLinear(
                uint width, uint height, uint depth,
                IntPtr source, IntPtr sourceLength,
                IntPtr destination, IntPtr destinationLength,
                uint blockHeight,
                uint bytesPerPixel);

            [DllImport(DllName, EntryPoint = "swizzled_mip_size", CallingConvention = CC)]
            public static extern IntPtr SwizzledMipSize(
                uint width, uint height, uint depth,
                uint blockHeight,
                uint bytesPerPixel);

            [DllImport(DllName, EntryPoint = "deswizzled_mip_size", CallingConvention = CC)]
            public static extern IntPtr DeswizzledMipSize(
                uint width, uint height, uint depth,
                uint bytesPerPixel);

            [DllImport(DllName, EntryPoint = "block_height_mip0", CallingConvention = CC)]
            public static extern uint BlockHeightMip0(uint height);

            [DllImport(DllName, EntryPoint = "mip_block_height", CallingConvention = CC)]
            public static extern uint MipBlockHeight(uint mipHeight, uint blockHeightMip0);
        }
    }
}
