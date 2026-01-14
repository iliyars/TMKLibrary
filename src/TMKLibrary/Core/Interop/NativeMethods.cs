using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TMKLibrary.Core.Interop
{
    /// <summary>
    /// P/Invoke declarations for WDMTMKv2.dll
    /// This class is internal - not exposed outside the library
    /// </summary>
    internal static class NativeMethods
    {
        private const string DLL_NAME = "WDMTMKv2.dll";
        private const CallingConvention CALLING_CONVENTION = CallingConvention.Cdecl;

        #region Library Management

        /// <summary>
        /// Opens TMK library and initializes driver
        /// </summary>
        /// <returns>0 on success, error code otherwise</returns>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern uint TmkOpen();

        /// <summary>
        /// Closes TMK library and releases driver
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void TmkClose();

        /// <summary>
        /// Gets library version
        /// </summary>
        /// <returns>Version packed as DWORD</returns>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern uint GetVersion();

        #endregion

        #region Device Configuration

        /// <summary>
        /// Gets maximum device number
        /// </summary>
        /// <returns>Maximum device number (0-based)</returns>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern int tmkgetmaxn();

        /// <summary>
        /// Configures TMK device
        /// </summary>
        /// <param name="tmkNumber">Device number (0-based)</param>
        /// <returns>0 on success, error code otherwise</returns>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern int tmkconfig(int tmkNumber);

        /// <summary>
        /// Releases TMK device
        /// </summary>
        /// <param name="tmkNumber">Device number or ALL_TMK (-1)</param>
        /// <returns>0 on success</returns>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern int tmkdone(int tmkNumber);

        /// <summary>
        /// Selects TMK device for operations
        /// </summary>
        /// <param name="tmkNumber">Device number</param>
        /// <returns>0 on success, error code otherwise</returns>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern int tmkselect(int tmkNumber);

        /// <summary>
        /// Gets currently selected device number
        /// </summary>
        /// <returns>Device number</returns>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern int tmkselected();

        /// <summary>
        /// Gets device operation mode
        /// </summary>
        /// <returns>Mode constant (BC_MODE, RT_MODE, MT_MODE, UNDEFINED_MODE)</returns>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern int tmkgetmode();

        #endregion

        #region Control Bits

        /// <summary>
        /// Sets control word bits
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void tmksetcwbits(ushort bits);

        /// <summary>
        /// Clears control word bits
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void tmkclrcwbits(ushort bits);

        /// <summary>
        /// Gets control word bits
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern ushort tmkgetcwbits();

        #endregion

        #region Interrupts

        /// <summary>
        /// Defines event for interrupt notifications
        /// </summary>
        /// <param name="hEvent">Windows event handle or IntPtr.Zero to unregister</param>
        /// <param name="fEventSet">1 to set, 0 to clear</param>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void tmkdefevent(IntPtr hEvent, int fEventSet);

        /// <summary>
        /// Gets event data from last interrupt
        /// </summary>
        /// <returns>Event data</returns>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern uint tmkgetevd();

        #endregion

        #region Bus Controller Functions

        /// <summary>
        /// Resets and initializes Bus Controller
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void bcreset();

        /// <summary>
        /// Defines BC interrupt mode
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void bcdefirqmode(uint wIrqMode);

        /// <summary>
        /// Gets BC interrupt mode
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern uint bcgetirqmode();

        /// <summary>
        /// Gets maximum base address for BC
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern int bcgetmaxbase();

        /// <summary>
        /// Defines BC base address
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern int bcdefbase(int wBase);

        /// <summary>
        /// Gets BC base address
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern int bcgetbase();

        /// <summary>
        /// Writes word to BC memory
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void bcputw(int addr, ushort data);

        /// <summary>
        /// Reads word from BC memory
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern ushort bcgetw(int addr);

        /// <summary>
        /// Writes block to BC memory
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void bcputblk(int addr, [In] ushort[] pBlk, int len);

        /// <summary>
        /// Reads block from BC memory
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void bcgetblk(int addr, [Out] ushort[] pBlk, int len);

        /// <summary>
        /// Reads answer word from BC memory
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern ushort bcgetansw(int addr);

        /// <summary>
        /// Defines bus number (A or B)
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void bcdefbus(uint wBus);

        /// <summary>
        /// Gets current bus number
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern uint bcgetbus();

        /// <summary>
        /// Starts BC from given address
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void bcstart(int addr);

        /// <summary>
        /// Stops BC
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void bcstop();

        /// <summary>
        /// Gets BC state
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern int bcgetstate();

        /// <summary>
        /// Defines link address
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void bcdeflink(int addr, int link);

        /// <summary>
        /// Gets link address
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern int bcgetlink(int addr);

        #endregion

        #region Remote Terminal Functions

        /// <summary>
        /// Resets and initializes Remote Terminal
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void rtreset();

        /// <summary>
        /// Defines RT interrupt mode
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void rtdefirqmode(uint wIrqMode);

        /// <summary>
        /// Gets RT interrupt mode
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern uint rtgetirqmode();

        /// <summary>
        /// Defines RT address (0-31)
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void rtdefaddress(uint wAddr);

        /// <summary>
        /// Gets RT address
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern uint rtgetaddress();

        /// <summary>
        /// Defines working subaddress
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void rtdefsubaddr(uint wSa);

        /// <summary>
        /// Gets current subaddress
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern uint rtgetsubaddr();

        /// <summary>
        /// Writes word to RT memory
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void rtputw(int addr, ushort data);

        /// <summary>
        /// Reads word from RT memory
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern ushort rtgetw(int addr);

        /// <summary>
        /// Writes block to RT memory
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void rtputblk(int addr, [In] ushort[] pBlk, int len);

        /// <summary>
        /// Reads block from RT memory
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void rtgetblk(int addr, [Out] ushort[] pBlk, int len);

        /// <summary>
        /// Sets answer word bits
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void rtsetanswbits(ushort wBits);

        /// <summary>
        /// Clears answer word bits
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void rtclranswbits(ushort wBits);

        /// <summary>
        /// Gets answer word bits
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern ushort rtgetanswbits();

        /// <summary>
        /// Gets RT state
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern int rtgetstate();

        /// <summary>
        /// Sets/clears BUSY flag for subaddress
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void rtbusy(uint wBusy, uint wSa);

        /// <summary>
        /// Locks subaddress
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void rtlock(uint wSa);

        /// <summary>
        /// Unlocks subaddress
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void rtunlock(uint wSa);

        /// <summary>
        /// Gets command data for subaddress
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void rtgetcmddata(uint wSa, ref ushort pCmd, [Out] ushort[] pData);

        /// <summary>
        /// Puts command data for subaddress
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void rtputcmddata(uint wSa, ushort Cmd, [In] ushort[] pData);

        /// <summary>
        /// Enables/disables subaddresses
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void rtenable(uint wMask);

        #endregion

        #region Monitor Functions

        /// <summary>
        /// Resets and initializes Monitor
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void mtreset();

        /// <summary>
        /// Defines Monitor interrupt mode
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void mtdefirqmode(uint wIrqMode);

        /// <summary>
        /// Gets Monitor interrupt mode
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern uint mtgetirqmode();

        /// <summary>
        /// Gets maximum base address for Monitor
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern int mtgetmaxbase();

        /// <summary>
        /// Defines Monitor base address
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern int mtdefbase(int wBase);

        /// <summary>
        /// Gets Monitor base address
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern int mtgetbase();

        /// <summary>
        /// Writes word to Monitor memory
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void mtputw(int addr, ushort data);

        /// <summary>
        /// Reads word from Monitor memory
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern ushort mtgetw(int addr);

        /// <summary>
        /// Writes block to Monitor memory
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void mtputblk(int addr, [In] ushort[] pBlk, int len);

        /// <summary>
        /// Reads block from Monitor memory
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void mtgetblk(int addr, [Out] ushort[] pBlk, int len);

        /// <summary>
        /// Reads status word from Monitor
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern ushort mtgetsw(int addr);

        /// <summary>
        /// Starts Monitor from given address
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void mtstartx(int addr);

        /// <summary>
        /// Stops Monitor
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void mtstop();

        /// <summary>
        /// Gets Monitor state
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern int mtgetstate();

        #endregion

        #region Timer Functions

        /// <summary>
        /// Timer control
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern void tmktimer(uint wMode);

        /// <summary>
        /// Gets timer value (32-bit)
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern uint tmkgettimer();

        /// <summary>
        /// Gets timer value (64-bit)
        /// </summary>
        [DllImport(DLL_NAME, CallingConvention = CALLING_CONVENTION)]
        internal static extern ulong tmkgettimerl();

        #endregion
    }
