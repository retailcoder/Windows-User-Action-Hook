using System;
using System.Collections.Generic;
using System.Linq;

namespace EventHook.Hooks.Hotkeys
{
    public class HotkeyEventArgs : EventArgs
    {
        private readonly HotkeyInfo _info;

        public HotkeyEventArgs(HotkeyInfo info)
        {
            _info = info;
        }

        public HotkeyInfo HotkeyInfo { get { return _info; } }
    }
}
