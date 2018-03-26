using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RustBuster2016.API;
using UnityEngine;

namespace FovBlocker
{
    public class FovBlockerClass : RustBuster2016.API.RustBusterPlugin
    {
        public override string Name { get { return "FovBlocker"; } }
        public override string Author { get { return "salva/juli"; } }
        public override Version Version { get { return new Version("1.0"); } }

        public static FovBlockerClass Instance;
        public override void Initialize()
        {
            Instance = this;
            if (this.IsConnectedToAServer)
            {
                RustBuster2016.API.Hooks.OnRustBusterClientConsole += OnRustBusterClientConsole;
            }
        }
        public override void DeInitialize()
        {
            RustBuster2016.API.Hooks.OnRustBusterClientConsole -= OnRustBusterClientConsole;
        }
        public void OnRustBusterClientConsole(string message)
        {
            if (message.ToLower().Contains("render.fov"))
            {
                char comillas = '"';
                Rust.Notice.Popup("", "You can´t change Fov", 10);
                RustBuster2016.API.Hooks.OnRustBusterClientConsole -= OnRustBusterClientConsole;
                ConsoleWindow.singleton.RunCommand("render.fov " + comillas + "60" + comillas);
                RustBuster2016.API.Hooks.OnRustBusterClientConsole += OnRustBusterClientConsole;
            }
        }
    }
}
