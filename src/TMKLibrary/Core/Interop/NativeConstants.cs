using System;
using System.Collections.Generic;
using System.Text;

namespace TMKLibrary.Core.Interop
{
    /// <summary>
    /// Native constants from WDMTMKv2 library
    /// </summary>
    internal static class NativeConstants
    {
        #region Device Numbers

        /// <summary>
        /// All TMK devices
        /// </summary>
        public const int ALL_TMK = -1;

        #endregion

        #region Modes

        /// <summary>
        /// Mode is not defined
        /// </summary>
        public const int UNDEFINED_MODE = 0;

        /// <summary>
        /// Bus Controller mode
        /// </summary>
        public const int BC_MODE = 1;

        /// <summary>
        /// Remote Terminal mode
        /// </summary>
        public const int RT_MODE = 2;

        /// <summary>
        /// Monitor mode
        /// </summary>
        public const int MT_MODE = 3;

        #endregion

        #region Error Codes

        public const uint TMK_ERROR_0 = 0xE0040000;
        public const uint TMK_BAD_TYPE = 1 + TMK_ERROR_0;
        public const uint TMK_BAD_IRQ = 2 + TMK_ERROR_0;
        public const uint TMK_BAD_NUMBER = 3 + TMK_ERROR_0;
        public const uint BC_BAD_BUS = 4 + TMK_ERROR_0;
        public const uint BC_BAD_BASE = 5 + TMK_ERROR_0;
        public const uint BC_BAD_LEN = 6 + TMK_ERROR_0;
        public const uint RT_BAD_PAGE = 7 + TMK_ERROR_0;
        public const uint RT_BAD_LEN = 8 + TMK_ERROR_0;
        public const uint RT_BAD_ADDRESS = 9 + TMK_ERROR_0;
        public const uint RT_BAD_FUNC = 10 + TMK_ERROR_0;
        public const uint BC_BAD_FUNC = 11 + TMK_ERROR_0;
        public const uint TMK_BAD_FUNC = 12 + TMK_ERROR_0;
        public const uint VTMK_BAD_VERSION = 13 + TMK_ERROR_0;

        #endregion

        #region BC Interrupt Modes

        /// <summary>
        /// Interrupt on BC start
        /// </summary>
        public const uint BC_INT_START = 0x0001;

        /// <summary>
        /// Interrupt on BC stop
        /// </summary>
        public const uint BC_INT_STOP = 0x0002;

        /// <summary>
        /// Interrupt on message complete
        /// </summary>
        public const uint BC_INT_DONE = 0x0004;

        /// <summary>
        /// Interrupt when index equals zero
        /// </summary>
        public const uint BC_INT_IXEQZ = 0x0008;

        /// <summary>
        /// Interrupt on condition
        /// </summary>
        public const uint BC_INT_CONDITION = 0x0010;

        /// <summary>
        /// Interrupt on pause stop
        /// </summary>
        public const uint BC_INT_PAUSE_STOP = 0x0020;

        #endregion

        #region RT Interrupt Modes

        /// <summary>
        /// Interrupt on command with data
        /// </summary>
        public const uint RT_INT_CWD = 0x0001;

        /// <summary>
        /// Interrupt on broadcast message
        /// </summary>
        public const uint RT_INT_BCM = 0x0002;

        #endregion

        #region MIL-STD-1553B Commands

        public const uint CMD_DYNAMIC_BUS_CONTROL = 0x400;
        public const uint CMD_SYNCHRONIZE = 0x401;
        public const uint CMD_TRANSMIT_STATUS_WORD = 0x402;
        public const uint CMD_INITIATE_SELF_TEST = 0x403;
        public const uint CMD_TRANSMITTER_SHUTDOWN = 0x404;
        public const uint CMD_OVERRIDE_TRANSMITTER_SHUTDOWN = 0x405;
        public const uint CMD_INHIBIT_TERMINAL_FLAG_BIT = 0x406;
        public const uint CMD_OVERRIDE_INHIBIT_TERMINAL_FLAG_BIT = 0x407;
        public const uint CMD_RESET_REMOTE_TERMINAL = 0x408;
        public const uint CMD_TRANSMIT_VECTOR_WORD = 0x410;
        public const uint CMD_SYNCHRONIZE_WITH_DATA_WORD = 0x011;
        public const uint CMD_TRANSMIT_LAST_COMMAND_WORD = 0x412;
        public const uint CMD_TRANSMIT_BUILT_IN_TEST_WORD = 0x413;

        #endregion

        #region Limits

        /// <summary>
        /// Maximum RT address (0-31)
        /// </summary>
        public const int MAX_RT_ADDRESS = 31;

        /// <summary>
        /// Maximum subaddress (0-31)
        /// </summary>
        public const int MAX_SUBADDRESS = 31;

        /// <summary>
        /// Maximum word count (0-32, where 0 means 32)
        /// </summary>
        public const int MAX_WORD_COUNT = 32;

        /// <summary>
        /// Maximum data words in one message
        /// </summary>
        public const int MAX_DATA_WORDS = 32;

        /// <summary>
        /// Broadcast address
        /// </summary>
        public const int BROADCAST_ADDRESS = 31;

        #endregion
    }
}
