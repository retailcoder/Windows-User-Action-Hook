﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EventHook.Hooks.Hotkeys;

namespace EventHook
{
    public static class HotkeyWatcher
    {
        private static readonly HotkeyListener Listener = new HotkeyListener();
        public static event EventHandler<HotkeyEventArgs> OnHotkeyInput;

        static HotkeyWatcher()
        {
            Listener.OnHotkey += Listener_OnHotkey;
        }

        private static void Listener_OnHotkey(object sender, HotkeyEventArgs e)
        {
            var handler = OnHotkeyInput;
            if (handler == null) return;

            handler.Invoke(sender, e);
        }

        public static void Register(Keys hotkey)
        {
            var info = new HotkeyInfo(hotkey);

            if (info.HotkeyModifiers == Keys.None)
                throw new ArgumentException("Hotkey requires a modifier key.");

            Listener.AddHotkey(info);
        }

        public static void Unregister(Keys hotkey)
        {
            var info = new HotkeyInfo(hotkey);
            Listener.RemoveHotkey(info);
        }

        /// <summary>
        /// Registers all inactive hotkeys.
        /// </summary>
        public static void Start()
        {
            Listener.Start();
        }

        /// <summary>
        /// Unregisters all active hotkeys.
        /// </summary>
        public static void Stop()
        {
            Listener.Stop();
        }
    }
}
