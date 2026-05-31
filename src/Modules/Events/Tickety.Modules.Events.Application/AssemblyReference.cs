using System.Reflection;

namespace Tickety.Modules.Events.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}

