using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TMKLibrary.Core.Interop
{
    /// <summary>
    /// Native structures for TMK interop
    /// </summary>
    internal static class NativeStructures
    {
        /// <summary>
        /// TMK data message structure (aligned with C++)
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct TMK_DATA
        {
            /// <summary>
            /// First command word
            /// </summary>
            public ushort cmd1;

            /// <summary>
            /// Second command word (for RT-RT transfers)
            /// </summary>
            public ushort cmd2;

            /// <summary>
            /// Answer/Status word
            /// </summary>
            public ushort answ;

            /// <summary>
            /// Data words (up to 32 words)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public ushort[] data;

            /// <summary>
            /// Initialize data array
            /// </summary>
            public static TMK_DATA Create()
            {
                return new TMK_DATA
                {
                    data = new ushort[32]
                };
            }
        }

        /// <summary>
        /// Interrupt information structure
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct TMK_IRQ_INFO
        {
            /// <summary>
            /// Event data
            /// </summary>
            public uint dwEvD;

            /// <summary>
            /// Interrupt number
            /// </summary>
            public uint dwInt;

            /// <summary>
            /// Timestamp
            /// </summary>
            public uint dwTime;
        }
    }
