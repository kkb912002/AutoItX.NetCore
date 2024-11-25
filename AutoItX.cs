using System;
using System.Drawing;
using System.Text;

namespace AutoIt
{
    /// <summary>The AutoItX DLL wrapper class for the native AutoItX3.dll.</summary>
    public static class AutoItX
    {
        private static readonly bool Is64BitProcess = IntPtr.Size == 8;

        /// <summary>Checks if currently running in 64bit</summary>
        public static void Init()
        {
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_Init64();
            }
            else
            {
                AutoItX_DLLImport.AU3_Init32();
            }
        }

        /// <summary>Returns the last error code.</summary>
        public static int ErrorCode()
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_error64();
            }

            return AutoItX_DLLImport.AU3_error32();
        }

        /// <summary>Changes the operation of various AutoIt functions/parameters.</summary>
        /// <param name="option"></param>
        /// <param name="optionValue"></param>
        public static int AutoItSetOption(string option, int optionValue)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_AutoItSetOption64(option, optionValue);
            }

            return AutoItX_DLLImport.AU3_AutoItSetOption32(option, optionValue);
        }

        /// <summary>Retrieves text from the clipboard.</summary>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string ClipGet(int maxLen = 1048576)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_ClipGet64(stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ClipGet32(stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Writes text to the clipboard.</summary>
        /// <param name="text"></param>
        public static void ClipPut(string text)
        {
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_ClipPut64(text);
            }
            else
            {
                AutoItX_DLLImport.AU3_ClipPut32(text);
            }
        }

        /// <summary>Sends a mouse click command to a given control.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="button"></param>
        /// <param name="numClicks"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static int ControlClick(string title, string text, string control, string button = "left", int numClicks = 1, int x = -2147483647, int y = -2147483647)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlClick64(title, text, control, button, numClicks, x, y);
            }

            return AutoItX_DLLImport.AU3_ControlClick32(title, text, control, button, numClicks, x, y);
        }

        /// <summary>Sends a mouse click command to a given control.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <param name="button"></param>
        /// <param name="numClicks"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static int ControlClick(IntPtr winHandle, IntPtr controlHandle, string button = "left", int numClicks = 1, int x = -2147483647, int y = -2147483647)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlClickByHandle64(winHandle, controlHandle, button, numClicks, x, y);
            }

            return AutoItX_DLLImport.AU3_ControlClickByHandle32(winHandle, controlHandle, button, numClicks, x, y);
        }

        /// <summary>Sends a command to a control.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="command"></param>
        /// <param name="extra"></param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string ControlCommand(string title, string text, string control, string command, string extra, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlCommand64(title, text, control, command, extra, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlCommand32(title, text, control, command, extra, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Sends a command to a control.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <param name="command"></param>
        /// <param name="extra"></param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string ControlCommand(IntPtr winHandle, IntPtr controlHandle, string command, string extra, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlCommandByHandle64(winHandle, controlHandle, command, extra, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlCommandByHandle32(winHandle, controlHandle, command, extra, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Sends a command to a ListView32 control.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="command"></param>
        /// <param name="extra1"></param>
        /// <param name="extra2"></param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string ControlListView(string title, string text, string control, string command, string extra1, string extra2, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlListView64(title, text, control, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlListView32(title, text, control, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Sends a command to a ListView32 control.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <param name="command"></param>
        /// <param name="extra1"></param>
        /// <param name="extra2"></param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string ControlListView(IntPtr winHandle, IntPtr controlHandle, string command, string extra1, string extra2, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlListViewByHandle64(winHandle, controlHandle, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlListViewByHandle32(winHandle, controlHandle, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Disables or "grays-out" a control.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        public static int ControlDisable(string title, string text, string control)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlDisable64(title, text, control);
            }

            return AutoItX_DLLImport.AU3_ControlDisable32(title, text, control);
        }

        /// <summary>Disables or "grays-out" a control.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        public static int ControlDisable(IntPtr winHandle, IntPtr controlHandle)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlDisableByHandle64(winHandle, controlHandle);
            }

            return AutoItX_DLLImport.AU3_ControlDisableByHandle32(winHandle, controlHandle);
        }

        /// <summary>Enables a "grayed-out" control.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        public static int ControlEnable(string title, string text, string control)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlEnable64(title, text, control);
            }

            return AutoItX_DLLImport.AU3_ControlEnable32(title, text, control);
        }

        /// <summary>Enables a "grayed-out" control.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        public static int ControlEnable(IntPtr winHandle, IntPtr controlHandle)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlEnableByHandle64(winHandle, controlHandle);
            }

            return AutoItX_DLLImport.AU3_ControlEnableByHandle32(winHandle, controlHandle);
        }

        /// <summary>Sets input focus to a given control on a window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        public static int ControlFocus(string title, string text, string control)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlFocus64(title, text, control);
            }

            return AutoItX_DLLImport.AU3_ControlFocus32(title, text, control);
        }

        /// <summary>Sets input focus to a given control on a window.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        public static int ControlFocus(IntPtr winHandle, IntPtr controlHandle)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlFocusByHandle64(winHandle, controlHandle);
            }

            return AutoItX_DLLImport.AU3_ControlFocusByHandle32(winHandle, controlHandle);
        }

        /// <summary>Returns the ControlRef# of the control that has keyboard focus within a specified window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string ControlGetFocus(string title = "", string text = "", int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlGetFocus64(title, text, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlGetFocus32(title, text, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Returns the ControlRef# of the control that has keyboard focus within a specified window.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string ControlGetFocus(IntPtr winHandle, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlGetFocusByHandle64(winHandle, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlGetFocusByHandle32(winHandle, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Retrieves the internal handle of a control.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="control">The control to search for.</param>
        public static IntPtr ControlGetHandle(IntPtr winHandle, string control = "")
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlGetHandle64(winHandle, control);
            }

            return AutoItX_DLLImport.AU3_ControlGetHandle32(winHandle, control);
        }

        /// <summary>Retrieves the internal handle of a control.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string ControlGetHandleAsText(string title = "", string text = "", string control = "", int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlGetHandleAsText64(title, text, control, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlGetHandleAsText32(title, text, control, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Retrieves the position and size of a control relative to it's window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        public static Rectangle ControlGetPos(string title = "", string text = "", string control = "")
        {
            AutoItX_DLLImport.RECT rect = default;
            if (Is64Bit())
            {
                _ = AutoItX_DLLImport.AU3_ControlGetPos64(title, text, control, ref rect);
            }
            else
            {
                _ = AutoItX_DLLImport.AU3_ControlGetPos32(title, text, control, ref rect);
            }

            Rectangle result = default;
            result.X = rect.left;
            result.Y = rect.top;
            result.Width = rect.right - rect.left;
            result.Height = rect.bottom - rect.top;
            return result;
        }

        /// <summary>Retrieves the position and size of a control relative to it's window.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        public static Rectangle ControlGetPos(IntPtr winHandle, IntPtr controlHandle)
        {
            AutoItX_DLLImport.RECT rect = default;
            if (Is64Bit())
            {
                _ = AutoItX_DLLImport.AU3_ControlGetPosByHandle64(winHandle, controlHandle, ref rect);
            }
            else
            {
                _ = AutoItX_DLLImport.AU3_ControlGetPosByHandle32(winHandle, controlHandle, ref rect);
            }

            Rectangle result = default;
            result.X = rect.left;
            result.Y = rect.top;
            result.Width = rect.right - rect.left;
            result.Height = rect.bottom - rect.top;
            return result;
        }

        /// <summary>Retrieves text from a control.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string ControlGetText(string title, string text, string control, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlGetText64(title, text, control, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlGetText32(title, text, control, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Retrieves text from a control.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string ControlGetText(IntPtr winHandle, IntPtr controlHandle, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlGetTextByHandle64(winHandle, controlHandle, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlGetTextByHandle32(winHandle, controlHandle, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Hides a control.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        public static int ControlHide(string title, string text, string control)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlHide64(title, text, control);
            }

            return AutoItX_DLLImport.AU3_ControlHide32(title, text, control);
        }

        /// <summary>Hides a control.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for</param>
        public static int ControlHide(IntPtr winHandle, IntPtr controlHandle)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlHideByHandle64(winHandle, controlHandle);
            }

            return AutoItX_DLLImport.AU3_ControlHideByHandle32(winHandle, controlHandle);
        }

        /// <summary>Moves a control within a window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static int ControlMove(string title, string text, string control, int x, int y, int width = -1, int height = -1)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlMove64(title, text, control, x, y, width, height);
            }

            return AutoItX_DLLImport.AU3_ControlMove32(title, text, control, x, y, width, height);
        }

        /// <summary>Moves a control within a window.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static int ControlMove(IntPtr winHandle, IntPtr controlHandle, int x, int y, int width = -1, int height = -1)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlMoveByHandle64(winHandle, controlHandle, x, y, width, height);
            }

            return AutoItX_DLLImport.AU3_ControlMoveByHandle32(winHandle, controlHandle, x, y, width, height);
        }

        /// <summary>Sends a string of characters to a control.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="sendText"></param>
        /// <param name="mode"></param>
        public static int ControlSend(string title, string text, string control, string sendText, int mode = 0)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlSend64(title, text, control, sendText, mode);
            }

            return AutoItX_DLLImport.AU3_ControlSend32(title, text, control, sendText, mode);
        }

        /// <summary>Sends a string of characters to a control.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <param name="sendText"></param>
        /// <param name="mode"></param>
        public static int ControlSend(IntPtr winHandle, IntPtr controlHandle, string sendText, int mode = 0)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlSendByHandle64(winHandle, controlHandle, sendText, mode);
            }

            return AutoItX_DLLImport.AU3_ControlSendByHandle32(winHandle, controlHandle, sendText, mode);
        }


        /// <summary>Sets text of a control.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="controlText"></param>
        public static int ControlSetText(string title, string text, string control, string controlText)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlSetText64(title, text, control, controlText);
            }

            return AutoItX_DLLImport.AU3_ControlSetText32(title, text, control, controlText);
        }

        /// <summary>Sets text of a control.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <param name="controlText"></param>
        public static int ControlSetText(IntPtr winHandle, IntPtr controlHandle, string controlText)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlSetTextByHandle64(winHandle, controlHandle, controlText);
            }

            return AutoItX_DLLImport.AU3_ControlSetTextByHandle32(winHandle, controlHandle, controlText);
        }

        /// <summary>Shows a control that was hidden.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        public static int ControlShow(string title, string text, string control)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlShow64(title, text, control);
            }

            return AutoItX_DLLImport.AU3_ControlShow32(title, text, control);
        }

        /// <summary>Shows a control that was hidden.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        public static int ControlShow(IntPtr winHandle, IntPtr controlHandle)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ControlShowByHandle64(winHandle, controlHandle);
            }

            return AutoItX_DLLImport.AU3_ControlShowByHandle32(winHandle, controlHandle);
        }

        /// <summary>Sends a command to a TreeView32 control.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="control">The control to search for.</param>
        /// <param name="command"></param>
        /// <param name="extra1"></param>
        /// <param name="extra2"></param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string ControlTreeView(string title, string text, string control, string command, string extra1, string extra2, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlTreeView64(title, text, control, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlTreeView32(title, text, control, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Sends a command to a TreeView32 control.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="controlHandle">The control handle to search for.</param>
        /// <param name="command"></param>
        /// <param name="extra1"></param>
        /// <param name="extra2"></param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string ControlTreeView(IntPtr winHandle, IntPtr controlHandle, string command, string extra1, string extra2, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_ControlTreeViewByHandle64(winHandle, controlHandle, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_ControlTreeViewByHandle32(winHandle, controlHandle, command, extra1, extra2, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Maps a network drive.</summary>
        /// <param name="device"></param>
        /// <param name="share"></param>
        /// <param name="flags"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        public static string DriveMapAdd(string device, string share, int flags = 0, string user = "", string password = "")
        {
            StringBuilder stringBuilder = new StringBuilder(4);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_DriveMapAdd64(device, share, flags, user, password, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_DriveMapAdd32(device, share, flags, user, password, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Disconnects a network drive.</summary>
        /// <param name="device"></param>
        public static int DriveMapDel(string device)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_DriveMapDel64(device);
            }

            return AutoItX_DLLImport.AU3_DriveMapDel32(device);
        }

        /// <summary>Retreives the details of a mapped drive.</summary>
        /// <param name="device"></param>
        public static string DriveMapGet(string device)
        {
            StringBuilder stringBuilder = new StringBuilder(260);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_DriveMapGet64(device, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_DriveMapGet32(device, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Checks if the current user has administrator privileges.</summary>
        public static int IsAdmin()
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_IsAdmin64();
            }

            return AutoItX_DLLImport.AU3_IsAdmin32();
        }

        /// <summary>Perform a mouse click operation.</summary>
        /// <param name="button"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="numClicks"></param>
        /// <param name="speed"></param>
        public static int MouseClick(string button = "LEFT", int x = -2147483647, int y = -2147483647, int numClicks = 1, int speed = -1)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_MouseClick64(button, x, y, numClicks, speed);
            }

            return AutoItX_DLLImport.AU3_MouseClick32(button, x, y, numClicks, speed);
        }

        /// <summary>Perform a mouse click and drag operation.</summary>
        /// <param name="button"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="speed"></param>
        public static int MouseClickDrag(string button, int x1, int y1, int x2, int y2, int speed = -1)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_MouseClickDrag64(button, x1, y1, x2, y2, speed);
            }

            return AutoItX_DLLImport.AU3_MouseClickDrag32(button, x1, y1, x2, y2, speed);
        }

        /// <summary>Perform a mouse down event at the current mouse position.</summary>
        /// <param name="button"></param>
        public static void MouseDown(string button = "LEFT")
        {
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_MouseDown64(button);
            }
            else
            {
                AutoItX_DLLImport.AU3_MouseDown32(button);
            }
        }

        /// <summary>Returns a cursor ID Number of the current Mouse Cursor.</summary>
        public static int MouseGetCursor()
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_MouseGetCursor64();
            }

            return AutoItX_DLLImport.AU3_MouseGetCursor32();
        }

        /// <summary>Retrieves the current position of the mouse cursor.</summary>
        public static Point MouseGetPos()
        {
            AutoItX_DLLImport.POINT pt = default;
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_MouseGetPos64(ref pt);
            }
            else
            {
                AutoItX_DLLImport.AU3_MouseGetPos32(ref pt);
            }

            return new Point(pt.x, pt.y);
        }

        /// <summary>Moves the mouse pointer.</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="speed"></param>
        public static int MouseMove(int x, int y, int speed = -1)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_MouseMove64(x, y, speed);
            }

            return AutoItX_DLLImport.AU3_MouseMove32(x, y, speed);
        }

        /// <summary>Perform a mouse up event at the current mouse position.</summary>
        /// <param name="button"></param>
        public static void MouseUp(string button = "LEFT")
        {
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_MouseUp64(button);
            }
            else
            {
                AutoItX_DLLImport.AU3_MouseUp32(button);
            }
        }

        /// <summary>Moves the mouse wheel up or down.</summary>
        /// <param name="direction">"up" or "down"</param>
        /// <param name="numClicks"></param>
        public static void MouseWheel(string direction, int numClicks = 1)
        {
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_MouseWheel64(direction, numClicks);
            }
            else
            {
                AutoItX_DLLImport.AU3_MouseWheel32(direction, numClicks);
            }
        }

        /// <summary>Generates a checksum for a region of pixels.</summary>
        /// <param name="rect"></param>
        /// <param name="step"></param>
        public static uint PixelChecksum(Rectangle rect, int step = 1)
        {
            AutoItX_DLLImport.RECT rect2 = default;
            rect2.left = rect.Left;
            rect2.top = rect.Top;
            rect2.right = rect.Right;
            rect2.bottom = rect.Bottom;
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_PixelChecksum64(ref rect2, step);
            }

            return AutoItX_DLLImport.AU3_PixelChecksum32(ref rect2, step);
        }

        /// <summary>Returns a pixel color according to x,y pixel coordinates.</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static int PixelGetColor(int x, int y)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_PixelGetColor64(x, y);
            }

            return AutoItX_DLLImport.AU3_PixelGetColor32(x, y);
        }

        /// <summary>Searches a rectangle of pixels for the pixel color provided.</summary>
        /// <param name="rect"></param>
        /// <param name="color"></param>
        /// <param name="shade"></param>
        /// <param name="step"></param>
        public static Point PixelSearch(Rectangle rect, int color, int shade = 0, int step = 1)
        {
            AutoItX_DLLImport.RECT rect2 = default;
            rect2.left = rect.Left;
            rect2.top = rect.Top;
            rect2.right = rect.Right;
            rect2.bottom = rect.Bottom;
            AutoItX_DLLImport.POINT winPoint = default;
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_PixelSearch64(ref rect2, color, shade, step, ref winPoint);
            }
            else
            {
                AutoItX_DLLImport.AU3_PixelSearch32(ref rect2, color, shade, step, ref winPoint);
            }

            return new Point(winPoint.x, winPoint.y);
        }

        /// <summary>Terminates a named process.</summary>
        /// <param name="process"></param>
        public static int ProcessClose(string process)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ProcessClose64(process);
            }

            return AutoItX_DLLImport.AU3_ProcessClose32(process);
        }

        /// <summary>Checks to see if a specified process exists.</summary>
        /// <param name="process"></param>
        public static int ProcessExists(string process)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ProcessExists64(process);
            }

            return AutoItX_DLLImport.AU3_ProcessExists32(process);
        }

        /// <summary>Changes the priority of a process.</summary>
        /// <param name="process"></param>
        /// <param name="priority"></param>
        public static int ProcessSetPriority(string process, int priority)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ProcessSetPriority64(process, priority);
            }

            return AutoItX_DLLImport.AU3_ProcessSetPriority32(process, priority);
        }

        /// <summary>Pauses script execution until a given process exists.</summary>
        /// <param name="process"></param>
        /// <param name="timeout"></param>
        public static int ProcessWait(string process, int timeout)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ProcessWait64(process, timeout);
            }

            return AutoItX_DLLImport.AU3_ProcessWait32(process, timeout);
        }

        /// <summary>Pauses script execution until a given process does not exist.</summary>
        /// <param name="process"></param>
        /// <param name="timeout"></param>
        public static int ProcessWaitClose(string process, int timeout)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_ProcessWaitClose64(process, timeout);
            }

            return AutoItX_DLLImport.AU3_ProcessWaitClose32(process, timeout);
        }

        /// <summary>Runs an external program.</summary>
        /// <param name="program">The program to run.</param>
        /// <param name="dir">The working directory to use.</param>
        /// <param name="showFlag"></param>
        public static int Run(string program, string dir, int showFlag = 1)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_Run64(program, dir, showFlag);
            }

            return AutoItX_DLLImport.AU3_Run32(program, dir, showFlag);
        }

        /// <summary>Runs an external program as a specified user.</summary>
        /// <param name="user"></param>
        /// <param name="domain"></param>
        /// <param name="password"></param>
        /// <param name="logonFlag"></param>
        /// <param name="program">The program to run.</param>
        /// <param name="dir">The working directory to use.</param>
        /// <param name="showFlag"></param>
        public static int RunAs(string user, string domain, string password, int logonFlag, string program, string dir, int showFlag = 1)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_RunAs64(user, domain, password, logonFlag, program, dir, showFlag);
            }

            return AutoItX_DLLImport.AU3_RunAs32(user, domain, password, logonFlag, program, dir, showFlag);
        }

        /// <summary>Runs an external program as a specified user and wait for it to close.</summary>
        /// <param name="user"></param>
        /// <param name="domain"></param>
        /// <param name="password"></param>
        /// <param name="logonFlag"></param>
        /// <param name="program">The program to run.</param>
        /// <param name="dir">The working directory to use.</param>
        /// <param name="showFlag"></param>
        public static int RunAsWait(string user, string domain, string password, int logonFlag, string program, string dir, int showFlag = 1)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_RunAsWait64(user, domain, password, logonFlag, program, dir, showFlag);
            }

            return AutoItX_DLLImport.AU3_RunAsWait32(user, domain, password, logonFlag, program, dir, showFlag);
        }

        /// <summary>Runs an external program and wait for it to close.</summary>
        /// <param name="program">The program to run.</param>
        /// <param name="dir">The working directory to use.</param>
        /// <param name="showFlag"></param>
        public static int RunWait(string program, string dir, int showFlag = 1)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_RunWait64(program, dir, showFlag);
            }

            return AutoItX_DLLImport.AU3_RunWait32(program, dir, showFlag);
        }

        /// <summary>Sends simulated keystrokes to the active window.</summary>
        /// <param name="sendText"></param>
        /// <param name="mode"></param>
        public static void Send(string sendText, int mode = 0)
        {
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_Send64(sendText, mode);
            }
            else
            {
                AutoItX_DLLImport.AU3_Send32(sendText, mode);
            }
        }

        /// <summary>Shut down the system.</summary>
        /// <param name="flag"></param>
        public static int Shutdown(int flag)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_Shutdown64(flag);
            }

            return AutoItX_DLLImport.AU3_Shutdown32(flag);
        }

        /// <summary>Pause for specified number of milliseconds.</summary>
        /// <param name="milliseconds"></param>
        public static void Sleep(int milliseconds)
        {
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_Sleep64(milliseconds);
            }
            else
            {
                AutoItX_DLLImport.AU3_Sleep32(milliseconds);
            }
        }

        /// <summary>Retrieves the text from a standard status bar control.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="part"></param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string StatusBarGetText(string title = "", string text = "", int part = 1, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_StatusbarGetText64(title, text, part, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_StatusbarGetText32(title, text, part, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Retrieves the text from a standard status bar control.</summary>
        /// <param name="winHandle"></param>
        /// <param name="part"></param>
        /// <param name="maxLen"></param>
        public static string StatusBarGetText(IntPtr winHandle, int part = 1, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_StatusbarGetTextByHandle64(winHandle, part, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_StatusbarGetTextByHandle32(winHandle, part, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Retrieves the text from a standard status bar control.</summary>
        /// <param name="tip"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void ToolTip(string tip, int x = -2147483647, int y = -2147483647)
        {
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_ToolTip64(tip, x, y);
            }
            else
            {
                AutoItX_DLLImport.AU3_ToolTip32(tip, x, y);
            }
        }

        /// <summary>Activates (gives focus to) a window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        public static int WinActivate(string title = "", string text = "")
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinActivate64(title, text);
            }

            return AutoItX_DLLImport.AU3_WinActivate32(title, text);
        }

        /// <summary>Activates (gives focus to) a window.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        public static int WinActivate(IntPtr winHandle)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinActivateByHandle64(winHandle);
            }

            return AutoItX_DLLImport.AU3_WinActivateByHandle32(winHandle);
        }

        /// <summary>Checks to see if a specified window exists and is currently active.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        public static int WinActive(string title = "", string text = "")
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinActive64(title, text);
            }

            return AutoItX_DLLImport.AU3_WinActive32(title, text);
        }

        /// <summary>Checks to see if a specified window exists and is currently active.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        public static int WinActive(IntPtr winHandle)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinActiveByHandle64(winHandle);
            }

            return AutoItX_DLLImport.AU3_WinActiveByHandle32(winHandle);
        }

        /// <summary>Checks to see if a specified window exists.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        public static int WinExists(string title = "", string text = "")
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinExists64(title, text);
            }

            return AutoItX_DLLImport.AU3_WinExists32(title, text);
        }

        /// <summary>Checks to see if a specified window exists.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        public static int WinExists(IntPtr winHandle)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinExistsByHandle64(winHandle);
            }

            return AutoItX_DLLImport.AU3_WinExistsByHandle32(winHandle);
        }

        /// <summary>Closes a window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        public static int WinClose(string title = "", string text = "")
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinClose64(title, text);
            }

            return AutoItX_DLLImport.AU3_WinClose32(title, text);
        }

        /// <summary>Closes a window.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        public static int WinClose(IntPtr winHandle)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinCloseByHandle64(winHandle);
            }

            return AutoItX_DLLImport.AU3_WinCloseByHandle32(winHandle);
        }

        /// <summary>Returns the coordinates of the caret in the foreground window.</summary>
        public static Point WinGetCaretPos()
        {
            AutoItX_DLLImport.POINT pt;
            if (Is64Bit())
            {
                _ = AutoItX_DLLImport.AU3_WinGetCaretPos64(out pt);
            }
            else
            {
                _ = AutoItX_DLLImport.AU3_WinGetCaretPos32(out pt);
            }

            return new Point(pt.x, pt.y);
        }

        /// <summary>Retrieves the classes from a window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string WinGetClassList(string title = "", string text = "", int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetClassList64(title, text, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetClassList32(title, text, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Retrieves the classes from a window.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string WinGetClassList(IntPtr winHandle, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetClassListByHandle64(winHandle, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetClassListByHandle32(winHandle, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Retrieves the size of a given window's client area.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        public static Rectangle WinGetClientSize(string title = "", string text = "")
        {
            AutoItX_DLLImport.RECT rect = default;
            if (Is64Bit())
            {
                _ = AutoItX_DLLImport.AU3_WinGetClientSize64(title, text, ref rect);
            }
            else
            {
                _ = AutoItX_DLLImport.AU3_WinGetClientSize32(title, text, ref rect);
            }

            Rectangle result = default;
            result.X = rect.left;
            result.Y = rect.top;
            result.Width = rect.right - rect.left;
            result.Height = rect.bottom - rect.top;
            return result;
        }

        /// <summary>Retrieves the size of a given window's client area.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        public static Rectangle WinGetClientSize(IntPtr winHandle)
        {
            AutoItX_DLLImport.RECT rect = default;
            if (Is64Bit())
            {
                _ = AutoItX_DLLImport.AU3_WinGetClientSizeByHandle64(winHandle, ref rect);
            }
            else
            {
                _ = AutoItX_DLLImport.AU3_WinGetClientSizeByHandle32(winHandle, ref rect);
            }

            Rectangle result = default;
            result.X = rect.left;
            result.Y = rect.top;
            result.Width = rect.right - rect.left;
            result.Height = rect.bottom - rect.top;
            return result;
        }

        /// <summary>Retrieves the internal handle of a window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        public static IntPtr WinGetHandle(string title = "", string text = "")
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinGetHandle64(title, text);
            }

            return AutoItX_DLLImport.AU3_WinGetHandle32(title, text);
        }

        /// <summary>Retrieves the internal handle of a window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string WinGetHandleAsText(string title = "", string text = "", int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetHandleAsText64(title, text, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetHandleAsText32(title, text, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Retrieves the position and size of a given window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        public static Rectangle WinGetPos(string title = "", string text = "")
        {
            AutoItX_DLLImport.RECT rect = default;
            if (Is64Bit())
            {
                _ = AutoItX_DLLImport.AU3_WinGetPos64(title, text, ref rect);
            }
            else
            {
                _ = AutoItX_DLLImport.AU3_WinGetPos32(title, text, ref rect);
            }

            Rectangle result = default;
            result.X = rect.left;
            result.Y = rect.top;
            result.Width = rect.right - rect.left;
            result.Height = rect.bottom - rect.top;
            return result;
        }

        /// <summary>Retrieves the position and size of a given window.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        public static Rectangle WinGetPos(IntPtr winHandle)
        {
            AutoItX_DLLImport.RECT rect = default;
            if (Is64Bit())
            {
                _ = AutoItX_DLLImport.AU3_WinGetPosByHandle64(winHandle, ref rect);
            }
            else
            {
                _ = AutoItX_DLLImport.AU3_WinGetPosByHandle32(winHandle, ref rect);
            }

            Rectangle result = default;
            result.X = rect.left;
            result.Y = rect.top;
            result.Width = rect.right - rect.left;
            result.Height = rect.bottom - rect.top;
            return result;
        }

        /// <summary>Retrieves the Process ID (PID) associated with a window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        public static uint WinGetProcess(string title = "", string text = "")
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinGetProcess64(title, text);
            }

            return AutoItX_DLLImport.AU3_WinGetProcess32(title, text);
        }

        /// <summary>Retrieves the Process ID (PID) associated with a window.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        public static uint WinGetProcess(IntPtr winHandle)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinGetProcessByHandle64(winHandle);
            }

            return AutoItX_DLLImport.AU3_WinGetProcessByHandle32(winHandle);
        }

        /// <summary>Retrieves the state of a given window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        public static int WinGetState(string title = "", string text = "")
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinGetState64(title, text);
            }

            return AutoItX_DLLImport.AU3_WinGetState32(title, text);
        }

        /// <summary>Retrieves the state of a given window.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        public static int WinGetState(IntPtr winHandle)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinGetStateByHandle64(winHandle);
            }

            return AutoItX_DLLImport.AU3_WinGetStateByHandle32(winHandle);
        }

        /// <summary>Retrieves the text from a window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string WinGetText(string title = "", string text = "", int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetText64(title, text, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetText32(title, text, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Retrieves the text from a window.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string WinGetText(IntPtr winHandle, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetTextByHandle64(winHandle, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetTextByHandle32(winHandle, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Retrieves the full title from a window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string WinGetTitle(string title = "", string text = "", int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetTitle64(title, text, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetTitle32(title, text, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Retrieves the full title from a window.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="maxLen">The maximum number of characters to return.</param>
        public static string WinGetTitle(IntPtr winHandle, int maxLen = 65535)
        {
            StringBuilder stringBuilder = new StringBuilder(maxLen);
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinGetTitleByHandle64(winHandle, stringBuilder, stringBuilder.Capacity);
            }
            else
            {
                AutoItX_DLLImport.AU3_WinGetTitleByHandle32(winHandle, stringBuilder, stringBuilder.Capacity);
            }

            return stringBuilder.ToString();
        }

        /// <summary>Forces a window to close.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        public static int WinKill(string title = "", string text = "")
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinKill64(title, text);
            }

            return AutoItX_DLLImport.AU3_WinKill32(title, text);
        }

        /// <summary>Forces a window to close.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        public static int WinKill(IntPtr winHandle)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinKillByHandle64(winHandle);
            }

            return AutoItX_DLLImport.AU3_WinKillByHandle32(winHandle);
        }

        /// <summary>Minimizes all windows.</summary>
        public static void WinMinimizeAll()
        {
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinMinimizeAll64();
            }
            else
            {
                AutoItX_DLLImport.AU3_WinMinimizeAll32();
            }
        }

        /// <summary>Undoes a previous WinMinimizeAll function.</summary>
        public static void WinMinimizeAllUndo()
        {
            if (Is64Bit())
            {
                AutoItX_DLLImport.AU3_WinMinimizeAllUndo64();
            }
            else
            {
                AutoItX_DLLImport.AU3_WinMinimizeAllUndo32();
            }
        }

        /// <summary>Moves and/or resizes a window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static int WinMove(string title, string text, int x, int y, int width = -1, int height = -1)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinMove64(title, text, x, y, width, height);
            }

            return AutoItX_DLLImport.AU3_WinMove32(title, text, x, y, width, height);
        }

        /// <summary>Moves and/or resizes a window.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static int WinMove(IntPtr winHandle, int x, int y, int width = -1, int height = -1)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinMoveByHandle64(winHandle, x, y, width, height);
            }

            return AutoItX_DLLImport.AU3_WinMoveByHandle32(winHandle, x, y, width, height);
        }

        /// <summary>Change a window's "Always On Top" attribute.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="flag"></param>
        public static int WinSetOnTop(string title, string text, int flag)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinSetOnTop64(title, text, flag);
            }

            return AutoItX_DLLImport.AU3_WinSetOnTop32(title, text, flag);
        }

        /// <summary>Change a window's "Always On Top" attribute.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="flag"></param>
        public static int WinSetOnTop(IntPtr winHandle, int flag)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinSetOnTopByHandle64(winHandle, flag);
            }

            return AutoItX_DLLImport.AU3_WinSetOnTopByHandle32(winHandle, flag);
        }

        /// <summary>Shows, hides, minimizes, maximizes, or restores a window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="flags"></param>
        public static int WinSetState(string title, string text, int flags)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinSetState64(title, text, flags);
            }

            return AutoItX_DLLImport.AU3_WinSetState32(title, text, flags);
        }

        /// <summary>Shows, hides, minimizes, maximizes, or restores a window.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="flags"></param>
        public static int WinSetState(IntPtr winHandle, int flags)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinSetStateByHandle64(winHandle, flags);
            }

            return AutoItX_DLLImport.AU3_WinSetStateByHandle32(winHandle, flags);
        }

        /// <summary>Changes the title of a window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="newTitle"></param>
        public static int WinSetTitle(string title, string text, string newTitle)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinSetTitle64(title, text, newTitle);
            }

            return AutoItX_DLLImport.AU3_WinSetTitle32(title, text, newTitle);
        }

        /// <summary>Changes the title of a window.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="newTitle"></param>
        public static int WinSetTitle(IntPtr winHandle, string newTitle)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinSetTitleByHandle64(winHandle, newTitle);
            }

            return AutoItX_DLLImport.AU3_WinSetTitleByHandle32(winHandle, newTitle);
        }

        /// <summary>Sets the transparency of a window.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="trans">0-255</param>
        public static int WinSetTrans(string title, string text, int trans)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinSetTrans64(title, text, trans);
            }

            return AutoItX_DLLImport.AU3_WinSetTrans32(title, text, trans);
        }

        /// <summary>Sets the transparency of a window.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="trans">0-255</param>
        public static int WinSetTrans(IntPtr winHandle, int trans)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinSetTransByHandle64(winHandle, trans);
            }

            return AutoItX_DLLImport.AU3_WinSetTransByHandle32(winHandle, trans);
        }

        /// <summary>Pauses execution of the script until the requested window exists.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="timeout"></param>
        public static int WinWait(string title = "", string text = "", int timeout = 0)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinWait64(title, text, timeout);
            }

            return AutoItX_DLLImport.AU3_WinWait32(title, text, timeout);
        }

        /// <summary>Pauses execution of the script until the requested window exists.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="timeout"></param>
        public static int WinWait(IntPtr winHandle, int timeout = 0)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinWaitByHandle64(winHandle, timeout);
            }

            return AutoItX_DLLImport.AU3_WinWaitByHandle32(winHandle, timeout);
        }

        /// <summary>Pauses execution of the script until the requested window is active.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="timeout"></param>
        public static int WinWaitActive(string title = "", string text = "", int timeout = 0)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinWaitActive64(title, text, timeout);
            }

            return AutoItX_DLLImport.AU3_WinWaitActive32(title, text, timeout);
        }

        /// <summary>Pauses execution of the script until the requested window is active.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="timeout"></param>
        public static int WinWaitActive(IntPtr winHandle, int timeout = 0)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinWaitActiveByHandle64(winHandle, timeout);
            }

            return AutoItX_DLLImport.AU3_WinWaitActiveByHandle32(winHandle, timeout);
        }

        /// <summary>Pauses execution of the script until the requested window does not exist.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="timeout"></param>
        public static int WinWaitClose(string title = "", string text = "", int timeout = 0)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinWaitClose64(title, text, timeout);
            }

            return AutoItX_DLLImport.AU3_WinWaitClose32(title, text, timeout);
        }

        /// <summary>Pauses execution of the script until the requested window does not exist.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="timeout"></param>
        public static int WinWaitClose(IntPtr winHandle, int timeout = 0)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinWaitCloseByHandle64(winHandle, timeout);
            }

            return AutoItX_DLLImport.AU3_WinWaitCloseByHandle32(winHandle, timeout);
        }

        /// <summary>Pauses execution of the script until the requested window is not active.</summary>
        /// <param name="title">The window title to search for.</param>
        /// <param name="text">The window text to search for.</param>
        /// <param name="timeout"></param>
        public static int WinWaitNotActive(string title = "", string text = "", int timeout = 0)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinWaitNotActive64(title, text, timeout);
            }

            return AutoItX_DLLImport.AU3_WinWaitNotActive32(title, text, timeout);
        }

        /// <summary>Pauses execution of the script until the requested window is not active.</summary>
        /// <param name="winHandle">The window handle to search for.</param>
        /// <param name="timeout"></param>
        public static int WinWaitNotActive(IntPtr winHandle, int timeout = 0)
        {
            if (Is64Bit())
            {
                return AutoItX_DLLImport.AU3_WinWaitNotActiveByHandle64(winHandle, timeout);
            }

            return AutoItX_DLLImport.AU3_WinWaitNotActiveByHandle32(winHandle, timeout);
        }

        private static bool Is64Bit()
        {
            return Is64BitProcess;
        }
    }
}
