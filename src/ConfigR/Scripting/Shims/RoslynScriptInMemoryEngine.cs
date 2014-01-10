﻿// <copyright file="RoslynScriptInMemoryEngine.cs" company="ConfigR contributors">
//  Copyright (c) ConfigR contributors. (configr.net@gmail.com)
// </copyright>

namespace ConfigR.Scripting.Shims
{
    using System;
    using System.Reflection;
    using Common.Logging;
    using ScriptCs;

    [CLSCompliant(false)]
    public class RoslynScriptInMemoryEngine : RoslynScriptCompilerEngine
    {
        public RoslynScriptInMemoryEngine(IScriptHostFactory scriptHostFactory, ILog logger)
            : base(scriptHostFactory, logger)
        {
        }

        protected override Assembly LoadAssembly(byte[] exeBytes, byte[] pdbBytes)
        {
            this.Logger.Debug("Loading assembly from memory.");

            // this is required for debugging. otherwise, the .dll is not related to the .pdb
            // there might be ways of doing this without "loading", haven't found one yet
            return AppDomain.CurrentDomain.Load(exeBytes, pdbBytes);
        }
    }
}